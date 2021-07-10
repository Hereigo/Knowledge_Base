namespace EF_UnitOfWork_Repository
{
    internal static class App_Start
    {
        private static void Main()
        {
            DatabaseContext databaseContext = new DatabaseContext();

            UnitOfWork unitOfWork = new UnitOfWork(databaseContext);

            unitOfWork.RepositoryA.Add(new EntityA { Text = "Some text.", BizOneSpecial = "Biz One Prop." });
            unitOfWork.Commit();

            foreach (EntityA i in unitOfWork.RepositoryA.GetAll())
            {
                System.Console.WriteLine($"{i.Id} - {i.Text} - {i.BizOneSpecial}");
            }
        }
    }
}
