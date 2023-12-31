﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;


namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
		private string connection;
		private dbSachOnlineDataContext data;

		public SachOnlineController()
		{
			// Khởi tạo chuỗi kết nối
			connection = "Data Source=LAPTOP-VRO7LLTN\\SQLEXPRESS;Initial Catalog=SachOnline;Integrated Security=True";
			data = new dbSachOnlineDataContext(connection);
		}

		private List<SACH> LaySachMoi(int count)
		{
			return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
		}
		// GET: SachOnline
		public ActionResult Index()
		{
			//Lay 6 quyen sach moi
			var listSachMoi = LaySachMoi(6);
			return View(listSachMoi);
		}
		public ActionResult ChuDePartial() 
        { 
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe); 
        }
		public ActionResult SlidePartial()
		{
			return PartialView();
		}

		public ActionResult NhaXuatBanPartial()
		{
			var listNhaXuatBan = from cd in data.NHAXUATBANs select cd;
			return PartialView(listNhaXuatBan);
		}

		public ActionResult SachBanNhieuPartial()
		{
			var listSachBanNhieu = data.SACHes.OrderByDescending(a => a.SoLuong).Take(6).ToList();
			return PartialView("SachBanNhieuPartial",listSachBanNhieu);
		}

		public ActionResult NavPartial()
		{
			return PartialView();
		}

		public ActionResult FooterPartial()
		{
			return PartialView();
		}
	}
}