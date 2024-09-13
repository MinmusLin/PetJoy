<!--
  Project Name:  UserInterface
  File Name:     AboutPetJoyPage.vue
  File Function: 关于宠悦页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-02
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='main-container'>
    <h1 class='title'>{{ t('AboutPetJoyPage.Title') }}</h1>

    <div class='module1'>
      <h2 class='module-title1'>{{ t('AboutPetJoyPage.ModuleTitle1') }}</h2>
      <div class='module-content-wrapper'>
        <p class='module-content1'>{{ t('AboutPetJoyPage.ModuleContent1') }}</p>
      </div>
    </div>

    <div class='module2'>
      <h2 class='module-title2'>{{ t('AboutPetJoyPage.ModuleTitle2') }}</h2>
      <p class='module-content2'>{{ t('AboutPetJoyPage.ModuleContent2') }}</p>
      <p class='module-content2'>{{ t('AboutPetJoyPage.ModuleContent3') }}</p>
      <p class='module-content2'>{{ t('AboutPetJoyPage.ModuleContent4') }}</p>
    </div>

    <div class='module2'>
      <h2 class='module-title2'>{{ t('AboutPetJoyPage.ModuleTitle3') }}</h2>
      <p class='module-content2'>{{ t('AboutPetJoyPage.ModuleContent5') }}</p>
    </div>

    <div class='module2'>
      <p class='module-content2'>
        <span class='content-format'>{{ t('AboutPetJoyPage.ModuleContent6') }}</span>
        <span class='title-format'>{{ t('AboutPetJoyPage.ModuleTitle4') }}</span>
        <span class='content-format'>{{ t('AboutPetJoyPage.ModuleContent7') }}</span>
      </p>

      <p class='module-content2'>
        <span class='title-format'>{{ t('AboutPetJoyPage.ModuleTitle5') }}</span>
        <span class='content-format'>{{ t('AboutPetJoyPage.ModuleContent8') }}</span>
      </p>

      <p class='module-content2'>
        <span class='title-format'>{{ t('AboutPetJoyPage.ModuleTitle6') }}</span>
        <span class='content-format'>{{ t('AboutPetJoyPage.ModuleContent9') }}</span>
      </p>

      <p class='module-content2'>
        <span class='title-format'>{{ t('AboutPetJoyPage.ModuleTitle7') }}</span>
        <span class='content-format'>{{ t('AboutPetJoyPage.ModuleContent10') }}</span>
      </p>

      <p class='module-content2'>
        <span class='title-format'>{{ t('AboutPetJoyPage.ModuleTitle8') }}</span>
        <span class='content-format'>{{ t('AboutPetJoyPage.ModuleContent11') }}</span>
      </p>
    </div>

    <div v-if='showTips' class='module1' style='margin-top: 80px'>
      <div class='module-content-wrapper' style='display: flex; align-items: center; justify-content: space-between'>
        <p class='module-content1'>{{ t('AboutPetJoyPage.Tips') }}</p>
        <el-icon :size='30' style='color: var(--about-module-title-color); cursor: pointer' @click='showTips=false'>
          <CloseBold/>
        </el-icon>
      </div>
    </div>

    <div class='container'>
      <div v-for='(member, index) in members' :key='index'>
        <div class='member' :class="{ 'hovered': member.hovered, 'reverse': member.reverse }">
          <div class='image-wrapper' :class="{ 'hovered': member.hovered, 'reverse': member.reverse }"
               @mouseover='members[index].hovered=true'>
            <img :src='member.photo' :alt='member.name'/>
          </div>
          <div class='info' :class="{ 'hovered': member.hovered, 'reverse': member.reverse }">
            <div class='text-content'>
              <p class='name-school'>
                <span class='name'>{{ member.name }}</span>
                <span class='school'>{{ t('AboutPetJoyPage.TongjiUniversity') }}</span>
                <el-icon v-if='index == 0 && member.hovered' :size='30' class='personal-homepage' @click='openLink'>
                  <HomeFilled/>
                </el-icon>
              </p>
              <p class='detail-content'>
                <span>{{ member.description }}</span>
              </p>
            </div>
          </div>
        </div>
        <hr class='separator'/>
      </div>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {ref} from 'vue'
import {useI18n} from 'vue-i18n'
import {ossBaseUrl} from '../globals'
import {CloseBold, HomeFilled} from '@element-plus/icons-vue'

