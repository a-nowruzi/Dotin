using Bunit;

namespace Dotin.Test
{
    public class IndexTest
    {
        [Fact]
        public void RendersSuccessfully()
        {
            using var ctx = new TestContext();
            var component = ctx.RenderComponent<Dotin.Client.Pages.Index>();
            Assert.Equal("Add New User", component.Find($".btn").TextContent);
        }
    }
}
