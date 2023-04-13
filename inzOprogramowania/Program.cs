using inzOprogramowania.DataContext;
using Microsoft.EntityFrameworkCore;
using inzOprogramowania.Controllers;
using inzOprogramowania.Services;
using inzOprogramowania.Services.AdsService;
using inzOprogramowania.Services.CommentsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdsService, AdsService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
Console.WriteLine( "App running");
app.Run();
