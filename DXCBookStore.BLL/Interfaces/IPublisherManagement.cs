using DXCBookStore.COMMON.Entities;

namespace DXCBookStore.BLL.Interfaces
{
    public interface IPublisherManagement
    {
        public Task<bool> CreatePublisher(Publisher publisher);

        public Task<IEnumerable<Publisher>> GetAllInActivePublisher();
        public Task<IEnumerable<Publisher>> GetAllActivePublisher();

        public Task<bool> ActivatePublisher(int id);

        public Task<Publisher> GetPublisherById(int id);

        public Task<bool> UpdatePublisher(Publisher publisher);

        public Task<Publisher> GetPublisherByUserName(string userName);
        public Task<bool> UpdateLastLoggedIn(string userName);

        public Task<bool> ChangeDefaultPassWord(string userName, string oldPassWord, string newPassWord, string confirmPassword);
    }
}
