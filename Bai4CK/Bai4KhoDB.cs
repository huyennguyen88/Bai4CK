namespace Bai4CK
{
    using Bai4CK.DTO;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Bai4KhoDB : DbContext
    {
        public Bai4KhoDB()
            : base("name=Bai4KhoDB")
        {
            Database.SetInitializer<Bai4KhoDB>(new ChienLuocKhoiTao());
        }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<NhapKho> NhapKhos { get; set; }
        public virtual DbSet<NhapKho_CT> NhapKho_CTs { get; set; }
        public class ChienLuocKhoiTao : CreateDatabaseIfNotExists<Bai4KhoDB>
        {
            protected override void Seed(Bai4KhoDB context)
            {
                LoaiHang lh1 = new LoaiHang
                {
                    MaLoai = "LH1",
                    TenLoai= "Bánh",
                };
                LoaiHang lh2 = new LoaiHang
                {
                    MaLoai = "LH2",
                    TenLoai = "Gia vị",
                };
                LoaiHang lh3 = new LoaiHang
                {
                    MaLoai = "LH3",
                    TenLoai = "Kẹo",
                };
                HangHoa hh1 = new HangHoa
                {
                    MaHang = "HH1",
                    TenHang = "Kẹo socola abc",
                    NhaCC = "Công ty abc",
                    DVT = "Gói",
                    MaLoai = "LH3",
                };
                HangHoa hh2 = new HangHoa
                {
                    MaHang = "HH2",
                    TenHang = "Bánh bông lan ttt",
                    NhaCC = "Công ty Hải Hà",
                    DVT = "Hộp",
                    MaLoai = "LH1",
                };
                HangHoa hh3 = new HangHoa
                {
                    MaHang = "HH3",
                    TenHang = "Bánh phông tôm oishi",
                    NhaCC = "Công ty xyz",
                    DVT = "Gói",
                    MaLoai = "LH1",
                };
                HangHoa hh4 = new HangHoa
                {
                    MaHang = "HH4",
                    TenHang = "Mì Chính at",
                    NhaCC = "Công ty mì chính",
                    DVT = "Gói",
                    MaLoai = "LH2",
                };

                context.LoaiHangs.Add(lh1);
                context.LoaiHangs.Add(lh2);
                context.LoaiHangs.Add(lh3);

                context.HangHoas.Add(hh1);
                context.HangHoas.Add(hh2);
                context.HangHoas.Add(hh3);
                context.HangHoas.Add(hh4);

                context.SaveChanges();
                NhapKho nk1 = new NhapKho
                {
                    NgayNhap = new DateTime(2018, 7, 21),
                    NguoiNhap = "Phạm Thị Lan",
                    LyDoNhap = "Mua thêm hàng",
                };
                NhapKho nk2 = new NhapKho
                {
                    NgayNhap = new DateTime(2018, 7, 18),
                    NguoiNhap = "Phạm Văn Nam",
                    LyDoNhap = "Dự trữ hàng",
                };
                NhapKho_CT nkct1 = new NhapKho_CT
                {
                    SoPhieuN = 1,
                    MaHang = "HH1",
                    SLNhap = "100",
                    DGNhap = "20000",
                };
                NhapKho_CT nkct2 = new NhapKho_CT
                {
                    SoPhieuN = 2,
                    MaHang = "HH2",
                    SLNhap = "100",
                    DGNhap = "50000",
                };
   

                context.NhapKho_CTs.Add(nkct1);
                context.NhapKho_CTs.Add(nkct2);
                context.NhapKhos.Add(nk1);
                context.NhapKhos.Add(nk2);
               

                context.SaveChanges();
            }


        }


    }
}