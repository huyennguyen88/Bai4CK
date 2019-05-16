using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4CK.DTO
{
    [Table("NhapKho")]
    public class NhapKho
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SoPhieuN { get; set; }

        public DateTime NgayNhap { get; set; }
        public string NguoiNhap { get; set; }
        public string LyDoNhap { get; set; }

        public virtual ICollection<NhapKho_CT> khoCT { get; set; }

        public NhapKho()
        {
            this.khoCT = new HashSet<NhapKho_CT>();
        }



    } 
}
