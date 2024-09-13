<!--
  Project Name:  UserInterface
  File Name:     PetNewsPage.vue
  File Function: 宠物新闻页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-05
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='background-container'>
    <h1>{{ t('HeaderNavbar.PetNews') }}</h1>
    <div class='search-container'>
      <NewsSearchBox/>
    </div>
    <el-button v-if='isAdministrator' class='new-management-button' round @click="router.push('/news-management')">
      {{ t('NewsManagementPage.NewsManagement') }}
    </el-button>
  </div>

  <div class='content-container'>
    <div class='news-top-background-container'>
      <div class='news-top-container'>
        <div class='news-carousel'>
          <el-carousel height='420px' indicator-position='none'>
            <el-carousel-item v-for='news in newsList' :key='news.newsId'>
              <img :src='`${ossBaseUrl}${news.coverUrl}`'
                   alt='news cover'
                   class='news-cover'
                   @click='goToNewsPage(news.newsId)'/>
              <div class='news-details'>
                <h2 @click='goToNewsPage(news.newsId)'>{{ news.title }}</h2>
                <p @click='goToNewsPage(news.newsId)'>{{ news.summary }}</p>
                <div class='like-container'>
                  <img :src='`${ossBaseUrl}LogosAndIcons/Like.png`' class='like-logo' alt='LikeLogo' height='18px'/>
                  <div>{{ news.likeCount }}</div>
                </div>
              </div>
            </el-carousel-item>
          </el-carousel>
        </div>

        <div class='news-titles'>
          <h2 class='news-titles-header'>{{ t('NewsPage.TopNewsList') }}</h2>
          <ul>
            <li v-for='news in newsList' :key='news.newsId'>
              <h3 @click='goToNewsPage(news.newsId)'>{{ news.title }}</h3>
              <p>{{ formatDateTimeToCST(news.creationDate).date }}</p>
            </li>
          </ul>
        </div>
      </div>
    </div>

    <div class='filter-container'>
      <el-checkbox-group v-model='selectedTags' @change='filterNewsByTags'>
        <el-checkbox v-for='tag in tagFilters' :label='tag.value' :key='tag.value'>
          <p style='font-size: 16px; transform: translateY(-1px)'>{{ tag.text }}</p>
        </el-checkbox>
      </el-checkbox-group>
      <div class='refresh-container'>
        <el-icon @click='refreshFilter' class='refresh-icon' v-if='showRefreshButton'>
          <Refresh/>
        </el-icon>
      </div>
    </div>
  </div>

  <div class='news-card-container'>
    <div class='news-card' v-for='newsId in paginatedNewsIds' :key='newsId'>
      <NewsCard :news-id='newsId'/>
    </div>
    <el-pagination v-model:current-page='currentPage'
                   :page-size='pageSize'
                   :total='filteredNewsIds.length'
                   layout='prev, pager, next'
                   class='pagination'/>
  </div>
</template>

<script setup lang='ts'>
import {onMounted, ref, computed} from 'vue'
import {useI18n} from 'vue-i18n'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import {useRouter} from 'vue-router'
import NewsSearchBox from '../components/NewsSearchBox.vue'
import NewsCard from '../components/NewsCard.vue'
import {ElPagination, ElCheckbox, ElCheckboxGroup, ElMessage} from 'element-plus'
import axiosInstance from '../utils/axios'
import {Refresh} from '@element-plus/icons-vue'

const {t} = useI18n()
const pageSize = 16
const currentPage = ref(1)
const selectedTags = ref<number[]>([])
const tagFilters = ref<{ value: number; text: string }[]>([])
const filteredNewsIds = ref<number[]>([])
const allTagIds = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
const router = useRouter()
const newsList = ref<news[]>([])
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const isAdministrator = ref(false)

type news = {
  newsId: number
  title: string
  summary: string
  coverUrl: string
  likeCount: number
  creationDate: string
}

