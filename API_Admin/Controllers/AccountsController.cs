using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AutoMapper;
using AppServices.AccountRepo;
using DTOs.AccountDTOs;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace API_Admin.Controllers
{
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AccountsController : ControllerBase
    {
        IMapper mapper;
        AccountRepositories AccountManager;

        public AccountsController(IMapper mapper, AccountRepositories accountManager)
        {
            this.mapper = mapper;
            AccountManager = accountManager;
        }

        [HttpPost]
        public IActionResult AddAccount(Register register)
        {
            try
            {
                Account account = mapper.Map<Register, Account>(register);

                if (!AccountManager.Register(account))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Add account fail!");

                return StatusCode((int)HttpStatusCode.OK, "Add account success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }

        }

        [HttpDelete("{accountId}")]
        public IActionResult DeleteAccount(int accountId)
        {
            try
            {
                if (!AccountManager.DeleteAccount(accountId))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Account does not exists.");

                return StatusCode((int)HttpStatusCode.OK, "Delete success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateRole(UpdateRole updateAccount)
        {
            try
            {
                if (!AccountManager.UpdateRole(updateAccount))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Account does not exists.");

                return StatusCode((int)HttpStatusCode.OK, "Update role success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllAccount()
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, AccountManager.GetAllAccount());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet("{accountId}")]
        public IActionResult GetbyID(int accountId)
        {
            try
            {
                var account = AccountManager.Profile(accountId, true);

                if (account == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Account does not exists.");

                return StatusCode((int)HttpStatusCode.OK, account);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        

    }
}
