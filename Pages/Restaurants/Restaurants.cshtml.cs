using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace C_.Pages.Restaurants
{
    public class Restaurants : PageModel
    {
        public string? Message { get; set; }
        public void OnGet()
        {
            Message = "Restaurant Message";
        }
    }
}