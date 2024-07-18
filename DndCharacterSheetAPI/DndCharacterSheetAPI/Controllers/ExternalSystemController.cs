using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DndCharacterSheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalSystemController: ControllerBase
    {
        private readonly IExternalSystemService _externalSystemService;

        public ExternalSystemController(IExternalSystemService externalSystemService)
        {
            _externalSystemService = externalSystemService;
        }

        [HttpGet]
        [Authorize]
        [Route("RollDice/{numberOfDice}/{minValue}/{maxValue}")]
        public async Task<List<int>> RollDice([FromRoute] int numberOfDice, [FromRoute] int minValue, [FromRoute] int maxValue)
        {
            var result = await _externalSystemService.RollDiceAsync(numberOfDice, minValue, maxValue);
            return result;
        }

        [HttpPost]
        [Authorize]
        [Route("GenerateImage")]
        public async Task<Response> GenerateImage(string prompt)
        {
            await _externalSystemService.GenerateAndSaveImageAsync(prompt);

            return new Response { Status = "200", Message = "VSE OK" };
        }
    }
}
