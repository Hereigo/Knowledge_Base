﻿using System;

namespace Log4net_use
{
    internal static class Program
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main()
        {
            log.Info("Hello logging world!");

            log.Info("Another logging data!");

            Console.WriteLine("Hit enter");
            Console.ReadLine();
        }
    }
}
