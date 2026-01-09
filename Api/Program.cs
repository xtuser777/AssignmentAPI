using Assignment.Api.Contexts;
using Assignment.Api.Converters;
using Assignment.Api.Filters;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Repositories;
using Assignment.Api.Services;
using Assignment.Api.Views;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new GuidConverter());
    options.JsonSerializerOptions.Converters.Add(new GuidNullableConverter());
    options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
    options.JsonSerializerOptions.Converters.Add(new DateOnlyNullableConverter());
    options.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
    options.JsonSerializerOptions.Converters.Add(new TimeOnlyNullableConverter());
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 22));
builder.Services.AddDbContext<ApplicationDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

// Repositories
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IYearsRepository, YearsRepository>();
builder.Services.AddScoped<IUnitsRepository, UnitsRepository>();
builder.Services.AddScoped<IPositionsRepository, PositionsRepository>();
builder.Services.AddScoped<ISituationsRepository, SituationsRepository>();
builder.Services.AddScoped<IDisciplinesRepository, DisciplinesRepository>();
builder.Services.AddScoped<IPreferencesRepository, PreferencesRepository>();
builder.Services.AddScoped<ICivilStatusesRepository, CivilStatusesRepository>();
builder.Services.AddScoped<IUsersUnitsRepository, UsersUnitsRepository>();
builder.Services.AddScoped<ITitlesRepository, TitlesRepository>();
builder.Services.AddScoped<ITeachersRepository, TeachersRepository>();
builder.Services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
builder.Services.AddScoped<ITitlesBySubscriptionsRepository, TitlesBySubscriptionsRepository>();
builder.Services.AddScoped<IPointsBySubscriptionsRepository, PointsBySubscriptionsRepository>();
builder.Services.AddScoped<IClassificationsRepository, ClassificationsRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();

// Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICryptService, CryptService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IYearsService, YearsService>();
builder.Services.AddScoped<IUnitsService, UnitsService>();
builder.Services.AddScoped<IPositionsService, PositionsService>();
builder.Services.AddScoped<ISituationsService, SituationsService>();
builder.Services.AddScoped<IDisciplinesService, DisciplinesService>();
builder.Services.AddScoped<IPreferencesService, PreferencesService>();
builder.Services.AddScoped<ICivilStatusesService, CivilStatusesService>();
builder.Services.AddScoped<ITitlesService, TitlesService>();
builder.Services.AddScoped<ITeachersService, TeachersService>();
builder.Services.AddScoped<ISubscriptionsService, SubscriptionsService>();
builder.Services.AddScoped<IPointsBySubscriptionsService, PointsBySubscriptionsService>();
builder.Services.AddScoped<IClassificationsService, ClassificationsService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Views
builder.Services.AddScoped<IUsersView, UsersView>();
builder.Services.AddScoped<IYearsView, YearsView>();
builder.Services.AddScoped<IUnitsView, UnitsView>();
builder.Services.AddScoped<IPositionsView, PositionsView>();
builder.Services.AddScoped<ISituationsView, SituationsView>();
builder.Services.AddScoped<IDisciplinesView, DisciplinesView>();
builder.Services.AddScoped<IPreferencesView, PreferencesView>();
builder.Services.AddScoped<ICivilStatusesView, CivilStatusesView>();
builder.Services.AddScoped<ITitlesView, TitlesView>();
builder.Services.AddScoped<ITeachersView, TeachersView>();
builder.Services.AddScoped<ISubscriptionsView, SubscriptionsView>();
builder.Services.AddScoped<IClassificationsView, ClassificationsView>();
builder.Services.AddScoped<IRolesView, RolesView>();
builder.Services.AddScoped<IAuthView, AuthView>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        config => config.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ExceptionFilter));
});

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = new List<string>();
        actionContext.ModelState.Values.ToList().ForEach(v => v.Errors.ToList().ForEach(e => errors.Add(e.ErrorMessage)));

        // Create a custom error response object
        var customErrorResponse = new
        {
            StatusCode = 400,
            Message = "Validation Failed",
            Errors = errors
        };

        return new BadRequestObjectResult(customErrorResponse);
    };
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
