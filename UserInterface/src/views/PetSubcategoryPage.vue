<!--
  Project Name:  UserInterface
  File Name:     PetSubcategoryPage.vue
  File Function: 宠物子类页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-08-05
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div style='display: flex; width: 100%; background-color: var(--pet-subcategory-page-background)'>
    <div style='width: 250px; min-width: 250px'>
      <PetEncyclopediaNavbar/>
    </div>

    <div style='width: calc(100% - 250px); min-width: 950px'>
      <!--suppress TypeScriptValidateTypes-->
      <el-breadcrumb :separator-icon='ArrowRight' class='breadcrumb-with-margin'>
        <el-breadcrumb-item to='/pet-encyclopedia'>
          {{ t('HeaderNavbar.PetEncyclopedia') }}
        </el-breadcrumb-item>
        <el-breadcrumb-item :to='`/pet-category/${pageData.categoryId}`'>
          {{ pageData.categoryName }}
        </el-breadcrumb-item>
        <el-breadcrumb-item>
          {{ pageData.subcategoryName }}
        </el-breadcrumb-item>
      </el-breadcrumb>

      <div class='pet-subcategory-page'>
        <div class='pet-subcategory-container'>
          <div class='pet-subcategory-name' style='display: block'>
            <p class='category-name' style='font-size: 36px; color: var(--el-color-primary-light-3); font-weight: bold'>
              {{ pageData.categoryName }}
            </p>
            <p class='subcategory-name'
               style='font-size: 48px; color: var(--el-color-primary-dark-2); font-weight: bold'>
              {{ pageData.subcategoryName }}
            </p>
          </div>
          <div class='pet-subcategory-img'>
            <div class='image-container'>
              <img :src='`${ossBaseUrl}${pageData.imageUrl}`' alt='PetSubcategoryImage'/>
            </div>
          </div>
        </div>

        <div style='border-bottom: 5px dashed var(--el-color-primary-light-9); padding-bottom: 20px'>
          <div class='flex-container'>
            <el-icon :size='36' class='tag-icon'>
              <CollectionTag/>
            </el-icon>
            <div class='text-container'>
              <p class='styled-light-text'>{{ t('PetSubcategoryPage.Origin') }}</p>
            </div>
            <p class='detailed-data'>{{ pageData.origin }}</p>
          </div>

          <div class='flex-container'>
            <el-icon :size='36' class='tag-icon'>
              <CollectionTag/>
            </el-icon>
            <div class='text-container'>
              <p class='styled-light-text'>{{ t('PetSubcategoryPage.Size') }}</p>
            </div>
            <p class='detailed-data'>{{ pageData.size }}</p>
          </div>

          <div class='flex-container'>
            <el-icon :size='36' class='tag-icon'>
              <CollectionTag/>
            </el-icon>
            <div class='text-container'>
              <p class='styled-light-text'>{{ t('PetSubcategoryPage.Lifespan') }}</p>
            </div>
            <p class='detailed-data'>{{ pageData.lifespan }}</p>
          </div>

          <div class='flex-container'>
            <el-icon :size='36' class='tag-icon'>
              <CollectionTag/>
            </el-icon>
            <div class='text-container'>
              <p class='styled-light-text'>{{ t('PetSubcategoryPage.Temperament') }}</p>
            </div>
            <p class='detailed-data'>{{ pageData.temperament }}</p>
          </div>

          <div class='flex-container'>
            <el-icon :size='36' class='tag-icon'>
              <CollectionTag/>
            </el-icon>
            <div class='text-container'>
              <p class='styled-light-text'>{{ t('PetSubcategoryPage.Coat') }}</p>
            </div>
            <p class='detailed-data'>{{ pageData.coat }}</p>
          </div>

          <div class='flex-container'>
            <el-icon :size='36' class='tag-icon'>
              <CollectionTag/>
            </el-icon>
            <div class='text-container'>
              <p class='styled-light-text'>{{ t('PetSubcategoryPage.Diet') }}</p>
            </div>
            <p class='detailed-data'>{{ pageData.diet }}</p>
          </div>
        </div>

        <div style='border-bottom: 5px dashed var(--el-color-primary-light-9); padding-bottom: 20px'>
          <div class='flex-container' style='margin-top: 20px; margin-bottom: 20px'>
            <p class='styled-dark-text'>{{ t('PetSubcategoryPage.Origin') }}</p>
          </div>
          <div class='image-container' style='margin-bottom: 22px; margin-left: 7px; width: 800px'>
            <img :src='originMapUrl' alt='OriginMap' style='width: 800px'/>
          </div>
        </div>

        <div>
          <div class='flex-container'
               style='margin-top: 20px; margin-bottom: -7px'>
            <p class='styled-dark-text'>{{ t('PetSubcategoryPage.Description') }}</p>
          </div>
          <p class='description-text'>
            {{ pageData.description }}
          </p>
        </div>

        <div style='padding-bottom: 20px'>
          <div v-for='guide in pageData.petCareGuideRequests'>
            <div class='flex-container' style='margin-bottom: -8px'>
              <p class='styled-dark-text'>{{ guide.title }}</p>
            </div>
            <p class='pet-care-guide-text'>{{ guide.content }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {useI18n} from 'vue-i18n'
import {useRoute, useRouter} from 'vue-router'
import {onMounted, ref, watch, computed} from 'vue'
import axiosInstance from '../utils/axios'
import {ElMessage} from 'element-plus'
import {gaodeAccessKey, ossBaseUrl} from '../globals'
import {ArrowRight, CollectionTag} from '@element-plus/icons-vue'
import PetEncyclopediaNavbar from '../components/PetEncyclopediaNavbar.vue'

const {locale, t} = useI18n()
const route = useRoute()
const router = useRouter()
const subcategoryId = ref(parseInt(<string>route.params.id))
const pageData = ref({
  subcategoryId: 0,
  categoryId: 0,
  subcategoryName: '',
  description: '',
  imageUrl: '',
  origin: '',
  size: '',
  coat: '',
  lifespan: '',
  temperament: '',
  diet: '',
  categoryName: '',
  latitudeAndLongitude: '',
  petCareGuideRequests: [{
    guideId: 0,
    subcategoryId: '',
    title: '',
    content: ''
  }]
})

if (subcategoryId.value == 0) {
  router.push('/404')
}

const fetchPageData = async () => {
  try {
    const response = await axiosInstance.get(`pet-encyclopedia/pet-subcategory-page/${subcategoryId.value}-${locale.value}`)
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

const originMapUrl = computed(() => {
  return `https://restapi.amap.com/v3/staticmap?key=${gaodeAccessKey}&zoom=2&size=1024*576&${pageData.value.latitudeAndLongitude}`
})

onMounted(() => {
  fetchPageData()
})

watch(() => route.params.id, (newId) => {
  subcategoryId.value = parseInt(<string>newId)
  fetchPageData()
})
</script>

<style scoped>
:global(:root) {
  --pet-subcategory-page-background: #FAFAFA;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --pet-subcategory-page-background: #1D1D1D;
}

.breadcrumb-with-margin {
  padding-left: 40px;
  padding-top: 25px;
  padding-bottom: 25px;
  font-size: 18px;
}

.pet-subcategory-page {
  display: flex;
  flex-direction: column;
  padding-left: 40px;
  padding-right: 40px;
}

.image-container {
  width: 600px;
  background-color: var(--el-color-primary-light-9);
  padding: 15px;
  border-radius: 8px;
  margin-bottom: 20px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  justify-content: center;
  align-items: center;
}

.image-container img {
  display: block;
  width: 600px;
  height: auto;
  border-radius: 4px;
}

.tag-icon {
  color: var(--el-color-primary-dark-2);
}

p {
  font-size: 20px;
  text-align: justify;
}

.styled-light-text {
  color: var(--el-color-primary-dark-2);
  background-color: var(--el-color-primary-light-8);
  padding: 10px 20px;
  font-size: 22px;
  font-weight: bold;
  box-shadow: 2px 2px 8px rgba(0, 0, 0, 0.3);
  border-radius: 5px;
  white-space: nowrap;
}

.styled-dark-text {
  color: var(--el-color-primary-light-8);
  background-color: var(--el-color-primary-dark-2);
  padding: 10px 20px;
  font-size: 22px;
  font-weight: bold;
  box-shadow: 2px 2px 8px rgba(0, 0, 0, 0.3);
  border-radius: 5px;
  margin-left: 7px;
}

.flex-container {
  display: flex;
  align-items: center;
}

.text-container {
  margin-left: 10px;
  margin-right: 15px;
}

.description-text {
  border-bottom: 5px dashed var(--el-color-primary-light-9);
  padding-bottom: 36px;
  line-height: 1.6;
  padding-left: 7px;
  padding-right: 7px;
}

.pet-care-guide-text {
  line-height: 1.6;
  padding-left: 7px;
  padding-right: 7px;
}

.detailed-data {
  flex: 1;
  text-align: left;
  line-height: 1.8;
}

@media (min-width: 1400px) {
  .flex-container:nth-child(1), .flex-container:nth-child(2) {
    width: 50%;
    display: inline-flex;
  }

  .flex-container:nth-child(3), .flex-container:nth-child(4) {
    width: 50%;
    display: inline-flex;
  }

  .flex-container:nth-child(5) {
    width: 100%;
  }

  .flex-container:nth-child(6) {
    width: 100%;
  }

  .pet-subcategory-container {
    position: relative;
    display: flex;
    flex-direction: row-reverse;
    justify-content: flex-end;
  }

  .category-name {
    margin-bottom: 40px;
    margin-left: 50px;
  }

  .subcategory-name {
    margin-bottom: 0;
    margin-left: 50px;
  }
}

@media (max-width: 1400px) {
  .category-name {
    margin-bottom: 0;
    margin-top: 10px;
    margin-left: 10px;
  }

  .subcategory-name {
    margin-top: 24px;
    margin-bottom: 32px;
    margin-left: 10px;
  }
}
</style>
