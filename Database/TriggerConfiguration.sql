/*
 * Project Name:  Database
 * File Name:     TriggerConfiguration.sql
 * File Function: 触发器配置 SQL 代码
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-15
 * License:       MIT License
 */

-- 向用户打卡表插入记录：增加经验点数
CREATE OR REPLACE TRIGGER increment_experience_points
AFTER INSERT ON USER_CHECK_IN
FOR EACH ROW
BEGIN
    -- 增加用户的经验点数
    UPDATE "USER"
    SET experience_points = experience_points + 100
    WHERE user_id = :NEW.user_id;
END;

-- 从用户打卡表删除记录：减少经验点数
CREATE OR REPLACE TRIGGER decrement_experience_points
AFTER DELETE ON USER_CHECK_IN
FOR EACH ROW
BEGIN
    -- 减少用户的经验点数
    UPDATE "USER"
    SET experience_points = experience_points - 100
    WHERE user_id = :OLD.user_id;
END;

-- 向用户关注表插入记录：增加关注数和被关注数
CREATE OR REPLACE TRIGGER increment_follow_counts
AFTER INSERT ON USER_FOLLOW
FOR EACH ROW
BEGIN
    -- 增加关注者的关注数
    UPDATE "USER"
    SET follows_count = follows_count + 1
    WHERE user_id = :NEW.follower_id;

    -- 增加被关注者的被关注数
    UPDATE "USER"
    SET followed_count = followed_count + 1
    WHERE user_id = :NEW.user_id;
END;

-- 从用户关注表删除记录：减少关注数和被关注数
CREATE OR REPLACE TRIGGER decrement_follow_counts
AFTER DELETE ON USER_FOLLOW
FOR EACH ROW
BEGIN
    -- 减少关注者的关注数
    UPDATE "USER"
    SET follows_count = follows_count - 1
    WHERE user_id = :OLD.follower_id;

    -- 减少被关注者的被关注数
    UPDATE "USER"
    SET followed_count = followed_count - 1
    WHERE user_id = :OLD.user_id;
END;

-- 向用户留言表插入记录：增加留言数
CREATE OR REPLACE TRIGGER increment_message_counts
AFTER INSERT ON USER_MESSAGE
FOR EACH ROW
BEGIN
    -- 增加用户的留言数
    UPDATE "USER"
    SET message_count = message_count + 1
    WHERE user_id = :NEW.user_id;
END;

-- 从用户留言表删除记录：减少留言数
CREATE OR REPLACE TRIGGER decrement_message_counts
AFTER DELETE ON USER_MESSAGE
FOR EACH ROW
BEGIN
    -- 减少用户的留言数
    UPDATE "USER"
    SET message_count = message_count - 1
    WHERE user_id = :OLD.user_id;
END;

-- 向帖子评论表插入记录：增加评论数
CREATE OR REPLACE TRIGGER increment_post_c_count
AFTER INSERT ON POST_COMMENT
FOR EACH ROW
BEGIN
    -- 增加帖子的评论数
    UPDATE POST
    SET comment_count = comment_count + 1
    WHERE post_id = :NEW.post_id;
END;

-- 从帖子评论表删除记录：减少评论数
CREATE OR REPLACE TRIGGER decrement_post_c_count
AFTER DELETE ON POST_COMMENT
FOR EACH ROW
BEGIN
    -- 减少帖子的评论数
    UPDATE POST
    SET comment_count = comment_count - 1
    WHERE post_id = :OLD.post_id;
END;

-- 向帖子点赞表插入记录：增加点赞数和被点赞数
CREATE OR REPLACE TRIGGER increment_post_like_counts
AFTER INSERT ON POST_LIKE
FOR EACH ROW
DECLARE
    poster_user_id INT;
