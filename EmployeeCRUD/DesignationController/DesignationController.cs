using EmployeeCRUD.DesignationService;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD.DesignationController
{
    public class DesignationController : Controller
    {
        private readonly IDesignationService _context;
        public DesignationController(IDesignationService context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetDesignation());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Designation data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);  
                }
                else
                {
                    await _context.AddDesignation(data);
                    if (data.Id == 0)
                    {
                        TempData["error"] = "Recard Not Saved";
                    }
                    else
                    {
                        TempData["success"] = "Recard Successfully Saved";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Designation data = new Designation();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                data = await _context.EditGetId(id);
                if (data == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(data);  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Designation data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);  
                }
                else
                {
                    bool status = await _context.UpdateDesignation(data);
                    if (status)
                    {
                        TempData["success"] = "Recard Successfully Updated";
                    }
                    else
                    {
                        TempData["error"] = "Recard Not Updated";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id==null)
                {
                    return BadRequest();
                }
                else
                {
                    bool status = await _context.DeleteRecard(id);
                    if (status)
                    {
                        TempData["success"] = "Recard Successfully Deleted";
                    }
                    else
                    {
                        TempData["error"] = "Recard Not Deleted";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");   
        }

    }
}
