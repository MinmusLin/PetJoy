<!--
  Project Name:  UserInterface
  File Name:     ProfilePage.vue
  File Function: 个人主页页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='page-container'>
    <div class='background-container'/>

    <el-avatar class='avatar' :src='`${ossBaseUrl}${userData.avatarUrl}`'>
      <el-icon :size='100'>
        <Avatar/>
      </el-icon>
    </el-avatar>

    <div class='info-module'>
      <div class='info-left'>
        <p class='name'>{{ userData.userName }}</p>
        <div v-if='isCurrentUser || userData.isLevelPublic'>
          <el-progress :percentage='experiencePercentage'
                       :format='formatLevel'
                       style='width: 300px; margin-left: 0; margin-top: -20px'/>
          <div class='experience-bar'>
            <p class='experience-text'>
              {{ t('HeaderNavbar.NextLevel') }} {{ nextLevel }} |
              {{ t('HeaderNavbar.NeededExperience') }} {{ remainingExperience }}
            </p>
          </div>
        </div>
      </div>

      <div class='info-right'>
        <div class='stats'>
          <div v-if='isCurrentUser || userData.isFollowingCountPublic'>
            <div class='stat'>
              <p class='number'>{{ userData.followsCount }}</p>
              <p class='label'>{{ t('ProfilePage.FollowsCount') }}</p>
              <el-dropdown class='information-icon'>
                <el-icon v-show='followingUsers.length > 0 && isCurrentUser'>
                  <InfoFilled/>
                </el-icon>
                <template #dropdown>
                  <el-dropdown-menu>
                    <el-dropdown-item v-for='user in followingUsers'
                                      :key='user'
                                      @click='router.push(`/profile/${user.userId}`)'>
                      <el-row>
                        <el-col :span='8'>
                          <el-avatar :src='`${ossBaseUrl}${user.avatarUrl}`' alt='avatar' class='user-avatar'>
                            <el-icon :size='28' style='transform: translateX(2px) translateY(-1px)'>
                              <Avatar/>
                            </el-icon>
                          </el-avatar>
                        </el-col>
                        <el-col :span='40'>
                          <div class='user-info'>
                            <p class='user-name'>{{ user.userName }}</p>
                            <p class='user-profile'>{{ user.profile }}</p>
                          </div>
                        </el-col>
                      </el-row>
                    </el-dropdown-item>
                  </el-dropdown-menu>
                </template>
              </el-dropdown>
            </div>
          </div>
          <div v-if='isCurrentUser || userData.isFollowersCountPublic'>
            <div class='stat'>
              <p class='number'>{{ userData.followedCount }}</p>
              <p class='label'>{{ t('ProfilePage.FollowedCount') }}</p>
              <el-dropdown class='information-icon'>
                <el-icon v-show='followersUsers.length > 0 && isCurrentUser'>
                  <InfoFilled/>
                </el-icon>
                <template #dropdown>
                  <el-dropdown-menu>
                    <el-dropdown-item v-for='user in followersUsers'
                                      :key='user'
                                      @click='router.push(`/profile/${user.followerId}`)'>
                      <el-row>
                        <el-col :span='8'>
                          <el-avatar :src='`${ossBaseUrl}${user.avatarUrl}`' alt='avatar' class='user-avatar'>
                            <el-icon :size='28' style='transform: translateX(2px) translateY(-1px)'>
                              <Avatar/>
                            </el-icon>
                          </el-avatar>
                        </el-col>
                        <el-col :span='40'>
                          <div class='user-info'>
                            <p class='user-name'>{{ user.userName }}</p>
                            <p class='user-profile'>{{ user.profile }}</p>
                          </div>
                        </el-col>
                      </el-row>
                    </el-dropdown-item>
                  </el-dropdown-menu>
                </template>
              </el-dropdown>
            </div>
          </div>
          <div v-if='isCurrentUser || userData.isLikedCountPublic'>
            <div class='stat'>
              <p class='number'>{{ userData.likedCount }}</p>
              <p class='label'>{{ t('ProfilePage.LikedCount') }}</p>
            </div>
          </div>
          <div v-if='isCurrentUser || userData.isFavoredCountPublic'>
            <div class='stat'>
              <p class='number'>{{ userData.favoritedCount }}</p>
              <p class='label'>{{ t('ProfilePage.FavoritedCount') }}</p>
            </div>
          </div>
        </div>
        <div v-if='isCurrentUser'>
          <button class='edit-button' @click="router.push('/settings')">
            {{ t('ProfilePage.ModifyPersonalInformation') }}
          </button>
        </div>
        <div v-else-if='userData.allowFollowing'>
          <button class='edit-button' @click='handleFollow'>
            {{ isFollowing ? t('ProfilePage.Followed') : t('ProfilePage.Follow') }}
          </button>
        </div>
      </div>
    </div>

    <div class='modules-container'>
      <div class='profile-module'>
        <h3>{{ t('ProfilePage.PersonalData') }}</h3>
        <div v-if='isCurrentUser || userData.isGenderPublic'>
          <div>
            <span>{{ t('ProfilePage.Gender') }}{{ userData.gender }}</span>
          </div>
          <div class='divider'/>
        </div>
        <div v-if='isCurrentUser || userData.isBirthdatePublic'>
          <div>
            <span>{{ t('ProfilePage.Birthdate') }}{{ userData.birthdate }}</span>
          </div>
          <div class='divider'/>
        </div>
        <div v-if='isCurrentUser || userData.isTelephonePublic'>
          <div>
            <span>{{ t('ProfilePage.Telephone') }}{{ userData.telephone }}</span>
          </div>
          <div class='divider'/>
        </div>
        <div v-if='isCurrentUser || userData.isRegistrationDatePublic'>
          <div>
            <span>{{ t('ProfilePage.RegistrationDate') }}{{ userData.registrationDate }}</span>
          </div>
          <div class='divider'/>
        </div>
        <div v-if='isCurrentUser || userData.isLikesCountPublic'>
          <div>
            <span>{{ t('ProfilePage.LikesCount') }}{{ userData.likesCount }}</span>
          </div>
          <div class='divider'/>
        </div>
        <div v-if='isCurrentUser || userData.isFavoritesCountPublic'>
          <div>
            <span>{{ t('ProfilePage.FavoritesCount') }}{{ userData.favoritesCount }}</span>
          </div>
          <div class='divider'/>
        </div>
        <div v-if='isCurrentUser || userData.isMessageCountPublic'>
          <div>
            <span>{{ t('ProfilePage.MessageCount') }}{{ userData.messageCount }}</span>
          </div>
          <div class='divider'/>
        </div>
        <div v-if='isCurrentUser || userData.isProfilePublic'>
          <div>
            <span>{{ t('ProfilePage.Profile') }}{{ userData.profile }}</span>
          </div>
        </div>
      </div>

      <div class='interaction-module'>
        <div style='display: flex; gap: 20px'>
          <h3 style='cursor: pointer' @click='activeIndex=0' v-if='isCurrentUser'>
            {{ t('ProfilePage.MyFavoriteNews') }}
          </h3>
          <h3 style='cursor: pointer' @click='activeIndex=1' v-if='isCurrentUser'>
            {{ t('ProfilePage.MyFavoritePost') }}
          </h3>
          <h3 style='cursor: pointer' @click='activeIndex=2'>
            {{ isCurrentUser ? t('ProfilePage.MyMessages') : t('ProfilePage.LeaveMessageToMe') }}
          </h3>
        </div>
        <div style='display: flex; flex-direction: column; gap: 10px'>
          <FavoriteNewsCard v-if='activeIndex==0'
                            v-for='newsId in favoriteNewsIds'
                            :key='newsId'
                            :news-id='newsId'/>
          <p v-if='activeIndex==0&&favoriteNewsIds.length==0' class='no-content-prompt'>
            {{ t('ProfilePage.NoFavoriteNews') }}
          </p>
        </div>
        <div>
          <FavoritePostCard v-if='activeIndex==1'
                            v-for='postId in favoritePostIds'
                            :key='postId'
                            :post-id='postId'/>
          <p v-if='activeIndex==1&&favoritePostIds.length==0' class='no-content-prompt'>
            {{ t('ProfilePage.NoFavoritePost') }}
          </p>
        </div>
        <div v-if='activeIndex==2'>
          <div v-if='isCurrentUser'>
            <MessageCard v-if='activeIndex==2'
                         v-for='message in messages'
                         :key='message'
                         :message-id='message.messageId'
                         :commenter-id='message.commenterId'
                         :message='message.message'
                         :comment-time='message.commentTime'/>
            <p v-if='activeIndex==2&&messages.length==0' class='no-content-prompt'>
              {{ t('ProfilePage.NoMessages') }}
            </p>
          </div>
          <div v-else>
            <div style='display: flex; flex-direction: column; align-items: center; margin-top: 53px'>
              <div class='message-prompt'>{{ t('ProfilePage.MessagePrompt') }}</div>
              <el-input v-model='message'
                        style='width: 600px'
                        :placeholder="t('ProfilePage.MessageInputPrompt')"
                        show-word-limit
                        size='large'
                        maxlength='128'/>
              <button class='confirm-bottom' @click='messageConfirm'>
                {{ t('ProfilePage.Confirm') }}
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {useI18n} from 'vue-i18n'
import {computed, onMounted, ref, watch} from 'vue'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import {useRoute, useRouter} from 'vue-router'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import {Avatar, InfoFilled} from '@element-plus/icons-vue'
import FavoriteNewsCard from '../components/FavoriteNewsCard.vue'
import FavoritePostCard from '../components/FavoritePostCard.vue'
import MessageCard from '../components/MessageCard.vue'

