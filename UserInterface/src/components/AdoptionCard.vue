<!--
  Project Name:  UserInterface
  File Name:     AdoptionCard.vue
  File Function: 宠物领养卡片组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-02
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='card-container'>
    <div class='card' @mouseenter='hover=true' @mouseleave='hover=false' :class='{ active: hover }'>
      <div class='image'>
        <img :src='`${ossBaseUrl}${adoptionData.imageUrl}`' alt='AdoptionPetImage'/>
      </div>
      <div class='content'>
        <div class='title-container'>
          <div class='title'>{{ adoptionData.name ? adoptionData.name : t('PetAdoptionPage.UnnamedPet') }}</div>
          <Male v-if='!adoptionData.gender' class='gender-icon male'/>
          <Female v-if='adoptionData.gender' class='gender-icon female'/>
        </div>
        <div class='info'>
          <span class='age'>
            {{ adoptionData.age }}
            {{ adoptionData.age <= 1 ? t('PetAdoptionPage.SingularAge') : t('PetAdoptionPage.PluralAge') }}
          </span>
          <span class='location'>{{ adoptionData.location }}</span>
        </div>
        <div class='status'>
          {{ adoptionData.status ? t('PetAdoptionPage.Adopted') : t('PetAdoptionPage.NotAdopted') }}
        </div>
        <div class='bottom' :class='{ active: hover }'>
          <el-text class='reason-text' truncated>
            {{ adoptionData.reason }}
          </el-text>
          <div class='tags'>
            <span class='tag'>{{ adoptionData.categoryName }}</span>
            <span class='tag'>{{ adoptionData.subcategoryName }}</span>
          </div>
          <div class='button-container'>
            <button v-if='props.isPublisher' @click='deleteAdoption' class='delete-button'>
              {{ t('NewsManagementPage.Delete') }}
            </button>
            <button @click='navigateToAdoption' class='learn-more-button'>
              {{ t('HomePage.LearnMore') }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {ref, onMounted, defineProps} from 'vue'
import {useI18n} from 'vue-i18n'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import {ossBaseUrl} from '../globals'
import {Female, Male} from '@element-plus/icons-vue'
import {useRouter} from 'vue-router'

type PetAdoptionData = {
  imageUrl: string
  name: string
  age: number
  location: string
  reason: string
  status: boolean
  gender: number
  categoryId: number
  subcategoryId: number
  categoryName: string
  subcategoryName: string
}

const router = useRouter()
const props = withDefaults(defineProps<{
  adoptionId: number
  isPublisher?: boolean
}>(), {
  isPublisher: false
})
const {t, locale} = useI18n()
const hover = ref(false)
const adoptionData = ref<PetAdoptionData>({
  imageUrl: '',
  name: '',
  age: 0,
  location: '',
  reason: '',
  status: false,
  gender: 0,
  categoryId: 0,
  subcategoryId: 0,
  categoryName: '',
  subcategoryName: ''
})

const fetchCategoryName = async (categoryId: number) => {
  try {
    const response = await axiosInstance.get(`pet-category/category-name/${categoryId}-${locale.value}`)
    adoptionData.value.categoryName = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetCategoryErrorMessage'))
  }
}

const fetchSubcategoryName = async (subcategoryId: number) => {
  try {
    const response = await axiosInstance.get(`pet-subcategory/subcategory-name/${subcategoryId}-${locale.value}`)
    adoptionData.value.subcategoryName = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetSubcategoryErrorMessage'))
  }
}

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`pet-adoption/${props.adoptionId}`)
    adoptionData.value = response.data
    await fetchCategoryName(adoptionData.value.categoryId)
    await fetchSubcategoryName(adoptionData.value.subcategoryId)
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

const navigateToAdoption = () => {
  router.push(`adoption/${props.adoptionId}`)
  window.scrollTo(0, 0)
}

async function deleteAdoption() {
  try {
    await axiosInstance.delete(`pet-adoption/${props.adoptionId}`)
  } catch (error) {
    ElMessage.error(t('ErrorMessage.DeleteErrorMessage'))
  } finally {
    window.location.reload()
  }
}
</script>

