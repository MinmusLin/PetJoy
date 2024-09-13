<!--
  Project Name:  UserInterface
  File Name:     PetEncyclopediaNavbar.vue
  File Function: 宠物百科导航栏组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-28
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='icon-bar'>
    <div v-for='icon in petCategories'
         :key='icon.id'
         class='icon-container'
         @click='router.push(`/pet-category/${icon.id}`)'>
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
</template>

<script setup lang='ts'>
import {petCategories} from '../globals'
import {onMounted} from 'vue'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import {useI18n} from 'vue-i18n'
import {useRouter} from 'vue-router'

const {locale, t} = useI18n()
const router = useRouter()

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`pet-encyclopedia/menu-index/${locale.value}`)
    const data = response.data
    petCategories.value.forEach(icon => {
      const match = data.find((item: any) => item.index == icon.id)
      if (match) {
        icon.label = match.title
      }
    })
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})
</script>

<style scoped>
:global(:root) {
  --pet-navbar-bg-color: rgba(0, 47, 119, 0.5);
  --pet-navbar-bg-hover-color: rgba(29, 73, 119, 0.8);
  --pet-navbar-line-border-color: rgba(141, 182, 255);
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --pet-navbar-bg-color: rgba(10, 24, 37, 0.5);
  --pet-navbar-bg-hover-color: rgba(27, 63, 97, 0.8);
  --pet-navbar-line-border-color: rgb(50, 74, 99);
}

.icon-bar {
  background-color: var(--pet-navbar-bg-color);
}

.icon-container {
  position: relative;
  flex: 1;
}

.icon-button {
  width: 100%;
  height: 80px;
  color: white;
  background: none;
  border: none;
  font-size: 20px;
  display: flex;
  align-items: center;
  transition: background-color 0.3s ease;
  border-bottom: 2px solid var(--pet-navbar-line-border-color);
  cursor: pointer;
}

.icon-button:hover {
  background-color: var(--pet-navbar-bg-hover-color);
}

.icon-button:hover span {
  transform: scale(1.1);
}

.icon-button:hover .icon-image {
  transform: scale(1.1);
}

.icon-image {
  width: 50px;
  height: 50px;
  padding-left: 10px;
  padding-right: 15px;
  transition: transform 0.3s ease;
}
</style>
