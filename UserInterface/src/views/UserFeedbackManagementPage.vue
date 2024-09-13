<!--
  Project Name:  UserInterface
  File Name:     UserFeedbackManagementPage.vue
  File Function: 用户反馈管理页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='page-container'>
    <h1 style='display: flex; justify-content: center; align-items: center'>
      {{ t('HeaderNavbar.UserFeedbackManagement') }}
    </h1>
    <el-table ref='tableRef'
              :data='paginatedFeedbackData'
              stripe
              border
              style='width: 100%'
              :empty-text="t('FooterNavbar.NoData')"
              @sort-change='handleSortChange'
              @filter-change='handleFilterChange'>
      <el-table-column prop='feedbackContent'
                       :label="t('UserFeedbackManagementPage.FeedbackContent')"
                       width='450'
                       align='center'>
        <template #default='{ $index }'>
          <el-popover trigger='hover' placement='top' width='450'>
            <div class='popover-feedback-content'>{{ paginatedFeedbackData[$index].feedbackContent }}</div>
            <template #reference>
              <el-text :style="{ padding: '0 10px', textAlign: 'center' }"
                       class='table-feedback-content'
                       truncated
                       line-clamp='1'>
                {{ paginatedFeedbackData[$index].feedbackContent }}
              </el-text>
            </template>
          </el-popover>
        </template>
      </el-table-column>
      <el-table-column column-key='tag'
                       prop='tag'
                       :label="t('UserFeedbackManagementPage.FeedbackCategory')"
                       width='120'
                       align='center'
                       :filters='localizedTagFilters'
                       :filter-multiple='true'
                       filter-placement='bottom-end'>
        <template #default='{ $index }'>
          <el-tag>{{ tagMap[paginatedFeedbackData[$index].tag] }}</el-tag>
        </template>
      </el-table-column>
      <el-table-column prop='feedbackTime'
                       :label="t('UserFeedbackManagementPage.FeedbackTime')"
                       width='190'
                       align='center'
                       sortable/>
      <el-table-column prop='email'
                       :label="t('FooterNavbar.Email')"
                       width='210'
                       align='center'/>
      <el-table-column prop='telephone'
                       :label="t('UserFeedbackManagementPage.Telephone')"
                       width='130'
                       align='center'/>
      <el-table-column label='' width='100' align='center'>
        <template #header>
          <el-input v-model='search' size='small' :placeholder="t('NewsManagementPage.Search')"/>
        </template>
        <template #default='{ $index }'>
          <el-button type='danger'
                     size='small'
                     class='custom-button'
                     @click='handleDelete(paginatedFeedbackData[$index].feedbackId)'>
            {{ t('NewsManagementPage.Delete') }}
          </el-button>
        </template>
      </el-table-column>
    </el-table>
    <div class='pagination-container'>
      <el-pagination v-model:currentPage='currentPage'
                     :page-size='16'
                     layout='prev, pager, next'
                     :total='filteredFeedbackData.length'
                     @current-change='handlePageChange'
                     class='el-pagination'/>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {ref, onMounted, computed} from 'vue'
import {useI18n} from 'vue-i18n'
import {useRouter} from 'vue-router'
import axiosInstance from '../utils/axios'
import {ElMessageBox, ElMessage} from 'element-plus'
import {formatDateTimeToCST} from '../globals'

interface FilterOption {
  text: string
  value: string
}

const {t} = useI18n()
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const router = useRouter()
const feedbackData = ref([])
const search = ref('')
const tableRef = ref()
const currentPage = ref(1)
const tagFilters = ref<FilterOption[]>([])
const activeFilters = ref({tags: []})
const tagMap = {
  'FeatureSuggestion': t('FooterNavbar.FeatureSuggestion'),
  'TechnicalIssue': t('FooterNavbar.TechnicalIssue'),
  'UserExperience': t('FooterNavbar.UserExperience'),
  'ContentError': t('FooterNavbar.ContentError'),
  'BusinessCooperation': t('FooterNavbar.BusinessCooperation'),
  'Other': t('FooterNavbar.Other')
}

