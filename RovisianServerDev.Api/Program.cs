using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RovisianServerDev.Domain.Repositories;
using RovisianServerDev.Domain.Services;
using RovisianServerDev.Domain.UseCases.Banco;
using RovisianServerDev.Domain.UseCases.Rol;
using RovisianServerDev.Domain.UseCases.State;
using RovisianServerDev.Domain.UseCases.User;
using RovisianServerDev.Infrastructure.Data;
using RovisianServerDev.Infrastructure.Filter;
using RovisianServerDev.Infrastructure.Repositories;
using RovisianServerDev.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Filtro para validar el modelo de forma globlal
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

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(session =>
{
    session.IdleTimeout = TimeSpan.FromMinutes(30);
    session.Cookie.HttpOnly = true;
    session.Cookie.IsEssential = true;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

