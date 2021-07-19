namespace EF_Repository_UoW
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork_Use use = new UnitOfWork_Use();

            use.GetAll();
        }
    }
}
