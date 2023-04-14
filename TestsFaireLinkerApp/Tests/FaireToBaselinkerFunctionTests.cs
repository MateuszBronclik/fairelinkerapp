using TestsFaireLinkerApp.Tests;

public class FaireToBaselinkerFunctionTests
{
    [Fact]
    public void Run_ShouldProcessFaireOrders()
    {
        // Arrange
        var mockConfiguration = new Mock<IConfiguration>();
        var mockFaireService = new Mock<IFaireService>();
        var mockBaselinkerService = new Mock<IBaselinkerService>();
        var mockLogger = new Mock<ILogger>();

        var sampleFaireOrder = TestData.SampleFaireOrder;

        mockFaireService.Setup(fs => fs.GetFaireOrders()).Returns(new List<FaireOrder.Root> { sampleFaireOrder });
        mockBaselinkerService.Setup(bs => bs.AddOrder(It.IsAny<BaselinkerOrder>())).Returns(true);

        var function = new FaireToBaselinkerFunction(mockConfiguration.Object, mockFaireService.Object, mockBaselinkerService.Object);

        // Act
        function.Run(null, mockLogger.Object);

        // Assert
        mockFaireService.Verify(fs => fs.GetFaireOrders(), Times.Once());
        mockBaselinkerService.Verify(bs => bs.AddOrder(It.IsAny<BaselinkerOrder>()), Times.Once());
    }
}
