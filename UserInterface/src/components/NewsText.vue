<!--
  Project Name:  UserInterface
  File Name:     NewsText.vue
  File Function: 新闻文本组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='news-text'>
    <h1>{{ newsData.title }}</h1>
    <div class='time'>
      {{ t('NewsPage.UpdatedAt') }}
      {{ newsData.updateDate }}
      <el-tag class='news-tag' type='warning' size='large'>{{ newsTag }}</el-tag>
    </div>
    <p>{{ newsData.summary }}</p>
    <div v-html='newsContent'/>
    <div class='news-footer'>
      <div class='news-stats'>
        <div class='stat-item'>
          <img :src='`${ossBaseUrl}LogosAndIcons/Like.png`' alt='Like' class='like-logo' @click='handleLike'>
          <span class='stat-text'>{{ newsData.likeCount }}</span>
        </div>
        <div class='stat-item'>
          <img :src='`${ossBaseUrl}LogosAndIcons/Star.png`' alt='Star' class='star-logo' @click='handleFavorite'>
          <span class='stat-text'>{{ newsData.favoriteCount }}</span>
        </div>
        <div class='stat-item'>
          <img :src='`${ossBaseUrl}LogosAndIcons/Comment.png`' alt='Comment' class='comment-logo'>
          <span class='stat-text'>{{ newsData.commentCount }}</span>
        </div>
        <div class='stat-item'>
          <img :src='`${ossBaseUrl}LogosAndIcons/Dislike.png`' alt='Dislike' class='dislike-logo'
               @click='handleDislike'>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {ref, onMounted, defineProps, watch} from 'vue'
import axiosInstance from '../utils/axios'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import {ElMessage} from 'element-plus'
import {useI18n} from 'vue-i18n'
import {useRouter} from 'vue-router'

const {t} = useI18n()
const router = useRouter()
const props = defineProps<{ newsId: number }>()
const newsContent = ref('')
const newsTag = ref('')
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)

const newsData = ref({
  newsId: 0,
  userId: 0,
  tagId: 0,
  title: '',
  summary: '',
  content: '',
  creationDate: '',
  updateDate: '',
  coverUrl: '',
  isSticky: false,
  likeCount: 0,
  dislikeCount: 0,
  favoriteCount: 0,
  commentCount: 0
})

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`news/${props.newsId}`)
    if (response.status == 404) {
      await router.push('/404')
    } else {
      newsData.value = response.data
      newsData.value.isSticky = response.data.isSticky == 1
      newsData.value.creationDate = formatDateTimeToCST(response.data.creationDate).dateTime
      newsData.value.updateDate = formatDateTimeToCST(response.data.updateDate).dateTime
      newsContent.value = response.data.content
      const tagResponse = await axiosInstance.get(`news-tag/${newsData.value.tagId}`)
      newsTag.value = tagResponse.data.tag
    }
  } catch (error) {
    if (error.response.status == 404) {
      await router.push('/404')
    } else {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
})

