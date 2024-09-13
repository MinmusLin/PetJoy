/*
 * Project Name:  Database
 * File Name:     DataDefinitionLanguage.sql
 * File Function: 数据定义语言 SQL 代码
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-09-07
 * License:       MIT License
 */

-- 用户表 USER 的数据定义语言
create table "USER"
(
    user_id             INT           GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint USER_pk
            primary key,
    user_name           VARCHAR(64)   not null
        constraint user_name_uk
            unique,
    password            VARCHAR(64)   not null,
    telephone           VARCHAR(16)   not null
        constraint telephone_uk
            unique,
    registration_date   DATE          not null,
    last_login_time     DATE          not null,
    role                NUMBER(1)     not null,
    status              NUMBER(1)     not null,
    avatar_url          VARCHAR(2048),
    profile             VARCHAR(512),
    gender              NUMBER(1)     not null,
    birthdate           DATE          not null,
    experience_points   INT           not null,
    follows_count       INT           not null,
    followed_count      INT           not null,
    favorites_count     INT           not null,
    favorited_count     INT           not null,
    likes_count         INT           not null,
    liked_count         INT           not null,
    message_count       INT           not null
);

comment on table "USER" is '用户';
comment on column "USER".user_id is '用户ID';
comment on column "USER".user_name is '用户名';
comment on column "USER".password is '密码';
comment on column "USER".telephone is '手机号码';
comment on column "USER".registration_date is '注册日期';
comment on column "USER".last_login_time is '上次登录时间';
comment on column "USER".role is '用户角色';
comment on column "USER".status is '用户状态';
comment on column "USER".avatar_url is '头像链接';
comment on column "USER".profile is '个人简介';
comment on column "USER".gender is '性别';
comment on column "USER".birthdate is '出生日期';
comment on column "USER".experience_points is '经验点数';
comment on column "USER".follows_count is '关注数';
comment on column "USER".followed_count is '被关注数';
comment on column "USER".favorites_count is '收藏数';
comment on column "USER".favorited_count is '被收藏数';
comment on column "USER".likes_count is '点赞数';
comment on column "USER".liked_count is '被点赞数';
comment on column "USER".message_count is '留言数';

-- 用户设置表 USER_SETTING 的数据定义语言
create table USER_SETTING
(
    user_id                     INT       not null
        constraint USER_SETTING_pk
            primary key
        constraint USER_SETTING_USER_fk
            references "USER" ON DELETE CASCADE,
    is_telephone_public         NUMBER(1) not null,
    is_registration_date_public NUMBER(1) not null,
    is_profile_public           NUMBER(1) not null,
    is_gender_public            NUMBER(1) not null,
    is_birthdate_public         NUMBER(1) not null,
    is_level_public             NUMBER(1) not null,
    is_following_count_public   NUMBER(1) not null,
    is_followers_count_public   NUMBER(1) not null,
    is_favorites_count_public   NUMBER(1) not null,
    is_favored_count_public     NUMBER(1) not null,
    is_likes_count_public       NUMBER(1) not null,
    is_liked_count_public       NUMBER(1) not null,
    is_message_count_public     NUMBER(1) not null,
    allow_following             NUMBER(1) not null,
    receive_admin_notifications NUMBER(1) not null,
    receive_user_notifications  NUMBER(1) not null
);

comment on table USER_SETTING is '用户设置';
comment on column USER_SETTING.user_id is '用户ID';
comment on column USER_SETTING.is_telephone_public is '是否公开手机号码';
comment on column USER_SETTING.is_registration_date_public is '是否公开注册日期';
comment on column USER_SETTING.is_profile_public is '是否公开个人简介';
comment on column USER_SETTING.is_gender_public is '是否公开性别';
comment on column USER_SETTING.is_birthdate_public is '是否公开出生日期';
comment on column USER_SETTING.is_level_public is '是否公开等级';
comment on column USER_SETTING.is_following_count_public is '是否公开关注数';
comment on column USER_SETTING.is_followers_count_public is '是否公开被关注数';
comment on column USER_SETTING.is_favorites_count_public is '是否公开收藏数';
comment on column USER_SETTING.is_favored_count_public is '是否公开被收藏数';
comment on column USER_SETTING.is_likes_count_public is '是否公开点赞数';
comment on column USER_SETTING.is_liked_count_public is '是否公开被点赞数';
comment on column USER_SETTING.is_message_count_public is '是否公开留言数';
comment on column USER_SETTING.allow_following is '是否允许他人关注';
comment on column USER_SETTING.receive_admin_notifications is '是否接受管理员通知';
comment on column USER_SETTING.receive_user_notifications is '是否接受用户通知';

-- 用户打卡表 USER_CHECK_IN 的数据定义语言
create table USER_CHECK_IN
(
    check_in_id   INT  GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint USER_CHECK_IN_pk
            primary key,
    user_id       INT  not null
        constraint USER_CHECK_IN_USER_fk
            references "USER" ON DELETE CASCADE,
    check_in_time DATE not null
);

comment on table USER_CHECK_IN is '用户打卡';
comment on column USER_CHECK_IN.check_in_id is '打卡记录ID';
comment on column USER_CHECK_IN.user_id is '用户ID';
comment on column USER_CHECK_IN.check_in_time is '打卡时间';

-- 用户关注表 USER_FOLLOW 的数据定义语言
create table USER_FOLLOW
(
    user_id     INT  not null
        constraint USER_FOLLOW_USER_fk_1
            references "USER" ON DELETE CASCADE,
    follower_id INT  not null
        constraint USER_FOLLOW_USER_fk_2
            references "USER" ON DELETE CASCADE,
    follow_time DATE not null,
    constraint USER_FOLLOW_pk
        primary key (user_id, follower_id)
);

comment on table USER_FOLLOW is '用户关注';
comment on column USER_FOLLOW.user_id is '被关注者ID';
comment on column USER_FOLLOW.follower_id is '关注者ID';
comment on column USER_FOLLOW.follow_time is '关注时间';

