using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thi.Models
{
    public class CN_TC
    {
        private string maCongNhan;
        private string maTrieuChung;
        public CN_TC()
        {
        }

        public CN_TC(string maCongNhan, string maTrieuChung)
        {
            this.maCongNhan = maCongNhan;
            this.maTrieuChung = maTrieuChung;
        }

        public string MaCongNhan { get => maCongNhan; set => maCongNhan = value; }
        public string MaTrieuChung { get => maTrieuChung; set => maTrieuChung = value; }
    }
}
