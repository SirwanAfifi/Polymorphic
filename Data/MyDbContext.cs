using Microsoft.EntityFrameworkCore;
using Polymorphic.Models;

namespace Polymorphic.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoComment> VideoComments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventComment> EventComments { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=polymorphic.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleComment>(entity =>
            {
                entity.HasKey(e => new { e.CommentId, e.ArticleId })
                    .HasName("PK_dbo.ArticleComments");

                entity.HasIndex(e => e.ArticleId)
                    .HasName("IX_ArticleId");

                entity.HasIndex(e => e.CommentId)
                    .HasName("IX_ArticleCommentId");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleComments)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_dbo.ArticleComments_dbo.Articles_ArticleId");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.ArticleComments)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_dbo.ArticleComments_dbo.Comments_CommentId");
            });
            
            modelBuilder.Entity<VideoComment>(entity =>
            {
                entity.HasKey(e => new { e.CommentId, e.VideoId })
                    .HasName("PK_dbo.VideoComments");

                entity.HasIndex(e => e.VideoId)
                    .HasName("IX_VideoId");

                entity.HasIndex(e => e.CommentId)
                    .HasName("IX_VideoCommentId");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.VideoComments)
                    .HasForeignKey(d => d.VideoId)
                    .HasConstraintName("FK_dbo.VideoComments_dbo.Videos_VideoId");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.VideoComments)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_dbo.VideoComments_dbo.Comments_CommentId");
            });
            
            modelBuilder.Entity<EventComment>(entity =>
            {
                entity.HasKey(e => new { e.CommentId, e.EventId })
                    .HasName("PK_dbo.EventComments");

                entity.HasIndex(e => e.EventId)
                    .HasName("IX_EventId");

                entity.HasIndex(e => e.CommentId)
                    .HasName("IX_EventCommentId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventComments)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_dbo.EventComments_dbo.Events_EventId");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.EventComments)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_dbo.EventComments_dbo.Comments_CommentId");
            });
        }
    }
}