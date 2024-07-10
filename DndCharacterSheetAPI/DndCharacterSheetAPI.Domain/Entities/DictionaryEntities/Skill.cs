using DndCharacterSheetAPI.Application.Models.Enums;

namespace DndCharacterSheetAPI.Domain.Entities.DictionaryEntities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Attributes AssociatedAttribute { get; set; }
    }
}
