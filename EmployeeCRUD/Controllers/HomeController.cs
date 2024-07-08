using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeCRUD.Controllers
{
    /*

     // Partial View //
     
     -> Partial view represents a sub view / Nested view /inner view of a main view. 
     -> Partial view allows you to reuse common markups accross the different views of the application. 
     -> We can use partial views in different views 
     -> Partial views cannot  be used separatly, we have to attach partial in some other view.
     -> Partial view extention is .cshtml like a view 
     -> When we have to use some html markup on some pages not all pages then we can use partial view  
     -> Remember - A parial view is a part of a view file 

     // Partial view with Models (Strongly Typed Partial View) // 

     -> It is a combination of 2 concepts i asp.net core mvc 
        # Strongly typed view  
        # Partial view

     -> The Partial view which binds with any model is called as strongly typed partial view 
     -> strongly typed partial view is also know as dynamic partial views
     
     # There are two types of partial view 
    
       1 -> Static Partial View - Partial view with no model (Static data)
       2 -> Dynamic Partial view - partial view with model (Dynamic data)

    // Hidden Fields //

     -> Hidden fields store value at a page lavel
     -> Hidden Fields is used for storing small ammount of data on client side
     -> Syntax - <input type="hidden" />
     -> Used to store data in the html without presenting the data in the browser 
     -> Used to save the page scope and avoid data from podt backs and call backs (no any performance on server side)
     -> Hidden fields cannot handle object or controls 
     -> Hidden field are not secure, any user who can access,"View source" can get all data of all hidden fields 
     -> They are not encrypted so they could be visible in the html code 

    // Post Back // 

     -> first time page load then html page show then submit button click then again html page show so it is call post back
    */

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
