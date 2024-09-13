<!--
  Project Name:  UserInterface
  File Name:     NewsPage.vue
  File Function: 新闻页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-06
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div style='width: 1200px; margin: 0 auto'>
    <NewsText :news-id='newsId'/>

    <div v-if='commentCount>0' class='comment-count'>
      <img :src='`${ossBaseUrl}LogosAndIcons/Comment.png`' alt='Comment' class='comment-logo'>
      {{ t('NewsPage.TotalComments', {count: commentCount}) }}
    </div>

    <div v-if='comments.length>0' class='comments-section'>
      <div v-for='comment in comments' :key='comment.commentId' class='comment'>
        <div class='comment-header'>
          <el-avatar v-if='userAvatars[comment.userId]'
                     class='user-avatar'
                     @click="router.push(`/profile/${comment.userId}`)"
                     :src='`${ossBaseUrl}${userAvatars[comment.userId].avatarUrl}`'>
            <el-icon :size='24'>
              <Avatar/>
            </el-icon>
          </el-avatar>

          <div class='comment-content'>
            <span class='user-name'>{{ userAvatars[comment.userId].userName }}</span>
            <div v-if='!comment.parentCommentId'>
              {{ comment.content }}
            </div>
            <div v-else class='reply-comment'>
              {{ t('NewsPage.Reply') }} @{{ findParentCommentUser(comment.parentCommentId) }}: {{ comment.content }}
            </div>
          </div>

          <div class='stat-items'>
            <div class='stat-item'>
              <img :src='`${ossBaseUrl}LogosAndIcons/Like.png`'
                   alt='Like'
                   class='like-logo'
                   @click='handleCommentLike(comment.commentId)'>
              <span class='stat-text'>{{ comment.likeCount }}</span>
            </div>
            <div class='stat-item'>
              <img :src='`${ossBaseUrl}LogosAndIcons/Dislike.png`'
                   alt='Dislike'
                   class='dislike-logo'
                   @click='handleCommentDislike(comment.commentId)'>
            </div>
            <div class='stat-item report-button'>
              <el-popover :visible='isPopoverVisible(comment.commentId)'
                          placement='bottom-end'
                          :width='500'>
                <template #reference>
                  <button v-if='currentUserId!=comment.userId'
                          @click='togglePopover(comment.commentId)'
                          class='report-button-icon'>
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
                    <el-button size='small' @click="activeCommentId=null; reportContent=''">
                      {{ t('FooterNavbar.Cancel') }}
                    </el-button>
                    <el-button type='primary' size='small' @click='sendReport'>
                      {{ t('NewsPage.Report') }}
                    </el-button>
                  </el-button-group>
                </div>
              </el-popover>
              <button v-if='currentUserId==comment.userId'
                      @click="ElMessage.warning(t('NewsPage.CannotReportPrompt'))"
                      class='report-button-icon'>
                {{ t('NewsPage.Report') }}
              </button>
            </div>
          </div>
        </div>

        <div class='comment-details'>
          <span>{{ formatDateTimeToCST(comment.commentTime).dateTime }}</span>
          <div class='comment-actions'>
            <button class='reply-button'
                    @click='handleReplyClick(userAvatars[comment.userId].userName); parentCommentId=comment.commentId'>
              {{ t('NewsPage.Reply') }}
            </button>
            <button v-if='currentUserId == comment.userId || isAdmin'
                    @click='handleDelete(comment.commentId)'
                    class='delete-button'>
              {{ t('NewsManagementPage.Delete') }}
            </button>
          </div>
        </div>
      </div>
    </div>

    <div v-else>
      <div class='comment-placeholder'>
        <img :src='`${ossBaseUrl}LogosAndIcons/Comment.png`' alt='Comment' class='comment-logo'>
        <p class='no-comments'>{{ t('NewsPage.NoComments') }}</p>
      </div>
    </div>

    <div class='input-container'>
      <div class='input-with-button'>
        <el-input v-model='userInput'
                  class='input-box'
                  :placeholder="t('PetCommunityPage.CommunityAtmospherePrompt')"
                  show-word-limit
                  size='large'
                  :maxlength='128'
                  @focus='scrollToInputBox'>
          <template #prepend>
            <div class='input-prepend-content'>
              <span>{{ inputPrependText }}</span>
              <el-icon v-if='isReplying' :size='10' @click='resetInputText' class='close-icon'>
                <Close/>
              </el-icon>
            </div>
          </template>
        </el-input>

        <el-button size='large' type='primary' class='upload-button' @click='sendComment'>
          <el-icon :size='20'>
            <Upload style='font-weight: bold'/>
          </el-icon>
        </el-button>
      </div>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {useI18n} from 'vue-i18n'
