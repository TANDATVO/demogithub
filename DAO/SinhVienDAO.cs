using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SinhVienDAO
    {
        private static string _connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True";

        private SqlConnection _conn = new SqlConnection(_connectionString);
        
        public List<SinhVienDTO> LayDSSinhVien()
        {
            List<SinhVienDTO> lstSinhVien = new List<SinhVienDTO>();

            _conn.Open();

            string sql = "SELECT * FROM SinhVien WHERE TrangThai = 1";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    SinhVienDTO sv = new SinhVienDTO
                    {
                        ID = sdr.GetInt32(0),
                        MSSV = sdr.GetString(1),
                        Ho = sdr.GetString(2),
                        Ten = sdr.GetString(3),
                        MaLop = sdr.GetString(4),
                        NgaySinh = sdr.GetDateTime(5),
                        DiaChi = sdr.GetString(6),
                    };

                    lstSinhVien.Add(sv);
                }
            }

            _conn.Close();

            return lstSinhVien;
        }
        private SinhVienDTO sv = new SinhVienDTO();
        public bool XoaSV(string mssv)
        {
            string sqlUpdate = "UPDATE SinhVien SET TrangThai = 0 WHERE MSSV = @MSSV";
            _conn.Open();
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@MSSV", sv.MSSV));

            lstParameter.AddRange(lstParameter.ToArray());
            return false;
        }
    }
}
