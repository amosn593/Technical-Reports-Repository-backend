using DAL.Configuration;
using DAL.Data;
using DOMAIN.IConfiguration;
using Microsoft.EntityFrameworkCore;
using DTO.Profiles;
using AzureBlobStorage.Interfaces;
using AzureBlobStorage.Implimentations;
using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);

var dbconnection = builder.Configuration.GetConnectionString("PoultryContext");

var blobconnection = builder.Configuration.GetConnectionString("BlobConnection");

builder.Services.AddDbContext<PoultryDbContext>(
    options => options.UseSqlServer(dbconnection)
    );

// Add services to the container.
builder.Services.AddCors(options =>
        {
            options.AddPolicy("reportfrontend",policy =>
                                  {policy.WithOrigins("http://localhost:3000")
                                                          .AllowAnyHeader()
                                                         .AllowAnyMethod();
                                  });
        }
);

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(options =>
{
    return new BlobServiceClient(blobconnection);
});
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
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

app.UseRouting();

app.UseCors("reportfrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
