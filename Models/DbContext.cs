using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thi.Models
{
    public class DbContext
    {
        public string ConnectionString { get; set; }

        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // Them Diem Cach Ly

        public int Create(DiemCachLyModel DCL)
        {
            int count = 0;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
               
                var query = "insert into DiemCachLy values(@maDiemCachLy, @tenDiemCachLy, @diaChi)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("maDiemCachLy", DCL.MaDiemCachLy.ToString());
                cmd.Parameters.AddWithValue("tenDiemCachLy", DCL.TenDiemCachLy.ToString());
                cmd.Parameters.AddWithValue("diaChi", DCL.DiaChi.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        // Liet ke 
        public List<object> Show(int soTrieuChung)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var query = "select CN.MaCongNhan, CN.TenCongNhan, CN.NamSinh,CN.NuocVe,count(*) as SoTrieuChung from CongNhan " +
                    "CN join CN_TC TC on CN.MaCongNhan= TC.MaCongNhan group by CN.MaCongNhan,CN.TenCongNhan,CN.NamSinh,CN.NuocVe having count(*)>= @So ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@So", soTrieuChung);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new 
                        {
                            TenCongNhan = reader["tenCongNhan"].ToString(),
                            NamSinh = Convert.ToInt32(reader["namSinh"]),
                            NuocVe = reader["nuocVe"].ToString(),
                            SoTrieuChung = Convert.ToInt32(reader["soTrieuChung"])
                        });

                    }
                }
            }
            return list;
            }


            // Liet ke diem cach ly
            public List<DiemCachLyModel> getDiemCachLy()
            {
                List<DiemCachLyModel> list = new List<DiemCachLyModel>();
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    var query = "select maDiemCachly, tenDiemCachLy from diemcachly";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DiemCachLyModel()
                            {
                                MaDiemCachLy = reader["madiemcachly"].ToString(),
                                TenDiemCachLy = reader["tendiemcachly"].ToString()
                            });

                        }
                    }
                }
                return list;
            }
            //lay cong nhan theo diem cach ly
            public List<CongNhanModel> getCNCL(string maDiemCachLy)
            {
                List<CongNhanModel> list = new List<CongNhanModel>();
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    var query = "select maCongNhan, tenCongNhan, maDiemCachLy from congnhan " +
                                "where maDiemCachLy=@madiemcachly";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@madiemcachly", maDiemCachLy);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new CongNhanModel()
                            {
                                MaCongNhan = reader["macongnhan"].ToString(),
                                TenCongNhan = reader["tencongnhan"].ToString()
                            });
                        }
                    }
                }
                return list;
            }

            public List<CongNhanModel> getCN(string maDiemCachLy)
            {
                List<CongNhanModel> list = new List<CongNhanModel>();
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    var query = "select maCongNhan, tenCongNhan, gioiTinh, namSinh, nuocVe from congnhan " +
                                "where maDiemCachLy=@madiemcachly";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@madiemcachly", maDiemCachLy);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new CongNhanModel()
                            {
                                MaCongNhan = reader["macongnhan"].ToString(),
                                TenCongNhan = reader["tencongnhan"].ToString(),
                                GioiTinh = Convert.ToInt32(reader["gioitinh"].ToString()),
                                NamSinh = Convert.ToInt32(reader["namsinh"].ToString()),
                                NuocVe = reader["nuocve"].ToString()
                            });


                        }
                    }
                }
                return list;
            }
            public int DeleteCN(string MaCongNhan, CongNhanModel cn)
            {
                int count = 0;
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    var query = "delete from congnhan where macongnhan = @macongnhan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@macongnhan", cn.MaCongNhan);
                    cmd.ExecuteNonQuery();
                    count++;
                }
                return count;
            }

            public CongNhanModel DetailCN(string macongnhan)
            {
                CongNhanModel cn = new CongNhanModel();
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    var query = "select * from congnhan where maCongNhan=@macongnhan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@macongnhan", macongnhan);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cn.MaCongNhan = reader["macongnhan"].ToString();
                            cn.TenCongNhan = reader["tencongnhan"].ToString();
                            cn.GioiTinh = Convert.ToInt32(reader["gioitinh"].ToString());
                            cn.NamSinh = Convert.ToInt32(reader["namsinh"].ToString());
                            cn.NuocVe = reader["nuocve"].ToString();
                            cn.MaDiemCachLy = reader["madiemcachly"].ToString();
                        }
                        reader.Close();
                    }
                    conn.Close();
                }
                return cn;
            }

    }
}
