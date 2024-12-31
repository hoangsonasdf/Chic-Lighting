namespace projectchicandlighting.Services.SendMailServices
{
    public interface ISendMailService
    {
        Task SendMail(string subject, string body, string to);
        Task<string> EmailBodyVerify(string link);
        Task<string> EmailBodyReset(string link);
    }
}
