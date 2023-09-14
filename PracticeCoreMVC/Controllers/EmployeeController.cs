using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeCoreMVC.Models;

namespace PracticeCoreMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly PracticeCoreMVCContext _context;
        public EmployeeController(PracticeCoreMVCContext context)
        {
            _context = context;  
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> AddOrEdit(int? employeeId)  
        {
            ViewBag.PageName = employeeId == null ? "Create Employee" : "Edit Employee";
            ViewBag.IsEdit = employeeId == null ? false : true;
            if (employeeId == null)
            {
                return View();
            }
            else
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int employeeId, [Bind("EmployeeId,Name,Designation,Address,Salary,JoiningDate")]Employee employeeData)
        {
            bool IsEmployeeExist = false;

            Employee? employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

            if (employee != null)
            {
                IsEmployeeExist = true;
            }
            else
            {
                employee = new Employee();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employee.Name = employeeData.Name;
                    employee.Designation = employeeData.Designation;
                    employee.Address = employeeData.Address;
                    employee.Salary = employeeData.Salary;
                    employee.JoiningDate = employeeData.JoiningDate;

                    if (IsEmployeeExist)
                    {
                        _context.Update(employee);
                    }
                    else
                    {
                        _context.Add(employee);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeData);
        }
    }
}
