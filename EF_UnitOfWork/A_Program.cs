using System.Linq;

namespace EF_UnitOfWork
{
    internal static class A_Program
    {
        private static void Main()
        {
            var unitOfWork = new UnitOfWork();

            if (unitOfWork.OneRepository.GetAll().ToList().Count < 1)
            {
                unitOfWork.OneRepository.Create(new EntityA());
                unitOfWork.Save();

                unitOfWork.OneRepository.Create(new EntityA() { Name = "Alex Murphy" });
                unitOfWork.OneRepository.Create(new EntityA() { Name = "Robinson Crusoe" });
                unitOfWork.Save();
            }

            foreach (var item in unitOfWork.OneRepository.GetAll())
            {
                System.Console.WriteLine($"{item.Id} - {item.Name}");
            }
        }
    }
}
