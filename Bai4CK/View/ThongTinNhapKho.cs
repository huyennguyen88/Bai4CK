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
    public partial class ThongTinNhapKho : Form
    {
        Kho_BLL bll = new Kho_BLL();

        public ThongTinNhapKho()
        {
            InitializeComponent();
        }
        public void LoadCbbtenLoaiHang()
        {
            var c= bll.getListTenLoaiHang_BLL().ToArray();
            cbbLoai.Items.AddRange(c);
        }
        
         public void LoadCbbSoPhieuN()
        {
            var c = bll.getListSoPhieuN_BLL().ToArray();
            foreach(int i in c)
            {
                cbbSoPhieuN.Items.Add(i.ToString());
            }
        }
        public void LoadCbbDVT()
        {
            var c= bll.getListDVT_BLL().ToArray();
            cbbDVT.Items.AddRange(c);
        }
        public void LoadCbbTenHang()
        {
            var c = bll.getListTenHang_BLL().ToArray();
            cbbTenHang.Items.AddRange(c);
        }
        private void ThongTinNhapKho_Load(object sender, EventArgs e)
        {
            this.Enabled = true;
            LoadCbbtenLoaiHang();
            LoadCbbDVT();
            LoadCbbTenHang();
            LoadCbbSoPhieuN();
        }
        public void ShowDGV()
        {
            var qu = bll.getListKhoCT_BLL();
            dgv.DataSource = qu.ToList();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowDGV();
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string stt;
            stt = dgv.SelectedRows[0].Cells["STT"].Value.ToString();
            NhapKho_CT kct = bll.layKhoCT_BLL(Convert.ToInt32(stt));
            txtSTT.Text = kct.STT.ToString();
        
            txtSoLuong.Text = kct.SLNhap;
            txtNguoi.Text = kct.nhapkho.NguoiNhap;
            txtNCC.Text = kct.hanghoa.NhaCC;
            txtLido.Text = kct.nhapkho.LyDoNhap;
            txtDonGia.Text = kct.DGNhap;

            cbbSoPhieuN.SelectedIndex = cbbSoPhieuN.FindStringExact(kct.nhapkho.SoPhieuN.ToString());
            cbbLoai.SelectedIndex = cbbLoai.FindStringExact(kct.hanghoa.loaihang.TenLoai);
            cbbDVT.SelectedIndex = cbbDVT.FindStringExact(kct.hanghoa.DVT);
            cbbTenHang.SelectedIndex = cbbTenHang.FindStringExact(kct.hanghoa.TenHang);

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            f.OnOkButton += ShowDGV;
            f.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection tap = dgv.SelectedRows;
            List<string> listMa = new List<string>();
            foreach(DataGridViewRow r in tap)
            {
                string ms = r.Cells["STT"].Value.ToString();
                listMa.Add(ms);
            }
            bll.Xoa_BLL(listMa);
            ShowDGV();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string ms = txtSTT.Text;
            HangHoa hh = bll.LayHH_tuTen_BLL(cbbTenHang.SelectedItem.ToString());
            NhapKho_CT kct = bll.layKhoCT_BLL(Convert.ToInt32(ms));
            kct.SoPhieuN = Convert.ToInt32(cbbSoPhieuN.SelectedItem.ToString());
            kct.MaHang = hh.MaHang;
            kct.SLNhap = txtSoLuong.Text;
            kct.DGNhap = txtDonGia.Text;

            bll.Update_BLL(kct);
            ShowDGV();
        }
        private void btnSearch_Click(object sender, EventArgs e) //Theo ten hang
        {
            DataGridViewRowCollection tap = dgv.Rows;
            List<int> listSTT = new List<int>();
            List<NhapKho_CT> listOB = new List<NhapKho_CT>();
            foreach(DataGridViewRow r in tap)
            {
                string ms = r.Cells["STT"].Value.ToString();
                NhapKho_CT ct = bll.layKhoCT_BLL(Convert.ToInt32(ms));
                if (ct.hanghoa.TenHang.Contains(txtSearch.Text)) listOB.Add(ct);
            }
            var qu = from p in listOB
                     select new
                     {
                         p.STT,
                         p.nhapkho.NgayNhap,
                         p.nhapkho.NguoiNhap,
                         p.nhapkho.LyDoNhap,
                         p.hanghoa.TenHang,
                         p.hanghoa.NhaCC,
                         p.hanghoa.DVT,
                         p.hanghoa.loaihang.TenLoai,
                         p.SLNhap,
                         p.DGNhap,
                     };
            dgv.DataSource = qu.ToList();
        }
        public delegate bool SoSanhOB(object o1, object o2);
        public List<NhapKho_CT> SortTongQuat(List<NhapKho_CT> listOb, SoSanhOB ss)
        {
            int i, j;
            for (i = 0; i < listOb.Count - 1; i++)
            {
                for (j = i + 1; j < listOb.Count; j++)
                {
                    if (ss(listOb[i], listOb[j]) == false)
                    {
                        NhapKho_CT temp;
                        temp = listOb[i];
                        listOb[i] = listOb[j];
                        listOb[j] = temp;
                    }
                }
            }
            return listOb;

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int index;
            index = cbbSort.SelectedIndex;
            DataGridViewRowCollection tap = dgv.Rows;
            List<int> listSTT = new List<int>();
            List<NhapKho_CT> listOB = new List<NhapKho_CT>();
            foreach (DataGridViewRow r in tap)
            {
                string ms = r.Cells["STT"].Value.ToString();
                NhapKho_CT ct = bll.layKhoCT_BLL(Convert.ToInt32(ms));
                if (ct.hanghoa.TenHang.Contains(txtSearch.Text)) listOB.Add(ct);
            }
            List<NhapKho_CT> listOrder;
            //Sort tong quat
            SoSanhOB ss;
            if (index == 0) ss = NhapKho_CT.cppTenHang;
            else if (index == 1) ss = NhapKho_CT.cppNCC;
            else if (index == 2) ss = NhapKho_CT.cppLoaiHang;
            else ss = NhapKho_CT.cppNguoiNhap;
            listOrder = SortTongQuat(listOB, ss);
            var qu = from p in listOrder
                     select new
                     {
                         p.STT,
                         p.nhapkho.NgayNhap,
                         p.nhapkho.NguoiNhap,
                         p.nhapkho.LyDoNhap,
                         p.hanghoa.TenHang,
                         p.hanghoa.NhaCC,
                         p.hanghoa.DVT,
                         p.hanghoa.loaihang.TenLoai,
                         p.SLNhap,
                         p.DGNhap,
                     };
            dgv.DataSource = qu.ToList();

        }
    }
}
