using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
    public class InMemoryResturantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryResturantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id= 1, Name="The Butcher House and Grill", Location="Sandton Square", Cuisine = CuisineType.None},
                new Restaurant {Id= 2, Name="The Grill", Location="Sandton Square", Cuisine = CuisineType.Mexican},
                new Restaurant {Id= 3, Name="Hard Rock", Location="Johannesburg Sandton Center ", Cuisine = CuisineType.Italian},
                new Restaurant {Id= 4, Name="The Beach Hotel", Location="Durban Kzn South Africa ", Cuisine = CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
