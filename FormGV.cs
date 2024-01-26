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
using System.Xml.Linq;

namespace Tuan_1
{
    public partial class FormGV : Form
    {
        public FormGV()
        {
            InitializeComponent();
        }
        SqlConnection conn = new
        SqlConnection(Properties.Settings.Default.cnnStr);
        string sql = string.Format("SELECT * FROM GiaoVien");
       
        DataBase data = new DataBase();

        public void clear()
        {
            txtName.Clear();
            txtCCCD.Clear();
            txtAddress.Clear();
            dtpNgaySinh.Text=DateTime.Now.ToString();
        }
        private void FormGV_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                data.getdata(sql, gvGvien);
            }
            catch {
                MessageBox.Show("Loi");
            }
            finally { conn.Close(); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GiaoVien gv = new GiaoVien();
            gv.Hoten = txtName.Text;
            gv.Diachi = txtAddress.Text;
            gv.Cccd = txtCCCD.Text;
            gv.Ngaysinh = dtpNgaySinh.Text;

            GiaoVienDAO gvDAO = new GiaoVienDAO();

            if (gvDAO.them(gv))
            {
                data.getdata(sql, gvGvien);
                MessageBox.Show("thêm thành công");
                clear();
            }
            else
                MessageBox.Show("loi");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            GiaoVien gv = new GiaoVien();
            gv.Hoten = txtName.Text;
            gv.Diachi = txtAddress.Text;
            gv.Cccd = txtCCCD.Text;
            gv.Ngaysinh = dtpNgaySinh.Text;

            GiaoVienDAO gvDAO = new GiaoVienDAO();

            if (gvDAO.sua(gv))
            {
                data.getdata(sql, gvGvien);
                MessageBox.Show("sửa thành công");
                clear();
            }
            else
                MessageBox.Show("loi");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           

            GiaoVienDAO gvDAO = new GiaoVienDAO();

            if (gvDAO.xoa(txtCCCD.Text))
            {
                data.getdata(sql, gvGvien);
                MessageBox.Show("xoá thành công");
                clear();
            }
            else
                MessageBox.Show("loi");
        }

        private void gvGvien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtName.Text = gvGvien.Rows[i].Cells[0].Value.ToString();
            txtAddress.Text = gvGvien.Rows[i].Cells[1].Value.ToString();
            txtCCCD.Text = gvGvien.Rows[i].Cells[2].Value.ToString();
            dtpNgaySinh.Text = gvGvien.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
