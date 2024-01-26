using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1
{
    internal class GiaoVienDAO 
    {
        public DataBase data = new DataBase();
        public bool them(GiaoVien gv)
        {

            string sql = string.Format("INSERT INTO GiaoVien(hoTen , diaChi, cccd,ngaySinh ) VALUES ('{0}', '{1}', '{2}','{3}')",
                gv.Hoten, gv.Diachi, gv.Cccd, gv.Ngaysinh);
            if (data.thucThi(sql))
                return true;
            return false;
        }
        public bool sua(GiaoVien gv)
        {
            string sql = string.Format("UPDATE GiaoVien SET hoTen = '{0}', diaChi = '{1}',ngaySinh='{2}' WHERE cccd = {3}",
                gv.Hoten, gv.Diachi, gv.Ngaysinh, gv.Cccd);
            if (data.thucThi(sql))
                return true;
            return false;
        }
        public bool xoa(string cccd)
        {
            string sql = $"DELETE FROM GiaoVien WHERE cccd = {cccd}";

            if (data.thucThi(sql))
                return true;
            return false;
        }
    }
}
