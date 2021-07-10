using System.Linq;
using EF_UnitOfWork.UOW;

namespace EF_UnitOfWork
{
    internal static class A_Program
    {
        private static void Main()
        {
            var unitOfWork = new UnitOfWork();

            if (unitOfWork.RepositoryB.GetAll().ToList().Count < 1)
            {
                unitOfWork.RepositoryB.Create(new EntityB());
                unitOfWork.Save();

                unitOfWork.RepositoryB.Create(new EntityB() { Name = "Alex Murphy 2" });
                unitOfWork.RepositoryB.Create(new EntityB() { Name = "Robinson Crusoe 2" });
                unitOfWork.Save();
            }

            foreach (var item in unitOfWork.RepositoryB.GetAll())
            {
                System.Console.WriteLine($"{item.Id} - {item.Name}");
            }
        }
    }
}
