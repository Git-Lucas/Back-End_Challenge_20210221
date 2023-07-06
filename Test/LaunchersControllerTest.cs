using Back_End_Challenge_20210221.Infra.Controllers;
using Back_End_Challenge_20210221.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace Test
{
    [TestClass]
    public class LaunchersControllerTest
    {
        [TestMethod]
        public async Task GetLaunchersDatabase()
        {
            var launchData = new LaunchDataSqlServer(new EfSqlServerAdapter());
            var launchController = new LaunchersController(launchData);
            
            var response = await launchController.GetAllAsync();
            var okObjectResult = response as OkObjectResult;

            Assert.IsNotNull(okObjectResult);
        }

        [Fact]
        public async Task GetLaunchersMemory()
        {
            var launchData = new LaunchDataMemory();
            var launchController = new LaunchersController(launchData);

            var response = await launchController.GetAllAsync();

            var okObjectResult = response as OkObjectResult;

            Assert.IsNotNull(okObjectResult);

            var model = Assert.is)
        }
    }
}