using RestaurantCollectionAPI.Models;
using System.Collections.Generic;

namespace RestaurantCollectionAPI.Repositories
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
        IEnumerable<Restaurant> GetByCity(string city);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(int id);
        IEnumerable<Restaurant> GetSortedByRating();
    
    }
}