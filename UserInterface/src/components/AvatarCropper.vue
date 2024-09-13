<!--
  Project Name:  UserInterface
  File Name:     AvatarCropper.vue
  File Function: 头像裁剪上传组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-31
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div style='height: 500px; width: 500px'>
    <VueCropper ref='cropper'
                :img="uploadCorrectly ? avatarImageDataUrl : ''"
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

  <div class='button-container'>
    <el-upload :on-change='handleAvatarChange'
               :before-upload='beforeUpload'
               :show-file-list='false'
               accept='.jpeg, .jpg'>
      <!--suppress TypeScriptValidateTypes-->
      <el-button size='large' :icon='Upload'>{{ t('AvatarCropper.UploadAvatar') }}</el-button>
    </el-upload>

    <!--suppress TypeScriptValidateTypes-->
    <el-button size='large' :icon='Select' @click='saveAvatar'>{{ t('AvatarCropper.SaveAvatar') }}</el-button>
  </div>
</template>

<script setup lang='ts'>
import {ref, defineProps} from 'vue'
import {Upload, Select} from '@element-plus/icons-vue'
import {ElMessage} from 'element-plus'
import {VueCropper} from 'vue-cropper'
import {useI18n} from 'vue-i18n'
import axiosInstance from '../utils/axios'
import {dataUrlToBlob} from '../globals'
import 'vue-cropper/dist/index.css'

const props = defineProps<{ currentUserId: number }>()
const {t} = useI18n()
const avatarImageDataUrl = ref('')
const uploadCorrectly = ref(false)
const cropper = ref<InstanceType<typeof VueCropper>>()
const option = ref({
  outputType: 'jpeg',
  canScale: false,
  autoCrop: true,
  autoCropWidth: 500,
  autoCropHeight: 500,
  fixed: true,
  fixedNumber: [1, 1],
  canMove: false,
  centerBox: true,
  mode: 'contain',
  fillColor: 'white'
})

function saveAvatar() {
  if (cropper.value && uploadCorrectly.value) {
    cropper.value.getCropData((data) => {
      const blobData = dataUrlToBlob(data)
      const formData = new FormData()
      formData.append('file', blobData, 'avatar.jpg')
      axiosInstance.post('upload-avatar', formData).then((response) => {
        if (response.status == 200) {
          axiosInstance.put(`user/avatar-url/${props.currentUserId}`, {avatarUrl: response.data.fileName}).then((updateResponse) => {
            if (updateResponse.status == 200) {
              window.location.reload()
            } else {
              ElMessage.error(t('AvatarCropper.SaveFailed'))
            }
          }).catch(() => ElMessage.error(t('AvatarCropper.SaveFailed')))
        } else {
          ElMessage.error(t('AvatarCropper.SaveFailed'))
        }
      }).catch(() => ElMessage.error(t('AvatarCropper.SaveFailed')))
    })
  } else {
    ElMessage.error(t('AvatarCropper.UploadAvatarPrompt'))
  }
}

function beforeUpload(file) {
  const isJPG = file.type == 'image/jpeg'
  const isLt2M = file.size / 1024 / 1024 < 2
  if (!isJPG) {
    ElMessage.error(t('AvatarCropper.UploadedAvatarFormat'))
    uploadCorrectly.value = false
    return false
  }
  if (!isLt2M) {
    ElMessage.error(t('AvatarCropper.UploadedAvatarSize'))
    uploadCorrectly.value = false
    return false
  }
  uploadCorrectly.value = true
  return true
}

function handleAvatarChange(file) {
  const fileReader = new FileReader()
  fileReader.readAsDataURL(file.raw)
  fileReader.onload = (e) => {
    if (typeof e.target.result == 'string') {
      avatarImageDataUrl.value = e.target.result
    }
  }
}
</script>

<style scoped>
.button-container {
  padding-top: 16px;
  display: flex;
  justify-content: center;
  gap: 32px;
}
</style>
