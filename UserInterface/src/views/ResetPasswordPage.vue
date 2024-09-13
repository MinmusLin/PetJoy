<!--
  Project Name:  UserInterface
  File Name:     ResetPasswordPage.vue
  File Function: 重置密码页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-30
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='container'>
    <div class='left'>
      <h1>{{ t('ResetPasswordPage.ResetPassword') }}</h1>

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
          <el-form-item prop='resetVerificationCode'>
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
          <el-form-item prop='password'>
            <el-tooltip :visible="resetPasswordRuleForm.password!=''&&!isShowVCode"
                        :content='passwordStrengthText()'
                        placement='right'
                        raw-content>
              <!--suppress TypeScriptValidateTypes-->
              <el-input v-model='resetPasswordRuleForm.password'
                        type='password'
                        size='large'
                        :prefix-icon='Unlock'
                        :placeholder="t('RegisterPage.InputPasswordPrompt')"
                        autocomplete='off'
                        @input='checkPasswordStrength'
                        show-password/>
            </el-tooltip>
          </el-form-item>
          <el-form-item prop='passwordCheck'>
            <!--suppress TypeScriptValidateTypes-->
            <el-input v-model='resetPasswordRuleForm.passwordCheck'
                      type='password'
                      size='large'
                      :prefix-icon='Lock'
                      :placeholder="t('RegisterPage.InputPasswordCheckPrompt')"
                      autocomplete='off'
                      show-password/>
          </el-form-item>
          <el-button type='primary'
                     size='large'
                     @click='submitResetPassword(resetPasswordRuleFormRef)'
                     style='width: 100%'>{{ t('ResetPasswordPage.ResetPassword') }}
          </el-button>
        </el-form>
      </el-card>

      <div v-if='currentUserId==0' style='display: flex; padding-bottom: 46px'>
        <el-link type='primary' :underline='false' @click="router.push('/login')">
          {{ t('ResetPasswordPage.GoToLogin') }}
        </el-link>
        <el-divider direction='vertical' style='margin-top: 1px'/>
        <el-link type='primary' :underline='false' @click="router.push('/register')">
          {{ t('ResetPasswordPage.GoToRegister') }}
        </el-link>
      </div>

      <div v-if='currentUserId!=0' style='display: flex; padding-bottom: 46px'>
        <el-link type='primary' :underline='false' @click="router.push(`/profile/${currentUserId}`)">
          {{ t('ResetPasswordPage.GoToProfile') }}
        </el-link>
        <el-divider direction='vertical' style='margin-top: 1px'/>
        <el-link type='primary' :underline='false' @click="router.push('/settings')">
          {{ t('ResetPasswordPage.GoToSettings') }}
        </el-link>
      </div>
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
import {ElMessage, ElNotification, FormInstance, FormRules} from 'element-plus'
import axiosInstance from '../utils/axios'
import Vcode from 'vue3-puzzle-vcode'
import {Phone, CircleCheck, Unlock, Lock} from '@element-plus/icons-vue'

const {t} = useI18n()
const router = useRouter()
const countdown = ref(0)
const currentCode = ref('')
const currentPhone = ref('')
const buttonLabel = ref(t('RegisterPage.GetRegistrationVerificationCode'))
const isTelephoneUnique = ref(-1)
const resetPasswordRuleFormRef = ref<FormInstance>()
const isShowVCode = ref(false)
const passwordStrength = ref('low')
const passwordStrengthPrompt = ref('')
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const windowWidth = ref(window.innerWidth)

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
  password: string
  passwordCheck: string
}

const resetPasswordRuleForm = reactive<ResetPasswordRuleForm>({
  telephone: '',
  resetVerificationCode: '',
  password: '',
  passwordCheck: ''
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
  password: [
    {
      required: true,
      message: t('RegisterPage.PasswordRequired'),
      trigger: 'blur'
    },
    {
      min: 8,
      max: 16,
      message: t('RegisterPage.PasswordLength'),
      trigger: 'blur'
    },
    {
      validator: (rule, value, callback) => {
        if (!/[A-Z]/.test(value)) {
          callback(new Error(t('RegisterPage.PasswordRequirement')))
        } else if (!/[a-z]/.test(value)) {
          callback(new Error(t('RegisterPage.PasswordRequirement')))
        } else if (!/[0-9]/.test(value)) {
          callback(new Error(t('RegisterPage.PasswordRequirement')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
    }
  ],
  passwordCheck: [
    {
      required: true,
      message: t('RegisterPage.PasswordRequired'),
      trigger: 'blur'
    },
    {
      validator: (rule, value, callback) => {
        if (value != resetPasswordRuleForm.password) {
          callback(new Error(t('RegisterPage.PasswordMismatch')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
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
      await axiosInstance.post('reset-verification', body)
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
  if (resetPasswordRuleForm.resetVerificationCode
      && resetPasswordRuleForm.telephone
      && resetPasswordRuleForm.password
      && resetPasswordRuleForm.passwordCheck) {
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
        await axiosInstance.get(`user/get-user-id-by-telephone/${resetPasswordRuleForm.telephone}`).then((response) => {
          axiosInstance.put(`user/password/${response.data}`, {plainPassword: resetPasswordRuleForm.password}).then(() => {
            localStorage.setItem('currentUserId', '0')
            router.push('/login')
            window.location.href = '/login'
          }).catch(() => {
            ElMessage.error(t('ResetPasswordPage.ResetPasswordErrorPrompt'))
          })
        }).catch(() => {
          ElMessage.error(t('ResetPasswordPage.ResetPasswordErrorPrompt'))
        })
      } catch (error) {
        ElMessage.error(t('ResetPasswordPage.ResetPasswordErrorPrompt'))
      }
    }
  } catch (error) {
  }
}

function passwordStrengthText() {
  checkPasswordStrength()
  const strengthBars = `
    <div style='display: flex; justify-content: space-between; width: 100%; padding-bottom: 2px'>
      <div style="width: 30%; height: 5px; background-color: ${passwordStrength.value == 'low' ? '#FF6464' : 'lightgray'}"/>
      <div style="width: 30%; height: 5px; background-color: ${passwordStrength.value == 'medium' ? '#FFBD67' : 'lightgray'}"/>
      <div style="width: 30%; height: 5px; background-color: ${passwordStrength.value == 'high' ? '#5BE7A9' : 'lightgray'}"/>
    </div>`
  return `
    <div>
      <p style='margin-top: 0; margin-bottom: 8px'>${passwordStrengthPrompt.value}</p>
      ${strengthBars}
    </div>`
}

function checkPasswordStrength() {
  const password = resetPasswordRuleForm.password
  const hasUpperCase = /[A-Z]/.test(password)
  const hasLowerCase = /[a-z]/.test(password)
  const hasNumber = /[0-9]/.test(password)
  const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(password)
  if (password.length < 8 || !hasUpperCase || !hasLowerCase || !hasNumber) {
    passwordStrength.value = 'low'
    passwordStrengthPrompt.value = t('RegisterPage.LowPasswordStrengthPrompt')
  } else if (password.length >= 8 && password.length <= 16 && hasUpperCase && hasLowerCase && hasNumber && !hasSpecialChar) {
    passwordStrength.value = 'medium'
    passwordStrengthPrompt.value = t('RegisterPage.MediumPasswordStrengthPrompt')
  } else if (password.length >= 8 && password.length <= 16 && hasUpperCase && hasLowerCase && hasNumber && hasSpecialChar) {
    passwordStrength.value = 'high'
    passwordStrengthPrompt.value = t('RegisterPage.HighPasswordStrengthPrompt')
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
</style>
