using System;

namespace DI_Autofac_Net462
{
    public class DataAccess : IDataAccess
    {
        public void LoadData()
        {
            Console.WriteLine("Data Loaded.");
        }

        public void SaveData(string name)
        {
            Console.WriteLine("Saved data - " + name);
        }
    }
}
