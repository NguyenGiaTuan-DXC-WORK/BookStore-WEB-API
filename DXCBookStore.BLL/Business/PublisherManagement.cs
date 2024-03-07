using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Helpers;
using DXCBookStore.COMMON.Roles;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DXCBookStore.BLL.Business
{
    public class PublisherManagement : BaseBusiness, IPublisherManagement
    {
        private readonly DataContext _db;
        private IAccountManagement _accountManangement;
        public PublisherManagement(DataContext db, IAccountManagement accountManangement, IConfiguration configuration, IHttpContextAccessor contextAccessor) : base(contextAccessor, configuration)
        {
            _db = db;
            _accountManangement = accountManangement;
            _configuration = configuration;
        }

        public async Task<bool> ActivatePublisher(int id)
        {
            var publisher = await GetPublisherById(id);
            if(publisher !=null)
            {
                publisher.IsActive = true;
                // Set account password for publisher then update
                var account = publisher.Account;
                account.UpdatedDate = DateTime.Now;
                var rndPassWord = RandomPassWordHelper.RandomPassWord().ToString();
                account.PassWord = BCrypt.Net.BCrypt.HashPassword(rndPassWord);   
                await _accountManangement.UpdateAccount(account);
                // Send mail with PassWord
                var mailHelper = new MailHelper(_configuration);
                string subject = "Sign up for Publisher at DXC BookStore success";
                string content = "<table style='margin-bottom:20px;' width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' style='text-align: center;'> <img src='https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/DXC_Technology_logo_%282021%29.svg/2560px-DXC_Technology_logo_%282021%29.svg.png' width='220' height='100'> <h1 style='color:#5F249F;font-size: 40px;margin: 0;'>Publisher sign up success</h1> <h3>Thanks for choosing us</h3> <p>You are approved to be a part of DXC BookStore. Please change your password account right after sign in. </p> <p style='font-weight: bolder;'>This is your password, please dont share it in term of privacy: </p> <span style='color:#000000; border:1px solid #E5E5E5; font-size: 40px; padding: 10px;'>" + rndPassWord + "</span> </td> </tr> </table>";
                string from = "tuan.ng400@aptechlearning.edu.vn";
                await mailHelper.SendMailSync(from, publisher.ContactMail, subject, content);

                // Save update publishers
                await UpdatePublisher(publisher);
                return true;
            }
            return false;
        }

        public async Task<bool> ChangeDefaultPassWord(string userName, string oldPassWord, string newPassWord, string confirmPassword)
        {
            // Get user oldpassword
            var publisher = await GetPublisherByUserName(userName);
            if(publisher != null) {
                if (BCrypt.Net.BCrypt.Verify(oldPassWord, publisher.Account.PassWord))
                {
                    if (newPassWord.Equals(confirmPassword))
                    {
                        var account = publisher.Account;
                        if (account != null)
                        {
                            account.LastLoggedIn = DateTime.Now;
                            account.PassWord = BCrypt.Net.BCrypt.HashPassword(newPassWord);
                            account.Role = UserRole.Publisher;
                           
                            // Provide token for role publisher
                            var jwtHelper = new JwtHelper(_configuration);
                            string token = "";
                            token = jwtHelper.CreateJwtToken(publisher.Account.UserName, publisher.Id.ToString(), UserRole.Publisher, publisher.BrandName);

                            _contextAccessor.HttpContext.Session.SetString("Token", token);

                            var identity = new ClaimsIdentity(new List<Claim>
                        {
                            new Claim("UserId", publisher.Id.ToString(), ClaimValueTypes.Integer32),
                            new Claim("UserRole", publisher.Account.Role, ClaimValueTypes.String),
                            new Claim("UserName", publisher.Account.UserName, ClaimValueTypes.String)
                        }, "Custom");


                            await _accountManangement.UpdateAccount(account);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public async Task<bool> CreatePublisher(Publisher publisher)
        {
            // Create inactive account
            var account = new Account();
            account.UserName = publisher.ContactMail;
            account.Role = UserRole.InactivePublisher;
            account.PassWord = "";
            await _accountManangement.CreateAccount(account);

            // Assign init value for publisher
            publisher.IsActive = false;
            publisher.CreatedDate = DateTime.Now;
            publisher.Id = account.Id;
            _db.Publishers.Add(publisher);
            var result = await _db.SaveChangesAsync();

            if (result > 0 )
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Publisher>> GetAllActivePublisher()
        {
            return await _db.Publishers.Where(i => i.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<Publisher>> GetAllInActivePublisher()
        {
            return await _db.Publishers.Where(i => i.IsActive == false).ToListAsync();
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            var publisher = await _db.Publishers.Include(p => p.Account).SingleOrDefaultAsync(i => i.Id == id);
            return publisher;
        }

        public async Task<Publisher> GetPublisherByUserName(string userName)
        {
            var result = await _db.Publishers.Include(p => p.Account).SingleOrDefaultAsync(p =>
            p.Account.UserName.ToUpper().Trim().Equals(userName.ToUpper().Trim()));
            return result;
        }

        public async Task<Publisher> PublisherLogin(string userName, string passWord)
        {
            var validPublisher = await GetPublisherByUserName(userName);
            if (validPublisher != null)
            {
                var validPassword = BCrypt.Net.BCrypt.Verify(passWord, validPublisher.Account.PassWord);
                if(validPassword)
                {
                    return validPublisher;
                }
            }
            return null;
        }

        public async Task<bool> UpdateLastLoggedIn(string userName)
        {
            var publisher = await GetPublisherByUserName(userName);
            if (publisher != null)
            {
                var account = publisher.Account;
                if (account != null)
                {
                    account.LastLoggedIn = DateTime.Now;
                    var result = await _accountManangement.UpdateAccount(account);
                    if(result)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<bool> UpdatePublisher(Publisher publisher)
        {
            _db.Entry(publisher).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }


    }
}
