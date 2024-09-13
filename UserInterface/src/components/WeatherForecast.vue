<!--
  Project Name:  UserInterface
  File Name:     WeatherForecast.vue
  File Function: 天气预测组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-09-06
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <div v-if="weatherData.status == '0' || weatherData.infocode != '10000'" class='loading-container'>
    <div class='unknown-icon'/>
    {{ t('WeatherForecast.WeatherLoading') }}
  </div>

  <div v-else>
    <div style='display: flex; align-items: center; margin-bottom: 30px; margin-top: 20px'>
      <div style='flex-grow: 1; display: flex; flex-direction: column; align-items: flex-start; margin-left: 20px'>
        <span style='font-size: 26px; font-weight: bold; margin-bottom: 10px'>
          {{ weatherData.lives[0].reporttime }} {{ weatherDescription }}
        </span>
        <el-tag style='height: 30px; font-size: 14px'>
          {{ weatherData.lives[0].province }} {{ weatherData.lives[0].city }}
        </el-tag>
      </div>
      <div :style='{ backgroundImage: backgroundUrl }' style='width: 64px; height: 64px; margin-right: 10px'>
      </div>
    </div>

    <div style='display: flex; flex-direction: row; align-items: center; margin-bottom: 20px'>
      <span style='font-size: 24px; margin-left: 20px; margin-right: 8px'>{{
          weatherData.lives[0].temperature
        }} ℃</span>
      <img :src='`${ossBaseUrl}LogosAndIcons/Humidity.png`' alt='Humidity' class='weather-icon'/>
      <span style='font-size: 16px'>{{ weatherData.lives[0].humidity_float }} %</span>
      <img :src='`${ossBaseUrl}LogosAndIcons/Wind.png`' alt='Wind' class='weather-icon'/>
      <span style='font-size: 16px'>{{ weatherData.lives[0].winddirection }}</span>
    </div>
  </div>
</template>

<script setup lang='ts'>
import {onMounted, ref, computed} from 'vue'
import axiosInstance from '../utils/axios'
import {useI18n} from 'vue-i18n'
import {gaodeAccessKey, ossBaseUrl} from '../globals'

const {t} = useI18n()
const isDayTime = ref(true)
const weatherDescription = ref('')

const weatherData = ref({
  status: '',
  count: '',
  info: '',
  infocode: '',
  lives: [{
    province: '',
    city: '',
    adcode: '',
    weather: '',
    temperature: '',
    winddirection: '',
    windpower: '',
    humidity: '',
    reporttime: '',
    temperature_float: '',
    humidity_float: ''
  }]
})

const backgroundUrl = computed(() => {
  const weather = weatherData.value.lives[0].weather
  const time = isDayTime.value ? 'day' : 'night'
  const mode = (() => {
    switch (weather) {
      case '雷阵雨':
        return 'chance-thunder-storms'
      case '雷阵雨并伴有冰雹':
      case '强雷阵雨':
        return 'thunder-storms'
      case '中雨':
      case '阵雨':
      case '小雨':
      case '毛毛雨/细雨':
      case '小雨-中雨':
        return 'chance-rain'
      case '雨':
      case '中雨-大雨':
      case '大雨-暴雨':
      case '暴雨-大暴雨':
      case '大暴雨-特大暴雨':
      case '大雨':
      case '暴雨':
      case '大暴雨':
      case '特大暴雨':
      case '强阵雨':
      case '极端降雨':
        return 'rain'
      case '晴':
      case '热':
        return 'sunny'
      case '少云':
        return 'partly-cloudy'
      case '晴间多云':
      case '多云':
        return 'mostly-cloudy'
      case '阴':
        return 'cloudy'
      case '平静':
        return 'clear'
      case '雾':
      case '浓雾':
      case '强浓雾':
      case '轻雾':
      case '大雾':
      case '特强浓雾':
      case '有风':
      case '微风':
      case '和风':
      case '清风':
      case '强风/劲风':
      case '疾风':
      case '大风':
      case '烈风':
      case '风暴':
      case '狂爆风':
      case '飓风':
      case '热带风暴':
        return 'fog'
      case '霾':
      case '中度霾':
      case '重度霾':
      case '严重霾':
      case '浮尘':
      case '扬沙':
      case '沙尘暴':
      case '强沙尘暴':
      case '龙卷风':
        return 'hazy'
      case '雪':
      case '中雪':
      case '大雪':
      case '暴雪':
      case '中雪-大雪':
      case '大雪-暴雪':
      case '冷':
        return 'snow'
      case '阵雪':
      case '小雪':
      case '小雪-中雪':
        return 'chance-snow'
      case '雨雪天气':
      case '雨夹雪':
        return 'chance-sleet'
      case '阵雨夹雪':
        return 'sleet'
      case '冻雨':
        return 'flurries'
      default:
        return 'unknown'
    }
  })()
  return `var(--weather-${time}-${mode})`
})

