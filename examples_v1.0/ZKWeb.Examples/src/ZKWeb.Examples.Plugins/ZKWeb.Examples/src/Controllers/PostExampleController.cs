﻿using ZKWeb.Web;
using ZKWeb.Web.ActionResults;
using ZKWebStandard.Extensions;
using ZKWebStandard.Ioc;
using ZKWebStandard.Web;

namespace ZKWeb.Examples.Plugins.ZKWeb.Examples.src.Controllers {
	[ExportMany]
	public class PostExampleController : IController {
		[Action("example/post", HttpMethods.POST)]
		public IActionResult Post() {
			var request = HttpManager.CurrentContext.Request;
			var paramInUrl = request.GetQueryValue("paramInUrl");
			var paramInBody = request.GetFormValue("paramInBody");
			var name = request.Get<string>("name");
			var age = request.Get<int>("age");
			return new JsonResult(new { name, age });
		}
	}
}
