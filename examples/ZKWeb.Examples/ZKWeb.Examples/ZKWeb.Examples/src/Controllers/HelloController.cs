using ZKWeb.Web;
using ZKWeb.Web.ActionResults;
using ZKWebStandard.Ioc;

namespace ZKWeb.Examples.ZKWeb.Examples.src.Controllers {
	/// <summary>
	/// Hello world controller
	/// </summary>
	[ExportMany]
	public class HelloController : IController {
		/// <summary>
		/// GET /hello
		/// </summary>
		/// <returns></returns>
		[Action("hello")]
		public IActionResult Hello() {
			return new TemplateResult("zkweb.examples/hello.html", new { text = "World" });
		}
	}
}
