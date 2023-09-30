using Boss_az_Final.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_az_Final.Models
{
    public class Employer:Person
    {
        private List<Vacancies>? vacancies = new List<Vacancies>();
        public List<Vacancies>? _Vacancies
        {
            get { return vacancies; }
            set { vacancies = value; }
        }
        static string filepath = "../../../Employers.json";



        public Employer() { }
        public Employer(string? _name, string? _surname, int? _age, string _city, string _phone, string _username, string _password, string _email) : base()
        {
            this.Name = _name;
            this.SurName = _surname;
            this.Age = _age;
            this.City = _city;
            this.Phone = _phone;
            this.UserName = _username;
            this.Password = _password;
            this.Email = _email;

        }
        public static Employer EmployerSignin()
        {
            string user = "";
            string pass = "";
            List<string> choose = new List<string>
    {
        "Username:",
        "Password:",
        "Login",
        "Exit"
    };

            Console.Clear();

            int index = 0;

            while (true)
            {
                int y = 14 - choose.Count;

                for (int i = 0; i < choose.Count; i++)
                {
                    Console.SetCursorPosition(55, y + i);

                    if (index == i)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    Console.WriteLine(choose[i]);
                }

                Console.SetCursorPosition(65, 14 - choose.Count);
                Console.BackgroundColor = ConsoleColor.Black;


                Console.SetCursorPosition(65, 16 - choose.Count);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) break;
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (index > 0) index--;
                    else index = choose.Count - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (index < choose.Count - 1) index++;
                    else index = 0;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (index == 0)
                    {
                        Console.SetCursorPosition(65, 14 - choose.Count);
                        user = Console.ReadLine();
                    }
                    else if (index == 1)
                    {
                        Console.SetCursorPosition(65, 15 - choose.Count);
                        pass = EnterPassword();
                    }
                    if (index == 2)
                    {
                        Console.WriteLine("\nLogin selected");


                        Employer authenticatedEmployer = BaseData.SearchEmployer(user, pass);

                        if (authenticatedEmployer != null)
                        {
                            Console.WriteLine("Login successful!");
                            return authenticatedEmployer;
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password. Please try again.");
                        }
                    }
                    else if (index == 3)
                    {
                        Console.WriteLine("\nExiting the program.");
                        return null;
                    }
                    else { index++; }
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            return null;
        }

        public static string EnterPassword()
        {
            string password = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
        public static void EmployerSignUp()
        {
            Random random = new Random();
            string rand = Convert.ToString(random.Next(100, 999));
            Employer newemployer = new Employer();
            string Name = "";
            string Surname = "";
            int? Age = 0;
            string City = "";
            string Phone = "";
            string Username = "";
            string Password = "";
            string Email = "";
            string Verification = "";
            string empty = "x";
            List<string> choose = new List<string>
    {
        "Name:",
        "Surname:",
        "Age:",
        "City:",
        "Phone:",
        "Username:",
        "Password:",
        "Email:",
        "Verification:",
        "Exit"
    };

            Console.Clear();

            int index = 0;

            while (true)
            {
                int y = 14 - choose.Count;

                for (int i = 0; i < choose.Count; i++)
                {
                    Console.SetCursorPosition(55, y + i);

                    if (index == i)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    Console.WriteLine(choose[i]);
                }

                Console.SetCursorPosition(65, 14 - choose.Count);
                Console.BackgroundColor = ConsoleColor.Black;

               

                Console.SetCursorPosition(65, 16 - choose.Count);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) break;
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (index > 0) index--;
                    else index = choose.Count - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (index < choose.Count - 1) index++;
                    else index = 0;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (index == 9)
                    {
                        break;
                    }
                    if (index == 0)
                    {


                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(65, 14 - choose.Count);
                                Name = Console.ReadLine();
                                newemployer.Name = Name;
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(65, 14 - choose.Count);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                string emptySpaces = new string(' ', ex.Message.Length);
                                Console.SetCursorPosition(65, 14 - choose.Count);
                                Console.Write(emptySpaces);
                            }
                        }
                    }
                    else if (index == 1)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(65, 15 - choose.Count);
                                Surname = Console.ReadLine();
                                newemployer.SurName = Surname;
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(65, 15 - choose.Count);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                string emptySpaces = new string(' ', ex.Message.Length);
                                Console.SetCursorPosition(65, 15 - choose.Count);
                                Console.Write(emptySpaces);
                            }
                        }
                    }
                    else if (index == 2)
                    {
                        while (true)
                        {
                            try
                            {


                                Console.SetCursorPosition(65, 16 - choose.Count);
                                if (int.TryParse(Console.ReadLine(), out int age))
                                {
                                    newemployer.Age = age;
                                    break;
                                }
                                else { throw new Exception("Reqem daxil edin!"); }
                            }
                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(65, 16 - choose.Count);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                string emptySpaces = new string(' ', ex.Message.Length);
                                Console.SetCursorPosition(65, 16 - choose.Count);
                                Console.Write(emptySpaces);
                            }
                        }
                    }
                    else if (index == 3)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(65, 17 - choose.Count);
                                City = Console.ReadLine();
                                newemployer.City = City;
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(65, 17 - choose.Count);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                string emptySpaces = new string(' ', ex.Message.Length);
                                Console.SetCursorPosition(65, 17 - choose.Count);
                                Console.Write(emptySpaces);
                            }
                        }
                    }
                    else if (index == 4)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(65, 18 - choose.Count);
                                Phone = Console.ReadLine();
                                newemployer.Phone = Phone;
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(65, 18 - choose.Count);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                string emptySpaces = new string(' ', ex.Message.Length);
                                Console.SetCursorPosition(65, 18 - choose.Count);
                                Console.Write(emptySpaces);
                            }
                        }
                    }
                    else if (index == 5)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(65, 19 - choose.Count);
                                Username = Console.ReadLine();
                                if (BaseData.SearchWorkerUsername(Username))
                                {
                                    throw new Exception("Username movcuddur basqa bir username yoxla");
                                }
                                newemployer.UserName = Username;
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(65, 19 - choose.Count);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                string emptySpaces = new string(' ', ex.Message.Length);
                                Console.SetCursorPosition(65, 19 - choose.Count);
                                Console.Write(emptySpaces);
                            }
                        }
                    }
                    else if (index == 6)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(65, 20 - choose.Count);
                                Password = Console.ReadLine();

                                newemployer.Password = Password;
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(65, 20 - choose.Count);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                string emptySpaces = new string(' ', ex.Message.Length);
                                Console.SetCursorPosition(65, 20 - choose.Count);
                                Console.Write(emptySpaces);
                            }
                        }
                    }

                    else if (index == 7)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(65, 21 - choose.Count);
                                Email = Console.ReadLine();
                                if (BaseData.SearchWorkerEmail(Email))
                                {
                                    throw new Exception("Email movcuddur basqa bir email yoxla");
                                }
                                newemployer.Email = Email;
                                Console.SetCursorPosition(65, 21 - choose.Count);
                                Thread.Sleep(2000);
                                Console.WriteLine($"{Email}-code gonderildi!");
                                SendEmail.sendverification(Email, rand);
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(65, 21 - choose.Count);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                string emptySpaces = new string(' ', ex.Message.Length);
                                Console.SetCursorPosition(65, 21 - choose.Count);
                                Console.Write(emptySpaces);
                            }
                        }
                    }

                    else if (index == 8)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.SetCursorPosition(70, 22 - choose.Count);
                                Verification = Console.ReadLine();

                                if (Verification == rand)
                                {
                                    Console.SetCursorPosition(65, 23 - choose.Count);
                                    Console.WriteLine("SignUp Succesfully! Make your Cv");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                    Vacancies vac = Vacancies.CreateVacancies();

                                    if (vac != null)
                                    {Console.Clear();
                                        newemployer._Vacancies.Add(vac);
                                        BaseData.LoadAllDataFromJson();
                                        BaseData.Allemployers.Add(newemployer);
                                        BaseData.SaveDataToJson(filepath, BaseData.Allemployers);


                                        return;
                                    }


                                }

                            }



                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(65, 22 - choose.Count);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(2000);
                                string emptySpaces = new string(' ', ex.Message.Length);
                                Console.SetCursorPosition(65, 22 - choose.Count);
                                Console.Write(emptySpaces);
                            }
                        }
                    }

                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

        }






        public override string ToString()
        {
            return base.ToString() + $"Vacancies:{vacancies}\n";
        }

    }

}