BEGIN
    -- 增加帖子的点赞数
    UPDATE POST
    SET like_count = like_count + 1
    WHERE post_id = :NEW.post_id;

    -- 查找发帖用户 ID
    SELECT user_id INTO poster_user_id
    FROM POST
    WHERE post_id = :NEW.post_id;

    -- 增加发帖用户的被点赞数
    UPDATE "USER"
    SET liked_count = liked_count + 1
    WHERE user_id = poster_user_id;

    -- 增加用户的点赞数
    UPDATE "USER"
    SET likes_count = likes_count + 1
    WHERE user_id = :NEW.user_id;
END;

-- 从帖子点赞表删除记录：减少点赞数和被点赞数
CREATE OR REPLACE TRIGGER decrement_post_like_counts
AFTER DELETE ON POST_LIKE
FOR EACH ROW
DECLARE
    poster_user_id INT;
BEGIN
    -- 减少帖子的点赞数
    UPDATE POST
    SET like_count = like_count - 1
    WHERE post_id = :OLD.post_id;

    -- 查找发帖用户 ID
    SELECT user_id INTO poster_user_id
    FROM POST
    WHERE post_id = :OLD.post_id;

    -- 减少发帖用户的被点赞数
    UPDATE "USER"
    SET liked_count = liked_count - 1
    WHERE user_id = poster_user_id;

    -- 减少用户的点赞数
    UPDATE "USER"
    SET likes_count = likes_count - 1
    WHERE user_id = :OLD.user_id;
END;

-- 向帖子点踩表插入记录：增加点踩数
CREATE OR REPLACE TRIGGER increment_post_dislike_count
AFTER INSERT ON POST_DISLIKE
FOR EACH ROW
BEGIN
    -- 增加帖子的点踩数
    UPDATE POST
    SET dislike_count = dislike_count + 1
    WHERE post_id = :NEW.post_id;
END;

-- 从帖子点踩表删除记录：减少点踩数
CREATE OR REPLACE TRIGGER decrement_post_dislike_count
AFTER DELETE ON POST_DISLIKE
FOR EACH ROW
BEGIN
    -- 减少帖子的点踩数
    UPDATE POST
    SET dislike_count = dislike_count - 1
    WHERE post_id = :OLD.post_id;
END;

-- 向帖子评论点赞表插入记录：增加点赞数和被点赞数
CREATE OR REPLACE TRIGGER increment_post_c_like_counts
AFTER INSERT ON POST_COMMENT_LIKE
FOR EACH ROW
DECLARE
    commenter_user_id INT;
BEGIN
    -- 增加帖子评论的点赞数
    UPDATE POST_COMMENT
    SET like_count = like_count + 1
    WHERE comment_id = :NEW.comment_id;

    -- 查找发布帖子评论用户 ID
    SELECT user_id INTO commenter_user_id
    FROM POST_COMMENT
    WHERE comment_id = :NEW.comment_id;

    -- 增加发布帖子评论用户的被点赞数
    UPDATE "USER"
    SET liked_count = liked_count + 1
    WHERE user_id = commenter_user_id;

    -- 增加用户的点赞数
    UPDATE "USER"
    SET likes_count = likes_count + 1
    WHERE user_id = :NEW.user_id;
END;

-- 从帖子评论点赞表删除记录：减少点赞数和被点赞数
CREATE OR REPLACE TRIGGER decrement_post_c_like_counts
AFTER DELETE ON POST_COMMENT_LIKE
FOR EACH ROW
DECLARE
    commenter_user_id INT;
BEGIN
    -- 减少帖子评论的点赞数
    UPDATE POST_COMMENT
    SET like_count = like_count - 1
    WHERE comment_id = :OLD.comment_id;

    -- 查找发布帖子评论用户 ID
    SELECT user_id INTO commenter_user_id
    FROM POST_COMMENT
    WHERE comment_id = :OLD.comment_id;

    -- 减少发布帖子评论用户的被点赞数
    UPDATE "USER"
    SET liked_count = liked_count - 1
    WHERE user_id = commenter_user_id;

    -- 减少用户的点赞数
    UPDATE "USER"
    SET likes_count = likes_count - 1
    WHERE user_id = :OLD.user_id;
END;

