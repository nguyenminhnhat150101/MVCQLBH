﻿using ASM.Helpers;
using ASM.Models;
using ASM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Services
{
    public interface INguoidungSvc
    {
        List<Nguoidung> GetNguoiDungAll();
        Nguoidung getNguoiDung(int id);
        int AddNguoiDung(Nguoidung nguoidung);
        int EditNguoiDung(int id, Nguoidung nguoidung);
        Nguoidung Login(ViewLogin viewLogin);
    }
    public class NguoidungSvc : INguoidungSvc
    {
        protected DataContext _context;
        protected IMahoaHelper _mahoaHelper;
        public NguoidungSvc(DataContext context, IMahoaHelper mahoaHelper)
        {
            _context = context;
            _mahoaHelper = mahoaHelper;
        }
        public int AddNguoiDung(Nguoidung nguoidung)
        {
            int ret = 0;
            try
            {
                nguoidung.Password = _mahoaHelper.Mahoa(nguoidung.Password);
                nguoidung.ConfirmPassword = nguoidung.Password;
                _context.Add(nguoidung);
                _context.SaveChanges();
                ret = nguoidung.NguoiDungID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int EditNguoiDung(int id, Nguoidung nguoidung)
        {
            int ret = 0;
            try
            {
                Nguoidung _nguoidung = null;
                _nguoidung = _context.Nguoidungs.Find(id); //cách này chỉ dùng cho Khóa chính

                _nguoidung.UserName = nguoidung.UserName;
                _nguoidung.FullName = nguoidung.FullName;
                _nguoidung.Title = nguoidung.Title;
                _nguoidung.DOB = nguoidung.DOB;
                _nguoidung.Email = nguoidung.Email;
                _nguoidung.Admin = nguoidung.Admin;
                _nguoidung.Locked = nguoidung.Locked;
                if (nguoidung.Password != null)
                {
                    nguoidung.Password = _mahoaHelper.Mahoa(nguoidung.Password);
                    _nguoidung.Password = nguoidung.Password;
                }
                _context.Update(_nguoidung);
                _context.SaveChanges();
                ret = nguoidung.NguoiDungID;
            }
            catch
            {
                ret = 0;
            }
            return ret;

        }

        public Nguoidung getNguoiDung(int id)
        {
            Nguoidung nguoidung = null;
            nguoidung = _context.Nguoidungs.Find(id); //cách này chỉ dùng cho Khóa chính
            //product = _context.Products.Where(e=>e.Id==id).FirstOrDefault(); //cách tổng quát
            return nguoidung;
        }

        public List<Nguoidung> GetNguoiDungAll()
        {
            List<Nguoidung> list = new List<Nguoidung>();
            list = _context.Nguoidungs.ToList();
            return list;
        }

        public Nguoidung Login(ViewLogin viewLogin)
        {
            var u = _context.Nguoidungs.Where(
                p => p.UserName.Equals(viewLogin.UserName) 
                && p.Password.Equals(_mahoaHelper.Mahoa(viewLogin.Password))
                ).FirstOrDefault();
            return u;
        }
    }
}
