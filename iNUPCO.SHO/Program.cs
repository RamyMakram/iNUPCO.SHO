using iNUPCO.SHO;
using iNUPCO.SHO.Data.Context;
using iNUPCO.SHO.Repo;
using iNUPCO.SHO.Service;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Threading.RateLimiting;
using iNUPCO.SHO.DTOs.Global;

var builder = WebApplication.CreateBuilder(args);

new MapsterProfiler();



// Configure rate limiting.
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: context.User.Identity?.Name ?? context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
            factory: partition =>
                new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 10, // Allow 10 requests
                    Window = TimeSpan.FromSeconds(10), // Per 10 seconds
                    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                    QueueLimit = 2 // Allow 2 requests in the queue
                }));
    options.RejectionStatusCode = 429; // Too Many Requests
});
// Add Redis caching to the services
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis:6379";  // Redis container address
    options.InstanceName = "SampleApp_";  // Optional instance name for Redis keys
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? "Server=RAMY-MAKRAM;Database=iNUPCO;TrustServerCertificate=True;User ID=wa;Password=1";
builder.Services.AddDbContext<iNUPCOContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));

//Register Services From iNUPCO.PO.Service
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});


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
// Enable rate limiting middleware globally.
app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();
