using Microsoft.EntityFrameworkCore;
using XYZHotel.DB;
using XYZHotel.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelsContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("con")));

builder.Services.AddScoped<IHotelsRepository, HotelsRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
