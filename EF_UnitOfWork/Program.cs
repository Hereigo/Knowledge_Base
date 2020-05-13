using System.Linq;

namespace EF_UnitOfWork
{
    internal static class Program
    {
        private static void Main()
        {
            UnitOfWorkUsing usingUOW = new UnitOfWorkUsing();
            usingUOW.WorkWithUOW();
        }
    }

    public class UnitOfWorkUsing
    {
        private readonly UnitOfWork _uow;

        public UnitOfWorkUsing()
        {
            _uow = new UnitOfWork();
        }

        public void WorkWithUOW()
        {
            if (_uow.OneRepository.GetAll().ToList().Count < 1)
            {
                _uow.OneRepository.Create(new EntityOne());
                _uow.Save();

                _uow.OneRepository.Create(new EntityOne() { Name = "Alex Murphy" });
                _uow.OneRepository.Create(new EntityOne() { Name = "Robinson Crusoe" });
                _uow.Save();

                EntityOne bookToUpdate = _uow.OneRepository.Get(1);
                bookToUpdate.Name = "Bruce Lee";

                _uow.OneRepository.Update(bookToUpdate);
                _uow.Save();
            }

            foreach (var item in _uow.OneRepository.GetAll())
            {
                System.Console.WriteLine($"{item.Id} - {item.Name}");
            }
        }
    }
}
