using AutoMapper;
using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Application.Models.DTO.Character;
using DndCharacterSheetAPI.Domain.Context;
using DndCharacterSheetAPI.Domain.Entities;
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
            /*            return await _context.Characters
                       .Select(c => new CharacterDTO
                       {
                           Id = c.Id,
                           Name = c.Name,
                           CharacterClassId = c.CharacterClassId,
                           Level = c.Level,
                           Exp = c.Exp,
                           ProficiencyBonus = c.ProficiencyBonus,
                           RaceId = c.RaceId,
                           OriginId = c.OriginId,
                           OutlookText = c.OutlookText,
                           Strength = c.Strength,
                           Dexterity = c.Dexterity,
                           Constitution = c.Constitution,
                           Intelligence = c.Intelligence,
                           Wisdom = c.Wisdom,
                           Charisma = c.Charisma,
                           Age = c.Age,
                           Height = c.Height,
                           Weight = c.Weight,
                           Eyes = c.Eyes,
                           Skin = c.Skin,
                           Hair = c.Hair,
                           Notes = c.Notes,
                           Skills = c.Skills.Select(s => new CharacterSkillDTO
                           {
                               SkillId = s.SkillId,
                               Value = s.Value,
                               IsProficient = s.IsProficient
                           }).ToList(),
                           SavingThrows = c.SavingThrows.Select(s => new SavingThrowDTO
                           {
                               AssociatedAttribute = s.AssociatedAttribute,
                               Value = s.Value,
                               IsProficient = s.IsProficient
                           }).ToList()
                       }).ToListAsync();*/
            throw new NotImplementedException();
        }

        public async Task<CharacterFullViewModel> GetCharacter(Guid id)
        {
            throw new NotImplementedException();
            /*            var character = await _context.Characters
                                    .Where(c => c.Id == id)
                                    .Select(c => new CharacterDTO
                                    {
                                        Id = c.Id,
                                        Name = c.Name,
                                        CharacterClassId = c.CharacterClassId,
                                        Level = c.Level,
                                        Exp = c.Exp,
                                        ProficiencyBonus = c.ProficiencyBonus,
                                        RaceId = c.RaceId,
                                        OriginId = c.OriginId,
                                        OutlookText = c.OutlookText,
                                        Strength = c.Strength,
                                        Dexterity = c.Dexterity,
                                        Constitution = c.Constitution,
                                        Intelligence = c.Intelligence,
                                        Wisdom = c.Wisdom,
                                        Charisma = c.Charisma,
                                        Age = c.Age,
                                        Height = c.Height,
                                        Weight = c.Weight,
                                        Eyes = c.Eyes,
                                        Skin = c.Skin,
                                        Hair = c.Hair,
                                        Notes = c.Notes,
                                        Skills = c.Skills.Select(s => new CharacterSkillDTO
                                        {
                                            SkillId = s.SkillId,
                                            Value = s.Value,
                                            IsProficient = s.IsProficient
                                        }).ToList(),
                                        SavingThrows = c.SavingThrows.Select(s => new SavingThrowDTO
                                        {
                                            AssociatedAttribute = s.AssociatedAttribute,
                                            Value = s.Value,
                                            IsProficient = s.IsProficient
                                        }).ToList()
                                    }).FirstOrDefaultAsync();

                        if (character == null)
                        {
                            throw new KeyNotFoundException("Character not found");
                        }

                        return character;*/
        }

        public async Task<CharacterFullViewModel> CreateCharacter(CharacterDTO characterDto)
        {
            throw new NotImplementedException();
            /*            _context.Characters.Add(character);
                        await _context.SaveChangesAsync();
                        return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);*/
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
/*            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return NoContent();*/
        }
        private int CalculateModifier(int attribute)
        {
            return attribute % 2 - 5;
        }
    }
}
