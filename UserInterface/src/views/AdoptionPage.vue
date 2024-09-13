<!--
  Project Name:  UserInterface
  File Name:     AdoptionPage.vue
  File Function: 领养页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-18
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='center-container'>
    <!--suppress TypeScriptValidateTypes-->
    <el-breadcrumb :separator-icon='ArrowRight' class='breadcrumb-with-margin'>
      <el-breadcrumb-item to='/pet-adoption'>
        {{ t('HeaderNavbar.PetAdoption') }}
      </el-breadcrumb-item>
      <el-breadcrumb-item>
        {{ adoptionData.name }}
      </el-breadcrumb-item>
    </el-breadcrumb>

    <div class='adoption-data-page'>
      <div class='pet-adoption-main-container'>
        <div class='image-container'>
          <img :src='`${ossBaseUrl}${adoptionData.imageUrl}`' alt='AdoptionPetImage'/>
        </div>

        <div class='adoption-main-right'>
          <div class='main-user'>
            <el-avatar style='width: 80px; height: 80px' :src='userAvatarUrl'>
              <el-icon :size='48'>
                <Avatar/>
              </el-icon>
            </el-avatar>

            <div class='user-info'>
              <div class='main-user-title'>{{ t('PetAdoptionPage.UserName') }}</div>
              <div class='main-user-text'>{{ userName }}</div>
              <div class='main-user-title'>{{ t('PetAdoptionPage.Contact') }}</div>
              <div class='main-user-text'>{{ userTelephone }}</div>
            </div>
          </div>

          <div class='pet-adoption-main-data' style='margin-left: 25px'>
            <div class='main-data-title'>{{ t('PetAdoptionPage.Name') }}</div>
            <div class='main-data-text' style='text-align: left'>
              {{ adoptionData.name ? adoptionData.name : t('PetAdoptionPage.UnnamedPet') }}
            </div>
            <div class='main-data-title'>{{ t('PetAdoptionPage.PetAge') }}</div>
            <div class='main-data-text' style='text-align: left'>
              <span>
                {{ adoptionData.age }}
                {{ adoptionData.age <= 1 ? t('PetAdoptionPage.SingularAge') : t('PetAdoptionPage.PluralAge') }}
              </span>
            </div>
            <div class='main-data-title'>{{ t('PetAdoptionPage.Gender') }}</div>
            <div class='main-data-text' style='text-align: left'>
              {{ adoptionData.gender ? t('PetAdoptionPage.GenderFemale') : t('PetAdoptionPage.GenderMale') }}
              <Male v-if='!adoptionData.gender' class='gender-icon male'/>
              <Female v-else class='gender-icon female'/>
            </div>
            <div class='main-data-title'>{{ t('PetAdoptionPage.PetCategory') }}</div>
            <div class='main-data-text' style='text-align: left'>
              {{ combinedCategorySubcategory }}
            </div>
            <div class='main-data-title'>{{ t('PetAdoptionPage.NeuteredOrSpayed') }}</div>
            <div class='main-data-text' style='text-align: left'>
              {{ adoptionData.neuteredOrSpayed ? t('PetAdoptionPage.Neutered') : t('PetAdoptionPage.NotNeutered') }}
            </div>
            <div class='main-data-title'>{{ t('PetAdoptionPage.Location') }}</div>
            <div class='main-data-text' style='text-align: left'>{{ adoptionData.location }}</div>
            <div class='main-data-title'>{{ t('PetAdoptionPage.Reason') }}</div>
            <div class='main-data-text'>{{ adoptionData.reason }}</div>
            <div class='main-data-title'>{{ t('PetAdoptionPage.Status') }}</div>
            <div class='main-data-text' style='text-align: left'>
              {{ adoptionData.status ? t('PetAdoptionPage.Adopted') : t('PetAdoptionPage.NotAdopted') }}
            </div>
          </div>
        </div>
      </div>

      <div class='pet-sub-adoption-container'>
        <div class='sub-adoption-details'>
          <div style='color: var(--adoption-page-details-color)'>
            {{ t('PetAdoptionPage.Details') }}
          </div>
          <div v-if='adoptionData.appendixUrl' class='main-data-text'>
            <el-button type='primary' @click='downloadFile' size='large' class='adoption-page-download-button'>
              <el-icon style='margin-right: 5px; margin-left: -5px'>
                <Download/>
              </el-icon>
              {{ t('PetAdoptionPage.DownloadAppendix') }}
            </el-button>
          </div>
        </div>

        <div class='pet-adoption-main-data' style='margin-top: 20px'>
          <div class='main-data-title'>{{ t('PetAdoptionPage.LatestHealthCheck') }}</div>
          <div class='main-data-text'>{{ adoptionData.latestHealthCheck }}</div>
          <div class='main-data-title'>{{ t('PetAdoptionPage.Health') }}</div>
          <div class='main-data-text'>{{ adoptionData.health }}</div>
          <div class='main-data-title'>{{ t('PetAdoptionPage.Vaccination') }}</div>
          <div class='main-data-text'>{{ adoptionData.vaccination }}</div>
          <div v-if='adoptionData.careNeeds' class='main-data-title'>{{ t('PetAdoptionPage.CareNeeds') }}</div>
          <div v-if='adoptionData.careNeeds' class='main-data-text'>{{ adoptionData.careNeeds }}</div>
          <div v-if='adoptionData.dietaryNeeds' class='main-data-title'>{{ t('PetAdoptionPage.DietaryNeeds') }}</div>
          <div v-if='adoptionData.dietaryNeeds' class='main-data-text'>{{ adoptionData.dietaryNeeds }}</div>
          <div v-if='adoptionData.behavior' class='main-data-title'>{{ t('PetAdoptionPage.Behavior') }}</div>
          <div v-if='adoptionData.behavior' class='main-data-text'>{{ adoptionData.behavior }}</div>
          <div v-if='adoptionData.notes' class='main-data-title'>{{ t('PetAdoptionPage.Notes') }}</div>
          <div v-if='adoptionData.notes' class='main-data-text'>{{ adoptionData.notes }}</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {useI18n} from 'vue-i18n'
