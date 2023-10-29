using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace WebFormProject3.Models
{
    public class User : Data
    {
        private string _phone;
        private string _name;
        private string _birthday;
        private string _gender;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("이름은 비어있거나 null일 수 없습니다.");
                if (value.Length > 100) throw new ArgumentException("이름은 100자를 넘길 수 없습니다.");
                _name = value;
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("휴대폰 번호는 비어있거나 null일 수 없습니다.");

                string pattern = @"^\d{3,4}-\d{4}-\d{4}$";
                if (!Regex.IsMatch(value, @"^\d{3,4}-\d{4}-\d{4}$")) throw new ArgumentException("휴대폰 번호의 형식에 맞지 않습니다. 형식: " + pattern);

                _phone = value;
            }
        }
        public string Birthday
        {
            get { return _birthday; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("생년월일은 null일 수 없습니다.");

                string pattern = @"^\d{4}-\d{2}-\d{2}$";
                if (!Regex.IsMatch(value, pattern)) throw new ArgumentException("생년월일의 형식에 맞지 않습니다. 형식: " + pattern);

                string now = DateTime.Now.ToString("yyyy-MM-dd");
                if (string.Compare(value, now) > 0) throw new ArgumentException("생년월일은 현재 이후일 수 없습니다.");

                _birthday = value;
            }
        }
        public string GenderCode { get { return _gender; } }
        public string Gender
        {
            get
            {
                switch (_gender)
                {
                    case "M": return "남성";
                    case "W": return "여성";
                    default: return "알 수 없음";
                }
            }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("성별은 비어있거나 null일 수 없습니다.");

                string pattern = "^[MW]$";
                if (!Regex.IsMatch(value, pattern)) throw new ArgumentException(@"성별은 다음 중 하나여야 합니다. ('M', 'W')");

                _gender = value;
            }
        }
        public int Age
        {
            get
            {
                string[] birthdayArray = _birthday.Split('-');
                int birthYear = int.Parse(birthdayArray[0]);
                int currentYear = DateTime.Now.Year;
                return currentYear - birthYear + 1;
            }
        }

        private User() : base() { }

        public static User New(string name, string phone, string birthday, string gender) => Of(null, name, phone, birthday, gender, null, null, null);
        public static User Of(int? seq, string name, string phone, string birthday, string gender, DateTime? cDate, DateTime? mDate, DateTime? dDate)
        {
            return new User
            {
                Seq = seq,
                Name = name,
                Phone = phone,
                Birthday = birthday,
                Gender = gender,
                CDate = cDate,
                MDate = mDate,
                DDate = dDate,
            };
        }
    }
}