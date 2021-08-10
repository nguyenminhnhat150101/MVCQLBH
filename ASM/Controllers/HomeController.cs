using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASM.Models;
using ASM.Services;
using ASM.Filters;
using Microsoft.AspNetCore.Http;
using ASM.Constant;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using ASM.Models.ViewModels;

namespace ASM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment _webHostEnvironment;
        IMonanSvc _monanSvc;
        IKhachhangSvc _khachhangSvc;
        IDonhangSvc _donhangSvc;
        IDonhangChitietSvc _donhangChitietSvc;

        public HomeController(IWebHostEnvironment webHostEnvironment, IMonanSvc monanSvc, 
            IKhachhangSvc khachhangSvc, IDonhangSvc donhangSvc, IDonhangChitietSvc donhangChitietSvc)
        {
            _webHostEnvironment = webHostEnvironment;
            _monanSvc = monanSvc;
            _khachhangSvc = khachhangSvc;
            _donhangSvc = donhangSvc;
            _donhangChitietSvc = donhangChitietSvc;
        }
        #region Login - Logout - Register
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Login(string returnUrl)
        {
            string KH_Email = HttpContext.Session.GetString(SessionKey.Khachhang.KH_FullName);
            if (KH_Email != null && KH_Email != "")
            {
                return RedirectToAction("Index", "Home");
            }
            #region Hiển thị Login
            ViewWebLogin login = new ViewWebLogin();
            login.ReturnUrl = returnUrl;
            return View(login);
            #endregion

        }
        public IActionResult Index()
        {
            return View(_monanSvc.GetMonAnAll());
        }
        public IActionResult Cart()
        {
            List<ViewCart> dataCart = new List<ViewCart>();
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
            }
            return View(dataCart);
        }
        [HttpPost]
        public IActionResult UpdateCart(int id, int soluong)
        {          
            var cart = HttpContext.Session.GetString("cart");
            double total = 0;
            if (cart != null)
            {
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].MonAn.MonAnID == id)
                    {
                        dataCart[i].Quantity = soluong;
                        break;
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                total = Tongtien();
                return Ok(total);
            }
            return BadRequest();
        }
        public IActionResult DeleteCart(int id)
        {          
            double total = 0;
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].MonAn.MonAnID == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                total = Tongtien();
                return Ok(total);
            }
            return BadRequest();
        }
        [AuthenticationFilterAttribute_KH]
        public IActionResult OrderCart()
        {
            string kH_Email = HttpContext.Session.GetString(SessionKey.Khachhang.KH_FullName);
            if (kH_Email == null || kH_Email == "")  // đã có session
            {
                return BadRequest();
            }
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null && cart.Count() > 0)
            {
                #region DonHang
                var khachhangContext = HttpContext.Session.GetString(SessionKey.Khachhang.KhachhangContext);
                var khachhangId = JsonConvert.DeserializeObject<Khachhang>(khachhangContext).KhachhangID;

                double total = Tongtien();

                var donhang = new Donhang()
                {
                    trangThaiDonHang = TrangThaiDonHang.Moidat,
                    KhachhangID = khachhangId,
                    Tongtien = total,
                    Ngaydat = DateTime.Now,
                    Ghichu = "",
                };
                #endregion
                _donhangSvc.AddDonhang(donhang);
                int donhangId = donhang.DonhangID;

                #region Chitiet
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    DonhangChitiet chitiet = new DonhangChitiet()
                    {
                        DonhangID = donhangId,
                        MonAnID = dataCart[i].MonAn.MonAnID,
                        Soluong = dataCart[i].Quantity,
                        Thanhtien = dataCart[i].MonAn.Gia * dataCart[i].Quantity,
                        Ghichu = "",
                    };
                    //donhang.DonhangChitiets.Add(chitiet);
                    _donhangChitietSvc.AddDonhangChitietSvc(chitiet);
                }
                #endregion              
                HttpContext.Session.Remove("cart");

                return Ok();
            }
            return BadRequest();
        }

        [NonAction]
        private double Tongtien()
        {
            double total = 0;
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    total += (dataCart[i].MonAn.Gia * dataCart[i].Quantity);
                }
            }
            return total;
        }


        public IActionResult AddCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart==null)
            {
                var monAn = _monanSvc.getMonAn(id);
                List<ViewCart> listCarts = new List<ViewCart>()
                {
                    new ViewCart
                    {
                        MonAn = monAn,
                        Quantity = 1
                    }
                };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCarts));
            }
            else
            {
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].MonAn.MonAnID == id)
                    {
                        dataCart[i].Quantity++;
                        check = false;
                    }
                }
                if (check)
                {
                    var monAn = _monanSvc.getMonAn(id);
                    dataCart.Add(new ViewCart
                    {
                        MonAn = monAn,
                        Quantity = 1
                    });
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
            }
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]       
        public IActionResult Login(ViewWebLogin viewWebLogin)
        {
            if (ModelState.IsValid)
            {
                Khachhang khachhang = _khachhangSvc.Login(viewWebLogin);
                if (khachhang != null)
                {
                    HttpContext.Session.SetString(SessionKey.Khachhang.KH_Email, khachhang.EmailAddress);
                    HttpContext.Session.SetString(SessionKey.Khachhang.KH_FullName, khachhang.FullName);
                    HttpContext.Session.SetString(SessionKey.Khachhang.KhachhangContext,
                        JsonConvert.SerializeObject(khachhang));

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            return View(viewWebLogin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {     
            HttpContext.Session.Remove(SessionKey.Khachhang.KH_Email);
            HttpContext.Session.Remove(SessionKey.Khachhang.KH_FullName);
            HttpContext.Session.Remove(SessionKey.Khachhang.KhachhangContext);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Khachhang khachhang)
        {
            try
            {
                _khachhangSvc.AddKhachhang(khachhang);
                return RedirectToAction(nameof(Login), new { id = khachhang.KhachhangID});
            }
            catch
            {
                return View(); 
            }         
        }
        #endregion

        #region Info + History Dat hang
        [AuthenticationFilterAttribute_KH]
        public ActionResult Info()
        {
            string KH_Email = HttpContext.Session.GetString(SessionKey.Khachhang.KH_FullName);
            if (KH_Email == null && KH_Email == "") //đã có session
            {
                return RedirectToAction("Index", "Home");
            }
            var khachhangContext = HttpContext.Session.GetString(SessionKey.Khachhang.KhachhangContext);
            var khachhangId = JsonConvert.DeserializeObject<Khachhang>(khachhangContext).KhachhangID;
            var khachhang = _khachhangSvc.getKhachhang(khachhangId);
            return View(khachhang);           
        }
        [AuthenticationFilterAttribute_KH]
        // Post: KhachhangController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Info(int KhachhangID, Khachhang khachhang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _khachhangSvc.EditKhachhang(KhachhangID, khachhang);
                    return RedirectToAction(nameof(Index), new { id = khachhang.KhachhangID});
                }
            }
            catch
            {
        
            }
            return RedirectToAction(nameof(Index));
        }

            #endregion
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AuthenticationFilterAttribute_KH]
        public ActionResult Details(int id)
        {
            return View(_donhangSvc.getDonhang(id));
        }
        [AuthenticationFilterAttribute_KH]
        public IActionResult History()
        {
            string KH_Email = HttpContext.Session.GetString(SessionKey.Khachhang.KH_FullName);
            if (KH_Email ==null || KH_Email=="")
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_donhangSvc.GetDonhangAll());
        }
        //#endregion
    }
}
