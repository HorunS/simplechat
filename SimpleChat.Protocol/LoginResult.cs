namespace SimpleChat.Protocol
{
    public class LoginResult
    {
        public bool Success { get; set; }

        public string Token { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}