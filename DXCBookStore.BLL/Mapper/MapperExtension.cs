using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Helpers;
using DXCBookStore.COMMON.Models;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.COMMON.Models.ResponseModels;

namespace DXCBookStore.BLL.Mapper
{
    public static class MapperExtension
    {
        // To Model
        public static Publisher ToPublisherModel(this PublisherRequestModel publisherRequestModel) 
        {
            var publisher = new Publisher();    
            publisher.BrandName = publisherRequestModel.BrandName;
            publisher.HeadOfficeAddress = publisherRequestModel.HeadOfficeAddress;
            publisher.ContactMail = publisherRequestModel.ContactMail;
            publisher.Description = publisherRequestModel.Description;
            publisher.HotLine = publisherRequestModel.HotLine;
            return publisher;
        } 
        public static Serie ToSerieModel (this SerieRequestModel serieRequestModel)
        {
            var serie = new Serie ();
            serie.SerieName = serieRequestModel.SerieName;
            serie.CreatedDate = DateTime.Now;
            serie.StartYear = serieRequestModel.StartYear;
            serie.EndYear = serieRequestModel.EndYear;
            serie.IsDeleted = serieRequestModel.IsDeleted;
            serie.PublisherId = serieRequestModel.PublisherId;

            return serie;
        }

        // To Response Model

        public static List<PublisherResponseModel> ToListPublisherResponseModel(this IEnumerable<Publisher> publishers)
        {
            var result = new List<PublisherResponseModel>();
            publishers.ToList().ForEach(item =>
            {
                result.Add(new PublisherResponseModel()
                {
                    Id = item.Id,
                    BrandName = item.BrandName,
                    HeadOfficeAddress = item.HeadOfficeAddress,
                    HotLine = item.HotLine,
                    ContactMail = item.ContactMail,
                    Description = item.Description,
                    IsActive=  item.IsActive
                });
            });
            return result;
        }

        public static CustomerResponseModel ToCustomerResponseModel(this Customer customer)
        {
            var customerResponseModel = new CustomerResponseModel();
            customerResponseModel.Id = customer.Id;
            customerResponseModel.FullName = customer.FullName;
            customerResponseModel.Address = customer.ShippingAddress;
            customerResponseModel.Phone = customer.Phone;
            return customerResponseModel;
        }

        public static BookResponseModel ToBookResponseModel(this Book book)
        {
            var result = new BookResponseModel();
            result.Id = book.Id;
            result.Title = book.Title;
            result.ThumbNail = book.Images.ToList()[0].ImageName;
            result.Price = book.Price;
            result.CategoryName = book.Category.CategoryName;
            result.SerieName = book.Serie?.SerieName;
            result.Description = book.Description;
            result.Quantity = book.Quantity;
            result.Images = book.Images.ToList();
            result.Author = book.Author;
            result.Publisher = book.Publisher.BrandName;
            return result;
        }

        public static List<CategoryResponseModel> ToListCategoryReponseModel(this IEnumerable<Category> categories)
        {
            var result = new List<CategoryResponseModel>();
            categories.ToList().ForEach(item =>
            {
                result.Add(new CategoryResponseModel()
                {
                    Id = item.Id,
                    CategoryName = item.CategoryName,
                    CategoryIcon = item.CategoryIcon,
                    HasChildren = item.InverseParent?.Count > 0,
                    CategoryParentName = item.CategoryParent?.CategoryName
                });
            });
            return result;
        }

        public static List<InvoiceResponseModel> ToListInvoiceReponseModel(this IEnumerable<Invoice> invoices)
        {
            var result = new List<InvoiceResponseModel>();
            invoices.ToList().ForEach(item =>
            {
                result.Add(new InvoiceResponseModel()
                {
                    Id = item.Id,
                    ShippingAddress = item.ShippingAddress,
                    Phone = item.Phone,
                    PaidDate = item.PaidDate,
                    TotalPrice = item.TotalPrice,
                    FullName = item.Customer.FullName,
                    InvoiceDetailReponseModels = item.InvoiceDetails.ToListInvoiceDetailResponseModel()
                });
            });
            return result;
        }

        public static List<InvoiceDetailResponseModel> ToListInvoiceDetailResponseModel(this IEnumerable<InvoiceDetail> invoices)
        {
            var result = new List<InvoiceDetailResponseModel>();
            invoices.ToList().ForEach(item =>
            {
                result.Add(new InvoiceDetailResponseModel()
                {
                   Id= item.Id,
                   BookName = item.Book.Title,
                   Price = item.Price,
                   Quantity = item.Quantity,
                   ThumbNail = item.Book.Images.ToList()[0].ImageName,
                   Author = item.Book.Author
                });
            });
            return result;
        }

        public static List<SerieResponseModel> ToListSerieResponseModel(this IEnumerable<Serie> series)
        {
            var result = new List<SerieResponseModel>();
            series.ToList().ForEach(item =>
            {
                result.Add(new SerieResponseModel()
                {
                    Id = item.Id,
                    SerieName = item.SerieName,
                    StartYear = item.StartYear,
                    EndYear = item.EndYear,
                    IsDeleted = item.IsDeleted,
                    Thumbnail = item.Image.ImageName
                });
            });
            return result;
        }

        public static List<BookResponseModel> ToListBookResponseModel(this IEnumerable<Book> books)
        {
            var result = new List<BookResponseModel>();
            books.ToList().ForEach(item =>
            {
                result.Add(new BookResponseModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ThumbNail = item.Images.ToList()[0].ImageName,
                    Author = item.Author,
                    Images = item.Images.ToList(),
                    Publisher = item.Publisher.BrandName,
                    SerieName = item.Serie?.SerieName,
                    CategoryName = item.Category.CategoryName,
                    Description = item.Description
                });
            });
            return result;
        }
    }
}