<style scoped>
:global(:root) {
  --adoption-page-background: #FAFAFA;
  --adoption-card-background: #FFFFFF;
  --adoption-card-content-title-color: #333333;
  --adoption-card-content-text-color: #666666;
  --adoption-card-content-location-color: #3498DB;
  --adoption-card-content-button-color: #3498DB;
  --adoption-card-tag-border-color: #3498DB;
  --adoption-card-tag-background: #F0FAFF;
  --adoption-card-tag-text-color: #3498DB;
  --adoption-card-status-background-color: #3498DB;
  --adoption-card-status-text-color: #FFFFFF;
  --adoption-card-delete-button-background: #FF7F7F;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --adoption-page-background: #1D1D1D;
  --adoption-card-background: #2C2C2C;
  --adoption-card-content-title-color: #E0E0E0;
  --adoption-card-content-text-color: #B0B0B0;
  --adoption-card-content-location-color: #00BFFF;
  --adoption-card-content-button-color: #004287;
  --adoption-card-tag-border-color: #236895;
  --adoption-card-tag-background: #1D5278;
  --adoption-card-tag-text-color: #FFFFFF;
  --adoption-card-status-background-color: #004287;
  --adoption-card-status-text-color: #E0E0E0;
  --adoption-card-delete-button-background: #8F2D2D;
}

.card-container {
  height: 100%;
  display: grid;
  background-color: var(--adoption-page-background);
  border-radius: 10px;
}

.card * {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  border-radius: 10px;
}

.card {
  position: relative;
  height: 470px;
  width: 360px;
  transition: 0.4s linear;
  border-radius: 10px;
  box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.1);
}

.card:hover {
  box-shadow: 0 1px 35px 0 rgba(0, 0, 0, 0.1);
  border-color: #3498DB;
}

.card .image {
  background-color: black;
  height: 400px;
  overflow: hidden;
  display: flex;
  justify-content: center;
  align-items: center;
}

.image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  transition: 0.6s linear;
}

.card.active .image img {
  opacity: 0.6;
  transform: scale(1.1);
}

.card .content {
  position: absolute;
  bottom: 0;
  background-color: var(--adoption-card-background);
  width: 100%;
  text-align: center;
  padding: 20px 30px;
}

.content .title-container {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  margin-bottom: 10px;
}

.content .title {
  font-size: 24px;
  font-weight: 600;
  color: var(--adoption-card-content-title-color);
  margin-bottom: 5px;
  justify-content: center;
}

.content .info {
  display: flex;
  justify-content: center;
  gap: 10px;
  margin-bottom: 10px;
}

.info .age {
  font-size: 16px;
  font-weight: 500;
  color: var(--adoption-card-content-text-color);
  padding-bottom: 10px;
}

.info .location {
  font-size: 16px;
  font-weight: 500;
  color: var(--adoption-card-content-location-color);
  padding-bottom: 10px;
}

.status {
  font-size: 18px;
  font-weight: 600;
  color: var(--adoption-card-status-text-color);
  background-color: var(--adoption-card-status-background-color);
  padding: 5px 10px;
  border-radius: 6px;
  margin-bottom: 3px;
}

.reason-text {
  display: -webkit-box;
  -webkit-box-orient: vertical;
  overflow: hidden;
  -webkit-line-clamp: 3;
  line-clamp: 3;
  white-space: normal;
  word-break: break-all;
  color: var(--adoption-card-content-text-color);
  font-size: 14px;
  text-align: justify;
  line-height: 1.8em;
  margin-bottom: 15px;
}

.bottom .tags {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 12px;
  margin-bottom: 10px;
}

.bottom .tag {
  background-color: var(--adoption-card-tag-background);
  border: 1px solid var(--adoption-card-tag-border-color);
  color: var(--adoption-card-tag-text-color);
  font-size: 14px;
  padding: 6px 12px;
  border-radius: 6px;
  font-weight: 500;
}

.button-container {
  display: flex;
  align-items: center;
  justify-content: flex-end;
  gap: 16px;
  margin-top: 10px;
}

.delete-button {
  background-color: var(--adoption-card-delete-button-background);
}

.learn-more-button {
  background-color: var(--adoption-card-content-button-color);
}

.button-container button {
  padding: 7px 15px;
  font-size: 17px;
  color: white;
  font-weight: 500;
  border: none;
  margin: 10px 0;
  transition: 0.3s ease;
  border-radius: 6px;
}

.button-container button:hover, .delete-button:hover {
  transform: scale(0.95);
  cursor: pointer;
}

.bottom {
  max-height: 0;
  overflow: hidden;
  transition: max-height 1s ease, padding 1s ease;
  display: flex;
  flex-direction: column;
}

.bottom.active {
  max-height: 250px;
  padding-top: 10px;
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
</style>
