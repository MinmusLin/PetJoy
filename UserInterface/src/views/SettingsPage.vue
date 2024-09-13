<!--
  Project Name:  UserInterface
  File Name:     SettingsPage.vue
  File Function: 设置页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='background-container'>
    <div style='display: flex; justify-content: space-between'>
      <div style='display: flex; margin-bottom: -15px; margin-top: 17px;'>
        <el-avatar style='margin-top: 1px' size='large' :src='`${ossBaseUrl}${user.avatarUrl}`'>
          <el-icon :size='36'>
            <Avatar/>
          </el-icon>
        </el-avatar>
        <div style='margin-left: 12px'>
          <h2 style='margin-top: 0; margin-bottom: 6px'>{{ user.userName }}</h2>
          <div style='display: flex'>
            <p style='font-size: 14px; margin-top: 0'>{{ t('SettingsPage.RegistrationDate') + registrationDate }}</p>
            <el-divider direction='vertical' style='margin-top: 1px'/>
            <p style='font-size: 14px; margin-top: 0'>{{ t('SettingsPage.LastLoginTime') + lastLoginTime }}</p>
          </div>
        </div>
      </div>

      <el-button-group style='margin-top: 28px'>
        <!--suppress TypeScriptValidateTypes-->
        <el-button type='primary' plain size='large' :icon='Refresh' @click='resetSettings'>{{
            t('SettingsPage.Reset')
          }}
        </el-button>
        <!--suppress TypeScriptValidateTypes-->
        <el-button type='primary' size='large' :icon='Setting' @click='saveSettings'>{{
            t('SettingsPage.Save')
          }}
        </el-button>
      </el-button-group>
    </div>

    <el-divider content-position='left'>{{ t('SettingsPage.AccountSettings') }}</el-divider>

    <div>
      <el-tabs tab-position='left'>
        <el-tab-pane>
          <template #label>
            <span>
              <el-icon class='icon-align'><User/></el-icon>
              <span>{{ ' ' + t('SettingsPage.PersonalInformation') }}</span>
            </span>
          </template>

          <div class='tab-content'>
            <h2>{{ t('SettingsPage.PersonalInformation') }}</h2>

            <p>{{ t('SettingsPage.Profile') }}</p>
            <!--suppress TypeScriptValidateTypes-->
            <el-input v-model='user.profile'
                      size='large'
                      maxlength='128'
                      style='width: 360px'
                      :prefix-icon='Edit'
                      :placeholder="t('SettingsPage.ProfilePrompt')"
                      autocomplete='off'
                      show-word-limit/>
            <p>{{ t('SettingsPage.Gender') }}</p>
            <el-select v-model='user.gender'
                       size='large'
                       :placeholder="t('SettingsPage.GenderPrompt')"
                       style='width: 360px'>
              <el-option :label="t('SettingsPage.Male')" :value='0'/>
              <el-option :label="t('SettingsPage.Female')" :value='1'/>
            </el-select>
            <p>{{ t('SettingsPage.Birthdate') }}</p>
            <el-date-picker v-model='user.birthdate'
                            type='date'
                            :disabled-date='disabledDate'
                            style='width: 360px'
                            size='large'
                            :placeholder="t('SettingsPage.BirthdatePrompt')"
                            :editable='false'
                            :clearable='false'/>

            <div @click='showAvatarCropper=true' class='avatar-wrapper'>
              <el-avatar :src='`${ossBaseUrl}${user.avatarUrl}`' class='avatar-image'>
                <el-icon :size='150'>
                  <Avatar/>
                </el-icon>
              </el-avatar>
              <div class='avatar-overlay'>
                <span class='upload-text'>{{ t('AvatarCropper.UploadAvatar') }}</span>
              </div>
            </div>
          </div>
        </el-tab-pane>

        <el-tab-pane>
          <template #label>
            <span>
              <el-icon class='icon-align'><Lock/></el-icon>
              <span>{{ ' ' + t('SettingsPage.SecuritySettings') }}</span>
            </span>
          </template>

          <div class='tab-content'>
            <h2>{{ t('SettingsPage.SecuritySettings') }}</h2>

            <div style='width: 360px; display: flex; flex-direction: column; padding-bottom: 20px'>
              <!--suppress TypeScriptValidateTypes-->
              <el-button size='large'
                         :icon='Lock'
                         style='justify-content: flex-start'
                         @click="router.push('/reset-password')">
                {{ t('SettingsPage.ChangePassword') }}
              </el-button>
            </div>

            <div style='width: 360px; display: flex; flex-direction: column; padding-bottom: 20px'>
              <!--suppress TypeScriptValidateTypes-->
              <el-button size='large'
                         :icon='Phone'
                         style='justify-content: flex-start'
                         @click="router.push('/change-telephone')">
                {{ t('SettingsPage.ChangeBoundTelephone') }}
              </el-button>
            </div>

            <div style='width: 360px; display: flex; flex-direction: column'>
              <!--suppress TypeScriptValidateTypes-->
              <el-popconfirm :title="t('SettingsPage.ConfirmDeleteAccount')"
                             :confirm-button-text="t('SettingsPage.Yes')"
                             :cancel-button-text="t('SettingsPage.No')"
                             :icon='WarningFilled'
                             width='360px'
                             :hide-after='0'
                             icon-color='#F56C6C'
                             @confirm="router.push('/delete-account')">
                <template #reference>
                  <!--suppress TypeScriptValidateTypes-->
                  <el-button size='large'
                             :icon='Delete'
                             plain
                             type='danger'
                             style='justify-content: flex-start'>
                    {{ t('SettingsPage.DeleteAccount') }}
                  </el-button>
                </template>
              </el-popconfirm>
            </div>
          </div>
        </el-tab-pane>

        <el-tab-pane>
          <template #label>
            <span>
              <el-icon class='icon-align'><View/></el-icon>
              <span>{{ ' ' + t('SettingsPage.PrivacySettings') }}</span>
            </span>
          </template>

          <div class='tab-content'>
            <h2>{{ t('SettingsPage.PrivacySettings') }}</h2>
            <div class='checkbox-group'>
              <el-checkbox v-model='userSetting.isTelephonePublic'
                           :label="t('SettingsPage.IsTelephonePublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isRegistrationDatePublic'
                           :label="t('SettingsPage.IsRegistrationDatePublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isProfilePublic'
                           :label="t('SettingsPage.IsProfilePublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isGenderPublic'
                           :label="t('SettingsPage.IsGenderPublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isBirthdatePublic'
                           :label="t('SettingsPage.IsBirthdatePublic')"
                           size='large'/>
              <el-checkbox v-model='(userSetting.isLevelPublic)'
                           :label="t('SettingsPage.IsLevelPublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isFollowingCountPublic'
                           :label="t('SettingsPage.IsFollowingCountPublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isFollowersCountPublic'
                           :label="t('SettingsPage.IsFollowersCountPublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isFavoritesCountPublic'
                           :label="t('SettingsPage.IsFavoritesCountPublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isFavoredCountPublic'
                           :label="t('SettingsPage.IsFavoredCountPublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isLikesCountPublic'
                           :label="t('SettingsPage.IsLikesCountPublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isLikedCountPublic'
                           :label="t('SettingsPage.IsLikedCountPublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.isMessageCountPublic'
                           :label="t('SettingsPage.IsMessageCountPublic')"
                           size='large'/>
              <el-checkbox v-model='userSetting.allowFollowing'
                           :label="t('SettingsPage.AllowFollowing')"
                           size='large'/>
            </div>
          </div>
        </el-tab-pane>
      </el-tabs>
    </div>
  </div>

  <el-dialog v-model='showAvatarCropper'
             :title="t('AvatarCropper.UploadAvatar')"
             :close-on-click-modal='false'
             :close-on-press-escape='false'
             style='width: 532px; height: auto'
             :key='dialogKey'
             align-center>
    <AvatarCropper :current-user-id='currentUserId'/>
  </el-dialog>
