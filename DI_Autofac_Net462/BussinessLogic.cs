namespace DI_Autofac_Net462
{
    public class BussinessLogic : IBussinessLogic
    {
        IDataAccess _dataAccess;

        public BussinessLogic(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void ProcessData()
        {
            _dataAccess.LoadData();

            _dataAccess.SaveData("TestedData");
        }
    }
}
