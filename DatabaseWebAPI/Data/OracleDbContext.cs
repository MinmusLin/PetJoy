/*
 * Project Name:  DatabaseWebAPI
 * File Name:     OracleDbContext.cs
 * File Function: OracleDbContext 类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-10
 * License:       Creative Commons Attribution 4.0 International License
 */

using DatabaseWebAPI.Models.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DatabaseWebAPI.Data;

public class OracleDbContext(DbContextOptions<OracleDbContext> options) : DbContext(options)
{
    // 配置数据库上下文实体集
    public DbSet<DevelopmentTeam> DevelopmentTeamSet { get; set; }
    public DbSet<News> NewsSet { get; set; }
    public DbSet<NewsComment> NewsCommentSet { get; set; }
    public DbSet<NewsCommentDislike> NewsCommentDislikeSet { get; set; }
    public DbSet<NewsCommentLike> NewsCommentLikeSet { get; set; }
    public DbSet<NewsCommentReport> NewsCommentReportSet { get; set; }
    public DbSet<NewsDislike> NewsDislikeSet { get; set; }
    public DbSet<NewsFavorite> NewsFavoriteSet { get; set; }
    public DbSet<NewsLike> NewsLikeSet { get; set; }
    public DbSet<NewsTag> NewsTagSet { get; set; }
    public DbSet<PetAdoption> PetAdoptionSet { get; set; }
    public DbSet<PetCareGuide> PetCareGuideSet { get; set; }
    public DbSet<PetCategory> PetCategorySet { get; set; }
    public DbSet<PetSubcategory> PetSubcategorySet { get; set; }
    public DbSet<Post> PostSet { get; set; }
    public DbSet<PostCategory> PostCategorySet { get; set; }
    public DbSet<PostComment> PostCommentSet { get; set; }
    public DbSet<PostCommentDislike> PostCommentDislikeSet { get; set; }
    public DbSet<PostCommentLike> PostCommentLikeSet { get; set; }
    public DbSet<PostCommentReport> PostCommentReportSet { get; set; }
    public DbSet<PostDislike> PostDislikeSet { get; set; }
    public DbSet<PostFavorite> PostFavoriteSet { get; set; }
    public DbSet<PostLike> PostLikeSet { get; set; }
    public DbSet<PostReport> PostReportSet { get; set; }
    public DbSet<User> UserSet { get; set; }
    public DbSet<UserCheckIn> UserCheckInSet { get; set; }
    public DbSet<UserFeedback> UserFeedbackSet { get; set; }
    public DbSet<UserFollow> UserFollowSet { get; set; }
    public DbSet<UserMessage> UserMessageSet { get; set; }
    public DbSet<UserSetting> UserSettingSet { get; set; }

    // 重写 OnModelCreating 方法
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 配置复合主键
        modelBuilder.Entity<NewsCommentDislike>().HasKey(n => new { n.CommentId, n.UserId });
        modelBuilder.Entity<NewsCommentLike>().HasKey(n => new { n.CommentId, n.UserId });
        modelBuilder.Entity<NewsDislike>().HasKey(n => new { n.NewsId, n.UserId });
        modelBuilder.Entity<NewsFavorite>().HasKey(n => new { n.NewsId, n.UserId });
        modelBuilder.Entity<NewsLike>().HasKey(n => new { n.NewsId, n.UserId });
        modelBuilder.Entity<PostCommentDislike>().HasKey(n => new { n.CommentId, n.UserId });
        modelBuilder.Entity<PostCommentLike>().HasKey(n => new { n.CommentId, n.UserId });
        modelBuilder.Entity<PostDislike>().HasKey(n => new { n.PostId, n.UserId });
        modelBuilder.Entity<PostFavorite>().HasKey(n => new { n.PostId, n.UserId });
        modelBuilder.Entity<PostLike>().HasKey(n => new { n.PostId, n.UserId });
        modelBuilder.Entity<UserFollow>().HasKey(n => new { n.UserId, n.FollowerId });

        // 配置 NEWS_COMMENT_REPORT 与 USER 的关系
        modelBuilder.Entity<NewsCommentReport>()
            .HasOne(n => n.Reporter)
            .WithMany(u => u.NewsCommentReportEntityReporter)
            .HasForeignKey(n => n.ReporterId);
        modelBuilder.Entity<NewsCommentReport>()
            .HasOne(n => n.ReportedUser)
            .WithMany(u => u.NewsCommentReportEntityReportedUser)
            .HasForeignKey(n => n.ReportedUserId);

        // 配置 POST_COMMENT_REPORT 与 USER 的关系
        modelBuilder.Entity<PostCommentReport>()
            .HasOne(n => n.Reporter)
            .WithMany(u => u.PostCommentReportEntityReporter)
            .HasForeignKey(n => n.ReporterId);
        modelBuilder.Entity<PostCommentReport>()
            .HasOne(n => n.ReportedUser)
            .WithMany(u => u.PostCommentReportEntityReportedUser)
            .HasForeignKey(n => n.ReportedUserId);

        // 配置 POST_REPORT 与 USER 的关系
        modelBuilder.Entity<PostReport>()
            .HasOne(n => n.Reporter)
            .WithMany(u => u.PostReportEntityReporter)
            .HasForeignKey(n => n.ReporterId);
        modelBuilder.Entity<PostReport>()
            .HasOne(n => n.ReportedUser)
            .WithMany(u => u.PostReportEntityReportedUser)
            .HasForeignKey(n => n.ReportedUserId);

        // 配置 USER_FOLLOW 与 USER 的关系
        modelBuilder.Entity<UserFollow>()
            .HasOne(n => n.User)
            .WithMany(u => u.UserFollowEntityUser)
            .HasForeignKey(n => n.UserId);
        modelBuilder.Entity<UserFollow>()
            .HasOne(n => n.Follower)
            .WithMany(u => u.UserFollowEntityFollower)
            .HasForeignKey(n => n.FollowerId);

        // 配置 USER_MESSAGE 与 USER 的关系
        modelBuilder.Entity<UserMessage>()
            .HasOne(n => n.User)
            .WithMany(u => u.UserMessageEntityUser)
            .HasForeignKey(n => n.UserId);
        modelBuilder.Entity<UserMessage>()
            .HasOne(n => n.Commenter)
            .WithMany(u => u.UserMessageEntityCommenter)
            .HasForeignKey(n => n.CommenterId);
    }
}