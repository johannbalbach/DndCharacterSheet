using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DndCharacterSheetAPI.JWT
{
    public class JwtConfigurations
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int AccessLifeTime { get; set; }
        public int RefreshLifeTime { get; set; }

        public static SymmetricSecurityKey GetSymmetricSecurityKey(string Key = "")
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