-- 用户留言表 USER_MESSAGE 的数据定义语言
create table USER_MESSAGE
(
    message_id   INT          GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint USER_MESSAGE_pk
            primary key,
    user_id      INT          not null
        constraint USER_MESSAGE_USER_fk_1
            references "USER" ON DELETE CASCADE,
    commenter_id INT          not null
        constraint USER_MESSAGE_USER_fk_2
            references "USER" ON DELETE CASCADE,
    message      VARCHAR(512) not null,
    comment_time DATE         not null
);

comment on table USER_MESSAGE is '用户留言';
comment on column USER_MESSAGE.message_id is '留言ID';
comment on column USER_MESSAGE.user_id is '用户ID';
comment on column USER_MESSAGE.commenter_id is '留言者ID';
comment on column USER_MESSAGE.message is '留言内容';
comment on column USER_MESSAGE.comment_time is '留言时间';

-- 用户反馈表 USER_FEEDBACK 的数据定义语言
create table USER_FEEDBACK
(
    feedback_id       INTEGER       GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint USER_FEEDBACK_pk
            primary key,
    feedback_category VARCHAR(32)   not null,
    feedback_content  VARCHAR(2048) not null,
    feedback_time     DATE          not null,
    email             VARCHAR(2048),
    telephone         VARCHAR(16)
);

comment on table USER_FEEDBACK is '用户反馈';
comment on column USER_FEEDBACK.feedback_id is '反馈意见ID';
comment on column USER_FEEDBACK.feedback_category is '反馈类型';
comment on column USER_FEEDBACK.feedback_content is '反馈内容';
comment on column USER_FEEDBACK.feedback_time is '反馈时间';
comment on column USER_FEEDBACK.email is '电子邮箱';
comment on column USER_FEEDBACK.telephone is '手机号码';

-- 帖子分类表 POST_CATEGORY 的数据定义语言
create table POST_CATEGORY
(
    category_id INT         not null
        constraint POST_CATEGORY_pk
            primary key,
    category    VARCHAR(64) not null
        constraint post_category_uk
            unique
);

comment on table POST_CATEGORY is '帖子分类';
comment on column POST_CATEGORY.category_id is '帖子分类ID';
comment on column POST_CATEGORY.category is '帖子分类';

-- 帖子表 POST 的数据定义语言
create table POST
(
    post_id        INT           GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint POST_pk
            primary key,
    user_id        INT           not null
        constraint POST_USER_fk
            references "USER" ON DELETE CASCADE,
    category_id    INT           not null
        constraint POST_POST_CATEGORY_fk
            references POST_CATEGORY (category_id) ON DELETE CASCADE,
    title          VARCHAR(256)  not null,
    content        VARCHAR(2048) not null,
    creation_date  DATE          not null,
    update_date    DATE          not null,
    is_sticky      NUMBER(1)     not null,
    like_count     INT           not null,
    dislike_count  INT           not null,
    favorite_count INT           not null,
    comment_count  INT           not null,
    image_url      VARCHAR(2048)
);

comment on table POST is '帖子';
comment on column POST.post_id is '帖子ID';
comment on column POST.user_id is '发帖用户ID';
comment on column POST.category_id is '帖子分类ID';
comment on column POST.title is '标题';
comment on column POST.content is '内容';
comment on column POST.creation_date is '创建时间';
comment on column POST.update_date is '更新时间';
comment on column POST.is_sticky is '是否置顶';
comment on column POST.like_count is '点赞数';
comment on column POST.dislike_count is '点踩数';
comment on column POST.favorite_count is '收藏数';
comment on column POST.comment_count is '评论数';
comment on column POST.image_url is '图片链接';

-- 帖子评论表 POST_COMMENT 的数据定义语言
create table POST_COMMENT
(
    comment_id        INT          GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint POST_COMMENT_pk
            primary key,
    post_id           INT          not null
        constraint POST_COMMENT_POST_fk
            references POST ON DELETE CASCADE,
    user_id           INT          not null
        constraint POST_COMMENT_USER_fk
            references "USER" ON DELETE CASCADE,
    parent_comment_id INT
        constraint POST_COMMENT_POST_COMMENT_fk
            references POST_COMMENT ON DELETE CASCADE,
    content           VARCHAR(512) not null,
    comment_time      DATE         not null,
    like_count        INT          not null,
    dislike_count     INT          not null
);

comment on table POST_COMMENT is '帖子评论';
comment on column POST_COMMENT.comment_id is '帖子评论ID';
comment on column POST_COMMENT.post_id is '帖子ID';
comment on column POST_COMMENT.user_id is '用户ID';
comment on column POST_COMMENT.parent_comment_id is '父评论ID';
comment on column POST_COMMENT.content is '评论内容';
comment on column POST_COMMENT.comment_time is '评论时间';
comment on column POST_COMMENT.like_count is '点赞数';
comment on column POST_COMMENT.dislike_count is '点踩数';

-- 帖子点赞表 POST_LIKE 的数据定义语言
create table POST_LIKE
(
    post_id   INT  not null
        constraint POST_LIKE_POST_fk
            references POST ON DELETE CASCADE,
    user_id   INT  not null
        constraint POST_LIKE_USER_fk
            references "USER" ON DELETE CASCADE,
    like_time DATE not null,
    constraint POST_LIKE_pk
        primary key (post_id, user_id)
);

comment on table POST_LIKE is '帖子点赞';
comment on column POST_LIKE.post_id is '帖子ID';
comment on column POST_LIKE.user_id is '用户ID';
comment on column POST_LIKE.like_time is '点赞时间';

-- 帖子点踩表 POST_DISLIKE 的数据定义语言
create table POST_DISLIKE
(
    post_id      INT  not null
        constraint POST_DISLIKE_POST_fk
            references POST ON DELETE CASCADE,
    user_id      INT  not null
        constraint POST_DISLIKE_USER_fk
            references "USER" ON DELETE CASCADE,
    dislike_time DATE not null,
    constraint POST_DISLIKE_pk
        primary key (post_id, user_id)
);

comment on table POST_DISLIKE is '帖子点踩';
comment on column POST_DISLIKE.post_id is '帖子ID';
comment on column POST_DISLIKE.user_id is '用户ID';
comment on column POST_DISLIKE.dislike_time is '点踩时间';

