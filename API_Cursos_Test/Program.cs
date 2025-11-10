using Amazon.Lambda.Core;

//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<API_Cursos_Test.Interfaces.ICursosSearch, API_Cursos_Test.Repository.CursosSearchRepository>();
builder.Services.AddScoped<API_Cursos_Test.Interfaces.IFilterCursos, API_Cursos_Test.Repository.FilterRepository>();
builder.Services.AddScoped<API_Cursos_Test.Interfaces.ILoadDataExcel, API_Cursos_Test.Repository.LoadDataExcelRepository>();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
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

app.Run();