function getLocalizedWindDirection(windDirection: string) {
  switch (windDirection) {
    case '东':
      return t('WeatherForecast.East')
    case '南':
      return t('WeatherForecast.South')
    case '西':
      return t('WeatherForecast.West')
    case '北':
      return t('WeatherForecast.North')
    case '东南':
      return t('WeatherForecast.Southeast')
    case '东北':
      return t('WeatherForecast.Northeast')
    case '西南':
      return t('WeatherForecast.Southwest')
    case '西北':
      return t('WeatherForecast.Northwest')
    default:
      return t('WeatherForecast.Unknown')
  }
}

function getLocalizedWeather(weather: string) {
  switch (weather) {
    case '晴':
      return t('WeatherForecast.Sunny')
    case '少云':
      return t('WeatherForecast.FewClouds')
    case '晴间多云':
      return t('WeatherForecast.PartlyCloudy')
    case '多云':
      return t('WeatherForecast.Cloudy')
    case '阴':
      return t('WeatherForecast.Overcast')
    case '有风':
      return t('WeatherForecast.Windy')
    case '平静':
      return t('WeatherForecast.Calm')
    case '微风':
      return t('WeatherForecast.LightBreeze')
    case '和风':
      return t('WeatherForecast.GentleBreeze')
    case '清风':
      return t('WeatherForecast.ModerateBreeze')
    case '强风/劲风':
      return t('WeatherForecast.FreshBreeze')
    case '疾风':
      return t('WeatherForecast.NearGale')
    case '大风':
      return t('WeatherForecast.Gale')
    case '烈风':
      return t('WeatherForecast.StrongGale')
    case '风暴':
      return t('WeatherForecast.Storm')
    case '狂爆风':
      return t('WeatherForecast.ViolentStorm')
    case '飓风':
      return t('WeatherForecast.Hurricane')
    case '热带风暴':
      return t('WeatherForecast.TropicalStorm')
    case '霾':
      return t('WeatherForecast.Haze')
    case '中度霾':
      return t('WeatherForecast.ModerateHaze')
    case '重度霾':
      return t('WeatherForecast.HeavyHaze')
    case '严重霾':
      return t('WeatherForecast.SevereHaze')
    case '阵雨':
      return t('WeatherForecast.ShowerRain')
    case '雷阵雨':
      return t('WeatherForecast.ThunderShower')
    case '雷阵雨并伴有冰雹':
      return t('WeatherForecast.ThunderShowerWithHail')
    case '小雨':
      return t('WeatherForecast.LightRain')
    case '中雨':
      return t('WeatherForecast.ModerateRain')
    case '大雨':
      return t('WeatherForecast.HeavyRain')
    case '暴雨':
      return t('WeatherForecast.StormRain')
    case '大暴雨':
      return t('WeatherForecast.HeavyStorm')
    case '特大暴雨':
      return t('WeatherForecast.SevereStorm')
    case '强阵雨':
      return t('WeatherForecast.HeavyShowerRain')
    case '强雷阵雨':
      return t('WeatherForecast.SevereThunderShower')
    case '极端降雨':
      return t('WeatherForecast.ExtremeRain')
    case '毛毛雨/细雨':
      return t('WeatherForecast.DrizzleRain')
    case '雨':
      return t('WeatherForecast.Rain')
    case '小雨-中雨':
      return t('WeatherForecast.LightToModerateRain')
    case '中雨-大雨':
      return t('WeatherForecast.ModerateToHeavyRain')
    case '大雨-暴雨':
      return t('WeatherForecast.HeavyRainToStorm')
    case '暴雨-大暴雨':
      return t('WeatherForecast.StormToHeavyStorm')
    case '大暴雨-特大暴雨':
      return t('WeatherForecast.HeavyToSevereStorm')
    case '雨雪天气':
      return t('WeatherForecast.Sleet')
    case '雨夹雪':
      return t('WeatherForecast.RainAndSnow')
    case '阵雨夹雪':
      return t('WeatherForecast.ShowerSnow')
    case '冻雨':
      return t('WeatherForecast.FreezingRain')
    case '雪':
      return t('WeatherForecast.Snow')
    case '阵雪':
      return t('WeatherForecast.SnowFlurry')
    case '小雪':
      return t('WeatherForecast.LightSnow')
    case '中雪':
      return t('WeatherForecast.ModerateSnow')
    case '大雪':
      return t('WeatherForecast.HeavySnow')
    case '暴雪':
      return t('WeatherForecast.Snowstorm')
    case '小雪-中雪':
      return t('WeatherForecast.LightToModerateSnow')
    case '中雪-大雪':
      return t('WeatherForecast.ModerateToHeavySnow')
    case '大雪-暴雪':
      return t('WeatherForecast.HeavySnowToSnowstorm')
    case '浮尘':
      return t('WeatherForecast.Dust')
    case '扬沙':
      return t('WeatherForecast.Sand')
    case '沙尘暴':
      return t('WeatherForecast.Duststorm')
    case '强沙尘暴':
      return t('WeatherForecast.StrongDuststorm')
    case '龙卷风':
      return t('WeatherForecast.Tornado')
    case '雾':
      return t('WeatherForecast.Foggy')
    case '浓雾':
      return t('WeatherForecast.DenseFog')
    case '强浓雾':
      return t('WeatherForecast.StrongFog')
    case '轻雾':
      return t('WeatherForecast.LightFog')
    case '大雾':
      return t('WeatherForecast.HeavyFog')
    case '特强浓雾':
      return t('WeatherForecast.ExtraStrongFog')
    case '热':
      return t('WeatherForecast.Hot')
    case '冷':
      return t('WeatherForecast.Cold')
    default:
      return t('WeatherForecast.Unknown')
  }
}

