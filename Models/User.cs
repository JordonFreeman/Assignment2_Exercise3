namespace OrderManagement.RazorWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public string Role { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
    }
}