-- 帖子评论点赞表 POST_COMMENT_LIKE 的数据定义语言
create table POST_COMMENT_LIKE
(
    comment_id INT  not null
        constraint POST_COMMENT_LPC_fk
            references POST_COMMENT ON DELETE CASCADE,
    user_id    INT  not null
        constraint POST_COMMENT_LIKE_USER_fk
            references "USER" ON DELETE CASCADE,
    like_time  DATE not null,
    constraint POST_COMMENT_LIKE_pk
        primary key (comment_id, user_id)
);

comment on table POST_COMMENT_LIKE is '帖子评论点赞';
comment on column POST_COMMENT_LIKE.comment_id is '帖子评论ID';
comment on column POST_COMMENT_LIKE.user_id is '用户ID';
comment on column POST_COMMENT_LIKE.like_time is '点赞时间';

-- 帖子评论点踩表 POST_COMMENT_DISLIKE 的数据定义语言
create table POST_COMMENT_DISLIKE
(
    comment_id   INT  not null
        constraint POST_COMMENT_DPC_fk
            references POST_COMMENT ON DELETE CASCADE,
    user_id      INT  not null
        constraint POST_COMMENT_DISLIKE_USER_fk
            references "USER" ON DELETE CASCADE,
    dislike_time DATE not null,
    constraint POST_COMMENT_DISLIKE_pk
        primary key (comment_id, user_id)
);

comment on table POST_COMMENT_DISLIKE is '帖子评论点踩';
comment on column POST_COMMENT_DISLIKE.comment_id is '帖子评论ID';
comment on column POST_COMMENT_DISLIKE.user_id is '用户ID';
comment on column POST_COMMENT_DISLIKE.dislike_time is '点踩时间';

-- 帖子收藏表 POST_FAVORITE 的数据定义语言
create table POST_FAVORITE
(
    post_id       INT  not null
        constraint POST_FAVORITE_POST_fk
            references POST ON DELETE CASCADE,
    user_id       INT  not null
        constraint POST_FAVORITE_USER_fk
            references "USER" ON DELETE CASCADE,
    favorite_time DATE not null,
    constraint POST_FAVORITE_pk
        primary key (post_id, user_id)
);

comment on table POST_FAVORITE is '帖子收藏';
comment on column POST_FAVORITE.post_id is '帖子ID';
comment on column POST_FAVORITE.user_id is '用户ID';
comment on column POST_FAVORITE.favorite_time is '收藏时间';

-- 帖子举报表 POST_REPORT 的数据定义语言
create table POST_REPORT
(
    post_report_id   INT          GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint POST_REPORT_pk
            primary key,
    reporter_id      INT          not null
        constraint POST_REPORT_USER_fk_1
            references "USER" ON DELETE CASCADE,
    reported_user_id INT          not null
        constraint POST_REPORT_USER_fk_2
            references "USER" ON DELETE CASCADE,
    reported_post_id INT          not null
        constraint POST_REPORT_POST_fk
            references POST ON DELETE CASCADE,
    report_reason    VARCHAR(512) not null,
    report_time      DATE         not null,
    status           NUMBER(1)    not null
);

comment on table POST_REPORT is '帖子举报';
comment on column POST_REPORT.post_report_id is '帖子举报ID';
comment on column POST_REPORT.reporter_id is '举报者ID';
comment on column POST_REPORT.reported_user_id is '被举报者ID';
comment on column POST_REPORT.reported_post_id is '被举报帖子ID';
comment on column POST_REPORT.report_reason is '举报原因';
comment on column POST_REPORT.report_time is '举报时间';
comment on column POST_REPORT.status is '处理状态';

-- 帖子评论举报表 POST_COMMENT_REPORT 的数据定义语言
create table POST_COMMENT_REPORT
(
    post_comment_report_id INT          GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint POST_COMMENT_REPORT_pk
            primary key,
    reporter_id            INT          not null
        constraint POST_COMMENT_REPORT_USER_fk_1
            references "USER" ON DELETE CASCADE,
    reported_user_id       INT          not null
        constraint POST_COMMENT_REPORT_USER_fk_2
            references "USER" ON DELETE CASCADE,
    reported_post_id       INT          not null
        constraint POST_COMMENT_REPORT_POST_fk
            references POST ON DELETE CASCADE,
    reported_comment_id    INT          not null
        constraint POST_COMMENT_REPORT_PC_fk
            references POST_COMMENT ON DELETE CASCADE,
    report_reason          VARCHAR(512) not null,
    report_time            DATE         not null,
    status                 NUMBER(1)    not null
);

comment on table POST_COMMENT_REPORT is '帖子评论举报';
comment on column POST_COMMENT_REPORT.post_comment_report_id is '帖子评论举报ID';
comment on column POST_COMMENT_REPORT.reporter_id is '举报者ID';
comment on column POST_COMMENT_REPORT.reported_user_id is '被举报者ID';
comment on column POST_COMMENT_REPORT.reported_post_id is '被举报评论所属帖子ID';
comment on column POST_COMMENT_REPORT.reported_comment_id is '被举报评论ID';
comment on column POST_COMMENT_REPORT.report_reason is '举报原因';
comment on column POST_COMMENT_REPORT.report_time is '举报时间';
comment on column POST_COMMENT_REPORT.status is '处理状态';

-- 新闻标签表 NEWS_TAG 的数据定义语言
create table NEWS_TAG
(
    tag_id INT         not null
        constraint NEWS_TAG_pk
            primary key,
    tag    VARCHAR(64) not null
        constraint tag_uk
            unique
);

comment on table NEWS_TAG is '新闻标签';
comment on column NEWS_TAG.tag_id is '新闻标签ID';
comment on column NEWS_TAG.tag is '新闻标签';

-- 新闻表 NEWS 的数据定义语言
create table NEWS
(
    news_id        INT           GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint NEWS_pk
            primary key,
    user_id        INT           not null
        constraint NEWS_USER_fk
            references "USER" ON DELETE CASCADE,
    tag_id         INT           not null
        constraint NEWS_NEWS_TAG_fk
            references NEWS_TAG (tag_id) ON DELETE CASCADE,
    title          VARCHAR(256)  not null,
    summary        VARCHAR(512)  not null,
    content        CLOB          not null,
    creation_date  DATE          not null,
    update_date    DATE          not null,
    cover_url      VARCHAR(2048) not null,
    is_sticky      NUMBER(1)     not null,
    like_count     INT           not null,
    dislike_count  INT           not null,
    favorite_count INT           not null,
    comment_count  INT           not null
);

