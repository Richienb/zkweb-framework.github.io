基础插件提供了一系列的模板标签和过滤器.<br/>
关于模板标签和过滤器请查看[模板系统](../core/template_engine).<br/>

### 提供的标签

- copyright_text
	- 显示版权信息文本
	- 例: `{% copyright_text %}`
- include_css_here
	- 在当前位置引用css文件
	- 例: `{% include_css_here "/static/common.base.css/test.css" %}`
	- 例: `{% include_css_here variable %}`
- include_css_later
	- 延迟引用css文件, 需要配合"render_included_css"标签使用
	- 这个标签会影响上下文内容, 不应该在有缓存的模板模块中使用
	- 例: `{% include_css_later "/static/common.base.css/test.css" %}`
	- 例: `{% include_css_later variable %}`
- include_js_here
	- 在当前位置引用js文件
	- 例: `{% include_js_here "/static/common.base.js/test.js" %}`
	- 例: `{% include_js_here variable %}`
- include_js_later
	- 延迟引用javascript文件, 需要配合"render_included_js"标签使用
	- 这个标签会影响上下文内容, 不应该在有缓存的模板模块中使用
	- 例: `{% include_js_later "/static/common.base.js/test.js" %}`
	- 例: `{% include_js_later variable %}`
- render_extra_metadata
	- 描画额外的meta标签
	- 描画后会清空原有的内容, 可以重复调用
	- 例: `{% render_extra_metadata %}`
- render_included_css
	- 描画延迟引用的css资源
	- 描画后会清空原有的引用, 可以重复调用
	- 例: `{% render_included_css %}`
- render_included_js
	- 描画延迟引用的javascript资源
	- 描画后会清空原有的引用, 可以重复调用
	- 例: `{% render_included_js %}`
- remder_meta_description
	- 描画页面描述
	- 如果有指定关键词时使用指定的描述, 否则使用网站设置中的描述
	- 例: `{% remder_meta_description %}`
- render_meta_keywords
	- 描画页面关键词
	- 如果有指定关键词时使用指定的关键词, 否则使用网站设置中的关键词
	- 例: `{% render_meta_keywords %}`
- render_title
	- 描画当前网站标题
	- 例: `{% render_title %}`
- url_pagination
	- 根据Url分页的控件, 需要配合Model.Pagination使用
	- 例: `{% url_pagination response.Pagination %}`
- use_meta_description
	- 设置页面描述, 需要配合"remder_meta_description"标签使用
	- 例: `{% use_meta_description "description" %}`
	- 例: `{% use_meta_description variable %}`
- use_meta_keywords
	- 设置页面关键词, 需要配合"render_meta_keywords"标签使用
	- 例: `{% use_meta_keywords "keywords" %}`
	- 例: `{% use_meta_keywords variable %}`
- use_title
	- 设置网站标题, 需要配合标签"render_title"使用
	- 例: `{% use_title "Plain Text Title" %}`
	- 例: `{% use_title variable_title %}`
- website_name
	- 显示当前网站名称
	- 例: `{% website_name %}`

### 提供的过滤器

- website_title
	- 网站标题
	- 按WebsiteSettings.DocumentTitleFormat进行格式化
	- 例: `{{ "Website Title" | website_title }}`
- url
	- 全局过滤网址
	- 请参考"全局过滤网址"的说明
	- 例: `{{ "/example" | url }}`
- url_get_param
	- 获取Url参数, 传入的url是空值时使用当前请求的url
	- 例: `{{ "" | url_get_param: "key" }}`
	- 例: `{{ test_url | url_get_param: variable }}`
- url_set_param
	- 设置Url参数, 传入的url是空值时使用当前请求的url
	- 例: `{{ "" | url_set_param: "key", "value" | url }}`
	- 例: `{{ test_url | url_set_param: "key", variable | url }}`
- url_remove_param
	- 删除Url参数, 传入的url是空值时使用当前请求的url
	- 例: `{{ "" | url_remove_param: "key" }}`
	- 例: `{{ test_url | url_remove_param: variable }}`
- html_attributes
	- 描画Html标签
	- 需要传入类型是`IDictionary<string, string>`的参数
	- 例: `{{ attribtues | html_attributes }}`
- json
	- 使用Json序列化对象
	- 例: `{{ obj | json }}`

### 全局过滤网址

为了支持伪静态等高级功能, 基础插件提供了全局过滤网址的功能.<br/>
描画url(例如a标签的href)时应该添加`url`过滤器.<br/>
需要全局过滤网址时可以注册`IUrlFilter`到容器.<br/>

**使用全局过滤网址的例子**
``` html
<a href="{{ "/example/view?id=[0]" | format: exampleId | url }}"></a>
```