import {useRoute, useRouter} from 'vue-router'
import {ref, onMounted, watch} from 'vue'
import axiosInstance from '../utils/axios'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import {Avatar, Upload, Close} from '@element-plus/icons-vue'
import {ElMessage, ElMessageBox, ElNotification} from 'element-plus'
import NewsText from '../components/NewsText.vue'

const {t} = useI18n()
const router = useRouter()
const route = useRoute()
const newsId = ref(parseInt(<string>route.params.id))
const comments = ref<Comment[]>([])
const userAvatars = ref<{ [key: number]: { userName: string, avatarUrl: string } }>({})
const commentCount = ref(0)
const isReplying = ref(false)
const userInput = ref('')
const inputPrependText = ref(t('NewsPage.ReplyToNews'))
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const parentCommentId = ref(0)
const reportContent = ref('')
const isAdmin = ref(false)
const activeCommentId = ref(null)

type Comment = {
  commentId: number
  newsId: number
  userId: number
  parentCommentId: number | null
  content: string
  commentTime: string
  likeCount: number
  dislikeCount: number
}

const isPopoverVisible = (commentId) => {
  return activeCommentId.value == commentId
}

const togglePopover = (commentId) => {
  reportContent.value = ''
  if (activeCommentId.value == commentId) {
    activeCommentId.value = null
  } else {
    activeCommentId.value = commentId
  }
}

