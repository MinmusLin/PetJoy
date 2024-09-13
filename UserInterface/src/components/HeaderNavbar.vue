<!--
  Project Name:  UserInterface
  File Name:     HeaderNavbar.vue
  File Function: 顶部导航栏组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <el-menu :default-active='activeIndex' class='header-navbar' mode='horizontal' :ellipsis='false'>
    <el-container ref='tourRef1' class='logo-title' @click="router.push('/')">
      <img :src='`${ossBaseUrl}LogosAndIcons/PetJoyIcon.png`' style='height: 45px; margin-left: 10px' alt='PetJoyIcon'>
      <h1 style='white-space: nowrap'>宠悦 PetJoy</h1>
    </el-container>

    <el-menu-item ref='tourRef2' index='1' class='navbar-item' @click="router.push('/pet-community')">
      {{ t('HeaderNavbar.PetCommunity') }}
    </el-menu-item>
    <el-menu-item ref='tourRef3' index='2' class='navbar-item' @click="router.push('/pet-news')">
      {{ t('HeaderNavbar.PetNews') }}
    </el-menu-item>
    <el-menu-item ref='tourRef4' index='3' class='navbar-item' @click="router.push('/pet-adoption')">
      {{ t('HeaderNavbar.PetAdoption') }}
    </el-menu-item>
    <el-menu-item ref='tourRef5' index='4' class='navbar-item' @click="router.push('/pet-encyclopedia')">
      {{ t('HeaderNavbar.PetEncyclopedia') }}
    </el-menu-item>
    <el-menu-item ref='tourRef6' index='5' class='navbar-item' @click="router.push('/pet-care')">
      {{ t('HeaderNavbar.PetCare') }}
    </el-menu-item>
    <el-menu-item ref='tourRef7' index='6' class='navbar-item' @click="router.push('/pet-ai')">
      {{ t('HeaderNavbar.PetAI') }}
    </el-menu-item>

    <div class='flex-grow'/>

    <el-dropdown size='large' :class="{ 'disable-dropdown': currentUserId == 0 || currentUserRole != 1 }">
      <el-icon v-if='currentUserId != 0 && currentUserRole == 1'
               color='#4888F6'
               :size='24'
               style='margin-right: 8px; margin-bottom: 2px; outline: none'>
        <Operation/>
      </el-icon>
      <el-icon v-else
               color='#00000000'
               :size='24'
               style='margin-right: 8px; margin-bottom: 2px; outline: none'>
        <Operation/>
      </el-icon>
      <template #dropdown>
        <el-dropdown-menu>
          <el-dropdown-item @click="router.push('/post-report-management')">
            {{ t('HeaderNavbar.PostReportManagement') }}
          </el-dropdown-item>
          <el-dropdown-item @click="router.push('/post-comment-report-management')">
            {{ t('HeaderNavbar.PostCommentReportManagement') }}
          </el-dropdown-item>
          <el-dropdown-item @click="router.push('/news-comment-report-management')">
            {{ t('HeaderNavbar.NewsCommentReportManagement') }}
          </el-dropdown-item>
          <el-dropdown-item @click="router.push('/news-management')">
            {{ t('NewsManagementPage.NewsManagement') }}
          </el-dropdown-item>
          <el-dropdown-item @click="router.push('/user-feedback-management')">
            {{ t('HeaderNavbar.UserFeedbackManagement') }}
          </el-dropdown-item>
          <el-dropdown-item @click="router.push('/api')">
            {{ t('HeaderNavbar.DatabaseWebAPI') }}
          </el-dropdown-item>
        </el-dropdown-menu>
      </template>
    </el-dropdown>

    <el-popover :width='350' popper-style='box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); padding: 15px'>
      <template #reference>
        <el-icon ref='tourRef8' color='#4888F6' :size='24' style='margin-right: 10px; margin-bottom: 2px'>
          <Sunny/>
        </el-icon>
      </template>
      <template #default>
        <WeatherForecast/>
      </template>
    </el-popover>

    <el-dropdown ref='tourRef9' size='large'>
      <p v-html='languageIconSvg' style='outline: none'/>
      <template #dropdown>
        <el-dropdown-menu>
          <el-dropdown-item @click="toggleLanguage('zh')" :disabled="locale == 'zh'">简体中文</el-dropdown-item>
          <el-dropdown-item @click="toggleLanguage('en')" :disabled="locale == 'en'">English</el-dropdown-item>
          <el-dropdown-item @click="toggleLanguage('es')" :disabled="locale == 'es'">Español</el-dropdown-item>
          <el-dropdown-item @click="toggleLanguage('ru')" :disabled="locale == 'ru'">Русский</el-dropdown-item>
          <el-dropdown-item @click="toggleLanguage('pt')" :disabled="locale == 'pt'">Português</el-dropdown-item>
          <el-dropdown-item @click="toggleLanguage('ja')" :disabled="locale == 'ja'">日本語</el-dropdown-item>
          <el-dropdown-item @click="toggleLanguage('de')" :disabled="locale == 'de'">Deutsch</el-dropdown-item>
          <el-dropdown-item @click="toggleLanguage('ko')" :disabled="locale == 'ko'">한국어</el-dropdown-item>
          <el-dropdown-item @click="toggleLanguage('fr')" :disabled="locale == 'fr'">Français</el-dropdown-item>
          <el-dropdown-item @click="toggleLanguage('it')" :disabled="locale == 'it'">Italiano</el-dropdown-item>
        </el-dropdown-menu>
      </template>
    </el-dropdown>

    <el-switch class='mode-switch'
               v-model='darkMode'
               size='large'
               ref='tourRef10'
               style='--el-switch-on-color: #2C2C2C; --el-switch-off-color: #F2F2F2; --el-switch-border-color: var(--el-color-info-light-7)'
               @change='toggleDarkMode'>
      <template #active-action>
        <el-icon>
          <Moon/>
        </el-icon>
      </template>
      <template #inactive-action>
        <el-icon class='icon-reverse'>
          <Sunny/>
        </el-icon>
      </template>
    </el-switch>

    <el-dropdown ref='tourRef11' size='large'>
      <el-avatar class='avatar' :src='`${ossBaseUrl}${currentUserAvatarUrl}`'>
        <el-icon :size='24'>
          <Avatar/>
        </el-icon>
      </el-avatar>
      <template #dropdown>
        <el-dropdown-menu style='width: 210px' v-if='currentUserId==0'>
          <h2 style='text-align: center'>{{ t('HomePage.TourRefTitle11') }}</h2>

          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='Connection' @click="router.push('/login')">
            <div class='dropdown-item'>
              <span>{{ t('HeaderNavbar.Login') }}</span>
              <span><el-icon :size='12' class='dropdown-item-icon'><ArrowRightBold/></el-icon></span>
            </div>
          </el-dropdown-item>

          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='CirclePlus' @click="router.push('/register')">
            <div class='dropdown-item'>
              <span>{{ t('HeaderNavbar.Register') }}</span>
              <span><el-icon :size='12' class='dropdown-item-icon'><ArrowRightBold/></el-icon></span>
            </div>
          </el-dropdown-item>

          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='Key' @click="router.push('/reset-password')">
            <div class='dropdown-item'>
              <span>{{ t('LoginPage.ForgetPassword') }}</span>
              <span><el-icon :size='12' class='dropdown-item-icon'><ArrowRightBold/></el-icon></span>
            </div>
          </el-dropdown-item>

          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='SetUp' @click="router.push('/'); showGuidedTour=true">
            <div class='dropdown-item'>
              <span>{{ t('HeaderNavbar.GuidedTour') }}</span>
              <span><el-icon :size='12' class='dropdown-item-icon'><ArrowRightBold/></el-icon></span>
            </div>
          </el-dropdown-item>
        </el-dropdown-menu>

        <el-dropdown-menu v-else style='width: 250px'>
          <el-icon v-if='!checkedIn' size='24' color="#409EFF" class='check-icon' @click='checkIn'
                   style='cursor: pointer'>
            <Checked/>
          </el-icon>
          <el-tooltip :content="t('HeaderNavbar.CheckReminder')" placement='bottom'>
            <el-icon v-if='checkedIn' size='24' color='#909399' class='check-icon'>
              <Checked/>
            </el-icon>
          </el-tooltip>

          <div style='display: flex; align-items: center; justify-content: center; border-radius: 50%'
               @click="router.push('/settings')">
            <div class='avatar-container'>
              <el-avatar :src='`${ossBaseUrl}${currentUserAvatarUrl}`' class='dropdown-item-avatar'>
                <el-icon :size='80'>
                  <Avatar/>
                </el-icon>
              </el-avatar>
              <el-icon class='edit-icon'>
                <Edit/>
              </el-icon>
            </div>
          </div>

          <h2 style='display: flex; justify-content: center; font-size: 24px'>
            {{ currentUserName }}
          </h2>

          <el-progress :percentage='experiencePercentage' :format='formatLevel' style='margin-left: 22px'/>

          <div class='experience-bar'>
            <p class='experience-text'>
              {{ t('HeaderNavbar.NextLevel') }} {{ nextLevel }} |
              {{ t('HeaderNavbar.NeededExperience') }} {{ remainingExperience }}
            </p>
          </div>

          <div style='display: flex; width: 220px; padding-bottom: 16px; margin: 0 auto'>
            <el-col :span='8' style='display: flex; justify-content: center'>
              <el-statistic :value='userFollowsCount' :title="t('HeaderNavbar.Following')" style='text-align: center'/>
            </el-col>
            <el-col :span='8' style='display: flex; justify-content: center'>
              <el-statistic :value='userFollowedCount' :title="t('HeaderNavbar.Followers')" style='text-align: center'/>
            </el-col>
            <el-col :span='8' style='display: flex; justify-content: center'>
              <el-statistic :value='userLikedCount' :title="t('HeaderNavbar.Likes')" style='text-align: center'/>
            </el-col>
          </div>

          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='User' @click='router.push(`/profile/${currentUserId}`)'>
            <div class='dropdown-item'>
              <span>{{ t('HeaderNavbar.Profile') }}</span>
              <span><el-icon :size='12' class='dropdown-item-icon'><ArrowRightBold/></el-icon></span>
            </div>
          </el-dropdown-item>

          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='Setting' @click="router.push('/settings')">
            <div class='dropdown-item'>
              <span>{{ t('HeaderNavbar.Settings') }}</span>
              <span><el-icon :size='12' class='dropdown-item-icon'><ArrowRightBold/></el-icon></span>
            </div>
          </el-dropdown-item>

          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='SetUp' @click="router.push('/'); showGuidedTour=true">
            <div class='dropdown-item'>
              <span>{{ t('HeaderNavbar.GuidedTour') }}</span>
              <span><el-icon :size='12' class='dropdown-item-icon'><ArrowRightBold/></el-icon></span>
            </div>
          </el-dropdown-item>

          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='Link' @click='logout'>
            <div class='dropdown-item'>
              <span>{{ t('HeaderNavbar.Logout') }}</span>
              <span><el-icon :size='12' class='dropdown-item-icon'><ArrowRightBold/></el-icon></span>
            </div>
          </el-dropdown-item>
        </el-dropdown-menu>
      </template>
    </el-dropdown>
  </el-menu>
