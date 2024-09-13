<!--
  Project Name:  UserInterface
  File Name:     GlobalSearchBox.vue
  File Function: 全局搜索框组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-16
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <!--suppress TypeScriptValidateTypes-->
  <el-input v-model='searchContent'
            ref='tourRef12'
            class='custom-search-input'
            :placeholder="t('PetCommunityPage.SearchPrompt')"
            :prefix-icon='Search'/>
  <el-menu v-if='showDropdown' class='search-dropdown' v-loading='loading'>
    <el-menu-item v-if='searchResults.length==0'>{{ t('PetCommunityPage.NoResultsFound') }}</el-menu-item>
    <el-menu-item v-for='result in searchResults'
                  :key='result.item.id'
                  @click='navigateToPage(result.item)'
                  class='menu-item-large'>
      <div class='flex-column-start'>
        <div>
          <el-text :title='getTitle(result.item)' class='menu-item-title'> {{ getTitle(result.item) }}</el-text>
        </div>
        <div class='margin-title-context'>
          <el-text :title='result.matchDetails.surroundingText' class='menu-item-context'>
            <Highlighter highlightClassName='highlight'
                         :searchWords='[result.matchDetails.match]'
                         :autoEscape='true'
                         :textToHighlight='result.matchDetails.surroundingText'
                         :highlightStyle="{backgroundColor: '#FFFFFF00', color: '#00B2FF'}"/>
          </el-text>
        </div>
      </div>
      <div class='icon-alignment'>
        <img class='icon-enter' :src='`${ossBaseUrl}LogosAndIcons/Enter.png`' alt='Enter'/>
      </div>
    </el-menu-item>
  </el-menu>
</template>

<script setup lang='ts'>
import {ref, watch} from 'vue'
import {useI18n} from 'vue-i18n'
import {Search} from '@element-plus/icons-vue'
import {tourRef12, searchThresholdScore, ossBaseUrl} from '../globals'
import {useRouter} from 'vue-router'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import Highlighter from 'vue-highlight-words'
import Fuse from 'fuse.js'

type MatchDetail = {
  match: string
  surroundingText: string
}

const router = useRouter()
const {locale, t} = useI18n()
const loading = ref(false)
const searchContent = ref('')
const searchResults = ref([])
const showDropdown = ref(false)
const list = ref([])

const fuseOptionsCategory = {
  ignoreLocation: true,
  ignoreFieldNorm: true,
  includeScore: true,
  includeMatches: true,
  keys: [
    'categoryName',
    'description'
  ]
}

const fuseOptionsSubcategory = {
  ignoreLocation: true,
  ignoreFieldNorm: true,
  includeScore: true,
  includeMatches: true,
  keys: [
    'subcategoryName',
    'description',
    'origin',
    'size',
    'coat',
    'lifespan',
    'temperament',
    'diet'
  ]
}

const fuseOptionsPetCareGuide = {
  ignoreLocation: true,
  ignoreFieldNorm: true,
  includeScore: true,
  includeMatches: true,
  keys: [
    'title',
    'content'
  ]
}

const fuseOptionsPost = {
  ignoreLocation: true,
  ignoreFieldNorm: true,
  includeScore: true,
  includeMatches: true,
  keys: [
    'title',
    'content'
  ]
}

const fuseOptionsPostComment = {
  ignoreLocation: true,
  ignoreFieldNorm: true,
  includeScore: true,
  includeMatches: true,
  keys: [
    'content'
  ]
}

const fuseOptionsNews = {
  ignoreLocation: true,
  ignoreFieldNorm: true,
  includeScore: true,
  includeMatches: true,
  keys: [
    'title',
    'summary',
    'content'
  ]
}

const fuseOptionsAdoption = {
  ignoreLocation: true,
  ignoreFieldNorm: true,
  includeScore: true,
  includeMatches: true,
  keys: [
    'name',
    'location',
    'reason',
    'health',
    'vaccination',
    'careNeeds',
    'dietaryNeeds',
    'behavior',
    'notes'
  ]
}

let fuseCategory = new Fuse(list.value, fuseOptionsCategory)
let fuseSubcategory = new Fuse(list.value, fuseOptionsSubcategory)
let fusePetCareGuide = new Fuse(list.value, fuseOptionsPetCareGuide)
let fusePost = new Fuse(list.value, fuseOptionsPost)
let fusePostComment = new Fuse(list.value, fuseOptionsPostComment)
let fuseNews = new Fuse(list.value, fuseOptionsNews)
let fuseAdoption = new Fuse(list.value, fuseOptionsAdoption)

