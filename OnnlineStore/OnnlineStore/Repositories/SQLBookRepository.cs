using Microsoft.EntityFrameworkCore;
using OnnlineStore.Controllers;
using OnnlineStore.Data;
using OnnlineStore.Models.Domain;

namespace OnnlineStore.Repositories
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly OnlineStoreDbContext _dbContext;
        public SQLBookRepository(OnlineStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> DeleteAsync(Guid Id)
        {
            var existingBook = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingBook == null)
            {
                return null;
            }

            _dbContext.Books.Remove(existingBook);
            await _dbContext.SaveChangesAsync();
            return existingBook;
        }

        

     

        public async Task<List<Book>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
        {
            var books = _dbContext.Books.Include(x => x.Author).Include(x => x.Category).AsQueryable();

            //filter

            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {

                if (filterOn.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    books = books.Where(x => x.Title.Contains(filterQuery));
                }

            }

            //sort

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if(sortBy.Equals("Price" , StringComparison.OrdinalIgnoreCase))
                {
                    books = isAscending ? books.OrderBy(x => x.Price) : books.OrderByDescending(x => x.Price);
                }
            }
            return await books.ToListAsync();
        }

        public async Task<Book?> GetAsync(Guid Id)
        {
            return await _dbContext.Books.Include(x => x.Author).Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Book?> UpdateAsync(Guid Id, Book book)
        {
            var existingBook = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingBook == null) {
            
            return null;
            }

            
            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.Price = book.Price;
            existingBook.CoverImageUrl = book.CoverImageUrl;
            existingBook.AuthorId = book.AuthorId;
            existingBook.CategoryId = book.CategoryId;

            await _dbContext.SaveChangesAsync();
            return existingBook;
            

        }

        
    }
}
