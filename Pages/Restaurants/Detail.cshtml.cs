using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace C_.Pages.Restaurants
{
    public class Detail : PageModel
    {
        private readonly IRestaurantData RestaurantData;
        public Detail(IRestaurantData restaurantData)
        {
            this.RestaurantData = restaurantData;
        }
        public Restaurant? Restaurant {get; set;}
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = RestaurantData.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("/Restaurants/NotFound");
            }
            return Page();
        }
    }
}