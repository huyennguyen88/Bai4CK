using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4CK.DTO
{
    [Table("NhapKho_CT")]
    public class NhapKho_CT
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }

        public int SoPhieuN { get; set; }
        [ForeignKey("SoPhieuN")]
        public virtual NhapKho nhapkho { get; set; }

        public string MaHang { get; set; }
        [ForeignKey("MaHang")]
        public virtual HangHoa hanghoa { get; set; }

        public string SLNhap { get; set; }
        public string DGNhap { get; set; }
      
        public static bool cppTenHang(object o1, object o2) //0
        {
            string k1, k2;
            k1 = ((NhapKho_CT)o1).hanghoa.TenHang;
            k2 = ((NhapKho_CT)o2).hanghoa.TenHang;
            if (string.Compare(k1, k2) > 0) return false;
            return true;
        }
        public static bool cppNCC(object o1, object o2) //1
        {
            string k1, k2;
            k1 = ((NhapKho_CT)o1).hanghoa.NhaCC;
            k2 = ((NhapKho_CT)o2).hanghoa.NhaCC;
            if (string.Compare(k1, k2) > 0) return false;
            return true;
        }
        public static bool cppLoaiHang(object o1, object o2) //2
        {
            string k1, k2;
            k1 = ((NhapKho_CT)o1).hanghoa.loaihang.TenLoai;
            k2 = ((NhapKho_CT)o2).hanghoa.loaihang.TenLoai;
            if (string.Compare(k1, k2) > 0) return false;
            return true;
        }
        public static bool cppNguoiNhap(object o1, object o2) //3
        {
            string k1, k2;
            k1 = ((NhapKho_CT)o1).nhapkho.NguoiNhap;
            k2 = ((NhapKho_CT)o2).nhapkho.NguoiNhap;
            if (string.Compare(k1, k2) > 0) return false;
            return true;
        }
    }
}
