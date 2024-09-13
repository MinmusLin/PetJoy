<!--
  Project Name:  UserInterface
  File Name:     App.vue
  File Function: 父组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-24
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div id='app'>
    <Progress/>
    <HeaderNavbar class='header-navbar'/>
    <div class='router-view-container'>
      <router-view/>
    </div>
    <el-backtop :right='50' :bottom='50'/>
    <FooterNavbar/>
  </div>
</template>

<script setup lang='ts'>
import {onMounted, onUnmounted} from 'vue'
import Progress from './components/Progress.vue'
import HeaderNavbar from './components/HeaderNavbar.vue'
import FooterNavbar from './components/FooterNavbar.vue'

const updateHeaderTransform = () => {
  const headerNavbar = document.querySelector('.header-navbar') as HTMLElement
  if (headerNavbar) {
    headerNavbar.style.transform = `translateX(-${window.scrollX}px)`
  }
}

onMounted(() => {
  window.addEventListener('scroll', updateHeaderTransform)
  window.addEventListener('resize', updateHeaderTransform)
  updateHeaderTransform()
})

onUnmounted(() => {
  window.removeEventListener('scroll', updateHeaderTransform)
  window.removeEventListener('resize', updateHeaderTransform)
})
</script>

<style scoped>
:global(:root) {
  --header-background-initial-color: rgba(255, 255, 255, 1);
  --header-background-transparent-color: rgba(255, 255, 255, 0.8);
  --header-shadow-color-1: rgba(0, 0, 0, 0.1);
  --header-shadow-color-2: rgba(0, 0, 0, 0.06);
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --header-background-initial-color: rgba(0, 0, 0, 1);
  --header-background-transparent-color: rgba(0, 0, 0, 0.8);
  --header-shadow-color-1: rgba(255, 255, 255, 0.1);
  --header-shadow-color-2: rgba(255, 255, 255, 0.06);
}

.router-view-container {
  min-height: calc(100vh - 135px);
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  padding-top: 65px;
}

.header-navbar {
  position: fixed;
  width: 100%;
  z-index: 1000;
  background-color: var(--header-background-initial-color);
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px);
  transition: background-color 0.3s ease;
  box-shadow: 0 4px 6px -1px var(--header-shadow-color-1), 0 2px 4px -1px var(--header-shadow-color-2);
}

/* noinspection CssUnusedSymbol */
.transparent-header {
  background-color: var(--header-background-transparent-color);
}
</style>
