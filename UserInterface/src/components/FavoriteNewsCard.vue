<!--
  Project Name:  UserInterface
  File Name:     FavoriteNewsCard.vue
  File Function: 收藏新闻卡片组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div @click='router.push(`/news/${props.newsId}`)' style='cursor: pointer'>
    <el-card :body-style='bodyStyle'
             style='width: 100%; display: flex; border: 1px solid var(--favorite-news-card-border-color); box-shadow: none; padding: 0; position: relative; background-color: var(--favorite-news-card-bg-color)'>
      <img :src='`${ossBaseUrl}${newsData.coverUrl}`' alt='NewsCoverImage' class='news-image'>
      <div class='content-wrapper'>
        <el-text class='news-title' truncated>{{ newsData.title }}</el-text>
        <p class='news-summary'>{{ newsData.summary }}</p>
        <div class='news-bottom'>
          <div class='news-info'>
            <span class='time'>{{ newsData.updateDate }}</span>
            <el-tag size='small'>{{ newsTag }}</el-tag>
          </div>
          <div class='news-stats'>
            <div class='stat-item'>
              <img :src='`${ossBaseUrl}LogosAndIcons/Like.png`'
                   class='news-card-like-logo'
                   alt='LikeLogo'
                   height='10px'/>
              <span class='stat-text' style='color: #409EFF'>{{ newsData.likeCount }}</span>
            </div>
            <div class='stat-item'>
              <img :src='`${ossBaseUrl}LogosAndIcons/Star.png`'
                   class='news-card-star-logo'
                   alt='StarLogo'
                   height='10px'/>
              <span class='stat-text' style='color: #409EFF'>{{ newsData.favoriteCount }}</span>
            </div>
            <div class='stat-item'>
              <img :src='`${ossBaseUrl}LogosAndIcons/Comment.png`'
                   class='news-card-comment-logo'
                   alt='CommentLogo'
                   height='10px'/>
              <span class='stat-text' style='color: #409EFF'>{{ newsData.commentCount }}</span>
            </div>
          </div>
        </div>
      </div>
    </el-card>
  </div>
</template>

<script setup lang='ts'>
import {ref, onMounted, defineProps} from 'vue'
import axiosInstance from '../utils/axios'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import {ElMessage} from 'element-plus'
import {useI18n} from 'vue-i18n'
import {useRouter} from 'vue-router'
import {CSSProperties} from 'vue'

const {t} = useI18n()
const newsTag = ref()
const router = useRouter()
const props = defineProps<{ newsId: number }>()
const newsData = ref({
  newsId: 0,
  userId: 0,
  tagId: 0,
  title: '',
  summary: '',
  content: '',
  creationDate: '',
  updateDate: '',
  coverUrl: '',
  isSticky: false,
  likeCount: 0,
  dislikeCount: 0,
  favoriteCount: 0,
  commentCount: 0
})

const bodyStyle = ref<CSSProperties>({
  padding: '0',
  display: 'flex',
  alignItems: 'center'
})

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`news/${props.newsId}`)
    newsData.value = response.data
    newsData.value.isSticky = response.data.isSticky == 1
    newsData.value.creationDate = formatDateTimeToCST(response.data.creationDate).dateTime
    newsData.value.updateDate = formatDateTimeToCST(response.data.updateDate).dateTime
    const newsInform = await axiosInstance.get(`news-tag/${newsData.value.tagId}`)
    newsTag.value = newsInform.data.tag
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})
</script>

<style scoped>
:global(:root) {
  --favorite-news-card-title-text-color: #3B3838;
  --favorite-news-card-content-text-color: #767171;
  --favorite-news-card-time-text-color: #767171;
  --favorite-news-card-border-color: #0000000C;
  --favorite-news-card-bg-color: #FFFFFF;
  --favorite-news-card-sticky-filter-color: invert(8%) sepia(6%) saturate(285%) hue-rotate(174deg) brightness(94%) contrast(91%);
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --favorite-news-card-title-text-color: #F2F2F2;
  --favorite-news-card-content-text-color: #BFBFBF;
  --favorite-news-card-time-text-color: #BFBFBF;
  --favorite-news-card-border-color: #FFFFFF33;
  --favorite-news-card-bg-color: #101D32;
  --favorite-news-card-sticky-filter-color: invert(100%) sepia(0%) saturate(0%) hue-rotate(0deg) brightness(85%) contrast(80%);
}

.news-image {
  width: 240px;
  height: 135px;
  object-fit: cover;
}

.content-wrapper {
  margin-left: 20px;
  justify-content: space-between;
  padding: 0;
  position: relative;
}

.news-title {
  color: var(--favorite-news-card-title-text-color);
  margin-bottom: -5px;
  font-size: 18px;
  text-align: left;
  font-weight: bold;
  text-overflow: ellipsis;
  max-width: 475px;
}

.news-summary {
  color: var(--favorite-news-card-content-text-color);
  line-height: 1.8em;
  margin-right: 20px;
  font-size: 12px;
  display: -webkit-box;
  -webkit-box-orient: vertical;
  -webkit-line-clamp: 2;
  overflow: hidden;
  text-overflow: ellipsis;
  text-align: justify;
  position: relative;
  min-height: 3.6em;
}

.news-summary:after {
  content: '';
  width: 100%;
  height: 0;
  display: inline-block;
  position: absolute;
  bottom: 0;
}

.news-bottom {
  width: 475px;
  display: flex;
  justify-content: space-between;
}

.news-info {
  display: flex;
  align-items: center;
}

.news-stats {
  display: flex;
  align-items: center;
  margin-right: 10px;
  gap: 20px;
}

.stat-item {
  display: flex;
  align-items: center;
}

.stat-text {
  font-size: 12px;
  margin-left: 5px;
}

.time {
  margin-right: 20px;
  font-size: 12px;
  color: var(--favorite-news-card-time-text-color);
}

.news-card-like-logo {
  filter: invert(60%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.news-card-star-logo {
  filter: invert(60%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.news-card-comment-logo {
  filter: invert(60%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}
</style>