watch(newsContent, (newValue) => {
  const parser = new DOMParser()
  const doc = parser.parseFromString(newValue, 'text/html')
  const images = doc.querySelectorAll('img')
  images.forEach((img) => {
    img.style.maxWidth = '600px'
    img.style.width = '100%'
    img.style.height = 'auto'
    img.style.display = 'block'
    img.style.margin = '1em auto'
    img.style.borderRadius = '10px'
  })

  const pres = doc.querySelectorAll('pre')
  pres.forEach((pre) => {
    pre.style.backgroundColor = 'var(--news-text-bg-highlight)'
    pre.style.border = '1px solid var(--news-text-border)'
    pre.style.padding = '1em'
    pre.style.borderRadius = '3px'
    pre.style.overflowX = 'auto'
    pre.style.whiteSpace = 'pre-wrap'
    pre.style.width = '80%'
    pre.style.margin = '0 auto'
    pre.style.marginBottom = '16px'
  })

  const tables = doc.querySelectorAll('table')
  tables.forEach((table) => {
    table.style.width = '70%'
    table.style.borderCollapse = 'collapse'
    table.style.margin = '1em 0'
    table.style.margin = '0 auto'
  })

  const ths = doc.querySelectorAll('th')
  ths.forEach((th) => {
    th.style.backgroundColor = 'var(--news-text-table-head)'
    th.style.color = 'var(--news-text-th)'
    th.style.border = '1px solid var(--news-text-border)'
    th.style.padding = '0.5em'
    th.style.textAlign = 'center'
  })

  const codes = doc.querySelectorAll('code')
  codes.forEach((code) => {
    code.style.backgroundColor = 'var(--news-text-bg-highlight)'
    code.style.padding = '5px'
  })

  const tds = doc.querySelectorAll('td')
  tds.forEach((td) => {
    td.style.border = '1px solid var(--news-text-border)'
    td.style.padding = '0.5em'
    td.style.textAlign = 'center'
  })

  const paragraphs = doc.querySelectorAll('p')
  paragraphs.forEach((p) => {
    p.style.fontSize = '19px'
    p.style.lineHeight = '1.7'
    p.style.color = 'var(--news-text-text-color)'
    p.style.margin = '0 0 0.7em'
    if (!p.style.textAlign) {
      p.style.textAlign = 'justify'
    }
  })

  const h1s = doc.querySelectorAll('h1')
  h1s.forEach((h1) => {
    h1.style.fontSize = '2em'
    h1.style.color = 'var(--news-text-heading-color)'
  })

  const h2s = doc.querySelectorAll('h2')
  h2s.forEach((h2) => {
    h2.style.color = 'var(--news-text-heading-color)'
  })

  const h3s = doc.querySelectorAll('h3')
  h3s.forEach((h3) => {
    h3.style.color = 'var(--news-text-heading-color)'
  })

  const h4s = doc.querySelectorAll('h4')
  h4s.forEach((h4) => {
    h4.style.color = 'var(--news-text-heading-color)'
  })

  const h5s = doc.querySelectorAll('h5')
  h5s.forEach((h5) => {
    h5.style.color = 'var(--news-text-subheading-color)'
    h5.style.textAlign = 'center'
    h5.style.fontSize = '16px'
  })

  const hrs = doc.querySelectorAll('hr')
  hrs.forEach((hr) => {
    hr.style.border = 'none'
    hr.style.height = '1px'
    hr.style.backgroundColor = 'var(--news-text-divider-color)'
    hr.style.width = '100%'
    hr.style.marginBottom = '25px'
  })

  const uls = doc.querySelectorAll('ul')
  uls.forEach((ul) => {
    ul.style.marginLeft = '10px'
  })

  const ols = doc.querySelectorAll('ol')
  ols.forEach((ol) => {
    ol.style.marginLeft = '10px'
  })

  const lis = doc.querySelectorAll('li')
  lis.forEach((li) => {
    li.style.padding = '5px 5px'
    li.style.fontSize = '18px'
    li.style.color = 'var(--news-text-text-color-alt)'
  })

  const todos = doc.querySelectorAll('div')
  todos.forEach((todo) => {
    todo.style.fontSize = '18px'
    todo.style.padding = '5px 5px'
  })

  const inputs = doc.querySelectorAll('input')
  inputs.forEach((input) => {
    input.style.marginRight = '20px'
  })

  const videos = doc.querySelectorAll('video')
  videos.forEach((video) => {
    video.style.width = '90%'
    video.style.height = 'auto'
    video.style.display = 'block'
    video.style.margin = '1em auto'
  })

  const links = doc.querySelectorAll('a')
  links.forEach((a) => {
    a.style.color = 'var(--news-text-link-color)'
  })

  const blockquotes = doc.querySelectorAll('blockquote')
  blockquotes.forEach((blockquote) => {
    blockquote.style.backgroundColor = 'var(--news-text-bg-highlight)'
    blockquote.style.borderLeft = '5px solid var(--news-text-border-accent)'
    blockquote.style.padding = '10px 20px'
    blockquote.style.margin = '10px 0'
    blockquote.style.fontSize = '18px'
    blockquote.style.marginLeft = '20px'
  })

  newsContent.value = doc.body.innerHTML
})

