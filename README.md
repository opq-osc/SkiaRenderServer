# SkiaRenderServer

**本项目正在开发，尚不可用**

## 概述
本项目预计实现一套图片渲染引擎，通过它可以利用类似html的标记语法来生成图片。

## 特点
- 方便易用：通过xml声明图片中元素及定位，免去计算坐标的繁琐
- 数据绑定：简单的数据绑定语法，一套模板重复使用
- 平台无关：底层使用谷歌开源Skia图形库，并提供HTTP API，可接入任何语言、任何平台

## 路线表
### 第一部分：核心类库

| 模块 | 状态 |
| --- | --- |
| 基本布局系统 | 正在进行 |
| 基本渲染器 | 正在进行 |
| 基本图片及文本元素 | 未开始 |

### 第二部分：分析器

| 模块 | 状态 |
| --- | --- |
| XML分析器 | 未开始 |
| ViewModel数据绑定支持 | 未开始 |

### 第三部分：SDK
| 模块 | 状态 |
| --- | --- |
| HTTP API | 未开始 |
| .NET Nuget包 | 未开始 |

### 第四部分：开发者工具
| 模块 | 状态 |
| --- | --- |
| VSCode插件 | 未开始 |
| 可视化设计器 | 未开始 |