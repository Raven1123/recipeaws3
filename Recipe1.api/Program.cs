
using Amazon.S3;
using Recipe1.api.ImageService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAWSService<IAmazonS3>();


builder.Services.AddSingleton<IS3Service, S3Service>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
