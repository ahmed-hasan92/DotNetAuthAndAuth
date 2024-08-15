using Microsoft.EntityFrameworkCore;
using OnnlineStore.Models.Domain;

namespace OnnlineStore.Data
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var author = new List<Author>()
            {
                new Author()
                {
                    Id = Guid.Parse("080b5cb7-b849-40cf-9b90-645cde291033"),
                    Name= "Mark Twain",
                    Biography="Mark Twain was an American writer and humorist known for his novels 'The Adventures of Tom Sawyer' and 'Adventures of Huckleberry Finn."

                },
                  new Author()
                {
                    Id = Guid.Parse("b893780a-45a1-41a3-9144-161864aca2ba"),
                    Name= "Jane Austen",
                    Biography="Jane Austen was an English novelist known for her six major novels including 'Pride and Prejudice' and 'Sense and Sensibility'."

                },
                   new Author()
                {
                    Id = Guid.Parse("83b98008-1cdd-4432-b87e-fc9f7abcaedc"),
                    Name= "J.K. Rowling",
        Biography = "J.K. Rowling is a British author, best known for writing the 'Harry Potter' series which has become one of the best-selling book series in history."

                },
            };
            modelBuilder.Entity<Author>().HasData(author);

            var category = new List<Category>()
            {
                new Category()
                {
                    Id= Guid.Parse("12ab5a40-b795-40ce-b15d-8018422c8577"),
                    Name="Educational"
                },

                new Category()
                {
                    Id= Guid.Parse("f57eaa3d-89eb-4cef-bbe0-2aacc290b439"),
                    Name="Self development"
                },

                  new Category()
                {
                    Id= Guid.Parse("88f9ab88-463b-4c13-bf25-e18b6c480f9c"),
                    Name="Novel"
                },

                    new Category()
                {
                    Id= Guid.Parse("afd1fa53-a0ff-48ef-9704-300ed1837ba4"),
                    Name="Children"
                }
            };

            modelBuilder.Entity<Category>().HasData(category);

            var books = new List<Book>()
            {
                new Book()
                {
                    Id = Guid.Parse("6f5e32e2-b224-4497-9dd8-ab5e0ca5ec8e"),
                    Title = "The Adventures of Tom Sawyer",
                    Description = "A novel by Mark Twain about a young boy's adventures in the American South.",
                    Price = 19.99m,
                    CoverImageUrl = "tom_sawyer.jpg",
                    AuthorId = Guid.Parse("080b5cb7-b849-40cf-9b90-645cde291033"),
                    CategoryId = Guid.Parse("88f9ab88-463b-4c13-bf25-e18b6c480f9c")
                },
                new Book()
                {
                    Id = Guid.Parse("c5de44d9-ceb9-4481-bdfd-ec47a5d25fb3"),
                    Title = "Pride and Prejudice",
                    Description = "A classic novel by Jane Austen exploring themes of love and social class.",
                    Price = 14.99m,
                    CoverImageUrl = "pride_and_prejudice.jpg",
                    AuthorId = Guid.Parse("b893780a-45a1-41a3-9144-161864aca2ba"),
                    CategoryId = Guid.Parse("88f9ab88-463b-4c13-bf25-e18b6c480f9c")
                },
                new Book()
                {
                    Id = Guid.Parse("67375ef5-72d0-4451-ae8f-3f6055edcdd6"),
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Description = "The first book in the Harry Potter series by J.K. Rowling.",
                    Price = 24.99m,
                    CoverImageUrl = "harry_potter.jpg",
                    AuthorId = Guid.Parse("83b98008-1cdd-4432-b87e-fc9f7abcaedc"),
                    CategoryId = Guid.Parse("afd1fa53-a0ff-48ef-9704-300ed1837ba4")
                },
                new Book()
                {
                    Id = Guid.Parse("2eb18ede-7b1b-4d83-b1e4-871cce818c8a"),
                    Title = "The 7 Habits of Highly Effective People",
                    Description = "A self-help book by Stephen R. Covey that provides a principle-centered approach for solving personal and professional problems.",
                    Price = 29.99m,
                    CoverImageUrl = "7_habits.jpg",
                    AuthorId = Guid.Parse("080b5cb7-b849-40cf-9b90-645cde291033"),
                    CategoryId = Guid.Parse("f57eaa3d-89eb-4cef-bbe0-2aacc290b439")
                }
            };
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}
