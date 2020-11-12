using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MVC_Dapper.Models;

namespace MVC_Dapper.Controllers
{
    public class Employee : Controller
    {
        public IActionResult Index()
        {
            return View(DapperORM.ReturnList<MVC_Dapper.Models.Employee>("EmployeeViewAll"));
        }



        [HttpGet]
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0) {
                return View();
            }
            else
            {
                DynamicParameters parm = new DynamicParameters();
                parm.Add("@EmployeeID", id);
                return View(DapperORM.ReturnList<MVC_Dapper.Models.Employee>("EMployeeViewByID", parm).FirstOrDefault<MVC_Dapper.Models.Employee>());
            }
        }

        [HttpPost]
        public IActionResult AddorEdit(MVC_Dapper.Models.Employee emp)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", emp.EmployeeID);
            param.Add("@EmployeeName", emp.Employee_Name);
            param.Add("@EmployeePosition", emp.Employee_Posititon);
            param.Add("@EmployeeAge", emp.Employee_Age);
            param.Add("@EmployeeSalary", emp.Employee_Salary);
            DapperORM.ExecuteWithoutReturn("EMployeeAddOrEdit", param);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@EmployeeID", id);
            DapperORM.ExecuteWithoutReturn("EmployeeDeleteByID", parm);
            return RedirectToAction("Index");
        }
    }
}
