using Boss_az_Final.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Boss_az_Final.Models
{
    public class CV
    {

        // Private Fields

        private Guid _id;
        private string? _job;
        private string? _school;
        private string? _skills;
        private string? _companies;
        private string? _foreignLanguages;
        private string? _gitUrl;
        private string? contact;
        private string? _linkedin;
        private string? _haveDifCert;
        private float _graduateScore;
        private int _payment;
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


        // Properties

        public Guid Id { get { return _id; } set { _id = value; } }
  
        public string? Job
        {
            get { return _job; }
            set
            {
                if (value != null)
                {
                    _job = value;
                }
                else
                {
                    throw new Exception("Job must not be null.");
                }
            }
        }

        public string? School
        {
            get { return _school; }
            set
            {
                if (value != null)
                {
                    _school = value;
                }
                else
                {
                    throw new Exception("School must not be null.");
                }
            }
        }

        public string? Skills
        {
            get { return _skills; }
            set
            {
                if (value != null)
                {
                    _skills = value;
                }
                else
                {
                    throw new Exception("Skills must not be null.");
                }
            }
        }

        public string? Companies
        {
            get { return _companies; }
            set
            {
                if (value != null)
                {
                    _companies = value;
                }
                else
                {
                    throw new Exception("Companies must not be null.");
                }
            }
        }

        public string? ForeignLanguages
        {
            get { return _foreignLanguages; }
            set
            {
                if (value != null)
                {
                    _foreignLanguages = value;
                }
                else
                {
                    throw new Exception("ForeignLanguages must not be null.");
                }
            }
        }

        public string? Linkedin
        {
            get { return _linkedin; }
            set
            {
                if (value != null)
                {
                    _linkedin = value;
                }
                else
                {
                    throw new Exception("Linkedin must not be null.");
                }
            }
        }

        public string? GitUrl
        {
            get { return _gitUrl; }
            set
            {
                if (value != null)
                {
                    _gitUrl = value;
                }
                else
                {
                    throw new Exception("GitUrl must not be null.");
                }
            }
        }

        public string? HaveDifCert
        {
            get { return _haveDifCert; }
            set
            {
                if (value != null)
                {
                    _haveDifCert = value;
                }
                else
                {
                    throw new Exception("HaveDifCert must not be null.");
                }
            }
        }

        public float GraduateScore
        {
            get { return _graduateScore; }
            set
            {
                try
                {
                    if (value < 0) throw new Exception("Graduate Score couldn't be lower than zero!");
                    _graduateScore = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public int Payment
        {
            get { return _payment; }
            set
            {
                try
                {
                    if (value < 0) throw new Exception("Payment couldn't be lower than zero!");
                    _payment = value;
                    int days = _payment * 7;
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Constructors

        public CV() { Id = Guid.NewGuid() ; }

        public CV(string? job, string? school, string? skills,
            string? companies, string? foreignLanguages, string? gitUrl, string? linkedin,
            float graduateScore, string? haveDifCert, int _payment,string _contact) : this() 
        {
            Job = job;
            School = school;
            Skills = skills;
            Companies = companies;
            ForeignLanguages = foreignLanguages;
            GitUrl = gitUrl;
            Linkedin = linkedin;
            GraduateScore = graduateScore;
            HaveDifCert = haveDifCert;
            Payment = _payment;
            Contact = _contact;
            BaseData.AllCvs.Add(this);
            BaseData.UpdateAllData();
        }

        // Functions

        public static CV CreateCV()
        { 
       
        string? job = null;
            string? school = null;
            string? _contact = null;
            string? skills = null;
            string? companies = null;
            string? foreignLanguages = null;
            string? gitUrl = null;
            string? linkedin = null;
            string? haveDifCert = null;
            float? graduateScore = null;
            int payment = 0;

           

            while (string.IsNullOrWhiteSpace(job))
            {
                try
                {
                    Console.Write("CV Job: ");
                    job = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(job))
                    {
                        throw new Exception("CV Job cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (string.IsNullOrWhiteSpace(school))
            {
                try
                {
                    Console.Write("CV School: ");
                    school = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(school))
                    {
                        throw new Exception("CV School cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (string.IsNullOrWhiteSpace(skills))
            {
                try
                {
                    Console.Write("CV Skills: ");
                    skills = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(skills))
                    {
                        throw new Exception("CV Skills cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (string.IsNullOrWhiteSpace(companies))
            {
                try
                {
                    Console.Write("CV Companies: ");
                    companies = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(companies))
                    {
                        throw new Exception("CV Companies cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (string.IsNullOrWhiteSpace(foreignLanguages))
            {
                try
                {
                    Console.Write("CV Foreign Languages: ");
                    foreignLanguages = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(foreignLanguages))
                    {
                        throw new Exception("CV Foreign Languages cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (string.IsNullOrWhiteSpace(gitUrl))
            {
                try
                {
                    Console.Write("CV Git Url: ");
                    gitUrl = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(gitUrl))
                    {
                        throw new Exception("CV Git Url cannot be empty or whitespace.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (string.IsNullOrWhiteSpace(linkedin))
            {
                try
                {
                    Console.Write("CV Linkedin: ");
                    linkedin = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(linkedin))
                    {
                        throw new Exception("CV Linkedin cannot be empty or whitespace.");
                    }
                }   
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (graduateScore == null || graduateScore < 0)
            {
                try
                {
                    Console.Write("Graduate Score (Positive number): ");
                    if (float.TryParse(Console.ReadLine(), out float score))
                    {
                        graduateScore = score;
                        if (graduateScore < 0)
                        {
                            throw new Exception("Graduate Score must be a positive number.");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid graduate score format. Score must be a positive number.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (payment <= 0)
            {
                try
                {
                    Console.Write("Payment (Positive number): ");
                    if (int.TryParse(Console.ReadLine(), out int pay))
                    {
                        payment = pay;
                        if (payment <= 0)
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

            while (string.IsNullOrWhiteSpace(haveDifCert) || !(haveDifCert.Equals("Yes", StringComparison.OrdinalIgnoreCase) || haveDifCert.Equals("No", StringComparison.OrdinalIgnoreCase)))
            {
                try
                {
                    Console.Write("Difference Certificate (Yes/No): ");
                    haveDifCert = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(haveDifCert) || !(haveDifCert.Equals("Yes", StringComparison.OrdinalIgnoreCase) || haveDifCert.Equals("No", StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new Exception("Please enter either 'Yes' or 'No' for Difference Certificate.");
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

            return new CV(job, school, skills, companies, foreignLanguages, gitUrl, linkedin, graduateScore.Value, haveDifCert, payment,_contact);
        }

        public static void ShowCvs(Employer current)
        {
            BaseData.LoadAllDataFromJson();
            ConsoleKeyInfo key;
            int selectedCategoryIndex = 0;

            while (true)
            {
                Console.Clear();
               

                Console.WriteLine("For Exit press  ESC...");

                Console.Clear();
                int id = 0;
                foreach (var item in BaseData.AllCvs)
                {
                    id++;
                    Console.WriteLine($"\n---------------------------------------------\nCV-Id:{id}\n{item}");
                }
               

             

                    while (true)
                    {
                        Console.Write("Enter id for view the Cv:");
                        string input = Console.ReadLine();
                        int index;
                        if (int.TryParse(input, out index))
                        {
                        if (index <= BaseData.AllCvs.Count && index > 0)
                        {
                            while (true) {
                                Console.Clear();
                                Console.WriteLine(BaseData.AllCvs[index - 1]);
                                Console.Write("Invite for job Write [inv]([exit]-for exit):");
                                string str = Console.ReadLine();
                                if (str != null)
                                {
                                    if (str == "inv")
                                    {
                                     int  workind = BaseData.Allworkers.FindIndex(worker => worker.Email==BaseData.AllCvs[index-1].Contact);
                                        BaseData.Allworkers[workind].Notify.Add(new Notificaiton($"Size {current.Name} {current.SurName}" +
                                            $"Terefinden is deveti   gonderildi "));
                                        BaseData.AllNotifications.Add(new Notificaiton($"{BaseData.Allworkers[workind].Name}" +
                                            $"{BaseData.Allworkers[workind].SurName} adli Worker {current.Name} {current.SurName}" +
                                            $"Terefinden is deveti  aldi "));
                                        BaseData.UpdateAllData();
                                        Console.WriteLine("Is deveti gonderildi.");
                                        Funcs.PressAnyKey();
                                        break;
                                    }
                                    if (str == "exit")
                                    {
                                        return;
                                    }

                                }
                            }
                        }
                        }
                        else
                        {
                            Console.WriteLine("Exiting...");
                        Funcs.PressAnyKey();
                        return;
                        }
                    }
                    
                }
            }
        

       


        public override string ToString()
        {
            return $"Id : {Id} \n" +
                   $"Job : {Job} \n" +
                   $"School : {School} \n" +
                   $"Skills : {Skills} \n" +
                   $"Companies : {Companies} \n" +
                   $"Foreign Languages : {ForeignLanguages} \n" +
                   $"Git Url : {GitUrl} \n" +
                   $"Linkedn : {Linkedin} \n" +
                   $"Graduate Score : {GraduateScore} \n" +
                   $"Difference Certificate : {HaveDifCert} \n"+
                   $"Contact : {contact} \n";
        }
    }
}

