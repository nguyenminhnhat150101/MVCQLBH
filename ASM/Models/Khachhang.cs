using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class Khachhang
    {
        [Key]
        public int KhachhangID { get; set; }
        [Column(TypeName = "varchar(50)"), Display(Name = "Email"), Required(ErrorMessage = "Bạn cần nhập email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không hợp lệ")]
        public string EmailAddress { get; set; }
        [Column(TypeName = "nvarchar(100)"), Display(Name = "Họ Tên"), Required(ErrorMessage = "Bạn cần nhập họ tên")]
        public string FullName { get; set; }
        [Display(Name = "Ngày sinh"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}"), Required(ErrorMessage = "Bạn cần chọn ngày sinh")]
        public DateTime? NgaySinh { get; set; }
        [Column(TypeName = "varchar(15)"), MaxLength(15), Display(Name = "Số phone"), Required(ErrorMessage = "Bạn cần nhập số điện thoại")]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }      
        [Column(TypeName = "varchar(50)"), Display(Name = "Mật khẩu"), MaxLength(50), Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Column(TypeName = "varchar(50)"), Display(Name = "Nhập lại mật khẩu"), MaxLength(50), Required(ErrorMessage = "Bạn cần nhập lại mật khẩu")]
        [DataType(DataType.Password), Compare("Password", ErrorMessage = "Mật Khẩu không khớp")]      
        public string ConfirmPassword { get; set; }
        [StringLength(250)]
        [Display(Name = "Mô tả")]
        public string Mota { get; set; }
    }
}
