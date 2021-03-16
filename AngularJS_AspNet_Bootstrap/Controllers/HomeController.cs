using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AngularJS_AspNet_Bootstrap.Models;

namespace AngularJS_AspNet_Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get_AllEmployee()
        {
            using (AngJSAsp4_EmployeesEntities Obj = new AngJSAsp4_EmployeesEntities())
            {
                List<Employee> Emp = Obj.Employees.ToList();

                return Json(Emp, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get_EmployeeById(string Id)
        {
            using (AngJSAsp4_EmployeesEntities Obj = new AngJSAsp4_EmployeesEntities())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.Employees.Find(EmpId), JsonRequestBehavior.AllowGet);
            }
        }

        public string Insert_Employee(Employee Employe)
        {
            if (Employe != null)
            {
                using (AngJSAsp4_EmployeesEntities Obj = new AngJSAsp4_EmployeesEntities())
                {
                    Obj.Employees.Add(Employe);
                    Obj.SaveChanges();
                    return "Employee Added Successfully";
                }
            }
            else
            {
                return "Employee Not Inserted!";
            }
        }

        public string Delete_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                using (AngJSAsp4_EmployeesEntities Obj = new AngJSAsp4_EmployeesEntities())
                {
                    var Emp_ = Obj.Entry(Emp);
                    if (Emp_.State == System.Data.Entity.EntityState.Detached)
                    {
                        Obj.Employees.Attach(Emp);
                        Obj.Employees.Remove(Emp);
                    }
                    Obj.SaveChanges();
                    return "Employee Deleted Successfully";
                }
            }
            else
            {
                return "Employee Not Deleted!";
            }
        }

        public string Update_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                using (AngJSAsp4_EmployeesEntities Obj = new AngJSAsp4_EmployeesEntities())
                {
                    var Emp_ = Obj.Entry(Emp);
                    Employee EmpObj = Obj.Employees.Where(x => x.Emp_Id == Emp.Emp_Id).FirstOrDefault();
                    EmpObj.Emp_Age = Emp.Emp_Age;
                    EmpObj.Emp_City = Emp.Emp_City;
                    EmpObj.Emp_Name = Emp.Emp_Name;
                    Obj.SaveChanges();
                    return "Employee Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated!";
            }
        }
    }
}