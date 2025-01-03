namespace TccBackEnd.Shared.Result;

public class Result<T> 
{
  public T? Data { get; set; }
  public bool Sucess { get; set;}
  public string? ErrorMessage{ get; set;}
}