namespace EConnectSocialMedia.API.Controllers.AccountEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Authorization")]
    [Route("api/v{version:apiVersion}/Account/[controller]")]
    [ApiVersion("1.0")]
    [AllowAll]
    public class AuthorizationController : ControllerBase
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public AuthorizationController(
            DatabaseContext dataContext,
            UnitOfWork unitOfWork,
            IMapper mapper,
            EntityLocalizationService Localizer,
            IAccountService AccountService,
            IWebHostEnvironment environment,
            IOptions<AppSettings> appSettings)
        {
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Localizer = Localizer;
            _AccountService = AccountService;
            _Environment = environment;
            _appSettings = appSettings.Value;
            _StatusHandler = new StatusHandler(Localizer);
        }

        /// <summary>
        /// Post: Login
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public AuthenticateResponse Login(
            [FromQuery] string Culture,
            [FromBody] AuthenticateRequest model)
        {
            AuthenticateResponse returnData = new();

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                returnData = _AccountService.Authenticate(model, IpAddress());

                SetJwtTokenHeader(returnData.JwtToken);
                SetRefresh(returnData.RefreshToken);

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Create Account
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public async Task<AuthenticateResponse> Register(
            [FromQuery] string Culture,
            [FromBody] RegisterModel model)
        {
            AuthenticateResponse returnData = new();

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your profile!");
                }

                if (_UnitOfWork.Account.Any(a => a.Phone == model.Phone))
                {
                    throw new AppException("Phone already registered!");
                }

                Account account = new();
                _Mapper.Map(model, account);

                if (account.Fk_Gender == 0)
                {
                    account.Fk_Gender = (int)GenderEnum.Male;
                }

                account.PasswordHash = BC.HashPassword(model.Password);
                account.IsVerified = true;
                account.Fk_AccountState = (int)AccountStateEnum.Active;

                _UnitOfWork.Account.CreateEntity(account);

                await _UnitOfWork.Save();

                returnData = _AccountService.Authenticate(new AuthenticateRequest
                {
                    Phone = model.Phone,
                    Password = model.Password,
                }, IpAddress());

                SetJwtTokenHeader(returnData.JwtToken);
                SetRefresh(returnData.RefreshToken);

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Edit Profile
        /// </summary>
        [HttpPost]
        [Route(nameof(EditProfile))]
        public async Task<AccountModel> EditProfile(
            [FromQuery] string Culture,
            [FromBody] AccountEditModel model)
        {
            AccountModel returnData = new();

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                Account data = await _UnitOfWork.Account.GetFirst(a => a.Id == account.Id);

                _Mapper.Map(model, data);

                data.LastModifiedBy = account.FullName;

                _UnitOfWork.Account.UpdateEntity(data);

                _Mapper.Map(data, returnData);

                _UnitOfWork.Account.Save();

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Get Profile
        /// </summary>
        [HttpGet]
        [Route(nameof(GetProfile))]
        public async Task<AccountModel> GetProfile(
            [FromQuery] string Culture,
            [FromQuery] string UniqueName,
            [FromQuery] string Phone,
            [FromQuery] int id = 0)
        {
            AccountModel returnData = new();

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (id == 0 &&
                    string.IsNullOrWhiteSpace(UniqueName) &&
                    string.IsNullOrWhiteSpace(Phone))
                {
                    id = account.Id;
                }

                Account data = await _UnitOfWork.Account.GetFirst(a => (id == 0 || a.Id == id) &&
                                                                       (string.IsNullOrWhiteSpace(UniqueName) || a.UniqueName == UniqueName) &&
                                                                       (string.IsNullOrWhiteSpace(Phone) || a.Phone == Phone));

                _Mapper.Map(data, returnData);

                returnData.IsOwner = returnData.Id == account.Id;

                if (data.Id != account.Id &&
                    _UnitOfWork.Chat.Any(a => a.Fk_ChatType == (int)ChatTypeEnum.Private &&
                                              a.ChatMembers.Any(b => b.Fk_Account == data.Id) &&
                                              a.ChatMembers.Any(b => b.Fk_Account == account.Id)))
                {

                    returnData.Fk_Chat = _UnitOfWork.Chat.GetQuery(a => a.Fk_ChatType == (int)ChatTypeEnum.Private &&
                                                         a.ChatMembers.Any(b => b.Fk_Account == data.Id) &&
                                                         a.ChatMembers.Any(b => b.Fk_Account == account.Id))
                                                         .Select(a => a.Id)
                                                         .First();
                }

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Edit Phone
        /// </summary>
        [HttpPost]
        [Route(nameof(EditPhone))]
        public async Task<bool> EditPhone(
            [FromQuery] string Culture,
            [FromBody] EditPhoneModel model)
        {
            bool returnData = default;

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your profile!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (account.Phone == model.Phone)
                {
                    throw new AppException("Phone already registered in your profile!");
                }

                Account data = await _UnitOfWork.Account.GetByID(account.Id);

                data.Phone = model.Phone;
                data.LastModifiedBy = data.FullName;
                data.LastModifiedAt = DateTime.UtcNow;

                _UnitOfWork.Account.UpdateEntity(data);
                await _UnitOfWork.Save();

                returnData = true;

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Set Verification Code
        /// </summary>
        [HttpPost]
        [Route(nameof(SetVerificationCode))]
        [AllowAnonymous]
        public async Task<bool> SetVerificationCode(
            [FromQuery] string Culture,
            [FromBody] SetVerificationCodeModel model)
        {
            bool returnData = default;

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your profile!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                Account data = await _UnitOfWork.Account.GetByID(account.Id);

                data.VerificationCodeHash = BC.HashPassword(model.VerificationCode);
                data.VerificationAt = DateTime.UtcNow;

                data.LastModifiedBy = data.FullName;

                _UnitOfWork.Account.UpdateEntity(data);
                await _UnitOfWork.Save();

                returnData = true;

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Verify Phone
        /// </summary>
        [HttpPost]
        [Route(nameof(VerifyPhone))]
        [AllowAnonymous]
        public async Task<bool> VerifyPhone(
            [FromQuery] string Culture,
            [FromBody] VerifyPhoneModel model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                Account data = await _UnitOfWork.Account.GetByID(account.Id);

                if (data.VerificationAt.AddMinutes(30) < DateTime.UtcNow)
                {
                    throw new AppException("Verification code is Expired");
                }

                if (!string.IsNullOrEmpty(data.VerificationCodeHash) &&
                    BC.Verify(model.Code, data.VerificationCodeHash))
                {
                    data.IsVerified = true;
                    data.LastModifiedBy = data.FullName;

                    _UnitOfWork.Account.UpdateEntity(data);
                    await _UnitOfWork.Save();

                    returnData = true;

                    Status = new Status(true);
                }
                else
                {
                    throw new AppException("Verification code is wrong!");
                }
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Change Profile Image
        /// </summary>
        [HttpPost]
        [Route(nameof(ChangeProfileImage))]
        public async Task<string> ChangeProfileImage(
            [FromQuery] string Culture,
            [FromForm] ProfileImageModel model)
        {
            string returnData = default;

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                Account data = await _UnitOfWork.Account.GetByID(account.Id);

                if (model.ProfileImage != null)
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, account.Id.ToString(), model.ProfileImage, "Uploud/Account");

                    if (!string.IsNullOrEmpty(FileURL))
                    {
                        data.ImageURL = FileURL;
                    }
                }

                data.LastModifiedBy = data.FullName;

                _UnitOfWork.Account.UpdateEntity(data);
                await _UnitOfWork.Save();

                returnData = data.ImageURL;

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Remove Profile Image
        /// </summary>
        [HttpPost]
        [Route(nameof(RemoveProfileImage))]
        public async Task<bool> RemoveProfileImage(
            [FromQuery] string Culture)
        {
            bool returnData = false;

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                Account data = await _UnitOfWork.Account.GetByID(account.Id);

                data.ImageURL = null;

                data.LastModifiedBy = data.FullName;

                _UnitOfWork.Account.UpdateEntity(data);

                await _UnitOfWork.Save();

                returnData = true;

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Change Password
        /// </summary>
        [HttpPost]
        [Route(nameof(ChangePassword))]
        public async Task<bool> ChangePassword(
            [FromQuery] string Culture,
            [FromBody] ChangePasswordModel model)
        {
            bool returnData = default;

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                Account data = await _UnitOfWork.Account.GetByID(account.Id);

                if (!BC.Verify(model.OldPassword, data.PasswordHash))
                {
                    throw new AppException("Old password is incorrect!");
                }

                data.PasswordHash = BC.HashPassword(model.NewPassword);
                data.LastModifiedBy = data.FullName;

                _UnitOfWork.Account.UpdateEntity(data);
                await _UnitOfWork.Save();

                returnData = true;
                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Add Device
        /// </summary>
        [HttpPost]
        [Route(nameof(AddDevice))]
        public async Task<bool> AddDevice(
            [FromQuery] string Culture,
            [FromBody] AccountDeviceCreateModel model)
        {
            Status Status = new();
            bool returnData = default;

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                AccountDevice accountDevice = new();

                _Mapper.Map(model, accountDevice);

                accountDevice.Fk_Account = account.Id;

                await _UnitOfWork.Save();

                returnData = true;
                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Check phone if existing
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(CheckPhone))]
        public void CheckPhone(
            [FromQuery] string Culture,
            [FromBody] EditPhoneModel model)
        {
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                if (!_UnitOfWork.Account.Any(a => a.Phone == model.Phone))
                {
                    throw new AppException("Phone not registered, register now!");
                }

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));
        }

        /// <summary>
        /// Post: Send Phone Code if you out from app
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(ForgetPassword))]
        public async Task ForgetPassword(
            [FromQuery] string Culture,
            [FromBody] ForgetPasswordModel model)
        {
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                if (!_UnitOfWork.Account.Any(a => a.Phone == model.Phone))
                {
                    throw new AppException("Phone not registered, register now!");
                }

                Account data = await _UnitOfWork.Account.GetFirst(a => a.Phone == model.Phone);

                data.VerificationCodeHash = model.Code;
                data.VerificationAt = DateTime.UtcNow;

                _UnitOfWork.Account.UpdateEntity(data);
                await _UnitOfWork.Save();

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));
        }

        /// <summary>
        /// Post: Reset Password
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(ResetPassword))]
        public async Task<AuthenticateResponse> ResetPassword(
            [FromQuery] string Culture,
            [FromBody] ResetPasswordModel model)
        {
            AuthenticateResponse returnData = new();

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                if (_UnitOfWork.Account.Any(a => a.Phone == model.Phone))
                {
                    Account account = await _UnitOfWork.Account.GetFirst(a => a.Phone == model.Phone);

                    if (!string.IsNullOrEmpty(account.VerificationCodeHash) &&
                    string.Equals(model.Code, account.VerificationCodeHash))
                    {
                        account.VerificationCodeHash = null;

                        account.PasswordHash = BC.HashPassword(model.NewPassword);
                        account.LastModifiedAt = DateTime.UtcNow;

                        _UnitOfWork.Account.UpdateEntity(account);
                        await _UnitOfWork.Save();

                        returnData = _AccountService.Authenticate(new AuthenticateRequest
                        {
                            Phone = account.Phone,
                            Password = model.NewPassword
                        }, IpAddress());

                        SetJwtTokenHeader(returnData.JwtToken);
                        SetRefresh(returnData.RefreshToken);

                        Status = new Status(true);
                    }
                    else
                    {
                        throw new AppException("Code is wrong!");
                    }
                }
                else
                {
                    throw new AppException("The phone not found!");
                }
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: RefreshToken
        /// </summary>
        [HttpPost]
        [Route(nameof(RefreshToken))]
        [AllowAnonymous]
        public AuthenticateResponse RefreshToken(
            [FromQuery] string Culture,
            [FromBody] RefreshTokenRequest model)
        {
            AuthenticateResponse returnData = new();

            Status Status = new();

            try
            {
                string token = model.Token;
                token = WebUtility.UrlDecode(token);
                token = token.Replace(" ", "+");

                if (string.IsNullOrEmpty(token))
                {
                    throw new AppException("Token is required!");
                }

                AuthenticateResponse response = _AccountService.RefreshToken(token, IpAddress());

                returnData = response;
                SetJwtTokenHeader(response.JwtToken);
                SetRefresh(response.RefreshToken);

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Revoke Token
        /// </summary>
        [HttpPost]
        [Route(nameof(RevokeToken))]
        [AllowAnonymous]
        public void RevokeToken(
            [FromQuery] string Culture,
            [FromBody] RevokeTokenRequest model)
        {
            Status Status = new();

            try
            {
                // accept refresh token in request body or cookie
                string token = model.Token ?? Request.Cookies["refreshToken"];

                if (string.IsNullOrEmpty(token))
                {
                    throw new AppException("Token is required!");
                }

                _AccountService.RevokeToken(token, IpAddress());

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));
        }

        private void SetRefresh(string token)
        {
            Response.Headers.Add("Set-Refresh", _StatusHandler.GetRefresh(token));
        }

        private void SetJwtTokenHeader(string token)
        {
            Response.Headers.Add("Expires", _StatusHandler.GetExpires());
            Response.Headers.Add("Authorization", token);
        }

        private string IpAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }
    }
}
