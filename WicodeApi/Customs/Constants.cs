using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WicodeApi.Customs;

public static class Constants
{
    private const string SECRET_KEY = "EverythingAsCodeByWicode";

    public static readonly SymmetricSecurityKey SIGN_KEY = new(Encoding.UTF8.GetBytes(SECRET_KEY));

    public static readonly string AppLogin = "Cryptographie";
    
    public static readonly string AppPassword = "Wicode";




}
