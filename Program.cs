using Microsoft.EntityFrameworkCore;
using ms.Context.MySql;
using ms.Context.SqlServer;
using ms.Repository;
using ms.Services;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);
// creacion de cadenas de conexion

var DbCRMexp = builder.Configuration.GetConnectionString("CRMexp");
var DbVFmid = builder.Configuration.GetConnectionString("VFmid");
var DbCRMSqlServer = builder.Configuration.GetConnectionString("CRMSqlServer");
var DbWinforce = builder.Configuration.GetConnectionString("Winforce");
var DbMiPortalWin = builder.Configuration.GetConnectionString("MiPortalWin");
var DbECOMSqlServer = builder.Configuration.GetConnectionString("ECOMSqlServer");

builder.Services.AddEntityFrameworkMySQL().AddDbContext<DbWinforce>(options =>
{
    options.UseMySQL(DbWinforce);
});

builder.Services.AddEntityFrameworkMySQL().AddDbContext<DbMiPortalWin>(options =>
{
    options.UseMySQL(DbMiPortalWin);
});
builder.Services.AddDbContext<DbVFmid>(
    options => options.UseSqlServer(DbVFmid)
); ;
builder.Services.AddDbContext<DbCRM>(
    options => options.UseSqlServer(DbCRMSqlServer)
); ;
builder.Services.AddDbContext<DbECOM>(
    options => options.UseSqlServer(DbECOMSqlServer)
); ;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAzureStorage, AzureStorage>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
