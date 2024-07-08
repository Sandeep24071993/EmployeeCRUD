using EmployeeCRUD.Data;
using EmployeeCRUD.EmployeeRepository.Interface;
using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace EmployeeCRUD.EmployeeRepository.Service
{
    public class EmployeeRepository :IEmployee
    {
        private readonly EmployeeDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeRepository(EmployeeDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;   
        }
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await _context.Employees
                                 .Include(x => x.Departments)
                                 .Include(x => x.Designations)
                                 .ToListAsync();
        }
        public async Task<int> AddEmployee(Employee data)
        {
            string uniqueimage = UploadImage(data);
            var  model = new Employee()
            {
                Name = data.Name,
                Age = data.Age, 
                Salary = data.Salary,   
                Gender = data.Gender,
                BloodGroup = data.BloodGroup,   
                Designation = data.Designation, 
                Designations = data.Designations,
                Department = data.Department,   
                Departments = data.Departments, 
                Path = uniqueimage
            };
            await _context.Employees.AddAsync(model);
            await _context.SaveChangesAsync();
            return data.Id;
        }
        private string UploadImage(Employee model)
        {
            string uniqueFileName = string.Empty;
            if (model.ImagePath != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task<bool> DeleteRecard(int id)
        {
            bool status = false;    
            var data = await _context.Employees.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                string deleteFromFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Image");
                string currentImage = Path.Combine(Directory.GetCurrentDirectory(),deleteFromFolder,data.Path);
                if (currentImage != null)
                {
                    if (File.Exists(currentImage))
                    {
                        File.Delete(currentImage);    
                    }
                }
                _context.Employees.Remove(data);
                await _context.SaveChangesAsync(status);
                status = true;  
            }
            return status;
        }

        public async Task<Employee> DetailsRecard(int id)
        {
            var data = await _context.Employees.Where(x=>x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Employee> EditRecard(int id)
        {
            var data = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateRecard(Employee model)
        {
            bool status = false;
            var data = await _context.Employees.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            string uniqueImage = string.Empty;
            if(data != null)
            {
                if (model.ImagePath != null)
                {
                    if (data.Path != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Image", data.Path);
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                    uniqueImage = UploadImage(model);
                }
                data.Name = model.Name;
                data.Age = model.Age;
                data.Salary = model.Salary;
                data.Gender = model.Gender;
                data.BloodGroup = model.BloodGroup;
                data.Designations = model.Designations;
                data.Designation = model.Designation;
                data.Department = model.Department;
                data.Departments = model.Departments;
                if (model.ImagePath != null)
                {
                    data.Path = uniqueImage;
                }
                _context.Employees.Update(data);
                await _context.SaveChangesAsync();
                status = true;
            }
            return status;  
        }
    }
}
