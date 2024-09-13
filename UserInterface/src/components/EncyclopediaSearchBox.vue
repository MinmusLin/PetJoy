<!--
  Project Name:  UserInterface
  File Name:     EncyclopediaSearchBox.vue
  File Function: 宠物百科搜索框组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-16
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <el-menu v-if='showDropdown' class='search-dropdown' v-loading='loading'>
    <el-menu-item v-if='searchResults.length==0'>{{ t('PetCommunityPage.NoResultsFound') }}</el-menu-item>
    <el-menu-item v-for='result in searchResults'
                  :key='result.item.id'
                  @click='router.push(result.item.categoryName ? `/pet-category/${result.item.categoryId}` : `/pet-subcategory/${result.item.subcategoryId}`)'
                  class='menu-item-large'>
      <div class='flex-column-start'>
        <div>
          <el-text :title='result.item.subcategoryName || result.item.categoryName || result.item.searchTitle'
                   class='menu-item-title'>
            {{ result.item.subcategoryName || result.item.categoryName || result.item.searchTitle }}
          </el-text>
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
import {ref, watch, defineProps} from 'vue'
import {useI18n} from 'vue-i18n'
import {useRouter} from 'vue-router'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import Highlighter from 'vue-highlight-words'
import Fuse from 'fuse.js'
import {ossBaseUrl, searchThresholdScore} from '../globals'

type MatchDetail = {
  match: string
  surroundingText: string
}

const props = defineProps({searchContent: {type: String, required: true}})
const input = ref('searchContent')
const router = useRouter()
const {locale, t} = useI18n()
const loading = ref(false)
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

let fuseCategory = new Fuse(list.value, fuseOptionsCategory)
let fuseSubcategory = new Fuse(list.value, fuseOptionsSubcategory)
let fusePetCareGuide = new Fuse(list.value, fuseOptionsPetCareGuide)

const initFuseCategory = (newList) => fuseCategory = new Fuse(newList, fuseOptionsCategory)
const initFuseSubcategory = (newList) => fuseSubcategory = new Fuse(newList, fuseOptionsSubcategory)
const initFusePetCareGuide = (newList) => fusePetCareGuide = new Fuse(newList, fuseOptionsPetCareGuide)

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

watch(() => props.searchContent, async (newPattern) => {
  if (!(newPattern) || newPattern.trim() == '') {
    showDropdown.value = false
    searchResults.value = []
  } else {
    loading.value = true
    showDropdown.value = true
    try {
      const [data1, data2, data3] = await Promise.all([
        axiosInstance.get(`search/pet-care-guide/${locale.value}`),
        axiosInstance.get(`search/pet-category/${locale.value}`),
        axiosInstance.get(`search/pet-subcategory/${locale.value}`)
      ])
      list.value = [
        ...data1.data.map(item => ({...item, type: 'type1'})),
        ...data2.data.map(item => ({...item, type: 'type2'})),
        ...data3.data.map(item => ({...item, type: 'type3'}))
      ]
      initFusePetCareGuide(data1.data)
      initFuseCategory(data2.data)
      initFuseSubcategory(data3.data)
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    } finally {
      loading.value = false
      const resultsCategory = fuseCategory.search(newPattern)
      const resultsSubcategory = fuseSubcategory.search(newPattern)
      const resultsPetCareGuide = fusePetCareGuide.search(newPattern)
      const combinedResults = [...resultsCategory, ...resultsPetCareGuide, ...resultsSubcategory].sort(() => Math.random() - 0.5)
      searchResults.value = combinedResults.filter(result => result.score <= searchThresholdScore)
      addMatchDetails(searchResults.value, searchResults.value)
    }
  }
})
</script>

<style scoped>
@import '../styles/SearchBoxCSS.css';
</style>
