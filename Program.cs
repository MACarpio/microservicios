using Microsoft.EntityFrameworkCore;
using ms.Context.SqlServer;

var builder = WebApplication.CreateBuilder(args);
// creacion de cadenas de conexion

var DbVFmid = builder.Configuration.GetConnectionString("VFmid");

builder.Services.AddDbContext<DbVFmid>(
    options => options.UseSqlServer(DbVFmid)
); ;


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
