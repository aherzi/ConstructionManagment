using ConstructionAppServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSignalR();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DatabaseManager>();
builder.Services.AddScoped<SiteService>();
builder.Services.AddScoped<ContractorService>();

var app = builder.Build();

app.Logger.LogInformation("Using Access database: {DatabasePath}",
    Path.GetFullPath(builder.Configuration["Database:Path"]
        ?? Path.Combine(app.Environment.ContentRootPath, "Construction_Management_DB.accdb"), app.Environment.ContentRootPath));

app.MapHub<NotificationHub>("/notificationHub");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
