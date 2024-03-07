using DXCBookStore.COMMON.Helpers;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace DXC_BookStore_API_TEST
{
    public class HelperTest
    {
        [Fact]
        public void GenerateFileNameTest()
        {
            string contentType = "image/png";
            string genFileName = FileHelper.GenerateFileName(contentType);
            Assert.True(contentType.Length < genFileName.Length);
        }

    }
}

