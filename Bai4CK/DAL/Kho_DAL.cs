using Bai4CK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4CK.DAL
{
    public class Kho_DAL
    {
        public IEnumerable<Object> getListKhoCT_DAL()
        {
            Bai4KhoDB db = new Bai4KhoDB();
            var query = from p in db.NhapKho_CTs
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
            return query;
        }
        public IQueryable<string> getListTenLoaiHang_DAL()
        {
            Bai4KhoDB db = new Bai4KhoDB();
            var chon = from p in db.LoaiHangs select p.TenLoai;
            return chon;
        }
        public IQueryable<string> getListDVT_DAL()
        {
            Bai4KhoDB db = new Bai4KhoDB();
            var chon = (from p in db.HangHoas select p.DVT).Distinct();
            return chon;
        }
        public IQueryable<string> getListTenHang_DAL()
        {
            Bai4KhoDB db = new Bai4KhoDB();
            var chon = (from p in db.HangHoas select p.TenHang);
            return chon;
        }
        public IQueryable<int> getListSoPhieuN_DAL()
        {
            Bai4KhoDB db = new Bai4KhoDB();
            var chon = (from p in db.NhapKhos select p.SoPhieuN);
            return chon;
        }
        public NhapKho_CT layKhoCT_DAL(int STT )
        {
            Bai4KhoDB db = new Bai4KhoDB();
            NhapKho_CT kct = (from p in db.NhapKho_CTs
                           where p.STT == STT
                           select p).SingleOrDefault();
            return kct;
        }
        public HangHoa  LayHH_tuTen_DAL(string ten)
        {
            Bai4KhoDB db = new Bai4KhoDB();
            HangHoa hh = (from p in db.HangHoas
                              where p.TenHang == ten
                              select p).SingleOrDefault();
            return hh;
        }
        public bool coHang_DAL(HangHoa hh)
        {
            Bai4KhoDB db = new Bai4KhoDB();
            if (db.HangHoas.Contains(hh)) return true;
            return false;

        }
        public LoaiHang  LayLoaiHangtuTen_DAL(string tenlh)
        {
            Bai4KhoDB db = new Bai4KhoDB();
            LoaiHang lh = (from p in db.LoaiHangs
                          where p.TenLoai == tenlh
                          select p).SingleOrDefault();
            return lh;
        }
        public int DemsoHH_DAL()
        {
            Bai4KhoDB db = new Bai4KhoDB();
            int n = (from p in db.HangHoas
                     select p).Count();
            return n;
        }
        public void themNhapKhoCT_DAL(NhapKho_CT nkct, NhapKho nk)
        {
            Bai4KhoDB db = new Bai4KhoDB();
            db.NhapKho_CTs.Add(nkct);
            db.NhapKhos.Add(nk);
            db.SaveChanges();
        }
        public void Xoa_DAL(List<string> msList)
        {
            Bai4KhoDB db = new Bai4KhoDB();
            foreach(string i in msList)
            {
                int a = Convert.ToInt32(i);
                var query = (from p in db.NhapKho_CTs
                            where p.STT == a
                            select p).SingleOrDefault();
                db.NhapKho_CTs.Remove(query);
            }
            db.SaveChanges();     
        }
        public void Update_DAL(NhapKho_CT kct)
        {
            Bai4KhoDB db = new Bai4KhoDB();
            var qr = (from p in db.NhapKho_CTs where p.STT == kct.STT select p).SingleOrDefault();
            qr.STT = kct.STT;
            qr.SoPhieuN = kct.SoPhieuN;
            qr.MaHang = kct.MaHang;
            qr.SLNhap = kct.SLNhap;
            qr.DGNhap = kct.DGNhap;
            
            db.SaveChanges();
        }
    }
}