onMounted(async () => {
  try {
    const positionResponse = await axiosInstance.get(`https://restapi.amap.com/v3/ip?key=${gaodeAccessKey}`)
    const weatherResponse = await axiosInstance.get(`https://restapi.amap.com/v3/weather/weatherInfo?city=${positionResponse.data.adcode}&key=${gaodeAccessKey}`)
    weatherData.value = weatherResponse.data
    weatherData.value.lives[0].reporttime = weatherData.value.lives[0].reporttime.slice(5, 10)
    weatherData.value.lives[0].winddirection = getLocalizedWindDirection(weatherData.value.lives[0].winddirection)
    weatherDescription.value = getLocalizedWeather(weatherData.value.lives[0].weather)
  } catch (error) {
  }
})

const checkDayTime = () => {
  const now = new Date()
  const hour = now.getHours()
  isDayTime.value = hour >= 6 && hour < 18
}

onMounted(() => checkDayTime())
</script>

<style scoped>
:global(:root) {
  --weather-day-chance-rain: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayChanceRain.png');
  --weather-day-chance-sleet: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayChanceSleet.png');
  --weather-day-chance-snow: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayChanceSnow.png');
  --weather-day-chance-thunder-storms: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayChanceThunderStorms.png');
  --weather-day-clear: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayClear.png');
  --weather-day-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayCloudy.png');
  --weather-day-flurries: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayFlurries.png');
  --weather-day-fog: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayFog.png');
  --weather-day-hazy: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayHazy.png');
  --weather-day-mostly-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayMostlyCloudy.png');
  --weather-day-partly-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayPartlyCloudy.png');
  --weather-day-rain: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayRain.png');
  --weather-day-sleet: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DaySleet.png');
  --weather-day-snow: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DaySnow.png');
  --weather-day-sunny: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DaySunny.png');
  --weather-day-thunder-storms: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayThunderStorms.png');
  --weather-day-unknown: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/DayUnknown.png');
  --weather-night-chance-rain: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightChanceRain.png');
  --weather-night-chance-sleet: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightChanceSleet.png');
  --weather-night-chance-snow: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightChanceSnow.png');
  --weather-night-chance-thunder-storms: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightChanceThunderStorms.png');
  --weather-night-clear: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightClear.png');
  --weather-night-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightCloudy.png');
  --weather-night-flurries: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightFlurries.png');
  --weather-night-fog: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightFog.png');
  --weather-night-hazy: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightHazy.png');
  --weather-night-mostly-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightMostlyCloudy.png');
  --weather-night-partly-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightPartlyCloudy.png');
  --weather-night-rain: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightRain.png');
  --weather-night-sleet: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightSleet.png');
  --weather-night-snow: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightSnow.png');
  --weather-night-sunny: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightSunny.png');
  --weather-night-thunder-storms: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightThunderStorms.png');
  --weather-night-unknown: url('[TODO: ossBaseUrl]LogosAndIcons/LightWeatherIcons/NightUnknown.png');
  --weather-icon: invert(0);
}