type Message = {
  messageId: number
  userId: number
  commenterId: number
  message: String
  commentTime: String
}

type FollowingUser = {
  userId: number
  userName: string
  profile: string
  avatarUrl: string
}

type FollowersUser = {
  followerId: number
  userName: string
  profile: string
  avatarUrl: string
}

const {t} = useI18n()
const route = useRoute()
const router = useRouter()
const profileUserId = ref(parseInt(<string>route.params.id))
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const isCurrentUser = ref(false)
const isFollowing = ref(false)
const nextLevel = computed(() => Math.floor(userData.value.experiencePoints / 1000) + 2)
const experiencePercentage = computed(() => (userData.value.experiencePoints % 1000) / 10)
const remainingExperience = computed(() => (1000 - userData.value.experiencePoints % 1000))
const favoritePostIds = ref([])
const favoriteNewsIds = ref([])
const activeIndex = ref(2)
const message = ref('')
const messages = ref<Message[]>([])
const followingUsers = ref<FollowingUser[]>([])
const followersUsers = ref<FollowersUser[]>([])

const userData = ref({
  userName: '',
  telephone: '',
  registrationDate: '',
  role: 0,
  status: 0,
  avatarUrl: '',
  profile: '',
  gender: '',
  birthdate: '',
  experiencePoints: 0,
  followsCount: 0,
  followedCount: 0,
  favoritesCount: 0,
  favoritedCount: 0,
  likesCount: 0,
  likedCount: 0,
  messageCount: 0,
  isTelephonePublic: false,
  isRegistrationDatePublic: false,
  isProfilePublic: false,
  isGenderPublic: false,
  isBirthdatePublic: false,
  isLevelPublic: false,
  isFollowingCountPublic: false,
  isFollowersCountPublic: false,
  isFavoritesCountPublic: false,
  isFavoredCountPublic: false,
  isLikesCountPublic: false,
  isLikedCountPublic: false,
  isMessageCountPublic: false,
  allowFollowing: false,
  receiveAdminNotifications: false,
  receiveUserNotifications: false
})

