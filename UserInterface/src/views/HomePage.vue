<!--
  Project Name:  UserInterface
  File Name:     HomePage.vue
  File Function: 主页页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-04
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='background-container'>
    <video autoplay loop muted playsinline class='background-video'>
      <source :src='`${ossBaseUrl}HomePage/BackgroundVideo.mp4`' type='video/mp4'/>
    </video>
    <img :src='`${ossBaseUrl}LogosAndIcons/PetJoyLogo.png`' alt='PetJoyTitle' class='petjoy-title'>
    <div class='search-container'>
      <GlobalSearchBox/>
    </div>
    <div class='down-arrow-container' v-if='isButtonVisible'>
      <a href='#' class='water-ripple' @click='handleButtonClick'>{{ t('HomePage.ClickForDetails') }}</a>
    </div>
  </div>

  <transition name='slide-fade'>
    <div v-show='isContentVisible' class='content-container'>
      <div class='introduction-card'>
        <div style='display: flex; align-items: center'>
          <img style='height: 200px; padding-right: 50px'
               :src='`${ossBaseUrl}LogosAndIcons/PetJoyLogo.png`'
               alt='PetJoyLogo'>
          <div style='font-size: 26px; line-height: 2; text-align: justify' class='introduction-text'>
            {{ t('HomePage.Welcome') }}
          </div>
        </div>
      </div>

      <div class='ai-introduction-card'>
        <div class='content'>
          <div class='bubble' @mouseenter='startTyping' :class='{ expanded: isExpanded }'>
            <el-icon class='initial'>
              <MoreFilled/>
            </el-icon>
            <p class='full' ref='fullTextRef'/>
          </div>
          <img style='height: 200px; margin-left: 20px; cursor: pointer' @click="router.push('/pet-ai')"
               :src='`${ossBaseUrl}LogosAndIcons/PetAIAnime.gif`'
               alt='PetAIAnime'>
        </div>
      </div>

      <div id='app' class='bg-group-one'>
        <div class='component-horizontal'>
          <img :class="{ 'visible': showGroupOne }"
               :src='`${ossBaseUrl}HomePage/PetCommunity.jpg`'
               class='popup-image1'
               alt='PetCommunity'>
          <div :class="{ 'visible': showGroupOne }" class='popup-content1'>
            <div class='title-button-container'>
              <h1>{{ t('HeaderNavbar.PetCommunity') }}</h1>
              <el-button round plain type='danger' @click="router.push('/pet-community')">
                {{ t('HomePage.LearnMore') }}
              </el-button>
            </div>
            <div class='popup-text1'>{{ t('HomePage.CommunityPresentation') }}</div>
          </div>
        </div>

        <div class='component-horizontal reverse'>
          <div :class="{ 'visible': showGroupOne }" class='popup-content2'>
            <div class='title-button-container'>
              <h1>{{ t('HeaderNavbar.PetNews') }}</h1>
              <el-button round plain type='danger' @click="router.push('/pet-news')">
                {{ t('HomePage.LearnMore') }}
              </el-button>
            </div>
            <div class='popup-text2'>{{ t('HomePage.NewsPresentation') }}</div>
          </div>
          <img :class="{ 'visible': showGroupOne }"
               :src='`${ossBaseUrl}HomePage/PetNews.jpg`'
               class='popup-image2'
               alt='PetNews'>
        </div>
      </div>

      <div id='app' class='bg-group-two'>
        <div class='component-horizontal'>
          <img :class="{ 'visible': showGroupTwo }"
               :src='`${ossBaseUrl}HomePage/PetAdoption.jpg`'
               class='popup-image3'
               alt='PetAdoption'>
          <div :class="{ 'visible': showGroupTwo }" class='popup-content3'>
            <div class='title-button-container'>
              <h1>{{ t('HeaderNavbar.PetAdoption') }}</h1>
              <el-button round plain type='danger' @click="router.push('/pet-adoption')">
                {{ t('HomePage.LearnMore') }}
              </el-button>
            </div>
            <div class='popup-text3'>{{ t('HomePage.AdoptionPresentation') }}</div>
          </div>
        </div>

        <div class='component-horizontal reverse'>
          <div :class="{ 'visible': showGroupTwo }" class='popup-content4'>
            <div class='title-button-container'>
              <h1>{{ t('HeaderNavbar.PetEncyclopedia') }}</h1>
              <el-button round plain type='danger' @click="router.push('/pet-encyclopedia')">
                {{ t('HomePage.LearnMore') }}
              </el-button>
            </div>
            <div class='popup-text4'>{{ t('HomePage.EncyclopediaPresentation') }}</div>
          </div>
          <img :class="{ 'visible': showGroupTwo }"
               :src='`${ossBaseUrl}HomePage/PetEncyclopedia.jpg`'
               class='popup-image4'
               alt='PetEncyclopedia'>
        </div>
      </div>
    </div>
  </transition>

  <el-tour v-model='showGuidedTour'>
    <el-tour-step>
      <div class='tour-guide-initial-content'>
        <div class='tour-guide-header'>
          <img :src='`${ossBaseUrl}LogosAndIcons/PetJoyLogo.png`'
               alt='PetJoyLogo'
               class='tour-guide-logo'/>
          <h1 class='tour-guide-title'>{{ t('HomePage.TourRefTitle1') }}</h1>
        </div>
        <div class='tour-guide-body'>
          <p class='tour-guide-welcome'>{{ t('HomePage.WelcomeMessage1') }}</p>
          <p>{{ t('HomePage.WelcomeMessage2') }}</p>
        </div>
        <img :src='`${ossBaseUrl}LogosAndIcons/PetAIAnime.gif`'
             alt='PetAIAnime'
             class='tour-guide-ai-image'/>
      </div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef1?.$el' :title="t('HomePage.TourRefTitle1')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent1') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef2?.$el' :title="t('HomePage.TourRefTitle2')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent2') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef3?.$el' :title="t('HomePage.TourRefTitle3')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent3') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef4?.$el' :title="t('HomePage.TourRefTitle4')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent4') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef5?.$el' :title="t('HomePage.TourRefTitle5')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent5') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef6?.$el' :title="t('HomePage.TourRefTitle6')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent6') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef7?.$el' :title="t('HomePage.TourRefTitle7')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent7') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef8?.$el' :title="t('HomePage.TourRefTitle8')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent8') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef9?.$el' :title="t('HomePage.TourRefTitle9')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent9') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef10?.$el' :title="t('HomePage.TourRefTitle10')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent10') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef11?.$el' :title="t('HomePage.TourRefTitle11')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent11') }}</div>
    </el-tour-step>
    <!--suppress TypeScriptUnresolvedReference-->
    <el-tour-step :target='tourRef12?.$el' :title="t('HomePage.TourRefTitle12')">
      <div class='tour-guide-content'>{{ t('HomePage.TourRefContent12') }}</div>
    </el-tour-step>
  </el-tour>
