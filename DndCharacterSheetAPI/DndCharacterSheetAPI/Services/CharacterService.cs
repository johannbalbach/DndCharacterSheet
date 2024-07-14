using AutoMapper;
using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Application.Models.DTO.Character;
using DndCharacterSheetAPI.Application.Models.Enums;
using DndCharacterSheetAPI.Domain.Context;
using DndCharacterSheetAPI.Domain.Entities;
using DndCharacterSheetAPI.Domain.Entities.DictionaryEntities;
using DndCharacterSheetAPI.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DndCharacterSheetAPI.Services
{
    public class CharacterService: ICharacterService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CharacterService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CharactersList> GetAllCharacters()
        {
            var characters = await _context.Characters
                .Include(c => c.Skills)
                .ThenInclude(cs => cs.Skill)
                .Include(c => c.SavingThrows)
                .ToListAsync();

            List<CharacterFullViewModel> charactersDto = new List<CharacterFullViewModel>();
            
            foreach(Character character in characters)
            {
                var characterFullViewModel = _mapper.Map<CharacterFullViewModel>(character);
                characterFullViewModel.Skills = character.Skills.Select(s => new CharacterSkillDTO
                {
                    Name = s.Skill.Name,
                    AssociatedAttribute = s.Skill.AssociatedAttribute,
                    Value = s.Value,
                    IsProficient = s.IsProficient
                }).ToList();
                characterFullViewModel.SavingThrows = character.SavingThrows.Select(st => new SavingThrowDTO
                {
                    AssociatedAttribute = st.AssociatedAttribute,
                    Value = st.Value,
                    IsProficient = st.IsProficient
                }).ToList();

                charactersDto.Add(characterFullViewModel);
            }

            var charactersList = new CharactersList
            {
                Characters = charactersDto,
                Page = 1,
                Count = characters.Count,
                TotalCount = characters.Count 
            };

            return charactersList;
        }

        public async Task<CharacterFullViewModel> GetCharacter(Guid id)
        {
            var character = await _context.Characters
                .Include(c => c.Skills)
                .ThenInclude(cs => cs.Skill)
                .Include(c => c.SavingThrows)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
                throw new NotFoundException("character with that guid cant be found");

            var characterFullViewModel = _mapper.Map<CharacterFullViewModel>(character);
            characterFullViewModel.Skills = character.Skills.Select(s => new CharacterSkillDTO
            {
                Name = s.Skill.Name,
                AssociatedAttribute = s.Skill.AssociatedAttribute,
                Value = s.Value,
                IsProficient = s.IsProficient
            }).ToList();
            characterFullViewModel.SavingThrows = character.SavingThrows.Select(st => new SavingThrowDTO
            {
                AssociatedAttribute = st.AssociatedAttribute,
                Value = st.Value,
                IsProficient = st.IsProficient
            }).ToList();

            return characterFullViewModel;
        }

        public async Task<CharacterFullViewModel> CreateCharacter(CharacterDTO characterDto, string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
                throw new NotFoundException("user with that username cant be found, must be something wrong with registration token");

            Character character = _mapper.Map<Character>(characterDto);
            character.Id = Guid.NewGuid();

            character.User = user;
            character.UserId = user.Id;

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();

            character.Skills = await GetListOfSkills(character.Id);
            character.SavingThrows = await GetListOfSavingThrows(character.Id);
           
            await _context.SaveChangesAsync();

            return await GetCharacter(character.Id);
        }

        public async Task UpdateCharacter(Guid id, CharacterDTO characterDto)
        {
/*            if (id != character.Id)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();*/
        }
        public async Task DeleteCharacter(Guid id)
        {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
                throw new NotFoundException("Character with the given ID can't be found");

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
        private async Task<int> CalculateModifier(int attribute)
        {
            return attribute / 2 - 5;
        }
        private async Task<List<CharacterSkill>> GetListOfSkills(Guid characterId)
        {
            List<CharacterSkill> charactersSkills = new List<CharacterSkill>();
            List<Skill> skills = await _context.Skills.ToListAsync();
            var character = await _context.Characters
                .Include(c => c.CharacterClass)
                .ThenInclude(cc => cc.ClassSkillProficiencies)
                .Include(c => c.Race)
                .ThenInclude(r => r.RacialBonuses)
                .Include(c => c.Origin)
                .ThenInclude(o => o.OriginSkillProficiencies)
                .FirstOrDefaultAsync(c => c.Id == characterId);

            if (character == null)
                throw new NotFoundException("Character with the given ID can't be found");

            int proficiencyBonus = character.ProficiencyBonus;

            foreach (Skill skill in skills)
            {

                int baseValue = await CalculateModifier((int)character.GetType().GetProperty(skill.AssociatedAttribute.ToString())?.GetValue(character));

                bool isProficient = character.CharacterClass.ClassSkillProficiencies.Any(csp => csp.SkillId == skill.Id) ||
                                    character.Origin.OriginSkillProficiencies.Any(osp => osp.SkillId == skill.Id && osp.Value > 0);

                int racialBonus = character.Race.RacialBonuses
                    .Where(rb => rb.Attribute == skill.AssociatedAttribute)
                    .Sum(rb => rb.BonusValue);

                int skillValue = baseValue + racialBonus;

                if (isProficient)
                {
                    skillValue += proficiencyBonus;
                }
                CharacterSkill characterSkill = new CharacterSkill
                {
                    Id = Guid.NewGuid(),
                    CharacterId = characterId,
                    Character = character,
                    SkillId = skill.Id,
                    Skill = skill,
                    Value = skillValue,
                    IsProficient = isProficient
                };
                await _context.CharacterSkills.AddAsync(characterSkill);

                charactersSkills.Add(characterSkill);
            }
            await _context.SaveChangesAsync();

            return charactersSkills;
        }
        private async Task<List<SavingThrow>> GetListOfSavingThrows(Guid characterId)
        {
            List<SavingThrow> charactersThrows = new List<SavingThrow>();
            var character = await _context.Characters
                .Include(c => c.CharacterClass)
                .FirstOrDefaultAsync(c => c.Id == characterId);

            if (character == null)
                throw new NotFoundException("Character with the given ID can't be found");

            int proficiencyBonus = character.ProficiencyBonus;
            var attributes = Enum.GetValues<Attributes>();

            foreach (var attribute in attributes)
            {
                int baseValue = await CalculateModifier((int)character.GetType().GetProperty(attribute.ToString()).GetValue(character));

                bool isProficient = character.CharacterClass.Rescues.Contains(attribute);

                int savingThrowValue = baseValue;

                if (isProficient)
                {
                    savingThrowValue += proficiencyBonus;
                }
                SavingThrow savingThrow = new SavingThrow
                {
                    Id = Guid.NewGuid(),
                    AssociatedAttribute = attribute,
                    CharacterId = characterId,
                    Character = character,
                    Value = savingThrowValue,
                    IsProficient = isProficient
                };

                await _context.SavingThrows.AddAsync(savingThrow);

                charactersThrows.Add(savingThrow);
            }
            await _context.SaveChangesAsync();

            return charactersThrows;
        }
    }
}
