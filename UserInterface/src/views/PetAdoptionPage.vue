<!--
  Project Name:  UserInterface
  File Name:     PetAdoptionPage.vue
  File Function: 宠物领养页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='background-container'>
    <h1>{{ t('HeaderNavbar.PetAdoption') }}</h1>
    <div class='search-container'>
      <SearchBoxAdoption/>
    </div>
  </div>

  <div class='page-container'>
    <el-segmented style='height: 72px; margin-top: -10px' v-model='pageIndex' :options='pageOptions'>
      <template #default='{ item }'>
        <el-icon :size='24'>
          <component :is='item.icon'/>
        </el-icon>
        <div style='font-size: 16px; font-weight: bold'>{{ item.label }}</div>
      </template>
    </el-segmented>

    <div v-if="pageIndex=='1'">
      <div class='tabs'>
        <div class='tab-labels'>
          <div class='slider' :style='{ transform: `translateY(${currentIndex * 64}px)` }'/>
          <div v-for='(item, index) in tabItems'
               :key='index'
               class='tab-label'
               :class='{ active: currentIndex == index }'
               @click='selectTab(index)'>
            {{ item }}
          </div>
        </div>
        <div class='tab-content'>
          <component :is='currentTabComponent'/>
        </div>
      </div>
    </div>

    <div v-if="pageIndex=='2'">
      <div class='cards-container'>
        <div v-for='adoption in paginatedAdoptions' :key='adoption' class='card'>
          <AdoptionCard :adoption-id='adoption'/>
        </div>
        <div v-for='index in emptySlots' :key="'empty-'+index" class='card placeholder'/>
      </div>
      <div class='pagination-container'>
        <el-pagination v-model:current-page='currentPage'
                       :page-size='pageSize'
                       :total='adoptionIds.length'
                       layout='prev, pager, next'
                       @current-change='handlePageChange'/>
      </div>
    </div>

    <div v-if="pageIndex=='3'" style='position: relative'>
      <div class='image-container'>
        <img v-if='adoptionRuleForm.imageUrl'
             :src='`${ossBaseUrl}${adoptionRuleForm.imageUrl}`'
             alt='AdoptionPetImage'/>
        <el-icon v-else color='var(--adoption-text-color)' :size='80'>
          <Picture/>
        </el-icon>
      </div>

      <el-form :model='adoptionRuleForm'
               ref='adoptionRuleFormRef'
               :rules='adoptionRules'
               class='form-container'
               status-icon>
        <div style='width: 100%; display: flex; flex-direction: column; justify-content: center; align-items: center'>
          <p style='font-size: 36px; font-weight: bold; color: var(--adoption-text-color); margin: 0'>
            {{ t('PetAdoptionPage.AdoptionInformationRelease') }}
          </p>
          <p style='font-size: 24px; color: var(--adoption-text-color); margin-bottom: 40px'>
            {{ t('PetAdoptionPage.Slogan') }}
          </p>
        </div>

        <el-form-item prop='name'>
          <div class='form-label-container'>
            <div class='form-label' style='margin-left: 26px'>
              <span>{{ t('PetAdoptionPage.Name') }}</span>
            </div>
            <el-input v-model='adoptionRuleForm.name'
                      maxlength='16'
                      show-word-limit
                      size='large'
                      style='width: 380px'
                      :placeholder="t('PetAdoptionPage.NamePlaceholder')"/>
          </div>
        </el-form-item>

        <el-form-item prop='age'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <div class='form-label'>
              <span>{{ t('PetAdoptionPage.PetAge') }}</span>
            </div>
            <el-input-number v-model='adoptionRuleForm.age'
                             size='large'
                             style='width: 380px'
                             :min='0'
                             :max='100'/>
          </div>
        </el-form-item>

        <el-form-item>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <div class='form-label'>
              <span>{{ t('PetAdoptionPage.Gender') }}</span>
            </div>
            <el-select v-model='adoptionRuleForm.gender'
                       style='width: 380px'
                       size='large'>
              <el-option :label="t('PetAdoptionPage.GenderMale')" :value='false'/>
              <el-option :label="t('PetAdoptionPage.GenderFemale')" :value='true'/>
            </el-select>
          </div>
        </el-form-item>

        <el-form-item>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <div class='form-label'>
              <span>{{ t('PetAdoptionPage.PetCategory') }}</span>
            </div>
            <el-cascader v-model='selectedCategory'
                         :options='categoryOptions'
                         size='large'
                         style='width: 380px'
                         :placeholder="t('PetAdoptionPage.PetCategoryPlaceholder')"/>
          </div>
        </el-form-item>

        <el-form-item>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <div class='form-label'>
              <span>{{ t('PetAdoptionPage.NeuteredOrSpayed') }}</span>
            </div>
            <el-select v-model='adoptionRuleForm.neuteredOrSpayed'
                       style='width: 380px'
                       size='large'>
              <el-option :label="t('PetAdoptionPage.NotNeutered')" :value='false'/>
              <el-option :label="t('PetAdoptionPage.Neutered')" :value='true'/>
            </el-select>
          </div>
        </el-form-item>

        <el-form-item prop='location'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <div class='form-label'>
              <span>{{ t('PetAdoptionPage.Location') }}</span>
            </div>
            <el-cascader v-model='selectedLocation'
                         :options='locationOptions'
                         size='large'
                         style='width: 380px'
                         :placeholder="t('PetAdoptionPage.LocationPlaceholder')"
                         @change='handleLocationChange'/>
          </div>
        </el-form-item>

        <el-form-item prop='latestHealthCheck'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <div class='form-label'>
              <span>{{ t('PetAdoptionPage.LatestHealthCheck') }}</span>
            </div>
            <el-date-picker v-model='adoptionRuleForm.latestHealthCheck'
                            type='date'
                            :disabled-date='disabledDate'
                            size='large'
                            style='width: 380px'
                            :placeholder="t('PetAdoptionPage.LatestHealthCheckPlaceholder')"
                            :editable='false'
                            :clearable='false'/>
            <el-upload ref='petImage'
                       :limit='1'
                       :before-upload='handleBeforeUploadImage'
                       accept='.jpeg, .jpg'
                       :show-file-list='false'>
              <el-button size='large'
                         style='width: 157px; margin-left: 20px'
                         plain>
                <span style='color: #F56C6C; margin-right: 4px'>*</span>
                <span>{{ t('PetAdoptionPage.UploadPetImagePrompt') }}</span>
              </el-button>
            </el-upload>
            <el-upload ref='appendix'
                       :limit='1'
                       :before-upload='handleBeforeUploadAppendix'
                       accept='.pdf'
                       :show-file-list='false'>
              <el-tooltip
                  :content="adoptionRuleForm.appendixUrl == '' ? t('PetAdoptionPage.AppendixNotUploaded') : t('PetAdoptionPage.AppendixUploaded')"
                  placement='right'>
                <el-button size='large'
                           style='width: 157px; margin-left: 20px'
                           plain>
                  {{ t('PetAdoptionPage.UploadAppendixPrompt') }}
                </el-button>
              </el-tooltip>
            </el-upload>
          </div>
        </el-form-item>

        <el-form-item prop='reason'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <div class='form-label'>
              <span>{{ t('PetAdoptionPage.Reason') }}</span>
            </div>
            <el-input v-model='adoptionRuleForm.reason'
                      maxlength='256'
                      show-word-limit
                      :autosize='{ minRows: 2 }'
                      type='textarea'
                      @input="adoptionRuleForm.reason = adoptionRuleForm.reason.replace(/\n/g, '')"
                      :placeholder="t('PetAdoptionPage.ReasonPlaceholder')"/>
          </div>
        </el-form-item>

        <el-form-item prop='health'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <div class='form-label'>
              <span>{{ t('PetAdoptionPage.Health') }}</span>
            </div>
            <el-input v-model='adoptionRuleForm.health'
                      maxlength='256'
                      show-word-limit
                      :autosize='{ minRows: 2 }'
                      type='textarea'
                      @input="adoptionRuleForm.health = adoptionRuleForm.health.replace(/\n/g, '')"
                      :placeholder="t('PetAdoptionPage.HealthPlaceholder')"/>
          </div>
        </el-form-item>

        <el-form-item prop='vaccination'>
          <div class='form-label-container'>
            <span class='required-star'>*</span>
            <div class='form-label'>
              <span>{{ t('PetAdoptionPage.Vaccination') }}</span>
            </div>
            <el-input v-model='adoptionRuleForm.vaccination'
                      maxlength='256'
                      show-word-limit
                      :autosize='{ minRows: 2 }'
                      type='textarea'
                      @input="adoptionRuleForm.vaccination = adoptionRuleForm.vaccination.replace(/\n/g, '')"
                      :placeholder="t('PetAdoptionPage.VaccinationPlaceholder')"/>
          </div>
        </el-form-item>

        <el-form-item prop='careNeeds'>
          <div class='form-label-container'>
            <div class='form-label' style='margin-left: 26px'>
              <span>{{ t('PetAdoptionPage.CareNeeds') }}</span>
            </div>
            <el-input v-model='adoptionRuleForm.careNeeds'
                      maxlength='256'
                      show-word-limit
                      :autosize='{ minRows: 2 }'
                      type='textarea'
                      @input="adoptionRuleForm.careNeeds = adoptionRuleForm.careNeeds.replace(/\n/g, '')"
                      :placeholder="t('PetAdoptionPage.CareNeedsPlaceholder')"/>
          </div>
        </el-form-item>

        <el-form-item prop='dietaryNeeds'>
          <div class='form-label-container'>
            <div class='form-label' style='margin-left: 26px'>
              <span>{{ t('PetAdoptionPage.DietaryNeeds') }}</span>
            </div>
            <el-input v-model='adoptionRuleForm.dietaryNeeds'
                      maxlength='256'
                      show-word-limit
                      :autosize='{ minRows: 2 }'
                      type='textarea'
                      @input="adoptionRuleForm.dietaryNeeds = adoptionRuleForm.dietaryNeeds.replace(/\n/g, '')"
                      :placeholder="t('PetAdoptionPage.DietaryNeedsPlaceholder')"/>
          </div>
        </el-form-item>

        <el-form-item prop='behavior'>
          <div class='form-label-container'>
            <div class='form-label' style='margin-left: 26px'>
              <span>{{ t('PetAdoptionPage.Behavior') }}</span>
            </div>
            <el-input v-model='adoptionRuleForm.behavior'
                      maxlength='256'
                      show-word-limit
                      :autosize='{ minRows: 2 }'
                      type='textarea'
                      @input="adoptionRuleForm.behavior = adoptionRuleForm.behavior.replace(/\n/g, '')"
                      :placeholder="t('PetAdoptionPage.BehaviorPlaceholder')"/>
          </div>
        </el-form-item>

        <el-form-item prop='notes'>
          <div class='form-label-container'>
            <div class='form-label' style='margin-left: 26px'>
              <span>{{ t('PetAdoptionPage.Notes') }}</span>
            </div>
            <el-input v-model='adoptionRuleForm.notes'
                      maxlength='256'
                      show-word-limit
                      :autosize='{ minRows: 2 }'
                      type='textarea'
                      @input="adoptionRuleForm.notes = adoptionRuleForm.notes.replace(/\n/g, '')"
                      :placeholder="t('PetAdoptionPage.NotesPlaceholder')"/>
          </div>
        </el-form-item>

        <el-alert type='warning' show-icon :closable='false' style='padding-right: 30px; margin-top: 22px'>
          <p style='line-height: 1.6; margin-bottom: 12px; text-align: justify'>
            {{ '1. ' + t('PetAdoptionPage.AdoptionWarningPrompt1') }}</p>
          <p style='line-height: 1.6; margin-top: 12px; margin-bottom: 12px; text-align: justify'>
            {{ '2. ' + t('PetAdoptionPage.AdoptionWarningPrompt2') }}</p>
          <p style='line-height: 1.6; margin-top: 12px; text-align: justify'>
            {{ '3. ' + t('PetAdoptionPage.AdoptionWarningPrompt3') }}</p>
        </el-alert>

        <el-form-item prop='confirm'>
          <label>
            <input type='checkbox' v-model='adoptionRuleForm.confirm'>
            {{ t('PetAdoptionPage.ConfirmPrompt') }}
          </label>
        </el-form-item>

        <div style='width: 100%; display: flex; flex-direction: column; align-items: center'>
          <el-button type='primary'
                     style='width: 300px; margin-top: 12px'
                     size='large'
                     @click='submitAdoptionForm(adoptionRuleFormRef)'>
            {{ t('PetAdoptionPage.ReleaseAdoptionInformation') }}
          </el-button>
        </div>
      </el-form>
    </div>

    <div v-if="pageIndex=='4'">
      <div v-if='myAdoptionIds.length==0' class='no-adoption-container'>
        <img class='no-adoption-icon'
             :src='`${ossBaseUrl}LogosAndIcons/Edit.png`'
             alt='EditIcon'>
        <p class='no-adoption-message' v-html="t('PetAdoptionPage.NoAdoptionPrompt')"/>
        <el-button type='primary' size='large' round class='publish-button' @click="pageIndex='3'">
          {{ t('PetAdoptionPage.WantPublish') }}
        </el-button>
      </div>
      <div v-else>
        <div class='cards-container'>
          <div v-for='adoption in myAdoptionIds' :key='adoption' class='card'>
            <AdoptionCard :adoption-id='adoption' :is-publisher='true'/>
          </div>
          <div v-for='index in emptySlots' :key="'empty-'+index" class='card placeholder'/>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {useI18n} from 'vue-i18n'
