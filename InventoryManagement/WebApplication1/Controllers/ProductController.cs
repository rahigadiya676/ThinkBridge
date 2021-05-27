using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

         ItemAccessLayer itemAccessLayer = null;
        public ProductController()
        {
            itemAccessLayer = new ItemAccessLayer();
        }

        public ActionResult Index()
        {
            IEnumerable<Inventory> Items=  itemAccessLayer.GetAllItem();
            return View(Items);
        }

        public ActionResult Details(int id)
        {
            Inventory Item = itemAccessLayer.GetItemById(id);
            return View(Item);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Inventory Item)
        {
            try
            {
                itemAccessLayer.AddItem(Item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Inventory Item= itemAccessLayer.GetItemById(id);
            return View(Item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inventory Item)
        {
            try
            {
                itemAccessLayer.UpdateItem(Item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            Inventory Item= itemAccessLayer.GetItemById(id);
            return View(Item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Inventory Item)
        {
            try
            {
                // TODO: Add delete logic here  
                itemAccessLayer.DeleteItem(Item.id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
