using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NetCore_API.Controllers;
using NetCore_API.Model;
using NetCore_API.Repository;
using NetCore_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    public class AssetsControllerTest
    {
        private readonly AssetsController _assetsController;
        private readonly Mock<IAssetService> _assetServiceMock = new Mock<IAssetService>();
        private readonly Mock<IAssetRepository> _assetRepositoryMock = new Mock<IAssetRepository>();

        public AssetsControllerTest()
        {
            _assetsController = new AssetsController(_assetServiceMock.Object, _assetRepositoryMock.Object);
        }

        [Fact]
        public void add_should_return_OkResult_when_successful()
        {
            // Arrange
            var assetModel = new AssetRequest
            {
                Asset_Name = "Test Asset"
            };
            _assetServiceMock.Setup(x => x.add(assetModel)).Verifiable();

            // Act
            var result = _assetsController.add(assetModel);

            // Assert
            Assert.IsType<OkResult>(result);
            _assetServiceMock.Verify();
        }
        [Fact]
        public void add_should_return_InternalServerError_when_exception_thrown()
        {
            // Arrange
            var assetModel = new AssetRequest
            {
                Asset_Name = "Test Asset"
            };
            _assetServiceMock.Setup(x => x.add(assetModel)).Throws(new Exception());

            // Act
            var result = _assetsController.add(assetModel);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = (StatusCodeResult)result;
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

    }
}
