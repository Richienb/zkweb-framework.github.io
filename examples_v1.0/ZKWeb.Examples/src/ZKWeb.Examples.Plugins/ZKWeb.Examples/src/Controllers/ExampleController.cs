using ZKWeb.Web;
using ZKWeb.Web.ActionResults;
using ZKWebStandard.Ioc;

namespace ZKWeb.Examples.Plugins.ZKWeb.Examples.src.Controllers {
	[ExportMany]
	public class ExampleController : IController {
		[Action("example/plain_text")]
		public IActionResult PlainText() {
			// �����ı�
			return new PlainResult("some plain text");
		}

		[Action("example/plain_string")]
		public string PlainString() {
			// �����ı�������������stringʱ���Զ�ʹ��PlainResult��װ
			return "some plain string";
		}

		[Action("example/json")]
		public object Json(string name, int age) {
			// �в���ʱ���Զ���ȡ�������
			// ����json���������Ͳ���IActionResult��stringʱ���Զ�ʹ��JsonResult��װ
			return new { name, age };
		}

		[Action("example/template")]
		public IActionResult Template() {
			// ����ģ��
			return new TemplateResult("zkweb.examples/hello.html", new { text = "World" });
		}

		[Action("example/file")]
		public IActionResult File() {
			// �����ļ�
			return new FileResult("D:\\1.txt");
		}
	}
}
