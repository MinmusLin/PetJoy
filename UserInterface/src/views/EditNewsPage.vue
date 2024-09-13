<!--
  Project Name:  UserInterface
  File Name:     EditNewsPage.vue
  File Function: 编辑新闻页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-14
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='page-container'>
    <h1 style='display: flex; justify-content: center; align-items: center'>
      {{ t('EditNewsPage.EditNews') }}
    </h1>

    <el-form :model='newsRuleForm' ref='newsRuleFormRef' :rules='newsRules'>
      <el-form-item prop='newsTitle'>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <el-icon :size='18' style='margin-right: 5px'>
              <Postcard/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PublishNewsPage.NewsTitleLabel') }}</span>
          </div>

          <el-input v-model='newsRuleForm.newsTitle'
                    maxlength='64'
                    size='large'
                    show-word-limit
                    :placeholder="t('PublishNewsPage.NewsTitlePlaceholder')"/>
        </div>
      </el-form-item>

      <el-form-item prop='newsSummary'>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <el-icon :size='18' style='margin-right: 5px'>
              <Collection/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PublishNewsPage.NewsSummaryLabel') }}</span>
          </div>

          <el-input v-model='newsRuleForm.newsSummary'
                    maxlength='128'
                    size='large'
                    show-word-limit
                    :placeholder="t('PublishNewsPage.NewsSummaryPlaceholder')"/>
        </div>
      </el-form-item>

      <el-form-item prop='newsTagId'>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <el-icon :size='18' style='margin-right: 5px'>
              <CollectionTag/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PublishNewsPage.NewsTagLabel') }}</span>
          </div>

          <el-radio-group size='large' v-model='newsRuleForm.newsTagId'>
            <el-radio v-for='tag in sortedNewsTags' :key='tag.id' :label='tag.id'>{{ tag.name }}</el-radio>
          </el-radio-group>
        </div>
      </el-form-item>

      <el-form-item>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <el-icon :size='18' style='margin-right: 5px'>
              <Flag/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PublishNewsPage.IsStickyLabel') }}</span>
          </div>

          <el-select v-model='newsRuleForm.isSticky' size='large' style='width: 480px'>
            <el-option :label="t('PublishNewsPage.RegularNews')" :value='false'/>
            <el-option :label="t('PublishNewsPage.StickyNews')" :value='true'/>
          </el-select>
        </div>
      </el-form-item>

      <el-form-item>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <el-icon :size='18' style='margin-right: 5px'>
              <Camera/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PublishNewsPage.CoverImageLabel') }}</span>
          </div>

          <div style='display: flex; align-items: flex-end'>
            <div style='height: 270px; width: 480px'>
              <VueCropper ref='cropper'
                          :img="uploadCorrectly ? coverImageDataUrl : ''"
                          :outputType='option.outputType'
                          :canScale='option.canScale'
                          :autoCrop='option.autoCrop'
                          :autoCropWidth='option.autoCropWidth'
                          :autoCropHeight='option.autoCropHeight'
                          :fixed='option.fixed'
                          :fixedNumber='option.fixedNumber'
                          :canMove='option.canMove'
                          :centerBox='option.centerBox'
                          :mode='option.mode'
                          :fillColor='option.fillColor'/>
            </div>

            <el-upload :on-change='handleCoverImageChange'
                       :before-upload='beforeUploadCoverImage'
                       :show-file-list='false'
                       accept='.jpeg, .jpg'>
              <div style='margin-left: 20px; display: flex; flex-direction: column; align-items: flex-start'>
                <img :src='`${ossBaseUrl}${duplicateNews.coverUrl}`' alt='OriginalCoverImage' height='210px'>
                <!--suppress TypeScriptValidateTypes-->
                <el-button size='large' :icon='Upload' style='margin-top: 20px' plain>
                  {{ t('EditNewsPage.UploadCoverImage') }}
                </el-button>
              </div>
            </el-upload>
          </div>
        </div>
      </el-form-item>

      <el-form-item>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <el-icon :size='18' style='margin-right: 5px'>
              <Picture/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PublishNewsPage.ContentImageLabel') }}</span>
          </div>

          <div style='display: flex; align-items: flex-end'>
            <el-upload v-model:file-list='contentImagesList'
                       :before-upload='handleBeforeUploadImage'
                       :on-preview='handlePreviewImage'
                       :before-remove='handleBeforeRemoveImage'
                       multiple
                       style='width: 100%'
                       accept='.jpeg, .jpg'
                       drag>
              <el-icon class='el-icon--upload'>
                <UploadFilled/>
              </el-icon>
              <div class='el-upload__text'>{{ t('PublishNewsPage.UploadContentImagesPrompt') }}</div>
            </el-upload>
          </div>
        </div>
      </el-form-item>

      <el-form-item>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <el-icon :size='18' style='margin-right: 5px'>
              <VideoCamera/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PublishNewsPage.ContentVideoLabel') }}</span>
          </div>

          <div style='display: flex; align-items: flex-end'>
            <el-upload v-model:file-list='contentVideosList'
                       :before-upload='handleBeforeUploadVideo'
                       :on-preview='handlePreviewVideo'
                       :before-remove='handleBeforeRemoveVideo'
                       multiple
                       style='width: 100%'
                       accept='.mp4'
                       drag>
              <el-icon class='el-icon--upload'>
                <UploadFilled/>
              </el-icon>
              <div class='el-upload__text'>{{ t('PublishNewsPage.UploadContentVideosPrompt') }}</div>
            </el-upload>
          </div>
        </div>
      </el-form-item>

      <el-form-item prop='newsContent'>
        <div class='form-label-wrapper'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <el-icon :size='18' style='margin-right: 5px'>
              <Memo/>
            </el-icon>
            <span style='font-size: 16px'>{{ t('PublishNewsPage.NewsContentLabel') }}</span>
          </div>

          <div style='border: 1px solid #CCCCCC'>
            <!--suppress TypeScriptValidateTypes-->
            <Toolbar style='border-bottom: 1px solid #CCCCCC'
                     :editor='editorRef'
                     :defaultConfig='toolbarConfig'
                     mode='default'/>
            <Editor ref='editor'
                    style='height: 500px; overflow-y: hidden'
                    v-model:html='newsRuleForm.newsContent'
                    :defaultConfig='editorConfig'
                    mode='default'
                    @onCreated='handleCreated'
                    @onChange='handleEditorChange'/>
          </div>
        </div>
      </el-form-item>

      <el-form-item>
        <div style='width: 100%; display: flex; justify-content: center'>
          <el-button-group>
            <el-button size='large' @click='showHtml=true'>
              {{ t('PublishNewsPage.DisplayHtml') }}
            </el-button>
            <el-button type='primary' size='large' @click='submitNewsForm(newsRuleFormRef)'>
              {{ t('EditNewsPage.SaveNews') }}
            </el-button>
          </el-button-group>
        </div>
      </el-form-item>
    </el-form>
  </div>

  <el-dialog v-model='showHtml' width='1200px' title='HTML' align-center>
    <el-scrollbar height='640px'>
      <p style='text-align: justify'>{{ newsRuleForm.newsContent }}</p>
    </el-scrollbar>
  </el-dialog>
