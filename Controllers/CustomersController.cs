using System.Globalization;
using DevUpLink.Constants;
using DevUpLink.Entities;
using DevUpLink.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DevUpLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> GetCustomers(IFormFile file)
        {

            if (file == null || file.Length < 1)
            {
                return BadRequest("File is Empty - New ");
            }

            var customers = await InputReader.ReadFileAsync(file);

            var result = customers
                .Where(c => DistanceClaculator.CalculateDistance(GlobalConstants.DublinLatitude, GlobalConstants.DublinLongitude, double.Parse(c.Latitude, CultureInfo.InvariantCulture), double.Parse(c.Longitude, CultureInfo.InvariantCulture)) <= 100)
                .OrderBy(c => c.UserId)
                .Select(c => new { c.Name, c.UserId })
                .ToList();

            return Ok(result);
        }
    }
}