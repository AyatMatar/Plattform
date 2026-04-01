using API.Helpers;
using API.Models.Domain;
using API.Repsitories.Abstract;
using API.Repsitories.Implemintation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddTransient<IUserRepository,UserRepository>(); //solved Dependancy
builder.Services.AddTransient<ICourseRepository, CourseRepository>(); //solved Dependancy
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>(); //solved Dependancy
builder.Services.AddTransient<IAuthRepository, AuthRepository>(); //solved Dependancy
builder.Services.AddTransient<ISectionRepository, SectionRepository>(); //solved Dependancy

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var secretKey = builder.Configuration.GetSection("AppSettings:key").Value;
var key = new SymmetricSecurityKey(Encoding.UTF8
               .GetBytes(secretKey));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = key,
        ClockSkew = TimeSpan.Zero
        
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(option => option.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
