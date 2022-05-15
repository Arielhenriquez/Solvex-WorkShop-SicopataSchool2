using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SegundaAsignacion.BL.Mappings;
using SegundaAsignacion.BL.Validators;
using SegundaAsignacion.Model.Context;
using SegundaAsignacion.Model.Repository;
using SegundaAsignacion.Services.GenericServices;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string myAppDbContextConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SegundaAsignacionDbContext>(op => op.UseSqlServer(myAppDbContextConnection),
    ServiceLifetime.Transient);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ICrudEstudiantes, CrudEstudiantes>();
builder.Services.AddTransient<ICrudNotas, CrudNotas>();


builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidacionEstudiantes>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidacionNotas>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.
          GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
          ValidateIssuer = false,
          ValidateAudience = false
      };

  });

var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new EstudiantesProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
