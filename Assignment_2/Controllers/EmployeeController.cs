using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Razor;
using Assignment_2.Models;
using Microsoft.Ajax.Utilities;

namespace Assignment_2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            Db db = new Db();
            ViewBag.Location = new SelectList(db.LocationTbls, "LocationId", "LocationName");
            ViewBag.Position = new SelectList(db.PositionTbls, "PositionId", "PositionName");

            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (Db db = new Db())
            {
                EmployeeTbl tbl = new EmployeeTbl();
                tbl.EmployeeName = model.EmployeeName;
                tbl.PresentAddress = model.PresentAddress;
                tbl.PermanentAddress = model.PermanentAddress;
                tbl.LocationId = model.LocationId;
                tbl.PositionId = model.PositionId;
                tbl.Gender = model.Gender;
                tbl.Phone = model.PhoneNumber;
                tbl.IsUserOfSystem = model.IsUserOfSystem;
                tbl.DateOfBirth = model.DateOfBirth;
                tbl.JoiningDate = model.JoiningDate;
                tbl.Salary = model.Salary;
                //tbl.MaritalStatus = model.MaritalStatus;
                int id = model.EmployeeId;

                db.EmployeeTbls.Add(tbl);
                db.SaveChanges();
            }

            TempData["SM"] = "You Have Added A Employee Information";

            return RedirectToAction("Index");
        }

        public ActionResult Info()
        {
            using (Db db = new Db())
            {
                List<EmployeeTbl> list = db.EmployeeTbls.ToList();
                List<EmployeeVm> emp = list.Select(x => new EmployeeVm
                {
                    EmployeeId = x.EmployeeId,
                    EmployeeName = x.EmployeeName,
                    PermanentAddress = x.PermanentAddress,
                    PresentAddress = x.PresentAddress,
                    PhoneNumber = x.Phone,
                    LocationId = x.LocationTbl.LocationId,
                    PositionId = x.PositionTbl.PositionId,
                    LocationName = x.LocationTbl.LocationName,
                    PositionName = x.PositionTbl.PositionName
                }).ToList();
                return View(emp);
            }
        }

        public ActionResult EditInfo(int id)
        {
            EmployeeVm model;
            Db db = new Db();
            EmployeeTbl tbl = db.EmployeeTbls.Find(id);
            if (tbl == null)
            {
                return Content("Information Not Found!");
            }

            ViewBag.Location = new SelectList(db.LocationTbls, "LocationId", "LocationName");
            ViewBag.Position = new SelectList(db.PositionTbls, "PositionId", "PositionName");

            model = new EmployeeVm(tbl);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditInfo(EmployeeVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (Db db=new Db())
            {
                var tbl = db.EmployeeTbls.Find(model.EmployeeId);
                if (tbl != null)
                {
                    tbl.EmployeeName = model.EmployeeName;
                    tbl.PresentAddress = model.PresentAddress;
                    tbl.PermanentAddress = model.PermanentAddress;
                    tbl.LocationId = model.LocationId;
                    tbl.PositionId = model.PositionId;
                    tbl.Gender = model.Gender;
                    tbl.Phone = model.PhoneNumber;
                    tbl.IsUserOfSystem = model.IsUserOfSystem;
                    tbl.DateOfBirth = model.DateOfBirth;
                    tbl.JoiningDate = model.JoiningDate;
                    tbl.Salary = model.Salary;

                    db.SaveChanges();
                }
            }

            TempData["SM"] = "You Have Updated A Employee Information";

            return this.RedirectToAction("EditInfo");
        }

        public ActionResult DeleteInfo(int id)
        {
            using (Db db = new Db())
            {
                EmployeeTbl tbl = db.EmployeeTbls.Find(id);
                db.EmployeeTbls.Remove(tbl);
                db.SaveChanges();
            }

            return RedirectToAction("Info");
        }
    }
}