</template>

<script setup lang='ts'>
import {ref, computed, shallowRef, onMounted, reactive, watch} from 'vue'
import {useI18n} from 'vue-i18n'
import {useRoute, useRouter} from 'vue-router'
import axiosInstance from '../utils/axios'
import {ElMessageBox, ElMessage, FormInstance, FormRules, UploadUserFile} from 'element-plus'
import {
  Postcard,
  CollectionTag,
  Collection,
  Memo,
  Flag,
  Picture,
  Upload,
  Camera,
  UploadFilled,
  VideoCamera
} from '@element-plus/icons-vue'
import {Editor, Toolbar} from '@wangeditor/editor-for-vue'
import {VueCropper} from 'vue-cropper'
import {dataUrlToBlob, ossBaseUrl} from '../globals'
import '@wangeditor/editor/dist/css/style.css'
import 'vue-cropper/dist/index.css'

const {t} = useI18n()
const route = useRoute()
const newsId = ref(parseInt(<string>route.params.id))
const editorRef = shallowRef(null)
const editorConfig = {placeholder: t('PublishNewsPage.NewsContentPlaceholder')}
const toolbarConfig = {excludeKeys: ['fullScreen']}
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const router = useRouter()
const newsTags = ref([])
const newsRuleFormRef = ref<FormInstance>()
const coverImageDataUrl = ref('')
const uploadCorrectly = ref(false)
const cropper = ref<InstanceType<typeof VueCropper>>()
const contentImagesList = ref<UploadUserFile[]>([])
const contentVideosList = ref<UploadUserFile[]>([])
const showHtml = ref(false)
const option = ref({
  outputType: 'jpeg',
  canScale: false,
  autoCrop: true,
  autoCropWidth: 480,
  autoCropHeight: 270,
  fixed: true,
  fixedNumber: [16, 9],
  canMove: false,
  centerBox: true,
  mode: 'contain',
  fillColor: 'white'
})

