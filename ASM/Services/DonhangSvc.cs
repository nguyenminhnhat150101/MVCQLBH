using ASM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Services
{
    public interface IDonhangSvc
    {
        List<Donhang> GetDonhangAll();
        List<Donhang> GetDonhangbyKhachhang(int khachhangId);
        Donhang getDonhang(int id);
        int AddDonhang(Donhang donhang);
        int EditDonhang(int id, Donhang donhang);
    }
    public class DonhangSvc : IDonhangSvc
    {
        protected DataContext _context;
        public DonhangSvc(DataContext context)
        {
            _context = context;
        }
        public int AddDonhang(Donhang donhang)
        {
            int ret = 0;
            try
            {
                _context.Add(donhang);
                _context.SaveChanges();
                ret = donhang.DonhangID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int EditDonhang(int id, Donhang donhang)
        {
            int ret = 0;
            try
            {
                _context.Update(donhang);
                _context.SaveChanges();
                ret = donhang.DonhangID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public Donhang getDonhang(int id)
        {
            Donhang donhang = null;
            donhang = _context.Donhangs.Where(x => x.DonhangID == id)
                .Include(x => x.khachhang)
                .Include(x => x.DonhangChitiets).ThenInclude(y => y.MonAn)
                .FirstOrDefault();
            return donhang;
        }

        public List<Donhang> GetDonhangAll()
        {
            List<Donhang> list = new List<Donhang>();
            list = _context.Donhangs.OrderByDescending(x => x.Ngaydat)
                .Include(x => x.khachhang)
                .Include(x => x.DonhangChitiets)
                .ToList();
            return list;
        }

        public List<Donhang> GetDonhangbyKhachhang(int khachhangId)
        {
            List<Donhang> list = new List<Donhang>();
            list = _context.Donhangs.Where(x => x.KhachhangID==khachhangId).OrderByDescending(x=>x.Ngaydat)
                .Include(x => x.khachhang)
                .Include(x => x.DonhangChitiets)
                .ToList();
            return list;
        }
    }
}
