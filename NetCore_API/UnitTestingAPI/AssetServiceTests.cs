//using Microsoft.EntityFrameworkCore;
//using Moq;
//using NetCore_API.Model;
//using NetCore_API.Repository;
//using NetCore_API.Service;


//namespace UnitTestingAPI
//{
//    public class AssetServiceTests
//    {
//        private readonly Mock<IAssetRepository> _assetRepositoryMock;
//        private readonly AssetService _assetService;
//        private readonly NetCore_API.Data.DataContext _context;
//        public AssetServiceTests()
//        {
//            _assetRepositoryMock = new Mock<IAssetRepository>();
//            _assetService = new AssetService(_assetRepositoryMock.Object, _context);
//        }

//        [Fact]
//        public void AddAsset_ShouldCallAddMethod_WhenAssetNameIsCorrect()
//        {
//            //Arrange
//            var assetModel = new AssetRequest { Asset_Name = "Keyboard" };

//            //Act
//            _assetService.add(assetModel);

//            //Assert
//            _assetRepositoryMock.Verify(x => x.add(It.IsAny<AssetRequest>()), Times.Once);
//        }

//    }
//}
