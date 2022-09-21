using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TaskManager.Controllers.Account;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountFacade _facade;

        public AccountController(ILogger<AccountController> logger, IAccountFacade facade)
        {
            _logger = logger;
            _facade = facade;
        }

        [HttpGet]
        public IEnumerable<Model.Data.User> Get(uint? id) => _facade.Read(id);
        
        [HttpPost]
        public void Login(Model.Data.User user)
        {
            var token = _facade.Auth(user);
            if (token != null)
            {
                Set("usr-tkn", token);
                Response.StatusCode = StatusCodes.Status200OK;
            }
            else Response.StatusCode = StatusCodes.Status401Unauthorized;
        }

        [HttpPost]
        public void SignIn(Model.Data.User user) => _facade.Create(user);

        [HttpPut]
        public void Put(Model.Data.User user) => _facade.Update(user);
        

        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void Set(string key, string value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append(key, value, option);
        }
    }
}
