//using AppAmostras.Components.Pages;
using AppAmostras.Data;
using AppAmostras.Models;
using Bunit;
using Xunit;
using AppAmostras.Components.Pages;

public class ComponentTest : TestContext
{
    [Fact]
    public void ComponentLoadsCorrectly()
    {
        // Arrange
        var render = RenderComponent<Home>();

        // Assert
        render.Find("p").MarkupMatches("<p>Bem vindo ao sistema.</p>");
    }    
}