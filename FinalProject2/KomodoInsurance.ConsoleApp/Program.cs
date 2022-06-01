using System;
using System.Collections.Generic;

namespace KomodoInsurance.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OutingsInterface oi = new OutingsInterface();
            oi.Run();
        }
    }
}