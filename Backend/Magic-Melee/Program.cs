using System;
using System.Text;
using Magic_Melee.Services;
using MagicMelee.Data;
using MagicMelee.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

//Here we will register our dependencies (Services and DbContext, etc) so that we can satisfy our constructors
//and inject dependecies where needed
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();

builder.Services.AddScoped<ILoginRepo, LoginRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();


builder.Services.AddDbContext<PokemonDBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Logging.AddConsole();

var app = builder.Build();


// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    
//     //public void ConfigureServices(IServiceCollection services)
//     //{
//     //services.AddDbContext<AppContext>(options =>
//        // options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

//     //services.AddIdentity<User, IdentityRole>()
//        // .AddEntityFrameworkStores<AppDbContext>()
//         //.AddDefaultTokenProviders();

//     //services.AddScoped<ILoginService, LoginService>();
//    // services.AddScoped<ILoginRepo, LoginRepo>();
//    // services.AddScoped<ITokenService, TokenService>();

//    // services.AddControllers();

//    // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//         //.AddJwtBearer(options =>
//       //  {
//       //      options.TokenValidationParameters = new TokenValidationParameters
//            // {
//             //    ValidateIssuer = true,
//              //   ValidateAudience = true,
//               //  ValidateLifetime = true,
//              //   ValidateIssuerSigningKey = true,
//               //  ValidIssuer = Configuration["Jwt:Issuer"],
//                // ValidAudience = Configuration["Jwt:Audience"],
//                // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
//            // };
//        // }

// }
