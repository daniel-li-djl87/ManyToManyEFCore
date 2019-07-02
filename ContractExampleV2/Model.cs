using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractExampleV2
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ContractExampleV2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasKey(bp => new { bp.BlogId, bp.PostId });
            modelBuilder.Entity<BlogPost>()
                .HasOne(bp => bp.Blog)
                .WithMany(b => b.BlogPosts)
                .HasForeignKey(bp => bp.BlogId);
            modelBuilder.Entity<BlogPost>()
                .HasOne(bp => bp.Post)
                .WithMany(p => p.BlogPosts)
                .HasForeignKey(bp => bp.PostId);
        }

    }

    //Many to Many relationship with Post
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
    }

    //Many to Many relationship with Blog
    //Parent to Author, Every post needs an author
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<BlogPost> BlogPosts { get; set; }

        [Required]
        public Author Author { get; set; }
    }

    //Child to Post, optional relationship, doesn't need to have a post
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        //ForeignKey is of type int? because it can be null
        public int? PostId { get; set; }
        public Post Post { get; set; }
    }

    //Entity to represent the join table for Post and Blog many-to-many relationship
    public class BlogPost
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}