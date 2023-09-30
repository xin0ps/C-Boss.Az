using Boss_az_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boss_az_Final.DB
{
    public static class BaseData
    {
        public static List<Worker>? Allworkers = new List<Worker>();
        public static List<Employer>? Allemployers = new List<Employer>();
        public static List<Vacancies>? AllVacancies = new List<Vacancies>();
        public static List<CV>? AllCvs = new List<CV>();
        public static List<Notificaiton>? AllNotifications = new List<Notificaiton>();
      



        public static string workerFile = "../../../Workers.json";
        public static string employerFile = "../../../Employers.json";
        public static string vacanciesFile = "../../../Vacancies.json";
        public static string cvsFile = "../../../Cvs.json";
        public static string notificationFile = "../../../Notifications.json";
      

        public static void LoadAllDataFromJson()
        {
            Allworkers = LoadDataFromJson<Worker>(workerFile);
            Allemployers = LoadDataFromJson<Employer>(employerFile);
            AllVacancies = LoadDataFromJson<Vacancies>(vacanciesFile);
            AllCvs = LoadDataFromJson<CV>(cvsFile);
            AllNotifications = LoadDataFromJson<Notificaiton>(notificationFile);
           
        }

        public static void SaveDataToJson<T>(string filename, List<T> data)
        {
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filename, json);
        }

        public static Worker SearchWorker(string username, string pass)
        {
            LoadAllDataFromJson();
            foreach (Worker worker in Allworkers)
            {
                if (worker.UserName == username && worker.Password == pass)
                {
                    return worker;
                }
            }
            return null;
        }

        public static Employer SearchEmployer(string username, string pass)
        {
            LoadAllDataFromJson();
            foreach (Employer employer in Allemployers)
            {
                if (employer.UserName == username && employer.Password == pass)
                {
                    return employer;
                }
            }
            return null;
        }

        private static List<T> LoadDataFromJson<T>(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                return new List<T>();
            }
        }


        public static bool SearchWorkerEmail(string email)
        {
            LoadAllDataFromJson();
            foreach (Worker worker in Allworkers)
            {
                if (worker.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool SearchEmployerEmail(string email)
        {
            LoadAllDataFromJson();
            foreach (Employer employer in Allemployers)
            {
                if (employer.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool SearchWorkerUsername(string user)
        {
            LoadAllDataFromJson();
            foreach (Worker worker in Allworkers)
            {
                if (worker.UserName == user)
                {
                    return true;
                }
            }
            return false;
        }

        public static void UpdateWorker(Worker updatedWorker)
        {
            LoadAllDataFromJson();
            Worker existingWorker = Allworkers.FirstOrDefault(w => w.Id == updatedWorker.Id);

            if (existingWorker != null)
            {
                existingWorker.Name = updatedWorker.Name;
                existingWorker.SurName = updatedWorker.SurName;
                existingWorker.Age = updatedWorker.Age;
                existingWorker.City = updatedWorker.City;
                existingWorker.Phone = updatedWorker.Phone;
                existingWorker.UserName = updatedWorker.UserName;
                existingWorker.Password = updatedWorker.Password;
                existingWorker.Email = updatedWorker.Email;
                existingWorker.Notify = updatedWorker.Notify;
                existingWorker._Cvs = updatedWorker._Cvs;

                SaveDataToJson(workerFile, Allworkers);
            }
        }
        public static void UpdateEmployer(Employer updatedEmployer)
        {
            LoadAllDataFromJson();
            Employer existingEmployer = Allemployers.FirstOrDefault(e => e.Id == updatedEmployer.Id);

            if (existingEmployer != null)
            {
                existingEmployer.Name = updatedEmployer.Name;
                existingEmployer.SurName= updatedEmployer.SurName;
                existingEmployer.Phone = updatedEmployer.Phone;
                existingEmployer.UserName = updatedEmployer.UserName;
                existingEmployer.Password = updatedEmployer.Password;
                existingEmployer.Email = updatedEmployer.Email;
                existingEmployer.City = updatedEmployer.City;
                existingEmployer.Age = updatedEmployer.Age;
                existingEmployer.Notify = updatedEmployer.Notify;
                existingEmployer._Vacancies = updatedEmployer._Vacancies;

                SaveDataToJson(employerFile, Allemployers);
            }
        }


        public static void UpdateVacancies(Vacancies updatedVacancy)
        {
            LoadAllDataFromJson();
            Vacancies existingVacancy = AllVacancies.FirstOrDefault(v => v.Id == updatedVacancy.Id);

            if (existingVacancy != null)
            {
                existingVacancy._Category = updatedVacancy._Category;
                existingVacancy.Job = updatedVacancy.Job;
                existingVacancy.Age = updatedVacancy.Age;
                existingVacancy.City = updatedVacancy.City;
                existingVacancy.Payment = updatedVacancy.Payment;
                existingVacancy.Company = updatedVacancy.Company;
                existingVacancy.Experience = updatedVacancy.Experience;
                existingVacancy.AnnounceDate = updatedVacancy.AnnounceDate;
                existingVacancy.ExpireAnnounceDate = updatedVacancy.ExpireAnnounceDate;
                existingVacancy.Vacview = updatedVacancy.Vacview;

                SaveDataToJson(vacanciesFile, AllVacancies);
            }
        }
        public static void UpdateCvs(List<CV> updatedCvs)
        {
            AllCvs = updatedCvs;
            SaveDataToJson(cvsFile, AllCvs);
        }
        public static void UpdateNotifications(List<Notificaiton> updatedNotify)
        {
            AllNotifications = updatedNotify;
            SaveDataToJson(notificationFile, AllNotifications);
        }


        public static void UpdateAllData()
        {
            SaveDataToJson(notificationFile, AllNotifications);
          SaveDataToJson(cvsFile, AllCvs);
            SaveDataToJson(employerFile, Allemployers);
            SaveDataToJson(workerFile, Allworkers);
             SaveDataToJson(vacanciesFile, AllVacancies);
     

        }

        public static bool SearchEmployerUsername(string user)
        {
            LoadAllDataFromJson();
            foreach (Employer employer in Allemployers)
            {
                if (employer.UserName == user)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

