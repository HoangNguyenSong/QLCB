using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCB
{
    public partial class ManHinhChinh : Form
    {
        Connect connection = new Connect();
        public ManHinhChinh()
        {
            InitializeComponent();
        }

        
        public void Load_dataKH()
        {
            string load = "select * from KHACHHANG";
            DataTable dt = Connect.getDataTable(load);
            dgvKhachHang.DataSource = dt;
        }

        public void Load_dataNV()
        {
            string load = "select * from NHANVIEN";
            DataTable dt = Connect.getDataTable(load);
            dgvNhanVien.DataSource = dt; 
        }

        public void Load_dataDatCho()
        {
            string load = "select * from DATCHO";
            DataTable dt = Connect.getDataTable(load);
            dgvDatCho.DataSource = dt;

        }

        public void Load_dataLichBay()
        {
            string load = "select * from LICHBAY";
            DataTable dt = Connect.getDataTable(load);
            dgvLichBay.DataSource = dt;
        }

        public void Load_dataCB()
        {
            string data = "select * from selectCB";            
            dgvCB.DataSource = Connect.getDataTable(data);

        }
        

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            this.Load_dataKH();
            this.Load_dataNV();
            this.Load_dataCB();
            this.Load_dataDatCho();
            this.Load_dataLichBay();
            

            connection.showCombobox(cbbSBDi, "SANBAY", "TENSB", "MASB");
            connection.showCombobox(cbbSBDen, "SANBAY", "TENSB","MASB");
            connection.showCombobox(cbbGioDi, "CHUYENBAY", "GIODI","GIODI");
            connection.showCombobox(cbbGioDen, "CHUYENBAY", "GIODEN","GIODEN");
            connection.showCombobox(cbbMaLoai, "LOAIMB", "MALOAI", "MALOAI");
        }

        private void btnAddKH_Click(object sender, EventArgs e)
        {
            if (connection.checked_khachhang(txtMaKH.Text).Rows.Count > 0)
            {
                MessageBox.Show(" Mã khách hàng này đã tồn tại!");
                dgvKhachHang.DataSource = connection.checked_khachhang(txtMaKH.Text);
                return;
            }
            connection.add_khachhang(txtMaKH.Text, txtTenKH.Text, txtDiaChiKH.Text, txtSdtKH.Text);
            Load_dataKH();
        }


        private void btnModifyKH_Click(object sender, EventArgs e)
        {
            connection.modify_khachhang(txtMaKH.Text, txtTenKH.Text, txtDiaChiKH.Text, txtSdtKH.Text);
                Load_dataKH();
        }

        private void btnDeleteKH_Click(object sender, EventArgs e)
        {
            connection.delete_khachhang(txtMaKH.Text);
            Load_dataKH();
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            if (connection.checked_nhanvien(txtMaNV.Text).Rows.Count > 0)
            {
                MessageBox.Show(" Mã nhân viên này đã tồn tại!");
                dgvNhanVien.DataSource = connection.checked_nhanvien(txtMaNV.Text);
                return;
            }
            connection.add_nhanvien(txtMaNV.Text, txtTenNV.Text, txtDiaChiNV.Text, txtSdtNV.Text,txtLuongNV.Text);
            Load_dataNV();
        }

        private void btnModifyNV_Click(object sender, EventArgs e)
        {
            connection.modify_nhanvien(txtMaNV.Text, txtTenNV.Text, txtDiaChiNV.Text, txtSdtNV.Text, txtLuongNV.Text);
            Load_dataNV();
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            connection.delete_nhanvien(txtMaNV.Text);
            Load_dataNV();
        }

        private void txtTimKiemKH_TextChanged(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = connection.search_khachhang(txtTimKiemKH.Text);
        }

        private void txtTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = connection.search_nhanvien(txtTimKiemNV.Text);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaKH.Text = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            txtDiaChiKH.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            txtSdtKH.Text = dgvKhachHang.Rows[r].Cells[3].Value.ToString();
        }

        private void dgvCB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaCB.Text = dgvCB.Rows[r].Cells[0].Value.ToString();
            cbbSBDi.Text = dgvCB.Rows[r].Cells[1].Value.ToString();
            cbbSBDen.Text = dgvCB.Rows[r].Cells[2].Value.ToString();
            cbbGioDi.SelectedValue = dgvCB.Rows[r].Cells[3].Value;
            cbbGioDen.SelectedValue = dgvCB.Rows[r].Cells[4].Value;
            //DataGridViewRow row = new DataGridViewRow();
            //row = dgvCB.Rows[e.RowIndex];
            //txtMaCB.Text = row.Cells[0].Value.ToString();
            //cbbSBDi.Text = row.Cells[1].Value.ToString();
            //cbbSBDen.Text = row.Cells[2].Value.ToString();
            //cbbGioDi.SelectedValue = row.Cells[3].Value;
            //cbbGioDen.SelectedValue = row.Cells[4].Value;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            txtDiaChiNV.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            txtSdtNV.Text = dgvNhanVien.Rows[r].Cells[3].Value.ToString();
            txtLuongNV.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
        }

        private void dgvLichBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            dtpNgaydiLB.Text = dgvLichBay.Rows[r].Cells[0].Value.ToString();
            txtMaCBLB.Text = dgvLichBay.Rows[r].Cells[1].Value.ToString();
            txtSoHieu.Text = dgvLichBay.Rows[r].Cells[2].Value.ToString();
            cbbMaLoai.SelectedValue = dgvLichBay.Rows[r].Cells[3].Value.ToString();
        }

        private void dgvDatCho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaKHDC.Text = dgvDatCho.Rows[r].Cells[0].Value.ToString();
            dtpNgaydiDC.Text = dgvDatCho.Rows[r].Cells[1].Value.ToString();
            txtMaCBDC.Text = dgvDatCho.Rows[r].Cells[2].Value.ToString();
        }

        private void txtTimKiemCB_TextChanged(object sender, EventArgs e)
        {
            dgvCB.DataSource = connection.search_chuyenbay(txtTimKiemCB.Text);
        }

        private void btnAddCB_Click(object sender, EventArgs e)
        {
            connection.add_chuyenbay(txtMaCB.Text, cbbSBDi.SelectedValue.ToString(), cbbSBDen.SelectedValue.ToString(), cbbGioDi.SelectedValue.ToString(), cbbGioDen.SelectedValue.ToString());
            Load_dataCB();
        }

        private void btnModifyCB_Click(object sender, EventArgs e)
        {
            connection.modify_chuyenbay(txtMaCB.Text, cbbSBDi.SelectedValue.ToString(), cbbSBDen.SelectedValue.ToString(), cbbGioDi.SelectedValue.ToString(), cbbGioDen.SelectedValue.ToString());
            Load_dataCB();
        }

        private void btnDeleteCB_Click(object sender, EventArgs e)
        {
            connection.delete_chuyenbay(txtMaCB.Text);
            Load_dataCB();
        }
        
        private void btnSearchLB_Click(object sender, EventArgs e)
        { 
            DateTime day= dtpNgaydiLB.Value;
            string formatday = day.Year + "-" + day.Month + "-" + day.Day;
            dgvLichBay.DataSource= connection.search_lichbay(formatday, txtMaCBLB.Text, txtSoHieu.Text, cbbMaLoai.SelectedValue.ToString());

        }

        private void btnSearchDC_Click(object sender, EventArgs e)
        {
            DateTime day = dtpNgaydiDC.Value;
            string formatday = day.Year + "-" + day.Month + "-" + day.Day;
            dgvDatCho.DataSource = connection.search_datcho(txtMaKHDC.Text, formatday, txtMaCBDC.Text);
        }
    }
}
