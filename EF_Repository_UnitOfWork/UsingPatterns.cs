using System;
using System.Linq;

namespace EF_Repository_UnitOfWork
{
    internal static class UsingPatterns
    {
        private static void Main()
        {
            AppDbContext dbContext = new AppDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);

            // Create
            Author author = new Author() { Name = "Jack" };
            unitOfWork.AuthorRepository.Add(author);
            unitOfWork.Commit();

            // Update
            author = unitOfWork.AuthorRepository.Entities.First(n => n.Name == "Jack");
            author.Name = "Julia";
            unitOfWork.Commit();

            foreach (var item in unitOfWork.AuthorRepository.Entities.Where(n => n.Name.StartsWith("J")))
            {
                Console.WriteLine($"{item.ID} : {item.Name}");
            }

            // Attempt to Delete with Reject all changes in case of I don't want to do this :
            author = unitOfWork.AuthorRepository.Entities.First(n => n.Name == "Dan");
            unitOfWork.AuthorRepository.Remove(author);
            unitOfWork.RejectChanges();

            Console.ReadKey();
        }
    }
}
