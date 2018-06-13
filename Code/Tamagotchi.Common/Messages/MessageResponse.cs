namespace Tamagotchi.Common.Messages
{
    public class MessageResponse<T>
    {
        public T Body { get; set; }
        public string Error { get; set; }
    }
}
