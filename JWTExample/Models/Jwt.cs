using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace JWTExample.Models
{
    public class Jwt : IJwt
    {
        private string _jwtToken;
        public Jwt(string jwtToken)
        {
            _jwtToken = jwtToken;
        }

        public string Authenticate(string username, string password)
        {
            string strToken = null;
            FilmDBContext filmDB = new FilmDBContext();
            User user = filmDB.Users.Where(u => u.Name == username && u.Password == password).SingleOrDefault();
            if (user != null)
            {
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var bytKey = Encoding.UTF8.GetBytes(_jwtToken); //Disaridan gelen Key degeri Byte dizisine cevrilir.

                var tokenDesc = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) }),
                    Expires = DateTime.Now.AddHours(1),  //1 saat token gecerlilik suresi.
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytKey), SecurityAlgorithms.HmacSha256Signature) //Hangi sifreleme algoritmasinin kullanilcagi tanimlanir.
                };

                var token = tokenHandler.CreateToken(tokenDesc); //Token descriptor bilgileri kullanilarak Token burada olusturulur.
                strToken = tokenHandler.WriteToken(token);
            }
            return strToken;
        }
    }
}
