using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Models.Core;

public class Result<T>
{
	public bool IsSuccess => Error == null;
	public string? Error;
	public T Data;

	public Result()
	{
		
	}

	public ObjectResult GetResult()
	{
		if (IsSuccess)
		{
			return new OkObjectResult(Data);
		}

		return new BadRequestObjectResult(Error);
	}
	public static Result<T> Success(T data)
	{
		return new Result<T>
		{
			Data = data
		};
	}

	public static Result<T> Fail(string errorMessage)
	{
		return new Result<T>
		{
			Error = errorMessage
		};
	}
}