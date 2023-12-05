using AutoMapper;
using DataAccess;
using DataAccess.Models;
using DTOs.SkillDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppServices.SkillRepo
{
    public class SkillRepositories
    {
        private readonly LienminhnhangiaContext context;
        IMapper mapper;

        public SkillRepositories(LienminhnhangiaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool AddSkill(Skill skill)
        {
            try
            {
                if (context.Skills.SingleOrDefault(ski => ski.SkillId.Equals(skill.SkillId)) != null)
                {
                    throw new Exception($"ID kỹ năng {skill.SkillId} đã tồn tại");
                }

                context.Skills.Add(skill);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateSkill(Skill updateSkill)
        {
            try
            {
                context.Entry<Skill>(updateSkill).State = EntityState.Modified;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteSkill(string ID)
        {
            try
            {
                var skill = context.Skills.SingleOrDefault(ski => ski.SkillId.Equals(ID));
                if (skill == null) return false;
                skill.Delete = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public List<Skill> GetAllSkill()
        {
            try
            {
                var list = context.Skills.Where(ski => ski.Delete == false).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public Skill GetSkillbyID(string skillID)
        {
            try
            {
                var skill = context.Skills.SingleOrDefault(ski => ski.SkillId.Equals(skillID) 
                                                                && ski.Delete == false);
                return skill;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public bool BuySkill(int accountID, string skillID)
        {
            try
            {
                var buySkill = new AccountSkill();

                buySkill.AccountId = accountID;
                buySkill.SkillId = skillID;

                var skill = context.AccountSkills.Add(buySkill);

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ViewSkillInfo> GetSkillbyCharacter(string characterID)
        {
            try
            {
                var skills = context.Skills.Where(ski => ski.CharacterId.Equals(characterID) && ski.Delete == false).ToList();
                var viewSkills = mapper.Map<List<Skill>, List<ViewSkillInfo>>(skills);
                return viewSkills;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public List<AccountSkill> GetSkillbyAccount(int accountID)
        {
            try
            {
                var skills = context.AccountSkills
                                        .Where(accountSkill => accountSkill.AccountId == accountID
                                                            && accountSkill.Delete == false)
                                        .Select(skill => skill)
                                        .ToList();

                return skills;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        //unity call
        public AccountSkill GetAccountSkillbySlotIndex(int accountID, int slotIndex)
        {
            try
            {
                var skill = context.AccountSkills
                                        .SingleOrDefault(accountSkill => accountSkill.AccountId == accountID
                                                            && accountSkill.SlotIndex == slotIndex
                                                            && accountSkill.Delete == false);

                return skill;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        //unity call
        public AccountSkill GetAccountSkillbySkillID(int accountID, string skillID)
        {
            try
            {
                var skill = context.AccountSkills
                                        .SingleOrDefault(accountSkill => accountSkill.AccountId == accountID
                                                            && accountSkill.SkillId == skillID
                                                            && accountSkill.Delete == false);

                return skill;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        //unity call
        public bool UpdateAccountSkillSlotIndex(int accountID, string skillID, int slotIndex)
        {
            try
            {
                var skill = context.AccountSkills
                                        .SingleOrDefault(accountSkill => accountSkill.AccountId == accountID
                                                            && accountSkill.SkillId == skillID
                                                            && accountSkill.Delete == false);

                skill.SlotIndex = slotIndex;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public bool UpgradeAccountSkillLevel(int accountID, string skillID)
        {
            try
            {
                var skill = context.AccountSkills
                                        .SingleOrDefault(accountSkill => accountSkill.AccountId == accountID
                                                            && accountSkill.SkillId == skillID
                                                            && accountSkill.Delete == false);

                skill.CurrentLevel += 1;

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
