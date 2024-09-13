<!--
  Project Name:  UserInterface
  File Name:     PostPage.vue
  File Function: 帖子页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-06
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='post-side-color'>
    <el-container class='post-main-container'>
      <el-aside width='25%'>
        <div class='post-author-card'>
          <p style='font-style: italic; color: var(--post-author-intro-color)'>AUTHOR</p>
          <el-avatar :src='`${ossBaseUrl}${postData.userAvatarUrl}`' size='large'
                     @click='router.push(`/profile/${postData.userId}`)' style='cursor: pointer'/>
          <p class='post-author-name'>{{ postData.userName }}</p>
          <p class='post-author-intro'>{{ postData.userProfile }}</p>
        </div>
      </el-aside>
      <div class='post-line'/>
      <el-main>
        <div class='post-card'>
          <div class='post-header'>
            <h2 class='post-title'>{{ postData.title }}</h2>
            <button v-if='currentUserId == postData.userId || isAdmin'
                    @click='handleDelete(postId)'
                    class='post-delete-button'>
              {{ t('NewsManagementPage.Delete') }}
            </button>
          </div>
          <p class='post-content' v-html='formattedContent'/>
          <el-image v-if='postData.imageUrl'
                    class='post-image'
                    :src='`${ossBaseUrl}${postData.imageUrl}`'
                    alt='PostImage'
                    :preview-src-list='[`${ossBaseUrl}${postData.imageUrl}`]'/>
          <div class='post-bottom'>
            <div class='post-date-container'>
              <p class='post-date'>{{ postData.creationDate }}</p>
              <el-popover :visible='reportVisible'
                          placement='bottom-start'
                          :width='500'>
                <template #reference>
                  <button v-if='postData.userId!=currentUserId'
                          @click="reportVisible=!reportVisible; reportContent=''"
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
                    <el-button size='small' @click="reportVisible=false; reportContent=''">
                      {{ t('FooterNavbar.Cancel') }}
                    </el-button>
                    <el-button type='primary' size='small' @click='sendReport'>
                      {{ t('NewsPage.Report') }}
                    </el-button>
                  </el-button-group>
                </div>
              </el-popover>
            </div>
            <div class='post-stats'>
              <div class='stat-item'>
                <img :src='`${ossBaseUrl}LogosAndIcons/Like.png`'
                     class='post-card-like-logo'
                     alt='LikeLogo'
                     @click='handleLike'
                     height='16px'/>
                <span class='stat-text' style='color: #6F9DDF'>{{ postData.likeCount }}</span>
              </div>
              <div class='stat-item'>
                <img :src='`${ossBaseUrl}LogosAndIcons/Star.png`'
                     class='post-card-star-logo'
                     alt='StarLogo'
                     @click='handleFavorite'
                     height='16px'/>
                <span class='stat-text' style='color: #6F9DDF'>{{ postData.favoriteCount }}</span>
              </div>
              <div class='stat-item'>
                <el-popover :visible='commentVisible'
                            placement='bottom-end'
                            :width='500'>
                  <template #reference>
                    <img :src='`${ossBaseUrl}LogosAndIcons/Comment.png`'
                         class='post-card-comment-logo'
                         alt='CommentLogo'
                         @click="commentVisible=!commentVisible; commentContent=''"
                         height='16px'/>
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
                <span class='stat-text' style='color: #6F9DDF'>{{ postData.commentCount }}</span>
              </div>
              <div class='stat-item'>
                <img :src='`${ossBaseUrl}LogosAndIcons/Dislike.png`'
                     class='post-card-dislike-logo'
                     alt='DislikeLogo'
                     @click='handleDislike'
                     height='16px'/>
              </div>
            </div>
          </div>
        </div>
      </el-main>
    </el-container>
    <div>
      <PostCommentCard v-for='comment in paginatedComments'
                       :comment='comment'
                       :id='postId'
                       :user='comment.commentUserId'
                       :post-user='postData.userId'/>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {useI18n} from 'vue-i18n'
import {useRoute} from 'vue-router'
import {onMounted, ref, watch, computed} from 'vue'
import axiosInstance from '../utils/axios'
import {ElMessage, ElMessageBox, ElNotification} from 'element-plus'
import {ossBaseUrl, formatDateTimeToCST} from '../globals'
import PostCommentCard from '../components/PostCommentCard.vue'
import {useRouter} from 'vue-router'

