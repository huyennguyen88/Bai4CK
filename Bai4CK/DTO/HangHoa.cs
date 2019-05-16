using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4CK.DTO
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string NhaCC { get; set; }
        public string DVT { get; set; }
        public string MaLoai { get; set; }

        [ForeignKey("MaLoai")]
        public virtual LoaiHang loaihang { get; set; }

        public virtual ICollection<NhapKho_CT> khoCT { get; set; }
        public HangHoa()
        {
            this.khoCT = new HashSet<NhapKho_CT>();
        }
    }
}
