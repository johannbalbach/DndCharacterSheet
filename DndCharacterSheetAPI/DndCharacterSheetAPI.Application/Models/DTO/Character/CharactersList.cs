namespace DndCharacterSheetAPI.Application.Models.DTO.Character
{
    public class CharactersList
    {
        public List<CharacterFullViewModel> Characters { get; set; } = new List<CharacterFullViewModel>();
        public int Page {  get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
}