const paginatedNewsIds = computed(() => {
  const start = (currentPage.value - 1) * pageSize
  return filteredNewsIds.value.slice(start, start + pageSize)
})

const goToNewsPage = (newsId: number) => {
  router.push(`news/${newsId}`)
}

const fetchNewsData = async () => {
  try {
    const response = await axiosInstance.get('news/top-news')
    newsList.value = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
}

onMounted(() => {
  fetchNewsData()
})

onMounted(async () => {
  try {
    await filterNewsByTags()
    const tagsSet = new Set<{ value: number; text: string }>()
    const tagsResponse = await axiosInstance.get('news-tag')
    const sortedTags = tagsResponse.data.sort((a: { tagId: number }, b: { tagId: number }) => {
      return a.tagId - b.tagId
    })
    sortedTags.forEach(tag => {
      tagsSet.add({text: tag.tag, value: tag.tagId})
    })
    tagFilters.value = Array.from(tagsSet)
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

async function filterNewsByTags() {
  currentPage.value = 1
  if (selectedTags.value.length == 0) {
    try {
      const response = await axiosInstance.post('news/filter-by-tag', allTagIds)
      filteredNewsIds.value = response.data
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  } else {
    try {
      const response = await axiosInstance.post('news/filter-by-tag', selectedTags.value)
      filteredNewsIds.value = response.data
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}

const refreshFilter = () => {
  selectedTags.value = []
  filterNewsByTags()
}

const showRefreshButton = computed(() => {
  return selectedTags.value.length > 0
})

onMounted(async () => {
  if (currentUserId.value != 0) {
    try {
      const response = await axiosInstance.get(`user/role/${currentUserId.value}`)
      isAdministrator.value = response.data == 1
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
})
</script>

<style scoped>
:global(:root) {
  --news-background-image: linear-gradient(rgba(255, 255, 255, 0.2), rgba(255, 255, 255, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetNewsPageBackgroundImage.jpg');
  --news-title-color: #043278;
  --news-title-shadow-color: #7392B6;
  --news-top-background: #F0F9FF;
  --news-title-lighten: #003A9E;
  --news-refresh-button-color: #007BFF;
  --news-refresh-button-hover-color: #0056B3;
  --news-management-button-color: #083479;
  --news-management-button-hover-color: #0F53BD;
  --news-management-button-active-color: #051B43;
  --news-management-button-text-color: #87C2FF;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --news-background-image: linear-gradient(rgba(0, 0, 0, 0.2), rgba(0, 0, 0, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetNewsPageBackgroundImage.jpg');
  --news-title-color: #B2D5FB;
  --news-title-shadow-color: #3B5A88;
  --news-top-background: #122B44;
  --news-title-lighten: #4A90E2;
  --news-refresh-button-color: #3B97FF;
  --news-refresh-button-hover-color: #4580B8;
  --news-management-button-color: #87C2FF;
  --news-management-button-hover-color: #4D96FF;
  --news-management-button-active-color: #4CA7FF;
  --news-management-button-text-color: #083479;
}

.content-container {
  display: flex;
  justify-content: space-between;
  max-width: 1200px;
  margin: 10px auto 0;
}

.news-top-container {
  display: flex;
  width: 1015px;
}

.news-top-background-container {
  display: flex;
  width: 1042px;
  border-radius: 5px;
  background-color: var(--news-top-background);
}

.news-carousel {
  width: 475px;
  margin-top: 20px;
  margin-left: 25px;
}

.news-cover {
  width: 435px;
  height: 240px;
  object-fit: cover;
  border-radius: 10px;
  cursor: pointer;
}

.news-details {
  text-align: justify;
  width: 430px;
  margin-top: -10px;
}

.news-details p {
  text-align: justify;
  width: 430px;
  display: -webkit-box;
  -webkit-box-orient: vertical;
  overflow: hidden;
  -webkit-line-clamp: 2;
  line-clamp: 3;
  white-space: normal;
  word-break: break-all;
  margin-top: -10px;
  cursor: pointer;
  font-size: 14px;
  line-height: 1.4;
}

.news-details h2 {
  cursor: pointer;
  font-size: 24px;
  line-height: 1.4;
}

.news-titles {
  width: 570px;
  margin-left: 25px;
  margin-top: 5px;
}

.news-titles-header {
  font-size: 28px;
  color: var(--news-title-color);
  margin-bottom: 10px;
  margin-top: 15px;
  font-weight: bold;
}

.news-titles ul {
  list-style: none;
  padding: 0;
}

.news-titles li {
  margin-bottom: 14px;
  display: flex;
  align-items: center;
  white-space: nowrap;
  justify-content: space-between;
}

.news-titles h3 {
  margin: 0;
  font-weight: 500;
  font-size: 16px;
  flex-grow: 1;
  max-width: 415px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  transition: color 0.3s ease;
  cursor: pointer;
}

.news-titles h3:hover {
  color: var(--news-title-lighten);
}

.news-titles p {
  margin: 0 0 0 10px;
  font-size: 14px;
  color: #666666;
  white-space: nowrap;
  padding-left: 20px;
  text-align: right;
}

h1 {
  width: 1200px;
  position: absolute;
  top: 12%;
  left: 50%;
  font-size: 64px;
  font-weight: bold;
  color: var(--news-title-color);
  text-align: center;
  transform: translateX(-50%);
  text-shadow: 0 2px 4px var(--news-title-shadow-color);
}

.search-container {
  position: absolute;
  top: 250px;
  left: 50%;
  transform: translateX(-50%);
  z-index: 1001;
}

.background-container {
  height: 530px;
  width: 100%;
  background-image: var(--news-background-image);
  background-size: cover;
  background-position: center;
  transform: translateY(-10px);
  z-index: 1;
}

.filter-container {
  width: 100px;
  margin-left: 20px;
  padding-left: 24px;
  padding-right: 14px;
  padding-top: 19px;
  background-color: var(--news-top-background);
  border-radius: 5px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  transform: translateX(2px);
  position: relative;
}

.news-card-container {
  width: 1200px;
  margin: 0 auto;
}

.news-card {
  display: inline-block;
  margin-top: 20px;
}

.pagination {
  margin-top: 18px;
  margin-bottom: 20px;
  text-align: center;
  display: flex;
  justify-content: center;
}

.like-container {
  display: flex;
  align-items: center;
  margin-top: -5px;
}

.like-logo {
  margin-right: 10px;
  filter: invert(29%) sepia(91%) saturate(3833%) hue-rotate(334deg) brightness(85%) contrast(102%);
}

/* noinspection CssUnusedSymbol */
.filter-container .el-checkbox {
  margin-bottom: 5px;
}

/* noinspection CssUnusedSymbol */
.filter-container .el-checkbox:last-child {
  margin-bottom: 0;
}

.refresh-container {
  position: absolute;
  top: 5px;
  right: 5px;
}

.refresh-icon {
  font-size: 20px;
  cursor: pointer;
  transition: color 0.3s;
  color: var(--news-refresh-button-color);
}

.refresh-icon:hover {
  color: var(--news-refresh-button-hover-color);
}

.new-management-button {
  position: absolute;
  top: 75%;
  left: 50%;
  width: 250px;
  height: 50px;
  font-size: 20px;
  font-weight: bold;
  color: var(--news-management-button-text-color);
  background-color: var(--news-management-button-color);
  border: none;
  border-radius: 10px;
  transform: translate(-50%, -50%);
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.3);
  transition: background-color 0.3s;
}

.new-management-button:hover {
  background-color: var(--news-management-button-hover-color);
}

.new-management-button:active {
  background-color: var(--news-management-button-active-color);
}
</style>
