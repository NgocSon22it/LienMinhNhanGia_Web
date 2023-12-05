using AutoMapper;
using DataAccess;
using DataAccess.Models;
using DTOs.MissionDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppServices.MissionRepo
{
    public class MissionRepositories
    {
        private readonly LienminhnhangiaContext context;
        IMapper mapper;


        public MissionRepositories(LienminhnhangiaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool AddMission(Mission mission)
        {
            try
            {
                context.Missions.Add(mission);
                return context.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public bool UpdateMission(Mission updateMission)
        {
            try
            {
                context.Entry<Mission>(updateMission).State = EntityState.Modified;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteMission(string ID)
        {
            try
            {
                var mission = context.Missions.SingleOrDefault(mission => mission.MissionId.Equals(ID));
                if (mission == null) return false;
                mission.Delete = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public bool AddMissionToAccount(AccountMission accountMission)
        {
            try
            {
                context.AccountMissions.Add(accountMission);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public List<AccountMission> GetAllMissionForAccount(int accountID)
        {
            try
            {
               var accountMissions = context.AccountMissions.Include(accountMission => accountMission.Mission)
                                        .Where(accountMission => accountMission.AccountId == accountID
                                                                && accountMission.Delete == false)
                                        .Select(accountMission => accountMission)
                                        .ToList();

                return accountMissions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        //unity call
        public bool UpdateAccountMissionState(AccountMission accountMission)
        {
            try
            {
                context.Entry<AccountMission>(accountMission).State = EntityState.Modified;
               
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public bool UpdateAccountMissionCurrent(int accountID, string missionID)
        {
            try
            {
                var account = context.AccountMissions
                            .Include(ac => ac.Mission)
                            .SingleOrDefault(ac => ac.AccountId == accountID
                                                    && ac.MissionId == missionID
                                                    && ac.Delete == false);

                if(account.Current < account.Mission.Target)
                {
                    account.Current += 1;
                } else
                {
                    account.Current = account.Mission.Target; 
                }

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {  
                throw new Exception(ex.Message);
            }
        }

        //unity call
        public AccountMission GetAccountMissionByMissionID(int accountID, string missionID)
        {
            try
            {
                var accountMissions = context.AccountMissions.Include(accountMission => accountMission.Mission)
                                         .SingleOrDefault(accountMission => accountMission.AccountId == accountID
                                                                && accountMission.MissionId ==  missionID
                                                                 && accountMission.Delete == false);

                return accountMissions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //unity call
        public Mission GetMissionbyId(string missionID)
        {
            try
            {
                var accountMissions = context.Missions
                                         .SingleOrDefault(miss => miss.MissionId == missionID
                                                                 && miss.Delete == false);

                return accountMissions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
