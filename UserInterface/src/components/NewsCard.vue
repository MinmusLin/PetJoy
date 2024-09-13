<!--
  Project Name:  UserInterface
  File Name:     NewsCard.vue
  File Function: 新闻卡片组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-05
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div @click='router.push(`/news/${props.newsId}`)' style='cursor: pointer'>
    <el-card :body-style='bodyStyle'
             style='width: 1200px; display: flex; border: 1px solid var(--news-card-border-color); box-shadow: none; padding: 0; position: relative'>
      <img :src='`${ossBaseUrl}${newsData.coverUrl}`' alt='NewsCoverImage' class='news-image'>
      <img v-if='newsData.isSticky'
           :src='`${ossBaseUrl}LogosAndIcons/Stick.png`'
           class='sticky-tag'
           alt='StickLogo'
           height='20px'/>
      <div class='content-wrapper'>
        <el-text class='news-title' truncated>{{ newsData.title }}</el-text>
        <p class='news-summary'>{{ newsData.summary }}</p>
        <div class='news-bottom'>
          <div class='news-info'>
            <span class='time'>{{ newsData.updateDate }}</span>
            <el-tag class='news-tag'>{{ newsTag }}</el-tag>
          </div>
          <div class='news-stats'>
            <div class='stat-item'>
              <img :src='`${ossBaseUrl}LogosAndIcons/Like.png`'
                   class='news-card-like-logo'
                   alt='LikeLogo'
                   height='14px'/>
              <span class='stat-text' style='color: #409EFF'>{{ newsData.likeCount }}</span>
            </div>
            <div class='stat-item'>
              <img :src='`${ossBaseUrl}LogosAndIcons/Star.png`'
                   class='news-card-star-logo'
                   alt='StarLogo'
                   height='14px'/>
              <span class='stat-text' style='color: #409EFF'>{{ newsData.favoriteCount }}</span>
            </div>
            <div class='stat-item'>
              <img :src='`${ossBaseUrl}LogosAndIcons/Comment.png`'
                   class='news-card-comment-logo'
                   alt='CommentLogo'
                   height='14px'/>
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
  --news-card-title-text-color: #3B3838;
  --news-card-content-text-color: #767171;
  --news-card-time-text-color: #767171;
  --news-card-border-color: #E5EAF3;
  --news-card-sticky-filter-color: invert(8%) sepia(6%) saturate(285%) hue-rotate(174deg) brightness(94%) contrast(91%);
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --news-card-title-text-color: #F2F2F2;
  --news-card-content-text-color: #BFBFBF;
  --news-card-time-text-color: #BFBFBF;
  --news-card-border-color: #303133;
  --news-card-sticky-filter-color: invert(100%) sepia(0%) saturate(0%) hue-rotate(0deg) brightness(85%) contrast(80%);
}

.news-image {
  width: 400px;
  height: 225px;
  object-fit: cover;
}

.content-wrapper {
  margin-left: 20px;
  height: 225px;
  justify-content: space-between;
  padding: 0;
  position: relative;
}

.news-title {
  color: var(--news-card-title-text-color);
  margin-top: 25px;
  margin-bottom: -5px;
  font-size: 24px;
  text-align: left;
  font-weight: bold;
  text-overflow: ellipsis;
  max-width: 740px;
}

.news-summary {
  color: var(--news-card-content-text-color);
  line-height: 1.8em;
  margin-right: 20px;
  font-size: 20px;
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
  width: 770px;
  display: flex;
  justify-content: space-between;
  margin-bottom: 25px;
  margin-top: 25px;
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
  font-size: 16px;
  margin-left: 5px;
}

.time {
  margin-right: 20px;
  font-size: 16px;
  color: var(--news-card-time-text-color);
}

.news-tag {
  font-size: 16px;
}

.sticky-tag {
  position: absolute;
  top: 5px;
  right: 5PX;
  font-size: 18px;
  padding: 10px;
  filter: var(--news-card-sticky-filter-color);
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
