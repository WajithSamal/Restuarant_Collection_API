using Microsoft.AspNetCore.Mvc;
using RestaurantCollectionAPI.Repositories;
using RestaurantCollectionAPI.Models;

namespace RestaurantCollectionAPI.Controllers
{   
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantController(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddRestaurant([FromBody] Restaurant restaurant)
        {
            _repository.Add(restaurant);
            return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurant.Id }, restaurant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, [FromBody] Restaurant updatedRestaurant)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            updatedRestaurant.Id = id;
            _repository.Update(updatedRestaurant);
            return NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            var restaurants = _repository.GetAll();
            return Ok(restaurants);
        }

        [HttpGet("query")]
        public ActionResult<IEnumerable<Restaurant>> GetRestaurantsByCity(string city)
        {
            var restaurants = _repository.GetByCity(city);
            return Ok(restaurants);
        }

        [HttpGet("query/{id}")]
        public ActionResult<Restaurant> GetRestaurantById(int id)
        {
            var restaurant = _repository.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }

        [HttpGet("sort")]
        public ActionResult<IEnumerable<Restaurant>> GetRestaurantsSortedByRating()
        {
            var restaurants = _repository.GetSortedByRating();
            return Ok(restaurants);
        }
    
    }   
}