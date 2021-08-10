using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Helpers;
using ASM.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers
{
    public class KhachhangController : Controller
    {
        //private readonly IWebHostEnvironment _webHostEnvironment;
        private IKhachhangSvc _khachhangSvc;
        //private IUploadHelper _uploadHelper;
        public KhachhangController(IKhachhangSvc khachhangSvc)
        {
            //_webHostEnvironment = webHostEnvironment;
            _khachhangSvc = khachhangSvc;
            //_uploadHelper = uploadHelper;

        }
        // GET: KhachhangController
        public ActionResult Index()
        {
            return View(_khachhangSvc.GetKhachhangAll());
        }

        // GET: KhachhangController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhachhangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachhangController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: KhachhangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KhachhangController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: KhachhangController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhachhangController/Delete/5
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
