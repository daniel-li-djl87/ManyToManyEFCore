using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractExampleV2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {

                //Transactions in EF Core
                //Swapping authors of 2 posts
                using (var transaction = db.Database.BeginTransaction())
                {
                    Post p1 = db.Posts.Where(p => p.Title.Equals("Rick's 1st Post")).Include(x => x.Author).Single();
                    Author a1 = p1.Author;
                    Post p2 = db.Posts.Where(p => p.Title.Equals("Max's 1st Post")).Include(x => x.Author).Single();
                    Author a2 = p2.Author;

                    p1.Author = a2;
                    db.SaveChanges();
                    p2.Author = a1;
                    db.SaveChanges();
                    transaction.Commit();
                }

                //Query for getting authors in Fb.com that have a 3 letter name
                //The many-to-many relationship adds an extra layer (because of BlogPost) of .Include when it comes to querying
                List<BlogPost> BlogPosts = db.Blogs.Include(z => z.BlogPosts).ThenInclude(t => t.Post).ThenInclude(v => v.Author).Where(x => x.Url.Equals("Fb.com")).Single().BlogPosts.Where(y => y.Post.Author.Name.Length == 3).ToList();

                foreach (BlogPost bp in BlogPosts)
                {
                    Console.WriteLine("An author with a 3 letter name in " + bp.Blog.Url + " is " + bp.Post.Author.Name);
                }

                //Output all the elements in DbSets
                List<BlogPost> blogPosts = db.BlogPosts.Include(blgpst => blgpst.Blog).Include(blgpst => blgpst.Post).ThenInclude(p => p.Author).ToList();

                foreach (BlogPost bp in blogPosts)
                {
                    Console.WriteLine(bp.Blog.Url + " has post: " + bp.Post.Title + " written by: " + bp.Post.Author.Name);
                }

                ////Accessing blogs that author has written in via BlogPost object
                foreach (Author a in db.Authors)
                {
                    if (a.Post == null)
                    {
                        Console.WriteLine(a.Name + " hasn't written anything");
                    }
                    else
                    {
                        Console.WriteLine(a.Name + " wrote: " + a.Post.Title + " in blog(s)");
                        foreach (BlogPost bp in db.BlogPosts.Where(bp2 => bp2.PostId == a.PostId).ToList())
                        {
                            Console.WriteLine("     " + bp.Blog.Url);
                        }
                    }
                }

                //Accessing authors that have written in a blog via BlogPost object
                foreach (Blog b in db.Blogs)
                {
                    Console.WriteLine("Authors that have written in: " + b.Url + " are ");
                    foreach (BlogPost bp in db.BlogPosts.Where(bp3 => bp3.Blog.Url.Equals(b.Url)).ToList())
                    {
                        Console.WriteLine(bp.Post.Author.Name);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
