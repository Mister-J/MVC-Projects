using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkiWebApplication.ViewModels;
using SkiWebApplication.Models;

namespace SkiWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test

        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.employees = empViewModels;
            employeeListViewModel.UserName = "Admin";
            return View("Index", employeeListViewModel);
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                    empBal.SaveEmployee(e);
                    return RedirectToAction("Index");
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }
}