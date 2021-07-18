namespace Contract.Communications
{
    public abstract class BaseResponce
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponce(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
