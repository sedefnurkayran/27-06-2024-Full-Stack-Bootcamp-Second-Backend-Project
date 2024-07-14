
using System.Diagnostics;
using System.Runtime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Techcareer.Models;

namespace Techcareer.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {

    }

    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;

        if (!String.IsNullOrEmpty(searchString))
        {

            ViewBag.SearchString = searchString;
            products = products.Where(p => p.Name!.ToLower().Contains(searchString)).ToList();
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
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)
    {
        var allowenExtensions = new[] { ".jpg", ".png", ".jpeg" };
        if (imageFile != null)
        {
            var extensions = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            if (!allowenExtensions.Contains(extensions))
            {
                ModelState.AddModelError("", "Geçerli bir resim seçiniz!");
            }
            else
            {
                var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                try
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomFileName;
                }
                catch
                {
                    ModelState.AddModelError("", "Dosya yüklenirken bir hata oluştu.");
                }
            }
        }
        else
        {
            ModelState.AddModelError("", "Bir dosya seçiniz.");
        }

        if (ModelState.IsValid)
        {

            model.ProductId = Repository.Products.Count + 1;
            Repository.CreateProduct(model);
            return RedirectToAction("Index");
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }


    public IActionResult Profile(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Index", "Home");
        }
        var profile = Repository.GetById(id);

        return View(profile);
    }


    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var edit = Repository.Products.FirstOrDefault(x => x.ProductId == id);
        if (edit == null)
        {
            return NotFound();
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");

        return View(edit);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile)
    {
        if (id != model.ProductId)
        {
            return NotFound();
        }

        var allowenExtensions = new[] { ".jpg", ".png", ".jpeg" };
        if (imageFile != null)
        {

            var extensions = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            if (!allowenExtensions.Contains(extensions))
            {
                ModelState.AddModelError("", "Geçerli bir resim seçiniz!");
            }
            else
            {
                var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extensions}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                try
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomFileName;
                }
                catch
                {
                    ModelState.AddModelError("", "Dosya yüklenirken bir hata oluştu.");
                }
            }
        }
        else
        {
            ModelState.AddModelError("", "Bir dosya seçiniz.");
        }

        if (ModelState.IsValid) //Validasyonda herhangi bir hata yok ise kaydet.
        {

            Repository.EditProduct(model);
            return RedirectToAction("Index");
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }



    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var deleteP = Repository.Products.FirstOrDefault(x => x.ProductId == id);
        if (deleteP == null)
        {
            return NotFound();
        }

        return View("DeleteConfirm", deleteP);
    }

    [HttpPost]


    public IActionResult DeleteConfirmed(int id, int ProductId)    //Id kesinlikle bos gelemez

    {
        if (id != ProductId)
        {
            return NotFound();
        }
        var deleteP = Repository.Products.FirstOrDefault(p => p.ProductId == ProductId);
        if (deleteP == null)
        {
            return NotFound();
        }

        Repository.DeleteProduct(deleteP);
        return RedirectToAction("Index");
    }

}

//  return View(Repository.Products); = Repository.Products.ToList(); //ayni seyi ifade eder.



