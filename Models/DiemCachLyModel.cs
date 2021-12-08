using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thi.Models
{
    public class DiemCachLyModel
    {
        private string maDiemCachLy;
        private string tenDiemCachLy;
        private string diaChi;
        public DiemCachLyModel()
        {
        }

        public DiemCachLyModel(string maDiemCachLy, string tenDiemCachLy, string diaChi)
        {
            this.maDiemCachLy = maDiemCachLy;
            this.tenDiemCachLy = tenDiemCachLy;
            this.diaChi = diaChi;
        }

        public string MaDiemCachLy { get => maDiemCachLy; set => maDiemCachLy = value; }
        public string TenDiemCachLy { get => tenDiemCachLy; set => tenDiemCachLy = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
