using CodeFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            //CreateAndAddSportNews(db);
            //AutomaticJoin(db);
            //UsingLinq(db);
            //UsingLinqSecond(db);
            //ChangeTracker(db);
            //RemoveFromDb(db);

        }

        private static void RemoveFromDb(ApplicationDbContext db)
        {
            var comments = db.Comments;

            foreach (var item in comments)
            {
                db.Comments.Remove(item);
            }
            db.SaveChanges();
        }

        private static void ChangeTracker(ApplicationDbContext db)
        {
            var news = db.News.FirstOrDefault();
            news.Content = "Mani go BG futbola";

            db.SaveChanges();
        }

        private static void UsingLinqSecond(ApplicationDbContext db)
        {
           var currNews = db.News.FirstOrDefault(n => n.Id == 1);
            Console.WriteLine(currNews.CategoryId);
        }

        private static void UsingLinq(ApplicationDbContext db)
        {
            var count = db.Comments.Where(x => x.Author == "Sasho").ToArray();

            Console.WriteLine(count.Length);
        }

        private static void AutomaticJoin(ApplicationDbContext db)
        {
            var news = db.News.Select(x => new
            {
                Name = x.Title,
                CategoryName = x.Category.Title
            });

            foreach (var item in news)
            {
                Console.WriteLine($"{item.CategoryName} => {item.Name}");
            }
        }

        private static void CreateAndAddSportNews(ApplicationDbContext db)
        {
            db.Categories.Add(new Category
            {
                Title = "Sport",
                News = new List<News>
                {
                    new News
                    {
                        Title = "ЦСКА бие Левски",
                        Content = "След двубой изпълнен с пропуски, ЦСКА успя да излъже вечния съперник.",
                        Comments = new List<Comment>
                        {
                            new Comment
                            {
                                Author = "Sasho",
                                Content = "Браво ЦСКА"
                            },
                            new Comment
                            {
                                Author = "Misho",
                                Content = "Само ЦСКА"
                            }
                        }
                    }
                }
            });

            db.SaveChanges();
        }
    }
}