const {t} = useI18n()
const route = useRoute()
const router = useRouter()
const postId = ref(parseInt(<string>route.params.id))
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const commentVisible = ref(false)
const commentContent = ref('')
const reportContent = ref('')
const isAdmin = ref(false)
const reportVisible = ref(false)

const postData = ref({
  userId: 0,
  title: '',
  categoryId: 0,
  content: '',
  creationDate: '',
  updateDate: '',
  likeCount: 0,
  dislikeCount: 0,
  favoriteCount: 0,
  commentCount: 0,
  imageUrl: '',
  userAvatarUrl: '',
  userName: '',
  userProfile: ''
})

const commentsData = ref({
  comments: [],
  currentPage: 1
})

const formattedContent = computed(() => {
  return postData.value.content.replace(/\n/g, '<br>')
})

const paginatedComments = computed(() => {
  const start = (commentsData.value.currentPage - 1) * 10
  const end = start + 10
  return commentsData.value.comments.slice(start, end)
})

const fetchPageData = async () => {
  if (postId.value != 0) {
    try {
      const response = await axiosInstance.get(`post/${postId.value}`)
      if (response.status == 404) {
        await router.push('/404')
      } else {
        postData.value = response.data
        postData.value.creationDate = formatDateTimeToCST(postData.value.creationDate).dateTime
      }
    } catch (error) {
      if (error.response.status == 404) {
        await router.push('/404')
      } else {
        ElMessage.error(t('ErrorMessage.GetErrorMessage'))
      }
    }
  }

  if (postData.value.userId != 0) {
    try {
      const response = await axiosInstance.get(`user/${postData.value.userId}`)
      const userData = response.data
      postData.value.userAvatarUrl = userData.avatarUrl
      postData.value.userName = userData.userName
      postData.value.userProfile = userData.profile
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }

  if (postData.value.commentCount != 0) {
    try {
      const response = await axiosInstance.get(`/post-comment/post-${postId.value}`)
      commentsData.value.comments = response.data.map((commentData: any) => ({
        commentId: commentData.commentId,
        parentCommentId: commentData.parentCommentId,
        content: commentData.content,
        commentUserId: commentData.userId,
        time: formatDateTimeToCST(commentData.commentTime).dateTime,
        commentLikeCount: commentData.likeCount,
        commentDislikeCount: commentData.dislikeCount,
        parentUserName: '',
        parentCommentUserId: '',
        author: {
          avatarUrl: '',
          userName: '',
          profile: ''
        }
      }))

      const userPromises = commentsData.value.comments.map(async (comment: any) => {
        try {
          const response = await axiosInstance.get(`user/${comment.commentUserId}`)
          const userData = response.data
          comment.author.avatarUrl = userData.avatarUrl
          comment.author.userName = userData.userName
          comment.author.profile = userData.profile
          if (comment.parentCommentId) {
            const parentResponse = await axiosInstance.get(`post-comment/${comment.parentCommentId}`)
            const parentCommentData = parentResponse.data
            comment.parentCommentUserId = parentCommentData.userId
            const parentUserResponse = await axiosInstance.get(`user/${comment.parentCommentUserId}`)
            comment.parentUserName = parentUserResponse.data.userName
          }
        } catch (error) {
          ElMessage.error(t('ErrorMessage.GetErrorMessage'))
        }
      })
      await Promise.all(userPromises)
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
}

onMounted(() => {
  fetchPageData()
})

watch(() => route.params.id, (newId) => {
  postId.value = parseInt(<string>newId)
  fetchPageData()
})

onMounted(() => {
  if (currentUserId.value == 0) {
    router.push('/login')
    ElMessageBox.alert(t('SettingsPage.PleaseLoginFirst'), t('SettingsPage.Notice'), {
      showClose: false
    })
  }
})

async function handleLike() {
  try {
    await axiosInstance.get(`post-like/${postId.value}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`post-like/${postId.value}-${currentUserId.value}`)
      postData.value.likeCount = postData.value.likeCount - 1
      ElMessage.success(t('NewsPage.CanceledLike'))
    } catch {
      ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('post-like', {
        postId: postId.value,
        userId: currentUserId.value,
        likeTime: new Date().toISOString()
      })
      postData.value.likeCount = postData.value.likeCount + 1
      ElMessage.success(t('NewsPage.Liked'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}

async function handleFavorite() {
  try {
    await axiosInstance.get(`post-favorite/${postId.value}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`post-favorite/${postId.value}-${currentUserId.value}`)
      postData.value.favoriteCount = postData.value.favoriteCount - 1
      ElMessage.success(t('NewsPage.CanceledFavorite'))
    } catch {
      ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('post-favorite', {
        postId: postId.value,
        userId: currentUserId.value,
        favoriteTime: new Date().toISOString()
      })
      postData.value.favoriteCount = postData.value.favoriteCount + 1
      ElMessage.success(t('NewsPage.Favorited'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}

async function handleDislike() {
  try {
    await axiosInstance.get(`post-dislike/${postId.value}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`post-dislike/${postId.value}-${currentUserId.value}`)
      ElMessage.success(t('NewsPage.CanceledDislike'))
    } catch {
      ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('post-dislike', {
        postId: postId.value,
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
        postId: postId.value,
        userId: currentUserId.value,
        parentCommentId: null,
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
      await axiosInstance.post('post-report', {
        reporterId: currentUserId.value,
        reportedUserId: postData.value.userId,
        reportedPostId: postId.value,
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
    await axiosInstance.delete(`post/${id}`)
    await router.push('/pet-community')
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
  --post-side-color: #F0F0F0;
  --post-border-color: #DCDFE6;
  --post-background-color: #FFFFFF;
  --post-author-intro-color: #666666;
  --post-date-color: #888888;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --post-side-color: #373737;
  --post-border-color: #4C4D4F;
  --post-background-color: #27292b;
  --post-author-intro-color: #C1C1C1;
  --post-date-color: #888888;
}

.post-side-color {
  background-color: var(--post-side-color);
  min-height: calc(100vh - 135px);
  display: flex;
  flex-direction: column;
}

.post-main-container {
  width: 65%;
  margin: 0 auto;
  min-width: 1200px;
  border-right-style: solid;
  border-left-style: solid;
  border-width: 1px;
  border-color: var(--post-border-color);
  background-color: var(--post-background-color);
  flex: 1;
}

.post-author-card {
  text-align: center;
  padding: 40px;
  line-height: 1.8;
}

.post-author-name {
  font-weight: bold;
  margin-top: 10px;
  line-height: 1.8;
}

.post-author-intro {
  margin-top: 10px;
  color: var(--post-author-intro-color);
  line-height: 1.8;
}

.post-line {
  margin-top: 15px;
  margin-bottom: 15px;
  background: var(--post-border-color);
  width: 1px;
  height: auto;
  position: relative;
  float: left;
}

.post-card {
  margin-bottom: 10px;
  display: flex;
  flex-direction: column;
  margin-left: 15px;
  line-height: 1.8;
}

.post-title {
  font-size: 24px;
  font-weight: bold;
  line-height: 1.8;
}

.post-content {
  margin: 16px 0;
  white-space: pre-wrap;
  line-height: 1.8;
}

.post-date {
  margin-top: 24px;
  color: var(--post-date-color);
  line-height: 1.8;
}

.post-image {
  width: 40%;
  margin-top: 10px;
  border-radius: 5px;
  cursor: pointer;
}

.post-bottom {
  width: 100%;
  display: flex;
  justify-content: space-between;
  margin-bottom: 25px;
}

.post-stats {
  display: flex;
  align-items: center;
  gap: 30px;
  margin-right: 10px;
}

.stat-item {
  display: flex;
  align-items: center;
}

.stat-text {
  font-size: 18px;
  margin-left: 5px;
}

.post-card-like-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(75%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.post-card-dislike-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(75%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.post-card-star-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(75%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.post-card-comment-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(75%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.post-card-like-logo:hover, .post-card-comment-logo:hover, .post-card-star-logo:hover, .post-card-dislike-logo:hover {
  transform: scale(1.1);
}

.post-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.post-delete-button {
  background-color: rgba(244, 67, 54, 0.1);
  border: none;
  color: #FF5722;
  cursor: pointer;
  font-size: 16px;
  padding: 6px 12px;
  margin-right: 12px;
  transition: background-color 0.3s ease, color 0.3s ease;
}

.post-delete-button:hover {
  background-color: rgba(244, 67, 54, 0.2);
  color: #E64A19;
}

.post-date-container {
  display: flex;
  align-items: center;
}

.report-button-icon {
  background-color: transparent;
  border: none;
  color: #FF5722;
  cursor: pointer;
  font-size: 14px;
  margin-left: 16px;
  margin-top: 5px;
}

.report-button-icon:hover {
  color: #E64A19;
}
</style>
