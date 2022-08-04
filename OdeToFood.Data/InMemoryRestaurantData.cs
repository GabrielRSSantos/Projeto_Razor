using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant>? _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name="Scoot's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant {Id = 2, Name="Gabriel's Pizza", Location="Sorocaba", Cuisine=CuisineType.Mexican},
                new Restaurant {Id = 3, Name="Saria's Pizza", Location="São Paulo", Cuisine=CuisineType.Indian}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in _restaurants
                    where string.IsNullOrEmpty(name) || r.Name!.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}