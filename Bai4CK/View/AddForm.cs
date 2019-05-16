using Bai4CK.BLL;
using Bai4CK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4CK.View
{
    public partial class AddForm : Form
    {
        Kho_BLL bll = new Kho_BLL();
        public AddForm()
        {
            InitializeComponent();
       
        }
        private void AddForm_Load(object sender, EventArgs e)
        {
            LoadCbbTenHang();
        }
        public void LoadCbbTenHang()
        {
            var c = bll.getListTenHang_BLL().ToArray();
            cbbTenHang.Items.AddRange(c);
        }

        public void Them()
        {
            NhapKho nk = new NhapKho
            {
                NgayNhap = dtpNgay.Value,
                NguoiNhap = txtNguoi.Text,
                LyDoNhap = txtLido.Text,
            };
            //Lay hang hoa tu ten
            HangHoa hh = bll.LayHH_tuTen_BLL(cbbTenHang.SelectedItem.ToString());
            NhapKho_CT khoCT = new NhapKho_CT
            {
                SoPhieuN = nk.SoPhieuN,
                MaHang = hh.MaHang, 
                SLNhap = txtSoLuong.Text,
                DGNhap = txtDonGia.Text,
            };
        
            bll.themNhapKhoCT_BLL(khoCT, nk);
        }
        public delegate void okButton();
        public okButton OnOkButton;
        private void btnOK_Click(object sender, EventArgs e)
        {
            Them();
            if (OnOkButton != null) OnOkButton();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
