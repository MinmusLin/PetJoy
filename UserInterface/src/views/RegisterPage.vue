<!--
  Project Name:  UserInterface
  File Name:     RegisterPage.vue
  File Function: 注册页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-30
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='container'>
    <div class='left'>
      <h1 style='margin-bottom: 50px'>{{ t('RegisterPage.RegisterAccount') }}</h1>

      <el-steps style='width: 520px' :active='activeStep' finish-status='success'>
        <el-step :title="t('RegisterPage.BindPhone')"/>
        <el-step :title="t('RegisterPage.AccountSecurity')"/>
        <el-step :title="t('RegisterPage.CompleteInformation')"/>
      </el-steps>

      <el-card style='width: 550px; margin-top: 50px; margin-bottom: 30px' shadow='always'>
        <div v-if='activeStep==0'>
          <el-form ref='registrationRuleFormRef1'
                   style='max-width: 100%'
                   :model='registrationRuleForm1'
                   :rules='registrationRules'>
            <el-form-item prop='telephone'>
              <!--suppress TypeScriptValidateTypes-->
              <el-input size='large'
                        :placeholder="t('RegisterPage.InputTelephonePrompt')"
                        v-model='registrationRuleForm1.telephone'
                        :prefix-icon='Phone'
                        clearable>
                <template #prepend>{{ t('LoginPage.TelephonePrepend') }}</template>
              </el-input>
            </el-form-item>
            <el-form-item prop='registrationVerificationCode'>
              <!--suppress TypeScriptValidateTypes-->
              <el-input size='large'
                        :placeholder="t('RegisterPage.InputRegistrationVerificationCodePrompt')"
                        v-model='registrationRuleForm1.registrationVerificationCode'
                        :prefix-icon='CircleCheck'
                        clearable>
                <template #append>
                  <el-button size='large'
                             type='info'
                             style='width: 200px'
                             @click='sendRegistrationVerificationCode'
                             :disabled='countdown>0'
                             plain>
                    {{ buttonLabel }}
                  </el-button>
                </template>
              </el-input>
            </el-form-item>
            <el-button type='primary'
                       size='large'
                       @click='submitRegistration(registrationRuleFormRef1)'
                       style='width: 100%'>{{ t('RegisterPage.NextStep') }}
            </el-button>
          </el-form>
        </div>

        <div v-else-if='activeStep==1'>
          <el-form ref='registrationRuleFormRef2'
                   style='max-width: 100%'
                   :model='registrationRuleForm2'
                   :rules='registrationRules'>
            <el-form-item prop='password'>
              <el-tooltip :visible="registrationRuleForm2.password!=''&&!isShowVCode"
                          :content='passwordStrengthText()'
                          placement='right'
                          raw-content>
                <!--suppress TypeScriptValidateTypes-->
                <el-input v-model='registrationRuleForm2.password'
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
              <el-input v-model='registrationRuleForm2.passwordCheck'
                        type='password'
                        size='large'
                        :prefix-icon='Lock'
                        :placeholder="t('RegisterPage.InputPasswordCheckPrompt')"
                        autocomplete='off'
                        show-password/>
            </el-form-item>
            <el-button type='primary'
                       size='large'
                       @click='submitRegistration(registrationRuleFormRef2)'
                       style='width: 100%'>{{ t('RegisterPage.NextStep') }}
            </el-button>
          </el-form>
        </div>

        <div v-else>
          <el-form ref='registrationRuleFormRef3'
                   style='max-width: 100%'
                   :model='registrationRuleForm3'
                   :rules='registrationRules'>
            <el-form-item prop='userName'>
              <!--suppress TypeScriptValidateTypes-->
              <el-input v-model='registrationRuleForm3.userName'
                        size='large'
                        :prefix-icon='Edit'
                        :disabled='activeStep==3'
                        :placeholder="t('RegisterPage.InputUserNamePrompt')"
                        autocomplete='off'
                        clearable/>
            </el-form-item>
            <div class='form-row'>
              <el-form-item prop='gender' class='form-half'>
                <el-select v-model='registrationRuleForm3.gender'
                           :disabled='activeStep==3'
                           :placeholder="t('RegisterPage.SelectGenderPrompt')"
                           size='large'
                           style='width: 240px'>
                  <el-option :label="t('RegisterPage.Male')" value='Male'/>
                  <el-option :label="t('RegisterPage.Female')" value='Female'/>
                </el-select>
              </el-form-item>
              <el-form-item prop='birthdate' class='form-half'>
                <el-date-picker v-model='registrationRuleForm3.birthdate'
                                :disabled='activeStep==3'
                                type='date'
                                :placeholder="t('RegisterPage.SelectBirthdatePrompt')"
                                :disabled-date='disabledDate'
                                style='width: 100%'
                                size='large'
                                :editable='false'
                                :clearable='false'/>
              </el-form-item>
            </div>
            <el-button v-if='activeStep==2'
                       type='primary'
                       size='large'
                       @click='submitFinalRegistration(registrationRuleFormRef3)'
                       style='width: 100%'>{{ t('RegisterPage.JoinPetJoy') }}
            </el-button>
            <el-button v-if='activeStep==3'
                       type='primary'
                       size='large'
                       @click="router.push('/login')"
                       style='width: 100%'>{{ t('RegisterPage.NowProceedingToLogin') }}
            </el-button>
          </el-form>
        </div>
      </el-card>

      <el-link style='margin-bottom: 50px' type='primary' :underline='false' @click="router.push('/login')">
        {{ t('RegisterPage.HaveAnAccountPrompt') }}
      </el-link>
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
import {sha256} from 'js-sha256'
import Vcode from 'vue3-puzzle-vcode'
import {CircleCheck, Lock, Phone, Unlock, Edit} from '@element-plus/icons-vue'

