namespace Comm.Model
{
    public class Common<T>
    {
        public int TotalEntity { get; set; }
        public int TotalPages { get; set; }
        public bool IsSuccess { get; set; }
        public T Entity { get; set; }
        public string ExceptionMessage { get; set; }
    }
}