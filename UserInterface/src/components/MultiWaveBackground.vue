<!--
  Project Name:  UserInterface
  File Name:     MultiWaveBackground.vue
  File Function: 多波浪背景组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-09
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='body'>
    <div class='header'>
      <div class='blank'/>
      <svg class='WaveMultiGroup' viewBox='0 24 150 28' preserveAspectRatio='none' shape-rendering='auto'>
        <path fill='var(--wave-color-1)'
              d='M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z'/>
        <path fill='var(--wave-color-2)'
              d='M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z'/>
        <path fill='var(--wave-color-3)'
              d='M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z'/>
        <path fill='var(--wave-color-4)'
              d='M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z'/>
      </svg>
    </div>
  </div>
</template>

<style scoped>
:global(:root) {
  --wave-background-color: #D0E7FAFF;
  --wave-header-background-color: linear-gradient(60deg, rgb(233, 240, 253) 0%, rgb(247, 248, 251) 100%);
  --wave-color-1: rgba(208, 231, 250, 0.7);
  --wave-color-2: rgba(208, 231, 250, 0.5);
  --wave-color-3: rgba(208, 231, 250, 0.3);
  --wave-color-4: rgb(208, 231, 250);
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --wave-header-background-color: linear-gradient(60deg, rgb(2, 16, 34) 0%, rgb(9, 22, 48) 100%);
  --wave-background-color: #00183c;
  --wave-color-1: rgba(0, 24, 60, 0.7);
  --wave-color-2: rgba(0, 24, 60, 0.5);
  --wave-color-3: rgba(0, 24, 60, 0.3);
  --wave-color-4: rgb(0, 24, 60);
}

.body {
  margin: 0;
  background-color: var(--wave-background-color);
}

.header {
  position: relative;
  background: var(--wave-header-background-color);
}

.blank {
  height: 65vh;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.WaveMultiGroup {
  position: relative;
  width: 100%;
  height: 15vh;
  margin-bottom: -7px;
  min-height: 100px;
  max-height: 150px;
}

.WaveMultiGroup path {
  animation: multi-wave-move 30s cubic-bezier(.55, .5, .45, .5) infinite;
}

.WaveMultiGroup path:nth-child(1) {
  transform: translateY(0px);
  animation-delay: -2s;
  animation-duration: 7s;
}

.WaveMultiGroup path:nth-child(2) {
  transform: translateY(1px);
  animation-delay: -3s;
  animation-duration: 10s;
}

.WaveMultiGroup path:nth-child(3) {
  transform: translateY(2px);
  animation-delay: -4s;
  animation-duration: 13s;
}

.WaveMultiGroup path:nth-child(4) {
  transform: translateY(3px);
  animation-delay: -5s;
  animation-duration: 20s;
}

@keyframes multi-wave-move {
  0% {
    transform: translate3d(-30px, 0, 0);
  }
  60% {
    transform: translate3d(80px, 0, 0);
  }
  100% {
    transform: translate3d(-30px, 0, 0);
  }
}
</style>