</template>

<script setup lang='ts'>
import {ref, onMounted, onUnmounted, watch} from 'vue'
import {useI18n} from 'vue-i18n'
import router from '../utils/router'
import GlobalSearchBox from '../components/GlobalSearchBox.vue'
import {
  ossBaseUrl,
  tourRef1,
  tourRef2,
  tourRef3,
  tourRef4,
  tourRef5,
  tourRef6,
  tourRef7,
  tourRef8,
  tourRef9,
  tourRef10,
  tourRef11,
  tourRef12,
  showGuidedTour
} from '../globals'
import {MoreFilled} from '@element-plus/icons-vue'
import TypeIt from 'typeit'

const {t} = useI18n()
const showGroupOne = ref(false)
const showGroupTwo = ref(false)
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const isExpanded = ref(false)
const fullTextRef = ref<HTMLElement | null>(null)
const isContentVisible = ref(false)
const isButtonVisible = ref(true)
let typeInstance: TypeIt | null = null

const startTyping = () => {
  if (!typeInstance && fullTextRef.value) {
    const stringToType = t('HomePage.AIPresentation')
    const speedPerCharacter = 6000 / stringToType.length
    typeInstance = new TypeIt(fullTextRef.value, {
      strings: [stringToType],
      speed: speedPerCharacter,
      lifeLike: true,
      cursor: false,
      loop: false
    }).go()
  }
  isExpanded.value = true
}

