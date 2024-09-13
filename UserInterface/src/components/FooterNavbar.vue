<!--
  Project Name:  UserInterface
  File Name:     FooterNavbar.vue
  File Function: 底部导航栏组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-14
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <el-container class='footer-navbar'>
    <a href='https://sse.tongji.edu.cn' target='_blank'>
      <img :src='`${ossBaseUrl}LogosAndIcons/TongjiSSELogo.png`'
           class='footer-sse-logo-left'
           alt='TongjiSSELogo'
           height='40px'/>
    </a>

    <a href='https://github.com/MinmusLin/PetJoy' target='_blank'>
      <el-tooltip :content="t('FooterNavbar.GitHubRepository')" placement='top'>
        <img :src='`${ossBaseUrl}LogosAndIcons/GitHubLogo.png`'
             class='footer-github-logo-right'
             alt='GitHubLogo'
             height='40px'/>
      </el-tooltip>
    </a>

    <div class='footer-content'>
      <p>{{ t('FooterNavbar.ProjectDescription') }}</p>
      <p v-html="t('FooterNavbar.CopyrightStatement')"/>
      <p>
        <el-link :underline='false' class='footer-link' @click="router.push('/about-petjoy')">
          {{ t('FooterNavbar.AboutPetJoy') }}
        </el-link>
        |
        <el-link :underline='false' class='footer-link' @click='showPrivacyPolicy=true'>
          {{ t('FooterNavbar.PrivacyPolicy') }}
        </el-link>
        |
        <el-link :underline='false' class='footer-link' @click='showDisclaimer=true'>
          {{ t('FooterNavbar.Disclaimer') }}
        </el-link>
        |
        <el-link :underline='false' class='footer-link' @click='showCodeOfConduct=true'>
          {{ t('FooterNavbar.CodeOfConduct') }}
        </el-link>
        |
        <el-link :underline='false' class='footer-link' @click='showContactUs=true'>
          {{ t('FooterNavbar.ContactUs') }}
        </el-link>
        |
        <el-link :underline='false' class='footer-link' @click='showFeedback=true'>
          {{ t('FooterNavbar.Feedback') }}
        </el-link>
      </p>
    </div>
  </el-container>

  <el-dialog v-model='showPrivacyPolicy' width='1000px' style='height: 640px' :show-close='false' align-center>
    <template #title>
      <div class='dialog-title'>{{ t('FooterNavbar.PrivacyPolicy') }}</div>
    </template>
    <el-scrollbar height='526px'>
      <PrivacyPolicy/>
    </el-scrollbar>
    <div class='button-container'>
      <el-button type='primary' plain @click='showPrivacyPolicy = false'>{{
          t('FooterNavbar.IAlreadyKnow')
        }}
      </el-button>
    </div>
  </el-dialog>

  <el-dialog v-model='showDisclaimer' width='1000px' style='height: 640px' :show-close='false' align-center>
    <template #title>
      <div class='dialog-title'>{{ t('FooterNavbar.Disclaimer') }}</div>
    </template>
    <el-scrollbar height='526px'>
      <Disclaimer/>
    </el-scrollbar>
    <div class='button-container'>
      <el-button type='primary' plain @click='showDisclaimer = false'>{{ t('FooterNavbar.IAlreadyKnow') }}</el-button>
    </div>
  </el-dialog>

  <el-dialog v-model='showCodeOfConduct' width='1000px' style='height: 640px' :show-close='false' align-center>
    <template #title>
      <div class='dialog-title'>{{ t('FooterNavbar.CodeOfConduct') }}</div>
    </template>
    <el-scrollbar height='526px'>
      <CodeOfConduct/>
    </el-scrollbar>
    <div class='button-container'>
      <el-button type='primary' plain @click='showCodeOfConduct = false'>{{
          t('FooterNavbar.IAlreadyKnow')
        }}
      </el-button>
    </div>
  </el-dialog>

  <el-dialog v-model='showContactUs' width='560px' :show-close='false' align-center>
    <template #title>
      <div v-html="t('FooterNavbar.PetJoyDevelopmentTeamContactDetails')" class='dialog-title'/>
    </template>
    <div class='teams-table'>
      <el-table :data='developmentTeam' stripe style='width: 520px' :empty-text="t('FooterNavbar.NoData')">
        <el-table-column prop='name' :label="t('FooterNavbar.Member')" align='center' width='120px'/>
        <el-table-column prop='email' :label="t('FooterNavbar.Email')" align='center' width='240px'>
          <template v-slot:default='{ row }'>
            <!--suppress TypeScriptUnresolvedReference -->
            <el-link :underline='false' :href='"mailto:"+row.email' target='_blank'>{{ row.email }}</el-link>
          </template>
        </el-table-column>
        <el-table-column :label="t('FooterNavbar.GitHubProfile')" align='center' width='160px'>
          <template v-slot:default='{ row }'>
            <!--suppress TypeScriptUnresolvedReference -->
            <el-link :underline='false' :href='row.githubProfile' target='_blank'>{{ row.githubName }}</el-link>
          </template>
        </el-table-column>
      </el-table>
    </div>
  </el-dialog>

  <el-dialog v-model='showFeedback'
             width='1000px'
             style='height: auto'
             :show-close='false'
             :close-on-click-modal='false'
             :close-on-press-escape='false'
             align-center>
    <template #title>
      <div class='dialog-title'>{{ t('FooterNavbar.Feedback') }}</div>
    </template>

    <el-form ref='feedbackRuleFormRef' :model='feedbackRuleForm' :rules='feedbackRules'>
      <p style='text-align: justify' v-html="t('FooterNavbar.FeedbackPrompt1')"/>
      <p style='text-align: justify'>{{ t('FooterNavbar.FeedbackPrompt2') }}</p>

      <el-form-item prop='feedbackCategory'>
        <el-radio-group v-model='feedbackRuleForm.feedbackCategory'>
          <el-radio value='FeatureSuggestion'>{{ t('FooterNavbar.FeatureSuggestion') }}</el-radio>
          <el-radio value='TechnicalIssue'>{{ t('FooterNavbar.TechnicalIssue') }}</el-radio>
          <el-radio value='UserExperience'>{{ t('FooterNavbar.UserExperience') }}</el-radio>
          <el-radio value='ContentError'>{{ t('FooterNavbar.ContentError') }}</el-radio>
          <el-radio value='BusinessCooperation'>{{ t('FooterNavbar.BusinessCooperation') }}</el-radio>
          <el-radio value='Other'>{{ t('FooterNavbar.Other') }}</el-radio>
        </el-radio-group>
      </el-form-item>

      <el-form-item prop='feedbackContent'>
        <el-input v-model='feedbackRuleForm.feedbackContent'
                  maxlength='512'
                  rows=10
                  style='width: 100%'
                  :placeholder="t('FooterNavbar.FeedbackPrompt3')"
                  type='textarea'
                  resize='none'
                  show-word-limit/>
      </el-form-item>

      <p style='text-align: justify'>{{ t('FooterNavbar.FeedbackPrompt4') }}</p>

      <el-form-item prop='feedbackTelephone'>
        <!--suppress TypeScriptValidateTypes-->
        <el-input v-model='feedbackRuleForm.feedbackTelephone'
                  style='width: 100%'
                  size='large'
                  :placeholder="t('FooterNavbar.TelephoneInputPrompt')"
                  :prefix-icon='Phone'
                  clearable/>
      </el-form-item>

      <el-form-item prop='feedbackEmail'>
        <!--suppress TypeScriptValidateTypes-->
        <el-input v-model='feedbackRuleForm.feedbackEmail'
                  style='width: 100%'
                  size='large'
                  :placeholder="t('FooterNavbar.EmailInputPrompt')"
                  :prefix-icon='Message'
                  clearable/>
      </el-form-item>

      <el-button-group style='display: flex; justify-content: center'>
        <el-button @click='cancelFeedback'>{{ t('FooterNavbar.Cancel') }}</el-button>
        <el-button @click='submitFeedback(feedbackRuleFormRef)' type='primary'>
          {{ t('FooterNavbar.Submit') }}
        </el-button>
      </el-button-group>
    </el-form>
  </el-dialog>
