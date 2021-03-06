ZKWeb需要使用IoC容器来管理各个插件中的组件。<br/>
ZKWeb使用了自己编写的轻量IoC容器，支持构造函数注入。<br/>

### 简单的使用例子

``` csharp
void Example() {
	var animals = Application.Ioc.ResolveMany<IAnimal>()
	// animals contains instances of Dog and Cow
	
	var animalManager = Application.Ioc.Resolve<IAnimalManager>();
	// animalManager is AnimalManager
	
	var otherAnimalManager = Application.Ioc.Resolve<IAnimalManager>();
	// animalManager only create once, otherAnimalManager == animalManager
}

public interface IAnimal { }

[ExportMany]
public class Dog : IAnimal { }

[ExportMany]
public class Cow : IAnimal { }

public interface IAnimalManager { }

[ExportMany, SingletonUsage]
public class AnimalManager : IAnimalManager {
	// inject animals
	public AnimalManager(IEnumerable<IAnimal> animals) { }
}
```

### 全局的IoC容器

ZKWeb使用了一个全局变量储存IoC容器，这个全局变量在`Application.Ioc`。<br/>
虽然使用了全局变量，但这个全局变量可以在线程范围内使用`Application.OverrideIoc`进行重载，以便测试。<br/>
如果不想使用全局的容器可以使用构造函数注入，但注意注入的组件必须已经注册，否则会抛出例外。<br/>

### 构造函数注入

ZKWeb的IoC容器支持构造函数注入，在选择构造函数的时候会选参数最多的函数

``` csharp
public interface IXmlWriter { }
public interface IAttributeProvider { }

public class XmlBuilder {
	// IoC容器会使用第二个构造函数
	public XmlBuilder() { }
	public XmlBuilder(IXmlWriter writer, IEnumerable<IAttributeProvider> providers) { }
}

void Example() {
	// 创建XmlBuilder的实例，自动注入依赖项
	var xmlBuilder = Application.Ioc.Resolve<XmlBuilder>();
}
```

也可以使用`InjectAttribute`手动指定应该选择的构造函数

``` csharp
public interface IXmlWriter { }
public interface IAttributeProvider { }

public class XmlBuilder {
	public XmlBuilder() { }
	public XmlBuilder(IXmlWriter writer, IEnumerable<string> providers) { }
	// IoC容器会使用标有[Inject]的构造函数
	[Inject]
	public XmlBuilder(IXmlWriter writer, IEnumerable<IAttributeProvider> providers) { }
}

void Example() {
	// 创建XmlBuilder的实例，自动注入依赖项
	var xmlBuilder = Application.Ioc.Resolve<XmlBuilder>();
}
```

### 在插件中注册组件

插件可以标记`[ExportMany]`属性注册组件，同时标记`[SingletonReuse]`属性可以注册成单例。<br/>
请注意标记该属性的类需要是公开类，私有类不会被扫描。<br/>
如果不想使用属性注册组件，可以实现`IPlugin`接口在插件载入时手动注册到`Application.Ioc`

### 替换现有的组件

替换现有的组件可以手动调用`Application.Ioc.Unregister`再注册，<br/>
也可以使用`[ExportMany]`属性中的`ClearExists`属性自动替换现有的实现

### 提供自定义的注册属性

如果你觉得`[ExportMany]`无法满足你的要求, 可以创建一个类继承`ExportAttributeBase`, 然后在里面编写你的注册逻辑
