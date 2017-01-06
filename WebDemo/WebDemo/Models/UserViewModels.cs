using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class spbanchay
    {
        public string TenLK { get; set; }
        public int? Count { get; set; }
        public string Anhbia { get; set; }
        public decimal? Giaban { get; set; }
        public int MaLK { get; set; }
    }
    public partial class resual
    {

        public int MaLK { get; set; }

        public string TenLK { get; set; }

        public Nullable<decimal> Giaban { get; set; }
        
        public string Mota { get; set; }
        public string Anhbia { get; set; }
        public Nullable<System.DateTime> Ngaycapnhat { get; set; }
        public Nullable<int> Soluongton { get; set; }
        public Nullable<int> MaLLK { get; set; }
        public Nullable<int> MaNSX { get; set; }

        public virtual LOAILK LOAILK { get; set; }
        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
    [Serializable]
    public class CartItem
    {
        public LINHKIEN Product { set; get; }
        
        public int Quantity { set; get; }
    }
    public class XacNhan
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Số điện thoại")]      
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Họ tên")]
        public string Hoten { get; set; }
        [Required]
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        public int flag { get; set; }
        
    }
    public class RoleUser
    {
        public string id { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }
    public class Search
    {
       
        public int id { get; set; }
        public string tenlk { get; set; }
    }
    public class keywordsearch
    {
        public string keyword { get; set; }
    }
    public class EditUser
    {
        public string id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Không được vượt quá 50 ký tự !!!")]
        [Display(Name = "Họ Tên")]
        public string Hoten { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [StringLength(100, ErrorMessage = "Không được vượt quá 100 ký tự !!!")]
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Required]
        [Phone]
        [Display(Name ="Số điện thoại")]
        public string sdt { get; set; }
        [Display(Name = "Tuổi")]
        public int Tuoi { get; set; }

        [Display(Name = "Giới tính")]
        public bool Gioitinh { get; set; }

    }
    public class DetailOrder
    {   
        public int Malk { get; set; }
        public string TenLK { get; set; }
        public decimal? Giaban { get; set; }
        public int? quantity { get; set; }
        public decimal? Dongia { get; set; }
    }
    public class LK
    {
        public int MaLK { get; set; }

        public string TenLK { get; set; }

        public Nullable<decimal> Giaban { get; set; }

        public string Mota { get; set; }
        public string Anhbia { get; set; }
      
        public Nullable<int> Soluongton { get; set; }
       
    }
    public class search
    {
        public int value { get; set; }
        public string label { get; set; }
        public string img { get; set; }
    }
}
