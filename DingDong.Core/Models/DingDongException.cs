namespace DingDong.Monitor.Models
{
    public class DingDongException : Exception
    {
        public DingDongStatus? Status { get; }
        public DingDongException(string? message) : this(message, null)
        {

        }

        public DingDongException(string? message, DingDongStatus? status) : base(message)
        {
            Status = status;
        }
    }
}
