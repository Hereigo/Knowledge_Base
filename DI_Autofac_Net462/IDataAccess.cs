namespace DI_Autofac_Net462
{
    public interface IDataAccess
    {
        void LoadData();
        void SaveData(string name);
    }
}