comment on table NEWS is '新闻';
comment on column NEWS.news_id is '新闻ID';
comment on column NEWS.user_id is '管理员ID';
comment on column NEWS.tag_id is '新闻标签ID';
comment on column NEWS.title is '标题';
comment on column NEWS.summary is '新闻摘要';
comment on column NEWS.content is '内容';
comment on column NEWS.creation_date is '创建时间';
comment on column NEWS.update_date is '更新时间';
comment on column NEWS.cover_url is '封面图片链接';
comment on column NEWS.is_sticky is '是否置顶';
comment on column NEWS.like_count is '点赞数';
comment on column NEWS.dislike_count is '点踩数';
comment on column NEWS.favorite_count is '收藏数';
comment on column NEWS.comment_count is '评论数';

-- 新闻评论表 NEWS_COMMENT 的数据定义语言
create table NEWS_COMMENT
(
    comment_id        INT          GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint NEWS_COMMENT_pk
            primary key,
    news_id           INT          not null
        constraint NEWS_COMMENT_NEWS_fk
            references NEWS ON DELETE CASCADE,
    user_id           INT          not null
        constraint NEWS_COMMENT_USER_fk
            references "USER" ON DELETE CASCADE,
    parent_comment_id INT
        constraint NEWS_COMMENT_NEWS_COMMENT_fk
            references NEWS_COMMENT ON DELETE CASCADE,
    content           VARCHAR(512) not null,
    comment_time      DATE         not null,
    like_count        INT          not null,
    dislike_count     INT          not null
);

comment on table NEWS_COMMENT is '新闻评论';
comment on column NEWS_COMMENT.comment_id is '新闻评论ID';
comment on column NEWS_COMMENT.news_id is '新闻ID';
comment on column NEWS_COMMENT.user_id is '用户ID';
comment on column NEWS_COMMENT.parent_comment_id is '父评论ID';
comment on column NEWS_COMMENT.content is '评论内容';
comment on column NEWS_COMMENT.comment_time is '评论时间';
comment on column NEWS_COMMENT.like_count is '点赞数';
comment on column NEWS_COMMENT.dislike_count is '点踩数';

-- 新闻点赞表 NEWS_LIKE 的数据定义语言
create table NEWS_LIKE
(
    news_id   INT  not null
        constraint NEWS_LIKE_NEWS_fk
            references NEWS ON DELETE CASCADE,
    user_id   INT  not null
        constraint NEWS_LIKE_USER_fk
            references "USER" ON DELETE CASCADE,
    like_time DATE not null,
    constraint NEWS_LIKE_pk
        primary key (news_id, user_id)
);

comment on table NEWS_LIKE is '新闻点赞';
comment on column NEWS_LIKE.news_id is '新闻ID';
comment on column NEWS_LIKE.user_id is '用户ID';
comment on column NEWS_LIKE.like_time is '点赞时间';

-- 新闻点踩表 NEWS_DISLIKE 的数据定义语言
create table NEWS_DISLIKE
(
    news_id      INT  not null
        constraint NEWS_DISLIKE_NEWS_fk
            references NEWS ON DELETE CASCADE,
    user_id      INT  not null
        constraint NEWS_DISLIKE_USER_fk
            references "USER" ON DELETE CASCADE,
    dislike_time DATE not null,
    constraint NEWS_DISLIKE_pk
        primary key (news_id, user_id)
);

comment on table NEWS_DISLIKE is '新闻点踩';
comment on column NEWS_DISLIKE.news_id is '新闻ID';
comment on column NEWS_DISLIKE.user_id is '用户ID';
comment on column NEWS_DISLIKE.dislike_time is '点踩时间';

-- 新闻评论点赞表 NEWS_COMMENT_LIKE 的数据定义语言
create table NEWS_COMMENT_LIKE
(
    comment_id INT  not null
        constraint NEWS_COMMENT_LIKE_NC_fk
            references NEWS_COMMENT ON DELETE CASCADE,
    user_id    INT  not null
        constraint NEWS_COMMENT_LIKE_USER_fk
            references "USER" ON DELETE CASCADE,
    like_time  DATE not null,
    constraint NEWS_COMMENT_LIKE_pk
        primary key (comment_id, user_id)
);

comment on table NEWS_COMMENT_LIKE is '新闻评论点赞';
comment on column NEWS_COMMENT_LIKE.comment_id is '新闻评论ID';
comment on column NEWS_COMMENT_LIKE.user_id is '用户ID';
comment on column NEWS_COMMENT_LIKE.like_time is '点赞时间';

-- 新闻评论点踩表 NEWS_COMMENT_DISLIKE 的数据定义语言
create table NEWS_COMMENT_DISLIKE
(
    comment_id   INT  not null
        constraint NEWS_COMMENT_DISLIKE_NC_fk
            references NEWS_COMMENT ON DELETE CASCADE,
    user_id      INT  not null
        constraint NEWS_COMMENT_DISLIKE_USER_fk
            references "USER" ON DELETE CASCADE,
    dislike_time DATE not null,
    constraint NEWS_COMMENT_DISLIKE_pk
        primary key (comment_id, user_id)
);

comment on table NEWS_COMMENT_DISLIKE is '新闻评论点踩';
comment on column NEWS_COMMENT_DISLIKE.comment_id is '新闻评论ID';
comment on column NEWS_COMMENT_DISLIKE.user_id is '用户ID';
comment on column NEWS_COMMENT_DISLIKE.dislike_time is '点踩时间';

-- 新闻收藏表 NEWS_FAVORITE 的数据定义语言
create table NEWS_FAVORITE
(
    news_id       INT  not null
        constraint NEWS_FAVORITE_NEWS_fk
            references NEWS ON DELETE CASCADE,
    user_id       INT  not null
        constraint NEWS_FAVORITE_USER_fk
            references "USER" ON DELETE CASCADE,
    favorite_time DATE not null,
    constraint NEWS_FAVORITE_pk
        primary key (news_id, user_id)
);

