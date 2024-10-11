using System.ComponentModel.DataAnnotations;

namespace RestaurantCollectionAPI.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Name { get; set; }
    public int EstimatedCost { get; set; }
    public string AverageRating { get; set; }
    public int Votes { get; set; }
}