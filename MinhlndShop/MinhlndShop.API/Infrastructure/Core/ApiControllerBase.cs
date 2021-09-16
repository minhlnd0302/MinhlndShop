using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhlndShop.Model.Model;
using MinhlndShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;



namespace MinhlndShop.API.Infrastructure.Core
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly IErrorService _errorService;
        public ApiControllerBase(IErrorService errorService)
        {
            _errorService = errorService;
        }

        //protected IActionResult CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        //{
        //    HttpResponseMessage response = null;
        //    ActionResult actionResult = null;
        //    try
        //    {
        //        response = function.Invoke(); 
        //    }
        //    catch(DbUpdateException dbEx)
        //    {
        //        LogError(dbEx);
        //    }
        //    catch(Exception ex)
        //    {
        //        LogError(ex);
                
        //    return actionResult; 
        //}

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
