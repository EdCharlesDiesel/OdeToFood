using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetResturantsByName(string name);
        Restaurant GetById(int Id);
        Restaurant Update(Restaurant updateRestaurant);
        Restaurant Add(Restaurant newResaurant);
        Restaurant Delete(int id);    
        int GetCountOfRestaurants();
        int Commit();
    }
}
