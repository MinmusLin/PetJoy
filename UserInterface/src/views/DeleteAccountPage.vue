<!--
  Project Name:  UserInterface
  File Name:     DeleteAccountPage.vue
  File Function: 注销账号页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-30
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='container'>
    <div class='left'>
      <div style='width: 550px'>
        <!--suppress TypeScriptValidateTypes-->
        <el-breadcrumb :separator-icon='ArrowRight' class='breadcrumb-with-margin'>
          <el-breadcrumb-item to='/settings'>{{ t('HeaderNavbar.Settings') }}</el-breadcrumb-item>
          <el-breadcrumb-item>{{ t('SettingsPage.DeleteAccount') }}</el-breadcrumb-item>
        </el-breadcrumb>
      </div>

      <h1>{{ t('SettingsPage.DeleteAccount') }}</h1>

      <el-card style='width: 550px; margin-top: 16px; margin-bottom: 30px' shadow='always'>
        <el-form ref='resetPasswordRuleFormRef'
                 style='max-width: 100%'
                 :model='resetPasswordRuleForm'
                 :rules='resetPasswordRules'>
          <el-form-item prop='telephone'>
            <!--suppress TypeScriptValidateTypes-->
            <el-input size='large'
                      :placeholder="t('RegisterPage.InputTelephonePrompt')"
                      v-model='resetPasswordRuleForm.telephone'
                      :prefix-icon='Phone'
                      clearable>
              <template #prepend>{{ t('LoginPage.TelephonePrepend') }}</template>
            </el-input>
          </el-form-item>
          <el-form-item prop='resetVerificationCode' style='padding-bottom: 4px'>
            <!--suppress TypeScriptValidateTypes-->
            <el-input size='large'
                      :prefix-icon='CircleCheck'
                      :placeholder="t('RegisterPage.InputRegistrationVerificationCodePrompt')"
                      v-model='resetPasswordRuleForm.resetVerificationCode'
                      clearable>
              <template #append>
                <el-button size='large'
                           type='info'
                           style='width: 200px'
                           @click='sendResetVerificationCode'
                           :disabled='countdown>0'
                           plain>{{ buttonLabel }}
                </el-button>
              </template>
            </el-input>
          </el-form-item>
          <el-alert type='warning' show-icon :closable='false' style='padding-right: 30px'>
            <p style='line-height: 1.2; margin-bottom: 12px; text-align: justify'>{{ t('DeleteAccountPage.WarningPrompt1') }}</p>
            <p style='line-height: 1.2; margin-top: 12px; margin-bottom: 12px; text-align: justify'>
              {{ '1. ' + t('DeleteAccountPage.WarningPrompt2') }}</p>
            <p style='line-height: 1.2; margin-top: 12px; margin-bottom: 12px; text-align: justify'>
              {{ '2. ' + t('DeleteAccountPage.WarningPrompt3') }}</p>
            <p style='line-height: 1.2; margin-top: 12px; margin-bottom: 12px; text-align: justify'>
              {{ '3. ' + t('DeleteAccountPage.WarningPrompt4') }}</p>
            <p style='line-height: 1.2; margin-top: 12px; text-align: justify'>{{ t('DeleteAccountPage.WarningPrompt5') }}</p>
          </el-alert>
          <el-form-item prop='confirm'>
            <label>
              <input type='checkbox' v-model='resetPasswordRuleForm.confirm'>
              {{ t('DeleteAccountPage.ConfirmPrompt') }}
            </label>
          </el-form-item>
          <el-button type='danger'
                     size='large'
                     @click='submitResetPassword(resetPasswordRuleFormRef)'
                     style='width: 100%'>{{ t('SettingsPage.DeleteAccount') }}
          </el-button>
        </el-form>
      </el-card>
    </div>

    <div v-if='windowWidth>=1200' class='right'>
      <div class='carousel-container'>
        <el-carousel trigger='click' :interval='3000' motion-blur height='calc(50vw * 9 / 16)'>
          <el-carousel-item v-for='(img, index) in carouselImages' :key='index'>
            <img :src='img' alt='CarouselImages' class='carousel-image'>
          </el-carousel-item>
        </el-carousel>
      </div>
    </div>
  </div>

  <Vcode :show='isShowVCode'
         @success='isShowVCode=false'
         @fail='isShowVCode=true'
         @close='isShowVCode=true'
         :successText="t('RegisterPage.VerificationSuccessful')"
         :failText="t('RegisterPage.VerificationFailed')"
         :sliderText="t('RegisterPage.DragTheSliderToVerify')"/>
</template>

<script setup lang='ts'>
import {useRouter} from 'vue-router'
import {useI18n} from 'vue-i18n'
import {carouselImages} from '../globals'
import {onMounted, onUnmounted, reactive, ref, watch} from 'vue'
import {ElMessage, ElMessageBox, ElNotification, FormInstance, FormRules} from 'element-plus'
import axiosInstance from '../utils/axios'
import Vcode from 'vue3-puzzle-vcode'
import {Phone, CircleCheck, ArrowRight} from '@element-plus/icons-vue'

const {t} = useI18n()
const router = useRouter()
const countdown = ref(0)
const currentCode = ref('')
const currentPhone = ref('')
const buttonLabel = ref(t('RegisterPage.GetRegistrationVerificationCode'))
const isTelephoneUnique = ref(-1)
const resetPasswordRuleFormRef = ref<FormInstance>()
const isShowVCode = ref(false)
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const windowWidth = ref(window.innerWidth)

onMounted(() => {
  if (currentUserId.value == 0) {
    router.push('/login')
    ElMessageBox.alert(t('SettingsPage.PleaseLoginFirst'), t('SettingsPage.Notice'), {
      showClose: false
    })
  }
})

