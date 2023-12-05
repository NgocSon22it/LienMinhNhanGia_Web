using AutoMapper;
using DataAccess;
using DataAccess.Models;
using DTOs.AccountDTOs;
using DTOs.CharacterDTOs;
using Microsoft.IdentityModel.Tokens;
using Obj_Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppServices.AccountRepo
{
    public class AccountRepositories
    {
        private readonly LienminhnhangiaContext context;
        IMapper mapper;

        public AccountRepositories(LienminhnhangiaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<ViewAccountAdmin> GetAllAccount()
        {
            try
            {
                var accounts = context.Accounts.Where(account => account.Role != Role.Admin && account.Delete == false).ToList();

                var accountAdmins = mapper.Map<List<Account>, List<ViewAccountAdmin>>(accounts);

                return accountAdmins;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Payload Login(Login login)
        {
            try
            {
                var account = context.Accounts.SingleOrDefault(acc => acc.Username == login.Username && acc.Delete == false);
                
                if (account == null)
                {
                    throw new Exception("Account does not exists.");
                }

                if (account.Password.ToLower() != Common.Hash(login.Password).ToLower())
                {
                    throw new Exception("Password is wrong.");
                }

                var payload = mapper.Map<Account, Payload>(account);

                return payload;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
       
        //unity call
        public Account Login_Unity(Login login)
        {
            try
            {
                var account = context.Accounts.SingleOrDefault(acc => acc.Username == login.Username && acc.Delete == false);

                if (account == null)
                {
                    throw new Exception("Account does not exists.");
                }

                if (account.Password != Common.Hash(login.Password))
                {
                    throw new Exception("Password is wrong.");
                }

                
                context.SaveChanges();

                return account;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public bool Logout(int accountID)
        {
            try
            {
                var account = context.Accounts.SingleOrDefault(acc => acc.AccountId == accountID);


                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public object Profile(int accountId, bool isAdmin = false, bool isPlaying = false)
        {
            try
            {
                var account = context.Accounts.SingleOrDefault(acc => acc.AccountId == accountId && acc.Delete == false);

                if (isPlaying)
                {
                    return account;
                }

                if (isAdmin)
                {
                    var viewAccountInfo = mapper.Map<Account, ViewAccountInfo>(account);
                    return viewAccountInfo;
                }

                var profile = mapper.Map<Account, AccountProfile>(account);

                return profile;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Register(Account newAccount)
        { 
            try
            {
                if (context.Accounts.SingleOrDefault(acc => acc.Username.Equals(newAccount.Username)) != null)
                {
                    throw new Exception("Tên đăng nhập đã tồn tại");
                }

                newAccount.Password = Common.Hash(newAccount.Password);
                context.Accounts.Add(newAccount);
                context.SaveChanges();
                return  true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Forgot(Forgot forgot)
        {
            try
            {
                var account = context.Accounts.SingleOrDefault(acc => acc.Username.Equals(forgot.Username));
                if (account == null)
                {
                    throw new Exception($"Tên đăng nhập {forgot.Username} không tồn tại");
                }
                
                if(!forgot.Password.IsNullOrEmpty())
                {
                    account.Password = Common.Hash(forgot.Password);

                    context.SaveChanges();

                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteAccount(int accountId)
        {
            try
            {
                var account = context.Accounts.SingleOrDefault(acc => acc.AccountId == accountId);
                if (account == null) return false;
                
                account.Delete = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateProfile(Account updateAccount)
        {
            try
            {
                var account = context.Accounts.SingleOrDefault(acc => acc.AccountId == updateAccount.AccountId && acc.Delete == false);

                if (account == null) return false;

                account.Name        =   Common.iifString(updateAccount.Name, account.Name);
                account.Avatar      =   Common.iifString(updateAccount.Avatar, account.Avatar);
                account.Password    = updateAccount.Password != null ? 
                                        Common.Hash(updateAccount.Password) : account.Password;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateRole(UpdateRole updateAccount)
        {
            try
            {
                var account = context.Accounts.SingleOrDefault(acc => acc.AccountId == updateAccount.AccountId && acc.Delete == false);

                if (account == null) return false;

                account.Role = updateAccount.Role;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //unity call
        public bool UpdateGameSpecs(Account updateAccount)
        {
            try
            {
                var account = context.Accounts.SingleOrDefault(acc => acc.AccountId == updateAccount.AccountId);

                if (account == null) return false; 
                

                account.Coin            = Common.iifInt     (updateAccount.Coin            , account.Coin);
                account.Experience      = Common.iifInt     (updateAccount.Experience      , account.Experience);  
                account.Level           = Common.iifInt     (updateAccount.Level           , account.Level);
                account.CheckPoint      = Common.iifString  (updateAccount.CheckPoint      , account.CheckPoint);
                account.BossKill        = Common.iifInt     (updateAccount.BossKill        , account.BossKill);
                account.AmountSlotSkill = Common.iifInt     (updateAccount.AmountSlotSkill , account.AmountSlotSkill);
                account.PointSkill      = Common.iifInt     (updateAccount.PointSkill      , account.PointSkill);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
