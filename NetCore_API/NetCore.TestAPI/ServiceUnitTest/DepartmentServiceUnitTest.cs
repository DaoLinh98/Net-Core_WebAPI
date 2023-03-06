using Moq;
using NetCore_API.Model;
using NetCore_API.Repository;
using NetCore_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.TestAPI.ServiceUnitTest
{
    public class DepartmentServiceUnitTest
    {
        [Fact]
        public void getAll_ReturnList()
        {

            // Arrange
            var expected = MockData.MockData.getDeparts();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            repo.Setup(_ => _.getAllWithUsers()).Returns(expected);
            // Act
            var actual = sut.getAllWithUsers();
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void getAll_ReturnEmpty()
        {
            // Arrange
            List<DepartmentRespone> expected = null;
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            repo.Setup(_ => _.getAllWithUsers()).Returns(expected);
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.getAllWithUsers()); //run mothod real at service
            Assert.Equal("List Item is null", ex.Message); //compare result Expected.

        }
        [Fact]
        public void add_value_null()
        {
            DepartmentRequest departmentRequest = null;
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.add(departmentRequest));
            Assert.Equal("Department incorrect!", ex.Message);

        }
        [Fact]
        public void add_assetName_already()
        {
            DepartmentRequest departmentRequest = new DepartmentRequest()
            {
                Depart_Name = "asd",
            };
            // Arrange
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            //
            int? a = 1;
            // a is result expect in repo
            repo.Setup(_ => _.getByUserName(departmentRequest.Depart_Name)).Returns(a); // Expect return in a.
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.add(departmentRequest)); //run mothod real at service
            Assert.Equal("Department Name allredy!", ex.Message); //compare result Expected.

        }

        [Fact]
        public void add_value_valid()
        {
            // Arrange
            DepartmentRequest departmentRequest = new DepartmentRequest()
            {
                Depart_Name = "asd",
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            //
            int? a = null;
            // a is result expect in repo
            repo.Setup(_ => _.getByUserName(departmentRequest.Depart_Name)).Returns(a); // Expect return in a.
            // Act
            var actual = sut.add(departmentRequest);
            // Assert
            Assert.Equal("Done", actual); //compare result Expected.

        }


        [Fact]
        public void getById_return_null()
        {
            // Arrange
            DepartmentRespone department = null;
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(department); // Expect return in a.
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.getById(id)); //run mothod real at service
            Assert.Equal("Department does not exist!", ex.Message); //compare result Expected.

        }
        [Fact]
        public void getById_return_departValid()
        {
            // Arrange
            DepartmentRespone department = new DepartmentRespone()
            {
                Depart_Id = 1,
                Depart_Name = "abc",
                Users = null
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(department); // Expect return in a.
            // Act
            var actual = sut.getById(id);
            // Act /Assert
            Assert.Equal(actual, department); //compare result Expected.
        }
        [Fact]

        public void deleteById_success()
        {
            // Arrange
            DepartmentRespone department = new DepartmentRespone()
            {
                Depart_Id = 1,
                Depart_Name = "abc",
                Users = null
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            //
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(department); // Expect return in a.

            // Act
            var actual = sut.deleteById(id);
            // Act /Assert
            Assert.Equal("Done", actual); //compare result Expected.
        }

        [Fact]
        public void deleteById_return_exception()
        {
            // Arrange
            DepartmentRespone department = null;
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(department); // Expect return in a.
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.deleteById(id)); //run mothod real at service
            Assert.Equal("Department does not exit!", ex.Message); //compare result Expected.
        }

        [Fact]
        public void updateById_value_null_return_exception()
        {
            // Arrange
            DepartmentRespone department = null;
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            //
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(department); // Expect return in a.
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.updateById(id, department)); //run mothod real at service
            Assert.Equal("Department does not exist!", ex.Message); //compare result Expected.
        }
        [Fact]
        public void updateById_success()
        {
            // Arrange
            DepartmentRespone department = new DepartmentRespone()
            {
                Depart_Id = 1,
                Depart_Name = "abc",
                Users = null
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(department); // Expect return in a.
            // Act
            var actual = sut.updateById(id, department);
            // Act /Assert
            Assert.Equal("Done", actual); //compare result Expected.
        }
        [Fact]
        public void updateById_id_notMacth()
        {
            //arrange
            DepartmentRespone department = new DepartmentRespone()
            {
                Depart_Id = 1,
                Depart_Name = "abc",
                Users = null
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IDepartmentRepository>();
            var sut = new DepartmentService(repo.Object);
            //
            // a is result expect in repo
            int id = 2;
            repo.Setup(_ => _.getById(id)).Returns(department); // Expect return in a.
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.updateById(id, department)); //run mothod real at service
            Assert.Equal("Update incorrect!", ex.Message); //compare result Expected.
        }



    }
}
