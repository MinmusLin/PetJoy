<!--
  Project Name:  UserInterface
  File Name:     ChangeTelephonePage.vue
  File Function: 修改手机页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-01
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='container'>
    <div class='left'>
      <div style='width: 550px'>
        <!--suppress TypeScriptValidateTypes-->
        <el-breadcrumb :separator-icon='ArrowRight' class='breadcrumb-with-margin'>
          <el-breadcrumb-item to='/settings'>{{ t('HeaderNavbar.Settings') }}</el-breadcrumb-item>
          <el-breadcrumb-item>{{ t('SettingsPage.ChangeBoundTelephone') }}</el-breadcrumb-item>
        </el-breadcrumb>
      </div>

      <h1>{{ t('SettingsPage.ChangeBoundTelephone') }}</h1>

      <el-card style='width: 550px; margin-top: 16px; margin-bottom: 30px' shadow='always'>
        <el-form ref='changeTelephoneRuleFormRef'
                 style='max-width: 100%'
                 :model='changeTelephoneRuleForm'
                 :rules='changeTelephoneRules'>
          <el-form-item prop='currentTelephone'>
            <!--suppress TypeScriptValidateTypes-->
            <el-input size='large'
                      :placeholder="t('ChangeTelephonePage.InputCurrentTelephonePrompt')"
                      v-model='changeTelephoneRuleForm.currentTelephone'
                      :prefix-icon='Phone'
                      clearable>
              <template #prepend>{{ t('LoginPage.TelephonePrepend') }}</template>
            </el-input>
          </el-form-item>
          <el-form-item prop='telephone'>
            <!--suppress TypeScriptValidateTypes-->
            <el-input size='large'
                      :placeholder="t('ChangeTelephonePage.InputBoundTelephonePrompt')"
                      v-model='changeTelephoneRuleForm.telephone'
                      :prefix-icon='Phone'
                      clearable>
              <template #prepend>{{ t('LoginPage.TelephonePrepend') }}</template>
            </el-input>
          </el-form-item>
          <el-form-item prop='changeVerificationCode'>
            <!--suppress TypeScriptValidateTypes-->
            <el-input size='large'
                      :placeholder="t('RegisterPage.InputRegistrationVerificationCodePrompt')"
                      v-model='changeTelephoneRuleForm.changeVerificationCode'
                      :prefix-icon='CircleCheck'
                      clearable>
              <template #append>
                <el-button size='large'
                           type='info'
                           style='width: 200px'
                           @click='sendChangeVerificationCode'
                           :disabled='countdown>0'
                           plain>
                  {{ buttonLabel }}
                </el-button>
              </template>
            </el-input>
          </el-form-item>
          <el-button type='primary'
                     size='large'
                     @click='submitChangeTelephone(changeTelephoneRuleFormRef)'
                     style='width: 100%'>{{ t('SettingsPage.ChangeBoundTelephone') }}
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
const isShowVCode = ref(false)
const currentUserTelephone = ref('')
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const windowWidth = ref(window.innerWidth)
const changeTelephoneRuleFormRef = ref<FormInstance>()

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

interface ChangeTelephoneRuleForm {
  currentTelephone: string
  telephone: string
  changeVerificationCode: string
}

const changeTelephoneRuleForm = reactive<ChangeTelephoneRuleForm>({
  currentTelephone: '',
  telephone: '',
  changeVerificationCode: ''
})

const changeTelephoneRules: FormRules = {
  currentTelephone: [
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
        if (value != currentUserTelephone.value) {
          callback(new Error(t('ChangeTelephonePage.InputCurrentTelephonePrompt')))
        } else {
          callback()
        }
      },
      trigger: 'change'
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
  changeVerificationCode: [
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
        if (value && (value != currentCode.value || changeTelephoneRuleForm.telephone != currentPhone.value)) {
          callback(new Error(t('RegisterPage.WrongRegistrationVerificationCode')))
        } else {
          callback()
        }
      },
      trigger: 'blur'
    }
  ]
}

watch(() => changeTelephoneRuleForm.telephone, (newVal) => {
  if (newVal) {
    checkTelephoneUnique(newVal)
  }
})

onMounted(() => {
  if (changeTelephoneRuleForm.telephone) {
    checkTelephoneUnique(changeTelephoneRuleForm.telephone)
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

const submitChangeTelephone = async (formEl: FormInstance | undefined) => {
  if (changeTelephoneRuleForm.changeVerificationCode && changeTelephoneRuleForm.telephone) {
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
        axiosInstance.put(`user/telephone/${currentUserId.value}`, {
          telephone: changeTelephoneRuleForm.telephone
        }).then(() => {
          localStorage.setItem('currentUserId', '0')
          router.push('/login')
          window.location.href = '/login'
        }).catch(() => {
          ElMessage.error(t('ErrorMessage.PutErrorMessage'))
        })
      } catch (error) {
        ElMessage.error(t('ErrorMessage.PutErrorMessage'))
      }
    }
  } catch (error) {
  }
}

async function sendChangeVerificationCode() {
  if (countdown.value > 0) {
    return
  }
  const phoneRegex = /^\d{11}$/
  const telephone = changeTelephoneRuleForm.telephone
  let changeVerificationCode = ''
  for (let i = 0; i < 6; i++) {
    changeVerificationCode += Math.floor(Math.random() * 10).toString()
  }
  currentCode.value = changeVerificationCode
  currentPhone.value = changeTelephoneRuleForm.telephone
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
    const body = {telephoneNumber: telephone, verificationCode: changeVerificationCode}
    try {
      await axiosInstance.post('change-verification', body)
    } catch (error) {
      ElNotification({
        title: t('RegisterPage.VerificationCodeSendingFailed'),
        message: t('RegisterPage.VerificationCodeSendingFailedPrompt'),
        type: 'error',
      })
    }
  }
}

function updateWidth() {
  windowWidth.value = window.innerWidth
}

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`user/telephone/${currentUserId.value}`)
    currentUserTelephone.value = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

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

.breadcrumb-with-margin {
  padding-bottom: 10px;
  font-size: 16px;
  align-self: flex-start;
}
</style>