/* noinspection CssUnusedSymbol */
:global(.dark) {
  --weather-day-chance-rain: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayChanceRain.png');
  --weather-day-chance-sleet: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayChanceSleet.png');
  --weather-day-chance-snow: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayChanceSnow.png');
  --weather-day-chance-thunder-storms: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayChanceThunderStorms.png');
  --weather-day-clear: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayClear.png');
  --weather-day-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayCloudy.png');
  --weather-day-flurries: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayFlurries.png');
  --weather-day-fog: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayFog.png');
  --weather-day-hazy: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayHazy.png');
  --weather-day-mostly-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayMostlyCloudy.png');
  --weather-day-partly-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayPartlyCloudy.png');
  --weather-day-rain: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayRain.png');
  --weather-day-sleet: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DaySleet.png');
  --weather-day-snow: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DaySnow.png');
  --weather-day-sunny: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DaySunny.png');
  --weather-day-thunder-storms: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayThunderStorms.png');
  --weather-day-unknown: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/DayUnknown.png');
  --weather-night-chance-rain: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightChanceRain.png');
  --weather-night-chance-sleet: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightChanceSleet.png');
  --weather-night-chance-snow: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightChanceSnow.png');
  --weather-night-chance-thunder-storms: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightChanceThunderStorms.png');
  --weather-night-clear: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightClear.png');
  --weather-night-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightCloudy.png');
  --weather-night-flurries: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightFlurries.png');
  --weather-night-fog: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightFog.png');
  --weather-night-hazy: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightHazy.png');
  --weather-night-mostly-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightMostlyCloudy.png');
  --weather-night-partly-cloudy: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightPartlyCloudy.png');
  --weather-night-rain: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightRain.png');
  --weather-night-sleet: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightSleet.png');
  --weather-night-snow: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightSnow.png');
  --weather-night-sunny: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightSunny.png');
  --weather-night-thunder-storms: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightThunderStorms.png');
  --weather-night-unknown: url('[TODO: ossBaseUrl]LogosAndIcons/DarkWeatherIcons/NightUnknown.png');
  --weather-icon: invert(1);
}

.loading-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  text-align: center;
  margin-bottom: 10px;
}

.unknown-icon {
  background-size: contain;
  background-repeat: no-repeat;
  height: 64px;
  width: 64px;
  margin-bottom: 10px;
  background-image: var(--weather-day-unknown);
}

.weather-icon {
  width: 24px;
  height: 24px;
  margin-left: 8px;
  margin-right: 8px;
  filter: var(--weather-icon);
}

@media (prefers-color-scheme: dark) {
  .unknown-icon {
    background-image: var(--weather-night-unknown);
  }
}
</style>
