using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlite(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));

builder.Services.AddMemoryCache();

// Bearer
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
    o.TokenValidationParameters = new TokenValidationParameters {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddSwaggerGen(
    o => {
        o.SwaggerDoc("v1", new OpenApiInfo { Title = "JuniorJavaNet", Version = "v1" });
        //*/ Don't use in prod: fail push in azure 
        var sec1 = new OpenApiSecurityScheme {
            BearerFormat = "JWT",
            Description = "JuniorJavaNet",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            Reference = new OpenApiReference {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };
       o.AddSecurityDefinition(sec1.Reference.Id, sec1);
        //o.AddSecurityRequirement(securityReq);
        o.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {sec1,Array.Empty<string>() }
        });
        //*/
    }
);

builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();



app.UseAuthorization();

app.MapControllers();

app.Run();
