
using BL;
using BL.Services;
using Contract;
using Entity;
using Microsoft.EntityFrameworkCore;
using Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAirPortLogic, AirPortLogic>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<ILegService, LegService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
//builder.Services.AddDbContext<AirPortContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddSingleton<AirPortContext>(new AirPortContext(new DbContextOptionsBuilder<AirPortContext>().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).Options));

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.MapControllerRoute(
name: "default",
pattern: "{controller=AirPort}/{action=Get}/{id?}");

app.Run();