</template>

<script setup lang='ts'>
import {onMounted, ref, watch} from 'vue'
import {ElMessage, ElMessageBox, ElNotification} from 'element-plus'
import {useI18n} from 'vue-i18n'
import axiosInstance from '../utils/axios'
import {
  User,
  Lock,
  Refresh,
  Setting,
  View,
  Avatar,
  Edit,
  Phone,
  Delete,
  WarningFilled
} from '@element-plus/icons-vue'
import {formatDateTimeToCST, ossBaseUrl} from '../globals'
import AvatarCropper from '../components/AvatarCropper.vue'
import {useRouter} from 'vue-router'

const {t} = useI18n()
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const registrationDate = ref('')
const lastLoginTime = ref('')
const showAvatarCropper = ref(false)
const dialogKey = ref(Date.now())
const router = useRouter()

onMounted(() => {
  if (currentUserId.value == 0) {
    router.push('/login')
    ElMessageBox.alert(t('SettingsPage.PleaseLoginFirst'), t('SettingsPage.Notice'), {
      showClose: false
    })
  }
})

const user = ref({
  userId: 0,
  userName: '',
  password: '',
  telephone: '',
  registrationDate: '',
  lastLoginTime: '',
  role: 0,
  status: 0,
  avatarUrl: '',
  profile: '',
  gender: t('RegisterPage.Male'),
  birthdate: '',
  experiencePoints: 0,
  followsCount: 0,
  followedCount: 0,
  favoritesCount: 0,
  favoritedCount: 0,
  likesCount: 0,
  likedCount: 0,
  messageCount: 0
})