-- 向帖子评论点踩表插入记录：增加点踩数
CREATE OR REPLACE TRIGGER increment_post_c_dislike_count
AFTER INSERT ON POST_COMMENT_DISLIKE
FOR EACH ROW
BEGIN
    -- 增加帖子评论的点踩数
    UPDATE POST_COMMENT
    SET dislike_count = dislike_count + 1
    WHERE comment_id = :NEW.comment_id;
END;

-- 从帖子评论点踩表删除记录：减少点踩数
CREATE OR REPLACE TRIGGER decrement_post_c_dislike_count
AFTER DELETE ON POST_COMMENT_DISLIKE
FOR EACH ROW
BEGIN
    -- 减少帖子评论的点踩数
    UPDATE POST_COMMENT
    SET dislike_count = dislike_count - 1
    WHERE comment_id = :OLD.comment_id;
END;

-- 向帖子收藏表插入记录：增加收藏数和被收藏数
CREATE OR REPLACE TRIGGER increment_post_favorite_counts
AFTER INSERT ON POST_FAVORITE
FOR EACH ROW
DECLARE
    poster_user_id INT;
BEGIN
    -- 增加帖子的收藏数
    UPDATE POST
    SET favorite_count = favorite_count + 1
    WHERE post_id = :NEW.post_id;

    -- 查找发帖用户 ID
    SELECT user_id INTO poster_user_id
    FROM POST
    WHERE post_id = :NEW.post_id;

    -- 增加发帖用户的被收藏数
    UPDATE "USER"
    SET favorited_count = favorited_count + 1
    WHERE user_id = poster_user_id;

    -- 增加用户的的收藏数
    UPDATE "USER"
    SET favorites_count = favorites_count + 1
    WHERE user_id = :NEW.user_id;
END;

-- 从帖子收藏表删除记录：减少收藏数和被收藏数
CREATE OR REPLACE TRIGGER decrement_post_favorite_counts
AFTER DELETE ON POST_FAVORITE
FOR EACH ROW
DECLARE
    poster_user_id INT;
BEGIN
    -- 减少帖子的收藏数
    UPDATE POST
    SET favorite_count = favorite_count - 1
    WHERE post_id = :OLD.post_id;

    -- 查找发帖用户 ID
    SELECT user_id INTO poster_user_id
    FROM POST
    WHERE post_id = :OLD.post_id;

    -- 减少发帖用户的被收藏数
    UPDATE "USER"
    SET favorited_count = favorited_count - 1
    WHERE user_id = poster_user_id;

    -- 减少用户的的收藏数
    UPDATE "USER"
    SET favorites_count = favorites_count - 1
    WHERE user_id = :OLD.user_id;
END;

-- 向新闻评论表插入记录：增加评论数
CREATE OR REPLACE TRIGGER increment_news_c_count
AFTER INSERT ON NEWS_COMMENT
FOR EACH ROW
BEGIN
    -- 增加新闻的评论数
    UPDATE NEWS
    SET comment_count = comment_count + 1
    WHERE news_id = :NEW.news_id;
END;

-- 从新闻评论表删除记录：减少评论数
CREATE OR REPLACE TRIGGER decrement_news_c_count
AFTER DELETE ON NEWS_COMMENT
FOR EACH ROW
BEGIN
    -- 减少新闻的评论数
    UPDATE NEWS
    SET comment_count = comment_count - 1
    WHERE news_id = :OLD.news_id;
END;

-- 向新闻点赞表插入记录：增加点赞数和被点赞数
CREATE OR REPLACE TRIGGER increment_news_like_counts
AFTER INSERT ON NEWS_LIKE
FOR EACH ROW
DECLARE
    news_owner_id INT;
