using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PNA_DayLap_On.Models
{
    [Table("pna_LoaiSanPham")]
    
    public class pna_LoaiSanPham
    {
        [Key]
        public long ID { get; set; }
        [Display(Name = "Mã loại sản phẩm")]
        [StringLength(20)]
        public string MaLoaiSanPham { get; set; }
        [Display(Name = "Tên loại sản phẩm")]
        [StringLength(100)]
        public string TenLoaiSanPham { get; set; }

        [Display(Name = "Trạng thái")]

        public string TrangThai { get; set; }
        public ICollection<pna_SanPham> SanPhams { get; set; }


    }
}
