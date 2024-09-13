<!--
  Project Name:  UserInterface
  File Name:     LoginPage.vue
  File Function: 登录页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-30
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='container'>
    <div class='left'>
      <h1>{{ t('LoginPage.LoginAccount') }}</h1>

      <el-card style='width: 550px; margin-top: 16px; margin-bottom: 30px' shadow='always'>
        <el-tabs v-model='activeName'>
          <el-tab-pane :label="t('LoginPage.PasswordLogin')" name='PasswordLogin'>
            <el-form ref='loginRuleFormRef1'
                     style='max-width: 100%'
                     :model='loginRuleForm1'
                     :rules='loginRules1'>
              <el-form-item prop='telephone'>
                <!--suppress TypeScriptValidateTypes-->
                <el-input size='large'
                          style='padding-top: 16px'
                          :placeholder="t('RegisterPage.InputTelephonePrompt')"
                          :prefix-icon='Phone'
                          v-model='loginRuleForm1.telephone'
                          clearable>
                  <template #prepend>{{ t('LoginPage.TelephonePrepend') }}</template>
                </el-input>
              </el-form-item>
              <el-form-item prop='password'>
                <!--suppress TypeScriptValidateTypes-->
                <el-input v-model='loginRuleForm1.password'
                          type='password'
                          size='large'
                          :prefix-icon='Lock'
                          :placeholder="t('RegisterPage.InputPasswordPrompt')"
                          autocomplete='off'
                          show-password/>
              </el-form-item>
              <el-button type='primary'
                         size='large'
                         @click='submitLogin1(loginRuleFormRef1)'
                         style='width: 100%'>{{ t('LoginPage.Login') }}
              </el-button>
            </el-form>
          </el-tab-pane>

          <el-tab-pane :label="t('LoginPage.VerificationCodeLogin')" name='VerificationCodeLogin'>
            <el-form ref='loginRuleFormRef2'
                     style='max-width: 100%'
                     :model='loginRuleForm2'
                     :rules='loginRules2'>
              <el-form-item prop='telephone'>
                <!--suppress TypeScriptValidateTypes-->
                <el-input size='large'
                          style='padding-top: 16px'
                          :placeholder="t('RegisterPage.InputTelephonePrompt')"
                          v-model='loginRuleForm2.telephone'
                          :prefix-icon='Phone'
                          clearable>
                  <template #prepend>{{ t('LoginPage.TelephonePrepend') }}</template>
                </el-input>
              </el-form-item>
              <el-form-item prop='loginVerificationCode'>
                <!--suppress TypeScriptValidateTypes-->
                <el-input size='large'
                          :prefix-icon='CircleCheck'
                          :placeholder="t('RegisterPage.InputRegistrationVerificationCodePrompt')"
                          v-model='loginRuleForm2.loginVerificationCode'
                          clearable>
                  <template #append>
                    <el-button size='large'
                               type='info'
                               style='width: 200px'
                               @click='sendLoginVerificationCode'
                               :disabled='countdown>0'
                               plain>{{ buttonLabel }}
                    </el-button>
                  </template>
                </el-input>
              </el-form-item>
              <el-button type='primary'
                         size='large'
                         @click='submitLogin2(loginRuleFormRef2)'
                         style='width: 100%'>{{ t('LoginPage.Login') }}
              </el-button>
            </el-form>
          </el-tab-pane>
        </el-tabs>
      </el-card>

      <div style='display: flex'>
        <el-link type='primary' :underline='false' @click="router.push('/register')">
          {{ t('LoginPage.NoAccountPrompt') }}
        </el-link>
        <el-divider direction='vertical' style='margin-top: 1px'/>
        <el-link type='primary' :underline='false' @click="router.push('/reset-password')">
          {{ t('LoginPage.ForgetPassword') }}
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
import {Phone, Lock, CircleCheck} from '@element-plus/icons-vue'

const {t} = useI18n()
const router = useRouter()
const activeName = ref('PasswordLogin')
const countdown = ref(0)
const currentCode = ref('')
const currentPhone = ref('')
const buttonLabel = ref(t('RegisterPage.GetRegistrationVerificationCode'))
const isTelephoneUnique = ref(-1)
const loginRuleFormRef1 = ref<FormInstance>()
const loginRuleFormRef2 = ref<FormInstance>()
const isShowVCode = ref(false)
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const windowWidth = ref(window.innerWidth)

onMounted(() => {
  if (currentUserId.value != 0) {
    router.push(`/profile/${currentUserId.value}`)
  }
})

