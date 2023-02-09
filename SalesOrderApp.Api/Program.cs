using MediatR;
using SalesOrderApp.Core.Mappers;
using SalesOrderApp.Core.Repositories;
using SalesOrderApp.Core.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);
string allowAllOrigin = "allowAllOrigin";

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); ;
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddMediatR(typeof(PersistenceStartup));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(OrderProfile));
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowAllOrigin,
        builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(allowAllOrigin);
app.UseAuthorization();

app.MapControllers();

app.Run();
