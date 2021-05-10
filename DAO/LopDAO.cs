using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class LopDAO
    {
        private static string _connectionString = @"Data Source=LAPTOP-N8JTJPCC\MSSQLSERVER02;Initial Catalog=QLSinhVien;Integrated Security=True";

        private SqlConnection _conn = new SqlConnection(_connectionString);

        public List<LopDTO> LayDSLop()
        {
            List<LopDTO> lstLop = new List<LopDTO>();

            _conn.Open();

            string sql = "SELECT * FROM Lop";

            SqlCommand cmd = new SqlCommand(sql, _conn);

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    LopDTO lop = new LopDTO
                    {
                        MaLop = sdr.GetString(0),
                        TenLop = sdr.GetString(1)
                    };

                    lstLop.Add(lop);
                }
            }

            _conn.Close();

            return lstLop;
        }
    }
}
