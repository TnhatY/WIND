using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tuan_1
{
    internal class HocSinhDAO 
    {
        public DataBase data = new DataBase();
        public bool them(HocSinh hs)
        {

            string sql = string.Format("INSERT INTO HocSinhh(Ten , Diachi, Cmnd,NgaySinh,Gioitinh,Email,Phone,Id,Diem ) " +
               "VALUES ('{0}', '{1}', '{2}','{3}','{4}', '{5}', '{6}','{7}','{8}')",
                   hs.Hoten, hs.Diachi, hs.Cccd, hs.Ngaysinh, hs.Gioitinh, hs.Email, hs.Phone, hs.Id, hs.Diem);
            if (data.thucThi(sql))
                return true;
            return false;

        }

        public bool sua(HocSinh hs)
        {
            
            string sql = string.Format("UPDATE HocSinhh SET Ten = '{0}', DiaChi = '{1}',NgaySinh='{2}' WHERE Cmnd = {3}",
                hs.Hoten, hs.Diachi, hs.Ngaysinh, hs.Cccd);

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
