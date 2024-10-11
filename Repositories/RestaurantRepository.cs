using RestaurantCollectionAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantCollectionAPI.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly List<Restaurant> _restaurants = new();

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetByCity(string city)
        {
            return _restaurants.Where(r => r.City.Equals(city, System.StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Restaurant restaurant)
        {
            _restaurants.Add(restaurant);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = GetById(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.City = restaurant.City;
                existing.EstimatedCost = restaurant.EstimatedCost;
                existing.AverageRating = restaurant.AverageRating;
                existing.Votes = restaurant.Votes;
            }
        }

        public void Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }
        }

        public IEnumerable<Restaurant> GetSortedByRating()
        {
            return _restaurants.OrderByDescending(r => float.Parse(r.AverageRating)).ToList();
        }
    
    }   
}