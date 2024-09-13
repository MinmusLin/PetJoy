<!--
  Project Name:  UserInterface
  File Name:     PetCarePage.vue
  File Function: 宠物护理页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-05
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='background-container'>
    <h1>{{ t('HeaderNavbar.PetCare') }}</h1>
    <div class='intro-container'>
      <p>{{ t('PetCarePage.Introduction') }}</p>
    </div>
  </div>
  <div class='page-container'>
    <CareCard v-for='(video, index) in paginatedVideos'
              :key='index'
              :videoUrl='video.url'
              :title='video.title'
              :cover='video.cover'
              class='care-card'/>
  </div>
  <el-pagination v-model:current-page='currentPage'
                 :page-size='pageSize'
                 :total='30'
                 layout='prev, pager, next'
                 class='pagination'/>
</template>

<script setup lang='ts'>
import {ref, computed} from 'vue'
import {useI18n} from 'vue-i18n'
import CareCard from '../components/CareCard.vue'

const {t} = useI18n()
const currentPage = ref(1)
const pageSize = 12

const paginatedVideos = computed(() => {
  const start = (currentPage.value - 1) * pageSize
  const end = start + pageSize
  return careVideos.value.slice(start, end)
})

const careVideos = ref([
  {
    url: 'PetCareVideos/PetCareVideo1.mp4',
    title: t('PetCarePage.Video1'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage1.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo2.mp4',
    title: t('PetCarePage.Video2'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage2.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo3.mp4',
    title: t('PetCarePage.Video3'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage3.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo4.mp4',
    title: t('PetCarePage.Video4'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage4.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo5.mp4',
    title: t('PetCarePage.Video5'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage5.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo6.mp4',
    title: t('PetCarePage.Video6'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage6.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo7.mp4',
    title: t('PetCarePage.Video7'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage7.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo8.mp4',
    title: t('PetCarePage.Video8'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage8.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo9.mp4',
    title: t('PetCarePage.Video9'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage9.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo10.mp4',
    title: t('PetCarePage.Video10'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage10.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo11.mp4',
    title: t('PetCarePage.Video11'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage11.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo12.mp4',
    title: t('PetCarePage.Video12'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage12.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo13.mp4',
    title: t('PetCarePage.Video13'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage13.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo14.mp4',
    title: t('PetCarePage.Video14'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage14.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo15.mp4',
    title: t('PetCarePage.Video15'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage15.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo16.mp4',
    title: t('PetCarePage.Video16'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage16.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo17.mp4',
    title: t('PetCarePage.Video17'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage17.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo18.mp4',
    title: t('PetCarePage.Video18'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage18.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo19.mp4',
    title: t('PetCarePage.Video19'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage19.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo20.mp4',
    title: t('PetCarePage.Video20'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage20.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo21.mp4',
    title: t('PetCarePage.Video21'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage21.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo22.mp4',
    title: t('PetCarePage.Video22'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage22.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo23.mp4',
    title: t('PetCarePage.Video23'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage23.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo24.mp4',
    title: t('PetCarePage.Video24'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage24.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo25.mp4',
    title: t('PetCarePage.Video25'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage25.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo26.mp4',
    title: t('PetCarePage.Video26'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage26.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo27.mp4',
    title: t('PetCarePage.Video27'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage27.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo28.mp4',
    title: t('PetCarePage.Video28'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage28.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo29.mp4',
    title: t('PetCarePage.Video29'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage29.jpg'
  },
  {
    url: 'PetCareVideos/PetCareVideo30.mp4',
    title: t('PetCarePage.Video30'),
    cover: 'PetCareVideoCoverImages/PetCareVideoCoverImage30.jpg'
  }
])
</script>

<style scoped>
:global(:root) {
  --care-background-image: linear-gradient(rgba(255, 255, 255, 0.2), rgba(255, 255, 255, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetCarePageBackgroundImage.jpg');
  --care-title-color: #ED871A;
  --care-title-shadow-color: #75371B;
  --care-intro-bg-color: rgba(227, 181, 120, 0.5);
  --care-intro-font-color: #472F05;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --care-background-image: linear-gradient(rgba(0, 0, 0, 0.2), rgba(0, 0, 0, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetCarePageBackgroundImage.jpg');
  --care-title-color: #FFCF8C;
  --care-title-shadow-color: #B16900;
  --care-intro-bg-color: rgba(158, 107, 25, 0.5);
  --care-intro-font-color: #F7E3AB;
}

.page-container {
  width: 1200px;
  max-width: 100%;
  margin: 20px auto 6px;
  display: flex;
  align-items: center;
  flex-wrap: wrap;
  gap: 20px;
  justify-content: space-between;
}

.care-card {
  margin-bottom: 12px;
}

h1 {
  width: 1200px;
  position: absolute;
  top: 12%;
  left: 50%;
  font-size: 64px;
  font-weight: bold;
  color: var(--care-title-color);
  text-align: center;
  transform: translateX(-50%);
  text-shadow: 0 2px 4px var(--care-title-shadow-color);
}

.background-container {
  height: 530px;
  width: 100%;
  background-image: var(--care-background-image);
  background-size: cover;
  background-position: center;
  transform: translateY(-10px);
}

.intro-container {
  position: absolute;
  top: 290px;
  left: 50%;
  transform: translateX(-50%);
  width: 60%;
  padding: 10px 25px;
  border-radius: 15px;
  min-height: 80px;
  background-color: var(--care-intro-bg-color);
  font-size: 20px;
  font-weight: bold;
  line-height: 2;
  text-align: justify;
  color: var(--care-intro-font-color);
}

.pagination {
  margin-top: 2px;
  margin-bottom: 20px;
  text-align: center;
  display: flex;
  justify-content: center;
}
</style>
