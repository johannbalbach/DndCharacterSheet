using DndCharacterSheetAPI.Domain.Entities;
using DndCharacterSheetAPI.Domain.Entities.DictionaryEntities;
using Microsoft.EntityFrameworkCore;

namespace DndCharacterSheetAPI.Domain.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<SavingThrow> SavingThrows { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<CharacterClassSkillProficiency> ClassSkillsProfiencies { get; set; }
        public DbSet<ClassLevelBonus> ClassLevelBonuses { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<OriginSkillProficiency> OriginSkillProficiencies { get; set; }
        public DbSet<OriginUniqueSkill> OriginUniqueSkills { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RacialBonus> RacialBonuses { get; set; }
        public DbSet<RaceUniqueSkill> RaceUniqueSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }

    }
}