const handleScroll = () => {
  const popupImage1 = document.querySelector('.popup-image1') as HTMLElement | null
  const popupImage3 = document.querySelector('.popup-image3') as HTMLElement | null
  if (popupImage1 && popupImage3) {
    const bounding1 = popupImage1.getBoundingClientRect()
    const bounding3 = popupImage3.getBoundingClientRect()
    showGroupOne.value = bounding1.top < window.innerHeight && bounding1.bottom >= 0
    showGroupTwo.value = bounding3.top < window.innerHeight && bounding3.bottom >= 0
  }
}

const handleButtonClick = () => {
  isContentVisible.value = !isContentVisible.value
  isButtonVisible.value = false
  if (isContentVisible.value) {
    setTimeout(() => {
      const contentContainer = document.querySelector('.content-container')
      if (contentContainer) {
        const offset = 55
        const topPosition = contentContainer.getBoundingClientRect().top + window.scrollY - offset
        window.scrollTo({top: topPosition, behavior: 'smooth'})
      }
    }, 100)
  }
}

onMounted(() => window.addEventListener('scroll', handleScroll))

onUnmounted(() => window.removeEventListener('scroll', handleScroll))

onMounted(() => {
  watch(isExpanded, (newValue) => {
    if (!newValue && typeInstance) {
      typeInstance.reset(undefined)
    }
  })
})

onMounted(() => {
  if (currentUserId.value == 0) {
    showGuidedTour.value = true
  }
})
</script>

<style scoped>
:global(:root) {
  --home-text-color: #4D0606;
  --home-group-one-bg-color: #F8ECF0;
  --home-group-two-bg-color: #FCE5F1;
  --home-card-bg-color: #FAF1F1;
  --home-card-border-color: #F8ECF0;
  --home-card-shadow-color: #F8ECF07F;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --home-text-color: #FAF1F1;
  --home-group-one-bg-color: #39031F;
  --home-group-two-bg-color: #33001A;
  --home-card-bg-color: #3C032B;
  --home-card-border-color: #420626;
  --home-card-shadow-color: #4D0606;
}

#app {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
  margin: 0;
  padding: 0;
  width: 100%;
  position: relative;
  overflow: hidden;
}

.search-container {
  position: absolute;
  top: 385px;
  left: 50%;
  transform: translateX(-50%);
}

.petjoy-title {
  position: absolute;
  top: 70px;
  width: 600px;
  left: 50%;
  transform: translateX(-50%);
}

.background-container {
  position: relative;
}

.background-video {
  width: 100%;
  height: calc(100vh - 55px);
  object-fit: cover;
  margin-bottom: -14px;
  transform: translateY(-10px);
}

.introduction-card {
  background: var(--home-card-bg-color);
  border: 3px solid var(--home-card-border-color);
  padding: 60px;
  margin: 50px;
  box-shadow: 0 4px 8px var(--home-card-shadow-color);
  border-radius: 50px;
  color: var(--home-text-color);
}

.ai-introduction-card {
  padding: 20px;
  margin: 50px;
  border-radius: 20px;
}

.content {
  display: flex;
  justify-content: flex-end;
  align-items: flex-start;
}

.bubble {
  position: relative;
  background: var(--home-card-bg-color);
  border: 2px solid var(--home-card-border-color);
  border-radius: 15px;
  padding: 20px 70px;
  margin-left: 20px;
  box-shadow: 0 4px 8px var(--home-card-shadow-color);
  color: var(--home-text-color);
  max-width: 100%;
}

.bubble:before, .bubble:after {
  content: '';
  position: absolute;
  top: 20px;
  right: -24px;
  width: 0;
  height: 0;
  border-top: 10px solid transparent;
  border-bottom: 10px solid transparent;
}

.bubble:before {
  border-left: 20px solid var(--home-card-bg-color);
}

.bubble:after {
  border-left: 24px solid var(--home-card-border-color);
  border-top: 12px solid transparent;
  border-bottom: 12px solid transparent;
}