const duplicateUser = ref({
  userId: 0,
  userName: '',
  password: '',
  telephone: '',
  registrationDate: '',
  lastLoginTime: '',
  role: 0,
  status: 0,
  avatarUrl: '',
  profile: '',
  gender: t('RegisterPage.Male'),
  birthdate: '',
  experiencePoints: 0,
  followsCount: 0,
  followedCount: 0,
  favoritesCount: 0,
  favoritedCount: 0,
  likesCount: 0,
  likedCount: 0,
  messageCount: 0
})

const userSetting = ref({
  userId: 0,
  isTelephonePublic: false,
  isRegistrationDatePublic: false,
  isProfilePublic: false,
  isGenderPublic: false,
  isBirthdatePublic: false,
  isLevelPublic: false,
  isFollowingCountPublic: false,
  isFollowersCountPublic: false,
  isFavoritesCountPublic: false,
  isFavoredCountPublic: false,
  isLikesCountPublic: false,
  isLikedCountPublic: false,
  isMessageCountPublic: false,
  allowFollowing: false,
  receiveAdminNotifications: false,
  receiveUserNotifications: false
})

const duplicateUserSetting = ref({
  userId: 0,
  isTelephonePublic: false,
  isRegistrationDatePublic: false,
  isProfilePublic: false,
  isGenderPublic: false,
  isBirthdatePublic: false,
  isLevelPublic: false,
  isFollowingCountPublic: false,
  isFollowersCountPublic: false,
  isFavoritesCountPublic: false,
  isFavoredCountPublic: false,
  isLikesCountPublic: false,
  isLikedCountPublic: false,
  isMessageCountPublic: false,
  allowFollowing: false,
  receiveAdminNotifications: false,
  receiveUserNotifications: false
})

