﻿namespace DXCBookStore.COMMON.Models.RequestModels
{
    public class CustomerRegisterRequestModel
    {
        public string FullName { get; set; }
        public string Address { get;set; }
        public string Phone { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }    
    }
}
