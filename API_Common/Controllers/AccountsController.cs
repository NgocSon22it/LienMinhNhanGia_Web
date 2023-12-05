using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AutoMapper;
using AppServices.AccountRepo;
using AppServices.JWTRepo;
using DTOs.AccountDTOs;
using DataAccess.Models;
using Obj_Common;

namespace API_Common.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IMapper mapper;
        AccountRepositories AccountManager;
        JWTRepositories JWTManager;

        public AccountsController(IMapper mapper, AccountRepositories accountManager, JWTRepositories jWTManager)
        {
            this.mapper = mapper;
            AccountManager = accountManager;
            JWTManager = jWTManager;
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            try
            {
                Account account = mapper.Map<Register, Account>(register);

                if (!AccountManager.Register(account))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Register fail!");

                return StatusCode((int)HttpStatusCode.OK, "Register success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Forgot(Forgot forgot)
        {
            try
            {
                if (!AccountManager.Forgot(forgot))
                    return StatusCode((int)HttpStatusCode.BadRequest);

                return StatusCode((int)HttpStatusCode.OK, "Update password success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            try
            {
                Payload data = AccountManager.Login(login);
                if (data != null)
                {
                    var tokens = JWTManager.GenerateToken(data);
                    return StatusCode((int)HttpStatusCode.OK, tokens);
                }
                return StatusCode((int)HttpStatusCode.BadRequest, "Login fail!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

    }
}
