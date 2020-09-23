using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace doAnDotNet
{
    public class NguoiDung
    {
        public string _tenDN;
        public string _pass;
        public string _hd;
        public string tenDN
        {
            get { return _tenDN; }
            set { _tenDN = value; }
        }
        public string pass
        {
            get { return _pass; }
            set { _pass = value; }
        }
        public string hd
        {
            get { return _hd; }
            set { _hd = value; }
        }
        public NguoiDung()
        {
        }
        public NguoiDung(DataRow row)
        {
            this.tenDN = row["TenDangNhap"].ToString();
            this.pass = row["MatKhau"].ToString();
            if (row["HoatDong"] != null || row["HoatDong"].ToString()!="")
                this.hd = row["HoatDong"].ToString();
        }
        public NguoiDung(string t, string p, string h=null)
        {
            _tenDN = t;
            _pass = p;
            _hd = h;
        }
    }
}