comment on table NEWS_FAVORITE is '新闻收藏';
comment on column NEWS_FAVORITE.news_id is '新闻ID';
comment on column NEWS_FAVORITE.user_id is '用户ID';
comment on column NEWS_FAVORITE.favorite_time is '收藏时间';

-- 新闻评论举报表 NEWS_COMMENT_REPORT 的数据定义语言
create table NEWS_COMMENT_REPORT
(
    news_comment_report_id INT          GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint NEWS_COMMENT_REPORT_pk
            primary key,
    reporter_id            INT          not null
        constraint NEWS_COMMENT_REPORT_USER_fk_1
            references "USER" ON DELETE CASCADE,
    reported_user_id       INT          not null
        constraint NEWS_COMMENT_REPORT_USER_fk_2
            references "USER" ON DELETE CASCADE,
    reported_news_id       INT          not null
        constraint NEWS_COMMENT_REPORT_NEWS_fk
            references NEWS ON DELETE CASCADE,
    reported_comment_id    INT          not null
        constraint NEWS_COMMENT_REPORT_NC_fk
            references NEWS_COMMENT ON DELETE CASCADE,
    report_reason          VARCHAR(512) not null,
    report_time            DATE         not null,
    status                 NUMBER(1)    not null
);

comment on table NEWS_COMMENT_REPORT is '新闻评论举报';
comment on column NEWS_COMMENT_REPORT.news_comment_report_id is '新闻评论举报ID';
comment on column NEWS_COMMENT_REPORT.reporter_id is '举报者ID';
comment on column NEWS_COMMENT_REPORT.reported_user_id is '被举报者ID';
comment on column NEWS_COMMENT_REPORT.reported_news_id is '被举报评论所属新闻ID';
comment on column NEWS_COMMENT_REPORT.reported_comment_id is '被举报评论ID';
comment on column NEWS_COMMENT_REPORT.report_reason is '举报原因';
comment on column NEWS_COMMENT_REPORT.report_time is '举报时间';
comment on column NEWS_COMMENT_REPORT.status is '处理状态';

-- 宠物分类表 PET_CATEGORY 的数据定义语言
create table PET_CATEGORY
(
    category_id      INT           not null
        constraint PET_CATEGORY_pk
            primary key,
    category_name_zh VARCHAR(1024) not null
        constraint category_name_zh_uk
            unique,
    category_name_de VARCHAR(1024) not null
        constraint category_name_de_uk
            unique,
    category_name_en VARCHAR(1024) not null
        constraint category_name_en_uk
            unique,
    category_name_es VARCHAR(1024) not null
        constraint category_name_es_uk
            unique,
    category_name_fr VARCHAR(1024) not null
        constraint category_name_fr_uk
            unique,
    category_name_it VARCHAR(1024) not null
        constraint category_name_it_uk
            unique,
    category_name_ja VARCHAR(1024) not null
        constraint category_name_ja_uk
            unique,
    category_name_ko VARCHAR(1024) not null
        constraint category_name_ko_uk
            unique,
    category_name_pt VARCHAR(1024) not null
        constraint category_name_pt_uk
            unique,
    category_name_ru VARCHAR(1024) not null
        constraint category_name_ru_uk
            unique,
    description_zh   CLOB          not null,
    description_de   CLOB          not null,
    description_en   CLOB          not null,
    description_es   CLOB          not null,
    description_fr   CLOB          not null,
    description_it   CLOB          not null,
    description_ja   CLOB          not null,
    description_ko   CLOB          not null,
    description_pt   CLOB          not null,
    description_ru   CLOB          not null,
    image_url        VARCHAR(2048) not null
);

comment on table PET_CATEGORY is '宠物分类';
comment on column PET_CATEGORY.category_id is '宠物分类ID';
comment on column PET_CATEGORY.category_name_zh is '宠物分类名称（汉语）';
comment on column PET_CATEGORY.category_name_de is '宠物分类名称（德语）';
comment on column PET_CATEGORY.category_name_en is '宠物分类名称（英语）';
comment on column PET_CATEGORY.category_name_es is '宠物分类名称（西班牙语）';
comment on column PET_CATEGORY.category_name_fr is '宠物分类名称（法语）';
comment on column PET_CATEGORY.category_name_it is '宠物分类名称（意大利语）';
comment on column PET_CATEGORY.category_name_ja is '宠物分类名称（日语）';
comment on column PET_CATEGORY.category_name_ko is '宠物分类名称（韩语）';
comment on column PET_CATEGORY.category_name_pt is '宠物分类名称（葡萄牙语）';
comment on column PET_CATEGORY.category_name_ru is '宠物分类名称（俄语）';
comment on column PET_CATEGORY.description_zh is '描述（汉语）';
comment on column PET_CATEGORY.description_de is '描述（德语）';
comment on column PET_CATEGORY.description_en is '描述（英语）';
comment on column PET_CATEGORY.description_es is '描述（西班牙语）';
comment on column PET_CATEGORY.description_fr is '描述（法语）';
comment on column PET_CATEGORY.description_it is '描述（意大利语）';
comment on column PET_CATEGORY.description_ja is '描述（日语）';
comment on column PET_CATEGORY.description_ko is '描述（韩语）';
comment on column PET_CATEGORY.description_pt is '描述（葡萄牙语）';
comment on column PET_CATEGORY.description_ru is '描述（俄语）';
comment on column PET_CATEGORY.image_url is '图片链接';

