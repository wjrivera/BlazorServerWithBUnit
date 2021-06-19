using BlazorServerWithBUnit.Pages;
using Bunit;
using Xunit;

namespace BlazorServerWithBUnit.Testing
{
    public class CounterTests
    {

        [Fact]
        public void TestIncrementCounterButton()
        {
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();

            var button = cut.Find("button.btn.btn-primary");
            button.Click();
            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
            button.Click();
            cut.Find("p").MarkupMatches("<p>Current count: 2</p>");
        }

        [Fact]
        public void TestResetCounterButton()
        {
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();
            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");

            var button = cut.Find("button.btn.btn-primary");
            button.Click();
            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");

            var clearButton = cut.Find("button.btn.btn-secondary");
            clearButton.Click();
            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
        }
    }
}
