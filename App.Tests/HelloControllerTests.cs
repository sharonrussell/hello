using Xunit;
using App.Controllers;

namespace App.Tests
{
    public class HelloControllerTests
    {
        [Fact]
        public void WhenICallHello_WithANameSupplied_ThenTheResultContainsTheName()
        {
            var controller = new HelloController();
            var result = controller.Get("Sharon");

            Assert.True(result.Equals("Hello, Sharon"));
        }
    }
}
