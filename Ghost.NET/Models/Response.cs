namespace GhostNet.Models
{
    public class Response<T>
    {
        public T Content { get; set; }
        public ErrorList Error { get; set; }
    }
}