-- 宠物子类表 PET_SUBCATEGORY 的数据定义语言
create table PET_SUBCATEGORY
(
    subcategory_id         INT           not null
        constraint PET_SUBCATEGORY_pk
            primary key,
    category_id            INT           not null
        constraint PET_SUBCATEGORY_PC_fk
            references PET_CATEGORY ON DELETE CASCADE,
    subcategory_name_zh    VARCHAR(1024) not null
        constraint subcategory_name_zh_uk
            unique,
    subcategory_name_de    VARCHAR(1024) not null
        constraint subcategory_name_de_uk
            unique,
    subcategory_name_en    VARCHAR(1024) not null
        constraint subcategory_name_en_uk
            unique,
    subcategory_name_es    VARCHAR(1024) not null
        constraint subcategory_name_es_uk
            unique,
    subcategory_name_fr    VARCHAR(1024) not null
        constraint subcategory_name_fr_uk
            unique,
    subcategory_name_it    VARCHAR(1024) not null
        constraint subcategory_name_it_uk
            unique,
    subcategory_name_ja    VARCHAR(1024) not null
        constraint subcategory_name_ja_uk
            unique,
    subcategory_name_ko    VARCHAR(1024) not null
        constraint subcategory_name_ko_uk
            unique,
    subcategory_name_pt    VARCHAR(1024) not null
        constraint subcategory_name_pt_uk
            unique,
    subcategory_name_ru    VARCHAR(1024) not null
        constraint subcategory_name_ru_uk
            unique,
    description_zh         CLOB          not null,
    description_de         CLOB          not null,
    description_en         CLOB          not null,
    description_es         CLOB          not null,
    description_fr         CLOB          not null,
    description_it         CLOB          not null,
    description_ja         CLOB          not null,
    description_ko         CLOB          not null,
    description_pt         CLOB          not null,
    description_ru         CLOB          not null,
    image_url              VARCHAR(2048) not null,
    origin_zh              VARCHAR(512)  not null,
    origin_de              VARCHAR(512)  not null,
    origin_en              VARCHAR(512)  not null,
    origin_es              VARCHAR(512)  not null,
    origin_fr              VARCHAR(512)  not null,
    origin_it              VARCHAR(512)  not null,
    origin_ja              VARCHAR(512)  not null,
    origin_ko              VARCHAR(512)  not null,
    origin_pt              VARCHAR(512)  not null,
    origin_ru              VARCHAR(512)  not null,
    size_zh                VARCHAR(512)  not null,
    size_de                VARCHAR(512)  not null,
    size_en                VARCHAR(512)  not null,
    size_es                VARCHAR(512)  not null,
    size_fr                VARCHAR(512)  not null,
    size_it                VARCHAR(512)  not null,
    size_ja                VARCHAR(512)  not null,
    size_ko                VARCHAR(512)  not null,
    size_pt                VARCHAR(512)  not null,
    size_ru                VARCHAR(512)  not null,
    coat_zh                VARCHAR(512)  not null,
    coat_de                VARCHAR(512)  not null,
    coat_en                VARCHAR(512)  not null,
    coat_es                VARCHAR(512)  not null,
    coat_fr                VARCHAR(512)  not null,
    coat_it                VARCHAR(512)  not null,
    coat_ja                VARCHAR(512)  not null,
    coat_ko                VARCHAR(512)  not null,
    coat_pt                VARCHAR(512)  not null,
    coat_ru                VARCHAR(512)  not null,
    lifespan_zh            VARCHAR(512)  not null,
    lifespan_de            VARCHAR(512)  not null,
    lifespan_en            VARCHAR(512)  not null,
    lifespan_es            VARCHAR(512)  not null,
    lifespan_fr            VARCHAR(512)  not null,
    lifespan_it            VARCHAR(512)  not null,
    lifespan_ja            VARCHAR(512)  not null,
    lifespan_ko            VARCHAR(512)  not null,
    lifespan_pt            VARCHAR(512)  not null,
    lifespan_ru            VARCHAR(512)  not null,
    temperament_zh         VARCHAR(512)  not null,
    temperament_de         VARCHAR(512)  not null,
    temperament_en         VARCHAR(512)  not null,
    temperament_es         VARCHAR(512)  not null,
    temperament_fr         VARCHAR(512)  not null,
    temperament_it         VARCHAR(512)  not null,
    temperament_ja         VARCHAR(512)  not null,
    temperament_ko         VARCHAR(512)  not null,
    temperament_pt         VARCHAR(512)  not null,
    temperament_ru         VARCHAR(512)  not null,
    diet_zh                VARCHAR(512)  not null,
    diet_de                VARCHAR(512)  not null,
    diet_en                VARCHAR(512)  not null,
    diet_es                VARCHAR(512)  not null,
    diet_fr                VARCHAR(512)  not null,
    diet_it                VARCHAR(512)  not null,
    diet_ja                VARCHAR(512)  not null,
    diet_ko                VARCHAR(512)  not null,
    diet_pt                VARCHAR(512)  not null,
    diet_ru                VARCHAR(512)  not null,
    latitude_and_longitude VARCHAR(512)  not null
);

