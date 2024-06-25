var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("*") // Belirli bir kökene izin ver
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });

    // Alternatif olarak tüm kökenlere izin vermek için:
    // options.AddPolicy("AllowAllOrigins",
    //     builder =>
    //     {
    //         builder.AllowAnyOrigin()
    //                .AllowAnyHeader()
    //                .AllowAnyMethod();
    //     });
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
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
