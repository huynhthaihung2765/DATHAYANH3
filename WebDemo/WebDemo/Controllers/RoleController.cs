using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using Microsoft.AspNet.Identity.EntityFramework;
namespace WebDemo.Controllers
{
    
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        ApplicationDbContext context;
        QLLINHKIENEntities db;
        public RoleController()
        {
            context = new ApplicationDbContext();
            db = new QLLINHKIENEntities();
        }
        // GET: Role
        
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return PartialView(Roles);
        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return PartialView(Role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            try
            { 
            context.Roles.Add(role);
            context.SaveChanges();
                ModelState.AddModelError("CustomError", "Tạo thành công quyền mới");
            }
            catch
            {
                ModelState.AddModelError("CustomError", "Quyền đã tồn tại");
            }
            
            return PartialView(role);
        }
        public ActionResult Delete(string id)
        {
            var iD = context.Roles.Where(s => s.Id == id).FirstOrDefault();
            if(iD==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            context.Roles.Remove(iD);
            context.SaveChanges();
            return RedirectToAction("Index", "Role");
        }
       
    }
}