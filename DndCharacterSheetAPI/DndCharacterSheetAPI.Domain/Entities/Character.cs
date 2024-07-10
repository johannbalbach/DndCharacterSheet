﻿using DndCharacterSheetAPI.Domain.Entities.DictionaryEntities;

namespace DndCharacterSheetAPI.Domain.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CharacterClassId { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int ProficiencyBonus {get; set; }
        public Guid RaceId { get; set; }
        public Race Race { get; set; }
        public Guid OriginId { get; set; }
        public Origin Origin { get; set; }
        public string? OutlookText { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public List<CharacterSkill> Skills { get; set; } = new List<CharacterSkill>();
        public List<SavingThrow> SavingThrows { get; set; } = new List<SavingThrow>();
        public User User { get; set; }
        public Guid UserId { get; set; }

        public int CalculateModifier(int attribute)
        {
            return attribute % 2 - 5;
        }
    }
}