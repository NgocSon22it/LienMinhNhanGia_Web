using AutoMapper;
using DataAccess;
using DataAccess.Models;
using DTOs.ItemDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AppServices.ItemRepo
{
    public class ItemRepositories
    {
        private readonly LienminhnhangiaContext context;
        IMapper mapper;

        public ItemRepositories(LienminhnhangiaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool AddItem(Item item)
        {
            try
            {
                if (context.Items.SingleOrDefault(it => it.ItemId.Equals(item.ItemId)) != null)
                {
                    throw new Exception($"ID vật phẩm {item.ItemId} đã tồn tại");
                }

                context.Items.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateItem(Item updateItem)
        {
            try
            {
                context.Entry<Item>(updateItem).State = EntityState.Modified;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteItem(string itemId)
        {
            try
            {
                var item = context.Items.SingleOrDefault(i => i.ItemId.Equals(itemId));
                if (item == null) return false;

                item.Delete = true;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public bool BuyItem(AccountItem buyItem)
        {
            try
            {
                var accountItem = context.AccountItems
                                        .Include(ac => ac.Item)
                                        .Include(ac => ac.Account)
                                        .SingleOrDefault(ac => ac.ItemId.Equals(buyItem.ItemId) 
                                                            && ac.AccountId.Equals(buyItem.AccountId)
                                                            && ac.Delete == false );

                if(accountItem == null) context.AccountItems.Add(buyItem);
                else accountItem.Amount += buyItem.Amount;
               
                var account = context.Accounts
                                        .SingleOrDefault(ac => ac.AccountId == accountItem.AccountId
                                                            && ac.Delete == false); 

                account.Coin -= accountItem.Item.Coin * buyItem.Amount;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

     
        public List<Item> GetAllItem(int? total, string? keyword)
        {
            try
            {
                var items = context.Items.Where(i => i.Delete == false).ToList();
                
                if(keyword != null) {
                    items = items.Where(it => it.Name.Contains(keyword.ToLower())).ToList();
                }
                
                if (total != null)
                {
                    items = items.Take((int)total).ToList();
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        //unity call
        public List<ViewItem> GetItembyAccount(int accountID) 
        {
            try
            {
                var accountItems = context.AccountItems.Include(accountItem => accountItem.Item)
                                                        .Where(accountItem => accountItem.AccountId == accountID
                                                                            && accountItem.Item.Delete == false
                                                                            && accountItem.Delete == false)
                                                        .Select(accountItem => accountItem)
                                                        .ToList();


                List<ViewItem> viewItems = mapper.Map<List<AccountItem>, List<ViewItem>>(accountItems);

                return viewItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        //unity call
        public AccountItem GetAccountItemByItemID(int accountID, string itemID)
        {
            try
            {
                var accountItems = context.AccountItems.Include(accountItem => accountItem.Item)
                                    .SingleOrDefault(accountItem => accountItem.AccountId == accountID
                                                && accountItem.ItemId == itemID
                                                && accountItem.Delete == false);
                return accountItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        //unity call
        public Item GetItembyID(string itemId)
        {
            try
            {
                return context.Items.SingleOrDefault(item => item.ItemId.Equals(itemId) && item.Delete == false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

    }
}
