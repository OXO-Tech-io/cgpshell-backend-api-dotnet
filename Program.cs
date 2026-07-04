using CGPExamBackend.Services;
using CGPExamBackend.Hubs;


var builder = WebApplication.CreateBuilder(args);

// IMPORTANT: this must exist BEFORE building app
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SessionService>();
builder.Services.AddSingleton<SecurityEventService>();
builder.Services.AddSingleton<AuditLogService>();
builder.Services.AddSignalR();
builder.Services.AddSingleton<BotNotificationService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// IMPORTANT: routing order
app.MapControllers();
app.MapHub<BotHub>("/botHub");

app.Run();