const resetFilters = () => {
  tableRef.value.clearFilter()
  activeFilters.value.tags = []
}

const localizedTagFilters = computed(() => {
  return tagFilters.value.map(filter => ({
    text: tagMap[filter.value],
    value: filter.value
  }))
})

const filteredFeedbackData = computed(() => {
  let filteredData = feedbackData.value
  if (activeFilters.value.tags.length > 0) {
    filteredData = filteredData.filter(feedbacks =>
        activeFilters.value.tags.includes(feedbacks.tag)
    )
  }
  if (search.value.length >= 2) {
    filteredData = filteredData.filter(
        feedbacks => feedbacks.feedbackContent.toLowerCase().includes(search.value.toLowerCase())
    )
  }
  return filteredData
})

const paginatedFeedbackData = computed(() => {
  const start = (currentPage.value - 1) * 16
  const end = currentPage.value * 16
  return filteredFeedbackData.value.slice(start, end)
})

onMounted(async () => {
  try {
    const tagsSet = new Set()
    const response = await axiosInstance.get('user-feedback')
    const allFeedbackData = response.data
    for (const feedbackItem of allFeedbackData) {
      const feedbackId = feedbackItem.feedbackId
      const response = await axiosInstance.get(`user-feedback/${feedbackId}`)
      const feedbacks = response.data
      feedbackData.value.push({
        ...feedbacks,
        feedbackId: feedbacks.feedbackId,
        feedbackTime: formatDateTimeToCST(feedbacks.feedbackTime).dateTime,
        email: feedbacks.email,
        telephone: feedbacks.telephone,
        tag: feedbacks.feedbackCategory
      })
      tagsSet.add(feedbacks.feedbackCategory)
    }
    tagFilters.value = Array.from(tagsSet).map(tag => ({text: tag, value: tag}))
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

const handlePageChange = page => {
  currentPage.value = page
}

const handleFilterChange = filters => {
  resetFilters()
  if (filters.tag) {
    activeFilters.value.tags = filters.tag
  }
  currentPage.value = 1
}

const handleSortChange = ({prop, order}) => {
  feedbackData.value.sort((a, b) => {
    if (order == 'ascending') return a[prop] > b[prop] ? 1 : -1
    if (order == 'descending') return a[prop] < b[prop] ? 1 : -1
    return 0
  })
  currentPage.value = 1
}

onMounted(async () => {
  if (currentUserId.value == 0) {
    await router.push('/login')
    await ElMessageBox.alert(t('SettingsPage.PleaseLoginFirst'), t('SettingsPage.Notice'), {
      showClose: false
    })
    return
  }
  try {
    const response = await axiosInstance.get(`user/role/${currentUserId.value}`)
    if (response.data == 0) {
      await router.push('/')
      await ElMessageBox.alert(t('PublishNewsPage.AuthorityPrompt'), t('SettingsPage.Notice'), {
        showClose: false
      })
    }
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    await router.push('/')
  }
})

async function handleDelete(feedbackId: number) {
  try {
    await axiosInstance.delete(`user-feedback/${feedbackId}`)
  } catch (error) {
    ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
  } finally {
    window.location.reload()
  }
}
</script>

<style scoped>
.page-container {
  width: 1200px;
  height: calc(100vh - 135px);
  align-self: center;
  display: flex;
  flex-direction: column;
  padding: 0;
  box-sizing: border-box;
}

.el-table th, .el-table td {
  white-space: nowrap;
  overflow: hidden;
}

.table-feedback-content {
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  display: block;
  text-align: center;
}

.popover-feedback-content {
  display: flex;
  justify-content: center;
  width: 426px;
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
  margin-bottom: 20px;
}

.custom-button {
  margin-left: 0;
  margin-right: 0;
  width: 63px;
}
</style>
