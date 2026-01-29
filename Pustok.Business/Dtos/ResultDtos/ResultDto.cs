using Pustok.Business.Dtos.ResultDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos.ResultDtos
{
    public class ResultDto
    {
        public bool IsSucceed { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;


        public ResultDto()
        {
            IsSucceed = true;
            StatusCode = 200;
            Message = "Success";
        }
        public ResultDto(string message): this()
        {
         
            Message = message;
        }

        public ResultDto( string message, int statusCode):this(message)
        {
            Message=message;
            StatusCode = statusCode;
            
        }

        public ResultDto(bool isSucceed, int statusCode, string message):this(message,statusCode) 
        {
            IsSucceed = isSucceed;
           
        }
    }
}


public class ResultDto<T> : ResultDto
{
    public T? Data { get; set; }
    public ResultDto() : base()
    {
    }
    public ResultDto(T data) : this()
    {
        Data = data;
    }
    public ResultDto(string message, T data) : base(message)
    {
        Data = data;
    }
    public ResultDto(string message, int statusCode, T data) : base(message, statusCode)
    {
        Data = data;
    }
    public ResultDto(bool isSucceed, int statusCode, string message, T data) : base(isSucceed, statusCode, message)
    {
        Data = data;
    }
}
