using Microsoft.EntityFrameworkCore;
using RovisianServerDev.Domain.Repositories;
using RovisianServerDev.Domain.Services;
using RovisianServerDev.Domain.UseCases.State;
using RovisianServerDev.Infrastructure.Data;
using RovisianServerDev.Infrastructure.Repositories;
using RovisianServerDev.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DBContext
builder.Services.AddDbContext<RovisianDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Rovisian")));

// Services of Estado
builder.Services.AddTransient<IStateService, StateService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IGetAllStatesUseCase, GetAll>();
builder.Services.AddTransient<IGetByIdStatesUseCase, GetByIdStateCase>();
builder.Services.AddTransient<ISaveStatesUseCase, SaveStateCase>();
builder.Services.AddTransient<IUpdateStatesUseCase, UpdateStateCase>();
builder.Services.AddTransient<IDeleteStatesUseCase, DeleteStateCase>();
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

