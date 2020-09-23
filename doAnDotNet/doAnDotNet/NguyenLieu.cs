using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace doAnDotNet
{
    public class NguyenLieu
    {
        public int _maNL;
        public int _maNCC;
        public int _klton;
        //public string _hinh;
        public string _tenNL;
        public string _dvt;
        public int maNL
        {
            get { return _maNL; }
            set { _maNL = value; }
        }
        public int maNCC
        {
            get { return _maNCC; }
            set { _maNCC = value; }
        }
        public int KLTon
        {
            get { return _klton; }
            set { _klton = value; }
        }
        //public string hinh
        //{
        //    get { return _hinh; }
        //    set { _hinh = value; }
        //}
        public string tenNL
        {
            get { return _tenNL; }
            set { _tenNL = value; }
        }
        public string DVT
        {
            get { return _dvt; }
            set { _dvt = value; }
        }
        public NguyenLieu()
        {
        }
        public NguyenLieu(int maNL, string tenNL, string dvt, int maNCC, int klton)
        {
            _maNL = maNL;
            _tenNL = tenNL;
            _dvt = dvt;
            _maNCC = maNCC;
            _klton = klton;
            //_hinh = hinh;
            
        }
        public NguyenLieu(DataRow row)
        {
            this.maNL = (int)row["MaNL"];
            this.tenNL = row["TenNL"].ToString();
            this.maNCC = (int)row["MaNCC"];
            this.DVT = row["DVT"].ToString();
            this.KLTon = (int)row["KLTon"];
            //if (row["HinhAnh"] != null || row["HinhAnh"].ToString()!="")
            //    this.hinh = row["HinhAnh"].ToString();
            
        }
    }
}
