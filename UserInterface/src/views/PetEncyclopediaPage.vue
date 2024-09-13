<!--
  Project Name:  UserInterface
  File Name:     PetEncyclopediaPage.vue
  File Function: 宠物百科页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-16
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='background-container'>
    <h1>{{ t('HeaderNavbar.PetEncyclopedia') }}</h1>

    <div class='search-input'>
      <!--suppress TypeScriptValidateTypes-->
      <el-input v-model='searchContent'
                class='custom-search-input'
                :placeholder="t('PetCommunityPage.SearchPrompt')"
                :prefix-icon='Search'/>
    </div>
    <div class='search-container'>
      <EncyclopediaSearchBox :searchContent='searchContent'/>
    </div>

    <div class='icon-bar'>
      <div v-for='icon in petCategories'
           :key='icon.id'
           class='icon-container'
           @click='hideMenu(icon.id); router.push(`/pet-category/${icon.id}`)'
           @mouseenter='showMenu(icon.id)'
           @mouseleave='hideMenu(icon.id)'>
        <button class='icon-button'>
          <img :src='icon.iconPath' class='icon-image' :alt='icon.label'/>
          {{ icon.label }}
        </button>
        <transition name='fade'>
          <div v-if='icon.showMenu' class='dropdown-menu'>
            <a v-for='item in icon.menuItems'
               :key='item.index'
               :href='`/pet-subcategory/${item.index}`'
               class='menu-item'>{{ item.title }}</a>
          </div>
        </transition>
      </div>
    </div>
  </div>

  <div class='pet-list'>
    <div class='refresh-container'>
      <el-icon @click='refreshPets' class='refresh-icon'>
        <Refresh/>
      </el-icon>
    </div>
    <div v-for='(pet, index) in recommendedPet' :key='pet.subcategoryId' class='pet-container'>
      <img :src='`${ossBaseUrl}${pet.imageUrl}`' :alt='pet.subcategoryName' class='pet-image'>
      <div class='text-content'>
        <h2 class='title'>
          {{ pet.subcategoryName }}
          <el-link :href='`/pet-subcategory/${pet.subcategoryId}`' class='learn-more-link' :underline='false'>
            {{ t('HomePage.LearnMore') }}
          </el-link>
        </h2>
        <el-text class='text-clamp' truncated>
          {{ pet.description }}
        </el-text>
      </div>
      <el-divider v-if='index % 2 == 0 && index != recommendedPet.length - 1'
                  direction='vertical'
                  border-style='dashed'
                  class='vertical-divider'/>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {onMounted, ref} from 'vue'
import {useI18n} from 'vue-i18n'
import {ossBaseUrl, petCategories} from '../globals'
import {useRouter} from 'vue-router'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import {Refresh, Search} from '@element-plus/icons-vue'
import EncyclopediaSearchBox from '../components/EncyclopediaSearchBox.vue'

interface MenuItem {
  index: string
  title: string
}

const {locale, t} = useI18n()
const router = useRouter()
const menuIndex = ref<Record<string, MenuItem[]>>({})
const searchContent = ref('')

const recommendedPet = ref([{
  subcategoryId: 0,
  subcategoryName: '',
  description: '',
  imageUrl: ''
}])

const showMenu = (id: string) => {
  if (searchContent.value.trim() == '') {
    petCategories.value.forEach(icon => {
      if (icon.id == id) {
        icon.showMenu = true
      }
    })
  }
}

const hideMenu = (id: string) => {
  petCategories.value.forEach(icon => {
    if (icon.id == id) {
      icon.showMenu = false
    }
  })
}

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`pet-encyclopedia/menu-index/${locale.value}`)
    const data = response.data
    menuIndex.value = data.reduce((acc: Record<string, MenuItem[]>, item: any) => {
      acc[item.index] = item.children.map((child: any) => ({
        index: child.index,
        title: child.title
      }))
      return acc
    }, {})
    petCategories.value.forEach(icon => {
      const match = data.find((item: any) => item.index == icon.id)
      if (match) {
        icon.label = match.title
        icon.menuItems = menuIndex.value[icon.id] || []
      }
    })
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

const fetchRecommendedPets = async () => {
  let validData = false
  while (!validData) {
    try {
      const response = await axiosInstance.get(`pet-subcategory/recommended-pet/4-${locale.value}`)
      const pets = response.data.map((item) => ({
        subcategoryId: item.subcategoryId,
        subcategoryName: item.subcategoryName,
        description: item.description,
        imageUrl: item.imageUrl
      }))
      validData = pets.every(pet => pet.subcategoryId != 0)
      if (validData) {
        recommendedPet.value = pets
        break
      }
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
      break
    }
  }
}

const refreshPets = () => fetchRecommendedPets()

onMounted(() => fetchRecommendedPets())
</script>

