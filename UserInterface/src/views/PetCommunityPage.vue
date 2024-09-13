<!--
  Project Name:  UserInterface
  File Name:     PetCommunityPage.vue
  File Function: 宠物社区页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-06
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='background-container'>
    <h1>{{ t('HeaderNavbar.PetCommunity') }}</h1>
    <div class='search-container'>
      <CommunitySearchBox/>
    </div>
    <el-button class='publish-post-button' round @click='publishPost'>
      {{ locale == 'zh' ? '我要发帖' : t('PetCommunityPage.PublishPost') }}
    </el-button>
  </div>

  <div class='page-container'>
    <div class='notice-container'>
      <el-header class='centered-header'>
        <div class='header-container'>
          <span class='header-icon'>•</span>
          <span class='large-purple-text'>{{ t('PetCommunityPage.NoticeHead') }}</span>
          <span class='header-icon'>•</span>
        </div>
        <span class='small-text'>NOTICE</span>
      </el-header>

      <div class='horizontal-container'>
        <div class='card-container'>
          <img :src='`${ossBaseUrl}PetCommunityPage/PetHealth.jpg`' class='circular-image' alt='Image 1'>
          <div class='card-head'>{{ t('PetCommunityPage.NoticeCardHeadOne') }}</div>
          <div>
            <span class='card-icon'>⏰</span>
            <span class='card-icon-text'>{{ t('PetCommunityPage.NoticeFirstCardTextOne') }}</span>
            <span class='card-icon'>⏰</span>
          </div>
          <div class='card-text'>{{ t('PetCommunityPage.NoticeFirstCardTextTwo') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeFirstCardTextThree') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeFirstCardTextFour') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeFirstCardTextFive') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeFirstCardTextSix') }}</div>
        </div>
        <div class='card-container'>
          <img :src='`${ossBaseUrl}PetCommunityPage/PamperedPetsPunchCard.jpg`' class='circular-image'
               alt='HarmonyCommunity'>
          <div class='card-head'>{{ t('PetCommunityPage.NoticeCardHeadTwo') }}</div>
          <div>
            <span class='card-icon'>🐾</span>
            <span class='card-icon-text'>{{ t('PetCommunityPage.NoticeSecondCardTextOne') }}</span>
            <span class='card-icon'>🐾</span>
          </div>
          <div class='card-text'>{{ t('PetCommunityPage.NoticeSecondCardTextTwo') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeSecondCardTextThree') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeSecondCardTextFour') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeSecondCardTextFive') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeSecondCardTextSix') }}</div>
        </div>
        <div class='card-container'>
          <img :src='`${ossBaseUrl}PetCommunityPage/HarmonyCommunity.jpg`' class='circular-image' alt='Image 1'>
          <div class='card-head'>{{ t('PetCommunityPage.NoticeCardHeadThree') }}</div>
          <div>
            <span class='card-icon'>🏥</span>
            <span class='card-icon-text'>{{ t('PetCommunityPage.NoticeThirdCardTextOne') }} </span>
            <span class='card-icon'>🏥</span>
          </div>
          <div class='card-text'>{{ t('PetCommunityPage.NoticeThirdCardTextTwo') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeThirdCardTextThree') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeThirdCardTextFour') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeThirdCardTextFive') }}</div>
          <div class='card-small-text'>{{ t('PetCommunityPage.NoticeThirdCardTextSix') }}</div>
        </div>
      </div>
    </div>

    <h2 style='font-size: 36px; margin-top: 20px; margin-bottom: 20px'>
      {{ t('PetCommunityPage.PopularCategories') }}
    </h2>
    <div style='margin-bottom: 30px; position: relative'>
      <p style='font-size: 22px; margin: 0'>{{ t('PetCommunityPage.ClickBelow') }}</p>
      <div v-if='categoryIds.length==1' style='position: absolute; right: 0; top: 0'>
        <el-tag size='large' type='danger'
                style='font-size: 16px; padding-bottom: 2px; padding-left: 13px; height: 36px'>
          {{ petCategories[categoryIds[0] - 1].title }}
          <el-icon style='transform: translateY(2px)' @click='categoryIds=[1, 2, 3, 4, 5, 6, 7, 8, 9]' :size='16'>
            <CloseBold/>
          </el-icon>
        </el-tag>
      </div>
    </div>

    <div class='category-container'>
      <Swiper slidesPerView='5'
              :autoplay='{ delay: 2000, disableOnInteraction: false }'
              :edgeSwipeDetection='true'
              loop>
        <SwiperSlide v-for='(category, index) in petCategories' :key='index' class='swiper-slide'>
          <div class='image-container'>
            <img :src='category.src' :alt='category.alt' class='image' style='height: 150px'/>
            <div class='hover-layer' @click='categoryIds=[category.id]'>
              <div class='title'>{{ category.title }}</div>
            </div>
          </div>
        </SwiperSlide>
      </Swiper>
    </div>

    <div>
      <PostCard v-for='postId in paginatedPostIds' :key='postId' :post-id='postId'/>
      <div class='pagination-container'>
        <el-pagination @current-change='handleCurrentChange'
                       :current-page='currentPage'
                       :page-size='pageSize'
                       layout='prev, pager, next'
                       :total='totalPosts'>
        </el-pagination>
      </div>
    </div>
  </div>

  <el-dialog v-model='showPublishPost'
             width='1000px'
             style='height: auto'
             :title="t('PetCommunityPage.PublishPost')"
             :close-on-click-modal='false'
             :close-on-press-escape='false'
             align-center>
    <el-form :model='postRuleForm'
             ref='postRuleFormRef'
             :rules='postRules'>
      <el-form-item prop='title'>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <el-icon :size='18' style='margin-right: 5px'>
              <Postcard/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PetCommunityPage.PostTitleLabel') }}</span>
          </div>

          <el-input v-model='postRuleForm.title'
                    maxlength='64'
                    size='large'
                    show-word-limit
                    :placeholder="t('PetCommunityPage.PostTitlePlaceholder')"/>
        </div>
      </el-form-item>

      <el-form-item prop='content'>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <el-icon :size='18' style='margin-right: 5px'>
              <Collection/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PetCommunityPage.PostContentLabel') }}</span>
          </div>

          <el-input v-model='postRuleForm.content'
                    maxlength='512'
                    show-word-limit
                    :autosize='{ minRows: 3 }'
                    type='textarea'
                    size='large'
                    :placeholder="t('PetCommunityPage.PostContentPlaceholder')"/>
        </div>
      </el-form-item>

      <el-form-item prop='categoryId'>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <el-icon :size='18' style='margin-right: 5px'>
              <CollectionTag/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PetCommunityPage.PostCategoryLabel') }}</span>
          </div>

          <el-radio-group size='large' v-model='postRuleForm.categoryId'>
            <el-radio v-for='tag in sortedPostCategories' :key='tag.id' :label='tag.id'>{{ tag.name }}</el-radio>
          </el-radio-group>
        </div>
      </el-form-item>
    </el-form>

    <div style='display: flex'>
      <el-upload ref='postImage'
                 :limit='1'
                 :before-upload='handleBeforeUploadImage'
                 accept='.jpeg, .jpg'
                 :show-file-list='false'>
        <el-button size='large' plain>
          <span>{{ t('PetCommunityPage.UploadPostImagePrompt') }}</span>
        </el-button>
      </el-upload>

      <el-button v-if="imageUrls[0]!=''" size='large' plain style='margin-left: 12px' @click='imageViewerVisible=true'>
        <span>{{ t('PetCommunityPage.ViewPostImagePrompt') }}</span>
      </el-button>
    </div>

    <el-button-group style='display: flex; justify-content: center; margin-top: 8px'>
      <el-button size='large' @click='cancelPublishPost'>{{ t('PetCommunityPage.Cancel') }}</el-button>
      <el-button size='large' @click='submitPost(postRuleFormRef)' type='primary'>
        {{ t('PetCommunityPage.PublishPost') }}
      </el-button>
    </el-button-group>
  </el-dialog>

  <el-image-viewer v-if='imageViewerVisible'
                   :url-list='addOssPrefix()'
                   :initial-index='0'
                   @close='imageViewerVisible=false'/>
</template>

<script setup lang='ts'>
import {ref, computed, onMounted, watch, reactive} from 'vue'
import {useI18n} from 'vue-i18n'
import {Swiper, SwiperSlide} from 'swiper/vue'
import {ossBaseUrl} from '../globals'
import SwiperCore from 'swiper'
import {Autoplay} from 'swiper/modules'
import PostCard from '../components/PostCard.vue'
import CommunitySearchBox from '../components/CommunitySearchBox.vue'
import axiosInstance from '../utils/axios'
import {ElMessage, ElMessageBox, ElNotification, FormInstance, FormRules, UploadInstance} from 'element-plus'
import {CloseBold, Collection, CollectionTag, Postcard} from '@element-plus/icons-vue'
import 'swiper/css'

SwiperCore.use([Autoplay])

const {t, locale} = useI18n()
const currentPage = ref(1)
const pageSize = ref(10)
const totalPosts = computed(() => postIds.value.length)
const postIds = ref([])
const categoryIds = ref([1, 2, 3, 4, 5, 6, 7, 8, 9])
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const showPublishPost = ref(false)
const postCategories = ref([])
const postImage = ref<UploadInstance>()
const postRuleFormRef = ref<FormInstance>()
const imageViewerVisible = ref(false)
const imageUrls = ref([''])

interface PostRuleForm {
  title: string
  content: string
  categoryId: string
}

const sortedPostCategories = computed(() => postCategories.value.sort((a, b) => a.id - b.id))

const postRuleForm = reactive<PostRuleForm>({
  title: '',
  content: '',
  categoryId: ''
})

const postRules: FormRules = {
  title: [
    {
      required: true,
      message: t('PetCommunityPage.RequiredPostTitle'),
      trigger: 'blur'
    },
  ],
  content: [
    {
      required: true,
      message: t('PetCommunityPage.RequiredPostContent'),
      trigger: 'blur'
    },
  ],
  categoryId: [
    {
      required: true,
      message: t('PetCommunityPage.RequiredCategoryId'),
      trigger: 'blur'
    }
  ]
}

const paginatedPostIds = computed(() => {
  const start = (currentPage.value - 1) * pageSize.value
  const end = start + pageSize.value
  return postIds.value.slice(start, end)
})

const handleCurrentChange = (page) => {
  currentPage.value = page
}

const petCategories = ref([
  {
    id: 1,
    src: `${ossBaseUrl}PostCategories/PostCategory1.jpg`,
    alt: 'HelpForIllness',
    title: t('PetCommunityPage.HelpForIllness')
  },
  {
    id: 2,
    src: `${ossBaseUrl}PostCategories/PostCategory2.jpg`,
    alt: 'LossOfPet',
    title: t('PetCommunityPage.LossOfPet')
  },
  {
    id: 3,
    src: `${ossBaseUrl}PostCategories/PostCategory3.jpg`,
    alt: 'PetDating',
    title: t('PetCommunityPage.PetDating')
  },
  {
    id: 4,
    src: `${ossBaseUrl}PostCategories/PostCategory4.jpg`,
    alt: 'FunSharing',
    title: t('PetCommunityPage.FunSharing')
  },
  {
    id: 5,
    src: `${ossBaseUrl}PostCategories/PostCategory5.jpg`,
    alt: 'Recommendations',
    title: t('PetCommunityPage.Recommendations')
  },
  {
    id: 6,
    src: `${ossBaseUrl}PostCategories/PostCategory6.jpg`,
    alt: 'FeedingExperience',
    title: t('PetCommunityPage.FeedingExperience')
  },
  {
    id: 7,
    src: `${ossBaseUrl}PostCategories/PostCategory7.jpg`,
    alt: 'TroubleShooting',
    title: t('PetCommunityPage.TroubleShooting')
  },
  {
    id: 8,
    src: `${ossBaseUrl}PostCategories/PostCategory8.jpg`,
    alt: 'TrainingSkills',
    title: t('PetCommunityPage.TrainingSkills')
  },
  {
    id: 9,
    src: `${ossBaseUrl}PostCategories/PostCategory9.jpg`,
    alt: 'Others',
    title: t('PetCommunityPage.Others')
  }
])

function addOssPrefix(): string[] {
  return imageUrls.value.map(url => `${ossBaseUrl}${url}`)
}

onMounted(async () => {
  try {
    const response = await axiosInstance.post('post/filter-by-category', categoryIds.value)
    postIds.value = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

watch(categoryIds, async (newCategoryIds, oldCategoryIds) => {
  if (newCategoryIds != oldCategoryIds) {
    try {
      const response = await axiosInstance.post('post/filter-by-category', newCategoryIds)
      postIds.value = response.data
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
}, {deep: true})

function publishPost() {
  if (currentUserId.value && currentUserId.value != 0) {
    showPublishPost.value = true
  } else {
    ElMessage.warning(t('SettingsPage.PleaseLoginFirst'))
  }
}

onMounted(async () => {
  try {
    const response = await axiosInstance.get('post-category')
    postCategories.value = response.data.map(tag => ({
      id: tag.categoryId,
      name: tag.category
    }))
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

function beforeUploadImage(file) {
  const isJPG = file.type == 'image/jpeg'
  const isLt5M = file.size / 1024 / 1024 < 5
  if (!isJPG) {
    ElMessage.error(t('PetCommunityPage.UploadedPostImageFormat'))
    return false
  }
  if (!isLt5M) {
    ElMessage.error(t('PetCommunityPage.UploadedPostImageSize'))
    return false
  }
  return true
}

const handleBeforeUploadImage = async (file: File) => {
  if (!beforeUploadImage(file)) {
    return
  }
  const formData = new FormData()
  formData.append('file', file, 'postImage.jpg')
  try {
    const response = await axiosInstance.post('upload-post-image', formData)
    imageUrls.value[0] = response.data.fileName
    ElMessage.success(t('PetCommunityPage.UploadPostImageSucceed'))
  } catch (error) {
    ElMessage.error(t('PetCommunityPage.UploadPostImageFailed'))
  }
}

const cancelPublishPost = () => {
  ElMessageBox.confirm(
      t('PetCommunityPage.CancelPublishPostPrompt'),
      t('PetCommunityPage.CancelPublishPost'),
      {
        showClose: false,
        closeOnClickModal: false,
        closeOnPressEscape: false,
        confirmButtonText: t('PetCommunityPage.Continue'),
        cancelButtonText: t('PetCommunityPage.Cancel')
      }
  ).catch(() => {
    showPublishPost.value = false
    resetFeedback(postRuleFormRef.value)
  })
}

const resetFeedback = (formEl: FormInstance | undefined) => {
  if (!formEl) {
    return
  }
  formEl.resetFields()
  imageUrls.value[0] = ''
}

const submitPost = async (formEl: FormInstance | undefined) => {
  if (!formEl) {
    return
  }
  await formEl.validate(async (valid) => {
    if (valid) {
      const result = await postPost()
      if (result) {
        ElNotification({
          title: t('PetCommunityPage.PublishPostSuccessfully'),
          message: t('PetCommunityPage.PublishPostSuccessfullyPrompt'),
          type: 'success'
        })
        showPublishPost.value = false
        resetFeedback(postRuleFormRef.value)
      } else {
        ElNotification({
          title: t('PetCommunityPage.PublishPostFailed'),
          message: t('PetCommunityPage.PublishPostFailedPrompt'),
          type: 'error'
        })
      }
    }
  })
}

async function postPost() {
  const now = new Date().toISOString()
  try {
    const response = await axiosInstance.post('post', {
      userId: currentUserId.value,
      categoryId: parseInt(postRuleForm.categoryId),
      title: postRuleForm.title,
      content: postRuleForm.content,
      creationDate: now,
      updateDate: now,
      isSticky: 0,
      likeCount: 0,
      dislikeCount: 0,
      favoriteCount: 0,
      commentCount: 0,
      imageUrl: imageUrls.value[0] == '' ? null : imageUrls.value[0]
    })
    return response.status == 201
  } catch (error) {
    return false
  }
}
</script>

<style scoped>
:global(:root) {
  --community-background-image: linear-gradient(rgba(255, 255, 255, 0.2), rgba(255, 255, 255, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetCommunityPageBackgroundImage.jpg');
  --community-title-color: #393B9C;
  --community-title-shadow-color: #787ACF;
  --community-img-title-color: #FFFFFF;
  --community-categoty-bg-color: #FFF0F0;
  --community-notice-bg-color: #D8D9E8;
  --community-notice-head-color: #373F9E;
  --community-card-color: #373F9E;
  --community-card-text-color: #64616C;
  --community-card-bg-color: #FFFFFF;
  --community-publish-post-button-text: #F1EAFF;
  --community-publish-post-button: #393B9C;
  --community-publish-post-button-hover: #7F71D0;
  --community-publish-post-button-active: #46328A;
  --community-img-filter: brightness(100%);
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --community-background-image: linear-gradient(rgba(0, 0, 0, 0.2), rgba(0, 0, 0, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetCommunityPageBackgroundImage.jpg');
  --community-title-color: #E4DBFF;
  --community-title-shadow-color: #473B7E;
  --community-img-title-color: #E0E0E0;
  --community-categoty-bg-color: #391A2D;
  --community-notice-bg-color: #232535;
  --community-notice-head-color: #ACD1FF;
  --community-card-color: #E5E7FF;
  --community-card-text-color: #DDDDE1;
  --community-card-bg-color: #3E3E57;
  --community-publish-post-button-text: #46328A;
  --community-publish-post-button: #C3AFFF;
  --community-publish-post-button-hover: #D3C8FF;
  --community-publish-post-button-active: #9777FF;
  --community-img-filter: brightness(80%);
}

.page-container {
  width: 1200px;
  max-width: 100%;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
}

h1 {
  width: 1200px;
  position: absolute;
  top: 12%;
  left: 50%;
  font-size: 64px;
  font-weight: bold;
  color: var(--community-title-color);
  text-align: center;
  transform: translateX(-50%);
  text-shadow: 0 2px 4px var(--community-title-shadow-color);
}

.search-container {
  position: absolute;
  top: 250px;
  left: 50%;
  transform: translateX(-50%);
}

.background-container {
  height: 530px;
  width: 100%;
  background-image: var(--community-background-image);
  background-size: cover;
  background-position: center;
  transform: translateY(-10px);
}

.swiper-slide {
  display: flex;
  justify-content: center;
}

.image-container {
  position: relative;
  overflow: hidden;
  height: 150px;
}

.image {
  display: block;
  width: 100%;
  height: 100%;
  border-radius: 4px;
  filter: var(--community-img-filter);
}

.image-container .hover-layer {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.2);
  opacity: 1;
  border-radius: 4px;
  justify-content: center;
  align-items: center;
  color: white;
  font-size: 18px;
  font-weight: normal;
  transition: background-color 0.3s, font-weight 0.3s;
}

.image-container:hover .hover-layer {
  background-color: rgba(0, 0, 0, 0.5);
  font-weight: bold;
}

.pagination-container {
  display: flex;
  justify-content: center;
  margin-top: 20px;
  margin-bottom: 20px;
}

.title {
  color: var(--community-img-title-color);
  font-size: 18px;
  text-align: center;
  position: relative;
  top: 40%;
  justify-content: space-between;
}

.category-container {
  background-color: var(--community-categoty-bg-color);
  padding: 20px 12px;
  margin-bottom: 30px;
  border-radius: 20px;
}

.publish-post-button {
  position: absolute;
  top: 75%;
  left: 50%;
  width: 250px;
  height: 50px;
  font-size: 20px;
  font-weight: bold;
  color: var(--community-publish-post-button-text);
  background-color: var(--community-publish-post-button);
  border: none;
  border-radius: 10px;
  transform: translate(-50%, -50%);
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.3);
  transition: background-color 0.3s;
}

.publish-post-button:hover {
  background-color: var(--community-publish-post-button-hover);
}

.publish-post-button:active {
  background-color: var(--community-publish-post-button-active);
}

.form-label-wrapper {
  display: flex;
  flex-direction: column;
  width: 100%;
}

.form-label-container {
  display: flex;
  align-items: center;
  padding-bottom: 6px;
}

.required-star {
  color: #F56C6C;
  margin-right: 5px;
}

.horizontal-container {
  display: flex;
  justify-content: space-between;
  margin: 20px 0 10px;
}

.card-container {
  flex: 1;
  margin: 20px 10px 0;
  height: 360px;
  padding: 20px;
  background-color: var(--community-card-bg-color);
  text-align: center;
  border-radius: 10px;
  box-shadow: 0 1px 35px 0 rgba(0, 0, 0, 0.1);
}

.card-container:first-child {
  margin-left: 50px;
}

.card-container:last-child {
  margin-right: 50px;
}

.card-container > * {
  margin-bottom: 10px;
}

.card-container > *:last-child {
  margin-bottom: 25px;
}

.notice-container {
  background-color: var(--community-notice-bg-color);
  padding: 20px 12px;
  margin-bottom: 5px;
  margin-top: 25px;
  border-radius: 20px;
}

.centered-header {
  text-align: center;
  line-height: 1.5;
  margin-top: -20px;
}

.header-container {
  display: flex;
  align-items: center;
  justify-content: center;
}

.card-icon {
  font-size: 25px;
}

.header-icon {
  font-size: 30px;
  color: var(--community-notice-head-color);
  font-weight: 900;
  margin: 0 8px;
}

.large-purple-text {
  font-size: 35px;
  color: var(--community-notice-head-color);
  font-weight: bold;
  margin-top: 10px;
}

.card-icon-text {
  font-size: 18px;
  color: var(--community-card-color);
}

.small-text {
  font-size: 16px;
  font-weight: bold;
}

.circular-image {
  width: 90px;
  height: 90px;
  border-radius: 50%;
  object-fit: cover;
  display: block;
  margin: 0 auto 10px;
}

.card-head {
  font-size: 25px;
  color: var(--community-card-color);
  font-weight: bold;
}

.card-text {
  font-size: 15px;
  color: var(--community-card-text-color);
  text-align: center;
  margin-top: 20px;
  margin-bottom: 20px;
  line-height: 1.5;
}

.card-small-text {
  color: var(--community-card-color);
  text-align: center;
  font-size: 15px;
  margin-top: -2px;
  font-weight: 550;
}
</style>
