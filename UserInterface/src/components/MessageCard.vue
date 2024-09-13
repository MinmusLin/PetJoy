<!--
  Project Name:  UserInterface
  File Name:     MessageCard.vue
  File Function: 留言卡片组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='message-card'>
    <div class='avatar'>
      <el-avatar :src='userAvatarUrl' style='cursor: pointer' @click='router.push(`/profile/${props.commenterId}`)'>
        <el-icon :size='24'>
          <Avatar/>
        </el-icon>
      </el-avatar>
    </div>
    <div class='message-content'>
      <div class='header'>
        <span class='name'>{{ userName }}</span>
        <span class='time'>{{ formatDateTimeToCST(props.commentTime).dateTime }}</span>
      </div>
      <div class='content'>
        <div class='message'>{{ props.message }}</div>
        <el-button type='danger' link size='small' style='margin-left: 8px' @click='handleDelete'>
          {{ t('NewsManagementPage.Delete') }}
        </el-button>
      </div>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {defineProps, onMounted, ref} from 'vue'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import {useI18n} from 'vue-i18n'
import {Avatar} from '@element-plus/icons-vue'
import {useRouter} from 'vue-router'

const router = useRouter()
const {t} = useI18n()
const userAvatarUrl = ref('')
const userName = ref('')
const props = defineProps({
  messageId: Number,
  commenterId: Number,
  message: String,
  commentTime: String
})

onMounted(async () => {
  try {
    const avatarResponse = await axiosInstance.get(`user/avatar-url/${props.commenterId}`)
    userAvatarUrl.value = `${ossBaseUrl}${avatarResponse.data}`
    const nameResponse = await axiosInstance.get(`user/user-name/${props.commenterId}`)
    userName.value = nameResponse.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

async function handleDelete() {
  try {
    await axiosInstance.delete(`user-message/${props.messageId}`)
  } catch (error) {
    ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
  } finally {
    window.location.reload()
  }
}
</script>

<style scoped>
:global(:root) {
  --message-card-divider-color: #0000000C;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --message-card-divider-color: #FFFFFF33;
}

.message-card {
  border-top: 1px solid var(--message-card-divider-color);
  display: flex;
  align-items: flex-start;
  padding: 10px;
}

.avatar {
  margin-right: 15px;
}

.message-content {
  flex-grow: 1;
}

.header {
  display: flex;
  justify-content: space-between;
}

.content {
  display: flex;
  justify-content: space-between;
  margin-right: -2px;
}

.name {
  font-size: 14px;
  font-weight: bold;
}

.time {
  font-size: 12px;
}

.message {
  font-size: 13px;
  margin-top: 4px;
  line-height: 1.4;
  text-align: justify;
}
</style>
