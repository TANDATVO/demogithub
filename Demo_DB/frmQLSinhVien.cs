using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_DB
{
    public partial class frmQLSinhVien : Form
    {
        private static string _connectionString = @"Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True";

        private SqlConnection _conn = new SqlConnection(_connectionString);

        private LopBUS _lopBUS = new LopBUS();
        private SinhVienBUS _sinhvienBUS = new SinhVienBUS();

        public frmQLSinhVien()
        {
            InitializeComponent();

            // Đổ dữ liệu vào combobox
            cbbLop.DataSource = _lopBUS.LayDSLop();
            cbbLop.DisplayMember = "TenLop";
            cbbLop.ValueMember = "MaLop";
        }

        private void frmQLSinhVien_Load(object sender, EventArgs e)
        {
            // Đổ dữ liệu vào DataGridView
            Lop.DataSource = _lopBUS.LayDSLop();
            Lop.DisplayMember = "TenLop";
            Lop.ValueMember = "MaLop";

            dgvSinhVien.DataSource = _sinhvienBUS.LayDSSinhVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin nhân viên đã nhập
            if (txtMSSV.Text == String.Empty || txtHo.Text == String.Empty || txtTen.Text == String.Empty ||
                txtDiaChi.Text == String.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //kiểm tra MSSV không được trùng
           
                if (true)
                {
                    string sqlInsert = @"INSERT INTO SinhVien(MSSV,Ho,Ten,MaLop,NgaySinh,DiaChi,TrangThai)
                                 VALUES (@mssv,@ho,@ten,@malop,@ngaysinh,@diachi,1)";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@mssv", txtMSSV.Text));
                    parameters.Add(new SqlParameter("@ho", txtHo.Text));
                    parameters.Add(new SqlParameter("@ten", txtTen.Text));
                    parameters.Add(new SqlParameter("@malop", cbbLop.SelectedValue));
                    parameters.Add(new SqlParameter("@ngaysinh", dtpNgaySinh.Value));
                    parameters.Add(new SqlParameter("@diachi", txtDiaChi.Text));

                    _conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlInsert, _conn);
                    cmd.Parameters.AddRange(parameters.ToArray());
                    int count = cmd.ExecuteNonQuery();
                    _conn.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvSinhVien.DataSource = _sinhvienBUS.LayDSSinhVien();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm sinh viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtMSSV.Text)||(String.IsNullOrEmpty(txtHo.Text))||(String.IsNullOrEmpty(txtTen.Text))||dtpNgaySinh.Value >= DateTime.Now||(String.IsNullOrEmpty(txtDiaChi.Text)))
            {
             
            }
        }
        private bool KTmssv(string MSSV)
        {
            _conn.Open();
            string sqlFormat = "Select Count(*) from SinhVien where MSSV = '{0}'";
            string sql = String.Format(sqlFormat, MSSV);
            SqlCommand cmd = new SqlCommand(sql, _conn);
            object value = cmd.ExecuteScalar();

            _conn.Close();
            return Convert.ToInt32(value) > 0;
        }

    }
}