watch(countdown, (newCount) => {
  if (newCount > 0) {
    buttonLabel.value = `${newCount} s`
  } else {
    buttonLabel.value = t('RegisterPage.GetRegistrationVerificationCode')
  }
})

interface ResetPasswordRuleForm {
  telephone: string
  resetVerificationCode: string
  confirm: boolean
}

const resetPasswordRuleForm = reactive<ResetPasswordRuleForm>({
  telephone: '',
  resetVerificationCode: '',
  confirm: false
})

const resetPasswordRules: FormRules = {
  telephone: [
    {
      required: true,
      message: t('RegisterPage.EmptyTelephone'),
      trigger: 'change',
    },
    {
      validator: (rule, value, callback) => {
        const phoneRegex = /^\d{11}$/
        if (value && !phoneRegex.test(value)) {
          callback(new Error(t('RegisterPage.InvalidTelephone')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
    },
    {
      validator: (rule, value, callback) => {
        if (value && isTelephoneUnique.value == 0) {
          callback(new Error(t('LoginPage.NotRegistered')))
        } else {
          callback()
        }
      },
      trigger: 'change'
    }
  ],
  resetVerificationCode: [
    {
      required: true,
      message: t('RegisterPage.EmptyRegistrationVerificationCode'),
      trigger: 'change',
    },
    {
      validator: (rule, value, callback) => {
        const phoneRegex = /^\d{6}$/
        if (value && !phoneRegex.test(value)) {
          callback(new Error(t('RegisterPage.InvalidRegistrationVerificationCode')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
    },
    {
      validator: (rule, value, callback) => {
        if (value && (value != currentCode.value || resetPasswordRuleForm.telephone != currentPhone.value)) {
          callback(new Error(t('RegisterPage.WrongRegistrationVerificationCode')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
    }
  ],
  confirm: [
    {
      validator: (rule, value, callback) => {
        if (value == true) {
          callback()
        } else {
          callback(new Error(t('DeleteAccountPage.WarningPrompt5')))
        }
      },
      trigger: 'change'
    }
  ]
}

watch(() => resetPasswordRuleForm.telephone, (newVal) => {
  if (newVal) {
    checkTelephoneUnique(newVal)
  }
})

onMounted(() => {
  if (resetPasswordRuleForm.telephone) {
    checkTelephoneUnique(resetPasswordRuleForm.telephone)
  }
})

const checkTelephoneUnique = async (telephone) => {
  try {
    const response = await axiosInstance.get(`user/check-telephone-unique/${telephone}`)
    isTelephoneUnique.value = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    isTelephoneUnique.value = -1
  }
}

async function sendResetVerificationCode() {
  if (countdown.value > 0) {
    return
  }
  const phoneRegex = /^\d{11}$/
  const telephone = resetPasswordRuleForm.telephone
  let resetVerificationCode = ''
  for (let i = 0; i < 6; i++) {
    resetVerificationCode += Math.floor(Math.random() * 10).toString()
  }
  currentCode.value = resetVerificationCode
  currentPhone.value = resetPasswordRuleForm.telephone
  if (telephone != '' && phoneRegex.test(telephone) && isTelephoneUnique.value == 0) {
    ElMessage.warning(t('LoginPage.NotRegistered'))
  }
  if (telephone != '' && phoneRegex.test(telephone) && isTelephoneUnique.value == 1) {
    console.log('Telephone: ' + (currentPhone.value == '' ? 'null' : currentPhone.value) + ' - Code: ' + currentCode.value)
    countdown.value = 60
    const intervalId = setInterval(() => {
      countdown.value--
      if (countdown.value <= 0) {
        clearInterval(intervalId)
      }
    }, 1000)
    const body = {telephoneNumber: telephone, verificationCode: resetVerificationCode}
    try {
      await axiosInstance.post('delete-verification', body)
    } catch (error) {
      ElNotification({
        title: t('RegisterPage.VerificationCodeSendingFailed'),
        message: t('RegisterPage.VerificationCodeSendingFailedPrompt'),
        type: 'error',
      })
    }
  }
}

const submitResetPassword = async (formEl: FormInstance | undefined) => {
  if (resetPasswordRuleForm.resetVerificationCode && resetPasswordRuleForm.telephone && resetPasswordRuleForm.confirm) {
    isShowVCode.value = true
  }
  while (isShowVCode.value) {
    await new Promise(resolve => setTimeout(resolve, 100))
  }
  if (!formEl) {
    return
  }
  try {
    const valid = await formEl.validate();
    if (valid) {
      try {
        await axiosInstance.delete(`user/${currentUserId.value}`)
        localStorage.setItem('currentUserId', '0')
        await router.push('/')
        window.location.href = '/'
      } catch (error) {
        ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
      }
    }
  } catch (error) {
  }
}

function updateWidth() {
  windowWidth.value = window.innerWidth
}

onMounted(() => window.addEventListener('resize', updateWidth))

onUnmounted(() => window.removeEventListener('resize', updateWidth))
</script>

<style scoped>
.container {
  display: flex;
  height: calc(100vh - 135px);
}

.left, .right {
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.right {
  background-color: var(--el-color-info-light-9);
}

.carousel-container {
  width: 100%;
}

.carousel-image {
  max-width: 100%;
}

input[type='checkbox'] {
  cursor: pointer;
}

label {
  display: flex;
  cursor: pointer;
}

label input[type='checkbox'] {
  margin-right: 6px;
}

.breadcrumb-with-margin {
  padding-bottom: 10px;
  font-size: 16px;
  align-self: flex-start;
}
</style>