import {useRoute, useRouter} from 'vue-router'
import {onMounted, ref, watch} from 'vue'
import axiosInstance from '../utils/axios'
import {ElMessage, ElMessageBox} from 'element-plus'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import {ArrowRight, Female, Male, Download, Avatar} from '@element-plus/icons-vue'

const {locale, t} = useI18n()
const route = useRoute()
const router = useRouter()
const adoptionId = ref(parseInt(<string>route.params.id))
const combinedCategorySubcategory = ref('')
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const userAvatarUrl = ref('')
const userName = ref('')
const userTelephone = ref('')

const adoptionData = ref({
  adoptionId: 0,
  userId: 0,
  categoryId: 0,
  subcategoryId: 0,
  name: '',
  imageUrl: '',
  age: 0,
  location: '',
  reason: '',
  health: '',
  latestHealthCheck: '',
  vaccination: '',
  careNeeds: '',
  dietaryNeeds: '',
  behavior: '',
  neuteredOrSpayed: false,
  notes: '',
  status: false,
  gender: false,
  appendixUrl: ''
})

const downloadFile = () => {
  window.open(`${ossBaseUrl}${adoptionData.value.appendixUrl}`, '_blank')
}

const fetchAdoptionData = async () => {
  try {
    const response1 = await axiosInstance.get(`pet-adoption/${adoptionId.value}`)
    if (response1.status == 404) {
      await router.push('/404')
    } else {
      adoptionData.value = response1.data
      adoptionData.value.latestHealthCheck = formatDateTimeToCST(response1.data.latestHealthCheck).date
      adoptionData.value.gender = response1.data.gender == 1
      const response2 = await axiosInstance.get(`pet-category/category-name/${adoptionData.value.categoryId}-${locale.value}`)
      const response3 = await axiosInstance.get(`pet-subcategory/subcategory-name/${adoptionData.value.subcategoryId}-${locale.value}`)
      combinedCategorySubcategory.value = `${response2.data} / ${response3.data}`
      const avatarResponse = await axiosInstance.get(`user/avatar-url/${adoptionData.value.userId}`)
      userAvatarUrl.value = `${ossBaseUrl}${avatarResponse.data}`
      const nameResponse = await axiosInstance.get(`user/user-name/${adoptionData.value.userId}`)
      userName.value = nameResponse.data
      const telephoneResponse = await axiosInstance.get(`user/telephone/${adoptionData.value.userId}`)
      userTelephone.value = telephoneResponse.data
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
  fetchAdoptionData()
})

watch(() => route.params.id, (newId) => {
  adoptionId.value = parseInt(<string>newId)
  fetchAdoptionData()
})

onMounted(() => {
  if (currentUserId.value == 0) {
    router.push('/login')
    ElMessageBox.alert(t('SettingsPage.PleaseLoginFirst'), t('SettingsPage.Notice'), {
      showClose: false
    })
  }
})
</script>

<style scoped>
:global(:root) {
  --adoption-page-details-color: #49A2FE;
  --adoption-page-button-bg-color: #49A2FE;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --adoption-page-details-color: #2C6FB4;
  --adoption-page-button-bg-color: #275A90;
}

.main-user {
  display: flex;
  align-items: center;
  background-color: var(--el-color-primary-light-7);
  border-radius: 10px;
  margin-left: 25px;
  margin-bottom: 20px;
  padding: 15px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.user-info {
  font-size: 18px;
  margin-left: 20px;
  line-height: 2;
  display: grid;
  grid-template-columns: auto 1fr;
}

.main-user-title {
  font-weight: bold;
  color: var(--el-color-info-light-3);
}

.main-user-text {
  margin-left: 30px;
  text-align: justify;
}

.center-container {
  width: 1200px;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  justify-content: center;
  min-height: 100vh;
}

.breadcrumb-with-margin {
  padding-left: 40px;
  padding-top: 25px;
  padding-bottom: 25px;
  font-size: 18px;
}

.adoption-data-page {
  display: flex;
  flex-direction: column;
  margin-left: 40px;
  margin-right: 40px;
  background-color: var(--el-color-primary-light-9);
  padding: 30px;
  border-radius: 20px;
  margin-bottom: 60px;
}

.pet-adoption-main-container {
  display: flex;
  align-items: center;
}

.pet-adoption-main-data {
  font-size: 20px;
  align-items: center;
  display: grid;
  grid-template-columns: auto 1fr;
  grid-row-gap: 20px;
  grid-column-gap: 5px;
}

.main-data-title {
  font-weight: bold;
  color: var(--el-color-info-light-3);
  text-align: justify;
}

.main-data-text {
  margin-left: 30px;
  line-height: 1.5;
  text-align: justify;
}

.image-container {
  background-color: var(--el-color-primary-light-7);
  width: 520px;
  padding: 15px;
  border-radius: 8px;
  margin-bottom: 20px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  justify-content: center;
  align-items: center;
  transform: translateY(8px);
}

.image-container img {
  display: block;
  width: 520px;
  height: auto;
  border-radius: 4px;
}

.sub-adoption-details {
  display: flex;
  align-items: center;
  border-bottom: 5px dashed var(--el-color-primary-light-7);
  padding-bottom: 20px;
  font-size: 30px;
  margin-top: 30px;
  font-weight: bold;
}

.gender-icon {
  display: inline-block;
  vertical-align: middle;
  width: 25px;
  height: 25px;
}

.male {
  color: #00B2FF;
  margin-bottom: 5px;
}

.female {
  color: #F18383;
  margin-bottom: 5px;
}

.adoption-page-download-button {
  background-color: var(--adoption-page-button-bg-color);
  border-color: var(--adoption-page-button-bg-color);
}

.adoption-page-download-button:hover {
  background-color: var(--el-color-primary-light-3);
  border-color: var(--el-color-primary-light-3);
}
</style>