import {useRouter} from 'vue-router'
import {reactive, onMounted, ref, computed} from 'vue'
import {Tickets, Files, DocumentAdd, Picture, DocumentChecked} from '@element-plus/icons-vue'
import {ElMessageBox, ElMessage, FormRules, FormInstance, UploadInstance} from 'element-plus'
import axiosInstance from '../utils/axios'
import PetAdoptionRequirements from '../components/PetAdoptionRequirements.vue'
import PetAdoptionPrecautions from '../components/PetAdoptionPrecautions.vue'
import PetAdoptionContractExample from '../components/PetAdoptionContractExample.vue'
import SearchBoxAdoption from '../components/AdoptionSearchBox.vue'
import AdoptionCard from '../components/AdoptionCard.vue'
import rawAreaData from '../chinaAreas.json'
import {ossBaseUrl} from '../globals.ts'

const {t, locale} = useI18n()
const selectedLocation = ref([])
const locationOptions = ref(transformAreaData(rawAreaData))
const router = useRouter()
const pageIndex = ref('1')
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const currentPage = ref(1)
const pageSize = ref(9)
const selectedCategory = ref(['0', '0'])
const categoryOptions = ref()
const adoptionRuleFormRef = ref<FormInstance>()
const currentIndex = ref(0)
const previousIndex = ref(0)
const tabItems = [t('PetAdoptionPage.PetAdoptionConsiderations'), t('PetAdoptionPage.PetAdoptionRequirements'), t('PetAdoptionPage.SamplePetAdoptionAgreement')]
const components = [PetAdoptionPrecautions, PetAdoptionRequirements, PetAdoptionContractExample]
const currentTabComponent = computed(() => components[currentIndex.value])
const petImage = ref<UploadInstance>()
const appendix = ref<UploadInstance>()
const adoptionIds = ref([])
const myAdoptionIds = ref([])