interface NewsRuleForm {
  newsTitle: string
  newsSummary: string
  newsTagId: string
  isSticky: boolean
  newsContent: string
}

const duplicateNews = ref({
  newsId: 0,
  userId: 0,
  tagId: 0,
  title: '',
  summary: '',
  content: '',
  creationDate: '',
  updateDate: '',
  coverUrl: '',
  isSticky: 0,
  likeCount: 0,
  dislikeCount: 0,
  favoriteCount: 0,
  commentCount: 0
})

const newsRuleForm = reactive<NewsRuleForm>({
  newsTitle: '',
  newsSummary: '',
  newsTagId: '',
  isSticky: false,
  newsContent: ''
})

const newsRules: FormRules = {
  newsTitle: [
    {
      required: true,
      message: t('PublishNewsPage.RequiredNewsTitle'),
      trigger: 'blur'
    },
  ],
  newsSummary: [
    {
      required: true,
      message: t('PublishNewsPage.RequiredNewsSummary'),
      trigger: 'blur'
    },
  ],
  newsTagId: [
    {
      required: true,
      message: t('PublishNewsPage.RequiredNewsTag'),
      trigger: 'blur'
    },
  ],
  newsContent: [
    {
      validator: (rule, value, callback) => {
        if (newsRuleForm.newsContent == '<p><br></p>' || newsRuleForm.newsContent == '') {
          callback(new Error(t('PublishNewsPage.RequiredNewsContent')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
    }
  ]
}

const sortedNewsTags = computed(() => newsTags.value.sort((a, b) => a.id - b.id))

const handleCreated = (editor) => editorRef.value = editor

const handleEditorChange = () => {
  if (editorRef.value) {
    // noinspection TypeScriptUnresolvedReference
    newsRuleForm.newsContent = editorRef.value.getHtml().trim()
  }
}

const submitNewsForm = async (formEl: FormInstance | undefined) => {
  if (!formEl) {
    return
  }
  await formEl.validate((valid) => {
    if (valid) {
      saveNews()
    }
  })
}

onMounted(async () => {
  if (currentUserId.value == 0) {
    await router.push('/login')
    await ElMessageBox.alert(t('SettingsPage.PleaseLoginFirst'), t('SettingsPage.Notice'), {
      showClose: false
    })
    return
  }
  try {
    const response = await axiosInstance.get(`user/role/${currentUserId.value}`)
    if (response.data == 0) {
      await router.push('/')
      await ElMessageBox.alert(t('PublishNewsPage.AuthorityPrompt'), t('SettingsPage.Notice'), {
        showClose: false
      })
    }
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    await router.push('/')
  }
})

onMounted(async () => {
  try {
    const response = await axiosInstance.get('news-tag')
    newsTags.value = response.data.map(tag => ({
      id: tag.tagId,
      name: tag.tag
    }))
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

function saveNews() {
  if (cropper.value && uploadCorrectly.value) {
    cropper.value.getCropData((data) => {
      const blobData = dataUrlToBlob(data)
      const formData = new FormData()
      formData.append('file', blobData, 'coverImage.jpg')
      axiosInstance.post('upload-news-cover-image', formData).then((response) => {
        if (response.status == 200) {
          axiosInstance.put(`news/${duplicateNews.value.newsId}`, {
            newsId: duplicateNews.value.newsId,
            userId: currentUserId.value,
            tagId: parseInt(newsRuleForm.newsTagId),
            title: newsRuleForm.newsTitle,
            summary: newsRuleForm.newsSummary,
            content: newsRuleForm.newsContent,
            creationDate: duplicateNews.value.creationDate,
            updateDate: new Date().toISOString(),
            coverUrl: response.data.fileName,
            isSticky: newsRuleForm.isSticky ? 1 : 0,
            likeCount: duplicateNews.value.likeCount,
            dislikeCount: duplicateNews.value.dislikeCount,
            favoriteCount: duplicateNews.value.favoriteCount,
            commentCount: duplicateNews.value.commentCount
          }).then(() => router.push(`/news/${duplicateNews.value.newsId}`)).catch(() => ElMessage.error(t('EditNewsPage.SaveNewsFailed')))
        } else {
          ElMessage.error(t('PublishNewsPage.UploadFailed'))
        }
      }).catch(() => ElMessage.error(t('PublishNewsPage.UploadFailed')))
    })
  } else {
    axiosInstance.put(`news/${duplicateNews.value.newsId}`, {
      newsId: duplicateNews.value.newsId,
      userId: currentUserId.value,
      tagId: parseInt(newsRuleForm.newsTagId),
      title: newsRuleForm.newsTitle,
      summary: newsRuleForm.newsSummary,
      content: newsRuleForm.newsContent,
      creationDate: duplicateNews.value.creationDate,
      updateDate: new Date().toISOString(),
      coverUrl: duplicateNews.value.coverUrl,
      isSticky: newsRuleForm.isSticky ? 1 : 0,
      likeCount: duplicateNews.value.likeCount,
      dislikeCount: duplicateNews.value.dislikeCount,
      favoriteCount: duplicateNews.value.favoriteCount,
      commentCount: duplicateNews.value.commentCount
    }).then(() => router.push(`/news/${duplicateNews.value.newsId}`)).catch(() => ElMessage.error(t('EditNewsPage.SaveNewsFailed')))
  }
}

function beforeUploadCoverImage(file) {
  const isJPG = file.type == 'image/jpeg'
  const isLt5M = file.size / 1024 / 1024 < 5
  if (!isJPG) {
    ElMessage.error(t('PublishNewsPage.UploadedCoverImageFormat'))
    uploadCorrectly.value = false
    return false
  }
  if (!isLt5M) {
    ElMessage.error(t('PublishNewsPage.UploadedCoverImageSize'))
    uploadCorrectly.value = false
    return false
  }
  uploadCorrectly.value = true
  return true
}

function handleCoverImageChange(file) {
  const fileReader = new FileReader()
  fileReader.readAsDataURL(file.raw)
  fileReader.onload = (e) => {
    if (typeof e.target.result == 'string') {
      coverImageDataUrl.value = e.target.result
    }
  }
}

function beforeUploadContentImage(file) {
  const isJPG = file.type == 'image/jpeg'
  const isLt5M = file.size / 1024 / 1024 < 5
  if (!isJPG) {
    ElMessage.error(t('PublishNewsPage.UploadedContentImageFormat'))
    return false
  }
  if (!isLt5M) {
    ElMessage.error(t('PublishNewsPage.UploadedContentImageSize'))
    return false
  }
  return true
}

const handleBeforeUploadImage = async (file: File) => {
  if (!beforeUploadContentImage(file)) {
    return
  }
  const formData = new FormData()
  formData.append('file', file, 'contentImage.jpg')
  try {
    const response = await axiosInstance.post('upload-news-content-image', formData)
    contentImagesList.value.push({
      name: response.data.fileName.slice(18),
      url: `${ossBaseUrl}${response.data.fileName}`
    })
    ElMessage.success(t('PublishNewsPage.UploadContentImageSucceed'))
  } catch (error) {
    ElMessage.error(t('PublishNewsPage.UploadContentImageFailed'))
  }
}

const handlePreviewImage = (file: any) => {
  if (!file.url) {
    ElMessage.warning(t('PublishNewsPage.UploadingNewsContentImage'))
    return
  }
  navigator.clipboard.writeText(file.url)
      .then(() => ElMessage.success(t('PublishNewsPage.CopyContentImageUrlSucceeded')))
      .catch(() => ElMessage.error(t('PublishNewsPage.CopyContentImageUrlFailed')))
}

const handleBeforeRemoveImage = async () => {
  ElMessage.warning(t('PublishNewsPage.DeleteImagePrompt'))
  return false
}

function beforeUploadContentVideo(file) {
  const isMP4 = file.type == 'video/mp4'
  const isLt100M = file.size / 1024 / 1024 < 100
  if (!isMP4) {
    ElMessage.error(t('PublishNewsPage.UploadedContentVideoFormat'))
    return false
  }
  if (!isLt100M) {
    ElMessage.error(t('PublishNewsPage.UploadedContentVideoSize'))
    return false
  }
  return true
}

const handleBeforeUploadVideo = async (file: File) => {
  if (!beforeUploadContentVideo(file)) {
    return
  }
  const formData = new FormData()
  formData.append('file', file, 'contentVideo.mp4')
  try {
    const response = await axiosInstance.post('upload-news-content-video', formData)
    contentVideosList.value.push({
      name: response.data.fileName.slice(18),
      url: `${ossBaseUrl}${response.data.fileName}`
    })
    ElMessage.success(t('PublishNewsPage.UploadContentVideoSucceed'))
  } catch (error) {
    ElMessage.error(t('PublishNewsPage.UploadContentVideoFailed'))
  }
}

const handlePreviewVideo = (file: any) => {
  if (!file.url) {
    ElMessage.warning(t('PublishNewsPage.UploadingNewsContentVideo'))
    return
  }
  navigator.clipboard.writeText(file.url)
      .then(() => ElMessage.success(t('PublishNewsPage.CopyContentVideoUrlSucceeded')))
      .catch(() => ElMessage.error(t('PublishNewsPage.CopyContentVideoUrlFailed')))
}

const handleBeforeRemoveVideo = async () => {
  ElMessage.warning(t('PublishNewsPage.DeleteVideoPrompt'))
  return false
}

const fetchNewsData = async () => {
  try {
    const response = await axiosInstance.get(`news/${newsId.value}`)
    if (response.status == 404) {
      await router.push('/404')
    } else {
      duplicateNews.value = response.data
      newsRuleForm.newsTitle = response.data.title
      newsRuleForm.newsSummary = response.data.summary
      newsRuleForm.newsTagId = response.data.tagId
      newsRuleForm.isSticky = response.data.isSticky == 1
      newsRuleForm.newsContent = response.data.content
      editorRef.value.setHtml(response.data.content)
    }
  } catch (error) {
    if (error.response.status == 404) {
      await router.push('/404')
    } else {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
}

onMounted(() => {
  fetchNewsData()
})

watch(() => route.params.id, (newId) => {
  newsId.value = parseInt(<string>newId)
  fetchNewsData()
})
</script>

<style scoped>
.page-container {
  width: 1200px;
  align-self: center;
  display: flex;
  flex-direction: column;
  padding: 20px;
  box-sizing: border-box;
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
</style>
