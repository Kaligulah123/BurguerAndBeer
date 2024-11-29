using BurguerAndBeer.Api.Data;
using BurguerAndBeer.Api.Endpoints;
using BurguerAndBeer.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("BurguerAndBeer");
builder.Services.AddDbContext<DataContext>(options =>options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwtoptions => jwtoptions.TokenValidationParameters = TokenService.GetTokenValidationParameters(builder.Configuration));

builder.Services.AddAuthorization();

builder.Services.AddTransient<TokenService>();
builder.Services.AddTransient<PasswordService>();
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<BurguerService>();
builder.Services.AddTransient<BeerService>();
builder.Services.AddTransient<ChipsService>();
builder.Services.AddTransient<DessertService>();
builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<OrderService>();

var app = builder.Build();

#if DEBUG
MigrateDatabase(app.Services);
#endif


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.MapControllers();

app.Run();

static void MigrateDatabase(IServiceProvider services)
{
    var scope = services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    if (dataContext.Database.GetPendingMigrations().Any()) dataContext.Database.Migrate();
}