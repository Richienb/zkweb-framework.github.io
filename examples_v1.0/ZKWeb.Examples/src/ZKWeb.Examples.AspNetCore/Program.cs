using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace ZKWeb.Examples.AspNetCore {
	/// <summary>
	/// Asp.Net Core Main Program
	/// </summary>
	public class Program {
		/// <summary>
		/// Entry Point
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args) {
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();
			host.Run();
		}
	}
}