async function handleLike() {
  try {
    await axiosInstance.get(`news-like/${props.newsId}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`news-like/${props.newsId}-${currentUserId.value}`)
      newsData.value.likeCount = newsData.value.likeCount - 1
      ElMessage.success(t('NewsPage.CanceledLike'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('news-like', {
        newsId: props.newsId,
        userId: currentUserId.value,
        likeTime: new Date().toISOString()
      })
      newsData.value.likeCount = newsData.value.likeCount + 1
      ElMessage.success(t('NewsPage.Liked'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}

async function handleFavorite() {
  try {
    await axiosInstance.get(`news-favorite/${props.newsId}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`news-favorite/${props.newsId}-${currentUserId.value}`)
      newsData.value.favoriteCount = newsData.value.favoriteCount - 1
      ElMessage.success(t('NewsPage.CanceledFavorite'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('news-favorite', {
        newsId: props.newsId,
        userId: currentUserId.value,
        favoriteTime: new Date().toISOString()
      })
      newsData.value.favoriteCount = newsData.value.favoriteCount + 1
      ElMessage.success(t('NewsPage.Favorited'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}

async function handleDislike() {
  try {
    await axiosInstance.get(`news-dislike/${props.newsId}-${currentUserId.value}`)
    try {
      await axiosInstance.delete(`news-dislike/${props.newsId}-${currentUserId.value}`)
      ElMessage.success(t('NewsPage.CanceledDislike'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  } catch {
    try {
      await axiosInstance.post('news-dislike', {
        newsId: props.newsId,
        userId: currentUserId.value,
        dislikeTime: new Date().toISOString()
      })
      ElMessage.success(t('NewsPage.Disliked'))
    } catch {
      ElMessage.error(t('ErrorMessage.PostErrorMessage'))
    }
  }
}
</script>

<style scoped>
:global(:root) {
  --news-text-bg-color: #FFFFF0;
  --news-text-summary: #E09F00;
  --news-text-summary-bg: #FFFACD;
  --news-text-summary-border: #E0E0E0;
  --news-text-text-color: #505050;
  --news-text-bg-highlight: #FCF7D8;
  --news-text-table-head: #FCF7D8;
  --news-text-th: #000000;
  --news-text-border: #DDDDDD;
  --news-text-heading-color: #303030;
  --news-text-subheading-color: #888888;
  --news-text-divider-color: #F5DEB3;
  --news-text-text-color-alt: #333333;
  --news-text-link-color: #A0522D;
  --news-text-border-accent: #D2B48C;
  --news-text-button-bg: #ecf5ff;
  --news-text-button-shadow: rgba(0, 0, 0, 0.1);
  --news-text-button-bg-hover: rgba(160, 210, 255, 0.7);
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --news-text-text-color: #FFFFFF;
  --news-text-bg-color: #202020;
  --news-text-summary: #FFDD85;
  --news-text-summary-bg: #2A2A2A;
  --news-text-summary-border: #505050;
  --news-text-bg-highlight: #3A3A3A;
  --news-text-table-head: #8E6F5A;
  --news-text-th: #FFFFFF;
  --news-text-border: #444444;
  --news-text-heading-color: #E0E0E0;
  --news-text-subheading-color: #AAAAAA;
  --news-text-divider-color: #605A4D;
  --news-text-text-color-alt: #F0F0F0;
  --news-text-link-color: #D28A5E;
  --news-text-border-accent: #806040;
  --news-text-button-bg: #35495E;
  --news-text-button-shadow: rgba(0, 0, 0, 0.3);
  --news-text-button-bg-hover: rgba(50, 100, 150, 0.7);
}

.news-text {
  line-height: 1.6;
  color: var(--news-text-text-color-alt);
  background: var(--news-text-bg-color);
  padding: 16px 50px 50px 50px;
}

.news-text h1 {
  font-size: 42px;
  margin: 15px;
  text-align: center;
  background-color: var(--news-text-bg-color);
  padding-top: 30px;
  padding-bottom: 25px;
}

.news-text p {
  font-family: Arial, sans-serif;
  font-size: 20px;
  line-height: 1.7;
  color: var(--news-text-summary);
  margin: 0 0 50px;
  padding: 15px 30px;
  text-align: justify;
  background-color: var(--news-text-summary-bg);
  border: 1px solid var(--news-text-summary-border);
  border-radius: 20px;
}

.time {
  width: 100%;
  font-size: 16px;
  margin-left: 16px;
  margin-bottom: 25px;
  color: var(--news-text-text-color);
}

.news-footer {
  display: flex;
  margin-top: 35px;
  align-items: center;
  justify-content: flex-end;
}

.news-tag {
  font-size: 16px;
  float: right;
  margin-right: 32px;
}

.news-stats {
  display: flex;
  align-items: center;
  margin-right: 10px;
  gap: 20px;
}

.stat-item {
  display: flex;
  align-items: center;
}

.stat-text {
  margin-left: 5px;
  font-size: 16px;
  color: var(--news-text-text-color);
}

.like-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(39%) sepia(87%) saturate(444%) hue-rotate(323deg) brightness(94%) contrast(99%);
}

.star-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(69%) sepia(60%) saturate(2944%) hue-rotate(4deg) brightness(89%) contrast(104%);
}

.comment-logo {
  filter: invert(60%) sepia(60%) saturate(2531%) hue-rotate(185deg) brightness(87%) contrast(101%);
}

.dislike-logo {
  cursor: pointer;
  transition: filter 0.2s ease-in-out;
  filter: invert(80%) sepia(0%) saturate(0%) hue-rotate(0deg) brightness(90%) contrast(100%);
}

.like-logo, .star-logo, .comment-logo, .dislike-logo {
  width: 20px;
  height: 20px;
}

.like-logo:hover, .star-logo:hover, .dislike-logo:hover {
  transform: scale(1.1);
}
</style>
