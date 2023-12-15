﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NlayerCore.DTOs
{
    
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore] //istek yaptıklarında Clientlara donmeyecek!
        public int StatusCode { get; set; }


        public List<String> Errors { get; set; }


        //static factory methot(design pattern)
        public static CustomResponseDto<T> Success(int statusCode,T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };

        }

           public static CustomResponseDto<T> Success(int statusCode)
           {
            return new CustomResponseDto<T> { StatusCode = statusCode };

           } 
        
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode ,Errors=errors};

        }
        
        public static CustomResponseDto<T> Fail(int statusCode, string errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { errors } };

        }

    }
}
