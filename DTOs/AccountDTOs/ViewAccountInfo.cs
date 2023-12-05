using Obj_Common;

namespace DTOs.AccountDTOs
{
    public class ViewAccountInfo
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public string Avatar { get; set; }
        public int Coin { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public string CheckPoint { get; set; } 
        public int PointSkill { get; set; }
    }
}
