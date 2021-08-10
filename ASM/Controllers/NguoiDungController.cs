using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Models;
using ASM.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers
{
    public class NguoiDungController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private INguoidungSvc _nguoidungSvc;
        public NguoiDungController(IWebHostEnvironment webHostEnvironment, INguoidungSvc nguoidungSvc)
        {
            _webHostEnvironment = webHostEnvironment;
            _nguoidungSvc = nguoidungSvc;
        }
        // GET: NguoiDungController
        public ActionResult Index()
        {
            return View(_nguoidungSvc.GetNguoiDungAll());
        }

        // GET: NguoiDungController/Details/5
        public ActionResult Details(int id)
        {
            var nguoidung = _nguoidungSvc.getNguoiDung(id);
            return View(nguoidung);
        }

        // GET: NguoiDungController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NguoiDungController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nguoidung nguoidung)
        {
            try
            {
                _nguoidungSvc.AddNguoiDung(nguoidung);
                return RedirectToAction(nameof(Details), new { id = nguoidung.NguoiDungID});
            }
            catch
            {
                return View();
            }
        }

        // GET: NguoiDungController/Edit/5
        public ActionResult Edit(int id)
        {
            var nguoidung = _nguoidungSvc.getNguoiDung(id);
            return View(nguoidung);
        }

        // POST: NguoiDungController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Nguoidung nguoidung)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _nguoidungSvc.EditNguoiDung(id, nguoidung);
                    return RedirectToAction(nameof(Details), new { id = nguoidung.NguoiDungID});
                }              
            }
            catch
            {
                
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: NguoiDungController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NguoiDungController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