.bubble.expanded {
  width: auto;
  height: auto;
  font-size: 22px;
  letter-spacing: 1px;
  line-height: 1.7;
  text-align: justify;
}

.bubble .initial {
  display: block;
}

.bubble .full {
  display: none;
  text-align: justify;
}

.bubble.expanded .initial {
  display: none;
}

.bubble.expanded .full {
  display: block;
}

.bg-group-one {
  background-color: var(--home-group-one-bg-color);
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.bg-group-two {
  background-color: var(--home-group-two-bg-color);
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.component-horizontal {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  width: 100%;
  margin: 10px auto;
}

.title-button-container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 10px;
}

.popup-image1, .popup-image2, .popup-image3, .popup-image4 {
  border-radius: 30px;
  width: 400px;
  height: 230px;
  object-fit: cover;
  box-shadow: 0 8px 16px rgba(0, 0, 0, 0.1);
  transition: transform 3.0s ease;
}

.popup-content1, .popup-content2, .popup-content3, .popup-content4 {
  width: 1000px;
  max-height: 400px;
  overflow: auto;
  padding: 10px;
  box-sizing: border-box;
  transition: transform 3.0s ease;
  color: var(--home-text-color);
}

.popup-text1, .popup-text2, .popup-text3, .popup-text4 {
  white-space: normal;
  word-wrap: break-word;
  font-size: 20px;
  line-height: 2;
  transition: transform 3.0s ease;
  text-align: justify;
}

.popup-image1, .popup-image3 {
  transform: translateX(-100%);
  margin-left: 80px;
  margin-right: 20px;
}

.popup-content1, .popup-content3 {
  transform: translateX(100%);
  margin-left: 80px;
  margin-right: 20px;
}

.popup-image2, .popup-image4 {
  transform: translateX(100%);
  margin-left: 20px;
  margin-right: 80px;
}

.popup-content2, .popup-content4 {
  transform: translateX(-100%);
  margin-left: 80px;
  margin-right: 20px;
}

@media (max-width: 1200px) {
  .popup-content1, .popup-content2, .popup-content3, .popup-content4 {
    max-height: 300px;
  }
}

@media (max-width: 800px) {
  .popup-content1, .popup-content2, .popup-content3, .popup-content4 {
    max-height: 200px;
  }
}

@media (max-width: 600px) {
  .popup-content1, .popup-content2, .popup-content3, .popup-content4 {
    max-height: 150px;
  }
}

.visible {
  transform: translateX(0);
}

.tour-guide-content {
  font-size: 15px;
  line-height: 1.6;
  text-align: justify;
  position: relative;
}

.tour-guide-initial-content {
  font-size: 15px;
  line-height: 1.6;
  text-align: justify;
  position: relative;
  padding: 20px;
}

.tour-guide-header {
  display: flex;
  align-items: center;
  margin-bottom: 20px;
}

.tour-guide-logo {
  width: 80px;
  height: auto;
  margin-right: 20px;
  object-fit: contain;
}

.tour-guide-title {
  font-size: 24px;
  font-weight: bold;
  margin: 0;
}

.tour-guide-body {
  padding-right: 150px;
}

.tour-guide-welcome {
  position: relative;
  width: calc(100% + 150px);
  margin-bottom: 20px;
}

.tour-guide-ai-image {
  position: absolute;
  bottom: 10px;
  right: 10px;
  width: 120px;
  height: auto;
  object-fit: contain;
}

@keyframes smooth-flow-gradient {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
}

.water-ripple {
  position: absolute;
  top: 90%;
  left: 50%;
  transform: translate(-50%, -50%);
  padding: 12px 36px;
  color: white;
  text-decoration: none;
  text-transform: uppercase;
  font-size: 18px;
  letter-spacing: 2px;
  border-radius: 40px;
  overflow: hidden;
  background: linear-gradient(90deg, #9A2E4F, #E8AEC9, #E15D82, #EA89B1, #B83960);
  background-size: 300% 300%;
  font-weight: bold;
  animation: smooth-flow-gradient 10s linear infinite;
}
</style>
