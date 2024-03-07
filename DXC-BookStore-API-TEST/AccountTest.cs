using DXC_BookStore_WEB_API.Controllers;
using DXCBookStore.BLL.Business;
using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace DXC_BookStore_API_TEST
{
    public class AccountTest
    {

    }

}
        //[Fact]
    //    public async Task Login_ValidCredentials_Returns()
    //    {
    //        var data = new List<Account>
    //        {
    //            new Account {Id= 1, UserName="admin",PassWord="$2y$10$.ArmXZAhaIif0fJNp4J7OOtlhwIgMedY/3SVvl6Fo7OBbnVRxorKu", Role="admin", LastLoggedIn = null, },
    //            new Account {Id= 2, UserName="abc",PassWord="$2y$10$.ArmXZAhaIif0fJNp4J7OOtlhwIgMedY/3SVvl6Fo7OBbnVRxorKu", Role="customer", LastLoggedIn = null, },

    //        }.AsQueryable();

    //        var configMock = new Mock<IConfiguration>();
    //        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

    //        var dbContextMock = new Mock<DataContext>();

    //        var mockSet = new Mock<DbSet<Account>>();

    //        mockSet.As<IQueryable<Account>>().Setup(m => m.Provider).Returns(data.Provider);
    //        mockSet.As<IQueryable<Account>>().Setup(m => m.Expression).Returns(data.Expression);
    //        mockSet.As<IQueryable<Account>>().Setup(m => m.ElementType).Returns(data.ElementType);
    //        mockSet.As<IQueryable<Account>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

    //        dbContextMock.Setup(c => c.Accounts).Returns(mockSet.Object);

    //        var accountManagement = new AccountManagement(dbContextMock.Object, configMock.Object, httpContextAccessorMock.Object);

    //        var result = await accountManagement.LoginAccount("admin", "admin");
    //        // Assert
    //        var okResult = Assert.IsType<OkObjectResult>(result);
    //        Assert.Equal("valid_token", okResult.Value);
    //    }

//    //}
//}
