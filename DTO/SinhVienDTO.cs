using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVienDTO
    {
        public int ID { get; set; }
        public string MSSV { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string MaLop { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
    }
}