</template>

<script setup lang='ts'>
import {onMounted, ref, watch, onUnmounted, computed} from 'vue'
import {useRouter, useRoute} from 'vue-router'
import {useI18n} from 'vue-i18n'
import axiosInstance from '../utils/axios'
import {ElMessage, ElNotification} from 'element-plus'
import {
  ossBaseUrl,
  tourRef1,
  tourRef2,
  tourRef3,
  tourRef4,
  tourRef5,
  tourRef6,
  tourRef7,
  tourRef8,
  tourRef9,
  tourRef10,
  tourRef11, showGuidedTour
} from '../globals'
import {
  Sunny,
  Moon,
  User,
  Setting,
  Connection,
  Link,
  CirclePlus,
  Avatar,
  ArrowRightBold,
  Edit,
  SetUp,
  Key,
  Operation,
  Checked
} from '@element-plus/icons-vue'
import WeatherForecast from './WeatherForecast.vue'

const {locale, t} = useI18n()
const activeIndex = ref('0')
const darkMode = ref(localStorage.getItem('darkMode') == 'true')
const router = useRouter()
const route = useRoute()
const languageIconSvg = atob('PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnY9Imh0dHBzOi8vdmVjdGEuaW8vbmFubyIgd2lkdGg9IjIwIiBoZWlnaHQ9IjE4IiB2aWV3Qm94PSIwIDAgMjAgMTgiPiYjeGE7CTxzdHlsZSB0eXBlPSJ0ZXh0L2NzcyI+JiN4YTsJLnN0MHtmaWxsOiM0Mjg1ZjQ7fSYjeGE7CS5zdDF7ZmlsbDojNjY5ZGY2O2ZpbGwtcnVsZTpldmVub2RkfSYjeGE7CTwvc3R5bGU+JiN4YTsJPHBhdGggY2xhc3M9InN0MCIgZD0iTTE1LjkxIDcuMmgtMS44MkwxMCAxOGgxLjgybDEtMi43aDQuMzJsMSAyLjdIMjB6bS0yLjM5IDYuM0wxNSA5LjZsMS40OCAzLjl6Ii8+JiN4YTsJPHBhdGggY2xhc3M9InN0MSIgZD0iTTEwLjc5IDExLjc3TDguNDggOS41MWgwYTE1LjYyIDE1LjYyIDAgMCAwIDMuNC01LjkxaDIuNjdWMS44SDguMThWMEg2LjM2djEuOEgwdjEuNzloMTAuMTVhMTQuMDYgMTQuMDYgMCAwIDEtMi44OCA0LjgyIDE0LjU1IDE0LjU1IDAgMCAxLTIuMS0zSDMuMzVhMTYgMTYgMCAwIDAgMi43MSA0LjFMMS40NCAxNGwxLjI5IDEuMyA0LjU0LTQuNSAyLjgzIDIuOHoiLz4mI3hhOzwvc3ZnPg==')
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const currentUserAvatarUrl = ref('')
const currentUserName = ref('')
const currentUserRole = ref(0)
const userExperiencePoints = ref(0)
const userFollowsCount = ref(0)
const userFollowedCount = ref(0)
const userLikedCount = ref(0)
const checkedIn = ref(false)
const nextLevel = computed(() => Math.floor(userExperiencePoints.value / 1000) + 2)
const experiencePercentage = computed(() => (userExperiencePoints.value % 1000) / 10)
const remainingExperience = computed(() => (1000 - userExperiencePoints.value % 1000))

