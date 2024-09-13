<!--
  Project Name:  UserInterface
  File Name:     NotFoundPage.vue
  File Function: 404NotFound页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='not-found-container'>
    <img :src='`${ossBaseUrl}LogosAndIcons/PetJoyLogo.png`' style='height: 300px' alt='PetJoyLogo'>

    <h1 ref='NotFoundPagePrompt1'/>
    <p ref='NotFoundPagePrompt2'/>

    <p>
      <el-button-group>
        <!--suppress TypeScriptValidateTypes-->
        <el-button type='primary' size='large' plain round :icon='House' @click="router.push('/')">{{
            t('NotFoundPage.BackToHome')
          }}
        </el-button>
        <!--suppress TypeScriptValidateTypes-->
        <el-button type='primary' size='large' plain round :icon='Star' @click="router.push('/about-petjoy')">{{
            t('FooterNavbar.AboutPetJoy')
          }}
        </el-button>
        <!--suppress TypeScriptValidateTypes-->
        <el-button type='primary' size='large' plain round :icon='ChatLineSquare' @click='showContactUs=true'>{{
            t('FooterNavbar.ContactUs')
          }}
        </el-button>
      </el-button-group>
    </p>

    <el-dialog v-model='showContactUs' width='560px' :show-close='false' align-center>
      <template #title>
        <div v-html="t('FooterNavbar.PetJoyDevelopmentTeamContactDetails')" class='dialog-title'/>
      </template>
      <div class='teams-table'>
        <el-table :data='developmentTeam' stripe style='width: 520px' :empty-text="t('FooterNavbar.NoData')">
          <el-table-column prop='name' :label="t('FooterNavbar.Member')" align='center' width='120px'/>
          <el-table-column prop='email' :label="t('FooterNavbar.Email')" align='center' width='240px'>
            <template v-slot:default='{ row }'>
              <!--suppress TypeScriptUnresolvedReference -->
              <el-link :underline='false' :href="'mailto:'+row.email" target='_blank'>{{ row.email }}</el-link>
            </template>
          </el-table-column>
          <el-table-column :label="t('FooterNavbar.GitHubProfile')" align='center' width='160px'>
            <template v-slot:default='{ row }'>
              <!--suppress TypeScriptUnresolvedReference -->
              <el-link :underline='false' :href='row.githubProfile' target='_blank'>{{ row.githubName }}</el-link>
            </template>
          </el-table-column>
        </el-table>
      </div>
    </el-dialog>
  </div>
</template>

<script setup lang='ts'>
import {ref, onMounted} from 'vue'
import {useRouter} from 'vue-router'
import {ElMessage} from 'element-plus'
import {House, Star, ChatLineSquare} from '@element-plus/icons-vue'
import {useI18n} from 'vue-i18n'
import axiosInstance from '../utils/axios'
import {ossBaseUrl} from '../globals'
import TypeIt from 'typeit'

const {t} = useI18n()
const router = useRouter()
const showContactUs = ref(false)
const developmentTeam = ref([])
const NotFoundPagePrompt1 = ref('')
const NotFoundPagePrompt2 = ref('')

onMounted(() => {
  const stringToType = t('NotFoundPage.NotFoundPagePrompt1')
  const speedPerCharacter = 1500 / stringToType.length
  new (TypeIt)(NotFoundPagePrompt1.value, {
    strings: [stringToType],
    speed: speedPerCharacter,
    lifeLike: true,
    cursor: false,
    loop: false
  }).go()
})

onMounted(() => {
  const stringToType = t('NotFoundPage.NotFoundPagePrompt2')
  const speedPerCharacter = 1500 / stringToType.length
  new (TypeIt)(NotFoundPagePrompt2.value, {
    strings: [stringToType],
    speed: speedPerCharacter,
    lifeLike: true,
    cursor: false,
    loop: false
  }).go()
})

onMounted(async () => {
  try {
    const response = await axiosInstance.get('development-team')
    developmentTeam.value = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})
</script>

<style scoped>
.not-found-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  max-width: 100%;
  justify-content: center;
  height: calc(100vh - 135px);
}

h1 {
  margin-top: 2rem;
  color: var(--el-color-primary-dark-2);
}

.dialog-title {
  width: 100%;
  text-align: center;
  font-size: 20px;
}
</style>
