using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class Nguoidung
    {
        [Key]
        public int NguoiDungID { get; set; }
        [Column(TypeName = "nvarchar(100)"), Display(Name = "Tài Khoản"), Required(ErrorMessage = "Bạn cần nhập tài khoản")]
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(100)"), Display(Name = "Họ Tên"), Required(ErrorMessage = "Bạn cần nhập họ tên")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(50)"), Display(Name = "Email"), Required(ErrorMessage = "Bạn cần nhập email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(100)"), Display(Name = "Chức danh"), Required(ErrorMessage = "Bạn cần nhập chức danh")]
        public string Title { get; set; }
        [Display(Name = "Ngày sinh"), DisplayFormat(DataFormatString ="{0:dd//MM/yyyy}"), Required(ErrorMessage = "Bạn cần chọn ngày sinh")]
        public DateTime? DOB { get; set; }
        [Display(Name = "Quản trị"), Required(ErrorMessage = "Bạn cần chọn quản trị")]
        public bool Admin { get; set; }
        [Display(Name = "Sử dụng"), Required(ErrorMessage = "Bạn cần chọn sử dụng")]
        public bool Locked { get; set; }
        [Column(TypeName = "varchar(50)"), Display(Name = "Mật khẩu"), MaxLength(50),Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [Column(TypeName = "varchar(50)"), Display(Name = "Mật khẩu (lần 2)"), MaxLength(50), Required(ErrorMessage = "Bạn cần nhập mật khẩu lần 2")]
        [DataType(DataType.Password), Compare("Password", ErrorMessage = "Mật Khẩu không khớp")]
        //[NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