<style scoped>
:global(:root) {
  --encyclopedia-title-color: #337ECC;
  --encyclopedia-text-clamp-color: #409EFF;
  --encyclopedia-background-color: #ECF5FF;
  --encyclopedia-dropdown-bg-color: rgba(236, 245, 255, 0.8);
  --encyclopedia-dropdown-border-color: rgba(0, 47, 119, 0.5);
  --encyclopedia-menu-item-color: #002F77;
  --encyclopedia-menu-item-hover-bg-color: rgba(0, 47, 119, 0.2);
  --encyclopedia-refresh-button-color: #007BFF;
  --encyclopedia-refresh-button-hover-color: #0056B3;
  --encyclopedia-background-image: linear-gradient(rgba(255, 255, 255, 0.2), rgba(255, 255, 255, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetEncyclopediaPageBackgroundImage.jpg');
  --encyclopedia-main-title-color: #043278;
  --encyclopedia-main-title-shadow-color: #7392B6;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --encyclopedia-title-color: #A0CFFF;
  --encyclopedia-text-clamp-color: #D9ECFF;
  --encyclopedia-background-color: #122B44;
  --encyclopedia-dropdown-bg-color: rgba(18, 43, 68, 0.8);
  --encyclopedia-dropdown-border-color: rgba(160, 207, 255, 0.5);
  --encyclopedia-menu-item-color: #A0CFFF;
  --encyclopedia-menu-item-hover-bg-color: rgba(160, 207, 255, 0.2);
  --encyclopedia-refresh-button-color: #3B97FF;
  --encyclopedia-refresh-button-hover-color: #4580B8;
  --encyclopedia-background-image: linear-gradient(rgba(0, 0, 0, 0.2), rgba(0, 0, 0, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetEncyclopediaPageBackgroundImage.jpg');
  --encyclopedia-main-title-color: #B2D5FB;
  --encyclopedia-main-title-shadow-color: #3B5A88;
}

.icon-bar {
  position: absolute;
  top: calc(100vh - 255px);
  display: flex;
  width: 100%;
  background-color: rgba(0, 47, 119, 0.5);
  z-index: 1;
}

.icon-container {
  position: relative;
  flex: 1;
}

.icon-button {
  height: 200px;
  width: 100%;
  color: white;
  background: none;
  border: none;
  font-size: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
  transition: background-color 0.3s ease;
  border-right: 2px solid rgba(141, 182, 255, 0.5);
  cursor: pointer;
}

.icon-button:hover {
  background-color: rgba(0, 47, 119, 0.7);
}

.icon-button:hover span {
  transform: scale(1.1);
}

.icon-button:hover .icon-image {
  transform: scale(1.1);
}

.icon-image {
  width: 80px;
  height: 80px;
  margin-top: 20px;
  margin-bottom: 40px;
  transition: transform 0.3s ease;
}

h1 {
  width: 1200px;
  position: absolute;
  top: 12%;
  left: 50%;
  font-size: 64px;
  font-weight: bold;
  color: var(--encyclopedia-main-title-color);
  text-align: center;
  transform: translateX(-50%);
  text-shadow: 0 2px 4px var(--encyclopedia-main-title-shadow-color);
}

.search-container {
  margin-top: 0;
  position: absolute;
  top: 35%;
  left: 50%;
  transform: translateX(-50%) translateY(64px);
  transform-origin: center center;
  z-index: 3;
}

.search-input {
  margin-bottom: 0;
  position: absolute;
  top: 35%;
  left: 50%;
  transform: translateX(-50%);
  transform-origin: center center;
  z-index: 1;
}

.background-container {
  height: calc(100vh - 55px);
  width: 100%;
  background-image: var(--encyclopedia-background-image);
  background-size: cover;
  background-position: center;
  transform: translateY(-10px);
}

.dropdown-menu {
  position: absolute;
  bottom: 100%;
  left: 50%;
  transform: translateX(-50%);
  background-color: var(--encyclopedia-dropdown-bg-color);
  border: 1px solid var(--encyclopedia-dropdown-border-color);
  border-radius: 4px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  display: flex;
  flex-direction: column;
  width: 95%;
  z-index: 2;
}

.menu-item {
  padding: 10px;
  color: var(--encyclopedia-menu-item-color);
  text-decoration: none;
  transition: background-color 0.3s ease;
  font-size: 14px;
}

.custom-search-input {
  background-color: var(--search-input-background-color);
  box-shadow: 0 8px 16px rgba(0, 0, 0, 0.1);
  border-radius: 4px;
  width: 900px;
  height: 64px;
  font-size: 24px;
}

.menu-item:hover {
  background-color: var(--encyclopedia-menu-item-hover-bg-color);
}

.pet-list {
  padding-left: 10px;
  padding-right: 15px;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  background-color: var(--encyclopedia-background-color);
  margin: 40px;
  border-radius: 10px;
  position: relative;
  padding-top: 10px;
}

.pet-container {
  display: flex;
  align-items: center;
  width: calc(50% - 20px);
  margin-bottom: 20px;
  box-sizing: border-box;
  margin-left: 20px;
}

.pet-image {
  width: 200px;
  height: auto;
  margin-right: 20px;
  border-radius: 10px;
  margin-top: 22px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.text-content {
  flex: 1;
  padding: 15px;
  text-align: justify;
}

.text-clamp {
  display: -webkit-box;
  -webkit-box-orient: vertical;
  overflow: hidden;
  -webkit-line-clamp: 3;
  line-clamp: 3;
  white-space: normal;
  word-break: break-all;
  color: var(--encyclopedia-text-clamp-color);
  line-height: 1.7;
}

.vertical-divider {
  margin-top: 21px;
  height: 100%;
  margin-left: 10px;
}

.title {
  color: var(--encyclopedia-title-color);
  font-weight: bold;
  font-size: 24px;
  margin-bottom: 8px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.learn-more-link {
  margin-left: auto;
  font-size: 14px;
}

.refresh-container {
  position: absolute;
  top: 10px;
  right: 10px;
}

.refresh-icon {
  font-size: 20px;
  cursor: pointer;
  transition: color 0.3s;
  color: var(--encyclopedia-refresh-button-color);
}

.refresh-icon:hover {
  color: var(--encyclopedia-refresh-button-hover-color);
}

/* noinspection CssUnusedSymbol */
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.25s ease;
}

/* noinspection CssUnusedSymbol */
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}

/* noinspection CssUnusedSymbol */
.fade-enter-to, .fade-leave-from {
  opacity: 1;
}
</style>
