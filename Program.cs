using CGPExamBackend.Services;
using CGPExamBackend.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddSingleton<SessionService>();
builder.Services.AddSingleton<SecurityEventService>();
builder.Services.AddSingleton<AuditLogService>();
builder.Services.AddSingleton<BotNotificationService>();

// SignalR
builder.Services.AddSignalR();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("SignalRCors", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000") // React app
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseRouting();

// Enable CORS BEFORE mapping endpoints
app.UseCors("SignalRCors");

app.MapControllers();
app.MapHub<BotHub>("/examHub");

app.Run();