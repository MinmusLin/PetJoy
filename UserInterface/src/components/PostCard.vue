<!--
  Project Name:  UserInterface
  File Name:     PostCard.vue
  File Function: 帖子卡片组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-05
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='post-container' @click='router.push(`/post/${props.postId}`)'>
    <div class='post-title-container'>
      <h1 class='post-title'>{{ postData.title }}</h1>
      <img v-if='postData.isSticky'
           :src='`${ossBaseUrl}LogosAndIcons/Stick.png`'
           alt='StickyIcon'
           class='sticky-icon-t'>
    </div>

    <div class='post-header'>
      <el-avatar class='avatar' :src='`${ossBaseUrl}${user.avatarUrl}`'>
        <el-icon :size='24'>
          <Avatar/>
        </el-icon>
      </el-avatar>
      <span class='user-name'>{{ user.userName }}</span>
      <span class='post-date'>{{ postData.creationDate }}</span>
      <div class='post-footer'>
        <div style='margin-left: 2px'>
          <img :src='`${ossBaseUrl}LogosAndIcons/Like.png`'
               alt='LikeIcon'
               class='post-likes-icon'/>
          {{ postData.likeCount }}
        </div>
        <div style='margin-left: 8px'>
          <img :src='`${ossBaseUrl}LogosAndIcons/Star.png`'
               alt='FavoriteIcon'
               class='post-favorite-icon'/>
          {{ postData.favoriteCount }}
        </div>
        <div style='margin-left: 8px'>
          <img :src='`${ossBaseUrl}LogosAndIcons/Comment.png`'
               alt='CommentsIcon'
               class='post-comments-icon'/>
          {{ postData.commentCount }}
        </div>
      </div>
    </div>

    <div class='post-content-container'>
      <div class='post-content' @click='router.push(`/post/${props.postId}`)'>
        <div style='margin-bottom: 10px'>{{ postData.content }}</div>
        <el-tag style='margin-top: 6px'>{{ postCategory }}</el-tag>
      </div>
      <el-image v-if='postData.imageUrl'
                :src='`${ossBaseUrl}${postData.imageUrl}`'
                alt='PostImage'
                class='post-image'
                :preview-src-list='[`${ossBaseUrl}${postData.imageUrl}`]'
                @click.stop/>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {onMounted, ref, defineProps} from 'vue'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import {useI18n} from 'vue-i18n'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import {Avatar} from '@element-plus/icons-vue'
import {useRouter} from 'vue-router'

const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const {t} = useI18n()
const props = defineProps<{ postId: number }>()
const router = useRouter()
const postCategory = ref()

const postData = ref({
  postId: 0,
  userId: 0,
  categoryId: 0,
  title: '',
  content: '',
  creationDate: '',
  updateDate: '',
  isSticky: 0,
  likeCount: 0,
  dislikeCount: 0,
  favoriteCount: 0,
  commentCount: 0,
  imageUrl: ''
})

const user = ref({
  userId: 0,
  userName: '',
  avatarUrl: '',
})

onMounted(async () => {
  try {
    const postResponse = await axiosInstance.get(`post/${props.postId}`)
    postData.value = postResponse.data
    postData.value.creationDate = formatDateTimeToCST(postData.value.creationDate).dateTime
    postData.value.updateDate = formatDateTimeToCST(postData.value.updateDate).dateTime
    const userResponse = await axiosInstance.get(`user/${postData.value.userId}`)
    user.value = userResponse.data
    const categoryResponse = await axiosInstance.get(`post-category/${postData.value.categoryId}`)
    postCategory.value = categoryResponse.data.category
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})
</script>

<style scoped>
:global(:root) {
  --postcard-likes-color: invert(40%);
  --postcard-favorite-color: invert(40%);
  --postcard-comments-color: invert(40%);
  --postcard-header-color: #888888FF;
  --postcard-container-border-color: #D6D6D6;
  --postcard-sticky-filter-color: invert(8%) sepia(6%) saturate(285%) hue-rotate(174deg) brightness(94%) contrast(91%);
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --postcard-likes-color: invert(60%);
  --postcard-favorite-color: invert(60%);
  --postcard-comments-color: invert(60%);
  --postcard-header-color: #C5C5C5;
  --postcard-container-border-color: #494949;
  --postcard-sticky-filter-color: invert(100%) sepia(0%) saturate(0%) hue-rotate(0deg) brightness(85%) contrast(80%);
}

.post-likes-icon {
  filter: var(--postcard-likes-color);
  width: 15px;
  height: 15px;
  margin-right: 10px;
}

.post-favorite-icon {
  width: 15px;
  height: 15px;
  margin-right: 10px;
  filter: var(--postcard-favorite-color);
}

.post-comments-icon {
  width: 15px;
  height: 15px;
  margin-right: 10px;
  filter: var(--postcard-comments-color);
}

.sticky-icon-t {
  width: 25px;
  height: 25px;
  margin-left: auto;
  filter: var(--postcard-sticky-filter-color);
  transform: translateY(-8px);
}

.post-container {
  border: 1px solid var(--postcard-container-border-color);
  padding: 16px;
  cursor: pointer;
}

.post-header {
  display: flex;
  align-items: center;
  margin-bottom: 10px;
  margin-left: 15px;
  font-size: 14px;
  color: var(--postcard-header-color);
}

.avatar {
  width: 40px;
  height: 40px;
  margin-right: 20px;
}

.user-name {
  font-weight: bold;
  margin-right: 20px;
}

.post-date {
  margin-right: 20px;
}

.post-footer {
  display: flex;
  align-items: center;
}

.post-footer div {
  display: flex;
  align-items: center;
  margin-right: 8px;
}

.post-title-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-left: 15px;
  margin-right: 15px;
}

.post-title {
  font-size: 26px;
}

.post-content-container {
  display: flex;
  justify-content: space-between;
  margin-bottom: 10px;
  margin-left: 15px;
  margin-right: 15px;
}

.post-content {
  font-size: 16px;
  flex: 1;
  margin-right: 16px;
  text-align: justify;
  line-height: 1.5;
}

.post-image {
  width: auto;
  height: 180px;
  margin-left: 16px;
}
</style>
