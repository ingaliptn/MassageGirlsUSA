namespace MassageGirls.Models
{
    public class LogicModel
    {
        public string Smtp { get; set; } = "sp-vm.serverpipe.org";
        public int Port { get; set; } = 587;
        public bool IsEnableSsl { get; set; } = true;
        public bool IsUseDefaultCredentials { get; set; }
        public string Login { get; set; } = "relay@serverpipe.org";
        public string Email { get; set; } = "relay@serverpipe.org";
        public string Password { get; set; } = "Z326050r@";
        public string FromName { get; set; } = "Massage Girls Online";
        public string FromEmail { get; set; } = "relay@serverpipe.org";
        public string ToEmail { get; set; } = "nikitatkachuk6@gmail.com"; //= "manager@usescortagency.com, girls@usescortagency.com, supervisor@usescortagency.com, support@usescortagency.com";
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
    public class ContactUsModel
    {
        public string? NameC { get; set; }
        public string? PhoneC { get; set; }
        public string? EmailC { get; set; }
        public string? CityC { get; set; }
        public string? MessageC { get; set; }
    }

    public class BuyNowModel
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FirstGirl { get; set; }
        public string? SecondGirl { get; set; }
        public string? City { get; set; }
        public string? Message { get; set; }
    }
}
