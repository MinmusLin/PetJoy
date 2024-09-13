<!--
  Project Name:  UserInterface
  File Name:     NewsManagementPage.vue
  File Function: 新闻管理页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='page-container'>
    <h1 style='display: flex; justify-content: center; align-items: center'>
      {{ t('NewsManagementPage.NewsManagement') }}
    </h1>
    <el-button type='primary' link style='margin-bottom: 10px; margin-top: -10px' @click="router.push('/publish-news')">
      {{ t('PublishNewsPage.PublishNews') }}
    </el-button>
    <el-table ref='tableRef'
              :data='paginatedNewsData'
              stripe
              border
              style='width: 100%'
              :empty-text="t('FooterNavbar.NoData')"
              @sort-change='handleSortChange'
              @filter-change='handleFilterChange'>
      <el-table-column prop='title' :label="t('PublishNewsPage.NewsTitleLabel')" width='200' align='center'>
        <template #default='{ $index }'>
          <el-popover trigger='hover' placement='top' popper-class='custom-popover' width='200'>
            <div class='popover-title'>{{ paginatedNewsData[$index].title }}</div>
            <template #reference>
              <el-text :style="{ padding: '0 10px', textAlign: 'center'}" class='table-title' truncated line-clamp='1'>
                {{ paginatedNewsData[$index].title }}
              </el-text>
            </template>
          </el-popover>
        </template>
      </el-table-column>
      <el-table-column prop='summary' :label="t('PublishNewsPage.NewsSummaryLabel')" width='300' align='center'>
        <template #default='{ $index }'>
          <el-popover trigger='hover' placement='top' popper-class='custom-popover' width='300'>
            <div class='popover-summary'>{{ paginatedNewsData[$index].summary }}</div>
            <template #reference>
              <el-text :style="{ padding: '0 10px', textAlign: 'center' }"
                       class='table-summary'
                       truncated
                       line-clamp='1'>
                {{ paginatedNewsData[$index].summary }}
              </el-text>
            </template>
          </el-popover>
        </template>
      </el-table-column>
      <el-table-column column-key='tag'
                       prop='tag'
                       :label="t('PublishNewsPage.NewsTagLabel')"
                       width='110'
                       align='center'
                       :filters='tagFilters'
                       :filter-multiple='true'
                       filter-placement='bottom-end'>
        <template #default='{ $index }'>
          <el-tag>{{ paginatedNewsData[$index].tag }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop='creationDate'
                       :label="t('NewsManagementPage.CreationDate')"
                       width='165'
                       align='center'
                       sortable/>
      <el-table-column prop='updateDate'
                       :label="t('NewsManagementPage.UpdateDate')"
                       width='165'
                       align='center'
                       sortable/>
      <el-table-column :label="t('PublishNewsPage.CoverImageLabel')"
                       width='120'
                       align='center'>
        <template #default='{ $index }'>
          <el-button type='primary'
                     class='small-button'
                     @click='updateImageUrl(`${ossBaseUrl}${paginatedNewsData[$index].coverUrl}`)'>
            {{ t('NewsManagementPage.ViewCover') }}
          </el-button>
        </template>
      </el-table-column>
      <el-table-column column-key='isSticky'
                       prop='isSticky'
                       :label="t('PublishNewsPage.IsStickyLabel')"
                       width='130'
                       align='center'
                       :filters='stickyFilters'
                       :filter-multiple='true'
                       filter-placement='bottom-end'>
        <template #default='{ $index }'>
          <el-tag :type="paginatedNewsData[$index].isSticky == 1 ? 'success' : 'info'">
            {{
              paginatedNewsData[$index].isSticky == 1 ? t('NewsManagementPage.Sticky') : t('NewsManagementPage.NotSticky')
            }}
          </el-tag>
        </template>
      </el-table-column>
      <el-table-column label='' width='180' align='center'>
        <template #header>
          <el-input v-model='search' size='small' :placeholder="t('NewsManagementPage.Search')"/>
        </template>
        <template #default='{ $index }'>
          <el-button type='success'
                     size='small'
                     @click='previewNews(paginatedNewsData[$index].newsId)'
                     class='custom-button'>
            {{ t('NewsManagementPage.Preview') }}
          </el-button>
          <el-button type='warning'
                     size='small'
                     @click='editNews(paginatedNewsData[$index].newsId)'
                     class='custom-button'>
            {{ t('NewsManagementPage.Edit') }}
          </el-button>
          <el-button type='danger'
                     size='small'
                     @click='deleteNews(paginatedNewsData[$index].newsId)'
                     class='custom-button'>
            {{ t('NewsManagementPage.Delete') }}
          </el-button>
        </template>
      </el-table-column>
    </el-table>
    <div class='pagination-container'>
      <el-pagination v-model:currentPage='currentPage'
                     :page-size='16'
                     layout='prev, pager, next'
                     :total='filteredNewsData.length'
                     @current-change='handlePageChange'
                     class='el-pagination'/>
    </div>
  </div>
  <el-image-viewer v-if='imageViewerVisible'
                   :url-list='imageUrls'
                   :initial-index='0'
                   @close='imageViewerVisible=false'/>
</template>

<script setup lang='ts'>
import {ref, onMounted, computed} from 'vue'
import {useI18n} from 'vue-i18n'
import {useRouter} from 'vue-router'
import axiosInstance from '../utils/axios'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import {ElMessage} from 'element-plus'

const {t} = useI18n()
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const router = useRouter()
const newsData = ref([])
const search = ref('')
const tableRef = ref()
const imageViewerVisible = ref(false)
const imageUrls = ref([''])
const currentPage = ref(1)
const filteredNewsIds = ref<number[]>([])

const tagFilters = ref([
  {text: '', value: ''},
  {text: '', value: ''}
])

const updateImageUrl = (url) => {
  imageUrls.value[0] = url
  imageViewerVisible.value = true
}

const stickyFilters = ref([
  {text: t('NewsManagementPage.Sticky'), value: 1},
  {text: t('NewsManagementPage.NotSticky'), value: 0}
])

const activeFilters = ref({
  tags: [],
  sticky: []
})

const resetFilters = () => {
  tableRef.value.clearFilter()
  activeFilters.value.tags = []
  activeFilters.value.sticky = []
}

const filteredNewsData = computed(() => {
  let filteredData = newsData.value
  if (activeFilters.value.tags.length > 0) {
    filteredData = filteredData.filter(news => activeFilters.value.tags.includes(news.tag))
  }
  if (activeFilters.value.sticky.length > 0) {
    filteredData = filteredData.filter(news => activeFilters.value.sticky.includes(news.isSticky))
  }
  if (search.value.length >= 2) {
    filteredData = filteredData.filter(news => news.title.toLowerCase().includes(search.value.toLowerCase()) || news.summary.toLowerCase().includes(search.value.toLowerCase()))
  }
  return filteredData
})

const paginatedNewsData = computed(() => {
  const start = (currentPage.value - 1) * 16
  const end = currentPage.value * 16
  return filteredNewsData.value.slice(start, end)
})

onMounted(async () => {
  try {
    const response = await axiosInstance.post('news/filter-by-tag', [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11])
    filteredNewsIds.value = response.data
    const tagsSet = new Set()
    const tagsResponse = await Promise.all(Array.from({length: 11}, (_, i) => axiosInstance.get(`news-tag/${i + 1}`)))
    tagsResponse.forEach(response => {
      const tag = response.data.tag
      tagsSet.add(tag)
    })
    tagFilters.value = Array.from(tagsSet).map(tag => ({text: tag, value: tag}))
    for (let i = 0; i < filteredNewsIds.value.length; i++) {
      const response = await axiosInstance.get(`news/${filteredNewsIds.value[i]}`)
      const news = response.data
      const newsTagResponse = tagsResponse.find(
          tagResponse => tagResponse.data.tagId == news.tagId
      )
      const tag = newsTagResponse ? newsTagResponse.data.tag : ''
      newsData.value.push({
        ...news,
        newsId: news.newsId,
        isSticky: news.isSticky,
        coverUrl: news.coverUrl,
        creationDate: formatDateTimeToCST(news.creationDate).dateTime,
        updateDate: formatDateTimeToCST(news.updateDate).dateTime,
        likeCount: news.likeCount,
        dislikeCount: news.dislikeCount,
        commentCount: news.commentCount,
        favoriteCount: news.favoriteCount,
        tag
      })
    }
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

const previewNews = newsId => {
  router.push(`/news/${newsId}`)
}

const editNews = newsId => {
  router.push(`/edit-news/${newsId}`)
}

const deleteNews = async newsId => {
  try {
    await axiosInstance.delete(`news/${newsId}`)
  } catch (error) {
    ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
  } finally {
    window.location.reload()
  }
}

const handlePageChange = page => {
  currentPage.value = page
}

const handleFilterChange = filters => {
  resetFilters()
  if (filters.tag) {
    activeFilters.value.tags = filters.tag
  }
  if (filters.isSticky) {
    activeFilters.value.sticky = filters.isSticky
  }
  currentPage.value = 1
}

const handleSortChange = ({prop, order}) => {
  newsData.value.sort((a, b) => {
    if (order == 'ascending') return a[prop] > b[prop] ? 1 : -1
    if (order == 'descending') return a[prop] < b[prop] ? 1 : -1
    return 0
  })
  currentPage.value = 1
}
</script>

<style scoped>
.page-container {
  width: 1410px;
  height: calc(100vh - 135px);
  align-self: center;
  display: flex;
  flex-direction: column;
  padding: 20px;
  box-sizing: border-box;
}

.el-table th, .el-table td {
  white-space: nowrap;
  overflow: hidden;
}

.table-title {
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  display: block;
  text-align: center;
}

.table-summary {
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  display: block;
  text-align: center;
}

.popover-title {
  display: flex;
  justify-content: center;
  width: 176px;
  text-align: justify;
}

.popover-summary {
  display: flex;
  justify-content: center;
  width: 276px;
  text-align: justify;
}

.pagination-container {
  display: flex;
  justify-content: center;
  margin-top: 20px;
}

.el-pagination {
  font-size: x-large;
  text-align: center;
}

.small-button {
  font-size: 12px;
  padding: 2px 8px;
  height: 28px;
  line-height: 28px;
}

.custom-button {
  margin-left: 0;
  margin-right: 12px;
  width: 43px;
}

.custom-button:last-child {
  margin-right: 0;
}
</style>
