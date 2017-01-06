using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using PagedList;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WebDemo.Controllers
{

    public class LinhKienController : Controller
    {
        QLLINHKIENEntities data = new QLLINHKIENEntities();
        // GET: LinhKien

        public ActionResult Index()
        {
            ViewBag.Url = Request.Url.ToString();
            //lay 6 linh kiện mới
            var lkmoi = SPmoi(6);


            return View(lkmoi);

        }

        private List<LINHKIEN> SPmoi(int count)
        {
            // sắp xếp giảm dần ngày cập nhật, lấy count dong đầu
            return data.LINHKIENs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult spbanchay() //6 sản phẩm bán chạy
        {
            // lay 4 linh kiện bán chạy
            var lkhot = from a in data.LINHKIENs
                        join b in data.CHITIETDONTHANGs on a.MaLK equals b.MaLK
                        select new { a.TenLK, b.Soluong, a.Anhbia, a.Giaban, a.MaLK } into c
                        group c by new { c.TenLK, c.Anhbia, c.Giaban, c.MaLK } into d   // gộp nhóm c bằng khóa chính tenlk
                        select new spbanchay() //đưa vào viewmodel để hiển thị bên view
                        {
                            TenLK = d.Key.TenLK,
                            Anhbia = d.Key.Anhbia,
                            Giaban = d.Key.Giaban,
                            MaLK = d.Key.MaLK,
                            Count = d.Sum(a => a.Soluong)

                        };
            ViewBag.returnUrl = Request.Url.ToString();
            return PartialView(lkhot.OrderByDescending(a => a.Count).Take(6));//sắp xếp giảm dần take 6 hàng đầu  
        }
        public List<string> ListNamea(string keyword)
        {
            return data.LINHKIENs.Where(x => x.TenLK.Contains(keyword)).Select(x => x.TenLK).ToList();
        }
        public JsonResult ListName(string q)
        {
            var dataa = ListNamea(q);
            var test = from a in data.LINHKIENs
                       where a.TenLK.Contains(q)
                       select new search
                       {
                           value = a.MaLK,
                           label = a.TenLK,
                           img = a.Anhbia
                       };
            return Json(new
            {
                data = test,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string keyword, int? page)
        {

            // Tạo biến quy định số trang hiển thị
            int pageSize = 9;
            // Tạo biến số trang 
            int pageNum = (page ?? 1);
            ViewBag.key = keyword;
            ViewBag.Url = Request.Url.ToString();
            var show = data.LINHKIENs.Where(n => n.TenLK.Contains(keyword)).ToList();
            return View(show.ToPagedList(pageNum, pageSize));
        }
        public PartialViewResult loailinhkien() //loại linh kiện bên meunu trái
        {
            var loailk = data.LOAILKs.ToList();
            return PartialView(loailk);
        }

        [ValidateInput(false)]
        public ActionResult Details(int id) // show chi tiết sản phẩm với mã sp = id
        {
            var Details = from details in data.LINHKIENs
                          where details.MaLK == id
                          select details;
            ViewBag.Url = "http://npn.kimminhtien.xyz/LinhKien/Details/" + id.ToString();
            ViewBag.returnUrl = Request.Url.ToString();
            return View(Details.Single());
        }



        public ActionResult SPtheoloai(int? page, int id) // show danh sách các loại hàng
        {
            // Tạo biến quy định số trang hiển thị
            int pageSize = 9;
            // Tạo biến số trang 
            int pageNum = (page ?? 1);
            var sptheoloai = (from loai in data.LINHKIENs
                              where loai.MaLLK == id
                              select loai).ToList();
            var ten = data.LINHKIENs.Where(n => n.MaLLK == id).Select(n => n.LOAILK.TENLLK).FirstOrDefault();
            ViewBag.id = id;
            ViewBag.tenloai = ten;
            ViewBag.Url = Request.Url.ToString();
            return View(sptheoloai.ToPagedList(pageNum, pageSize));
        }
        public ActionResult SPlienquan(int? loai, int? nsx, int malk) //show 4 sản phẩm liên quan
        {
            var Splq = from splq in data.LINHKIENs
                       where splq.MaLLK == loai && splq.MaNSX == nsx && splq.MaLK != malk
                       select splq;
            ViewBag.Url = Request.Url.ToString();
            return PartialView(Splq.Take(4));

        }
        public PartialViewResult HeaderCart()
        {
            try
            {
                string CartSession = "CartSession";
                var cart = Session[CartSession];
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }

                return PartialView(list);
            }
            catch
            {
                var list = new List<CartItem>();
                return PartialView(list);
            }
        }

        public ActionResult LinhKien(int? page)
        {
            // Tạo biến quy định số trang hiển thị
            int pageSize = 9;
            // Tạo biến số trang 
            int pageNum = (page ?? 1);
            var a = data.LINHKIENs.OrderByDescending(n => n.Ngaycapnhat).ToList();
            ViewBag.Url = Request.Url.ToString();
            return View(a.ToPagedList(pageNum, pageSize));

        }

        public ActionResult Baohanh()
        {
            return View();
        }

        public PartialViewResult ScrollMenu()
        {
            var loailk = data.LOAILKs.ToList();
            return PartialView(loailk);
        }

        [HttpGet]
        public JsonResult MiniDetail(int id)
        {
            var detail = (from a in data.LINHKIENs
                          where (a.MaLK == id)
                          select new LK
                          {
                              MaLK = a.MaLK,
                              TenLK = a.TenLK,
                              Anhbia = a.Anhbia,
                              Giaban = a.Giaban,
                              Mota = a.Mota,
                              Soluongton = a.Soluongton

                          }).Single();
            resual test = new resual();

            return Json(new
            {

                status = true,
                data = detail
            }, JsonRequestBehavior.AllowGet);
        }

    }
}