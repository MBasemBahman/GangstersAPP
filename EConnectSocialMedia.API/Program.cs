using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json.Linq;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSignalR();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddAutoMapper(c => c.AddProfile<Mapping>(), typeof(Program));

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IAccountService, AccountService>();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.MapType<TimeSpan>(() => new OpenApiSchema
    {
        Type = "string",
        Example = new OpenApiString("hh:mm:ss")
    });

    c.MapType<DateTime>(() => new OpenApiSchema
    {
        Type = "string",
        Example = new OpenApiString("yyyy-MM-ddThh:mm:ss")
    });

    c.SwaggerDoc("Authorization", new OpenApiInfo { Title = "Authorization", Version = "v1" });
    c.SwaggerDoc("Accounts", new OpenApiInfo { Title = "AccountEntity/Accounts", Version = "v1" });
    c.SwaggerDoc("AccountMainData", new OpenApiInfo { Title = "AccountEntity/AccountMainData", Version = "v1" });

    c.SwaggerDoc("GroupMainData", new OpenApiInfo { Title = "GroupEntity/GroupMainData", Version = "v1" });
    c.SwaggerDoc("Group", new OpenApiInfo { Title = "GroupEntity/Group", Version = "v1" });

    c.SwaggerDoc("PostMainData", new OpenApiInfo { Title = "PostEntity/PostMainData", Version = "v1" });
    c.SwaggerDoc("Post", new OpenApiInfo { Title = "PostEntity/Post", Version = "v1" });

    c.SwaggerDoc("ChatMainData", new OpenApiInfo { Title = "ChatEntity/ChatMainData", Version = "v1" });
    c.SwaggerDoc("Chat", new OpenApiInfo { Title = "ChatEntity/Chat", Version = "v1" });

    c.SwaggerDoc("Notification", new OpenApiInfo { Title = "NotificationEntity/Notification", Version = "v1" });

    c.SwaggerDoc("MainData", new OpenApiInfo { Title = "MainData", Version = "v1" });

    c.SwaggerDoc("CHIAData", new OpenApiInfo { Title = "CHIAData", Version = "v1" });

    c.SwaggerDoc("Location", new OpenApiInfo { Title = "Location", Version = "v1" });


    c.SwaggerDoc("ServiceProviderRequestMainData", new OpenApiInfo { Title = "ServiceProviderRequestEntity/ServiceProviderRequestMainData", Version = "v1" });
    c.SwaggerDoc("ServiceProviderRequest", new OpenApiInfo { Title = "ServiceProviderRequestEntity/ServiceProviderRequest", Version = "v1" });


    c.SwaggerDoc("BeneficiaryRequestMainData", new OpenApiInfo { Title = "BeneficiaryRequestEntity/BeneficiaryRequestMainData", Version = "v1" });
    c.SwaggerDoc("BeneficiaryRequest", new OpenApiInfo { Title = "BeneficiaryRequestEntity/BeneficiaryRequest", Version = "v1" });




    c.OperationFilter<DocsHeaderFilter>();

    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

#endregion

#region Cors

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.SetIsOriginAllowed(origin => true)
               .AllowAnyMethod()
               .WithExposedHeaders("X-Status", "X-Pagination", "Authorization", "Expires", "Set-Refresh")
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

#endregion

#region Versioning

builder.Services.AddApiVersioning(config =>
{
    // Specify the default API Version
    config.DefaultApiVersion = new ApiVersion(1, 0);
    // If the client hasn't specified the API version in the request, use the default API version number 
    config.AssumeDefaultVersionWhenUnspecified = true;
    // Advertise the API versions supported for the particular endpoint
    config.ReportApiVersions = true;
});

#endregion

#region Localization

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    CultureInfo[] supportedCultures = new[]
    {
                    new CultureInfo("en"),
                    new CultureInfo("ar")
                };
    options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "ar");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddSingleton<EntityLocalizationService>();

#endregion


JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));

FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromJson(jAppSettings["GoogleCredential"].ToString())
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

#region Swagger

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/Authorization/swagger.json", "Authorization");
    c.SwaggerEndpoint("/swagger/Accounts/swagger.json", "Accounts");
    c.SwaggerEndpoint("/swagger/AccountMainData/swagger.json", "AccountEntity/AccountMainData");

    c.SwaggerEndpoint("/swagger/GroupMainData/swagger.json", "GroupEntity/GroupMainData");
    c.SwaggerEndpoint("/swagger/Group/swagger.json", "GroupEntity/Group");

    c.SwaggerEndpoint("/swagger/PostMainData/swagger.json", "PostEntity/PostMainData");
    c.SwaggerEndpoint("/swagger/Post/swagger.json", "PostEntity/Post");

    c.SwaggerEndpoint("/swagger/ChatMainData/swagger.json", "ChatEntity/ChatMainData");
    c.SwaggerEndpoint("/swagger/Chat/swagger.json", "ChatEntity/Chat");

    c.SwaggerEndpoint("/swagger/Notification/swagger.json", "NotificationEntity/Notification");

    c.SwaggerEndpoint("/swagger/MainData/swagger.json", "MainData");
    c.SwaggerEndpoint("/swagger/CHIAData/swagger.json", "CHIAData");
    c.SwaggerEndpoint("/swagger/Location/swagger.json", "Location");


    c.SwaggerEndpoint("/swagger/ServiceProviderRequestMainData/swagger.json", "ServiceProviderRequestEntity/ServiceProviderRequestMainData");
    c.SwaggerEndpoint("/swagger/ServiceProviderRequest/swagger.json", "ServiceProviderRequestEntity/ServiceProviderRequest");

    c.SwaggerEndpoint("/swagger/BeneficiaryRequestMainData/swagger.json", "BeneficiaryRequestEntity/BeneficiaryRequestMainData");
    c.SwaggerEndpoint("/swagger/BeneficiaryRequest/swagger.json", "BeneficiaryRequestEntity/BeneficiaryRequest");




    c.RoutePrefix = "docs";
});

#endregion

app.UseRouting();
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers",
          "Origin, X-Requested-With, Content-Type, Accept");
    }
});
app.UseFileServer();
app.UseCors();
app.UseRequestLocalization(app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value);

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/hub");
    endpoints.MapControllers();
});

app.Run();
