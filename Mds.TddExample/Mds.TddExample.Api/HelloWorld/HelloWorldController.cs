using Microsoft.AspNetCore.Mvc;

namespace Mds.TddExample.Api.HelloWorld
{
    public class HelloWorldController : Controller
    {
        [HttpGet("hello-world")]
        public Task<HelloWorldResponse> Get()
        {
            return Task.FromResult(new HelloWorldResponse { Message = "Hello, World!" });
        }
    }
}
