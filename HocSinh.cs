using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Tuan_1
{
    internal class HocSinh : People
    {
        DataBase dt = new DataBase();
        private double diem;

        public double Diem { get => diem; set { } }

        public HocSinh() { }
        public HocSinh(string _hoten, string _diachi, string _cccd, string _ngaySinh, string _gioitinh, string _email, int _phone, string _id, double _diem)
            :base(_hoten,_diachi,_cccd, _ngaySinh,_gioitinh, _email,_phone,_id)
        {
            diem = _diem;
        }

       
    }
}
