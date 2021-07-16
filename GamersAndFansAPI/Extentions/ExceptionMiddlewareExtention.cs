using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Microsoft.AspNetCore.Builder;

namespace GamersAndFansAPI.Extentions
{
    public static class ExceptionMiddlewareExtention
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder applicationBuilder , ILoggerManager loggerManager)
        {

        }
    }
}
