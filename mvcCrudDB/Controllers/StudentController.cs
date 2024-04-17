using mvcCrudDB.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCrudDB.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        student_dbEntities1 dbObj = new student_dbEntities1();
        public ActionResult Student(tbl_student obj)
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tbl_student model) /*model is used to receive data from view*/
        {
            tbl_student obj = new tbl_student();  /*model data will get assign in this object*/
            if (ModelState.IsValid)
            {
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                if (model.ID > 0)
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified; /*object which is coming, its state will get modified*/
                }
            }
            ModelState.Clear();
            return View("Student");
        }
        public ActionResult StudentList()
        {
            var res=dbObj.tbl_student.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res=dbObj.tbl_student.Where(x => x.ID == id).First();
            dbObj.tbl_student.Remove(res);
            dbObj.SaveChanges();
            var list = dbObj.tbl_student.ToList();
            return View("StudentList,list");
        }
    }
}