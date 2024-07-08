

using EmployeeCRUD.Data;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeCRUD.EmployeeService;
using EmployeeCRUD.DepartmentService;
using EmployeeCRUD.DesignationService;
using EmployeeCRUD.DesignationRepository.Interface;
using EmployeeCRUD.DepartmentRepository.Interface;

namespace EmployeeCRUD.EmployeeController
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _context;
        private readonly IDepartmentService _departmentService;
        private readonly IDesignationService _designationService;
     
        public EmployeeController(IEmployeeService context, IDepartmentService departmentService, IDesignationService designationService)
        {
            _context = context;
            _departmentService = departmentService;
            _designationService = designationService;
           
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetEmployee());
        }
        public async Task<IActionResult> Create()
        {
            var designation = await _designationService.GetDesignation();
            ViewBag.Designation = new SelectList(designation, "Id", "Name");
            var department = await _departmentService.GetDepartment();
            ViewBag.Department = new SelectList(department, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    await _context.AddEmployee(emp);
                    if (emp.Id != 0)
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id==0)
                {
                    return BadRequest();
                }
                else
                {
                    bool status = await _context.DeleteRecard(id);
                    if (status)
                    {
                        TempData["success"] = "Recard Has been successfully Deleted";
                    }
                    else
                    {
                        TempData["error"] = "Recard not Deleted";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var designation = await _designationService.GetDesignation();
            ViewBag.Designation = new SelectList(designation, "Id", "Name");
            var department = await _departmentService.GetDepartment();
            ViewBag.Department = new SelectList(department, "Id", "Name");
            Employee model = new Employee();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    model = await _context.DetailsRecard(id);
                    if (model == null)
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var designation = await _designationService.GetDesignation();
            ViewBag.Designation = new SelectList(designation, "Id", "Name");
            var department = await _departmentService.GetDepartment();
            ViewBag.Department = new SelectList(department, "Id", "Name");
            var data = await _context.EditRecard(id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    bool status = await _context.UpdateRecard(model);
                    if (status)
                    {
                        TempData["success"] = "Recard Has been successfully Updated";
                    }
                    else
                    {
                        TempData["error"] = "Recard not Updated";
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


        //private readonly EmployeeDbContext _employeeDbContext;  
        //private readonly IWebHostEnvironment  evn;
        //public EmployeeController(EmployeeDbContext employeeDbContext,IWebHostEnvironment evn)
        //{
        //        this._employeeDbContext = employeeDbContext;
        //       this.evn = evn;
        //}
        //public IActionResult Index()
        //{
        //    var data = _employeeDbContext.Employees.Include(x=>x.Designations).Include(x=>x.Departments).ToList();
        //    return View(data);
        //}
        //public IActionResult Create()
        //{
        //    LoadDropDown();
        //    return View();  
        //}

        //[HttpPost]
        //public IActionResult Create(Employee model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            string uniqueFileName = UploadImage(model);
        //            var data = new Employee()
        //            {
        //                Name = model.Name,
        //                Age = model.Age,
        //                Salary = model.Salary,
        //                Gender = model.Gender,
        //                BloodGroup = model.BloodGroup,
        //                Designation = model.Designation,
        //                Designations = model.Designations,
        //                Department = model.Department,
        //                Departments = model.Departments,
        //                Path = uniqueFileName
        //            };
        //            _employeeDbContext.Employees.Add(data);
        //            _employeeDbContext.SaveChanges();
        //            if (model.Id == 0)
        //            {
        //                TempData["error"] = "Recard Not Saved";
        //            }
        //            else
        //            {
        //                TempData["success"] = "Recard Successfully Saved";
        //            }
        //            return RedirectToAction("Index");
        //        }
        //        ModelState.AddModelError(string.Empty,"Model Property is not valid");
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //    }
        //    return View(model);
        //}
        //private string UploadImage(Employee model)
        //{
        //    string uniqueFileName = string.Empty;
        //    if (model.ImagePath != null)
        //    {
        //        string uploadFolder = Path.Combine(evn.WebRootPath,"Image");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
        //        string filePath = Path.Combine(uploadFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.ImagePath.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}

        //[NonAction]
        //private void LoadDropDown()
        //{
        //    var designation = _employeeDbContext.Designations.ToList();
        //    ViewBag.Designation = new SelectList(designation, "Id", "Name");
        //    var department = _employeeDbContext.Departments.ToList();
        //    ViewBag.Department = new SelectList(department, "Id", "Name");
        //}
   // }
}