interface AdoptionRuleForm {
  name: string
  imageUrl: string
  age: number
  location: string
  reason: string
  health: string
  latestHealthCheck: string
  vaccination: string
  careNeeds: string
  dietaryNeeds: string
  behavior: string
  neuteredOrSpayed: boolean
  notes: string
  gender: boolean
  appendixUrl: string
  confirm: boolean
}

const adoptionRuleForm = reactive<AdoptionRuleForm>({
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
  gender: false,
  appendixUrl: '',
  confirm: false
})

const adoptionRules: FormRules = {
  age: [{required: true, message: '', trigger: 'change'}],
  location: [{required: true, message: '', trigger: 'change'}],
  reason: [{required: true, message: '', trigger: 'change'}],
  health: [{required: true, message: '', trigger: 'change'}],
  latestHealthCheck: [{required: true, message: '', trigger: 'change'}],
  vaccination: [{required: true, message: '', trigger: 'change'}],
  confirm: [{
    validator: (rule, value, callback) => {
      if (value == true) {
        callback()
      } else {
        callback(new Error(t('PetAdoptionPage.RequiredPrompt')))
      }
    },
    trigger: 'change'
  }]
}

function transformAreaData(data) {
  const provinces = Object.keys(data)
  return provinces.map(province => ({
    value: province,
    label: province,
    children: Object.keys(data[province]).map(city => ({
      value: city,
      label: city,
      children: data[province][city].map(district => ({
        value: district,
        label: district
      }))
    }))
  }))
}

