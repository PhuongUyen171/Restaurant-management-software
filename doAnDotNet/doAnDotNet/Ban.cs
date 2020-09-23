using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace doAnDotNet
{
    public class Ban
    {
        public int _maBan;
        public int _maKV;
        public int? _maPD;
        public string _tinhTrang;
        public int maBan
        {
            get { return _maBan; }
            set { _maBan = value; }
        }
        public int? maPD
        {
            get { return _maPD; }
            set { _maPD = value; }
        }
        public int maKV
        {
            get { return _maKV; }
            set { _maKV = value; }
        }
        public string tinhTrang
        {
            get { return _tinhTrang; }
            set { _tinhTrang = value; }
        }
        public Ban()
        {
        }
        public Ban(int b, int kv, int pd, string tt)
        {
            _maBan = b;
            _maKV = kv;
            _maPD = pd;
            _tinhTrang = tt;
        }
        public Ban(DataRow row)
        {
            maBan = (int)row["MaB"];
            maKV = (int)row["MaKV"];
            if(maPD!=null)
                maPD = (int?)row["MaPD"];
            tinhTrang = row["TinhTrang"].ToString();
        }
        
    }
}
