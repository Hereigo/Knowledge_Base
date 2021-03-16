namespace EF_UnitOfWork_Repository_2
{
    internal static class App_Start
    {
        private static void Main()
        {
            DatabaseContext databaseContext = new DatabaseContext();

            UnitOfWork unitOfWork = new UnitOfWork(databaseContext);

            unitOfWork.RepositoryOne.Add(new BizOneEntity { Text = "Some text.", BizOneSpecial = "Biz One Prop." });
            unitOfWork.Commit();

            foreach (BizOneEntity i in unitOfWork.RepositoryOne.GetAll())
            {
                System.Console.WriteLine($"{i.Id} - {i.Text} - {i.BizOneSpecial}");
            }
        }
    }
}
