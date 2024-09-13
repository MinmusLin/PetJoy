<!--
  Project Name:  UserInterface
  File Name:     Progress.vue
  File Function: 进度条组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-24
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <el-progress v-if='isProgressVisible'
               :percentage='100'
               :show-text='false'
               :indeterminate='true'
               :duration='1.5'
               class='progress-bar'/>
  <div v-else class='progress-bar-background'/>
</template>

<script setup lang='ts'>
import {isProgressVisible} from '../globals'
</script>

<style scoped>
:global(:root) {
  --progress-bg-color: #EBEEF5;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --progress-bg-color: #363637;
}

.progress-bar {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 4px;
  z-index: 1001;
}

.progress-bar-background {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 5px;
  background-color: var(--progress-bg-color);
  z-index: 1001;
}
</style>
