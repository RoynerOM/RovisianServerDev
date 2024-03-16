using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RovisianServerDev.Application.UseCases.Banco;
using RovisianServerDev.Application.UseCases.Rol;
using RovisianServerDev.Application.UseCases.State;
using RovisianServerDev.Application.UseCases.Security;
using RovisianServerDev.Application.UseCases.User;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Services;
using RovisianServerDev.Domain.UseCases.User;
using RovisianServerDev.Infrastructure.Data;
using RovisianServerDev.Infrastructure.Filter;
using RovisianServerDev.Infrastructure.Filters;
using RovisianServerDev.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Carga las variables de entorno
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Fluent para validar los campos del DTO que son requeridos o que tengan el formato correcto
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Servicio que permite la compresion de datos de respuesta para que sean mas liviados
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
});

// Configuracion para autenticación basada en Tokens
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // Validacion del token recibidos
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        // Firma de token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

//Filtro para validar el modelo recibido de forma globlal y automatico
builder.Services.AddMvc(x => x.Filters.Add<ValidationFilter>());

//DBContext
builder.Services.AddDbContext<RovisianDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Rovisian")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Services of Estado
builder.Services.AddTransient<IStateService, StateService>();
builder.Services.AddTransient<IGetAllStatesUseCase, GetAll>();
builder.Services.AddTransient<IGetByIdStatesUseCase, GetByIdStateCase>();
builder.Services.AddTransient<ISaveStatesUseCase, SaveStateCase>();
builder.Services.AddTransient<IUpdateStatesUseCase, UpdateStateCase>();
builder.Services.AddTransient<IDeleteStatesUseCase, DeleteStateCase>();

// Rol
builder.Services.AddTransient<IRolService, RolService>();
builder.Services.AddTransient<IGetAllRolUseCase, GetAllRolCase>();
builder.Services.AddTransient<IGetByIdRolUseCase, GetByIdRolCase>();
builder.Services.AddTransient<IDeleteRolUseCase, DeleteRolCase>();
builder.Services.AddTransient<IUpdateRolUseCase, UpdateRolCase>();
builder.Services.AddTransient<ISaveRolUseCase, SaveRolCase>();

// Banco
builder.Services.AddTransient<IBancoService, BancoService>();
builder.Services.AddTransient<IGetAllBancoUseCase, GetAllBancoCase>();
builder.Services.AddTransient<IGetByIdBancoUseCase, GetByIdBancoCase>();
builder.Services.AddTransient<IDeleteBancoUseCase, DeleteBancoCase>();
builder.Services.AddTransient<IUpdateBancoUseCase, UpdateBancoCase>();
builder.Services.AddTransient<ISaveBancoUseCase, SaveBancoCase>();

// Usuario
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IGetAllUsersUseCase, GetAllUsers>();
builder.Services.AddTransient<IGetByIdUserUseCase, GetByIdUser>();
builder.Services.AddTransient<IDeleteUserUseCase, DeleteUser>();
builder.Services.AddTransient<IUpdateUserUseCase, UpdateUser>();
builder.Services.AddTransient<ISaveUserUseCase, SaveUser>();

//Token
builder.Services.AddTransient<ICreateTokenUseCase, CreateToken>();
builder.Services.AddTransient<IIsValidUserUseCase, IsValidUser>();

//Hashes
builder.Services.AddTransient<IPasswordService, PasswordService>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(session =>
{
    session.IdleTimeout = TimeSpan.FromMinutes(30);
    session.Cookie.HttpOnly = true;
    session.Cookie.IsEssential = true;

});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseSession();
app.UseHttpsRedirection();
app.MapControllers();
app.UseResponseCompression();
app.UseAuthorization();
app.Run();

