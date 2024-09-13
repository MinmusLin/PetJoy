/*
 * Project Name:  UserInterface
 * File Name:     vite.config.mts
 * File Function: Vite 构建工具配置文件
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-20
 * License:       Creative Commons Attribution 4.0 International License
 */

import {defineConfig} from 'vite'
import vue from '@vitejs/plugin-vue'
import AutoImport from 'unplugin-auto-import/vite'
import Components from 'unplugin-vue-components/vite'
import {ElementPlusResolver} from 'unplugin-vue-components/resolvers'

// noinspection JSUnusedGlobalSymbols
export default defineConfig({
    plugins: [
        vue(),
        AutoImport({
            resolvers: [ElementPlusResolver()]
        }),
        Components({
            resolvers: [ElementPlusResolver()]
        })
    ]
})
