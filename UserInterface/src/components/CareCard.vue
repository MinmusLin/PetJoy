<!--
  Project Name:  UserInterface
  File Name:     CareCard.vue
  File Function: 宠物护理卡片组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-04
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='care-card'>
    <video width='380' controls :poster='`${ossBaseUrl}${props.cover}`'>
      <source :src='`${ossBaseUrl}${props.videoUrl}`' type='video/mp4'>
    </video>
    <div class='title-container'>
      <p>{{ props.title }}</p>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {defineProps} from 'vue'
import {ossBaseUrl} from '../globals'

const props = defineProps({
  videoUrl: String,
  title: String,
  cover: String
})
</script>

<style scoped>
:global(:root) {
  --care-card-background: #FFFFFF;
  --care-card-title-color: #333333;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --care-card-background: #2C2C2C;
  --care-card-title-color: #E0E0E0;
}

.care-card {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 380px;
  border-radius: 8px;
  box-shadow: 0 0 12px rgba(0, 0, 0, 0.2);
  overflow: hidden;
  background-color: var(--care-card-background);
}

.title-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 72px;
  text-align: center;
}

.title-container p {
  margin: 0 16px;
  font-size: 16px;
  color: var(--care-card-title-color);
  justify-content: center;
  display: -webkit-box;
  -webkit-box-orient: vertical;
  overflow: hidden;
  -webkit-line-clamp: 2;
  line-clamp: 2;
  white-space: normal;
  text-align: justify;
  line-height: 1.6;
}
</style>
