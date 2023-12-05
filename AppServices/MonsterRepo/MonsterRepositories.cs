using AutoMapper;
using DataAccess;
using DataAccess.Models;
using DTOs.CharacterDTOs;
using DTOs.MonsterDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppServices.MonsterRepo
{
    public class MonsterRepositories
    {
        private readonly LienminhnhangiaContext context;

        IMapper mapper;

        public MonsterRepositories(LienminhnhangiaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool AddMonster(Monster monster)
        {
            try
            {
                if (context.Monsters.SingleOrDefault(mon => mon.MonsterId.Equals(monster.MonsterId)) != null)
                {
                    throw new Exception($"ID quái vật {monster.MonsterId} đã tồn tại");
                }

                context.Monsters.Add(monster);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateMonster(Monster updateMonster)
        {
            try
            {
                context.Entry<Monster>(updateMonster).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteMonster(string ID)
        {
            try
            {
                var monster = context.Monsters.SingleOrDefault(monster => monster.MonsterId.Equals(ID));
                if (monster == null) return false;
                monster.Delete = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public List<T> GetAllMonster<T>(int? total, string? keyword, bool flag = false)
        {
            try
            {
                var monsters = context.Monsters.Where(i => i.Delete == false).ToList();

                if (flag)
                {
                    return monsters.Cast<T>().ToList();
                }

                var viewMonsters = mapper.Map<List<Monster>, List<ViewMonster>>(monsters);
                
                if (keyword != null)
                {
                    viewMonsters = viewMonsters.Where(mon => mon.Name.Contains(keyword.ToLower())).ToList();
                }

                if (total != null)
                {
                    viewMonsters = viewMonsters.Take((int)total).ToList(); 
                }
                return viewMonsters.Cast<T>().ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Monster GetMonsterbyID(string ID)
        {
            try
            {
                return context.Monsters.SingleOrDefault(monster => monster.MonsterId.Equals(ID) && monster.Delete == false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