</template>

<script setup lang='ts'>
import {ElMessage, ElMessageBox, ElNotification, FormInstance, FormRules} from 'element-plus'
import {onMounted, ref, reactive} from 'vue'
import {useRouter} from 'vue-router'
import {useI18n} from 'vue-i18n'
import axiosInstance from '../utils/axios'
import PrivacyPolicy from './PrivacyPolicy.vue'
import Disclaimer from './Disclaimer.vue'
import CodeOfConduct from './CodeOfConduct.vue'
import {Message, Phone} from '@element-plus/icons-vue'
import {ossBaseUrl} from '../globals'

const {t} = useI18n()
const router = useRouter()
const showPrivacyPolicy = ref(false)
const showDisclaimer = ref(false)
const showCodeOfConduct = ref(false)
const showContactUs = ref(false)
const showFeedback = ref(false)
const developmentTeam = ref([])
const feedbackRuleFormRef = ref<FormInstance>()

interface FeedbackRuleForm {
  feedbackCategory: string
  feedbackContent: string
  feedbackTelephone: string
  feedbackEmail: string
}

const feedbackRuleForm = reactive<FeedbackRuleForm>({
  feedbackCategory: '',
  feedbackContent: '',
  feedbackTelephone: '',
  feedbackEmail: ''
})