const toggleDarkMode = () => {
  const htmlElement = document.documentElement
  const isDarkMode = localStorage.getItem('darkMode') == 'true'
  localStorage.setItem('darkMode', (!isDarkMode).toString())
  if (isDarkMode) {
    htmlElement.classList.remove('dark')
    htmlElement.classList.add('light')
  } else {
    htmlElement.classList.remove('light')
    htmlElement.classList.add('dark')
  }
}

document.addEventListener('DOMContentLoaded', () => {
  const htmlElement = document.documentElement
  const isDarkMode = localStorage.getItem('darkMode') == 'true'
  if (isDarkMode) {
    htmlElement.classList.add('dark')
  } else {
    htmlElement.classList.add('light')
  }
})

const toggleLanguage = (lang: string) => {
  // noinspection TypeScriptValidateTypes
  locale.value = lang
  localStorage.setItem('defaultLanguage', lang)
  window.location.reload()
}

const formatLevel = () => {
  return `LV ${Math.floor(userExperiencePoints.value / 1000) + 1}`
}

watch(route, (newRoute) => {
  switch (newRoute.path) {
    case '/pet-community':
      activeIndex.value = '1'
      break
    case '/pet-news':
      activeIndex.value = '2'
      break
    case '/pet-adoption':
      activeIndex.value = '3'
      break
    case '/pet-encyclopedia':
      activeIndex.value = '4'
      break
    case '/pet-care':
      activeIndex.value = '5'
      break
    case '/pet-ai':
      activeIndex.value = '6'
      break
    default:
      activeIndex.value = '0'
      break
  }
}, {immediate: true})

