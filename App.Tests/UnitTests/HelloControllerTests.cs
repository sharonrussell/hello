using Xunit;
using App.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace App.Tests
{
    public class HelloControllerTests
    {
        [Fact]
        public void WhenICallHello_WithANameSupplied_ThenTheResultContainsTheName()
        {
            var controller = new HelloController();
            IActionResult actionResult = controller.Get("Sharon");

            var result = actionResult as OkObjectResult;

            Assert.True(result.StatusCode.Equals(200));
            Assert.True(result.Value.Equals("Hello, Sharon"));
        }

        [Fact]
        public void WhenICallHello_WithNoNameSupplied_ThenTheResultIs400BadRequest()
        {
            var controller = new HelloController();
            var actionResult = controller.Get(string.Empty);

            var result = actionResult as BadRequestObjectResult;

            Assert.True(result.StatusCode.Equals(400));
            Assert.True(result.Value.Equals("Name should be supplied"));
        }
    }
}
