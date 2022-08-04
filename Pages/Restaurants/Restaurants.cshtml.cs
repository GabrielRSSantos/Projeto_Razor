using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using OdeToFood.Core;

namespace C_.Pages.Restaurants
{
    public class Restaurants : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public string? Message { get; set; }
        public IEnumerable<Restaurant>? ListRestaurants;

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm {get; set;}

        public Restaurants(IConfiguration config,
                           IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Message = "Restaurant Message";
            ListRestaurants = restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}