const feedbackRules: FormRules = {
  feedbackCategory: [
    {
      required: true,
      message: t('FooterNavbar.RequiredFeedbackCategory'),
      trigger: 'change'
    }
  ],
  feedbackContent: [
    {
      required: true,
      message: t('FooterNavbar.RequiredFeedbackContent'),
      trigger: 'change'
    }
  ],
  feedbackTelephone: [
    {
      required: false,
      trigger: 'blur',
      validator: (rule, value, callback) => {
        const phoneRegex = /^\d{11}$/
        if (value && !phoneRegex.test(value)) {
          callback(new Error(t('FooterNavbar.InvalidTelephone')))
        } else {
          callback()
        }
      }
    }
  ],
  feedbackEmail: [
    {
      required: false,
      trigger: 'blur',
      validator: (rule, value, callback) => {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
        if (value && !emailRegex.test(value)) {
          callback(new Error(t('FooterNavbar.InvalidEmail')))
        } else {
          callback()
        }
      }
    }
  ]
}

const cancelFeedback = () => {
  ElMessageBox.confirm(
      t('FooterNavbar.CancelFeedbackPrompt'),
      t('FooterNavbar.CancelFeedback'),
      {
        showClose: false,
        closeOnClickModal: false,
        closeOnPressEscape: false,
        confirmButtonText: t('FooterNavbar.ContinueFeedback'),
        cancelButtonText: t('FooterNavbar.CancelFeedback')
      }
  ).catch(() => {
    showFeedback.value = false
    resetFeedback(feedbackRuleFormRef.value)
  })
}

const resetFeedback = (formEl: FormInstance | undefined) => {
  if (!formEl) {
    return
  }
  formEl.resetFields()
}

const submitFeedback = async (formEl: FormInstance | undefined) => {
  if (!formEl) {
    return
  }
  await formEl.validate(async (valid) => {
    if (valid) {
      const result = await postUserFeedback()
      if (result) {
        ElNotification({
          title: t('FooterNavbar.FeedbackSubmittedSuccessfully'),
          message: t('FooterNavbar.FeedbackSubmittedSuccessfullyPrompt'),
          type: 'success'
        })
        showFeedback.value = false
        resetFeedback(feedbackRuleFormRef.value)
      } else {
        ElNotification({
          title: t('FooterNavbar.FeedbackSubmissionFailed'),
          message: t('FooterNavbar.FeedbackSubmissionFailedPrompt'),
          type: 'error'
        })
      }
    }
  })
}

async function postUserFeedback() {
  const userFeedback = {
    feedbackCategory: feedbackRuleForm.feedbackCategory,
    feedbackContent: feedbackRuleForm.feedbackContent,
    feedbackTime: new Date().toISOString(),
    email: feedbackRuleForm.feedbackEmail,
    telephone: feedbackRuleForm.feedbackTelephone
  }
  try {
    const response = await axiosInstance.post('user-feedback', userFeedback)
    return response.status == 201
  } catch (error) {
    return false
  }
}

onMounted(async () => {
  try {
    const response = await axiosInstance.get('development-team')
    developmentTeam.value = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})
</script>

<style scoped>
:global(:root) {
  --footer-bg-color: #F0F2F5;
  --footer-border-color: #DCDFE6;
  --footer-text-color: #909399;
  --footer-link-color: #909399;
  --footer-link-hover-color: #409EFF;
  --footer-sse-logo-filter: invert(50%) sepia(100%) saturate(500%) hue-rotate(180deg) brightness(80%);
  --footer-github-logo-filter: invert(0%);
  --footer-element-plus-logo-color: #24292F;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --footer-bg-color: #303030;
  --footer-border-color: #4C4D4F;
  --footer-text-color: #A3A6AD;
  --footer-link-color: #A3A6AD;
  --footer-link-hover-color: #66BFFF;
  --footer-sse-logo-filter: brightness(90%);
  --footer-github-logo-filter: invert(100%);
  --footer-element-plus-logo-color: #DBD6D0;
}

.footer-content {
  color: var(--footer-text-color);
  font-size: 12px;
  line-height: 0.5;
  text-align: center;
}

.footer-navbar {
  position: relative;
  width: 100%;
  height: 70px;
  background-color: var(--footer-bg-color);
  border-top: 1px solid var(--footer-border-color);
  justify-content: center;
}

.footer-link {
  color: var(--footer-link-color);
  font-size: 12px;
  line-height: 0.5;
}

.footer-link:hover {
  color: var(--footer-link-hover-color);
}

.dialog-title {
  width: 100%;
  text-align: center;
  font-size: 20px;
}

.button-container {
  display: flex;
  justify-content: flex-end;
  padding-top: 8px;
}

.footer-sse-logo-left {
  position: absolute;
  left: 15px;
  bottom: 15px;
  filter: var(--footer-sse-logo-filter);
}

.footer-github-logo-right {
  position: absolute;
  right: 15px;
  bottom: 15px;
  filter: var(--footer-github-logo-filter);
}
</style>
