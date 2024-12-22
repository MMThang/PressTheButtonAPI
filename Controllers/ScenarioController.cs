using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PressTheButtonAPI.DTOs.ScenarioDTOs;
using PressTheButtonAPI.Interfaces;

namespace PressTheButtonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenarioController : ControllerBase
    {

        private readonly IScenarioRepository _scenario;
        public ScenarioController(IScenarioRepository scenarioRepository) {
            _scenario = scenarioRepository;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateScario(CreateScenarioDTO scenarioData)
        {
            try
            {
                var scenario = await _scenario.CreateScenarioRepository(scenarioData.OwnerId, scenarioData.GoodOutcome, scenarioData.BadOutcome);
                return Ok(scenario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScenario(int id)
        {
            try
            {
                var scenario = await _scenario.GetScenarioRepository(id);
                return Ok(scenario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("random/{id}")]
        public async Task<IActionResult> GetARandomScenario(int id)
        {
            try
            {
                var scenario = await _scenario.GetARandomIdRepository(id);
                return Ok(scenario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("scenarios/{userId}/{category}")]
        [Authorize]
        public async Task<IActionResult> GetAlotScenarios([FromRoute]Guid userId,[FromRoute]string category, [FromQuery]int page = 1)
        {
            try
            {
                var scenario = await _scenario.GetAlotScenariosRepository(userId,category, page);
                return Ok(scenario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateScenario(UpdateScenarioDTO scenarioData)
        {
            try
            {
                var scenario = await _scenario.UpdateScenarioRepository(scenarioData.scenarioId, scenarioData.GoodOutcome, scenarioData.BadOutcome);
                return Ok(scenario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteScenario(GetScenarioDTO scenarioData)
        {
            try
            {
                var scenario = await _scenario.DeleteScenarioRepository(scenarioData.id);
                return Ok(scenario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("result")]
        public async Task<IActionResult> UpdatePlayedCount(UpdatePlayedCountDTO scenarioData)
        {
            try
            {
                var scenario = await _scenario.UpdatePlayedCount(scenarioData.id, scenarioData.isPressed );
                return Ok(scenario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
