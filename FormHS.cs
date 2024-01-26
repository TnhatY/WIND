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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Tuan_1
{
    public partial class FormHS : Form
    {
        public FormHS()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        
        string sql = string.Format("SELECT *FROM HocSinhh");
        DataBase data = new DataBase();
        HocSinhDAO hsDAO = new HocSinhDAO();
        public void clear()
        {
            txtName.Clear();
            txtCCCD.Clear();
            txtAddress.Clear();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                data.getdata(sql,gvHsinh);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gioiTinh = "";
            if (rdBNam.Checked)
                gioiTinh = "Nam";
            else if (rdBNu.Checked)
                gioiTinh = "Nữ";
            else
            {
                MessageBox.Show("Vui long chon gioi tinh");
                return;
            }
            HocSinh hs = new HocSinh(
            txtName.Text,
            txtAddress.Text,
            txtCCCD.Text,
            dtpNgaySinh.Text,
            gioiTinh,
            txtEmail.Text,
            int.Parse(txtPhone.Text), 
            txtId.Text,
            double.Parse(txtDiem.Text));
            
            if (hsDAO.them(hs))
            {
                data.getdata(sql, gvHsinh);
                MessageBox.Show("thêm thành công");
                clear();
            } 
            else
                MessageBox.Show("loi");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh();
            hs.Hoten = txtName.Text;
            hs.Diachi = txtAddress.Text;
            hs.Cccd = txtCCCD.Text;
            hs.Ngaysinh = dtpNgaySinh.Text;

            if (hsDAO.sua(hs))
            {
                data.getdata(sql, gvHsinh);
                MessageBox.Show("sửa thành công");
                clear();
            }
            else
                MessageBox.Show("loi");

        }

        private void gvHsinh_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvHsinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtName.Text = gvHsinh.Rows[i].Cells["Ten"].Value.ToString();
                txtAddress.Text = gvHsinh.Rows[i].Cells["DiaChi"].Value.ToString();
                txtCCCD.Text = gvHsinh.Rows[i].Cells["Cmnd"].Value.ToString();
                dtpNgaySinh.Text = gvHsinh.Rows[i].Cells["NgaySinh"].Value.ToString();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //string sql = string.Format("DELETE FROM HocSinhh WHERE Cmnd = '{0}'", txtCCCD.Text);
            if (hsDAO.xoa(txtCCCD.Text))
            {
                data.getdata(sql, gvHsinh);
                MessageBox.Show("xoá thành công");
                clear();
            }
            else
                MessageBox.Show("loi");

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGiaoVien_Click(object sender, EventArgs e)
        {
            FormGV f = new FormGV();
            f.ShowDialog();
        }
    }
}
