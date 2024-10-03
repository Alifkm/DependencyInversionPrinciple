namespace DependencyInversionPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmailService emailService = new EmailService();
            Notification notification = new Notification(emailService);
            notification.Send("Bisa baca kaga mas brow emailnya");
        }
    }

    public interface IEmailService
    {
        public void SendEmail(string to, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to} with subject {subject}");
        }
    }

    public class Notification
    {
        private readonly IEmailService _emailService;

        public Notification(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Send(string message)
        {
            _emailService.SendEmail("abc@test.com", "Test aja ini mah", message);
        }
    }

    public class MockEmailService:IEmailService
    {
        public void SendEmail(string to, string subject,string body)
        {
            throw new NotImplementedException();
        }
    }
}
