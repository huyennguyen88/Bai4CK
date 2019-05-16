using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4CK.DTO
{
    [Table("LoaiHang")]
    public class LoaiHang
    {
        [Key][StringLength(50)]
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<HangHoa> listHH { get; set; }

    }
}
