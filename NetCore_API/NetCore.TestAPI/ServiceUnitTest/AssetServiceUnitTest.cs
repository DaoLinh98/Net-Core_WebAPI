using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NetCore_API.Entity;
using NetCore_API.Model;
using NetCore_API.Repository;
using NetCore_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.TestAPI.Service
{
    public class AssetServiceUnitTest
    {
        [Fact]
        public void getAll_ReturnList()
        {
           
            // Arrange
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IAssetRepository>();
            repo.Setup(_ => _.getAll()).Returns(expected);
            var sut = new AssetService(repo.Object);
            // Act
            var actual = sut.getAll();
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void getAll_ReturnEmpty()
        {
            // Arrange
            List<AssetResponseAll> expected = null;
            var repo = new Mock<IAssetRepository>();
            repo.Setup(_ => _.getAll()).Returns(expected);
            var sut = new AssetService(repo.Object);
            // Act
            var actual = sut.getAll();
            // Assert
            Assert.Null(actual);
        }

        [Fact]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        public void add_value_null()
        {
            AssetRequest assetModel = null;
            //var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IAssetRepository>();
            var sut = new AssetService(repo.Object);
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.add(assetModel));
            Assert.Equal("Asset Name incorrect!", ex.Message);

        }
        [Fact]
        public void add_assetName_already()
        {
            // Arrange
            AssetRequest assetModel =new AssetRequest()
            {
                Asset_Name = "abc"
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IAssetRepository>();
            var sut = new AssetService(repo.Object);
            //
            int a = 1;
            // a is result expect in repo
            repo.Setup(_ => _.getByUserName(assetModel.Asset_Name)).Returns(a); // Expect return in a.
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.add(assetModel)); //run mothod real at service
            Assert.Equal("Asset Name allredy!", ex.Message); //compare result Expected.
        }

        [Fact]
        public void add_value_valid()
        {
            // Arrange
            AssetRequest assetModel = new AssetRequest()
            {
                Asset_Name = "abc"
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IAssetRepository>();
            var sut = new AssetService(repo.Object);
            //
            int? a = null;
            // a is result expect in repo
            repo.Setup(_ => _.getByUserName(assetModel.Asset_Name)).Returns(a); // Expect return in a.
            // Act
            var actual = sut.add(assetModel);
            // Assert
            Assert.Equal("Done", actual); //compare result Expected.
        }

        [Fact]
        public void getById_with_idIsNull()
        {
            int? id = null;
            // Arrange
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IAssetRepository>();
            var sut = new AssetService(repo.Object);
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.getById(id)); //run mothod real at service
            Assert.Equal("id invalid!", ex.Message); //compare result Expected.
        }
        [Fact]
        public void getById_return_null()
        {
            // Arrange
            int? id = 1;
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IAssetRepository>();
            var sut = new AssetService(repo.Object);
            // set up return mockValue in repo
            AssetRespone mockValue = null; //giá trị mong đợi trả về từ repo
            // Act
            repo.Setup(_ => _.getById(id)).Returns(mockValue); // Expect return in a.(Chạy lệnh giả từ repo trả về giá trị đã setup trước)
            //khi case thow ra lỗi thì sử dụng kết hợp lệnh Assert.Throws.
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.getById(id));
            Assert.Equal("Asset does not exist!", ex.Message); //compare result Expected.
        }

        [Fact]
        public void getById_return_valueValid()
        {
            // Arrange
            int? id = 1;
            // mock
            var repo = new Mock<IAssetRepository>();
            var sut = new AssetService(repo.Object);
            // set up return mockValue in repo
            AssetRespone mockValue = new AssetRespone()
            {
                Asset_Id=1,
                Asset_Name="test",
                userVMs = null
            }; //giá trị mong đợi trả về từ repo
            // Act
            repo.Setup(_ => _.getById(id)).Returns(mockValue); // Expect return in a.(Chạy lệnh giả từ repo trả về giá trị đã setup trước)
            //act
            var actual = sut.getById(id);
            //khi case thow ra lỗi thì sử dụng kết hợp lệnh Assert.Throws.
            // Assert
           // var ex = Assert.Throws<ArgumentException>(() => sut.getById(id));
            Assert.Equal(actual,mockValue); //compare result Expected.
        }

    }
}
