﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021030.BusinessLayers;
using _19T1021030.DomainModels;

namespace _19T1021030.Web.Controllers
{
    [Authorize]
    public class ShipperController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string SHIPPER_SEARCH = "ShipperSearch";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public ActionResult Index(int page = 1, string searchValue = "")
        //{
        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfShipper(page, PAGE_SIZE, searchValue, out rowCount);

        //    int pageCount = rowCount / PAGE_SIZE;
        //    if (rowCount % PAGE_SIZE > 0)
        //        pageCount += 1;
        //    ViewBag.Page = page;
        //    ViewBag.RowCount = rowCount;
        //    ViewBag.PageCount = pageCount;
        //    ViewBag.SearchValue = searchValue;

        //    return View(data);//Truyền dữ liệu bằng Model
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Models.PaginationSearchInput condition = Session["SHIPPER_SEARCH"] as Models.PaginationSearchInput;
            if (condition == null)
            {
                condition = new Models.PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = ""
                };
            }

            return View(condition);
        }

        public ActionResult Search(Models.PaginationSearchInput condition) //int Page, int PageSize, string SearchValue
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfShipper(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            Models.ShipperSearchOutput result = new Models.ShipperSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session["SHIPPER_SEARCH"] = condition;

            return View(result);
        }

        public ActionResult Create()
        {
            var data = new Shipper()
            {
                ShipperID = 0
            };
            ViewBag.Title = "Bổ sung người giao hàng";
            return View("Edit",data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            var data = CommonDataService.GetShipper(id);
            if (data == null)
                return RedirectToAction("Index");

            ViewBag.Title = "Cập nhật người giao hàng";
            return View(data);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Shipper data)
        {
            if (string.IsNullOrWhiteSpace(data.ShipperName))
                ModelState.AddModelError(nameof(data.ShipperName), "Tên người giao hàng không được để trống");
            if (string.IsNullOrWhiteSpace(data.Phone))
                ModelState.AddModelError(nameof(data.Phone), "Số điện thoại không được để trống");

            if (ModelState.IsValid == false)
            {
                ViewBag.Title = data.ShipperID == 0 ? "Bổ sung người giao hàng" : "Cập nhật người giao hàng";
                return View("Edit", data);
            }
                if (data.ShipperID == 0)
            {
                CommonDataService.AddShipper(data);
            }
            else
            {
                CommonDataService.UpdateShipper(data);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteShipper(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetShipper(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
    }
}