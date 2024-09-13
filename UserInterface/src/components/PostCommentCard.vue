<!--
  Project Name:  UserInterface
  File Name:     PostCommentCard.vue
  File Function: 帖子评论卡片组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-06
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <el-container class='post-main-container'>
    <el-aside width='25%'>
      <div class='comment-author-card'>
        <el-avatar :src='`${ossBaseUrl}${comment.author.avatarUrl}`' size='large'
                   @click='router.push(`/profile/${comment.commentUserId}`)' style='cursor: pointer'/>
        <p class='comment-author'>{{ comment.author.userName }}</p>
        <p class='comment-intro'>{{ comment.author.profile }}</p>
      </div>
    </el-aside>
    <div class='post-line'/>
    <el-main>
      <div class='comment-card'>
        <p v-if='comment.parentCommentId' class='parent-comment'>@{{ comment.parentUserName }}</p>
        <p>{{ comment.content }}</p>
        <p class='comment-date'>{{ comment.time }}</p>
        <div class='comment-stats'>
          <div class='stat-item'>
            <img :src='`${ossBaseUrl}LogosAndIcons/Like.png`'
                 class='comment-card-like-logo'
                 alt='LikeLogo'
                 @click='handleCommentLike(comment.commentId)'
                 height='14px'/>
            <span class='stat-text' style='color: #6F9DDF'>{{ comment.commentLikeCount }}</span>
          </div>
          <div class='stat-item'>
            <img :src='`${ossBaseUrl}LogosAndIcons/Dislike.png`'
                 class='comment-card-dislike-logo'
                 alt='DislikeLogo'
                 @click='handleCommentDislike(comment.commentId)'
                 height='14px'/>
          </div>
          <div class='stat-item'>
            <el-popover :visible='commentVisible'
                        placement='right-start'
                        :width='500'>
              <template #reference>
                <img :src='`${ossBaseUrl}LogosAndIcons/Comment.png`'
                     class='comment-card-comment-logo'
                     alt='CommentLogo'
                     @click="commentVisible=!commentVisible; commentContent=''"
                     height='14px'/>
              </template>
              <el-input v-model='commentContent'
                        size='large'
                        maxlength='128'
                        :placeholder="t('PetCommunityPage.InputCommentPrompt')"
                        show-word-limit/>
              <div style='margin-top: 10px; display: flex; justify-content: space-between; align-items: center'>
                <p style='margin: 0; font-size: 12px'>{{ t('PetCommunityPage.CommunityAtmospherePrompt') }}</p>
                <el-button-group>
                  <el-button size='small' @click="commentVisible=false; commentContent=''">
                    {{ t('FooterNavbar.Cancel') }}
                  </el-button>
                  <el-button type='primary' size='small' @click='sendComment'>
                    {{ t('PetCommunityPage.Comment') }}
                  </el-button>
                </el-button-group>
              </div>
            </el-popover>
          </div>
          <div class='stat-item button-container'>
            <el-popover :visible='reportVisible'
                        placement='bottom-start'
                        :width='500'>
              <template #reference>
                <button v-if='user != currentUserId'
                        @click="reportVisible=!reportVisible; reportContent=''"
                        class='report-button'>
                  {{ t('NewsPage.Report') }}
                </button>
              </template>
              <el-input v-model='reportContent'
                        size='large'
                        maxlength='128'
                        :placeholder="t('NewsPage.InputReportPrompt')"
                        show-word-limit/>
              <div style='margin-top: 10px; display: flex; justify-content: space-between; align-items: center'>
                <p style='margin: 0; font-size: 12px'>{{ t('NewsPage.ProcessReportRequest') }}</p>
                <el-button-group>
                  <el-button size='small' @click="reportVisible=false; reportContent=''">
                    {{ t('FooterNavbar.Cancel') }}
                  </el-button>
                  <el-button type='primary' size='small' @click='sendReport'>
                    {{ t('NewsPage.Report') }}
                  </el-button>
                </el-button-group>
              </div>
            </el-popover>
            <button v-if='postUser == currentUserId || user == currentUserId || isAdmin'
                    @click='handleDelete(comment.commentId)'
                    class='delete-button'>
              {{ t('NewsManagementPage.Delete') }}
            </button>
          </div>
        </div>
      </div>
    </el-main>
  </el-container>
</template>

<script setup lang='ts'>
import {useI18n} from 'vue-i18n'
import {defineProps, ref, onMounted} from 'vue'
import {ossBaseUrl} from '../globals'
import {useRouter} from 'vue-router'
import axiosInstance from '../utils/axios'
import {ElMessage, ElNotification} from 'element-plus'

const router = useRouter()
const {t} = useI18n()
const commentVisible = ref(false)
const commentContent = ref('')
const reportContent = ref('')
const isAdmin = ref(false)
const reportVisible = ref(false)
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const {comment, id, user, postUser} = defineProps({
  comment: {
    type: Object,
    required: true,
    default: () => ({
      author: {avatarUrl: '', userName: '', profile: ''},
      parentCommentId: null,
      parentUserName: '',
      content: '',
      time: '',
      commentLikeCount: 0,
      commentId: 0
    })
  },
  id: {
    type: Number,
    required: true,
    default: () => ({
      id: 0
    })
  },
  user: {
    type: Number,
    required: true,
    default: () => ({
      user: 0
    })
  },
  postUser: {
    type: Number,
    required: true,
    default: () => ({
      postUser: 0
    })
  }
})

