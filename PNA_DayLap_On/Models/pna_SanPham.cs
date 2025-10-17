using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace PNA_DayLap_On.Models
{
    [Table("SanPham")]
    public class pna_SanPham
    {
        [Key]
        public long ID { get; set; }
        [Display(Name = "Mã sản phẩm")]
        [StringLength(20)]
        [Required]
        public string MaSanPham { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [StringLength(100)]
        public string TenSanPham { get; set; }

        [Display(Name = "Hinh Anh")]

        public string HinhAnh { get; set; }
        [Display(Name = "Don gia")]
        public decimal Dongia { get; set; }

        [Display(Name = "Số lượng")]

        public int SoLuong { get; set; }
        public long LoaiSanPhamID { get; set; }
        public pna_LoaiSanPham LoaiSanPham { get; set; }


    }
}
