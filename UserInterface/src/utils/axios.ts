/*
 * Project Name:  UserInterface
 * File Name:     axios.ts
 * File Function: Vue Axios 配置文件
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-01
 * License:       Creative Commons Attribution 4.0 International License
 */

import axios from 'axios'
import {apiBaseUrl} from '../globals'
import {useRouter} from 'vue-router'

const router = useRouter()

const axiosInstance = axios.create({
    baseURL: apiBaseUrl
})

axiosInstance.interceptors.request.use(
    async config => {
        const token = localStorage.getItem('jwtToken')
        if (token) {
            config.headers.Authorization = `Bearer ${token}`
        }
        return config
    },
    error => {
        return Promise.reject(error)
    }
)

axiosInstance.interceptors.response.use(
    response => response, error => {
        if (error.response && error.response.status == 401) {
            router.push('/login').then()
        }
        return Promise.reject(error)
    }
)

export default axiosInstance
