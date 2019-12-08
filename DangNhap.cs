using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLCB
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            // SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T7VOT5C\SQLEXPRESS;Initial Catalog=QuanLiChuyenBay;Integrated Security=True");
            //try
            //{
            //    conn.Open();
            //    string tk = txtTaiKhoan.Text;
            //    string mk = txtMatKhau.Text;
            //    string sql = "select * from NguoiDung where TaiKhoan='" + tk + "' and MatKhau='" + mk + "'";
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    SqlDataReader dta = cmd.ExecuteReader();
            //    if (dta.Read() == true)
            //    {
            //        MessageBox.Show("Đăng nhập thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //        ManHinhChinh.login = true;
            //        Form main = new ManHinhChinh();
            //        this.Hide();
            //        main.ShowDialog();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Đăng nhập thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(" Lỗi kết nối");
            //}
        }

        private void bntExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        
    }
    
    
}
