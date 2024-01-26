using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1
{
    internal class People
    {
        DataBase dt = new DataBase();
        private string hoten;
        private string diachi;
        private string cccd;
        private string ngaysinh;
        private string email;
        private int phone;
        private string id;
        private string gioitinh;

        public string Hoten { get => hoten; set => hoten = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public string Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Email { get => email; set => email = value; }
        public int Phone { get => phone; set => phone = value; }
        public string Id { get => id; set => id = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }

        public People() { }

        public People(string _hoten, string _diachi, string _cccd, string _ngaySinh, string _gioitinh, string _email, int _phone, string _id)
        {
            hoten = _hoten;
            diachi = _diachi;
            cccd = _cccd;
            ngaysinh = _ngaySinh;
            gioitinh = _gioitinh;
            email = _email;
            phone = _phone;
            id = _id;
        }
       
    }
}
