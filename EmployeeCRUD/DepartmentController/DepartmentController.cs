using EmployeeCRUD.DepartmentService;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD.DepartmentController
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _context;
        public DepartmentController(IDepartmentService context)
        {
                _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetDepartment());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                else
                {
                    await _context.AddDepartment(data);
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
            Department data = new Department();
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
        public async Task<IActionResult> Edit(Department data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                else
                {
                    bool status = await _context.UpdateDepartment(data);
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
                if (id == null)
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
