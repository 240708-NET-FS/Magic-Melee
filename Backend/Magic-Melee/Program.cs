using System;
using System.Text;
using MagicMelee.Services;
using MagicMelee.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using MagicMelee.Models;

var builder = WebApplication.CreateBuilder(args);

// CORS CORS CORS
builder.Services.AddCors(co => {
    co.AddPolicy("CORS" , pb =>{
        pb.WithOrigins("*")
        .AllowAnyHeader();
    });
});
// CORS CORS CORS

// Add services to the container
//The below add json options adds an option to let the json serializer to ignore cycles
builder.Services.AddControllers()
.AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

//Here we will register our dependencies (Services and DbContext, etc) so that we can satisfy our constructors
//and inject dependecies where needed
builder.Services.AddScoped<IDndCharacterService, DndCharacterService>();
builder.Services.AddScoped<ICharacterClassService, CharacterClassService>();
builder.Services.AddScoped<ISpellService, SpellService>();
builder.Services.AddScoped<ISkillsService, SkillsService>();
builder.Services.AddScoped<IAbilityScoreArrService, AbilityScoreArrService>();
builder.Services.AddScoped<ICharacterRaceService, CharacterRaceService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Our Repos
builder.Services.AddScoped<ILoginRepo, LoginRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IDndCharacterRepo, DndCharacterRepo>();
builder.Services.AddScoped<ICharacterClassRepo, CharacterClassRepo>();
builder.Services.AddScoped<ICharacterRaceRepo, CharacterRaceRepo>();
builder.Services.AddScoped<IAbilityScoreArrRepo, AbilityScoreArrRepo>();
builder.Services.AddScoped<ISkillsRepo, SkillsRepo>();
builder.Services.AddScoped<ISpellRepo, SpellRepo>();
builder.Services.AddScoped<ICharacterSpellRepo, CharacterSpellRepo>();


builder.Services.AddDbContext<MagicMeleeContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


    builder.Services.AddIdentity<User, IdentityRole<int>>()
        .AddEntityFrameworkStores<MagicMeleeContext>()
        .AddDefaultTokenProviders();

    builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1;
});

  builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                         .AddJwtBearer(options =>
                                         {  
                                            options.TokenValidationParameters = new TokenValidationParameters
                                            {
                                            ValidateIssuer = true,
                                            ValidateAudience = true,
                                            ValidateLifetime = true,
                                            ValidateIssuerSigningKey = true,
                                            ValidIssuer = builder.Configuration["Jwt:Issuer"],
                                            ValidAudience = builder.Configuration["Jwt:Audience"],
                                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                                     };
                                 });

builder.Logging.AddConsole();



var app = builder.Build();

// // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS
app.UseCors("CORS"); //<-USE CORS with your policy name
//CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS CORS

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();