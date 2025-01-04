namespace TccBackEnd.Shared.Result;

public class Result<T>
{
  public bool IsSuccess { get; set; }
  public string? Message { get; set; }
  public string? ErrorMessage { get; set; }
  public T? Data { get; set; }
  
  public static Result<T> Success(string message)
  {
    return new Result<T>
    {
      IsSuccess = true,
      Message = message
    };
  }
  
  public static Result<T> Success(T data, string message)
  {
    return new Result<T>
    {
      IsSuccess = true,
      Data = data,
      Message = message
    };
  }

  public static Result<T> Error(string errorMessage)
  {
    return new Result<T>
    {
      IsSuccess = false,
      ErrorMessage = errorMessage
    };
  }
}
