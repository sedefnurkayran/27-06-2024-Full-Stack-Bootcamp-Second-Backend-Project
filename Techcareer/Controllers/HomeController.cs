using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Techcareer.Models;

namespace Techcareer.Controllers;

public class HomeController : Controller
{

    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;

        //Dolu bos kontrolü yap.

        if (!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            products = products.Where(x => x.Name!.ToLower().Contains(searchString)).ToList();

        }

        if (!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }
        //   ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name",category);
        var model = new ProductViewModel
        {
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };

        return View(model);
        //  return View(Repository.Products); = Repository.Products.ToList(); //ayni seyi ifade eder.


    }


}
