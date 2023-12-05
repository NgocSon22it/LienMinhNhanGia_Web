using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DataAccess
{
    public partial class LienminhnhangiaContext : DbContext
    {
        IConfiguration Configuration { get; set; }
        public LienminhnhangiaContext()
        {

        }

        public LienminhnhangiaContext(DbContextOptions<LienminhnhangiaContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountAbility> AccountAbilities { get; set; }
        public virtual DbSet<AccountCharacter> AccountCharacters { get; set; }
        public virtual DbSet<AccountItem> AccountItems { get; set; }
        public virtual DbSet<AccountMission> AccountMissions { get; set; }
        public virtual DbSet<AccountPet> AccountPets { get; set; }
        public virtual DbSet<AccountSkill> AccountSkills { get; set; }
        public virtual DbSet<Boss> Bosses { get; set; }
        public virtual DbSet<BossSkill> BossSkills { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Map> Maps { get; set; }
        public virtual DbSet<MapMonster> MapMonsters { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }
        public virtual DbSet<Monster> Monsters { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ability>(entity =>
            {
                entity.ToTable("Ability");

                entity.Property(e => e.AbilityId)
                    .HasMaxLength(50)
                    .HasColumnName("Ability_ID");

                entity.Property(e => e.LevelUnlock).HasColumnName("Level_Unlock");

                entity.Property(e => e.LinkImage).HasColumnName("Link_image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.AmountSlotSkill).HasColumnName("Amount_Slot_Skill");

                entity.Property(e => e.BossKill).HasColumnName("Boss_Kill");

                entity.Property(e => e.CheckPoint)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Check_Point");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(33);

                entity.Property(e => e.PointSkill).HasColumnName("Point_Skill");

                entity.Property(e => e.Role).HasMaxLength(10);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<AccountAbility>(entity =>
            {
                entity.ToTable("Account_Ability");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AbilityId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Ability_ID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.AccountAbilities)
                    .HasForeignKey(d => d.AbilityId);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountAbilities)
                    .HasForeignKey(d => d.AccountId);
            });

            modelBuilder.Entity<AccountCharacter>(entity =>
            {
                entity.ToTable("Account_Character");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.ChakraBonus).HasColumnName("Chakra_Bonus");

                entity.Property(e => e.CharacterId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Character_ID");

                entity.Property(e => e.HealthBonus).HasColumnName("Health_Bonus");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountCharacters)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.AccountCharacters)
                    .HasForeignKey(d => d.CharacterId);
            });

            modelBuilder.Entity<AccountItem>(entity =>
            {
                entity.ToTable("Account_Item");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.ItemId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Item_ID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountItems)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.AccountItems)
                    .HasForeignKey(d => d.ItemId);
            });

            modelBuilder.Entity<AccountMission>(entity =>
            {
                entity.ToTable("Account_Mission");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.MissionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Mission_ID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountMissions)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.AccountMissions)
                    .HasForeignKey(d => d.MissionId);
            });

            modelBuilder.Entity<AccountPet>(entity =>
            {
                entity.ToTable("Account_Pet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.CurrentLevel).HasColumnName("Current_Level");

                entity.Property(e => e.PetId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Pet_ID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountPets)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.AccountPets)
                    .HasForeignKey(d => d.PetId);
            });

            modelBuilder.Entity<AccountSkill>(entity =>
            {
                entity.ToTable("Account_Skill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.CurrentLevel).HasColumnName("Current_Level");

                entity.Property(e => e.SkillId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Skill_ID");

                entity.Property(e => e.SlotIndex).HasColumnName("Slot_Index");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountSkills)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.AccountSkills)
                    .HasForeignKey(d => d.SkillId);
            });

            modelBuilder.Entity<Boss>(entity =>
            {
                entity.ToTable("Boss");

                entity.Property(e => e.BossId)
                    .HasMaxLength(50)
                    .HasColumnName("Boss_ID");

                entity.Property(e => e.CoinBonus).HasColumnName("Coin_Bonus");

                entity.Property(e => e.ExperienceBonus).HasColumnName("Experience_Bonus");

                entity.Property(e => e.LinkImage).HasColumnName("Link_image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PercentBonus).HasColumnName("Percent_Bonus");

                entity.Property(e => e.PointSkillBonus).HasColumnName("Point_Skill_Bonus");
            });

            modelBuilder.Entity<BossSkill>(entity =>
            {
                entity.ToTable("Boss_Skill");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.BossId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Boss_ID");

                entity.Property(e => e.LinkImage).HasColumnName("Link_image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Boss)
                    .WithMany(p => p.BossSkills)
                    .HasForeignKey(d => d.BossId);
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Character");

                entity.Property(e => e.CharacterId)
                    .HasMaxLength(50)
                    .HasColumnName("Character_ID");

                entity.Property(e => e.LinkImage).HasColumnName("Link_image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .HasColumnName("Item_ID");

                entity.Property(e => e.LinkImage).HasColumnName("Link_image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Map>(entity =>
            {
                entity.ToTable("Map");

                entity.Property(e => e.MapId)
                    .HasMaxLength(50)
                    .HasColumnName("Map_ID");

                entity.Property(e => e.BossId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Boss_ID");

                entity.Property(e => e.LinkImage).HasColumnName("Link_image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Boss)
                    .WithMany(p => p.Maps)
                    .HasForeignKey(d => d.BossId);
            });

            modelBuilder.Entity<MapMonster>(entity =>
            {
                entity.ToTable("Map_Monster");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MapId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Map_ID");

                entity.Property(e => e.MonsterId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Monster_ID");

                entity.HasOne(d => d.Map)
                    .WithMany(p => p.MapMonsters)
                    .HasForeignKey(d => d.MapId);

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.MapMonsters)
                    .HasForeignKey(d => d.MonsterId);
            });

            modelBuilder.Entity<Mission>(entity =>
            {
                entity.ToTable("Mission");

                entity.Property(e => e.MissionId)
                    .HasMaxLength(50)
                    .HasColumnName("Mission_ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CoinBonus).HasColumnName("Coin_Bonus");

                entity.Property(e => e.ExperienceBonus).HasColumnName("Experience_Bonus");

                entity.Property(e => e.MapId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Map_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Request).IsRequired();

                entity.HasOne(d => d.Map)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.MapId);
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.ToTable("Monster");

                entity.Property(e => e.MonsterId)
                    .HasMaxLength(50)
                    .HasColumnName("Monster_ID");

                entity.Property(e => e.CoinBonus).HasColumnName("Coin_Bonus");

                entity.Property(e => e.LinkImage).HasColumnName("Link_image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");

                entity.Property(e => e.PetId)
                    .HasMaxLength(50)
                    .HasColumnName("Pet_ID");

                entity.Property(e => e.AttackRange).HasColumnName("Attack_Range");

                entity.Property(e => e.AttackSpeed).HasColumnName("Attack_Speed");

                entity.Property(e => e.BossKillUnlock).HasColumnName("Boss_Kill_Unlock");

                entity.Property(e => e.LinkImage).HasColumnName("Link_image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateCoin).HasColumnName("Update_Coin");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.SkillId)
                    .HasMaxLength(50)
                    .HasColumnName("Skill_ID");

                entity.Property(e => e.CharacterId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Character_ID");

                entity.Property(e => e.LevelUnlock).HasColumnName("Level_Unlock");

                entity.Property(e => e.LinkImage).HasColumnName("Link_image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateCoin).HasColumnName("Update_Coin");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.CharacterId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
