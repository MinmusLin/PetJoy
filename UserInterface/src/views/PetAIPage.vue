<!--
  Project Name:  UserInterface
  File Name:     PetAIPage.vue
  File Function: 宠物 AI 页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-02
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <MultiWaveBackground class='multi-wave-background'/>

  <div class='chat-container'>
    <div class='messages-container'>
      <template v-if='messages.length==0'>
        <div class='welcome-container'>
          <img :src='`${ossBaseUrl}LogosAndIcons/PetJoyLogo.png`'
               alt='PetJoyLogo'
               style='width: 450px; margin-top: 10px'/>
          <div style='display: flex; justify-content: space-between; width: 100%; margin-top: 80px'>
            <el-button size='large'
                       @click="sendExampleQuestion(t(`PetAIPage.Question1_${randomQuestion1}`))"
                       class='example-question-btn'
                       plain
                       round>
              <div>
                <img :src='`${ossBaseUrl}LogosAndIcons/Idea.png`' width='30' alt='Idea' style=''>
                <p style='margin-top: 0'>{{ t(`PetAIPage.Question1_${randomQuestion1}`) }}</p>
              </div>
            </el-button>
            <el-button size='large'
                       @click="sendExampleQuestion(t(`PetAIPage.Question2_${randomQuestion2}`))"
                       class='example-question-btn'
                       plain
                       round>
              <div>
                <img :src='`${ossBaseUrl}LogosAndIcons/Medicine.png`' width='30' alt='Idea'>
                <p style='margin-top: 0'>{{ t(`PetAIPage.Question2_${randomQuestion2}`) }}</p>
              </div>
            </el-button>
            <el-button size='large'
                       @click="sendExampleQuestion(t(`PetAIPage.Question3_${randomQuestion3}`))"
                       class='example-question-btn'
                       plain
                       round>
              <div>
                <img :src='`${ossBaseUrl}LogosAndIcons/Teach.png`' width='30' alt='Idea'>
                <p style='margin-top: 0'>{{ t(`PetAIPage.Question3_${randomQuestion3}`) }}</p>
              </div>
            </el-button>
            <el-button size='large'
                       @click="sendExampleQuestion(t(`PetAIPage.Question4_${randomQuestion4}`))"
                       class='example-question-btn'
                       plain
                       round>
              <div>
                <img :src='`${ossBaseUrl}LogosAndIcons/Food.png`' width='30' alt='Idea'>
                <p style='margin-top: 0'>{{ t(`PetAIPage.Question4_${randomQuestion4}`) }}</p>
              </div>
            </el-button>
          </div>
          <div class='warning-message'>
            {{ t('PetAIPage.Caution') }}
          </div>
        </div>
      </template>

      <template v-else>
        <transition-group name='slide-fade' tag='div'>
          <div v-for='message in messages' :key='message.content'>
            <div v-if="message.role=='user'" class='user-message-container'>
              <el-avatar class='user-avatar' :src='`${ossBaseUrl}${currentUserAvatarUrl}`'>
                <el-icon :size='24'>
                  <Avatar/>
                </el-icon>
              </el-avatar>
              <div class='user-message'>{{ message.content }}</div>
            </div>

            <div v-else class='assistant-message-container'>
              <img :src='`${ossBaseUrl}LogosAndIcons/PetAIAvatar.png`'
                   alt='PetAIAvatar'
                   class='assistant-avatar'/>
              <div class='assistant-message'>
                <span v-if="message.content == t('PetAIPage.AnswerLoading')" class='loading-icon'/>
                <div v-html='renderMarkdown(message.content)' class='message-content'/>
              </div>
            </div>
          </div>
        </transition-group>
      </template>
    </div>

    <div class='input-container'>
      <el-input v-model='userInput'
                class='input-box'
                :placeholder="t('PetAIPage.InputPrompt')"
                show-word-limit
                size='large'
                :maxlength='128'
                @keydown.enter='handleEnter'/>
      <el-button @click='handleSendMessage' size='large' type='primary' style='width: 120px' round>
        <el-icon :size='20'>
          <Upload style='font-weight: bold'/>
        </el-icon>
      </el-button>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {onMounted, ref} from 'vue'
import {useI18n} from 'vue-i18n'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import {ossBaseUrl} from '../globals'
import {Avatar, Upload} from '@element-plus/icons-vue'
import {marked} from 'marked'
import MultiWaveBackground from '../components/MultiWaveBackground.vue'

const {t} = useI18n()
const userInput = ref('')
const messages = ref([])
const currentUserAvatarUrl = ref('')
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const randomQuestion1 = ref(Math.floor(Math.random() * 10) + 1)
const randomQuestion2 = ref(Math.floor(Math.random() * 10) + 1)
const randomQuestion3 = ref(Math.floor(Math.random() * 10) + 1)
const randomQuestion4 = ref(Math.floor(Math.random() * 10) + 1)

