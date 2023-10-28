using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormProject3.Models
{
    public class Data
    {
        private int? _seq;
        private DateTime? _cDate;
        private DateTime? _mDate;
        private DateTime? _dDate;

        public int? Seq
        {
            get { return _seq; }
            protected set
            {
                if (value != null && value < 1) throw new ArgumentException("Seq는 0 이하일 수 없습니다.");
                _seq = value;
            }
        }
        public DateTime? CDate
        {
            get { return _cDate; }
            protected set
            {
                if (value != null && DateTime.Compare((DateTime)value, DateTime.Now) > 0) throw new ArgumentException("생성 일자는 현재 이후일 수 없습니다.");
                _cDate = value;
            }
        }
        public DateTime? MDate
        {
            get { return _mDate; }
            set
            {
                if (value != null && DateTime.Compare((DateTime)value, DateTime.Now) > 0) throw new ArgumentException("수정 일자는 현재 이후일 수 없습니다.");
                _mDate = value;
            }
        }
        public DateTime? DDate
        {
            get { return _dDate; }
            set
            {
                if (value != null && DateTime.Compare((DateTime)value, DateTime.Now) > 0) throw new ArgumentException("삭제 일자는 현재 이후일 수 없습니다.");
                _dDate = value;
            }
        }

        protected Data() { }
    }
}