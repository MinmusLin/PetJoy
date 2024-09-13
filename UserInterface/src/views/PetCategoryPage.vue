<!--
  Project Name:  UserInterface
  File Name:     PetCategoryPage.vue
  File Function: 宠物分类页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-27
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div style='display: flex; width: 100%; background-color: var(--pet-category-page-background)'>
    <div style='width: 250px'>
      <PetEncyclopediaNavbar/>
    </div>

    <div style='flex: 1'>
      <!--suppress TypeScriptValidateTypes-->
      <el-breadcrumb :separator-icon='ArrowRight' class='breadcrumb-with-margin'>
        <el-breadcrumb-item to='/pet-encyclopedia'>{{ t('HeaderNavbar.PetEncyclopedia') }}</el-breadcrumb-item>
        <el-breadcrumb-item>{{ pageData.categoryName }}</el-breadcrumb-item>
      </el-breadcrumb>

      <div class='pet-category-page'>
        <div class='category-item'>
          <img :src='`${ossBaseUrl}${pageData.imageUrl}`' alt='PetCategoryImage' class='category-image'/>
          <div class='category-info'>
            <h1 :style="{ color: 'var(--category-name-color)' }">{{ pageData.categoryName }}</h1>
            <p>{{ pageData.description }}</p>
          </div>
        </div>

        <div class='subcategory-list'>
          <div v-for='subcategory in pageData.petSubcategoryRequests'
               :key='subcategory.subcategoryName'
               class='subcategory-item'
               @click='router.push(`/pet-subcategory/${subcategory.subcategoryId}`)'>
            <img :src='`${ossBaseUrl}${subcategory.imageUrl}`' alt='PetSubcategoryImage' class='subcategory-image'/>
            <p>{{ subcategory.subcategoryName }}</p>
          </div>
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
import {ElMessage} from 'element-plus'
import {ossBaseUrl} from '../globals'
import {ArrowRight} from '@element-plus/icons-vue'
import PetEncyclopediaNavbar from '../components/PetEncyclopediaNavbar.vue'

const {locale, t} = useI18n()
const router = useRouter()
const route = useRoute()
const categoryId = ref(parseInt(<string>route.params.id))

if (categoryId.value == 0) {
  router.push('/404')
}

type PetSubcategory = {
  subcategoryId: number
  subcategoryName: string
  imageUrl: string
}

type PageData = {
  categoryName: string
  description: string
  imageUrl: string
  petSubcategoryRequests: PetSubcategory[]
}

const pageData = ref<PageData>({
  categoryName: '',
  description: '',
  imageUrl: '',
  petSubcategoryRequests: []
})

const fetchPageData = async () => {
  try {
    const response = await axiosInstance.get(`pet-encyclopedia/pet-category-page/${categoryId.value}-${locale.value}`)
    if (response.status == 404) {
      await router.push('/404')
    } else {
      pageData.value = response.data
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
  fetchPageData()
})

watch(() => route.params.id, (newId) => {
  categoryId.value = parseInt(<string>newId)
  fetchPageData()
})
</script>

<style scoped>
:global(:root) {
  --pet-category-page-background: #FAFAFA;
  --pet-card-background-color: #FFFFFF;
  --pet-card-background-color-hover: #E9E9EB;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --pet-category-page-background: #1D1D1D;
  --pet-card-background-color: #303030;
  --pet-card-background-color-hover: #4C4D4F;
}

.pet-category-page {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding-left: 40px;
  padding-right: 40px;
}

.breadcrumb-with-margin {
  padding-left: 40px;
  padding-top: 25px;
  padding-bottom: 25px;
  font-size: 18px;
}

.category-item {
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: justify;
  margin-bottom: 30px;
  background-color: var(--pet-card-background-color);
  border-radius: 12px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  padding: 40px 40px 34px 40px;
  box-sizing: border-box;
  transition: background-color 0.3s, box-shadow 0.3s, color 0.3s;
}

.category-image {
  max-width: 100%;
  border-radius: 12px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
}

.category-info {
  display: flex;
  flex-direction: column;
  align-items: center;
  line-height: 1.6;
}

.subcategory-list {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 20px;
  width: 100%;
  padding-bottom: 40px;
}

.subcategory-item {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  background: var(--pet-card-background-color);
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: background-color 0.3s, box-shadow 0.3s, color 0.3s;
  cursor: pointer;
}

.subcategory-image {
  margin-top: calc(5%);
  max-width: 90%;
  object-fit: cover;
  border-radius: 8px;
}

.category-info h1 {
  margin: 0;
  font-size: 24px;
}

.category-info p {
  margin: 10px 0 0;
}

.subcategory-item:hover {
  background: var(--pet-card-background-color-hover);
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.3);
}

@media (min-width: 1400px) {
  .category-item {
    flex-direction: row;
    padding: 40px 40px 40px 40px;
  }

  .category-image {
    max-width: 600px;
    margin-bottom: 0;
    margin-right: 40px;
  }

  .subcategory-list {
    grid-template-columns: repeat(3, 1fr);
  }
}
</style>
