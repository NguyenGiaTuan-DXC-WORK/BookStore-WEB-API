using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Models;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.COMMON.Models.ResponseModels;
using DXCBookStore.COMMON.Roles;
using DXCBookStore.COMMON.ViewModels;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DXCBookStore.BLL.Business
{
    public class CustomerManagement : BaseBusiness, ICustomerManagement
    {
        private readonly DataContext _dataContext;
        private readonly IInvoiceManagement _invoiceManagement;
        private readonly IBookManagement _bookManagement;
        private readonly IInvoiceDetailManagement _invoiceDetailManagement;
        private readonly IAccountManagement _accountManagement;

		public CustomerManagement(IHttpContextAccessor contextAccessor, 
            IConfiguration configuration, DataContext dataContext,
            IInvoiceManagement invoiceManagement, IBookManagement bookManagement,
            IInvoiceDetailManagement invoiceDetailManagement, IAccountManagement accountManagement
			) : base(contextAccessor, configuration)
        {
            _dataContext = dataContext;
            _invoiceManagement = invoiceManagement; 
            _bookManagement = bookManagement;
            _invoiceDetailManagement = invoiceDetailManagement;
            _accountManagement = accountManagement;
        }

        public async Task<Book> CheckBookQuantity(int quantity, int bookId)
        {
            var book = await _bookManagement.GetBookById(bookId);
            if(book.Quantity >= quantity)
            {
                return null;
            }
            return book;
        }

		public async Task<bool> CreateCustomer(Customer customer)
		{
            _dataContext.Add(customer);
            await _dataContext.SaveChangesAsync();
            return true;
		}

		public Account CurrentCustomerLoggedIn()
        {
            if(CurrentUser != null && CurrentUser.Role.Equals(UserRole.Customer))
            {
                return CurrentUser;
            }
            return null;
        }

        public async Task<string> CustomerCheckOut(List<CartItem> carts, CustomerResponseModel customer)
        {
            // Kiem tra so luong lan cuoi truoc khi luu DB
            foreach (var cart in carts)
            {
                var bookCheck = await CheckBookQuantity(cart.Quantity, cart.Book.Id);
                if (bookCheck != null)
                {
                    return bookCheck.Title + " chỉ còn " + bookCheck.Quantity + " quyển !";
                }
            }

            // Neu con du so luong moi tien hanh tao hoa don

            var invoice = new Invoice();
            invoice.ShippingAddress = customer.Address;
            invoice.Phone = customer.Phone;
            invoice.TotalPrice = carts.Sum(i => i.Quantity * i.Book.Price);
            invoice.PaidDate = DateTime.Now;
            invoice.CustomerId = customer.Id;
            invoice.CreatedDate = DateTime.Now;

            var newInvoice = await _invoiceManagement.CreateInvoice(invoice);
            if(newInvoice != null && newInvoice.Id >0) 
            {
                foreach (var cart in carts)
                {
                    var invoiceDetail = new InvoiceDetail();
                    invoiceDetail.BookId = cart.Book.Id;
                    invoiceDetail.InvoiceId = newInvoice.Id;
                    invoiceDetail.Price = cart.Book.Price;
                    invoiceDetail.Note = "";
                    invoiceDetail.CreatedDate = DateTime.Now;
                    invoiceDetail.UpdatedDate = null;
                    invoiceDetail.Quantity = cart.Quantity;

                    await _bookManagement.UpdateBookQuantity(cart.Book.Id, cart.Quantity);
                    await _invoiceDetailManagement.CreateInvoiceDetail(invoiceDetail);
                }
                return "Success";
            }
            return "Fail";
            
        }

		public async Task<bool> CustomerRegister(CustomerRegisterRequestModel customerRegister)
		{
            bool isExistUserName = await _accountManagement.CheckExistUserName(customerRegister.UserName);

            if (isExistUserName)
            {
                return false;
            }
            else
            {
                var account = new Account();
                account.UserName = customerRegister.UserName;
                account.PassWord = BCrypt.Net.BCrypt.HashPassword(customerRegister.Password);
                account.Role = "customer";

                var result = await _accountManagement.CreateAccount(account);

                if (account.Id != null && account.Id > 0)
                {
                    var customer = new Customer();
                    customer.Id = account.Id;
                    customer.Account = account;
                    customer.FullName = customerRegister.FullName;
                    customer.ShippingAddress = customerRegister.Address;
                    customer.Phone = customerRegister.Phone;
                    await CreateCustomer(customer);
                }

                return true;
            }
        }

		public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _dataContext.Customers.Include(i => i.Account).SingleOrDefaultAsync(p => p.Id == id);
            return customer;
        }

        
    }
}
