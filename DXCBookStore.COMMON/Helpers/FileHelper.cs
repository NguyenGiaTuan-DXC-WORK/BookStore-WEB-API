using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace DXCBookStore.COMMON.Helpers
{
    public class FileHelper
    {
        private IHostingEnvironment _webHostEnvironment;

        public FileHelper(IHostingEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public static string GenerateFileName(string contentType)
        {
            // Xu ly viec trung file bang cach dat ten file lai bang guid va noi' duoi file vao
            var guid = Guid.NewGuid().ToString().Replace("-", "");
            var extension = contentType.Split(new char[] { '/' })[1];
            return guid + "." + extension;
        }

        static bool CheckImage(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    try
                    {
                        var filePath = Path.GetTempFileName();

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        using (var img = Image.FromFile(filePath))
                        {
                            return true;
                        }
                    }
                    catch (OutOfMemoryException)
                    {
                        // Invalid image 
                        return false;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


        // Validate img file
        public static bool IsValidImgFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false;
            }

            if(CheckImage(file))
            {
                return true;
            }
            return false;
        }

        public string UploadFile(IFormFile photo)
        {
            if(IsValidImgFile(photo))
            {
                var name = FileHelper.GenerateFileName(photo.ContentType);
                if (name.Contains("+xml"))
                {
                    name = name.Replace("+xml", "");
                }
            
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "imgs", name);

                using (var fileStream = new FileStream(path, FileMode.Create)) 
                {
                    photo.CopyTo(fileStream);
                }

                return name;
            }
            else
            {
                return "error";
            }
        }

        public void DeleteOldFile(string oldFileName)
        {
            string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "imgs", oldFileName);
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
        }
    }
}
