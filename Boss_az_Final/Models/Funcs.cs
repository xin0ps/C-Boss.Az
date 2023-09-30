using Boss_az_Final.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Boss_az_Final.Models
{
   static class Funcs
    {
       static Worker? currentworker=null;
       static Employer? currentemployer=null;
        public static void startMenu()
        {
            BaseData.LoadAllDataFromJson();
           
          
            while (true)
            {
               
                List<string> choose2 = new List<string>();
                choose2.Add("Worker");
                choose2.Add("Employer");
                choose2.Add("Guest");
                var i = Menu(choose2);
                if (i == 0)
                {
                    List<string> choose3 = new List<string>();
                    choose3.Add("Sign up");
                    choose3.Add("Sign in");

                    var index1 = Menu(choose3);
                    if (index1 == 0)
                    {
                        Worker.WorkerSignUp();
                    }
                    if (index1 == 1)
                    {
                        currentworker = Worker.WorkerSignin();
                        if (currentworker != null)
                        {
                            BaseData.AllNotifications.Add(new Notificaiton($"{currentworker.Name} {currentworker.SurName}" + $" Login etdi-"));
                            BaseData.UpdateAllData();
                        
                            while (true)
                            {
                                
                              
                                List<string> choose4 = new List<string>();
                                choose4.Add("Vacancies");
                                choose4.Add("Notifications");
                                choose4.Add("Add Cv");
                                choose4.Add("Exit");

                                var index3 = Menu(choose4);
                                if (index3 == 0)
                                {
                                    Console.Clear();
                                    BaseData.AllNotifications.Add(new Notificaiton($"{currentworker.Name} {currentworker.SurName}" +
                                        $" Vakansiyalara baxdi-"));
                                    BaseData.UpdateAllData();
                                    Vacancies.ShowVacancies(currentworker);
                                   


                                }
                                if (index3 == 1)
                                {
                                    Console.Clear();
                                    BaseData.AllNotifications.Add(new Notificaiton($"{currentworker.Name} {currentworker.SurName}" +
                                       $" Notifikasiyalara baxdi-"));
                                    BaseData.UpdateAllData();
                                    foreach (var item in currentworker.Notify)
                                    {
                                        Console.WriteLine($"\n---------------------------\n{item}");

                                    }
                                    PressAnyKey();
                                }
                              
                                if (index3 == 2)
                                {
                                    Console.Clear();
                                    CV newcv = CV.CreateCV();
                                    if (newcv != null)
                                    {
                                        currentworker._Cvs.Add(newcv);

                                        BaseData.AllCvs.Add(newcv);
                                        Console.Clear();
                                        BaseData.AllNotifications.Add(new Notificaiton($"{currentworker.Name} {currentworker.SurName}" +
                                           $" Yeni cv yaratdi-"));
                                       
                                        BaseData.UpdateAllData();
                                        PressAnyKey();
                                    }

                                }
                                if (index3 == 3)
                                {
                                    BaseData.AllNotifications.Add(new Notificaiton($"{currentworker.Name} {currentworker.SurName}" +
                                        $" EXIT etdi-"));
                                    BaseData.UpdateAllData();
                                    break;


                                }
                            }

                        }
                    
                    }
                }
                if (i == 1)
                {
                    
                    List<string> choose3 = new List<string>();
                    choose3.Add("Sign up");
                    choose3.Add("Sign in");

                    var index1 = Menu(choose3);
                    if (index1 == 0)
                    {
                        Employer.EmployerSignUp();
                    }
                    if (index1 == 1)
                    {
                       Employer currentemployer = Employer.EmployerSignin();
                        if (currentemployer != null)
                        {
                            BaseData.AllNotifications.Add(new Notificaiton($"{currentemployer.Name} {currentemployer.SurName}" + $" Login etdi-"));
                            BaseData.UpdateAllData();

                            while (true)
                            {


                                List<string> choose4 = new List<string>();
                                choose4.Add("Show all Cv");
                                choose4.Add("Notifications");
                                choose4.Add("Add Vacation");
                                choose4.Add("Exit");

                                var index3 = Menu(choose4);
                                if (index3 == 0)
                                {
                                    Console.Clear();
                                    CV.ShowCvs(currentemployer);
                                    BaseData.AllNotifications.Add(new Notificaiton($"{currentemployer.Name} {currentemployer.SurName}" +
                                        $" Cv-lara baxdi-"));

                                    BaseData.UpdateAllData();

                                   



                                }
                                if (index3 == 1)
                                {
                                    Console.Clear();
                                    BaseData.AllNotifications.Add(new Notificaiton($"{currentemployer.Name} {currentemployer.SurName}" +
                                       $" Notifikasiyalara baxdi-"));
                                    BaseData.UpdateAllData();
                                    foreach (var item in currentemployer.Notify)
                                    {
                                        Console.WriteLine($"\n---------------------------\n{item}");

                                    }
                                    PressAnyKey();
                                }

                                if (index3 == 2)
                                {
                                    Console.Clear();
                                    Vacancies newvac = Vacancies.CreateVacancies();
                                    if (newvac != null)
                                    {
                                        currentemployer._Vacancies.Add(newvac);

                                        BaseData.AllVacancies.Add(newvac);
                                        Console.Clear();
                                        BaseData.AllNotifications.Add(new Notificaiton($"{currentemployer.Name} {currentemployer.SurName}" +
                                           $" Yeni vacansia yaratdi-"));

                                        BaseData.UpdateAllData();
                                        PressAnyKey();
                                    }

                                }
                                if (index3 == 3)
                                {
                                    BaseData.AllNotifications.Add(new Notificaiton($"{currentemployer.Name} {currentemployer.SurName}" +
                                        $" EXIT etdi-"));
                                    BaseData.UpdateAllData();
                                    break;


                                }
                            

                        

                    

                    if (index3 == 3)
                                {
                                    break;


                                }
                            }
                            }
                      
                    }
                }
                if (i == 2)
                {
                    while (true)
                    {
                    
                        List<string> choose5 = new List<string>();
                        choose5.Add("Show ALL cvs");
                        choose5.Add("Show vacancies");
                        choose5.Add("About");
                        choose5.Add("Exit");
                        int index5 = Menu(choose5);
                        if (index5 == 0)
                        {
                            Console.Clear();
                            foreach (var item in BaseData.AllCvs)
                            {
                                Console.WriteLine($"\n---------------------------------------------\n{item}");
                            }
                            PressAnyKey();
                        }
                        if (index5 == 1)
                        {
                            Console.Clear();
                            foreach (var item in BaseData.AllVacancies)
                            {
                                Console.WriteLine($"\n---------------------------------------------\n{item}");
                            }
                            PressAnyKey();
                        }
                        if (index5 == 2)
                        {
                           string text ="About Us\t\t\t create by Rasul Aslanov \r\n\r\nWelcome to [Boss.az], " +
                                "your go-to destination for seamless job hunting and recruitment solutions. " +
                                "At [Boss.az], we understand the challenges faced by both job seekers and" +
                                " employers in today's competitive market. That's why we've created a platform that " +
                                "bridges the gap between talent and opportunity.\r\n\r\nFor Job Seekers:\r\nAre you" +
                                " looking to take the next step in your career? Look no further. [Boss.az] offers " +
                                "a vast array of job listings across various industries. Whether you're a seasoned professional" +
                                " or just starting out, our user-friendly interface allows you to search for jobs based on your" +
                                " skills, experience, and preferences. Create a comprehensive CV, apply for multiple positions " +
                                "effortlessly, and track your applications, all in one place.\r\n\r\nFor Employers:\r\nFinding " +
                                "the right talent is crucial for the success of any organization. At [Boss.az]," +
                                " we simplify the recruitment process for you. Post your job openings, browse through" +
                                " a diverse pool of candidates, and connect with potential employees who align with your " +
                                "company's vision. Our advanced filtering and matching system ensures that you find the perfect" +
                                " fit for your team.\r\n\r\nWhy Choose Us?\r\n\r\nEfficiency: We streamline the job search and hiring " +
                                "process, saving you time and effort.\r\nDiversity: Our platform promotes inclusivity, allowing companies to " +
                                "diversify their workforce and job seekers to explore opportunities without barriers.\r\nSupport: Our dedicated " +
                                "support team is here to assist you at every step, ensuring a smooth experience for both employers and job seekers." +
                                "\r\nInnovation: We continuously enhance our platform to provide cutting-edge features and tools, keeping up with the" +
                                " ever-changing job market demands.\r\nJoin [Boss.az] today and embark on a journey where talent meets opportunity. " +
                                "Whether you're looking for your dream job or the ideal candidate, we've got you covered.";
                            foreach (char c in text)
                            {
                                Console.Write(c);
                                System.Threading.Thread.Sleep(1); 
                            }
                            PressAnyKey();
                        }
                        if (index5 == 3)
                        {
                            PressAnyKey();
                            break;

                        }

                    }
                }
            }
        }



        public static void PressAnyKey()
        {
            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }

        public static int Menu(List<string> choose)
        {
            Console.Clear();
            bool entered = false;
            int index = 0;

            while (true)
            {
                int y = 14 - choose.Count;
                for (int i = 0; i < choose.Count; i++)
                {
                    Console.SetCursorPosition(55, y + i);
                    if (index == i) Console.BackgroundColor = ConsoleColor.DarkGray;
                    else Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(choose[i]);
                }
                dynamic ascii = Console.ReadKey();
                if (ascii.Key == ConsoleKey.Escape) break;
                else if (ascii.Key == ConsoleKey.UpArrow)
                {
                    if (index > 0) index--;
                    else index = choose.Count - 1;
                }
                else if (ascii.Key == ConsoleKey.DownArrow)
                {
                    if (index < choose.Count - 1) index++;
                    else index = 0;
                }
                else if (ascii.Key == ConsoleKey.Enter)
                {
                    entered = true;
                    break;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            if (entered) return index;
            return -1;
        }

       

    }
}