comment on table PET_SUBCATEGORY is '宠物子类';
comment on column PET_SUBCATEGORY.subcategory_id is '宠物子类ID';
comment on column PET_SUBCATEGORY.category_id is '宠物分类ID';
comment on column PET_SUBCATEGORY.subcategory_name_zh is '宠物子类名称（汉语）';
comment on column PET_SUBCATEGORY.subcategory_name_de is '宠物子类名称（德语）';
comment on column PET_SUBCATEGORY.subcategory_name_en is '宠物子类名称（英语）';
comment on column PET_SUBCATEGORY.subcategory_name_es is '宠物子类名称（西班牙语）';
comment on column PET_SUBCATEGORY.subcategory_name_fr is '宠物子类名称（法语）';
comment on column PET_SUBCATEGORY.subcategory_name_it is '宠物子类名称（意大利语）';
comment on column PET_SUBCATEGORY.subcategory_name_ja is '宠物子类名称（日语）';
comment on column PET_SUBCATEGORY.subcategory_name_ko is '宠物子类名称（韩语）';
comment on column PET_SUBCATEGORY.subcategory_name_pt is '宠物子类名称（葡萄牙语）';
comment on column PET_SUBCATEGORY.subcategory_name_ru is '宠物子类名称（俄语）';
comment on column PET_SUBCATEGORY.description_zh is '描述（汉语）';
comment on column PET_SUBCATEGORY.description_de is '描述（德语）';
comment on column PET_SUBCATEGORY.description_en is '描述（英语）';
comment on column PET_SUBCATEGORY.description_es is '描述（西班牙语）';
comment on column PET_SUBCATEGORY.description_fr is '描述（法语）';
comment on column PET_SUBCATEGORY.description_it is '描述（意大利语）';
comment on column PET_SUBCATEGORY.description_ja is '描述（日语）';
comment on column PET_SUBCATEGORY.description_ko is '描述（韩语）';
comment on column PET_SUBCATEGORY.description_pt is '描述（葡萄牙语）';
comment on column PET_SUBCATEGORY.description_ru is '描述（俄语）';
comment on column PET_SUBCATEGORY.image_url is '图片链接';
comment on column PET_SUBCATEGORY.origin_zh is '起源地（汉语）';
comment on column PET_SUBCATEGORY.origin_de is '起源地（德语）';
comment on column PET_SUBCATEGORY.origin_en is '起源地（英语）';
comment on column PET_SUBCATEGORY.origin_es is '起源地（西班牙语）';
comment on column PET_SUBCATEGORY.origin_fr is '起源地（法语）';
comment on column PET_SUBCATEGORY.origin_it is '起源地（意大利语）';
comment on column PET_SUBCATEGORY.origin_ja is '起源地（日语）';
comment on column PET_SUBCATEGORY.origin_ko is '起源地（韩语）';
comment on column PET_SUBCATEGORY.origin_pt is '起源地（葡萄牙语）';
comment on column PET_SUBCATEGORY.origin_ru is '起源地（俄语）';
comment on column PET_SUBCATEGORY.size_zh is '体型（汉语）';
comment on column PET_SUBCATEGORY.size_de is '体型（德语）';
comment on column PET_SUBCATEGORY.size_en is '体型（英语）';
comment on column PET_SUBCATEGORY.size_es is '体型（西班牙语）';
comment on column PET_SUBCATEGORY.size_fr is '体型（法语）';
comment on column PET_SUBCATEGORY.size_it is '体型（意大利语）';
comment on column PET_SUBCATEGORY.size_ja is '体型（日语）';
comment on column PET_SUBCATEGORY.size_ko is '体型（韩语）';
comment on column PET_SUBCATEGORY.size_pt is '体型（葡萄牙语）';
comment on column PET_SUBCATEGORY.size_ru is '体型（俄语）';
comment on column PET_SUBCATEGORY.coat_zh is '毛色（汉语）';
comment on column PET_SUBCATEGORY.coat_de is '毛色（德语）';
comment on column PET_SUBCATEGORY.coat_en is '毛色（英语）';
comment on column PET_SUBCATEGORY.coat_es is '毛色（西班牙语）';
comment on column PET_SUBCATEGORY.coat_fr is '毛色（法语）';
comment on column PET_SUBCATEGORY.coat_it is '毛色（意大利语）';
comment on column PET_SUBCATEGORY.coat_ja is '毛色（日语）';
comment on column PET_SUBCATEGORY.coat_ko is '毛色（韩语）';
comment on column PET_SUBCATEGORY.coat_pt is '毛色（葡萄牙语）';
comment on column PET_SUBCATEGORY.coat_ru is '毛色（俄语）';
comment on column PET_SUBCATEGORY.lifespan_zh is '寿命（汉语）';
comment on column PET_SUBCATEGORY.lifespan_de is '寿命（德语）';
comment on column PET_SUBCATEGORY.lifespan_en is '寿命（英语）';
comment on column PET_SUBCATEGORY.lifespan_es is '寿命（西班牙语）';
comment on column PET_SUBCATEGORY.lifespan_fr is '寿命（法语）';
comment on column PET_SUBCATEGORY.lifespan_it is '寿命（意大利语）';
comment on column PET_SUBCATEGORY.lifespan_ja is '寿命（日语）';
comment on column PET_SUBCATEGORY.lifespan_ko is '寿命（韩语）';
comment on column PET_SUBCATEGORY.lifespan_pt is '寿命（葡萄牙语）';
comment on column PET_SUBCATEGORY.lifespan_ru is '寿命（俄语）';
comment on column PET_SUBCATEGORY.temperament_zh is '性情（汉语）';
comment on column PET_SUBCATEGORY.temperament_de is '性情（德语）';
comment on column PET_SUBCATEGORY.temperament_en is '性情（英语）';
comment on column PET_SUBCATEGORY.temperament_es is '性情（西班牙语）';
comment on column PET_SUBCATEGORY.temperament_fr is '性情（法语）';
comment on column PET_SUBCATEGORY.temperament_it is '性情（意大利语）';
comment on column PET_SUBCATEGORY.temperament_ja is '性情（日语）';
comment on column PET_SUBCATEGORY.temperament_ko is '性情（韩语）';
comment on column PET_SUBCATEGORY.temperament_pt is '性情（葡萄牙语）';
comment on column PET_SUBCATEGORY.temperament_ru is '性情（俄语）';
comment on column PET_SUBCATEGORY.diet_zh is '饮食习惯（汉语）';
comment on column PET_SUBCATEGORY.diet_de is '饮食习惯（德语）';
comment on column PET_SUBCATEGORY.diet_en is '饮食习惯（英语）';
comment on column PET_SUBCATEGORY.diet_es is '饮食习惯（西班牙语）';
comment on column PET_SUBCATEGORY.diet_fr is '饮食习惯（法语）';
comment on column PET_SUBCATEGORY.diet_it is '饮食习惯（意大利语）';
comment on column PET_SUBCATEGORY.diet_ja is '饮食习惯（日语）';
comment on column PET_SUBCATEGORY.diet_ko is '饮食习惯（韩语）';
comment on column PET_SUBCATEGORY.diet_pt is '饮食习惯（葡萄牙语）';
comment on column PET_SUBCATEGORY.diet_ru is '饮食习惯（俄语）';
comment on column PET_SUBCATEGORY.latitude_and_longitude is '经纬度参数';

