using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLCB

{
    public class Connect
    {
        public string Stringconnect = "";
        static SqlConnection cnn;
        static SqlDataAdapter da;
        static DataSet ds;
        static SqlCommand cmd;
        static string source;
        private DataTable dt;
        public static void openConnection()
        {
            source = @"Data Source=DESKTOP-T7VOT5C\SQLEXPRESS;Initial Catalog=QuanLiChuyenBay;Integrated Security=True";
            cnn = new SqlConnection(source);
            try
            {
                cnn.Open();
            }
            catch
            {
                MessageBox.Show("Lỗi", "Không thể kết nối đến cơ sở dữ liệu!!");
                return;
            }
        }
        public static void executeQuery(String sql)
        {
            cmd = new SqlCommand();
            openConnection();
            try
            {
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi dữ liệu:" + ex.Message);
                return;
            }

        }
        

        public static DataSet getDataSet(String sql)
        {

            openConnection();
            da = new SqlDataAdapter(sql, cnn);
            ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds;
        }

        public static DataTable getDataTable(String sql)
        {
            openConnection();
            da = new SqlDataAdapter(sql, cnn);
            ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds.Tables[0];
        }

        public void showCombobox(ComboBox cbb, string TenTable,string displayMember, string valueMember)
        {
            cnn.Open();
            cmd = new SqlCommand(" select * from " + TenTable , cnn);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);

            cbb.DataSource = table;
            cbb.DisplayMember = displayMember;
            cbb.ValueMember = valueMember;
            cbb.SelectedIndex = -1;
            cnn.Close();
        }


        public SqlCommand add_khachhang(string MaKH,string TenKH,string DiaChi, string Sdt)
        {
            cnn.Open();
            cmd = new SqlCommand("add_khachhang", cnn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang",MaKH));
            cmd.Parameters.Add(new SqlParameter("@tenkhachhang", TenKH));
            cmd.Parameters.Add(new SqlParameter("@diachi", DiaChi));
            cmd.Parameters.Add(new SqlParameter("@sdt", Sdt));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return cmd;
        }
        public SqlCommand modify_khachhang(string MaKH, string TenKH, string DiaChi, string Sdt)
        {
            cnn.Open();
            cmd = new SqlCommand("modify_khachhang", cnn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", MaKH));
            cmd.Parameters.Add(new SqlParameter("@tenkhachhang", TenKH));
            cmd.Parameters.Add(new SqlParameter("@diachi", DiaChi));
            cmd.Parameters.Add(new SqlParameter("@sdt", Sdt));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return cmd;
        }
        public SqlCommand delete_khachhang(string MaKH)
        {
            cnn.Open();
            cmd = new SqlCommand("delete_khachhang", cnn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", MaKH));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return cmd;
        }

        public SqlCommand add_nhanvien(string MaNV,string TenNV, string DiaChiNV,string SdtNV, string Luong)
        {
            cnn.Open();
            cmd = new SqlCommand("add_nhanvien", cnn);
            cmd.Parameters.Add(new SqlParameter("@manhanvien", MaNV));
            cmd.Parameters.Add(new SqlParameter("@tennhanvien", TenNV));
            cmd.Parameters.Add(new SqlParameter("@diachinhanvien", DiaChiNV));
            cmd.Parameters.Add(new SqlParameter("@sdtnhanvien", SdtNV));
            cmd.Parameters.Add(new SqlParameter("@luong", Luong));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return cmd;
        }

        public SqlCommand modify_nhanvien(string MaNV, string TenNV, string DiaChiNV, string SdtNV, string Luong)
        {
            cnn.Open();
            cmd = new SqlCommand("modify_nhanvien", cnn);
            cmd.Parameters.Add(new SqlParameter("@manhanvien", MaNV));
            cmd.Parameters.Add(new SqlParameter("@tennhanvien", TenNV));
            cmd.Parameters.Add(new SqlParameter("@diachinhanvien", DiaChiNV));
            cmd.Parameters.Add(new SqlParameter("@sdtnhanvien", SdtNV));
            cmd.Parameters.Add(new SqlParameter("@luong", Luong));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return cmd;
        }

        public SqlCommand delete_nhanvien(string MaNV)
        {
            cnn.Open();
            cmd = new SqlCommand("delete_nhanvien", cnn);
            cmd.Parameters.Add(new SqlParameter("@manhanvien", MaNV));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return cmd;
        }

        public DataTable search_khachhang( string ChuoitimkiemKH)
        {
            dt = new DataTable();
            cnn.Open();
            cmd = new SqlCommand("search_khachhang", cnn);
            cmd.Parameters.Add(new SqlParameter("@chuoitimkiemkhachhang", ChuoitimkiemKH));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public DataTable search_nhanvien(string ChuoitimkiemNV)
        {
            dt = new DataTable();
            cnn.Open();
            cmd = new SqlCommand("search_nhanvien", cnn);
            cmd.Parameters.Add(new SqlParameter("@chuoitimkiemnhanvien", ChuoitimkiemNV));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public DataTable checked_khachhang(string MaKH)
        {
            dt = new DataTable();
            cnn.Open();
            cmd = new SqlCommand("checked_khachhang", cnn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", MaKH));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public DataTable checked_nhanvien(string MaNV)
        {
            dt = new DataTable();
            cnn.Open();
            cmd = new SqlCommand("checked_nhanvien", cnn);
            cmd.Parameters.Add(new SqlParameter("@manhanvien", MaNV));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public SqlCommand add_chuyenbay(string MaCB, string SBDi, string SBDen, string GioDi, string GioDen)
        {
            cnn.Open();
            cmd = new SqlCommand("add_chuyenbay", cnn);
            cmd.Parameters.Add(new SqlParameter("@machuyenbay", MaCB));
            cmd.Parameters.Add(new SqlParameter("@sanbaydi",SBDi ));
            cmd.Parameters.Add(new SqlParameter("@sanbayden",SBDen ));
            cmd.Parameters.Add(new SqlParameter("@giodi",GioDi ));
            cmd.Parameters.Add(new SqlParameter("@gioden",GioDen ));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return cmd;
        }

        public SqlCommand modify_chuyenbay(string MaCB, string SBDi, string SBDen, string GioDi, string GioDen)
        {
            cnn.Open();
            cmd = new SqlCommand("modify_chuyenbay", cnn);
            cmd.Parameters.Add(new SqlParameter("@machuyenbay", MaCB));
            cmd.Parameters.Add(new SqlParameter("@sanbaydi", SBDi));
            cmd.Parameters.Add(new SqlParameter("@sanbayden", SBDen));
            cmd.Parameters.Add(new SqlParameter("@giodi", GioDi));
            cmd.Parameters.Add(new SqlParameter("@gioden", GioDen));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return cmd;
        }

        public SqlCommand delete_chuyenbay(string MaCB)
        {
            cnn.Open();
            cmd = new SqlCommand("delete_chuyenbay", cnn);
            cmd.Parameters.Add(new SqlParameter("@machuyenbay", MaCB));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return cmd;
        }

        public DataTable search_chuyenbay(string ChuoitimkiemCB)
        {
            dt = new DataTable();
            cnn.Open();
            cmd = new SqlCommand("search_chuyenbay", cnn);
            cmd.Parameters.Add(new SqlParameter("@chuoitimkiemchuyenbay", ChuoitimkiemCB));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cnn.Close();
            return dt;
        }



        public DataTable search_lichbay(string NgayDi, string MaCB, string SoHieu, string MaLoai)
        {
            dt = new DataTable();
            cnn.Open();
            cmd = new SqlCommand("search_LichBay", cnn);
            cmd.Parameters.Add(new SqlParameter("@ngaydi", NgayDi));
            cmd.Parameters.Add(new SqlParameter("@machuyenbay", MaCB));
            cmd.Parameters.Add(new SqlParameter("@sohieu", SoHieu));
            cmd.Parameters.Add(new SqlParameter("@maloai", MaLoai));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public DataTable search_datcho(string MaKH,string NgayDi, string MaCB)
        {
            dt = new DataTable();
            cnn.Open();
            cmd = new SqlCommand("search_datcho", cnn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", MaKH));
            cmd.Parameters.Add(new SqlParameter("@ngaydi", NgayDi));
            cmd.Parameters.Add(new SqlParameter("@machuyenbay", MaCB));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

    }


}