onMounted(async () => {
  if (currentUserId.value != 0) {
    try {
      const response = await axiosInstance.get(`user/${currentUserId.value}`)
      currentUserAvatarUrl.value = response.data.avatarUrl
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
})

function handleSendMessage() {
  if (userInput.value.trim() != '') {
    messages.value.push({'role': 'user', 'content': userInput.value})
    postMessage()
    userInput.value = ''
  }
}

function handleEnter() {
  if (userInput.value.trim() != '') {
    handleSendMessage();
  }
}

async function postMessage() {
  try {
    const messagesCopy = [{'role': 'assistant', 'content': t('PetAIPage.AIPrompt')}, ...messages.value]
    messages.value.push({'role': 'assistant', 'content': t('PetAIPage.AnswerLoading')})
    const response = await axiosInstance.post('zhipu-ai-pet-assistant', messagesCopy)
    messages.value.pop()
    messages.value.push({'role': 'assistant', 'content': response.data.choices[0].message.content})
  } catch (error) {
    ElMessage.error(t('ErrorMessage.PostErrorMessage'))
  }
}

function renderMarkdown(content: string) {
  return marked(content)
}

function sendExampleQuestion(question: string) {
  userInput.value = question
  messages.value.push({'role': 'user', 'content': userInput.value})
  postMessage()
  userInput.value = ''
}
</script>

<style scoped>
:global(:root) {
  --ai-background-color: #FFFFFF;
  --ai-messages-background-color: #FAFAFA;
  --ai-user-message-bg: #D4EDDA;
  --ai-assistant-message-bg: #E6F7FF;
  --ai-user-message-color: #155724;
  --ai-assistant-message-color: #1890FF;
  --ai-loading-border: #00000019;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --ai-background-color: #121212;
  --ai-messages-background-color: #1D1D1D;
  --ai-user-message-bg: #5F6F65;
  --ai-assistant-message-bg: #27374D;
  --ai-user-message-color: #D4EDDA;
  --ai-assistant-message-color: #DDE6ED;
  --ai-loading-border: #8C8C8C;
}

.chat-container {
  display: flex;
  flex-direction: column;
  width: 850px;
  margin: 0 auto;
  height: calc(100vh - 135px);
  background-color: var(--ai-background-color);
  position: relative;
  z-index: 1;
}

.messages-container {
  flex: 1;
  overflow-y: auto;
  padding: 20px 20px 0;
  background-color: var(--ai-messages-background-color);
  position: relative;
}

.user-message {
  background-color: var(--ai-user-message-bg);
  color: var(--ai-user-message-color);
  padding: 10px;
  border-radius: 10px;
  margin-bottom: 15px;
  max-width: 600px;
  word-wrap: break-word;
  font-size: 16px;
  line-height: 1.5;
  align-self: flex-end;
  display: inline-block;
  text-align: justify;
}

.assistant-message {
  background-color: var(--ai-assistant-message-bg);
  color: var(--ai-assistant-message-color);
  border-radius: 10px;
  max-width: 600px;
  word-wrap: break-word;
  font-size: 16px;
  line-height: 1.5;
  align-self: flex-start;
  display: inline-block;
  padding: 0 15px 0 15px;
  margin-bottom: 15px;
  position: relative;
  text-align: justify;
  overflow-x: auto;
}

.assistant-message::before {
  content: '';
  display: block;
  height: 5px;
  margin-top: -10px;
}

.input-container {
  display: flex;
  justify-content: center;
  padding: 10px;
  background-color: var(--ai-messages-background-color);
}

.input-box {
  flex: 1;
  margin-right: 10px;
}

.user-message-container {
  display: flex;
  flex-direction: row-reverse;
  align-items: flex-start;
}

.user-avatar {
  width: 40px;
  height: 40px;
  border-radius: 50%;
  margin-left: 10px;
  vertical-align: top;
}

.assistant-message-container {
  display: flex;
  flex-direction: row;
  align-items: flex-start;
}

.assistant-avatar {
  width: 40px;
  height: 40px;
  border-radius: 50%;
  margin-right: 10px;
  vertical-align: top;
}

.welcome-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100%;
}

.example-question-btn {
  flex: 1;
  align-items: flex-start;
  white-space: normal;
  text-align: justify;
  line-height: 1.7;
  height: 200px;
}

.multi-wave-background {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: -1;
}

.warning-message {
  position: absolute;
  top: calc(100% - 18px);
  left: 50%;
  white-space: nowrap;
  transform: translateX(-50%);
  font-size: 13px;
  color: #999999;
}

.loading-icon {
  width: 13px;
  height: 13px;
  border: 4px solid var(--ai-loading-border);
  border-left-color: var(--ai-assistant-message-color);
  border-radius: 50%;
  display: inline-block;
  animation: spin 1s linear infinite;
  margin-right: 10px;
  vertical-align: middle;
}

.message-content {
  display: inline-block;
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}

/* noinspection CssUnusedSymbol */
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.3s;
}

/* noinspection CssUnusedSymbol */
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}

/* noinspection CssUnusedSymbol */
.slide-fade-enter-active, .slide-fade-leave-active {
  transition: all 0.5s ease;
}

/* noinspection CssUnusedSymbol */
.slide-fade-enter-from, .slide-fade-leave-to {
  transform: translateY(30px);
  opacity: 0;
}

/* noinspection CssUnusedSymbol */
.slide-fade-enter-to, .slide-fade-leave-from {
  transform: translateY(0);
  opacity: 1;
}
</style>
