using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thi.Models
{
    public class CongNhanModel
    {
        private string maCongNhan;
        private string tenCongNhan;
        private int gioiTinh;
        private int namSinh;
        private string nuocVe;
        private string maDiemCachLy;
        public CongNhanModel()
        {
        }
        public CongNhanModel(string maCongNhan, string tenCongNhan, int gioiTinh, string nuocVe,int namSinh, string maDiemCachLy)
        {
            this.maCongNhan = maCongNhan;
            this.tenCongNhan = tenCongNhan;
            this.gioiTinh = gioiTinh;
            this.nuocVe = nuocVe;
            this.namSinh = namSinh;
            this.maDiemCachLy = maDiemCachLy;

        }

        public string MaCongNhan { get => maCongNhan; set => maCongNhan = value; }
        public string TenCongNhan { get => tenCongNhan; set => tenCongNhan = value; }
        public int NamSinh { get => namSinh; set => namSinh = value; }
        public string NuocVe { get => nuocVe; set => nuocVe = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string MaDiemCachLy { get => maDiemCachLy; set => maDiemCachLy = value; }
    }
}
