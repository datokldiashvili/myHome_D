using Microsoft.AspNetCore.Mvc;
using API.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        // Dummy data for demonstration
        private List<HouseDto> GetDummyHousesData()
        {
            return new List<HouseDto>
            {
                new HouseDto { Id = 1, Location = "ქუთაისი", Price = 200000 },
                new HouseDto { Id = 2, Location = "თბილისი", Price = 250000 },
                new HouseDto { Id = 3, Location = "ბათუმი", Price = 300000 }
            };
        }

        [HttpPost("filter")]
        public IActionResult FilterHouses(FilterDto filterDto)
        {
            var houses = GetDummyHousesData();

            var filteredHouses = houses.Where(house =>
                (string.IsNullOrEmpty(filterDto.Location) || house.Location == filterDto.Location) &&
                (!filterDto.MinPrice.HasValue || house.Price >= filterDto.MinPrice) &&
                (!filterDto.MaxPrice.HasValue || house.Price <= filterDto.MaxPrice)
            ).ToList();

            return Ok(filteredHouses);
        }

        [HttpPost("clear-filter")]
        public IActionResult ClearFilter()
        {

            var allHouses = GetDummyHousesData();
            return Ok(allHouses);
        }

         [HttpPost("change-currency")]
        public IActionResult ChangeCurrency(CurrencyDto currencyDto)
        {
            return Ok(currencyDto);
        }

        [HttpPost("rate-website")]
        public IActionResult RateWebsite(RatingDto ratingDto)
        {
            return Ok(ratingDto);
        }
    }
}
