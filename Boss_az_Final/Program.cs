
using Boss_az_Final.DB;
using Boss_az_Final.Models;



Console.CursorVisible = false;




Thread[] threads = new Thread[4];

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(Animation.AnimateBoss);
    threads[i].Start();
}
Console.ReadKey();
Animation.stop();
Console.ReadKey();





Funcs.startMenu();



