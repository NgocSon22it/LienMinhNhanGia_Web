namespace Obj_Common
{
    public static class ApiUrl
    {
        public const string BaseUrlCommon = "https://localhost:44374/api";
        public const string BaseUrlPlayer = "https://localhost:44323/api/Player";
        public const string BaseUrlAdmin = "https://localhost:44395/api/Admin";
    }

    public static class ApiController
    {
        public const string Ability = "Abilities";
        public const string Account = "Accounts";
        public const string Boss = "Bosses";
        public const string Character = "Characters";
        public const string Item = "Items";
        public const string Mission = "Missions";
        public const string Monster = "Monsters";
        public const string Skill = "Skills";
    }

    public static class Route
    {
        #region Common
        public static string Login = $"{ApiUrl.BaseUrlCommon}/{ApiController.Account}/Login";
        public static string Register = $"{ApiUrl.BaseUrlCommon}/{ApiController.Account}/Register";
        public static string Forgot = $"{ApiUrl.BaseUrlCommon}/{ApiController.Account}/Forgot";
        
        public static string getAllAbility = $"{ApiUrl.BaseUrlCommon}/{ApiController.Ability}/GetAllAbility";
        public static string getByIDAbility = $"{ApiUrl.BaseUrlCommon}/{ApiController.Ability}/GetAbilitybyID/" + "{0}";

        public static string getAllBoss = $"{ApiUrl.BaseUrlCommon}/{ApiController.Boss}/GetAllBoss";
        public static string getByIDBoss = $"{ApiUrl.BaseUrlCommon}/{ApiController.Boss}/GetBossbyID/" + "{0}";

        public static string getAllCharacter = $"{ApiUrl.BaseUrlCommon}/{ApiController.Character}/GetAllCharacter";
        public static string getByIDCharacter = $"{ApiUrl.BaseUrlCommon}/{ApiController.Character}/GetCharacterbyID/" + "{0}";

        public static string getAllItem = $"{ApiUrl.BaseUrlCommon}/{ApiController.Item}/GetAllItem";
        public static string getByIDItem = $"{ApiUrl.BaseUrlCommon}/{ApiController.Item}/GetItembyID/" + "{0}";

        public static string getAllMonster = $"{ApiUrl.BaseUrlCommon}/{ApiController.Monster}/GetAllMonster";
        public static string getByIDMonster = $"{ApiUrl.BaseUrlCommon}/{ApiController.Monster}/GetMonsterbyID/" + "{0}";
        #endregion


        #region Player
        public static string Profile = $"{ApiUrl.BaseUrlPlayer}/{ApiController.Account}/Profile";
        public static string UpdateProfile = $"{ApiUrl.BaseUrlPlayer}/{ApiController.Account}/UpdateProfile";
        
        public static string GetItembyAccount = $"{ApiUrl.BaseUrlPlayer}/{ApiController.Item}/GetItembyAccount";
        public static string GetAbilitybyAccount = $"{ApiUrl.BaseUrlPlayer}/{ApiController.Ability}/GetAbilitybyAccount";
        
        #endregion


        #region Admin
        public static string getAllCharacterAdmin = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Character}/GetAllCharacter";
        public static string addCharacter = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Character}/AddCharacter";
        public static string updateCharacter = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Character}/UpdateCharacter";
        public static string deleteCharacter = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Character}/DeleteCharacter";


        public static string getAllAccountAdmin = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Account}/GetAllAccount";
        public static string deleteAccount = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Account}/DeleteAccount";
        public static string addAccount = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Account}/AddAccount";
        public static string detailAccount = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Account}/GetbyID/" + "{0}";

        public static string getAllMonsterAdmin = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Monster}/GetAllMonster";
        public static string addMonster = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Monster}/AddMonster";
        public static string updateMonster = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Monster}/UpdateMonster";
        public static string deleteMonsterr = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Monster}/DeleteMonster";

        public static string getAllBossAdmin = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Boss}/GetAllBoss";
        public static string addBoss = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Boss}/AddBoss";
        public static string updateBoss = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Boss}/UpdateBoss";
        public static string deleteBoss = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Boss}/DeleteBoss";

        public static string addItem = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Item}/AddItem";
        public static string updateItem = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Item}/UpdateItem";
        public static string deleteItem = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Item}/DeleteItem";

        public static string addAbility = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Ability}/AddAbility";
        public static string updateAbility = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Ability}/UpdateAbility";
        public static string deleteAbility = $"{ApiUrl.BaseUrlAdmin}/{ApiController.Ability}/DeleteAbility";

        #endregion
    }
}
