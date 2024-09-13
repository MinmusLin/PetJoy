/*
 * Project Name:  UserInterface
 * File Name:     main.ts
 * File Function: 前端应用程序入口
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-29
 * License:       Creative Commons Attribution 4.0 International License
 */

// @ts-ignore
import App from './App.vue'
import {createApp} from 'vue'
import router from './utils/router'
import i18n from './utils/i18n'
import 'element-plus/dist/index.css'
import 'element-plus/theme-chalk/dark/css-vars.css'
import './styles/ScrollbarCSS.css'

const app = createApp(App)

app.use(router)
app.use(i18n)
app.mount('#app')
