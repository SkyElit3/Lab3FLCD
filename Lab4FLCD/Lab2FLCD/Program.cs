using System;

namespace Lab2FLCD
{
    class Program
    {
        static void Main()
        {
        
            Console.Write("Enter the problem name :");
            var val = Console.ReadLine();
            while (val != null && !val.Equals("exit"))
            {
                Scanner s1 = new Scanner();
                string path = new string(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\input\" + val + ".txt");
                string token = new string(@"C:\Users\SkyElit3\RiderProjects\Lab3FLCD\Lab2FLCD\input\token.in");
                s1.Scan(path, token);
                val = Console.ReadLine();
            }
            
        /*
        FiniteAutomator f = new FiniteAutomator();
        f.ScanFile(@"C:\Users\SkyElit3\RiderProjects\Lab4FLCD\Lab2FLCD\input\FA.in");
        f.Run();
        */
        }
    }
}