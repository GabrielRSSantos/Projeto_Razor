using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace C_.Pages.Restaurants
{
    public class Edit : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public Edit(IRestaurantData restaurantData,
                    IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            this.Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant is null)
            {
                return Redirect("/Restaurants/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Restaurant = restaurantData.Update(Restaurant);
            restaurantData.Commit();
            return Page();
        }
    }
}