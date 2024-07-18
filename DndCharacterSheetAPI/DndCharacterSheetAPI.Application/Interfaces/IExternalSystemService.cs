namespace DndCharacterSheetAPI.Application.Interfaces
{
    public interface IExternalSystemService
    {
        Task<List<int>> RollDiceAsync(int numberOfDice, int minValue, int maxValue);
        Task GenerateAndSaveImageAsync(string prompt);
    }
}
