using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{

    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            this.context = context;
        }
        public Restaurant Add(Restaurant newResaurant)
        {
            context.Add(newResaurant);
            return newResaurant;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if (restaurant != null)
            {
                context.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int Id)
        {
           return context.Restaurants.Find(Id);
        }

        public int GetCountOfRestaurants()
        {
            return context.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetResturantsByName(string name)
        {
            var query = from r in context.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
            
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = context.Restaurants.Attach(updateRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updateRestaurant;
        }
    }
}
