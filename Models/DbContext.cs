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

            
        }
}
