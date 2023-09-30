using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Boss_az_Final.Models
{
    public abstract class Person
    {
        private Guid id;
        private string? name;
        private string? surname;
        private int? age;
        private string? city;
        private string? phone;
        private string? username;
        private string? password;
        private string? email;
        private List<Notificaiton> notifications = new List<Notificaiton>();

        public List<Notificaiton> Notify
        {
            get { return notifications; }
            set { notifications = value; }
        }
        public Guid Id
        {
            get { return id; }  
            set { id = value; }
        }

        public string? Name
        {
            get { return name; }
            set
            {
                if (value != null && Regex.IsMatch(value, @"^[A-Z][a-z]*$"))
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Ad ilk herfi boyuk olmalidir");
                }
            }
        }

        public string? SurName
        {
            get { return surname; }
            set
            {
                if (value != null && Regex.IsMatch(value, @"^[A-Z][a-z]*$"))
                {
                    surname = value;
                }
                else
                {
                    throw new Exception("Soyad ilk herfi boyuk olmalidir.");
                }
            }
        }
    


    public string? Phone
        {
            get { return phone; }
            set
            {
                if (value != null && Regex.IsMatch(value, @"^(050|070|077|055|051)\d{7}$"))
                {
                    phone = value;
                }
                else
                {
                    throw new Exception("Telefon nomresi uygun formatda deyil!");
                }
            }
        }

        public string? City
        {
            get { return city; }
            set
            {
                if (value != null )
                {
                    city = value;
                }
                else
                {
                    throw new Exception("Bosluq daxil edile bilmez!");
                }
            }
        }

        public string? UserName
        {
            get { return username; }
            set
            {
                if (value != null )
                {
                    username = value;
                }
                else
                {
                    throw new Exception("username daxil edilmeyib!");
                }
            }
        }

        public string? Password
        {
            get { return password; }
            set
            {
                if (value != null && Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)[A-Za-z\d\W]{8,}$"))
                {
                    password = value;
                }
                else
                {
                    throw new Exception("Invalid password format. .");
                }
            }
        }


        public string? Email
        {
            get { return email; }
            set
            {
                if (value != null && Regex.IsMatch(value, @"^[A-Za-z0-9._%+-]+@gmail\.com$"))
                {
                    email = value;
                }
                else
                {
                    throw new Exception("Email @gmail.com ile bitmelidir");
                }
            }
        }

        public int? Age
        {
            get { return age; }
            set
            {
                if (value >= 18 && value < 65)
                {
                    age = value;
                }
                else
                {
                    throw new Exception("Yas araligi duzgun deyil!");
                }
            }
        }

      public  Person()
        {
            id= Guid.NewGuid();
        }

        public Person( string? _name, string? _surname, int? _age, string _city, string _phone, string _username, string _password, string _email):this()
        {

            Name = _name;
            SurName = _surname;
            Phone = _phone;
            City = _city;
            UserName = _username;
            Password = _password;
            Email = _email;
            Age = _age;
        }
        public void showNotifications()
        {
            foreach (var item in Notify)
            {
                Console.WriteLine(item);
            }
        }

        public override string ToString() {

            return $"Name:{Name}\n" +
                    $"Surname:{SurName}\n" +
                    $"Phone:{Phone}\n" +
                    $"City:{City}\n" +
                    $"Email:{Email}\n" +
                    $"Age:{Age}\n";
        }
    }
}
