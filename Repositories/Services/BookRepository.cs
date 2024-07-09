using Book_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Management.Repositories.Services
{
    public class BookRepository : IbookInterface
    {
        private readonly BookmanagementContext dataContext;

        public BookRepository(BookmanagementContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Book> Addbook(Book data)
        {
            var result = await dataContext.Books.AddAsync(data);
            await dataContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<bool> Deletebook(int id)
        {
            var book = await dataContext.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            dataContext.Books.Remove(book);
            await dataContext.SaveChangesAsync();
            return true;
        }
        public async Task<Book> Getbook(int id)
        {
            var data= await dataContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if(data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Book> Updatebook(Book book)
        {
            dataContext.Entry(book).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
            return book;
        }


        public async Task<IEnumerable<Book>> FilterBooks(string genre, string author)
        {
            return await dataContext.Books
                 .Where(b => (string.IsNullOrEmpty(genre) || b.Genre == genre) &&
                             (string.IsNullOrEmpty(author) || b.Author == author))
                 .ToListAsync();
        }

        public async Task<IEnumerable<Book>> Getbooks()
        {
              return await dataContext.Books.ToListAsync();
        }

       
    }
}
