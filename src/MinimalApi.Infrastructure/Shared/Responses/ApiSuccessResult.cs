namespace MinimalApi.Infrastructure.Shared;

public class ApiSuccessResult<T> : ApiResult<T>
{
    public ApiSuccessResult(string? message = null) : base(true, message)
    {
    }

    public ApiSuccessResult(T data, bool isSuccessed) : base(data, isSuccessed, "Success")
    {
    }

    public ApiSuccessResult(T data) : base(data, true)
    {
    }
    
    private static readonly Lazy<ApiSuccessResult<T>> Lazy =
        new (() => new ApiSuccessResult<T>());

    public static ApiSuccessResult<T> Instance => Lazy.Value;

    public ApiSuccessResult<T> WithData(T data)
    {
        Instance.Data = data;
        return Instance;
    }

    public ApiSuccessResult<T> WithMessage(string message)
    {
        Instance.Message = message;
        return Instance;
    }
        
}