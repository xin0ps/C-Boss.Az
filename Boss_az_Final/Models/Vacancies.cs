using Boss_az_Final.DB;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Boss_az_Final.Models
{
    public class Vacancies
    {



        private Guid _id;
        private DateTime _announceDate;
        private DateTime _expireAnnounceDate;
        private JobCategory _category;
        private string? _experience;
        private string? _company;
        private string? _city;
        private string? _job;
        private string? _age;
        private int _payment;
        private int vacview = 0;
        private string? contact;

        public static string filepath = "../../../Vacancies.json";

        public JobCategory _Category
        {
            get { return _category; }
            set { _category = value; }
        }


        public int Vacview
        {
            get { return vacview; }
            set { vacview = value; }
        }



        public string? Contact
        {
            get { return contact; }
            set
            {
                if (value != null && Regex.IsMatch(value, @"^[A-Za-z0-9._%+-]+@gmail\.com$"))
                {
                    contact = value;
                }
                else
                {
                    throw new Exception("Email @gmail.com ile bitmelidir");
                }
            }
        }
        public Guid Id { get { return _id; } set { _id = value; } }

        public string? Job { get { return _job; } set { _job = value; } }
        public string? Age { get { return _age; } set { _age = value; } }
        public string? Company { get { return _company; } set { _company = value; } }
        public string? City { get { return _city; } set { _city = value; } }

        public int Payment
        {
            get { return _payment; }
            set
            {
                try
                {
                    if (value < 0) throw new Exception("Payment couldn't be lower than zero !");
                    _payment = value;
                    int days = _payment * 7;
                    ExpireAnnounceDate = DateTime.Now.AddDays(days);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }
        public string? Experience { get { return _experience; } set { _experience = value; } }
        public DateTime AnnounceDate { get { return _announceDate; } set { _announceDate = value; } }
        public DateTime ExpireAnnounceDate { get { return _expireAnnounceDate; } set { _expireAnnounceDate = value; } }



        public Vacancies() { Id = Guid.NewGuid(); }
        public Vacancies(string? experience, string? company,
            string? city, string? job, string? age, int payment, DateTime start, DateTime end, JobCategory category, string _contact) : this()
        {
            Experience = experience;
            Company = company;
            City = city;
            Job = job;
            Age = age;
            Payment = payment;
            AnnounceDate = start;
            ExpireAnnounceDate = end;
            _Category = category;
            Contact = _contact;
        }

        public static Vacancies CreateVacancies()
        {

            DateTime _startTime = DateTime.MinValue;
            DateTime _endTime = DateTime.MinValue;

            string? _experience = null;
            string? _company = null;
            string? _city = null;
            string? _job = null;
            string? _age = null;
            string? _contact = null;
            int _payment = 0;

            JobCategory _category;




            while (_startTime == DateTime.MinValue)
            {
                try
                {
                    Console.Write("StartTime (yyyy-MM-dd ): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime startTime))
                    {
                        _startTime = startTime;
                    }
                    else
                    {
                        throw new Exception("Yanlis tarix formati.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (_endTime == DateTime.MinValue)
            {
                try
                {
                    Console.Write("EndTime (yyyy-MM-dd ): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime endTime))
                    {
                        _endTime = endTime;
                    }
                    else
                    {
                        throw new Exception("Yanlis tarix formati.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            while (string.IsNullOrWhiteSpace(_company))
            {
                try
                {
                    Console.Write("Company: ");
                    _company = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(_company))
                    {
                        throw new Exception("Company name cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (string.IsNullOrWhiteSpace(_experience))
            {
                try
                {
                    Console.Write("Experience: ");
                    _experience = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(_experience))
                    {
                        throw new Exception("Experience cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (string.IsNullOrWhiteSpace(_city))
            {
                try
                {
                    Console.Write("City: ");
                    _city = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(_city))
                    {
                        throw new Exception("City cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (string.IsNullOrWhiteSpace(_job))
            {
                try
                {
                    Console.Write("Job: ");
                    _job = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(_job))
                    {
                        throw new Exception("Job cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            while (true)
            {
                try
                {


                    Console.Write("Age : ");
                    if (int.TryParse(Console.ReadLine(), out int age))
                    {
                        _age = age.ToString();

                        break;
                    }
                    else { throw new Exception("Reqem daxil edin!"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (_payment <= 0)
            {
                try
                {
                    Console.Write("Payment (Positive number): ");
                    if (int.TryParse(Console.ReadLine(), out int pay))
                    {
                        _payment = pay;
                        if (_payment <= 0)
                        {
                            throw new Exception("Payment must be a positive number.");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid payment format. Payment must be a positive number.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Category (IT Marketing Finance Healthcare Education Construction Sales Legal Design CustomerService): ");
                    string category = Console.ReadLine();

                    if (Enum.TryParse(category, true, out JobCategory _jobCategory))
                    {
                        if (Enum.IsDefined(typeof(JobCategory), _jobCategory))
                        {
                            _category = _jobCategory;

                            break;
                        }
                        else
                        {
                            throw new Exception("Category movcud deyil.");
                        }
                    }
                    else
                    {
                        throw new Exception("Category movcud deyil.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            while (string.IsNullOrWhiteSpace(_contact))
            {
                try
                {
                    Console.Write("_contact(email: ");
                    _contact = Console.ReadLine();
                    if (!(Regex.IsMatch(_contact, @"^[A-Za-z0-9._%+-]+@gmail\.com$")))
                    {
                        throw new Exception("Email @gmail.com ile bitmelidir");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Vacancies vac = new Vacancies(_experience, _company, _city, _job, _age, _payment, _startTime, _endTime, _category, _contact);
            
            BaseData.AllVacancies.Add(vac);
            
            return vac;
        }

        public static void ShowVacancies(Worker current)
        {
            BaseData.LoadAllDataFromJson();
            ConsoleKeyInfo key;
            int selectedCategoryIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select a category:");
                
                    Console.WriteLine("For Exit press  ESC...");
                
                for (int i = 0; i < Enum.GetNames(typeof(JobCategory)).Length; i++)
                {
                    if (i == selectedCategoryIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"{i + 1}. {((JobCategory)(i + 1)).ToString()}----- {BaseData.AllVacancies.FindAll(vac => vac._Category == (JobCategory)(i + 1)).Count}");
                    Console.ResetColor();
                  
                }

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (key.Key == ConsoleKey.UpArrow && selectedCategoryIndex > 0)
                {
                    selectedCategoryIndex--;
                }
                else if (key.Key == ConsoleKey.DownArrow && selectedCategoryIndex < Enum.GetNames(typeof(JobCategory)).Length - 1)
                {
                    selectedCategoryIndex++;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    int categoryId = selectedCategoryIndex + 1;
                    var list = BaseData.AllVacancies.FindAll(vac => vac._Category == (JobCategory)categoryId);
                    int id = 0;
                    Console.Clear();
                    foreach (var item in list)
                    {
                        id++;
                        Console.WriteLine(
                                          $"------------------------------------ \n" +
                                          $"Id : {id} \n" +
                                          $"Category: {item._Category.ToString()} \n" +
                                          $"Job : {item.Job} \n" +
                                          $"Age : {item.Age} \n" +
                                          $"City : {item.City} \n" +
                                          $"Payment : {item.Payment} \n" +
                                          $"Company : {item.Company} \n" +
                                          $"Experience : {item.Experience} \n" +
                                          $"Announce Date : {item.AnnounceDate.ToString("yyyy/MM/d")} \n" +
                                          $"Expire of Announce Date : {item.ExpireAnnounceDate.ToString("yyyy/MM/d")} \n" +
                                          $"View : {item.Vacview} \n" +
                                          "------------------------------------ \n");
                    }

                    while (true)
                    {
                        Console.Write("Enter id for view the vacancy:");
                        string input = Console.ReadLine();
                        int index;
                        if (int.TryParse(input, out index))
                        {
                            if (index <= list.Count && index > 0)
                            {
                                viewVacancie(list, index, current);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                    }
                }
            }
        }

        public static void viewVacancie(List<Vacancies> vac, int index, Worker current)
        {
            Employer employer = BaseData.Allemployers.Find(emp => emp.Email == vac[index - 1].contact);
     
            Console.WriteLine(

                                  $"------------------------------------ \n" +
                                   $"Id : {index} \n" +
                                  $"Job : {vac[index - 1].Job} \n" +
                                  $"Age : {vac[index - 1].Age} \n" +
                                  $"City : {vac[index - 1].City} \n" +
                                  $"Payment : {vac[index - 1].Payment} \n" +
                                  $"Company : {vac[index - 1].Company} \n" +
                                  $"Experience : {vac[index - 1].Experience} \n" +
                                  $"Announce Date : {vac[index - 1].AnnounceDate.ToString("yyyy/MM/d")} \n" +
                                  $"Expire of Announce Date : {vac[index - 1].ExpireAnnounceDate.ToString("yyyy/MM/d")} \n" +
                                  $"View : {vac[index - 1].Vacview} \n" +
                                  $"Contact: {vac[index - 1].contact} \n");
            Console.Write("Write 'apply' to apply for the job: ");
            string? app = Console.ReadLine();
            if (app == "apply")
            {     
                string notificationMessage = $"Id:{vac[index - 1].Id} job vacancy has been applied by {current.Name} {current.SurName} at {DateTime.Now.ToString("yyyy/dd/mm/h/m")}";
                employer.Notify.Add(new Notificaiton(notificationMessage));
                BaseData.AllNotifications.Add(new Notificaiton(notificationMessage));
                
                
            }
            Funcs.PressAnyKey();
        }



        //Console.WriteLine($"Id : {id} \n" +
        //                  $"Category: {item._Category.ToString()} \n" +
        //                  $"Job : {item.Job} \n" +
        //                  $"Age : {item.Age} \n" +
        //                  $"City : {item.City} \n" +
        //                  $"Payment : {item.Payment} \n" +
        //                  $"Company : {item.Company} \n" +
        //                  $"Experience : {item.Experience} \n" +
        //                  $"Announce Date : {item.AnnounceDate.ToString("yyyy/MM/d")} \n" +
        //                  $"Expire of Announce Date : {item.ExpireAnnounceDate.ToString("yyyy/MM/d")} \n" +
        //                  $"View : {item.Vacview} \n");


        public override string ToString()
        {
            return $"Id : {Id} \n" +
                   $"Category: {_Category.ToString()} \n" +
                   $"Job : {Job} \n" +
                   $"Age : {Age} \n" +
                   $"City : {City} \n" +
                   $"Payment : {Payment} \n" +
                   $"Company : {Company} \n" +
                   $"Experience : {Experience} \n" +
                   $"Announce Date : {AnnounceDate.ToString("yyyyy/mm/d")} \n" +
                   $"Expire of Announce Date : {ExpireAnnounceDate.ToString("yyyyy/mm/d")} \n" +
                   $"View : {Vacview} \n" +
                   $"Contact: {contact} \n";
        }
    }
}

