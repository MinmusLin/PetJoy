/*
 * Project Name:  UserInterface
 * File Name:     router.ts
 * File Function: Vue Router 配置文件
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-09-07
 * License:       Creative Commons Attribution 4.0 International License
 */

import {createRouter, RouteRecordRaw, Router, createWebHistory} from 'vue-router'
import {isProgressVisible} from '../globals'
import i18n from './i18n'

const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        redirect: '/home'
    },
    {
        path: '/:pathMatch(.*)*',
        redirect: '/404'
    },
    {
        path: '/api',
        redirect: () => {
            window.location.href = '[TODO: APIRedirectUrl]'
            return '/'
        }
    },
    {
        path: '/about-petjoy',
        name: 'AboutPetJoyPage',
        // @ts-ignore
        component: () => import('../views/AboutPetJoyPage.vue'),
        meta: {
            title: 'RouterTitle.AboutPetJoyPage'
        }
    },
    {
        path: '/adoption/:id',
        name: 'AdoptionPage',
        // @ts-ignore
        component: () => import('../views/AdoptionPage.vue'),
        meta: {
            title: 'RouterTitle.PetAdoptionPage'
        }
    },
    {
        path: '/change-telephone',
        name: 'ChangeTelephonePage',
        // @ts-ignore
        component: () => import('../views/ChangeTelephonePage.vue'),
        meta: {
            title: 'RouterTitle.ChangeTelephonePage'
        }
    },
    {
        path: '/delete-account',
        name: 'DeleteAccountPage',
        // @ts-ignore
        component: () => import('../views/DeleteAccountPage.vue'),
        meta: {
            title: 'RouterTitle.DeleteAccountPage'
        }
    },
    {
        path: '/edit-news/:id',
        name: 'EditNewsPage',
        // @ts-ignore
        component: () => import('../views/EditNewsPage.vue'),
        meta: {
            title: 'RouterTitle.EditNewsPage'
        }
    },
    {
        path: '/home',
        name: 'HomePage',
        // @ts-ignore
        component: () => import('../views/HomePage.vue'),
        meta: {
            title: 'RouterTitle.HomePage'
        }
    },
    {
        path: '/login',
        name: 'LoginPage',
        // @ts-ignore
        component: () => import('../views/LoginPage.vue'),
        meta: {
            title: 'RouterTitle.LoginPage'
        }
    },
    {
        path: '/news-comment-report-management',
        name: 'NewsCommentReportManagementPage',
        // @ts-ignore
        component: () => import('../views/NewsCommentReportManagementPage.vue'),
        meta: {
            title: 'RouterTitle.NewsCommentReportManagementPage'
        }
    },
    {
        path: '/news-management',
        name: 'NewsManagementPage',
        // @ts-ignore
        component: () => import('../views/NewsManagementPage.vue'),
        meta: {
            title: 'RouterTitle.NewsManagementPage'
        }
    },
    {
        path: '/news/:id',
        name: 'NewsPage',
        // @ts-ignore
        component: () => import('../views/NewsPage.vue'),
        meta: {
            title: 'RouterTitle.PetNewsPage'
        }
    },
    {
        path: '/404',
        name: 'NotFoundPage',
        // @ts-ignore
        component: () => import('../views/NotFoundPage.vue'),
        meta: {
            title: 'RouterTitle.NotFoundPage'
        }
    },
    {
        path: '/pet-adoption',
        name: 'PetAdoptionPage',
        // @ts-ignore
        component: () => import('../views/PetAdoptionPage.vue'),
        meta: {
            title: 'RouterTitle.PetAdoptionPage'
        }
    },
    {
        path: '/pet-ai',
        name: 'PetAIPage',
        // @ts-ignore
        component: () => import('../views/PetAIPage.vue'),
        meta: {
            title: 'RouterTitle.PetAIPage'
        }
    },
    {
        path: '/pet-care',
        name: 'PetCarePage',
        // @ts-ignore
        component: () => import('../views/PetCarePage.vue'),
        meta: {
            title: 'RouterTitle.PetCarePage'
        }
    },
    {
        path: '/pet-community',
        name: 'PetCommunityPage',
        // @ts-ignore
        component: () => import('../views/PetCommunityPage.vue'),
        meta: {
            title: 'RouterTitle.PetCommunityPage'
        }
    },
    {
        path: '/pet-encyclopedia',
        name: 'PetEncyclopediaPage',
        // @ts-ignore
        component: () => import('../views/PetEncyclopediaPage.vue'),
        meta: {
            title: 'RouterTitle.PetEncyclopediaPage'
        }
    },
    {
        path: '/pet-category/:id',
        name: 'PetCategoryPage',
        // @ts-ignore
        component: () => import('../views/PetCategoryPage.vue'),
        meta: {
            title: 'RouterTitle.PetEncyclopediaPage'
        }
    },
    {
        path: '/pet-subcategory/:id',
        name: 'PetSubcategoryPage',
        // @ts-ignore
        component: () => import('../views/PetSubcategoryPage.vue'),
        meta: {
            title: 'RouterTitle.PetEncyclopediaPage'
        }
    },
    {
        path: '/post-comment-report-management',
        name: 'PostCommentReportManagementPage',
        // @ts-ignore
        component: () => import('../views/PostCommentReportManagementPage.vue'),
        meta: {
            title: 'RouterTitle.PostCommentReportManagementPage'
        }
    },
    {
        path: '/post/:id',
        name: 'PostPage',
        // @ts-ignore
        component: () => import('../views/PostPage.vue'),
        meta: {
            title: 'RouterTitle.PetCommunityPage'
        }
    },
    {
        path: '/post-report-management',
        name: 'PostReportManagementPage',
        // @ts-ignore
        component: () => import('../views/PostReportManagementPage.vue'),
        meta: {
            title: 'RouterTitle.PostReportManagementPage'
        }
    },
    {
        path: '/pet-news',
        name: 'PetNewsPage',
        // @ts-ignore
        component: () => import('../views/PetNewsPage.vue'),
        meta: {
            title: 'RouterTitle.PetNewsPage'
        }
    },
    {
        path: '/profile/:id',
        name: 'ProfilePage',
        // @ts-ignore
        component: () => import('../views/ProfilePage.vue'),
        meta: {
            title: 'RouterTitle.ProfilePage'
        }
    },
    {
        path: '/publish-news',
        name: 'PublishNews',
        // @ts-ignore
        component: () => import('../views/PublishNewsPage.vue'),
        meta: {
            title: 'RouterTitle.PublishNewsPage'
        }
    },
    {
        path: '/register',
        name: 'RegisterPage',
        // @ts-ignore
        component: () => import('../views/RegisterPage.vue'),
        meta: {
            title: 'RouterTitle.RegisterPage'
        }
    },
    {
        path: '/reset-password',
        name: 'ResetPasswordPage',
        // @ts-ignore
        component: () => import('../views/ResetPasswordPage.vue'),
        meta: {
            title: 'RouterTitle.ResetPasswordPage'
        }
    },
    {
        path: '/settings',
        name: 'SettingsPage',
        // @ts-ignore
        component: () => import('../views/SettingsPage.vue'),
        meta: {
            title: 'RouterTitle.SettingsPage'
        }
    },
    {
        path: '/user-feedback-management',
        name: 'UserFeedbackManagementPage',
        // @ts-ignore
        component: () => import('../views/UserFeedbackManagementPage.vue'),
        meta: {
            title: 'RouterTitle.UserFeedbackManagementPage'
        }
    }
]

const router: Router = createRouter({
    history: createWebHistory(),
    routes
})

router.beforeEach((to, _, next) => {
    if (to.meta && to.meta.title) {
        document.title = i18n.global.t(to.meta.title as string)
    } else {
        document.title = 'PetJoy'
    }
    isProgressVisible.value = true
    setTimeout(() => {
        isProgressVisible.value = false
    }, 1480)
    next()
})

export default router