onMounted(async () => {
  if (currentUserId.value != 0) {
    try {
      const response = await axiosInstance.get(`user/${currentUserId.value}`)
      user.value = response.data
      duplicateUser.value = {...user.value}
      user.value.birthdate = formatDateTimeToCST(response.data.birthdate).dateTime
      registrationDate.value = formatDateTimeToCST(user.value.registrationDate).date
      lastLoginTime.value = formatDateTimeToCST(user.value.lastLoginTime).dateTime
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
})

onMounted(async () => {
  if (currentUserId.value != 0) {
    try {
      const response = await axiosInstance.get(`user-setting/${currentUserId.value}`)
      userSetting.value = mapToBoolean(response.data)
      duplicateUserSetting.value = {...userSetting.value}
    } catch (error) {
      ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    }
  }
})

watch(showAvatarCropper, (newVal) => {
  if (newVal) {
    dialogKey.value = Date.now()
  }
})

function mapToBoolean(data) {
  Object.keys(data).forEach(key => {
    data[key] = Boolean(data[key])
  })
  return data
}

function resetSettings() {
  userSetting.value = {...duplicateUserSetting.value}
  user.value = {...duplicateUser.value}
  user.value.birthdate = formatDateTimeToCST(duplicateUser.value.birthdate).date
}

const disabledDate = (time: Date) => {
  return time.getTime() > Date.now()
}

function saveSettings() {
  try {
    axiosInstance.put(`user-setting/${currentUserId.value}`, {
      userId: currentUserId.value,
      isTelephonePublic: userSetting.value.isTelephonePublic ? 1 : 0,
      isRegistrationDatePublic: userSetting.value.isRegistrationDatePublic ? 1 : 0,
      isProfilePublic: userSetting.value.isProfilePublic ? 1 : 0,
      isGenderPublic: userSetting.value.isGenderPublic ? 1 : 0,
      isBirthdatePublic: userSetting.value.isBirthdatePublic ? 1 : 0,
      isLevelPublic: userSetting.value.isLevelPublic ? 1 : 0,
      isFollowingCountPublic: userSetting.value.isFollowingCountPublic ? 1 : 0,
      isFollowersCountPublic: userSetting.value.isFollowersCountPublic ? 1 : 0,
      isFavoritesCountPublic: userSetting.value.isFavoritesCountPublic ? 1 : 0,
      isFavoredCountPublic: userSetting.value.isFavoredCountPublic ? 1 : 0,
      isLikesCountPublic: userSetting.value.isLikesCountPublic ? 1 : 0,
      isLikedCountPublic: userSetting.value.isLikedCountPublic ? 1 : 0,
      isMessageCountPublic: userSetting.value.isMessageCountPublic ? 1 : 0,
      allowFollowing: userSetting.value.allowFollowing ? 1 : 0,
      receiveAdminNotifications: userSetting.value.receiveAdminNotifications ? 1 : 0,
      receiveUserNotifications: userSetting.value.receiveUserNotifications ? 1 : 0
    })
    axiosInstance.put(`user/personal-information/${currentUserId.value}`, {
      profile: user.value.profile,
      gender: user.value.gender,
      birthdate: user.value.birthdate
    })
    ElNotification({
      title: t('SettingsPage.SaveSettingsSuccessfully'),
      message: t('SettingsPage.SaveSettingsSuccessfullyPrompt'),
      type: 'success',
    })
  } catch (error) {
    ElNotification({
      title: t('SettingsPage.SaveSettingsFailed'),
      message: t('SettingsPage.SaveSettingsFailedPrompt'),
      type: 'error',
    })
  }
}
</script>

<style scoped>
.background-container {
  width: 1200px;
  max-width: 100%;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  padding-left: 20px;
  padding-right: 20px;
  box-sizing: border-box;
}

h2 {
  margin-top: 14px;
}

.tab-content {
  padding-left: 24px;
  display: flex;
  flex-direction: column;
}

.icon-align {
  position: relative;
  top: 3px;
}

.checkbox-group {
  display: flex;
  flex-direction: column;
}

.avatar-wrapper {
  position: absolute;
  cursor: pointer;
  width: 300px;
  height: 300px;
  overflow: hidden;
  top: 0;
  right: 0;
  border-radius: 50%;
}

.avatar-wrapper .avatar-overlay {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  border-radius: 50%;
  display: flex;
  justify-content: center;
  align-items: center;
  color: white;
  font-size: 20px;
  opacity: 0;
  transition: opacity 0.3s;
}

.avatar-wrapper:hover .avatar-overlay {
  opacity: 1;
}

.avatar-image {
  height: 300px;
  width: 300px;
}
</style>

<style>
/* noinspection CssUnusedSymbol */
.el-tabs__item {
  justify-content: left !important;
  height: 60px;
  font-size: 16px;
}

/* noinspection CssUnusedSymbol */
.el-checkbox__label {
  font-size: 16px !important;
}
</style>