const {t} = useI18n()
const showTips = ref(true)
const members = ref([
  {
    name: t('AboutPetJoyPage.JishenLin'),
    photo: `${ossBaseUrl}DevelopmentTeam/JishenLin.jpg`,
    description: t('AboutPetJoyPage.JishenLinDescription'),
    hovered: false,
    reverse: true
  },
  {
    name: t('AboutPetJoyPage.ChengzheZhong'),
    photo: `${ossBaseUrl}DevelopmentTeam/ChengzheZhong.jpg`,
    description: t('AboutPetJoyPage.ChengzheZhongDescription'),
    hovered: false,
    reverse: false
  },
  {
    name: t('AboutPetJoyPage.MingzheLi'),
    photo: `${ossBaseUrl}DevelopmentTeam/MingzheLi.jpg`,
    description: t('AboutPetJoyPage.MingzheLiDescription'),
    hovered: false,
    reverse: true
  },
  {
    name: t('AboutPetJoyPage.TianleDu'),
    photo: `${ossBaseUrl}DevelopmentTeam/TianleDu.jpg`,
    description: t('AboutPetJoyPage.TianleDuDescription'),
    hovered: false,
    reverse: false
  },
  {
    name: t('AboutPetJoyPage.ShuyiLiu'),
    photo: `${ossBaseUrl}DevelopmentTeam/ShuyiLiu.jpg`,
    description: t('AboutPetJoyPage.ShuyiLiuDescription'),
    hovered: false,
    reverse: true
  },
  {
    name: t('AboutPetJoyPage.ZhexvLiang'),
    photo: `${ossBaseUrl}DevelopmentTeam/ZhexvLiang.jpg`,
    description: t('AboutPetJoyPage.ZhexvLiangDescription'),
    hovered: false,
    reverse: false
  },
  {
    name: t('AboutPetJoyPage.SiyuanZhao'),
    photo: `${ossBaseUrl}DevelopmentTeam/SiyuanZhao.jpg`,
    description: t('AboutPetJoyPage.SiyuanZhaoDescription'),
    hovered: false,
    reverse: true
  },
  {
    name: t('AboutPetJoyPage.YukunYang'),
    photo: `${ossBaseUrl}DevelopmentTeam/YukunYang.jpg`,
    description: t('AboutPetJoyPage.YukunYangDescription'),
    hovered: false,
    reverse: false
  },
  {
    name: t('AboutPetJoyPage.YaoLiu'),
    photo: `${ossBaseUrl}DevelopmentTeam/YaoLiu.jpg`,
    description: t('AboutPetJoyPage.YaoLiuDescription'),
    hovered: false,
    reverse: true
  },
  {
    name: t('AboutPetJoyPage.MohanWang'),
    photo: `${ossBaseUrl}DevelopmentTeam/MohanWang.jpg`,
    description: t('AboutPetJoyPage.MohanWangDescription'),
    hovered: false,
    reverse: false
  }
])

function openLink() {
  window.open('https://github.com/MinmusLin', '_blank')
}
</script>

<style scoped>
:global(:root) {
  --about-main-container-bg: url('[TODO: ossBaseUrl]BackgroundImages/AboutPetJoyPageLightBackgroundImage.jpg');
  --about-title-color: #F18383;
  --about-title-shadow-color: #FFB9B9;
  --about-module-content-wrapper-color: #FCD3D399;
  --about-module-title-color: #F89898;
  --about-separator-color: #FCD3D3;
  --about-info-bg-color: #FCD3D399;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --about-main-container-bg: url('[TODO: ossBaseUrl]BackgroundImages/AboutPetJoyPageDarkBackgroundImage.jpg');
  --about-title-color: #CA5353;
  --about-title-shadow-color: #911F1F;
  --about-module-content-wrapper-color: #B2525299;
  --about-module-title-color: #B25252;
  --about-separator-color: #582E2E;
  --about-info-bg-color: #582E2E99;
}

.main-container {
  min-width: 1200px;
  height: auto;
  width: 100%;
  max-width: 100%;
  padding: 20px 0 80px;
  box-sizing: border-box;
  text-align: center;
  background-image: var(--about-main-container-bg);
  background-size: auto;
  background-position: center;
  background-repeat: repeat;
  margin: -10px auto 0;
}

