/*
 * Project Name:  UserInterface
 * File Name:     globals.ts
 * File Function: 全局变量文件
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-09-02
 * License:       Creative Commons Attribution 4.0 International License
 */

import {ref} from 'vue'
import type {Instance} from 'element-plus'

interface MenuItem {
    index: string
    title: string
}

interface PetCategory {
    id: string
    label: string
    iconPath: string
    showMenu: boolean
    menuItems: MenuItem[]
}

export const apiBaseUrl = '[TODO: apiBaseUrl]'
export const ossBaseUrl = '[TODO: ossBaseUrl]'
export const gaodeAccessKey = '[TODO: gaodeAccessKey]'
export const isProgressVisible = ref(false)
export const tourRef1 = ref<Instance>()
export const tourRef2 = ref<Instance>()
export const tourRef3 = ref<Instance>()
export const tourRef4 = ref<Instance>()
export const tourRef5 = ref<Instance>()
export const tourRef6 = ref<Instance>()
export const tourRef7 = ref<Instance>()
export const tourRef8 = ref<Instance>()
export const tourRef9 = ref<Instance>()
export const tourRef10 = ref<Instance>()
export const tourRef11 = ref<Instance>()
export const tourRef12 = ref<Instance>()
export const showGuidedTour = ref(false)
export const searchThresholdScore = 0.2

export const carouselImages = [
    `${ossBaseUrl}CarouselImages/CarouselImage1.jpg`,
    `${ossBaseUrl}CarouselImages/CarouselImage2.jpg`,
    `${ossBaseUrl}CarouselImages/CarouselImage3.jpg`,
    `${ossBaseUrl}CarouselImages/CarouselImage4.jpg`,
    `${ossBaseUrl}CarouselImages/CarouselImage5.jpg`,
    `${ossBaseUrl}CarouselImages/CarouselImage6.jpg`
]

export const petCategories = ref<PetCategory[]>([
    {
        id: '1',
        label: '',
        iconPath: `${ossBaseUrl}LogosAndIcons/PetCategories/Dog.png`,
        showMenu: false,
        menuItems: []
    },
    {
        id: '2',
        label: '',
        iconPath: `${ossBaseUrl}LogosAndIcons/PetCategories/Cat.png`,
        showMenu: false,
        menuItems: []
    },
    {
        id: '3',
        label: '',
        iconPath: `${ossBaseUrl}LogosAndIcons/PetCategories/Fish.png`,
        showMenu: false,
        menuItems: []
    },
    {
        id: '4',
        label: '',
        iconPath: `${ossBaseUrl}LogosAndIcons/PetCategories/Bird.png`,
        showMenu: false,
        menuItems: []
    },
    {
        id: '5',
        label: '',
        iconPath: `${ossBaseUrl}LogosAndIcons/PetCategories/Hamsters.png`,
        showMenu: false,
        menuItems: []
    },
    {
        id: '6',
        label: '',
        iconPath: `${ossBaseUrl}LogosAndIcons/PetCategories/Rabbit.png`,
        showMenu: false,
        menuItems: []
    },
    {
        id: '7',
        label: '',
        iconPath: `${ossBaseUrl}LogosAndIcons/PetCategories/Turtle.png`,
        showMenu: false,
        menuItems: []
    },
    {
        id: '8',
        label: '',
        iconPath: `${ossBaseUrl}LogosAndIcons/PetCategories/Lizards.png`,
        showMenu: false,
        menuItems: []
    },
    {
        id: '9',
        label: '',
        iconPath: `${ossBaseUrl}LogosAndIcons/PetCategories/Snake.png`,
        showMenu: false,
        menuItems: []
    }
])

export function formatDateTimeToCST(dateTimeStr: string): { date: string, dateTime: string } {
    const date = new Date(dateTimeStr)
    date.setHours(date.getHours() + 8)
    const dateFormatter = new Intl.DateTimeFormat('zh-CN', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        timeZone: 'Asia/Shanghai'
    })
    const timeFormatter = new Intl.DateTimeFormat('zh-CN', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit',
        hour12: false,
        timeZone: 'Asia/Shanghai'
    })
    return {
        date: dateFormatter.format(date).replace(/\//g, '-'),
        dateTime: timeFormatter.format(date).replace(/\//g, '-').replace(',', '')
    }
}

export function dataUrlToBlob(dataURI: any) {
    const byteString = atob(dataURI.split(',')[1])
    const mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0]
    const ab = new ArrayBuffer(byteString.length)
    const ia = new Uint8Array(ab)
    for (let i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i)
    }
    return new Blob([ab], {type: mimeString})
}
