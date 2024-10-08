namespace UserManagementApi.DTOS
{
    public class MailRequest
    {
        public string Reciever { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
