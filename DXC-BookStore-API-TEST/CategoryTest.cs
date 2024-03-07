using DXC_BookStore_WEB_API.Controllers;
using DXCBookStore.BLL.Business;
using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Helpers;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXC_BookStore_API_TEST
{
    public class CategoryTest
    {
        private readonly Mock<ICategoryManagement> _categoryManagement;
        public CategoryTest()
        {
            _categoryManagement = new Mock<ICategoryManagement>();
        }
        [Fact]
        public async Task GetAllCategory_Return200()
        {
            var categoryController = new CategoryController(_categoryManagement.Object);

            // Act
            var categoryResult = (OkObjectResult)await categoryController.GetAllCategories();

            // Assert
            Assert.NotNull(categoryResult);
        }


    }
}
