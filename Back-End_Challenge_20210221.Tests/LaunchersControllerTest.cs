namespace Back_End_Challenge_20210221.Tests
{
    public class LaunchersControllerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Mock<ILaunchData> MockRepo = new();
        private readonly LaunchDataMemory LaunchData = new();

        public LaunchersControllerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task GetAllAsyncOk()
        {
            MockRepo.Setup(x => x.CountUnlikeTrashAsync())
                    .ReturnsAsync(LaunchData.CountUnlikeTrash());
            MockRepo.Setup(x => x.GetAllAsync(0, 2))
                    .ReturnsAsync(LaunchData.GetAll(0,2));

            var controller = new LaunchersController(MockRepo.Object);

            var result = await controller.GetAllAsync(0, 2);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            dynamic model = new ExpandoObject();
            model = Assert.IsAssignableFrom<dynamic>(okObjectResult.Value);

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
            
            MockRepo.Setup(x => x.GetAsync(new Guid("e3df2ecd-c239-472f-95e4-2b89b4f75800")))
                    .ReturnsAsync(LaunchData.Get(new Guid("e3df2ecd-c239-472f-95e4-2b89b4f75800")));

            var controller = new LaunchersController(MockRepo.Object);
            var result = await controller.GetAsync(new Guid("e3df2ecd-c239-472f-95e4-2b89b4f75800"));
            
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Launch>(okObjectResult.Value);

            Assert.Equal("Sputnik 8K74PS | Sputnik 1", model.Name);
        }

        [Fact]
        public async Task GetAsyncDeleted()
        {
            MockRepo.Setup(x => x.GetAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3")))
                    .ReturnsAsync(LaunchData.Get(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3")));

            var controller = new LaunchersController(MockRepo.Object);
            var result = await controller.GetAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"));

            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Deleted locally.", notFoundObjectResult.Value);
        }

        [Fact]
        public void NotFound()
        {
            Assert.Throws<Exception>(() => 
            MockRepo.Setup(x => x.GetAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b4")))
                    .ReturnsAsync(LaunchData.Get(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b4"))));
        }

        [Fact]
        public async Task PutAsyncOk()
        {
            var launch = LaunchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"));
            launch.Name = "Lucas";

            MockRepo.Setup(x => x.GetAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb")))
                    .ReturnsAsync(LaunchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb")));

            MockRepo.Setup(x => x.PutAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"), launch))
                    .Returns(LaunchData.Put(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"), launch));

            var controller = new LaunchersController(MockRepo.Object);

            var result = await controller.PutAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"), launch);

            var okResult = Assert.IsType<OkResult>(result);

            var launchUpdated = LaunchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"));

            Assert.Equal("Lucas", launchUpdated.Name);
            Assert.Equal(Import_Status.Published, launchUpdated.Status);
        }

        [Fact]
        public async Task PutAsyncIdNotMatch()
        {
            var launch = LaunchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"));

            MockRepo.Setup(x => x.GetAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb")))
                    .ReturnsAsync(LaunchData.Get(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb")));

            var controller = new LaunchersController(MockRepo.Object);

            var result = await controller.PutAsync(new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fa"), launch);

            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("The id does not match the object.", badRequestObjectResult.Value);
        }

        [Fact]
        public async Task PutAsyncDeleted()
        {
            var launch = LaunchData.Get(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"));

            MockRepo.Setup(x => x.PutAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"), launch))
                    .Returns(LaunchData.Put(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"), launch));

            var controller = new LaunchersController(MockRepo.Object);

            var result = await controller.PutAsync(new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"), launch);

            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Deleted locally.", badRequestObjectResult.Value);
        }

        [Fact]
        public async Task DeleteAsyncOk()
        {
            MockRepo.Setup(x => x.GetAsync(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4")))
                    .ReturnsAsync(LaunchData.Get(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4")));

            MockRepo.Setup(x => x.DeleteAsync(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4")))
                    .Returns(LaunchData.Delete(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4")));

            var controller = new LaunchersController(MockRepo.Object);

            var result = await controller.DeleteAsync(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4"));

            var okResult = Assert.IsType<OkResult>(result);

            var launchDeleted = LaunchData.Get(new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4"));
            Assert.Equal(Import_Status.Trash, launchDeleted.Status);
        }
    }
}