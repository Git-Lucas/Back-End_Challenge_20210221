namespace Back_End_Challenge_20210221.Tests;

public class LaunchersControllerTest
{
    private readonly Mock<ILaunchData> _mockRepo = new();
    private readonly LaunchDataMemory _launchData = new();

    [Fact]
    public async Task GetAllAsyncOk()
    {
        _mockRepo.Setup(x => x.CountUnlikeTrashAsync())
                .ReturnsAsync(_launchData.CountUnlikeTrash());
        _mockRepo.Setup(x => x.GetAllAsync(0, 2))
                .ReturnsAsync(_launchData.GetAll(0,2));

        LaunchersController controller = new LaunchersController(_mockRepo.Object);

        IActionResult result = await controller.GetAllAsync(0, 2);

        OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(result);
        dynamic model = Assert.IsAssignableFrom<dynamic>(okObjectResult.Value);

        Assert.Equal(2, model.GetType().GetProperty("count").GetValue(model, null));
        Assert.Equal(4, model.GetType().GetProperty("count").GetValue(model, null));
        Assert.Equal(0, model.GetType().GetProperty("skip").GetValue(model, null));
        Assert.Equal(2, model.GetType().GetProperty("take").GetValue(model, null));
        Assert.Equal(1, model.GetType().GetProperty("currentPage").GetValue(model, null));
        Assert.Equal(2, model.GetType().GetProperty("totalPages").GetValue(model, null));
        Assert.IsAssignableFrom<List<Launch>>(model.GetType().GetProperty("results").GetValue(model, null));
    }

    [Fact]
    public async Task GetAsyncOk()
    {
        _mockRepo.Setup(x => x.GetAsync(new Guid("e3df2ecd-c239-472f-95e4-2b89b4f75800")))
                .ReturnsAsync(_launchData.Get(new Guid("e3df2ecd-c239-472f-95e4-2b89b4f75800")));

        LaunchersController controller = new LaunchersController(_mockRepo.Object);
        IActionResult result = await controller.GetAsync(new Guid("e3df2ecd-c239-472f-95e4-2b89b4f75800"));

        OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(result);
        Launch model = Assert.IsAssignableFrom<Launch>(okObjectResult.Value);

        Assert.Equal("Sputnik 8K74PS | Sputnik 1", model.Name);
    }

    [Fact]
    public async Task GetAsyncDeleted()
    {
        _mockRepo.Setup(x => x.GetAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3")))
                .ReturnsAsync(_launchData.Get(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3")));

        LaunchersController controller = new LaunchersController(_mockRepo.Object);
        IActionResult result = await controller.GetAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"));

        NotFoundObjectResult notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Deleted locally.", notFoundObjectResult.Value);
    }

    [Fact]
    public void NotFound()
    {
        Assert.Throws<Exception>(() => 
        _mockRepo.Setup(x => x.GetAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b4")))
                .ReturnsAsync(_launchData.Get(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b4"))));
    }

    [Fact]
    public async Task PutAsyncOk()
    {
        Launch launch = _launchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"));
        launch.Name = "Lucas";

        _mockRepo.Setup(x => x.GetAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb")))
                .ReturnsAsync(_launchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb")));

        _mockRepo.Setup(x => x.PutAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"), launch))
                .Returns(_launchData.Put(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"), launch));

        LaunchersController controller = new LaunchersController(_mockRepo.Object);

        IActionResult result = await controller.PutAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"), launch);

        Assert.IsType<OkResult>(result);

        Launch launchUpdated = _launchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"));

        Assert.Equal("Lucas", launchUpdated.Name);
        Assert.Equal(Import_Status.Published, launchUpdated.Status);
    }

    [Fact]
    public async Task PutAsyncIdNotMatch()
    {
        Launch launch = _launchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"));

        _mockRepo.Setup(x => x.GetAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb")))
                .ReturnsAsync(_launchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb")));

        LaunchersController controller = new LaunchersController(_mockRepo.Object);

        IActionResult result = await controller.PutAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fa"), launch);

        BadRequestObjectResult badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("The id does not match the object.", badRequestObjectResult.Value);
    }

    [Fact]
    public async Task PutAsyncDeleted()
    {
        Launch launch = _launchData.Get(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"));

        _mockRepo.Setup(x => x.PutAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"), launch))
                .Returns(_launchData.Put(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"), launch));

        LaunchersController controller = new LaunchersController(_mockRepo.Object);

        IActionResult result = await controller.PutAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"), launch);

        BadRequestObjectResult badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Deleted locally.", badRequestObjectResult.Value);
    }

    [Fact]
    public async Task DeleteAsyncOk()
    {
        _mockRepo.Setup(x => x.GetAsync(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4")))
                .ReturnsAsync(_launchData.Get(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4")));

        _mockRepo.Setup(x => x.DeleteAsync(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4")))
                .Returns(_launchData.Delete(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4")));

        LaunchersController controller = new LaunchersController(_mockRepo.Object);

        IActionResult result = await controller.DeleteAsync(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4"));

        OkResult okResult = Assert.IsType<OkResult>(result);

        Launch launchDeleted = _launchData.Get(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4"));
        Assert.Equal(Import_Status.Trash, launchDeleted.Status);
    }
}