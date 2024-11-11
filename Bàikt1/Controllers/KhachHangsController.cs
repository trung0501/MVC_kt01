using Bàikt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bàikt1.Controllers
{
    public class KhachHangsController : Controller
    {
        private static List<KhachHang> khachHangList = new List<KhachHang>
    {
        new KhachHang { MaKH = 1, Ten = "Nguyễn Minh Anh", DT = "0912287789", Email = "anh@gmail.com", GioiTinh = "Nữ", DiaChi = "Thanh Nhàn" },
        new KhachHang { MaKH = 2, Ten = "Nguyễn Tuấn Đạt", DT = "0989978999", Email = "dat@gmail.com", GioiTinh = "Nam", DiaChi = "Linh Đàm" }
    };
        // GET: KhachHangs
        public ActionResult Index()
        {
            return View(khachHangList);
        }
        // Action để hiển thị chi tiết của một khách hàng
        public ActionResult Details(int id)
        {
            var khachHang = khachHangList.FirstOrDefault(s => s.MaKH == id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // Action để hiển thị form tạo mới khách hàng
        public ActionResult Create()
        {
            return View();
        }

        // Action để lưu thông tin khách hàng mới
        [HttpPost]
        public ActionResult Create(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHangList.Add(khachHang);
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // Action để hiển thị form sửa thông tin khách hàng
        public ActionResult Edit(int id)
        {
            var khachHang = khachHangList.FirstOrDefault(s => s.MaKH == id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // Action để lưu thông tin khách hàng sau khi chỉnh sửa
        [HttpPost]
        public ActionResult Edit(KhachHang khachHang)
        {
            var existingKhachHang = khachHangList.FirstOrDefault(s => s.MaKH == khachHang.MaKH);
            if (existingKhachHang != null)
            {
                existingKhachHang.Ten = khachHang.Ten;
                existingKhachHang.DT = khachHang.DT;
                existingKhachHang.Email = khachHang.Email;
                existingKhachHang.GioiTinh 0= khachHang.GioiTinh;
                existingKhachHang.DiaChi = khachHang.DiaChi;
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // Action để hiển thị form xóa khách hàng
        public ActionResult Delete(int id)
        {
            var khachHang = khachHangList.FirstOrDefault(s => s.MaKH == id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // Action để xóa khach hang
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var khachHang = khachHangList.FirstOrDefault(s => s.MaKH == id);
            if (khachHang != null)
            {
                khachHangList.Remove(khachHang);
            }
            return RedirectToAction("Index");
        }
    }
}