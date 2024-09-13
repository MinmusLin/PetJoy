<!--
  Project Name:  UserInterface
  File Name:     AdoptionSearchBox.vue
  File Function: 宠物领养搜索框组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-16
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <!--suppress TypeScriptValidateTypes-->
  <el-input v-model='searchContent'
            class='custom-search-input'
            :placeholder="t('PetCommunityPage.SearchPrompt')"
            :prefix-icon='Search'/>
  <el-menu v-if='showDropdown' class='search-dropdown' v-loading='loading'>
    <el-menu-item v-if='searchResults.length==0'>{{ t('PetCommunityPage.NoResultsFound') }}</el-menu-item>
    <el-menu-item v-for='result in searchResults'
                  :key='result.item.id'
                  @click='router.push(`/adoption/${result.item.adoptionId}`)'
                  class='menu-item-large'>
      <div class='flex-column-start'>
        <div>
          <el-text :title="result.item.name ? result.item.name : t('PetAdoptionPage.UnnamedPet')" class='menu-item-title'>
            {{ result.item.name ? result.item.name : t('PetAdoptionPage.UnnamedPet') }}
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
import {ref, watch} from 'vue'
import {useI18n} from 'vue-i18n'
import {Search} from '@element-plus/icons-vue'
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

const router = useRouter()
const {locale, t} = useI18n()
const loading = ref(false)
const searchContent = ref('')
const searchResults = ref([])
const showDropdown = ref(false)
const list = ref([])

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

let fuseAdoption = new Fuse(list.value, fuseOptionsAdoption)

const initFuseAdoption = (newList) => fuseAdoption = new Fuse(newList, fuseOptionsAdoption)

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
      const data = await axiosInstance.get(`search/pet-adoption`)
      list.value = data.data.map(item => ({...item, type: 'type1'}))
      initFuseAdoption(list.value)
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    } finally {
      loading.value = false
      const results = fuseAdoption.search(newPattern)
      searchResults.value = results.filter(result => result.score <= searchThresholdScore)
      addMatchDetails(searchResults.value, searchResults.value)
    }
  }
})
</script>

<style scoped>
@import '../styles/SearchBoxCSS.css';
</style>
