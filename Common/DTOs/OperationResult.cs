namespace Common.DTOs
{
    public class OperationResult<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public ResponseCode ResponseCode { get; set; }
    }

    public enum ResponseCode
    {
        Successful = 200,
        NoAvailableData = 300,
        InvalidRequest = 400,
        OperationFailed = 500
    }
}
