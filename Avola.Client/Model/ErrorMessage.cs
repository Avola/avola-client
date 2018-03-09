namespace Avola.Client.Model
{
    public class ErrorMessage
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public string[] Values { get; set; }
    }
}