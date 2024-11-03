using Microsoft.AspNetCore.Mvc;
using API.Data.Dtos;
using Asp.Versioning;
using Core.AuthServices;
using Core.CoverageServices;
using Core.CoverageServices.GoogleServices;
using Data.Models.CoverageModels;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class NetworkCoverageController : ControllerBase
    {
        private readonly ICoverageService _coverageService;
        private readonly IGoogleGeoCodingService _googleGeoCodingService;
        private readonly ILogger<NetworkCoverageController> _logger;

        public NetworkCoverageController(ICoverageService coverageService, IGoogleGeoCodingService googleGeoCodingService, ILogger<NetworkCoverageController> logger)
        {
            _coverageService = coverageService;
            _googleGeoCodingService = googleGeoCodingService;
            _logger = logger;
        }

        [HttpGet("check-network-coverage-availability")]
        public async Task<IActionResult> CheckNetworkCoverage([FromQuery] LocationDto locationdto)
        {
            try
            {
                if (string.IsNullOrEmpty(locationdto.Location))
                {
                    return Ok(new { Message = $"Please input a location" });
                }
                var responseFromGoogle = _googleGeoCodingService.GetCoordinatesAsync(locationdto.Location);
                bool isInCoverageArea = await _coverageService.IsInCoverageAreaAsync(responseFromGoogle.Result.UserLatitude, responseFromGoogle.Result.UserLongitude);

                if (responseFromGoogle.Result.CloseCoverageLocations != null && responseFromGoogle.Result.CloseCoverageLocations.Any())
                {
                    var locationsMessage = string.Join(", ", responseFromGoogle.Result.CloseCoverageLocations.Select(location => location.CoverageName));
                    return Ok(new { Message = $"The locations closest to you are:{locationsMessage}" , isWithinRange = true });

                }

                else if (isInCoverageArea)
                { 
                    return Ok(new { Message = "your location is within ipNX Network Coverage Area." , isWithinRange = true });
                }
                else
                {
                    return NotFound(new { Message = "your location seems to be outside ipNX Network Coverage Area. Type in a more descriptive address." ,isWithinRange = false });
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while checking location availability");
                return StatusCode(500, $"An error occured while checking location availability. Please try again later");
            }
        }

        [HttpGet("get-location-suggestions")]
        public async Task<IActionResult> GetGoogleSuggestions(string userInput)
        {
            try
            {
                var result = await _googleGeoCodingService.GetSuggestionsFromGooglePlacesAsync(userInput);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error while trying to get location suggestions");
                return StatusCode(500, $"An error while trying to get location suggestions");
            }
        }



        [HttpGet("all-coverage-locations")]
        public async Task<IActionResult> GetAllCoverageLocations()
        {
            try
            {
                IEnumerable<CoverageLocation> coverageLocations = await _coverageService.GetAllCoverageLocationsAsync();
                return Ok(coverageLocations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get all our coverage locations");
                return StatusCode(500, $"An error occurred while trying to get all our coverage locations");
            }
        }

        [HttpGet("all-coverage-states")]
        public IActionResult GetAllCoverageStates()
        {
            try
            {
                var coverageLocations = _coverageService.GetAllCoverageLocationStatesAsync();
                return Ok(coverageLocations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get all our coverage states");
                return StatusCode(500, $"An error occurred while trying to get all our coverage states");
            }
        }

        [HttpGet("all-coverage-cities")]
        public IActionResult GetAllCoverageCities([FromQuery] List<string> states)
        {
            try
            {
                var coverageCities = _coverageService.GetAllCoverageLocationLgasAsync(states);
                return Ok(coverageCities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get all our coverage cities");
                return StatusCode(500, $"An error occurred while trying to get all our coverage cities");
            }
        }




        [HttpGet("all-coverage-streets")]
        public IActionResult GetAllCoverageStreets([FromQuery] List<string> lgas) 
        {
            try
            {
                var coverageLgas = _coverageService.GetAllCoverageLocationStreetsAsync(lgas);
                return Ok(coverageLgas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get all our coverage streets");
                return StatusCode(500, $"An error occurred while trying to get all our coverage streets");
            }
        }
    }



}