BEGIN
    -- 增加新闻的点赞数
    UPDATE NEWS
    SET like_count = like_count + 1
    WHERE news_id = :NEW.news_id;

    -- 查找管理员 ID
    SELECT user_id INTO news_owner_id
    FROM NEWS
    WHERE news_id = :NEW.news_id;

    -- 增加管理员的被点赞数
    UPDATE "USER"
    SET liked_count = liked_count + 1
    WHERE user_id = news_owner_id;

    -- 增加用户的点赞数
    UPDATE "USER"
    SET likes_count = likes_count + 1
    WHERE user_id = :NEW.user_id;
END;

-- 从新闻点赞表删除记录：减少点赞数和被点赞数
CREATE OR REPLACE TRIGGER decrement_news_like_counts
AFTER DELETE ON NEWS_LIKE
FOR EACH ROW
DECLARE
    news_owner_id INT;
BEGIN
    -- 减少新闻的点赞数
    UPDATE NEWS
    SET like_count = like_count - 1
    WHERE news_id = :OLD.news_id;

    -- 查找管理员 ID
    SELECT user_id INTO news_owner_id
    FROM NEWS
    WHERE news_id = :OLD.news_id;

    -- 减少管理员的被点赞数
    UPDATE "USER"
    SET liked_count = liked_count - 1
    WHERE user_id = news_owner_id;

    -- 减少用户的点赞数
    UPDATE "USER"
    SET likes_count = likes_count - 1
    WHERE user_id = :OLD.user_id;
END;

-- 向新闻点踩表插入记录：增加点踩数
CREATE OR REPLACE TRIGGER increment_news_dislike_count
AFTER INSERT ON NEWS_DISLIKE
FOR EACH ROW
BEGIN
    -- 增加新闻的点踩数
    UPDATE NEWS
    SET dislike_count = dislike_count + 1
    WHERE news_id = :NEW.news_id;
END;

-- 从新闻点踩表删除记录：减少点踩数
CREATE OR REPLACE TRIGGER decrement_news_dislike_count
AFTER DELETE ON NEWS_DISLIKE
FOR EACH ROW
BEGIN
    -- 减少新闻的点踩数
    UPDATE NEWS
    SET dislike_count = dislike_count - 1
    WHERE news_id = :OLD.news_id;
END;

-- 向新闻评论点赞表插入记录：增加点赞数和被点赞数
CREATE OR REPLACE TRIGGER increment_news_c_like_counts
AFTER INSERT ON NEWS_COMMENT_LIKE
FOR EACH ROW
DECLARE
    comment_user_id INT;
BEGIN
    -- 增加新闻评论的点赞数
    UPDATE NEWS_COMMENT
    SET like_count = like_count + 1
    WHERE comment_id = :NEW.comment_id;

    -- 查找发布新闻评论用户 ID
    SELECT user_id INTO comment_user_id
    FROM NEWS_COMMENT
    WHERE comment_id = :NEW.comment_id;

    -- 增加发布新闻评论用户的被点赞数
    UPDATE "USER"
    SET liked_count = liked_count + 1
    WHERE user_id = comment_user_id;

    -- 增加用户的点赞数
    UPDATE "USER"
    SET likes_count = likes_count + 1
    WHERE user_id = :NEW.user_id;
END;

-- 从新闻评论点赞表删除记录：减少点赞数和被点赞数
CREATE OR REPLACE TRIGGER decrement_news_c_like_counts
AFTER DELETE ON NEWS_COMMENT_LIKE
FOR EACH ROW
DECLARE
    comment_user_id INT;
BEGIN
    -- 减少新闻评论的点赞数
    UPDATE NEWS_COMMENT
    SET like_count = like_count - 1
    WHERE comment_id = :OLD.comment_id;

    -- 查找发布新闻评论用户 ID
    SELECT user_id INTO comment_user_id
    FROM NEWS_COMMENT
    WHERE comment_id = :OLD.comment_id;

    -- 减少发布新闻评论用户的被点赞数
    UPDATE "USER"
    SET liked_count = liked_count - 1
    WHERE user_id = comment_user_id;

    -- 减少用户的点赞数
    UPDATE "USER"
    SET likes_count = likes_count - 1
    WHERE user_id = :OLD.user_id;
END;

