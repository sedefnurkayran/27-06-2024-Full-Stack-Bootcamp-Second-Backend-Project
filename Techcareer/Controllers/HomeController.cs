using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Techcareer.Models;

namespace Techcareer.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        var products = Repository.Products;
        return View();

        //  return View(Repository.Products); = Repository.Products.ToList(); //ayni seyi ifade eder.
    }


}
