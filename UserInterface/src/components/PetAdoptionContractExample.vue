<!--
  Project Name:  UserInterface
  File Name:     PetAdoptionContractExample.vue
  File Function: 宠物领养合同示例组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-30
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='header-container'>
    <h1 v-if="$i18n.locale == 'de'">Haustier-Adoptionsvertrag</h1>
    <h1 v-else-if="$i18n.locale == 'en'">Pet Adoption Contract</h1>
    <h1 v-else-if="$i18n.locale == 'es'">Contrato de Adopción de Mascotas</h1>
    <h1 v-else-if="$i18n.locale == 'fr'">Contrat d'Adoption</h1>
    <h1 v-else-if="$i18n.locale == 'it'">Contratto Di Adozione Animale</h1>
    <h1 v-else-if="$i18n.locale == 'ja'">ペット養子縁組契約書</h1>
    <h1 v-else-if="$i18n.locale == 'ko'">반려동물 입양 계약서</h1>
    <h1 v-else-if="$i18n.locale == 'pt'">Contrato de adoção</h1>
    <h1 v-else-if="$i18n.locale == 'ru'">Контракт на усыновление питомца</h1>
    <h1 v-else>宠物领养合同</h1>

    <el-dropdown>
      <span style='outline: none'>
        {{ t('PetAdoptionContractExample.DownloadContractTemplates') }}
        <el-icon>
          <ArrowDown/>
        </el-icon>
      </span>

      <template #dropdown>
        <el-dropdown-menu>
          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='Download' @click="downloadFile($i18n.locale, 'pdf')">
            {{ t('PetAdoptionContractExample.DownloadPDFFile') }}
          </el-dropdown-item>
          <!--suppress TypeScriptValidateTypes-->
          <el-dropdown-item :icon='Download' @click="downloadFile($i18n.locale, 'docx')">
            {{ t('PetAdoptionContractExample.DownloadWordFile') }}
          </el-dropdown-item>
        </el-dropdown-menu>
      </template>
    </el-dropdown>
  </div>

  <iframe style='height: 1200px; width: 100%; border: none'
          :src='`PetAdoptionContractExamples/PetAdoptionContractExample${$i18n.locale[0].toUpperCase()}${$i18n.locale[1]}.pdf#toolbar=0&view=FitH`'/>
</template>

<script setup lang='ts'>
import {Download, ArrowDown} from '@element-plus/icons-vue'
import {ossBaseUrl} from '../globals'
import {useI18n} from 'vue-i18n'

const {t} = useI18n()
const downloadFile = (language: string, fileType: string) => {
  const linkUrl = `${ossBaseUrl}PetAdoptionContractExamples/PetAdoptionContractExample${language[0].toUpperCase()}${language[1]}.${fileType}`
  window.open(linkUrl, '_blank')
}
</script>

<style scoped>
h1 {
  margin-top: 0;
  margin-bottom: 0;
}

.header-container {
  display: flex;
  justify-content: space-between;
  align-items: flex-end;
  padding-top: 20px;
  padding-bottom: 20px;
}
</style>
