using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace WebFormProject3.Models
{
    public class User
    {
        private int? _seq;
        private string _name;
        private string _phone;
        private string _birthday;
        private DateTime _cDate;
        private DateTime? _mDate;
        private DateTime? _dDate;
        public int? Seq { get { return _seq; } }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null) throw new ArgumentException("이름은 null일 수 없습니다.");
                if (value.Length > 100) throw new ArgumentException("이름은 100자를 넘길 수 없습니다.");
                _name = value;
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value == null)
                {
                    _phone = string.Empty;
                    return;
                }

                string pattern = @"^\d{3,4}-\d{4}-\d{4}$";
                if (value?.Length > 14) throw new ArgumentException("휴대폰 번호는 14자를 넘길 수 없습니다.");
                if (!Regex.IsMatch(value, @"^\d{3,4}-\d{4}-\d{4}$")) throw new ArgumentException("휴대폰 번호의 형식에 맞지 않습니다. 형식: " + pattern);

                _phone = value;
            }
        }
        public string Birthday
        {
            get { return _birthday; }
            set
            {
                if (value == null) throw new ArgumentNullException("생년월일은 null일 수 없습니다.");

                string pattern = @"^\d{4}-\d{2}-\d{2}$";
                if (!Regex.IsMatch(value, pattern)) throw new ArgumentException("생년월일의 형식에 맞지 않습니다. 형식: " + pattern);

                string now = DateTime.Now.ToString("yyyy-MM-dd");
                if (string.Compare(value, now) > 0) throw new ArgumentException("생년월일은 현재 이후일 수 없습니다.");

                _birthday = value;
            }
        }
        public int Age
        {
            get
            {
                string[] birthdayArray = _birthday.Split(new char[] { '-' });
                int birthYear = int.Parse(birthdayArray[0]);
                int currentYear = DateTime.Now.Year;
                return currentYear - birthYear + 1;
            }
        }
        public DateTime CDate { get { return _cDate; } }
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

        private User(int? seq, DateTime cDate)
        {

            if (seq != null && seq < 1) throw new ArgumentException("PK는 0이하일 수 없습니다.");
            if (cDate == null) throw new ArgumentNullException("데이터 생성 일자는 null일 수 없습니다.");
            if (DateTime.Compare(CDate, DateTime.Now) > 0) throw new ArgumentException("데이터 생성 일자는 현재 이후일 수 없습니다.");

            _seq = seq;
            _cDate = cDate;
        }
        private User(DateTime cDate)
        {

            if (cDate == null) throw new ArgumentNullException("데이터 생성 일자는 null일 수 없습니다.");
            if (DateTime.Compare(cDate, DateTime.Now) > 0) throw new ArgumentNullException("데이터 생성 일자는 현재 이후일 수 없습니다.");

            _cDate = cDate;
        }

        public static User New(string name, string phone, string birthday)
        {
            return new User(DateTime.Now)
            {
                Name = name,
                Phone = phone,
                Birthday = birthday,
            };
        }

        public static User Of(int? seq, string name, string phone, string birthday, DateTime cDate, DateTime? mDate, DateTime? dDate)
        {
            return new User(seq, cDate)
            {
                Name = name,
                Phone = phone,
                Birthday = birthday,
                MDate = mDate,
                DDate = dDate,
            };
        }
    }
}