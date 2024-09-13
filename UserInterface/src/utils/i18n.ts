/*
 * Project Name:  UserInterface
 * File Name:     i18n.ts
 * File Function: Vue Internationalization (i18n) 配置文件
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-06-28
 * License:       Creative Commons Attribution 4.0 International License
 */

import {createI18n} from 'vue-i18n'
import de from '../languages/de'
import en from '../languages/en'
import es from '../languages/es'
import fr from '../languages/fr'
import it from '../languages/it'
import ja from '../languages/ja'
import ko from '../languages/ko'
import pt from '../languages/pt'
import ru from '../languages/ru'
import zh from '../languages/zh'

const languages = {
    de, // 德语（Deutsch）支持
    en, // 英语（English）支持
    es, // 西班牙语（Español）支持
    fr, // 法语（Français）支持
    it, // 意大利语（Italiano）支持
    ja, // 日语（日本語）支持
    ko, // 韩语（한국어）支持
    pt, // 葡萄牙语（Português）支持
    ru, // 俄语（Русский）支持
    zh  // 汉语（简体中文）支持
}

const defaultLanguage = localStorage.getItem('defaultLanguage') || 'zh'

const i18n = createI18n({
    legacy: false,
    locale: defaultLanguage,
    fallbackLocale: 'zh',
    messages: languages
})

export default i18n
