using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Polymorphic.Data;
using Polymorphic.Models;

namespace Polymorphic
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<MyDbContext>();

            var faker = new Bogus.Faker();
            
            /*dbContext.Articles.Add(new Article {
                Title = $"Article A", 
                Slug = $"article_a", 
                Description = "No desc", 
                Comments = Enumerable.Range(1, 10).Select(item => new Comment {CommentText = faker.Rant.Review(), User = faker.Internet.UserName()}).ToList()
            });
            
            dbContext.Videos.Add(new Video {
                Url = $"https://example.com/video_1.mp4",
                Description = "Nodesc",
                Comments = Enumerable.Range(1, 10).Select(item => new Comment {CommentText = faker.Lorem.Paragraph(1), User = faker.Internet.UserName()}).ToList()
            });

            dbContext.Events.Add(new Event {
                Name = "Event A",
                Start = DateTimeOffset.Now,
                End = DateTimeOffset.Now.AddDays(10),
                Comments = Enumerable.Range(1, 10).Select(item => new Comment {CommentText = faker.Lorem.Paragraph(1), User = faker.Internet.UserName()}).ToList()
            });

            dbContext.SaveChanges();*/
            
            // Querying
            var articles = dbContext.Articles
                .Include(x => x.Comments).Where(x => x.Id == 1);
            foreach (var article in articles)
            {
                Console.WriteLine($"{article.Title} - Comments: {article.Comments.Count}");
            }
            var comment = dbContext.Comments.Include(x => x.Article)
                .FirstOrDefault(x => x.Id == 1);
            Console.WriteLine(comment?.Article.Title);
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>();
        }
    }
}