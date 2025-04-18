namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // Constuctor Chaining - ortak bir constructor kullanarak kod tekrarını azaltır
        public Result(bool success, string message) : this (success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        
        public bool Success { get; }
        public string Message { get; }
    }
}