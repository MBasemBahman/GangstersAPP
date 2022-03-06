using System.Security.Cryptography;
using static EConnectSocialMedia.Entity.EntityEnum;
using BC = BCrypt.Net.BCrypt;
namespace EConnectSocialMedia.Repository.AuthEntityRepository
{
    public class SystemUserRepository : AppBaseRepository<SystemUser>
    {
        private readonly DatabaseContext DBContext;
        private readonly IMapper _Mapper;

        public SystemUserRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }


        public SystemUser Authenticate(string Email, string Password, int Expires)
        {
            SystemUser systemUser = null;

            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                systemUser = DBContext.SystemUser
                                      .SingleOrDefault(x => x.Email == Email);
                //systemUser.PasswordHash = BC.HashPassword(Password);
                // validate
                if (systemUser == null || (systemUser != null && !BC.Verify(Password, systemUser.PasswordHash)))
                {
                    throw new Exception("Email or password is incorrect");
                }
            }

            systemUser = GenerateToken(systemUser, Expires);
            UpdateEntity(systemUser);
            DBContext.SaveChanges();

            return systemUser;
        }

        public static SystemUser GenerateToken(SystemUser systemUser, int Expires = 14)
        {
            // generate token that is valid for 14 days
            using RNGCryptoServiceProvider rngCryptoServiceProvider = new();
            byte[] randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);

            systemUser.Token = Convert.ToBase64String(randomBytes);
            systemUser.Expires = DateTime.UtcNow.AddDays(14);
            systemUser.Token = Convert.ToBase64String(randomBytes);

            return systemUser;
        }

        public bool UserExists(string Token)
        {
            SystemUser systemUser = DBContext.SystemUser
                                             .SingleOrDefault(a => !string.IsNullOrEmpty(Token) &&
                                                                   a.Token == Token &&
                                                                   a.IsActive);

            return (systemUser != null && !systemUser.IsExpired);
        }

        public bool UserExists(string Email, string Password = null)
        {
            return DBContext.SystemUser
                   .Where(a => a.Email == Email)
                   .Where(a => Password == null ? true : a.PasswordHash == Password)
                   .Where(a => a.IsActive == true)
                   .Any();
        }

        public SystemUser GetByToken(string Token)
        {
            return DBContext.SystemUser.Single(a => a.Token == Token);
        }

        public SystemUser GetByEmail(string Email)
        {
            return DBContext.SystemUser.FirstOrDefault(a => a.Email == Email);
        }

        public Dictionary<string, string> GetViews(int Fk_SystemRole)
        {
            return DBContext.SystemRolePremission
                            .Where(a => a.Fk_SystemRole == Fk_SystemRole)
                            .Include(a => a.SystemView)
                            .ToDictionary(a => a.SystemView.Name, a => a.Fk_AccessLevel.ToString());
        }

        public bool CheckAuthorization(int Fk_SystemRole, string ViewName, int Fk_AccessLevel)
        {
            SystemRolePremission SystemUser = DBContext.SystemRolePremission.FirstOrDefault(a => a.Fk_SystemRole == Fk_SystemRole && a.SystemView.Name == ViewName);

            if (SystemUser != null)
            {
                if (SystemUser.Fk_AccessLevel == (int)AccessLevelEnum.FullAccess)
                {
                    return true;
                }
                else if (SystemUser.Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess)
                {
                    if (Fk_AccessLevel == (int)AccessLevelEnum.ControlAccess
                        || Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
                    {
                        return true;
                    }
                }
                else if (SystemUser.Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
                {
                    if (Fk_AccessLevel == (int)AccessLevelEnum.ViewAccess)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
