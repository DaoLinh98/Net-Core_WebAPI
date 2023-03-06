//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using NetCore_API.Data;
//using NetCore_API.Entity;
//using NetCore_API.Model;
//using NetCore_API.Repository;
//using NetCore_API.Service;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestService
//{
//    public class UnitTestService
//    {
//        private readonly Mock<DataContext> _mockDataContext;
//        private readonly IAssetService _assetService;

//        public UnitTestService()
//        {
//            _assetRepositoryMock = new Mock<IAssetRepository>();
//            _assetService = new AssetService(_assetRepositoryMock.Object, _mockDataContext.Object);
//        }

//        [Fact]
//        public void Add_ThrowsArgumentException_WhenAssetIsNull()
//        {
//            // Arrange
//            AssetRequest asset = null;

//            // Act & Assert
//            Assert.Throws<ArgumentException>(() => _assetService.add(asset));
//        }

//    }
//}
