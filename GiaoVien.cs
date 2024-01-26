using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1
{
    internal class GiaoVien : People
    {
        DataBase dt = new DataBase();
        public GiaoVien() { }
        public GiaoVien(string _hoten, string _diachi, string _cccd, string _ngaySinh, string _gioitinh, string _email, int _phone, string _id, double _diem)
            : base(_hoten, _diachi, _cccd, _ngaySinh, _gioitinh, _email, _phone, _id)
        {
            
        }
    }
}