async function handleCommentLike(commentId: number) {
  try {
    await axiosInstance.get(`post-comment-like/${commentId}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`post-comment-like/${commentId}-${currentUserId.value}`)
      comment.commentLikeCount = comment.commentLikeCount - 1
      ElMessage.success(t('NewsPage.CanceledLike'))
    } catch {
      ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('post-comment-like', {
        commentId: commentId,
        userId: currentUserId.value,
        likeTime: new Date().toISOString()
      })
      comment.commentLikeCount = comment.commentLikeCount + 1
      ElMessage.success(t('NewsPage.Liked'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}

async function handleCommentDislike(commentId: number) {
  try {
    await axiosInstance.get(`post-comment-dislike/${commentId}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`post-comment-dislike/${commentId}-${currentUserId.value}`)
      ElMessage.success(t('NewsPage.CanceledDislike'))
    } catch {
      ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('post-comment-dislike', {
        commentId: commentId,
        userId: currentUserId.value,
        dislikeTime: new Date().toISOString()
      })
      ElMessage.success(t('NewsPage.Disliked'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}

async function sendComment() {
  if (commentContent.value.trim().length != 0) {
    try {
      await axiosInstance.post('post-comment', {
        postId: id,
        userId: currentUserId.value,
        parentCommentId: comment.commentId,
        content: commentContent.value,
        commentTime: new Date().toISOString(),
        likeCount: 0,
        dislikeCount: 0
      })
      window.location.reload()
    } catch (error) {
      ElNotification({
        title: t('NewsPage.CommentFailed'),
        message: t('NewsPage.CommentFailedPrompt'),
        type: 'error'
      })
    }
  }
}

async function sendReport() {
  if (reportContent.value.trim().length != 0) {
    try {
      await axiosInstance.post('post-comment-report', {
        reporterId: currentUserId.value,
        reportedUserId: user,
        reportedPostId: id,
        reportedCommentId: comment.commentId,
        reportReason: reportContent.value,
        reportTime: new Date().toISOString(),
        status: 0
      })
      window.location.reload()
    } catch (error) {
      ElNotification({
        title: t('NewsPage.ReportFailed'),
        message: t('NewsPage.ReportFailedPrompt'),
        type: 'error'
      })
    }
  }
}

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`user/role/${currentUserId.value}`)
    isAdmin.value = response.data == 1
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

async function handleDelete(id: number) {
  try {
    await axiosInstance.delete(`post-comment/${id}`)
    window.location.reload()
  } catch (error) {
    ElNotification({
      title: t('NewsPage.DeleteFailed'),
      message: t('NewsPage.DeleteFailedPrompt'),
      type: 'error'
    })
  }
}
</script>

<style scoped>
:global(:root) {
  --post-comment-card-author-intro-color: #666666;
  --post-comment-card-date-color: #888888;
  --post-comment-card-line-bg-color: #DCDFE6;
  --post-comment-card-comment-color: #007BFF;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --post-comment-card-author-intro-color: #9F9F9F;
  --post-comment-card-date-color: #888888;
  --post-comment-card-line-bg-color: #4C4D4F;
  --post-comment-card-comment-color: #66BFFF;
}

.comment-author-card {
  text-align: center;
  padding: 40px;
}

.comment-author {
  font-weight: bold;
}

.comment-intro {
  color: var(--post-comment-card-author-intro-color);
}

.comment-card {
  margin-left: 15px;
  margin-right: 15px;
  line-height: 1.8;
}

.comment-date {
  color: var(--post-comment-card-date-color);
  font-size: 12px;
}

.post-line {
  margin-top: 25px;
  margin-bottom: 35px;
  background: var(--post-comment-card-line-bg-color);
  width: 1px;
  height: auto;
  position: relative;
  float: left;
}

.parent-comment {
  color: var(--post-comment-card-comment-color);
}

.post-main-container {
  width: 65%;
  margin: 0 auto;
  min-width: 1200px;
  border-right-style: solid;
  border-left-style: solid;
  border-width: 1px;
}

.comment-stats {
  display: flex;
  align-items: center;
  gap: 30px;
}

.stat-item {
  display: flex;
  align-items: center;
}

.stat-text {
  font-size: 16px;
  margin-left: 5px;
}

.comment-card-like-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(75%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.comment-card-dislike-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(75%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.comment-card-comment-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(75%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.comment-card-like-logo:hover, .comment-card-comment-logo:hover, .comment-card-dislike-logo:hover {
  transform: scale(1.1);
}

.delete-button {
  background-color: transparent;
  border: none;
  color: #FF5722;
  cursor: pointer;
  font-size: 13px;
  margin-top: -2px;
  display: flex;
  align-items: center;
}

.delete-button:hover {
  color: #E64A19;
}

.report-button {
  background-color: transparent;
  border: none;
  color: #FF9800;
  cursor: pointer;
  font-size: 13px;
  margin-top: -2px;
  display: flex;
  align-items: center;
}

.report-button:hover {
  color: #FF7043;
}

.button-container {
  display: flex;
  align-items: center;
  gap: 10px;
  margin-left: -10px;
  margin-top: -2px;
}
</style>
