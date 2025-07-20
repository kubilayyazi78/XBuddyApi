using XBuddy.WebApi.Infrastructure.MultiTenant.Extensions;
using XBuddy.Infra.SqlServer.Extensions;
using XBuddy.WebApi.Infrastructure.MultiTenant.Services;
using XBuddy.Infra.Cosmos.Extensions;

var builder = WebApplication.CreateBuilder(args);

#if DEBUG
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true);
#endif

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMultiTenancy();
builder.Services.AddInfraSqlServices(builder.Configuration.GetConnectionString("SqlServer"),(sp)=>
{
    var service = sp.GetRequiredService<IMultiTenantService>();

    return service.GetUserId().ToString();
});

builder.Services.AddInfraCosmosService(builder.Configuration.GetConnectionString("CosmosDb"));

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

app.UseMultiTenancy();

app.Run();