watch(countdown, (newCount) => {
  if (newCount > 0) {
    buttonLabel.value = `${newCount} s`
  } else {
    buttonLabel.value = t('RegisterPage.GetRegistrationVerificationCode')
  }
})

interface LoginRuleForm1 {
  telephone: string
  password: string
}

interface LoginRuleForm2 {
  telephone: string
  loginVerificationCode: string
}

const loginRuleForm1 = reactive<LoginRuleForm1>({
  telephone: '',
  password: ''
})

const loginRuleForm2 = reactive<LoginRuleForm2>({
  telephone: '',
  loginVerificationCode: ''
})

const loginRules1: FormRules = {
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
  password: [
    {
      required: true,
      message: t('RegisterPage.PasswordRequired'),
      trigger: 'change'
    }
  ]
}

const loginRules2: FormRules = {
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
  loginVerificationCode: [
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
        if (value && (value != currentCode.value || loginRuleForm2.telephone != currentPhone.value)) {
          callback(new Error(t('RegisterPage.WrongRegistrationVerificationCode')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
    }
  ]
}

watch(() => loginRuleForm1.telephone, (newVal) => {
  if (newVal) {
    checkTelephoneUnique(newVal)
  }
})

onMounted(() => {
  if (loginRuleForm1.telephone) {
    checkTelephoneUnique(loginRuleForm1.telephone)
  }
})

watch(() => loginRuleForm2.telephone, (newVal) => {
  if (newVal) {
    checkTelephoneUnique(newVal)
  }
})

onMounted(() => {
  if (loginRuleForm2.telephone) {
    checkTelephoneUnique(loginRuleForm2.telephone)
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

async function sendLoginVerificationCode() {
  if (countdown.value > 0) {
    return
  }
  const phoneRegex = /^\d{11}$/
  const telephone = loginRuleForm2.telephone
  let loginVerificationCode = ''
  for (let i = 0; i < 6; i++) {
    loginVerificationCode += Math.floor(Math.random() * 10).toString()
  }
  currentCode.value = loginVerificationCode
  currentPhone.value = loginRuleForm2.telephone
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
    const body = {telephoneNumber: telephone, verificationCode: loginVerificationCode}
    try {
      await axiosInstance.post('login-verification', body)
    } catch (error) {
      ElNotification({
        title: t('RegisterPage.VerificationCodeSendingFailed'),
        message: t('RegisterPage.VerificationCodeSendingFailedPrompt'),
        type: 'error',
      })
    }
  }
}

const submitLogin1 = async (formEl: FormInstance | undefined) => {
  if (loginRuleForm1.password && loginRuleForm1.telephone) {
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
      let userId = 0
      let isPasswordCorrect = -1
      try {
        const response = await axiosInstance.get(`user/get-user-id-by-telephone/${loginRuleForm1.telephone}`)
        userId = response.data
        try {
          const response = await axiosInstance.post('user/verify-password', {
            userId: userId,
            plainPassword: loginRuleForm1.password
          })
          isPasswordCorrect = response.data
          if (isPasswordCorrect == -1) {
            ElMessage.error(t('LoginPage.NetworkError'))
          } else if (isPasswordCorrect == 0) {
            ElMessage.error(t('LoginPage.IncorrectPassword'))
          } else {
            try {
              axiosInstance.put(`user/last-login-time/${userId}`, {
                lastLoginTime: new Date().toISOString()
              }).then(() => {
                localStorage.setItem('currentUserId', userId.toString())
                router.push('/')
                window.location.href = '/'
              }).catch(() => {
                ElMessage.error(t('LoginPage.LoginErrorPrompt'))
              })
            } catch (error) {
              ElMessage.error(t('LoginPage.LoginErrorPrompt'))
            }
          }
        } catch (error) {
          ElMessage.error(t('LoginPage.LoginErrorPrompt'))
        }
      } catch (error) {
        ElMessage.error(t('LoginPage.LoginErrorPrompt'))
      }
    }
  } catch (error) {
  }
}

const submitLogin2 = async (formEl: FormInstance | undefined) => {
  if (loginRuleForm2.loginVerificationCode && loginRuleForm2.telephone) {
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
      let userId = 0
      try {
        const response = await axiosInstance.get(`user/get-user-id-by-telephone/${loginRuleForm2.telephone}`)
        userId = response.data
        localStorage.setItem('currentUserId', userId.toString())
        await router.push('/')
        window.location.href = '/'
      } catch (error) {
        ElMessage.error(t('LoginPage.LoginErrorPrompt'))
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
</style>
