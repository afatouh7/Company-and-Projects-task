using CompanyBranchCore.Interfaces;
using CompanyBranchInfrastructure.Data;
using CompanyBranchInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;

    options.JsonSerializerOptions.MaxDepth = 32;
});
//builder.Services.AddScoped(typeof(IGenricRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<ICompanyRepository,CompanyRepository>();
//builder.Services.AddScoped<IBranchRepository,BranchRepository>(); 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalhostPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200") 
              .AllowAnyHeader()                   // Allow any header
              .AllowAnyMethod();                  // Allow any HTTP method
    });
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
app.UseCors("LocalhostPolicy");
app.MapControllers();

app.Run();