function logout() {
  localStorage.setItem('currentUserId', '0')
  router.push('/')
  window.location.href = '/'
}

onMounted(async () => {
  if (currentUserId.value != 0) {
    try {
      const response = await axiosInstance.get(`user/${currentUserId.value}`)
      currentUserAvatarUrl.value = response.data.avatarUrl
      currentUserName.value = response.data.userName
      userFollowsCount.value = response.data.followsCount
      userFollowedCount.value = response.data.followedCount
      userLikedCount.value = response.data.likedCount
      userExperiencePoints.value = response.data.experiencePoints
      currentUserRole.value = response.data.role
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
})

onMounted(async () => {
  try {
    const date = new Date()
    const now = new Date(date.getFullYear(), date.getMonth(), date.getDate())
    const formattedDate = now.toISOString().slice(0, 10).replace(/-/g, '')
    const response = await axiosInstance.get(`user-check-in/check-by-date/${currentUserId.value}-${formattedDate}`)
    checkedIn.value = response.data == 1
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

const handleScroll = () => {
  const header = document.querySelector('.header-navbar')
  if (window.scrollY > 60) {
    header.classList.add('transparent-header')
  } else {
    header.classList.remove('transparent-header')
  }
}

onMounted(() => {
  window.addEventListener('scroll', handleScroll)
})

onUnmounted(() => {
  window.removeEventListener('scroll', handleScroll)
})

async function checkIn() {
  const date = new Date()
  const formattedDate = new Date(date.getFullYear(), date.getMonth(), date.getDate())
  try {
    await axiosInstance.post('user-check-in', {
      userId: currentUserId.value,
      checkInTime: formattedDate
    })
    ElNotification({
      title: t('HeaderNavbar.CheckSuccessfully'),
      message: t('HeaderNavbar.CheckSuccessfullyPrompt'),
      type: 'success'
    })
    userExperiencePoints.value = userExperiencePoints.value + 100
    checkedIn.value = true
  } catch (error) {
    ElNotification({
      title: t('HeaderNavbar.CheckFailed'),
      message: t('HeaderNavbar.CheckFailedPrompt'),
      type: 'error'
    })
  }
}
</script>

<style scoped>
.header-navbar {
  margin-top: 5px;
  align-items: center;
  height: 60px;
  min-width: 1200px;
  border-bottom-left-radius: 10px;
  border-bottom-right-radius: 10px;
  overflow: auto;
}

.logo-title {
  max-width: 210px;
  display: flex;
  align-items: center;
  cursor: pointer;
  transition: transform 0.3s ease, color 0.3s ease;
}

.logo-title:hover {
  transform: scale(1.05);
  color: var(--el-color-primary);
}

h1 {
  font-size: 24px;
  margin: 10px 10px;
}

.navbar-item {
  font-size: 16px;
}

.flex-grow {
  flex-grow: 1;
}

.avatar {
  margin-right: 10px;
  outline: none;
}

.mode-switch {
  margin-left: 10px;
  margin-right: 10px;
}

.icon-reverse {
  filter: invert(100%);
}

.experience-bar {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding-bottom: 4px;
}

.experience-text {
  font-size: 12px;
  color: var(--el-color-info-light-3);
  text-align: center;
  padding: 0 10px;
  margin-top: 10px;
}

.dropdown-item {
  display: flex;
  justify-content: space-between;
  width: 100%;
}

.dropdown-item-icon {
  margin-right: 0;
}

.dropdown-item-avatar {
  width: 120px;
  height: 120px;
  margin-top: 10px;
}

.avatar-container {
  cursor: pointer;
  border-radius: 50%;
  overflow: visible;
  position: relative;
}

.dropdown-item-avatar {
  transition: filter 0.3s ease;
}

.avatar-container:hover .dropdown-item-avatar {
  filter: brightness(75%);
}

.edit-icon {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  color: lightgray;
  opacity: 0;
  font-size: 30px;
  transition: opacity 0.3s ease, transform 0.3s ease;
}

.avatar-container:hover .edit-icon {
  display: block;
  opacity: 1;
}

.check-icon {
  position: absolute;
  top: 6%;
  right: 15px;
  transform: translateY(-50%);
}

.disable-dropdown {
  pointer-events: none;
  opacity: 0.5;
}
</style>