const fetchComments = async () => {
  try {
    const response = await axiosInstance.get(`news-comment/news-${newsId.value}`)
    comments.value = response.data
    commentCount.value = response.data.length
    const userIds = Array.from(new Set(response.data.map((comment: Comment) => comment.userId)))
    const userPromises = userIds.map(async (userId) => {
      try {
        const userResponse = await axiosInstance.get(`user/${userId}`)
        return {
          userId,
          userName: userResponse.data.userName,
          avatarUrl: userResponse.data.avatarUrl
        }
      } catch (error) {
        ElMessage.error(t('ErrorMessage.GetErrorMessage'))
        return null
      }
    })
    const userResults = await Promise.all(userPromises)
    userResults.forEach(result => {
      if (result) {
        userAvatars.value[result.userId] = {
          userName: result.userName,
          avatarUrl: result.avatarUrl
        }
      }
    })
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
}

const findParentCommentUser = (parentCommentId: number | null): string => {
  const parentComment = comments.value.find(comment => comment.commentId == parentCommentId)
  if (parentComment) {
    const user = userAvatars.value[parentComment.userId]
    return user ? user.userName : ''
  }
  return ''
}

onMounted(() => {
  fetchComments()
})

onMounted(() => {
  if (currentUserId.value == 0) {
    router.push('/login')
    ElMessageBox.alert(t('SettingsPage.PleaseLoginFirst'), t('SettingsPage.Notice'), {
      showClose: false
    })
  }
})

watch(() => route.params.id, (newId) => {
  newsId.value = parseInt(<string>newId)
  fetchComments()
  inputPrependText.value = t('NewsPage.ReplyToNews')
})

const scrollToInputBox = () => {
  const inputBox = document.querySelector('.input-container')
  if (inputBox) {
    inputBox.scrollIntoView({behavior: 'smooth'})
  }
}

const handleReplyClick = (userName: string) => {
  inputPrependText.value = `${t('NewsPage.Reply')} @${userName}`
  isReplying.value = true
  scrollToInputBox()
}

const resetInputText = () => {
  inputPrependText.value = t('NewsPage.ReplyToNews')
  isReplying.value = false
}

async function sendComment() {
  if (userInput.value.trim().length != 0) {
    try {
      await axiosInstance.post('news-comment', {
        newsId: newsId.value,
        userId: currentUserId.value,
        parentCommentId: isReplying.value ? parentCommentId.value : null,
        content: userInput.value,
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

async function handleCommentLike(commentId: number) {
  try {
    await axiosInstance.get(`news-comment-like/${commentId}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`news-comment-like/${commentId}-${currentUserId.value}`)
      comments.value.find(comment => comment.commentId == commentId).likeCount = comments.value.find(comment => comment.commentId == commentId).likeCount - 1
      ElMessage.success(t('NewsPage.CanceledLike'))
    } catch {
      ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('news-comment-like', {
        commentId: commentId,
        userId: currentUserId.value,
        likeTime: new Date().toISOString()
      })
      comments.value.find(comment => comment.commentId == commentId).likeCount = comments.value.find(comment => comment.commentId == commentId).likeCount + 1
      ElMessage.success(t('NewsPage.Liked'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}

async function handleCommentDislike(commentId: number) {
  try {
    await axiosInstance.get(`news-comment-dislike/${commentId}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`news-comment-dislike/${commentId}-${currentUserId.value}`)
      ElMessage.success(t('NewsPage.CanceledDislike'))
    } catch {
      ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('news-comment-dislike', {
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

async function sendReport() {
  if (reportContent.value.trim().length != 0) {
    try {
      await axiosInstance.post('news-comment-report', {
        reporterId: currentUserId.value,
        reportedUserId: comments.value.find(comment => comment.commentId == activeCommentId.value).userId,
        reportedNewsId: newsId.value,
        reportedCommentId: activeCommentId.value,
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
  console.log(id)
  try {
    await axiosInstance.delete(`news-comment/${id}`)
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
  --news-page-bg-color: #FFFFF0;
  --news-page-reply-comment: #555555;
  --news-page-bottom-border: #DDDDDD;
  --news-page-text-color: #888888;
  --news-page-reply-button: #007BFF;
  --news-page-reply-button-hover: #0056B3;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --news-page-bg-color: #202020;
  --news-page-reply-comment: #DDDDDD;
  --news-page-bottom-border: #444444;
  --news-page-text-color: #888888;
  --news-page-reply-button: #4A90E2;
  --news-page-reply-button-hover: #357ABD;
}

.comment {
  background: var(--news-page-bg-color);
  padding: 20px 30px 20px 50px;
  transition: transform 0.2s ease-in-out;
  display: flex;
  flex-direction: column;
  border-bottom: 1px solid var(--news-page-bottom-border);
}

.comment-header {
  display: flex;
  flex-direction: row;
  align-items: flex-start;
}

.user-avatar {
  margin-right: 15px;
  cursor: pointer;
}

.comment-content {
  display: flex;
  flex-direction: column;
  flex: 1;
  margin-right: 40px;
}

.user-name {
  font-weight: bold;
  margin-bottom: 5px;
}

.reply-comment {
  color: var(--news-page-reply-comment);
}

.stat-items {
  display: flex;
  align-items: center;
  gap: 10px;
  justify-content: flex-end;
}

.stat-item {
  display: flex;
  align-items: center;
}

.stat-text {
  margin-left: 5px;
  font-size: 14px;
  color: var(--news-page-text-color);
}

.dislike-logo {
  width: 16px;
  height: 16px;
  margin-top: 0;
  transition: filter 0.2s ease-in-out;
  filter: invert(80%) sepia(0%) saturate(0%) hue-rotate(0deg) brightness(90%) contrast(100%);
  cursor: pointer;
}

.like-logo {
  width: 16px;
  height: 16px;
  margin-top: 0;
  transition: filter 0.2s ease-in-out;
  filter: invert(39%) sepia(87%) saturate(444%) hue-rotate(323deg) brightness(94%) contrast(99%);
  cursor: pointer;
}

.report-button {
  display: flex;
  align-items: center;
  gap: 5px;
  cursor: pointer;
}

.report-button-icon {
  background-color: transparent;
  border: none;
  color: #FF5722;
  cursor: pointer;
  font-size: 14px;
}

.report-button-icon:hover {
  color: #E64A19;
}

.comment-details {
  font-size: 14px;
  color: var(--news-page-text-color);
  display: flex;
  align-items: center;
  gap: 10px;
  margin-top: 10px;
  justify-content: flex-start;
}

.comment-actions {
  display: flex;
  gap: 0;
}

.reply-button {
  background-color: transparent;
  border: none;
  color: var(--news-page-reply-button);
  cursor: pointer;
  font-size: 14px;
}

.delete-button {
  background-color: transparent;
  border: none;
  color: #FF5722;
  cursor: pointer;
  font-size: 14px;
}

.delete-button:hover {
  color: #E64A19;
}

.reply-button:hover {
  color: var(--news-page-reply-button-hover);
}

.comment .stat-items img:hover {
  transform: scale(1.1);
}

.comment-count {
  font-size: 16px;
  font-weight: bold;
  padding-left: 50px;
  padding-bottom: 20px;
  background: var(--news-page-bg-color);
}

.comment-logo {
  width: 20px;
  height: 20px;
  padding-right: 20px;
  filter: invert(60%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
  vertical-align: middle;
  margin-bottom: 2px;
}

.comment-placeholder {
  background: var(--news-page-bg-color);
  display: flex;
  align-items: center;
  padding: 0 0 0 50px;
  margin-bottom: -16px;
}

.no-comments {
  background: var(--news-page-bg-color);
  margin-left: 10px;
  margin-top: 11px;
  color: var(--news-page-reply-comment);
}

.input-container {
  padding: 30px 50px;
  background-color: var(--news-page-bg-color);
  margin-top: 0;
}

.input-with-button {
  display: flex;
  align-items: center;
  width: 100%;
}

.input-box {
  width: 100%;
  flex: 1;
  margin-right: 20px;
  position: relative;
}

.upload-button {
  width: 100px;
}

.input-prepend-content {
  display: flex;
  align-items: center;
  position: relative;
  color: var(--news-page-reply-comment);
}

.close-icon {
  position: absolute;
  top: 0;
  right: -20px;
  margin: 5px;
  cursor: pointer;
}
</style>
