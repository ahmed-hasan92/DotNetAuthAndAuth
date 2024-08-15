using OnnlineStore.Models.Domain;

namespace OnnlineStore.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync(string? filterOn = null, string? filterQuery=null, string? sortBy = null, bool isAscending=true );
        Task<Book?> GetAsync(Guid Id);

        Task<Book?> DeleteAsync(Guid Id);
        Task<Book> AddAsync(Book book);
        Task<Book?> UpdateAsync(Guid Id,Book book);
    }
}
