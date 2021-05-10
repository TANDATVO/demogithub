using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class LopBUS
    {
        private LopDAO _lopDAO = new LopDAO();

        public List<LopDTO> LayDSLop()
        {
            return _lopDAO.LayDSLop();
        }
    }
}
