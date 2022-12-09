using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Stx.Api.Hrm.Configurations;
using Stx.Api.Hrm.Infrastructure.Image;
using Stx.Api.Hrm.Interfaces;
using Stx.Api.Hrm.Interfaces.Account;
using Stx.Api.Hrm.Interfaces.CRM;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Api.Hrm.Interfaces.Services;
using Stx.Api.Hrm.Repos;
using Stx.Api.Hrm.Repos.CRM;
using Stx.Api.Hrm.Repos.HRM;
using Stx.Api.Hrm.Services;
using Stx.Shared.Api.Interfaces;
using Stx.Shared.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
builder.Services.AddDbContext<StxDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Dont change this position
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 2;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<StxDbContext>();

builder.Services.AddControllersWithViews();

#region JWT Validations--------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
    {
        builder.Configuration.Bind("AzureAdB2C", options);
        options.TokenValidationParameters.NameClaimType = "name";
    },
    options => { builder.Configuration.Bind("AzureAdB2C", options); });

#region Authorization policies 
builder.Services.AddAuthorization(options =>
{
    //validation:  make sure the token is for scope 'hrm.jp.api'
    options.AddPolicy("PolicyApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "hrm.jp.api");
    });

    //Domain Policies
    options.AddPolicy("PolicyCandidate", policy => policy.RequireClaim("user_group", "cand"));
    options.AddPolicy("PolicyJobOwner", policy => policy.RequireClaim("user_group", "110", "111", "112"));
    options.AddPolicy("PolicyJobRecruiter", policy => policy.RequireClaim("user_group", "113"));
});

#endregion
#endregion

#region Azure Storage ----------
builder.Services.Configure<AzureStorageConfiguration>(builder.Configuration.GetSection("AzureStorageConfiguration"));
builder.Services.AddSingleton<BlobServiceClient>(new BlobServiceClient(builder.Configuration["AzureStorageConfiguration:Url"]));
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();
#endregion

#region Domain Repositories----------
//General
builder.Services.AddScoped<IImageHandler, ImageHandler>();
builder.Services.AddScoped<ICdnFileService, CdnFileService>();
builder.Services.AddScoped<IStxGeneralRepository, StxGeneralRepository>();
builder.Services.AddScoped<ICommonDataRepository, CommonDataRepository>();
builder.Services.AddScoped<IHrmGeneralRepository, HrmGeneralRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountClaimRepository, AccountClaimRepository>();

//CRM
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICorporateRepository, CorporateRepository>();
builder.Services.AddScoped<ICorporatePublicRepository, CorporatePublicRepository>();
builder.Services.AddScoped<ICorporateSettingsRepository, CorporateSettingsRepository>();

//HRM
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateSignupRepository, CandidateSignupRepository>();
builder.Services.AddScoped<ICandidateProfileRepository, CandidateProfileRepository>();
builder.Services.AddScoped<ICandidatePublicRepository, CandidatePublicRepository>();
builder.Services.AddScoped<IJobCandidateRepository, JobCandidateRepository>();
builder.Services.AddScoped<IJobOrderRepository, JobOrderRepository>();
builder.Services.AddScoped<IJobOrderPreviewRepository, JobOrderPreviewRepository>();
builder.Services.AddScoped<IJobSearchRepository, JobSearchRepository>();
builder.Services.AddScoped<IJobSendoutRepository, JobSendoutRepository>();

#endregion

#region Api Versioning---------------
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    //config.ApiVersionReader = new ();
});
#endregion

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("AllowAnyOrigin", builder =>
        builder.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
});

builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAnyOrigin");

//app.UseAuthorization();

app.MapControllers();

app.Run();