.title {
  text-align: center;
  font-size: 60px;
  margin-bottom: 40px;
  padding-top: 30px;
  color: var(--about-title-color);
  text-shadow: 0 4px 8px var(--about-title-shadow-color);
}

.module1 {
  margin: 0 auto 20px;
  min-width: 1200px;
  max-width: 1200px;
  padding-bottom: 5px;
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.module-content-wrapper {
  padding-left: 40px;
  padding-right: 40px;
  border-radius: 20px;
  background-color: var(--about-module-content-wrapper-color);
}

.module2 {
  margin: 0 auto 20px;
  padding-bottom: 15px;
  min-width: 1200px;
  max-width: 1200px;
}

.module-title1 {
  font-size: 36px;
  margin-bottom: 20px;
  justify-content: flex-start;
  line-height: 1.8;
  text-align: justify;
  color: var(--about-module-title-color);
  position: relative;
}

.module-title2 {
  font-size: 36px;
  margin-bottom: -12px;
  line-height: 1.8;
  justify-content: flex-start;
  text-align: justify;
  color: var(--about-module-title-color);
  position: relative;
}

.module-title1::before, .module-title2::before {
  content: '';
  display: inline-block;
  width: 8px;
  height: 36px;
  background-color: var(--about-module-title-color);
  margin-right: 16px;
  vertical-align: middle;
  transform: translateY(-3px);
}

.module-content1 {
  font-size: 24px;
  justify-content: flex-start;
  line-height: 1.8;
  text-align: justify;
}

.module-content2 {
  font-size: 24px;
  justify-content: flex-start;
  line-height: 1.8;
  text-align: justify;
  margin-bottom: calc(-0.8em);
}

.content-format {
  font-size: 24px;
  justify-content: flex-start;
  line-height: 1.8;
  text-align: justify;
}

.title-format {
  font-size: 24px;
  font-weight: bold;
  line-height: 1.8;
  justify-content: flex-start;
  text-align: justify;
  color: var(--about-module-title-color);
}

.container {
  display: flex;
  min-width: 1200px;
  flex-direction: column;
  align-items: center;
  gap: 20px;
  justify-content: center;
}

.member {
  position: relative;
  width: 1200px;
  height: 420px;
  overflow: hidden;
  display: flex;
  justify-content: center;
  align-items: center;
}

.separator {
  border: none;
  height: 6px;
  background: repeating-linear-gradient(to right, var(--about-separator-color), var(--about-separator-color) 50px, transparent 50px, transparent 100px);
  margin: 20px 0 0 25px;
}

.image-wrapper {
  width: 450px;
  height: 300px;
  position: absolute;
  overflow: hidden;
  transition: transform 1.6s ease;
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 2;
  box-shadow: 0 2px 4px 3px rgba(0, 0, 0, 0.3);
  background-color: transparent;
  border-radius: 10px;
}

.image-wrapper img {
  width: 100%;
  height: 300px;
}

.info {
  width: 450px;
  height: 300px;
  position: relative;
  top: 0;
  left: 100%;
  background-color: var(--about-info-bg-color);
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  line-height: 1.8;
  padding: 30px 30px;
  box-sizing: border-box;
  transition: transform 1.6s ease;
  z-index: 1;
  font-size: 20px;
  text-align: justify;
  border-radius: 10px;
  box-shadow: 0 2px 4px 3px rgba(0, 0, 0, 0.1);
}

.member.reverse .info {
  left: auto;
  right: 100%;
}

.name-school {
  display: flex;
  width: 100%;
  align-items: flex-end;
  margin: 0;
}

.name-school .name {
  font-weight: bold;
  font-size: 26px;
}

.name-school .school {
  font-size: 14px;
  padding-left: 20px;
  transform: translateY(-6px);
}

.detail-content {
  font-size: 16px;
  justify-content: flex-start;
  line-height: 1.5;
  text-align: justify;
}

.member.hovered .info {
  transform: translateX(-1450px);
}

.member.reverse.hovered .info {
  transform: translateX(1450px);
}

.member.hovered .image-wrapper {
  transform: translateX(250px);
}

.member.reverse.hovered .image-wrapper {
  transform: translateX(-250px);
}

.personal-homepage {
  position: fixed;
  color: var(--about-module-title-color);
  transform: translateX(360px) translateY(-12px);
  cursor: pointer;
}
</style>