-- 宠物护理指导表 PET_CARE_GUIDE 的数据定义语言
create table PET_CARE_GUIDE
(
    guide_id       INT           not null
        constraint PET_CARE_GUIDE_pk
            primary key,
    subcategory_id INT           not null
        constraint PET_CARE_GUIDE_PSC_fk
            references PET_SUBCATEGORY ON DELETE CASCADE,
    title_zh       VARCHAR(2048) not null,
    title_de       VARCHAR(2048) not null,
    title_en       VARCHAR(2048) not null,
    title_es       VARCHAR(2048) not null,
    title_fr       VARCHAR(2048) not null,
    title_it       VARCHAR(2048) not null,
    title_ja       VARCHAR(2048) not null,
    title_ko       VARCHAR(2048) not null,
    title_pt       VARCHAR(2048) not null,
    title_ru       VARCHAR(2048) not null,
    content_zh     CLOB          not null,
    content_de     CLOB          not null,
    content_en     CLOB          not null,
    content_es     CLOB          not null,
    content_fr     CLOB          not null,
    content_it     CLOB          not null,
    content_ja     CLOB          not null,
    content_ko     CLOB          not null,
    content_pt     CLOB          not null,
    content_ru     CLOB          not null
);

comment on table PET_CARE_GUIDE is '宠物护理指导';
comment on column PET_CARE_GUIDE.guide_id is '宠物护理指导ID';
comment on column PET_CARE_GUIDE.subcategory_id is '宠物子类ID';
comment on column PET_CARE_GUIDE.title_zh is '标题（汉语）';
comment on column PET_CARE_GUIDE.title_de is '标题（德语）';
comment on column PET_CARE_GUIDE.title_en is '标题（英语）';
comment on column PET_CARE_GUIDE.title_es is '标题（西班牙语）';
comment on column PET_CARE_GUIDE.title_fr is '标题（法语）';
comment on column PET_CARE_GUIDE.title_it is '标题（意大利语）';
comment on column PET_CARE_GUIDE.title_ja is '标题（日语）';
comment on column PET_CARE_GUIDE.title_ko is '标题（韩语）';
comment on column PET_CARE_GUIDE.title_pt is '标题（葡萄牙语）';
comment on column PET_CARE_GUIDE.title_ru is '标题（俄语）';
comment on column PET_CARE_GUIDE.content_zh is '内容（汉语）';
comment on column PET_CARE_GUIDE.content_de is '内容（德语）';
comment on column PET_CARE_GUIDE.content_en is '内容（英语）';
comment on column PET_CARE_GUIDE.content_es is '内容（西班牙语）';
comment on column PET_CARE_GUIDE.content_fr is '内容（法语）';
comment on column PET_CARE_GUIDE.content_it is '内容（意大利语）';
comment on column PET_CARE_GUIDE.content_ja is '内容（日语）';
comment on column PET_CARE_GUIDE.content_ko is '内容（韩语）';
comment on column PET_CARE_GUIDE.content_pt is '内容（葡萄牙语）';
comment on column PET_CARE_GUIDE.content_ru is '内容（俄语）';

-- 宠物领养表 PET_ADOPTION 的数据定义语言
create table PET_ADOPTION
(
    adoption_id         INT           GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) not null
        constraint PET_ADOPTION_pk
            primary key,
    user_id             INT           not null
        constraint PET_ADOPTION_USER_fk
            references "USER" ON DELETE CASCADE,
    category_id         INT           not null
        constraint PET_ADOPTION_PET_CATEGORY_fk
            references PET_CATEGORY ON DELETE CASCADE,
    subcategory_id      INT           not null
        constraint PET_ADOPTION_PS_fk
            references PET_SUBCATEGORY ON DELETE CASCADE,
    name                VARCHAR(64),
    image_url           VARCHAR(2048) not null,
    age                 INT           not null,
    location            VARCHAR(1024) not null,
    reason              VARCHAR(1024) not null,
    health              VARCHAR(1024) not null,
    latest_health_check DATE          not null,
    vaccination         VARCHAR(1024) not null,
    care_needs          VARCHAR(1024),
    dietary_needs       VARCHAR(1024),
    behavior            VARCHAR(1024),
    neutered_or_spayed  NUMBER(1)     not null,
    notes               VARCHAR(1024),
    status              NUMBER(1)     not null,
    gender              NUMBER(1)     not null,
    appendix_url        VARCHAR(2048)
);

comment on table PET_ADOPTION is '宠物领养';
comment on column PET_ADOPTION.adoption_id is '宠物领养ID';
comment on column PET_ADOPTION.user_id is '用户ID';
comment on column PET_ADOPTION.category_id is '宠物分类ID';
comment on column PET_ADOPTION.subcategory_id is '宠物子类ID';
comment on column PET_ADOPTION.name is '宠物名称';
comment on column PET_ADOPTION.image_url is '图片链接';
comment on column PET_ADOPTION.age is '宠物年龄';
comment on column PET_ADOPTION.location is '地址';
comment on column PET_ADOPTION.reason is '转让原因';
comment on column PET_ADOPTION.health is '健康情况';
comment on column PET_ADOPTION.latest_health_check is '最近一次健康检查日期';
comment on column PET_ADOPTION.vaccination is '疫苗接种情况';
comment on column PET_ADOPTION.care_needs is '特殊护理需求';
comment on column PET_ADOPTION.dietary_needs is '特殊饮食需求';
comment on column PET_ADOPTION.behavior is '性格行为特征';
comment on column PET_ADOPTION.neutered_or_spayed is '是否已绝育';
comment on column PET_ADOPTION.notes is '备注';
comment on column PET_ADOPTION.status is '领养状态';
comment on column PET_ADOPTION.gender is '性别';
comment on column PET_ADOPTION.appendix_url is '附件链接';

-- 开发团队表 DEVELOPMENT_TEAM 的数据定义语言
create table DEVELOPMENT_TEAM
(
    id             INT           not null
        constraint DEVELOPMENT_TEAM_pk
            primary key,
    name           VARCHAR(64)   not null,
    school         VARCHAR(64)   not null,
    email          VARCHAR(2048) not null,
    github_name    VARCHAR(64)   not null,
    github_profile VARCHAR(2048) not null
);

comment on table DEVELOPMENT_TEAM is '开发团队';
comment on column DEVELOPMENT_TEAM.id is '学号';
comment on column DEVELOPMENT_TEAM.name is '姓名';
comment on column DEVELOPMENT_TEAM.school is '学校';
comment on column DEVELOPMENT_TEAM.email is '电子邮箱';
comment on column DEVELOPMENT_TEAM.github_name is 'GitHub名称';
comment on column DEVELOPMENT_TEAM.github_profile is 'GitHub主页';