const initFuseCategory = (newList) => fuseCategory = new Fuse(newList, fuseOptionsCategory)
const initFuseSubcategory = (newList) => fuseSubcategory = new Fuse(newList, fuseOptionsSubcategory)
const initFusePetCareGuide = (newList) => fusePetCareGuide = new Fuse(newList, fuseOptionsPetCareGuide)
const initFusePost = (newList) => fusePost = new Fuse(newList, fuseOptionsPost)
const initFusePostComment = (newList) => fusePostComment = new Fuse(newList, fuseOptionsPostComment)
const initFuseNews = (newList) => fuseNews = new Fuse(newList, fuseOptionsNews)
const initFuseAdoption = (newList) => fuseAdoption = new Fuse(newList, fuseOptionsAdoption)

const navigateToPage = (item: any) => {
  if (item.newsId) {
    router.push(`/news/${item.newsId}`)
  } else if (item.postId) {
    router.push(`/post/${item.postId}`)
  } else if (item.adoptionId) {
    router.push(`/adoption/${item.adoptionId}`)
  } else if (item.categoryName) {
    router.push(`/pet-category/${item.categoryId}`)
  } else {
    router.push(`/pet-subcategory/${item.subcategoryId}`)
  }
}

const getTitle = (item) => {
  if (item.commentId || item.postId || item.newsId) {
    return item.title
  } else if (item.adoptionId) {
    return item.name ? item.name : t('PetAdoptionPage.UnnamedPet')
  } else {
    return item.categoryName || item.subcategoryName || item.searchTitle
  }
}

const addMatchDetails = (searchResults: any[], fuseResults: any[]) => {
  fuseResults.forEach((fuseResult, index) => {
    const matches = fuseResult.matches
    const item = searchResults[index]
    const matchDetails = matches.map(match => {
      const {value, indices} = match
      return indices.map(([start, end]) => {
        const match = value.slice(start, end + 1)
        let adjustedStart = Math.max(0, start - 5)
        let adjustedEnd = value.length
        let surroundingText = value.slice(adjustedStart, adjustedEnd)
        return {match, surroundingText}
      })
    }).flat()
    item.matchDetails = getLongestMatchDetail(matchDetails)
  })
}

const getLongestMatchDetail = (matchDetails: MatchDetail[]) => {
  return matchDetails.reduce((longest, current) => current.match.length > longest.match.length ? current : longest, {
    match: '',
    surroundingText: ''
  })
}

watch(searchContent, async (newPattern) => {
  if (newPattern.trim() == '') {
    showDropdown.value = false
    searchResults.value = []
  } else {
    loading.value = true
    showDropdown.value = true
    try {
      const [data1, data2, data3, data4, data5, data6, data7] = await Promise.all([
        axiosInstance.get(`search/pet-care-guide/${locale.value}`),
        axiosInstance.get(`search/pet-category/${locale.value}`),
        axiosInstance.get(`search/pet-subcategory/${locale.value}`),
        axiosInstance.get(`search/news`),
        axiosInstance.get(`search/post-comment`),
        axiosInstance.get(`search/post`),
        axiosInstance.get(`search/pet-adoption`)
      ])
      list.value = [
        ...data1.data.map(item => ({...item, type: 'type1'})),
        ...data2.data.map(item => ({...item, type: 'type2'})),
        ...data3.data.map(item => ({...item, type: 'type3'})),
        ...data4.data.map(item => ({...item, type: 'type4'})),
        ...data5.data.map(item => ({...item, type: 'type5'})),
        ...data6.data.map(item => ({...item, type: 'type6'})),
        ...data7.data.map(item => ({...item, type: 'type7'}))
      ]
      initFuseCategory(data2.data)
      initFuseSubcategory(data3.data)
      initFusePetCareGuide(data1.data)
      initFuseNews(data4.data)
      initFusePostComment(data5.data)
      initFusePost(data6.data)
      initFuseAdoption(data7.data)
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    } finally {
      loading.value = false
      const resultsPost = fusePost.search(newPattern)
      const resultsPostComment = fusePostComment.search(newPattern)
      const resultsPetCareGuide = fusePetCareGuide.search(newPattern)
      const resultsCategory = fuseCategory.search(newPattern)
      const resultsSubcategory = fuseSubcategory.search(newPattern)
      const resultsNews = fuseNews.search(newPattern)
      const resultsAdoption = fuseAdoption.search(newPattern)
      const combinedResults = [
        ...resultsPost,
        ...resultsPostComment,
        ...resultsPetCareGuide,
        ...resultsCategory,
        ...resultsSubcategory,
        ...resultsNews,
        ...resultsAdoption
      ].sort(() => Math.random() - 0.5)
      searchResults.value = combinedResults.filter(result => result.score <= searchThresholdScore)
      addMatchDetails(searchResults.value, searchResults.value)
    }
  }
})
</script>

<style scoped>
@import '../styles/SearchBoxCSS.css';
</style>
