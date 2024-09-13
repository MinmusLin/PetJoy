<!--
  Project Name:  UserInterface
  File Name:     PostCommentReportManagementPage.vue
  File Function: 帖子评论举报管理页面
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-07
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div class='page-container'>
    <h1 style='display: flex; justify-content: center; align-items: center'>
      {{ t('HeaderNavbar.PostCommentReportManagement') }}
    </h1>
    <el-table ref='tableRef'
              :data='commentReportData'
              stripe
              border
              style='width: 100%; margin-bottom: 32px'
              :empty-text="t('FooterNavbar.NoData')"
              @sort-change='handleSortChange'>
      <el-table-column prop='reporterName'
                       :label="t('PostCommentReportManagementPage.Reporter')"
                       width='100'
                       align='center'>
        <template #default='{ row }'>
          <!--suppress TypeScriptUnresolvedReference-->
          <span class='hover-blue' @click='navigateToUser(row.reporterId)'>
            {{ row.reporterName }}
          </span>
        </template>
      </el-table-column>

      <el-table-column prop='reportedUserName'
                       :label="t('PostCommentReportManagementPage.ReportedUser')"
                       width='100'
                       align='center'>
        <template #default='{ row }'>
          <!--suppress TypeScriptUnresolvedReference-->
          <span class='hover-blue' @click='navigateToUser(row.reportedUserId)'>
            {{ row.reportedUserName }}
          </span>
        </template>
      </el-table-column>

      <el-table-column prop='title'
                       :label="t('PostCommentReportManagementPage.ReportedPost')"
                       width='230'
                       align='center'>
        <template #default='{ row }'>
          <!--suppress TypeScriptUnresolvedReference-->
          <span class='hover-blue' @click='navigateToPost(row.reportedPostId)'>
            {{ row.title }}
          </span>
        </template>
      </el-table-column>

      <el-table-column prop='content'
                       :label="t('PostCommentReportManagementPage.ReportedComment')"
                       width='230'
                       align='center'>
        <!--suppress TypeScriptUnresolvedReference -->
        <template #default='{ row }'>
          {{ row.content }}
        </template>
      </el-table-column>

      <el-table-column prop='reportReason'
                       :label="t('PostCommentReportManagementPage.ReportReason')"
                       width='230'
                       align='center'>
        <!--suppress TypeScriptUnresolvedReference-->
        <template #default='{ row }'>
          {{ row.reportReason }}
        </template>
      </el-table-column>

      <el-table-column prop='reportTime'
                       :label="t('PostCommentReportManagementPage.ReportTime')"
                       width='180'
                       align='center' sortable>
        <!--suppress TypeScriptUnresolvedReference-->
        <template #default='{ row }'>
          {{ formatDateTimeToCST(row.reportTime).dateTime }}
        </template>
      </el-table-column>

      <el-table-column column-key='status'
                       prop='status'
                       :label="t('PostCommentReportManagementPage.Status')"
                       width='130'
                       align='center'>
        <template #default='{ row }'>
          <!--suppress TypeScriptUnresolvedReference -->
          <el-tag :type="row.status == 1 ? 'info' : 'primary'"
                  :class="row.status == 0 ? 'clickable-status' : ''"
                  @click='handleStatusClick(row)'>
            {{
              row.status == 1 ? t('PostCommentReportManagementPage.Handled')
                  : t('PostCommentReportManagementPage.Unhandled')
            }}
          </el-tag>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script setup lang='ts'>
import {ref, onMounted} from 'vue'
import {useI18n} from 'vue-i18n'
import {useRouter} from 'vue-router'
import axiosInstance from '../utils/axios'
import {ElMessageBox, ElMessage} from 'element-plus'
import {formatDateTimeToCST} from '../globals'

type PostCommentReport = {
  postCommentReportId: number
  reporterId: number
  reporterName: String
  reportedUserId: number
  reportedUserName: String
  reportedPostId: number
  title: String
  reportedCommentId: number
  content: String
  reportReason: String
  reportTime: String
  status: number
}

const {t} = useI18n()
const storedValue = localStorage.getItem('currentUserId')
const storedUserId = storedValue ? parseInt(storedValue) : 0
const currentUserId = ref(isNaN(storedUserId) ? 0 : storedUserId)
const router = useRouter()
const commentReportData = ref<PostCommentReport[]>([])
const tableRef = ref()

onMounted(async () => {
  try {
    const response = await axiosInstance.get('post-comment-report/management')
    commentReportData.value = response.data
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
  }
})

const navigateToUser = userId => {
  router.push(`/profile/${userId}`)
}

const navigateToPost = postId => {
  router.push(`/post/${postId}`)
}

const handleSortChange = ({prop, order}) => {
  commentReportData.value.sort((a, b) => {
    if (order == 'ascending') return a[prop] > b[prop] ? 1 : -1
    if (order == 'descending') return a[prop] < b[prop] ? 1 : -1
    return 0
  })
}

const handleStatusClick = async (report) => {
  if (report.status == 0) {
    try {
      await axiosInstance.put(`post-comment-report/${report.postCommentReportId}`, {
        postCommentReportId: report.postCommentReportId,
        reporterId: report.reporterId,
        reportedUserId: report.reportedUserId,
        reportedPostId: report.reportedPostId,
        reportedCommentId: report.reportedCommentId,
        reportReason: report.reportReason,
        reportTime: report.reportTime,
        status: 1
      })
      window.location.reload()
    } catch (error) {
      ElMessage.error(t('ErrorMessage.PutErrorMessage'))
    }
  }
}

onMounted(async () => {
  if (currentUserId.value == 0) {
    await router.push('/login')
    await ElMessageBox.alert(t('SettingsPage.PleaseLoginFirst'), t('SettingsPage.Notice'), {
      showClose: false
    })
    return
  }
  try {
    const response = await axiosInstance.get(`user/role/${currentUserId.value}`)
    if (response.data == 0) {
      await router.push('/')
      await ElMessageBox.alert(t('PublishNewsPage.AuthorityPrompt'), t('SettingsPage.Notice'), {
        showClose: false
      })
    }
  } catch (error) {
    ElMessage.error(t('ErrorMessage.GetErrorMessage'))
    await router.push('/')
  }
})
</script>

<style scoped>
.page-container {
  width: 1200px;
  align-self: center;
  display: flex;
  flex-direction: column;
  padding: 0;
  box-sizing: border-box;
}

.el-table th, .el-table td {
  white-space: nowrap;
  overflow: hidden;
}

.hover-blue {
  cursor: pointer;
  color: inherit;
  text-decoration: none;
}

.hover-blue:hover {
  color: #4A90E2;
}

/* noinspection CssUnusedSymbol */
.clickable-status {
  cursor: pointer;
}
</style>
