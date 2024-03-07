using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Models;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.COMMON.Models.ResponseModels;
using DXCBookStore.COMMON.ViewModels;

namespace DXCBookStore.BLL.Interfaces
{
    public interface ICustomerManagement
    {
        public Account CurrentCustomerLoggedIn();   

        public Task<string> CustomerCheckOut(List<CartItem> carts, CustomerResponseModel customer);

        public Task<Customer> GetCustomerById(int id); 
        
        public Task<Book> CheckBookQuantity(int quantity, int bookId);

        public Task<bool> CustomerRegister(CustomerRegisterRequestModel customerRegister);

        public Task<bool> CreateCustomer(Customer customer);


    }
}