const {t} = useI18n()
const router = useRouter()
const activeStep = ref(0)
const countdown = ref(0)
const currentCode = ref('')
const currentPhone = ref('')
const buttonLabel = ref(t('RegisterPage.GetRegistrationVerificationCode'))
const registrationRuleFormRef1 = ref<FormInstance>()
const registrationRuleFormRef2 = ref<FormInstance>()
const registrationRuleFormRef3 = ref<FormInstance>()
const isTelephoneUnique = ref(-1)
const isUserNameUnique = ref(-1)
const isShowVCode = ref(false)
const passwordStrength = ref('low')
const passwordStrengthPrompt = ref('')
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const windowWidth = ref(window.innerWidth)

onMounted(() => {
  if (currentUserId.value != 0) {
    router.push(`/profile/${currentUserId.value}`)
  }
})

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
  const password = registrationRuleForm2.password
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

watch(countdown, (newCount) => {
  if (newCount > 0) {
    buttonLabel.value = `${newCount} s`
  } else {
    buttonLabel.value = t('RegisterPage.GetRegistrationVerificationCode')
  }
})

interface RegistrationRuleForm1 {
  telephone: string
  registrationVerificationCode: string
}

interface RegistrationRuleForm2 {
  password: string
  passwordCheck: string
}

interface RegistrationRuleForm3 {
  userName: string
  gender: string
  birthdate: string
}

const registrationRuleForm1 = reactive<RegistrationRuleForm1>({
  telephone: '',
  registrationVerificationCode: ''
})

const registrationRuleForm2 = reactive<RegistrationRuleForm2>({
  password: '',
  passwordCheck: ''
})

const registrationRuleForm3 = reactive<RegistrationRuleForm3>({
  userName: '',
  gender: '',
  birthdate: ''
})

