using Bai4CK.DAL;
using Bai4CK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4CK.BLL
{
    public class Kho_BLL
    {
        public Kho_DAL dal { get; set; }
        public Kho_BLL()
        {
            this.dal = new Kho_DAL();
        }
        public IEnumerable<Object> getListKhoCT_BLL()
        {
            return dal.getListKhoCT_DAL();
        }
        public IQueryable<string> getListTenLoaiHang_BLL()
        {
            return dal.getListTenLoaiHang_DAL();
        }
        public IQueryable<string> getListDVT_BLL()
        {
            return dal.getListDVT_DAL();
        }
        public IQueryable<string> getListTenHang_BLL()
        {
            return dal.getListTenHang_DAL();
        }
        public NhapKho_CT layKhoCT_BLL(int STT)
        {
            return dal.layKhoCT_DAL(STT);
        }
        public HangHoa LayHH_tuTen_BLL(string ten)
        {
            return dal.LayHH_tuTen_DAL(ten);
        }
        public bool coHang_BLL(HangHoa hh)
        {
            return dal.coHang_DAL(hh);
        }
        public LoaiHang LayLoaiHangtuTen_BLL(string tenlh)
        {
            return dal.LayLoaiHangtuTen_DAL(tenlh);
        }
        public int DemsoHH_BLL()
        {
            return dal.DemsoHH_DAL();
        }
        public void themNhapKhoCT_BLL(NhapKho_CT nkct, NhapKho nk)
        {
            dal.themNhapKhoCT_DAL(nkct,  nk);
        }
        public void Xoa_BLL(List<string> msList)
        {
            dal.Xoa_DAL(msList);
        }
        public IQueryable<int> getListSoPhieuN_BLL()
        {
            return dal.getListSoPhieuN_DAL();
        }
        public void Update_BLL(NhapKho_CT kct)
        {
            dal.Update_DAL(kct);
        }

    }
}