const paginatedAdoptions = computed(() => {
  const start = (currentPage.value - 1) * pageSize.value
  const end = start + pageSize.value
  return adoptionIds.value.slice(start, end)
})

const emptySlots = computed(() => {
  const remainingCards = paginatedAdoptions.value.length % 3
  return remainingCards == 0 ? 0 : 3 - remainingCards
})

const loadPetCategories = async () => {
  try {
    const response = await axiosInstance.get(`pet-encyclopedia/menu-index/${locale.value}`)
    const petCategories = response.data
    categoryOptions.value = petCategories.map(category => ({
      value: category.index,
      label: category.title,
      children: category.children.map(subcategory => ({
        value: subcategory.index,
        label: subcategory.title
      }))
    }))
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
}

const handlePageChange = (page) => {
  currentPage.value = page
}

onMounted(() => {
  if (currentUserId.value == 0) {
    router.push('/login')
    ElMessageBox.alert(t('SettingsPage.PleaseLoginFirst'), t('SettingsPage.Notice'), {
      showClose: false
    })
  }
  loadPetCategories()
})

const pageOptions = ref([
  {label: t('PetAdoptionPage.PetAdoptionGuidelines'), value: '1', icon: Tickets},
  {label: t('PetAdoptionPage.PetAdoptionInformation'), value: '2', icon: Files},
  {label: t('PetAdoptionPage.AdoptionInformationRelease'), value: '3', icon: DocumentAdd},
  {label: t('PetAdoptionPage.MyReleaseAdoption'), value: '4', icon: DocumentChecked}
])

const disabledDate = (time: Date) => {
  return time.getTime() > Date.now()
}

const handleLocationChange = (value) => {
  adoptionRuleForm.location = value.join(' / ')
}

function selectTab(index: number) {
  previousIndex.value = currentIndex.value
  currentIndex.value = index
}

const submitAdoptionForm = async (formEl: FormInstance | undefined) => {
  if (!formEl) {
    return
  }
  try {
    const valid = await formEl.validate()
    if (valid) {
      if (adoptionRuleForm.imageUrl == '') {
        ElMessage.warning(t('PetAdoptionPage.RequiredUploadPetImage'))
        return
      }
      try {
        await axiosInstance.post('pet-adoption', {
          userId: currentUserId.value,
          categoryId: parseInt(selectedCategory.value[0]),
          subcategoryId: parseInt(selectedCategory.value[1]),
          name: adoptionRuleForm.name,
          imageUrl: adoptionRuleForm.imageUrl,
          age: adoptionRuleForm.age,
          location: adoptionRuleForm.location,
          reason: adoptionRuleForm.reason,
          health: adoptionRuleForm.health,
          latestHealthCheck: adoptionRuleForm.latestHealthCheck,
          vaccination: adoptionRuleForm.vaccination,
          careNeeds: adoptionRuleForm.careNeeds,
          dietaryNeeds: adoptionRuleForm.dietaryNeeds,
          behavior: adoptionRuleForm.behavior,
          neuteredOrSpayed: adoptionRuleForm.neuteredOrSpayed ? 1 : 0,
          notes: adoptionRuleForm.notes,
          status: 0,
          gender: adoptionRuleForm.gender ? 1 : 0,
          appendixUrl: adoptionRuleForm.appendixUrl
        }).then(() => window.location.reload()).catch(() => ElMessage.error(t('PetAdoptionPage.PublishAdoptionFailedPrompt')))
      } catch (error) {
        ElMessage.error(t('PetAdoptionPage.PublishAdoptionFailedPrompt'))
      }
    }
  } catch (error) {
  }
}

function beforeUploadImage(file) {
  const isJPG = file.type == 'image/jpeg'
  const isLt5M = file.size / 1024 / 1024 < 5
  if (!isJPG) {
    ElMessage.error(t('PetAdoptionPage.UploadedPetImageFormat'))
    return false
  }
  if (!isLt5M) {
    ElMessage.error(t('PetAdoptionPage.UploadedPetImageSize'))
    return false
  }
  return true
}

const handleBeforeUploadImage = async (file: File) => {
  if (!beforeUploadImage(file)) {
    return
  }
  const formData = new FormData()
  formData.append('file', file, 'petImage.jpg')
  try {
    const response = await axiosInstance.post('upload-pet-adoption-image', formData)
    adoptionRuleForm.imageUrl = response.data.fileName
    ElMessage.success(t('PetAdoptionPage.UploadPetImageSucceed'))
  } catch (error) {
    ElMessage.error(t('PetAdoptionPage.UploadPetImageFailed'))
  }
}

function beforeUploadAppendix(file) {
  const isPDF = file.type == 'application/pdf'
  const isLt10M = file.size / 1024 / 1024 < 10
  if (!isPDF) {
    ElMessage.error(t('PetAdoptionPage.UploadedAppendixFormat'))
    return false
  }
  if (!isLt10M) {
    ElMessage.error(t('PetAdoptionPage.UploadedAppendixSize'))
    return false
  }
  return true
}

const handleBeforeUploadAppendix = async (file: File) => {
  if (!beforeUploadAppendix(file)) {
    return
  }
  const formData = new FormData()
  formData.append('file', file, 'appendix.pdf')
  try {
    const response = await axiosInstance.post('upload-pet-adoption-appendix', formData)
    adoptionRuleForm.appendixUrl = response.data.fileName
    ElMessage.success(t('PetAdoptionPage.UploadAppendixSucceed'))
  } catch (error) {
    ElMessage.error(t('PetAdoptionPage.UploadAppendixFailed'))
  }
}

onMounted(async () => {
  try {
    const response = await axiosInstance.get('pet-adoption/ids')
    adoptionIds.value = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

onMounted(async () => {
  try {
    const response = await axiosInstance.get(`pet-adoption/ids/user-${currentUserId.value}`)
    myAdoptionIds.value = response.data
  } catch (error) {
  }
})
</script>

<style scoped>
:global(:root) {
  --adoption-background-image: linear-gradient(rgba(255, 255, 255, 0.2), rgba(255, 255, 255, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetAdoptionPageBackgroundImage.jpg');
  --adoption-title-color: #0D616A;
  --adoption-title-shadow-color: #34A4BA;
  --adoption-text-color: #002060;
  --adoption-slider-background-color: #82B8FF;
  --adoption-slider-default-text-color: #818181;
  --adoption-slider-active-text-color: #FEFEFE;
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --adoption-background-image: linear-gradient(rgba(0, 0, 0, 0.2), rgba(0, 0, 0, 0.2)), url('[TODO: ossBaseUrl]BackgroundImages/PetAdoptionPageBackgroundImage.jpg');
  --adoption-title-color: #74DAEC;
  --adoption-title-shadow-color: #3B7C88;
  --adoption-text-color: #BDD7EE;
  --adoption-slider-background-color: #004287;
  --adoption-slider-default-text-color: #ACACAC;
  --adoption-slider-active-text-color: #F4F4F4;
}

.page-container {
  width: 1200px;
  max-width: 100%;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  z-index: 1;
  min-height: calc(100vh - 665px);
}

h1 {
  width: 1200px;
  position: absolute;
  top: 12%;
  left: 50%;
  font-size: 64px;
  font-weight: bold;
  color: var(--adoption-title-color);
  text-align: center;
  transform: translateX(-50%);
  text-shadow: 0 2px 4px var(--adoption-title-shadow-color);
}

.search-container {
  position: absolute;
  top: 250px;
  left: 50%;
  transform: translateX(-50%);
}

.background-container {
  height: 530px;
  width: 100%;
  background-image: var(--adoption-background-image);
  background-size: cover;
  background-position: center;
  transform: translateY(-10px);
  z-index: 2;
}

.form-container {
  padding: 40px;
  display: flex;
  flex-direction: column;
  background-color: var(--el-color-primary-light-9);
}

.form-label-container {
  display: flex;
  align-items: center;
  width: 100%;
}

.form-label {
  margin-right: 30px;
  padding-left: 15px;
  padding-right: 15px;
  flex: 0 0 300px;
  align-content: center;
  height: 40px;
  white-space: nowrap;
  background: var(--el-color-primary-light-5);
  border-radius: 4px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  font-size: 16px;
}

.required-star {
  color: #F56C6C;
  margin-right: 15px;
  font-size: 24px;
}

.cards-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: flex-start;
}

.card {
  margin: 20px;
}

.card.placeholder {
  visibility: hidden;
  margin: 10px;
}

.pagination-container {
  display: flex;
  justify-content: center;
  margin-bottom: 18px;
}

.tabs {
  display: flex;
}

.tab-labels {
  position: relative;
  width: 297px;
  display: flex;
  flex-direction: column;
  padding: 2px;
}

.tab-label {
  cursor: pointer;
  position: relative;
  font-size: 16px;
  padding: 20px 20px 23px;
  color: var(--adoption-slider-default-text-color);
}

.tab-label.active {
  font-weight: bold;
  color: var(--adoption-slider-active-text-color);
}

.slider {
  position: absolute;
  width: calc(100% - 4px);
  height: 62px;
  background-color: var(--adoption-slider-background-color);
  transition: transform 0.2s ease;
  border-radius: 2px 16px 16px 2px;
}

.tab-content {
  width: 899px;
}

.image-container {
  background-color: var(--el-color-primary-light-7);
  width: 318px;
  height: 314px;
  padding: 8px;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  position: absolute;
  right: 40px;
  top: 182px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.image-container img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  border-radius: 4px;
}

.no-adoption-container {
  max-width: 1200px;
  text-align: center;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 20px;
  margin-bottom: 20px;
}

.no-adoption-icon {
  height: 140px;
  margin-top: 40px;
}

.no-adoption-message {
  font-size: 26px;
  color: #1296DB;
  margin-bottom: 40px;
  line-height: 2;
  font-weight: 700;
}

.publish-button {
  width: 200px;
  font-size: 20px;
  margin-bottom: 20px;
  height: 45px;
  font-weight: bold;
}
</style>
