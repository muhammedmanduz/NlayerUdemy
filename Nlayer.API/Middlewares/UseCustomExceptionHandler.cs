﻿using Microsoft.AspNetCore.Diagnostics;
using Nlayer.Service.Exceptions;
using NlayerCore.DTOs;
using System.Text.Json;

namespace Nlayer.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public  static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "applicastion/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException =>404,
                      _  => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response=CustomResponseDto<NoContentDto>.Fail(statusCode,exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                 });




            });
        }
    }
}
