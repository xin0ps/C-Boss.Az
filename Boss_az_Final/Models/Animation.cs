using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_az_Final.Models
{
    public static class Animation
    {


       public static bool isrunning = true;
       public static void AnimateBoss()
        {
            Random random = new Random();
            int screenWidth = Console.WindowWidth;
            int screenHeight = Console.WindowHeight;

            int x = random.Next(screenWidth);
            int y = random.Next(screenHeight);

            int deltaX = random.Next(2) * 2 - 1; 
            int deltaY = random.Next(2) * 2 - 1;

            while (isrunning)
            {
                
                Console.SetCursorPosition(x, y);
                ConsoleColor color = (ConsoleColor)random.Next(1, 16);
                Console.ForegroundColor = color;
                Console.Write("Boss.az");

                
                Thread.Sleep(100);
                Console.SetCursorPosition(x, y);
                Console.Write("--");

                x += deltaX;
                y += deltaY;

               
                if (x <= 0 || x >= screenWidth - 8)
                {
                    deltaX *= -1;
                }

                if (y <= 0 || y >= screenHeight)
                {
                    deltaY *= -1;
                }
            }
        }
        public static void stop()
        {
            isrunning = false;
        }
    }
}

