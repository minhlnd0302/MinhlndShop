using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhlndShop.Model.Model;
using MinhlndShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
namespace MinhlndShop.API.Infrastructure.Core
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly IErrorService _errorService;
        public ApiControllerBase(IErrorService errorService)
        {
            _errorService = errorService;
        }  
        protected void LogError(Exception exception)
        { 
            try
            {
                Error error = new Error();
                error.CreatedDate = DateTime.Now;
                error.Message = exception.Message;
                error.StackTrace = exception.StackTrace;
                _errorService.Create(error);
                _errorService.Save();
            }
            catch  
            {
            
            }
        }
    }
}