const registrationRules: FormRules = {
  userName: [
    {
      required: true,
      message: t('RegisterPage.EmptyUserName'),
      trigger: 'change'
    },
    {
      max: 16,
      message: t('RegisterPage.UserNameLength'),
      trigger: 'change'
    },
    {
      validator: (rule, value, callback) => {
        const pattern = /^[a-zA-Z0-9_\u4e00-\u9fa5]+$/
        if (!pattern.test(value)) {
          callback(new Error(t('RegisterPage.UserNameRequirement')))
        } else {
          callback()
        }
      },
      trigger: 'change'
    },
    {
      validator: (rule, value, callback) => {
        if (value && isUserNameUnique.value == 1) {
          callback(new Error(t('RegisterPage.UniqueUserName')))
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
        if (value != registrationRuleForm2.password) {
          callback(new Error(t('RegisterPage.PasswordMismatch')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
    }
  ],
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
        if (value && isTelephoneUnique.value == 1) {
          callback(new Error(t('RegisterPage.UniqueTelephone')))
        } else {
          callback()
        }
      },
      trigger: 'change'
    }
  ],
  gender: [
    {
      required: true,
      message: t('RegisterPage.EmptyGender'),
      trigger: 'change'
    }
  ],
  birthdate: [
    {
      required: true,
      message: t('RegisterPage.EmptyBirthdate'),
      trigger: 'change'
    }
  ],
  registrationVerificationCode: [
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
        if (value && (value != currentCode.value || registrationRuleForm1.telephone != currentPhone.value)) {
          callback(new Error(t('RegisterPage.WrongRegistrationVerificationCode')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
    }
  ]
}

watch(() => registrationRuleForm1.telephone, (newVal) => {
  if (newVal) {
    checkTelephoneUnique(newVal)
  }
})

onMounted(() => {
  if (registrationRuleForm1.telephone) {
    checkTelephoneUnique(registrationRuleForm1.telephone)
  }
})

watch(() => registrationRuleForm3.userName, (newVal) => {
  if (newVal) {
    checkUserNameUnique(newVal)
  }
})

onMounted(() => {
  if (registrationRuleForm3.userName) {
    checkUserNameUnique(registrationRuleForm3.userName)
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

const checkUserNameUnique = async (userName) => {
  try {
    const response = await axiosInstance.get(`user/check-userName-unique/${userName}`)
    isUserNameUnique.value = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    isUserNameUnique.value = -1
  }
}

const submitRegistration = async (formEl: FormInstance | undefined) => {
  if (!formEl) {
    return
  }
  await formEl.validate(async (valid) => {
    if (valid) {
      activeStep.value++
    }
  })
}

const submitFinalRegistration = async (formEl: FormInstance | undefined) => {
  if (registrationRuleForm3.userName && registrationRuleForm3.gender && registrationRuleForm3.birthdate) {
    isShowVCode.value = true
  }
  while (isShowVCode.value) {
    await new Promise(resolve => setTimeout(resolve, 100))
  }
  if (!formEl) {
    return
  }
  await formEl.validate(async (valid) => {
    if (valid) {
      const result = await postRegistration()
      if (result) {
        activeStep.value++
        ElNotification({
          title: t('RegisterPage.RegisterAccountSucceed'),
          message: t('RegisterPage.RegisterAccountSucceedPrompt'),
          type: 'success',
        })
      } else {
        ElNotification({
          title: t('RegisterPage.RegisterAccountFailed'),
          message: t('RegisterPage.RegisterAccountFailedPrompt'),
          type: 'error',
        })
      }
    }
  })
}

async function postRegistration() {
  const now = new Date().toISOString()
  const newUser = {
    userName: registrationRuleForm3.userName,
    password: sha256(registrationRuleForm2.password),
    telephone: registrationRuleForm1.telephone,
    registrationDate: now,
    lastLoginTime: now,
    role: 0,
    status: 0,
    gender: (registrationRuleForm3.gender == 'Male' ? 0 : 1),
    birthdate: registrationRuleForm3.birthdate,
    experiencePoints: 0,
    followsCount: 0,
    followedCount: 0,
    favoritesCount: 0,
    favoritedCount: 0,
    likesCount: 0,
    likedCount: 0,
    messageCount: 0
  }
  try {
    const response = await axiosInstance.post('user', newUser)
    return response.status == 201
  } catch (error) {
    return false
  }
}

async function sendRegistrationVerificationCode() {
  if (countdown.value > 0) {
    return
  }
  const phoneRegex = /^\d{11}$/
  const telephone = registrationRuleForm1.telephone
  let registrationVerificationCode = ''
  for (let i = 0; i < 6; i++) {
    registrationVerificationCode += Math.floor(Math.random() * 10).toString()
  }
  currentCode.value = registrationVerificationCode
  currentPhone.value = registrationRuleForm1.telephone
  if (telephone != '' && phoneRegex.test(telephone) && isTelephoneUnique.value == 1) {
    ElMessage.warning(t('RegisterPage.UniqueTelephone'))
  }
  if (telephone != '' && phoneRegex.test(telephone) && isTelephoneUnique.value == 0) {
    console.log('Telephone: ' + (currentPhone.value == '' ? 'null' : currentPhone.value) + ' - Code: ' + currentCode.value)
    countdown.value = 60
    const intervalId = setInterval(() => {
      countdown.value--
      if (countdown.value <= 0) {
        clearInterval(intervalId)
      }
    }, 1000)
    const body = {telephoneNumber: telephone, verificationCode: registrationVerificationCode}
    try {
      await axiosInstance.post('registration-verification', body)
    } catch (error) {
      ElNotification({
        title: t('RegisterPage.VerificationCodeSendingFailed'),
        message: t('RegisterPage.VerificationCodeSendingFailedPrompt'),
        type: 'error',
      })
    }
  }
}

const disabledDate = (time: Date) => {
  return time.getTime() > Date.now()
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

.form-row {
  display: flex;
  width: 100%;
}

.form-half {
  flex: 1;
}
</style>