-- 向新闻评论点踩表插入记录：增加点踩数
CREATE OR REPLACE TRIGGER increment_news_c_dislike_count
AFTER INSERT ON NEWS_COMMENT_DISLIKE
FOR EACH ROW
BEGIN
    -- 增加新闻评论的点踩数
    UPDATE NEWS_COMMENT
    SET dislike_count = dislike_count + 1
    WHERE comment_id = :NEW.comment_id;
END;

-- 从新闻评论点踩表删除记录：减少点踩数
CREATE OR REPLACE TRIGGER decrement_news_c_dislike_count
AFTER DELETE ON NEWS_COMMENT_DISLIKE
FOR EACH ROW
BEGIN
    -- 减少新闻评论点踩数
    UPDATE NEWS_COMMENT
    SET dislike_count = dislike_count - 1
    WHERE comment_id = :OLD.comment_id;
END;

-- 向新闻收藏表插入记录：增加收藏数和被收藏数
CREATE OR REPLACE TRIGGER increment_news_favorite_counts
AFTER INSERT ON NEWS_FAVORITE
FOR EACH ROW
DECLARE
    news_owner_id INT;
BEGIN
    -- 增加新闻的收藏数
    UPDATE NEWS
    SET favorite_count = favorite_count + 1
    WHERE news_id = :NEW.news_id;

    -- 查找管理员 ID
    SELECT user_id INTO news_owner_id
    FROM NEWS
    WHERE news_id = :NEW.news_id;

    -- 增加管理员的被收藏数
    UPDATE "USER"
    SET favorited_count = favorited_count + 1
    WHERE user_id = news_owner_id;

    -- 增加用户的收藏数
    UPDATE "USER"
    SET favorites_count = favorites_count + 1
    WHERE user_id = :NEW.user_id;
END;

-- 从新闻收藏表删除记录：减少收藏数和被收藏数
CREATE OR REPLACE TRIGGER decrement_news_favorite_counts
AFTER DELETE ON NEWS_FAVORITE
FOR EACH ROW
DECLARE
    news_owner_id INT;
BEGIN
    -- 减少新闻的收藏数
    UPDATE NEWS
    SET favorite_count = favorite_count - 1
    WHERE news_id = :OLD.news_id;

    -- 查找管理员 ID
    SELECT user_id INTO news_owner_id
    FROM NEWS
    WHERE news_id = :OLD.news_id;

    -- 减少管理员的被收藏数
    UPDATE "USER"
    SET favorited_count = favorited_count - 1
    WHERE user_id = news_owner_id;

    -- 减少用户的收藏数
    UPDATE "USER"
    SET favorites_count = favorites_count - 1
    WHERE user_id = :OLD.user_id;
END;

-- 用户注册时向用户设置表插入记录
CREATE OR REPLACE TRIGGER add_user_setting_after_insert
AFTER INSERT ON "USER"
FOR EACH ROW
BEGIN
    INSERT INTO USER_SETTING (
        user_id,
        is_telephone_public,
        is_registration_date_public,
        is_profile_public,
        is_gender_public,
        is_birthdate_public,
        is_level_public,
        is_following_count_public,
        is_followers_count_public,
        is_favorites_count_public,
        is_favored_count_public,
        is_likes_count_public,
        is_liked_count_public,
        is_message_count_public,
        allow_following,
        receive_admin_notifications,
        receive_user_notifications
    ) VALUES (
        :NEW.user_id,
        0,  -- is_telephone_public
        1,  -- is_registration_date_public
        1,  -- is_profile_public
        1,  -- is_gender_public
        0,  -- is_birthdate_public
        1,  -- is_level_public
        1,  -- is_following_count_public
        1,  -- is_followers_count_public
        1,  -- is_favorites_count_public
        1,  -- is_favored_count_public
        1,  -- is_likes_count_public
        1,  -- is_liked_count_public
        1,  -- is_message_count_public
        1,  -- allow_following
        1,  -- receive_admin_notifications
        1   -- receive_user_notifications
    );
END;