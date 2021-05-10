using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class SinhVienBUS
    {

        private SinhVienDAO _SinhVienDAO = new SinhVienDAO();

        public List<SinhVienDTO> LayDSSinhVien()
        {
            return _SinhVienDAO.LayDSSinhVien();
        }


    }
}
