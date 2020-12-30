using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
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

        public Restaurant Add(Restaurant newResaurant)
        {
            restaurants.Add(newResaurant);
            newResaurant.Id = restaurants.Max(r=>r.Id)+ 1;
            return newResaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {var restaurant = restaurants.FirstOrDefault(r=>r.Id==id);
            if (restaurant != null)
            {
                
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int Id)
        {
            return restaurants.SingleOrDefault(r=>r.Id==Id);
        }

        public IEnumerable<Restaurant> GetResturantsByName(string name =null)
        {
            return from r in restaurants
            where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r=>r.Id== updateRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
