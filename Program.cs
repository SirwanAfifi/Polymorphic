using System;
using System.Linq;
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
            // dbContext.Articles.Add(new Article {
            //     Title = $"Article A", 
            //     Slug = $"article_a", 
            //     Description = "No desc", 
            // });
            // dbContext.Videos.Add(new Video {
            //     Url = $"https://example.com/video_1.mp4",
            //     Description = "Nodesc",
            // });
            // dbContext.Events.Add(new Event {
            //     Name = "Event A",
            //     Start = DateTimeOffset.Now,
            //     End = DateTimeOffset.Now.AddDays(10),
            // });
            // foreach (var item in Enumerable.Range(1, 10))
            // {
            //     dbContext.Comments.Add(new Comment
            //     {
            //         CommentText = faker.Lorem.Paragraph(1), User = faker.Internet.UserName(),
            //         CommentType = CommentType.Article, TypeId = 1
            //     });
            //     
            //     dbContext.Comments.Add(new Comment
            //     {
            //         CommentText = faker.Lorem.Paragraph(1), User = faker.Internet.UserName(),
            //         CommentType = CommentType.Video, TypeId = 1
            //     });
            //     
            //     dbContext.Comments.Add(new Comment
            //     {
            //         CommentText = faker.Lorem.Paragraph(1), User = faker.Internet.UserName(),
            //         CommentType = CommentType.Event, TypeId = 1
            //     });
            // }
            //
            // dbContext.SaveChanges();

            var article = dbContext.Articles.Find(1);
            
            article.Comments = dbContext.Comments
                .Where(c => c.TypeId == article.Id
                            && c.CommentType == CommentType.Article)
                .ToList();
            
            foreach (var comment in article.Comments)
                comment.Parent = article;

            foreach (var comment in article.Comments)
            {
                Console.WriteLine($"{comment.User} - ${comment.CommentText} - {((Article) comment.Parent).Title}");
            }
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>();
        }
    }
}