const formatLevel = () => {
  return `LV ${Math.floor(userData.value.experiencePoints / 1000) + 1}`
}

const fetchUserData = async () => {
  try {
    const userResponse = await axiosInstance.get(`user/${profileUserId.value}`)
    if (userResponse.status == 404) {
      await router.push('/404')
    } else {
      const userSettingResponse = await axiosInstance.get(`user-setting/${profileUserId.value}`)
      userData.value = {
        userName: userResponse.data.userName,
        telephone: userResponse.data.telephone,
        registrationDate: formatDateTimeToCST(userResponse.data.registrationDate).date,
        role: userResponse.data.role,
        status: userResponse.data.status,
        avatarUrl: userResponse.data.avatarUrl,
        profile: userResponse.data.profile,
        gender: userResponse.data.gender == 0 ? t('RegisterPage.Male') : t('RegisterPage.Female'),
        birthdate: formatDateTimeToCST(userResponse.data.birthdate).date,
        experiencePoints: userResponse.data.experiencePoints,
        followsCount: userResponse.data.followsCount,
        followedCount: userResponse.data.followedCount,
        favoritesCount: userResponse.data.favoritesCount,
        favoritedCount: userResponse.data.favoritedCount,
        likesCount: userResponse.data.likesCount,
        likedCount: userResponse.data.likedCount,
        messageCount: userResponse.data.messageCount,
        isTelephonePublic: userSettingResponse.data.isTelephonePublic == 1,
        isRegistrationDatePublic: userSettingResponse.data.isRegistrationDatePublic == 1,
        isProfilePublic: userSettingResponse.data.isProfilePublic == 1,
        isGenderPublic: userSettingResponse.data.isGenderPublic == 1,
        isBirthdatePublic: userSettingResponse.data.isBirthdatePublic == 1,
        isLevelPublic: userSettingResponse.data.isLevelPublic == 1,
        isFollowingCountPublic: userSettingResponse.data.isFollowingCountPublic == 1,
        isFollowersCountPublic: userSettingResponse.data.isFollowersCountPublic == 1,
        isFavoritesCountPublic: userSettingResponse.data.isFavoritesCountPublic == 1,
        isFavoredCountPublic: userSettingResponse.data.isFavoredCountPublic == 1,
        isLikesCountPublic: userSettingResponse.data.isLikesCountPublic == 1,
        isLikedCountPublic: userSettingResponse.data.isLikedCountPublic == 1,
        isMessageCountPublic: userSettingResponse.data.isMessageCountPublic == 1,
        allowFollowing: userSettingResponse.data.allowFollowing == 1,
        receiveAdminNotifications: userSettingResponse.data.receiveAdminNotifications == 1,
        receiveUserNotifications: userSettingResponse.data.receiveUserNotifications == 1
      }
      isCurrentUser.value = (profileUserId.value == currentUserId.value)
    }
  } catch (error) {
    if (error.response.status == 404) {
      await router.push('/404')
    } else {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
}

onMounted(() => {
  fetchUserData()
})

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`user-message/user/${profileUserId.value}`)
    messages.value = response.data
  } catch {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

watch(() => route.params.id, (newId) => {
  profileUserId.value = parseInt(<string>newId)
  fetchUserData()
})

watch(profileUserId, () => {
  window.location.reload()
})

onMounted(async () => {
  try {
    await axiosInstance.get(`user-follow/${profileUserId.value}-${currentUserId.value}`)
    isFollowing.value = true
  } catch {
    isFollowing.value = false
  }
})

onMounted(async () => {
  try {
    const followingResponse = await axiosInstance.get(`user-follow/following/${currentUserId.value}`)
    followingUsers.value = followingResponse.data
    const followersResponse = await axiosInstance.get(`user-follow/followers/${currentUserId.value}`)
    followersUsers.value = followersResponse.data
  } catch {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

async function handleFollow() {
  if (isFollowing.value) {
    try {
      await axiosInstance.delete(`user-follow/${profileUserId.value}-${currentUserId.value}`)
      isFollowing.value = false
      userData.value.followedCount = userData.value.followedCount - 1
      ElMessage.success(t('ProfilePage.CanceledFollow'))
    } catch {
      ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
    }
  } else {
    try {
      await axiosInstance.post('user-follow', {
        userId: profileUserId.value,
        followerId: currentUserId.value,
        favoriteTime: new Date().toISOString()
      })
      isFollowing.value = true
      userData.value.followedCount = userData.value.followedCount + 1
      ElMessage.success(t('ProfilePage.Followed'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`post-favorite/user/${profileUserId.value}`)
    favoritePostIds.value = response.data
  } catch {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`news-favorite/user/${profileUserId.value}`)
    favoriteNewsIds.value = response.data
  } catch {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

async function messageConfirm() {
  if (!message.value.trim()) {
    ElMessage.warning(t('ProfilePage.MessageCannotBeEmpty'))
    return
  }
  try {
    await axiosInstance.post('user-message', {
      userId: profileUserId.value,
      commenterId: currentUserId.value,
      message: message.value,
      commentTime: new Date().toISOString()
    })
    ElMessage.success(t('ProfilePage.MessageSent'))
    userData.value.messageCount = userData.value.messageCount + 1
    message.value = ''
  } catch {
    ElMessage.error(t('ErrorMessage.PostErrorMessage'))
  }
}
</script>

<style scoped>
:global(:root) {
  --profile-page-container-color: #F5F5F5;
  --profile-module-color: #FFFFFF;
  --profile-content-color1: #002357;
  --profile-content-color2: #0360A3;
  --profile-divider-color: #0000000C;
  --profile-button-color: #FFFFFF;
  --profile-button-content-color: #0360A3;
  --profile-button-border-color: #0360A3;
  --profile-button-hover-color: #EBF3FF;
  --profile-info-border-color: #F5F5F5;
  --profile-background-image: linear-gradient(rgba(255, 255, 255, 0.2), rgba(255, 255, 255, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/ProfilePageBackgroundImage.jpg');
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --profile-page-container-color: #061122;
  --profile-module-color: #0E1D33;
  --profile-content-color1: #5ABAFF;
  --profile-content-color2: #5ABAFF;
  --profile-divider-color: #FFFFFF33;
  --profile-button-color: #0762A7;
  --profile-button-content-color: #FFFFFF;
  --profile-button-border-color: #033C63;
  --profile-button-hover-color: #1172BE;
  --profile-info-border-color: #0E1D33;
  --profile-background-image: linear-gradient(rgba(0, 0, 0, 0.2), rgba(0, 0, 0, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/ProfilePageBackgroundImage.jpg');
}

.page-container {
  width: 1200px;
  align-self: center;
  display: flex;
  flex-direction: column;
  position: relative;
  background-color: var(--profile-page-container-color);
  min-height: calc(100vh - 135px);
}

.background-container {
  height: 250px;
  width: 100%;
  background-image: var(--profile-background-image);
  background-size: cover;
  background-position: center;
}

.avatar {
  position: absolute;
  height: 165px;
  width: 165px;
  left: 120px;
  top: 180px;
  transform: translateX(-50%);
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
}

.info-module {
  width: 1198px;
  display: flex;
  background-color: var(--profile-module-color);
  border-left: 1px solid var(--profile-info-border-color);
  border-right: 1px solid var(--profile-info-border-color);
}

.info-left {
  flex: 1;
  margin-left: 240px;
}

.name {
  font-size: 26px;
  font-weight: bold;
  color: var(--profile-content-color1);
}

.experience-text {
  font-size: 14px;
  color: var(--el-color-info-light-3);
}

.info-right {
  display: flex;
  align-items: center;
  margin-right: 20px;
  margin-top: 50px;
}

.stats {
  display: flex;
  margin-bottom: 10px;
}

.stat {
  text-align: center;
  min-width: 50px;
  margin-right: 40px;
  position: relative;
}

.number {
  font-size: 20px;
  font-weight: bold;
  color: var(--profile-content-color2);
  margin-bottom: -10px;
}

.label {
  font-size: 12px;
  color: var(--profile-content-color2);
}

.edit-button {
  background-color: var(--profile-button-color);
  border: 2px solid var(--profile-button-border-color);
  color: var(--profile-button-content-color);
  width: 220px;
  height: 50px;
  cursor: pointer;
  border-radius: 20px;
  transition: background-color 0.3s ease;
}

.edit-button:hover {
  background-color: var(--profile-button-hover-color);
}

.modules-container {
  display: flex;
  justify-content: space-between;
  padding-top: 25px;
  padding-bottom: 25px;
}

.profile-module {
  width: 320px;
  background-color: var(--profile-module-color);
  padding: 15px;
  border-radius: 14px;
  margin-left: 20px;
}

.divider {
  height: 1px;
  background-color: var(--profile-divider-color);
  margin: 10px 0;
}

.interaction-module {
  width: 750px;
  background-color: var(--profile-module-color);
  padding: 15px;
  border-radius: 14px;
  margin-right: 20px;
}

h3 {
  margin-top: 0;
  color: var(--profile-content-color2);
}

.confirm-bottom {
  align-self: center;
  background-color: var(--profile-button-color);
  border: 2px solid var(--profile-button-border-color);
  color: var(--profile-button-content-color);
  width: 220px;
  height: 40px;
  cursor: pointer;
  border-radius: 20px;
  transition: background-color 0.3s ease;
  margin-top: 30px;
}

.confirm-bottom:hover {
  background-color: var(--profile-button-hover-color);
}

.message-prompt {
  margin-bottom: 30px;
  text-align: center;
  color: var(--profile-content-color2);
}

.no-content-prompt {
  text-align: center;
  display: flex;
  flex-direction: column;
  color: var(--profile-content-color2);
  margin-top: 124px;
}

.information-icon {
  position: absolute;
  top: -14px;
  right: -10px;
  color: #E6A23C;
  outline: none;
}

.user-avatar {
  width: 40px;
  height: 40px;
  border-radius: 50%;
  margin-right: 20px;
}

.user-info {
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.user-name {
  font-weight: bold;
  margin: 0;
}

.user-profile {
  font-size: 12px;
  color: #888;
  margin: 0;
  width: 120px;
  max-width: 180px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
