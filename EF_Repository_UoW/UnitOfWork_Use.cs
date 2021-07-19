using System.Collections.Generic;

namespace EF_Repository_UoW
{
    public class UnitOfWork_Use
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<BookAndroid> GetAll()
        {
            return unitOfWork.Books.GetAll();
        }

        public void Create(BookAndroid b)
        {
            unitOfWork.Books.Create(b);
            unitOfWork.Save();
        }

        public void Update(BookAndroid b)
        {
            unitOfWork.Books.Update(b);
            unitOfWork.Save();
        }

        protected void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            Dispose(disposing);
        }
    }
}
