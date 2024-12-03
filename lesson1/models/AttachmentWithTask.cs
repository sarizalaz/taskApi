using System.Net.Mail;

namespace lesson1.models
{
    public class AttachmentWithTask
    {
        public Attachments attachment { get; set; }
        public Tasks Tasks { get; set; }
    }
}
