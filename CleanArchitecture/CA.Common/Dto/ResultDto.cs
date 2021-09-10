namespace CA.Common.Dto
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ResultDto<TData>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
    }
}
