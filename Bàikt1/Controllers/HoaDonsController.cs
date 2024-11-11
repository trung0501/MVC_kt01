using Bàikt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bàikt1.Controllers
{
    public class HoaDonsController : Controller
    {
        private static List<HoaDon> hoaDonList = new List<HoaDon>
    {
        new HoaDon { SoHD = 1, TenH = "Báo tuổi trẻ", NgayDat = new DateTime(2024, 5, 12), SL = 5, DonGia = 25000, MaKH = 1 },
        new HoaDon { SoHD = 2, TenH = "Báo mua sắm", NgayDat = new DateTime(2024, 6, 12), SL = 10, DonGia = 30000, MaKH = 1 },
        new HoaDon { SoHD = 3, TenH = "Báo tuổi trẻ", NgayDat = new DateTime(2024, 8, 9), SL = 50, DonGia = 25000, MaKH = 2 }
    };
        // GET: HoaDons
        public ActionResult Index()
        {
            return View(hoaDonList);
        }
        // Action Details: hiển thị chi tiết hoa don
        public ActionResult Details(int id)
        {
            var hoaDon = hoaDonList.FirstOrDefault(d => d.SoHD == id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // Action Create: hiển thị form tạo hoa don mới
        public ActionResult Create()
        {
            return View();
        }

        // Action Create [POST]: xử lý thêm hoa don mới
        [HttpPost]
        public ActionResult Create(HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                hoaDonList.Add(hoaDon);
                return RedirectToAction("Index");
            }
            return View(hoaDon);
        }

        // Action Edit: hiển thị form sửa hoa don
        public ActionResult Edit(int id)
        {
            var hoaDon = hoaDonList.FirstOrDefault(d => d.SoHD == id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // Action Edit [POST]: xử lý cập nhật hoa don
        [HttpPost]
        public ActionResult Edit(HoaDon hoaDon)
        {
            var existingHoaDon = hoaDonList.FirstOrDefault(d => d.SoHD == hoaDon.SoHD);
            if (existingHoaDon != null)
            {
                existingHoaDon.TenH = hoaDon.TenH;
                existingHoaDon.NgayDat = hoaDon.NgayDat;
                existingHoaDon.SL = hoaDon.SL;
                existingHoaDon.DonGia = hoaDon.DonGia;
                existingHoaDon.MaKH = hoaDon.MaKH;
                return RedirectToAction("Index");
            }
            return View(hoaDon);
        }

        // Action Delete: hiển thị form xóa hoa don
        public ActionResult Delete(int id)
        {
            var hoaDon = hoaDonList.FirstOrDefault(d => d.SoHD == id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // Action Delete [POST]: xử lý xóa hoa don
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var hoaDon = hoaDonList.FirstOrDefault(d => d.SoHD == id);
            if (hoaDon != null)
            {
                hoaDonList.Remove(hoaDon);
            }
            return RedirectToAction("Index");
        }
    }
}