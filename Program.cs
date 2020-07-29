using System;
using System.Collections.Generic;
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

            var article = new Article
            {
                Title = "Article A",
                Slug = "article_a",
                Description = "No Description"
            };
            var comment = new Comment
            {
                CommentText = "It's great",
                User = "Sirwan"
            };
            dbContext.ArticleComments.Add(new ArticleComment
            {
                Article = article,
                Comment = comment
            });

            dbContext.SaveChanges();
            
            var articleOne = dbContext.Articles
                .Include(article => article.ArticleComments)
                .ThenInclude(comment => comment.Comment)
                .First(article => article.Id == 1);
            var article1Comments = articleOne.ArticleComments.Select(x => x.Comment);
            Console.WriteLine(article1Comments.Count());

        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>();
        }
    }
}