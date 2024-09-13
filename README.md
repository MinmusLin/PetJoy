# PetJoy

> Copyright © 2024 PetJoy Development Team - Licensed under [CC-BY-4.0 License](LICENSE)
>
> 版权所有 © 2024 宠悦 | PetJoy 项目开发组 - 采用 [CC-BY-4.0 许可证](LICENSE)授权

## 项目名称

PetJoy

## 项目简介

PetJoy: A one-stop hub for information and resource exchange tailored to pet enthusiasts.

宠悦：为宠物爱好者提供的一站式信息与资源交流天地。

![](assets/Logo.png)

> ***Relevant course***
> * Database Course Project 2024 (2024年同济大学数据库课程设计)

The project consists of five main modules:

* Pet Community
* Pet News
* Pet Adoption
* Pet Encyclopedia
* Pet AI

本项目由五个主要模块组成：

* 宠物社区
* 宠物新闻
* 宠物领养
* 宠物百科
* 宠物 AI

## 成员分工

| 姓名 | 学号 | GitHub 主页 | 代码行数 |
| :---: | :---: | :---: | :---: |
| 林继申 (组长) | 2250758 | [MinmusLin](https://github.com/MinmusLin) | 30069 |
| 刘淑仪 | 2251730 | [bunnyoii](https://github.com/bunnyoii) | 6220 |
| 赵思源 | 2252444 | [aaa705](https://github.com/aaa705) | 3410 |
| 杜天乐 | 2251310 | [lleell04](https://github.com/lleell04) | 2903 |
| 王沫涵 | 2253333 | [WCSCHM](https://github.com/WCSCHM) | 1586 |
| 钟承哲 | 2153495 | [FDSAIUOGH](https://github.com/FDSAIUOGH) | 1286 |
| 杨宇琨 | 2252843 | [YangRuakaka](https://github.com/YangRuakaka) | 1691 |
| 梁哲旭 | 2252432 | [wangzai200](https://github.com/wangzai200) | 797 |
| 刘垚 | 2253215 | [yaoyaolove](https://github.com/yaoyaolove) | 0 |
| 李明哲 | 2250931 | [jaychou729](https://github.com/jaychou729) | 462 |

```
git log --format='%aN' | sort -u | while read name; do echo -en "$name\t"; git log --author="$name" --pretty=tformat: --numstat | awk '{ add += $1; subs += $2; loc += $1 - $2 } END { printf "added lines: %s, removed lines: %s, total lines: %s\n", add, subs, loc }' -; done
```

## 项目组成

* `/assets`
存放 `README.md` 文件所需的相关图片资源

* `/Database`
数据库

* `/DatabaseWebAPI`
后端应用程序

* `/UserInterface`
前端应用程序

## 致谢

Thanks to [bunnyoii](https://github.com/bunnyoii) for her contributions to this repository.

感谢 [bunnyoii](https://github.com/bunnyoii) 对本仓库的贡献。

## 免责声明

The code and materials contained in this repository are intended for personal learning and research purposes only and may not be used for any commercial purposes. Other users who download or refer to the content of this repository must strictly adhere to the **principles of academic integrity** and must not use these materials for any form of homework submission or other actions that may violate academic honesty. I am not responsible for any direct or indirect consequences arising from the improper use of the contents of this repository. Please ensure that your actions comply with the regulations of your school or institution, as well as applicable laws and regulations, before using this content. If you have any questions, please contact me via [email](mailto:minmuslin@outlook.com).

本仓库包含的代码和资料仅用于个人学习和研究目的，不得用于任何商业用途。请其他用户在下载或参考本仓库内容时，严格遵守**学术诚信原则**，不得将这些资料用于任何形式的作业提交或其他可能违反学术诚信的行为。本人对因不恰当使用仓库内容导致的任何直接或间接后果不承担责任。请在使用前务必确保您的行为符合所在学校或机构的规定，以及适用的法律法规。如有任何问题，请通过[电子邮件](mailto:minmuslin@outlook.com)与我联系。

## 文档更新日期

2024年9月13日