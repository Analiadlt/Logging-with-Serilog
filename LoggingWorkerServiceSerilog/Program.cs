using LoggingWorkerServiceSerilog;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

//Logger creado para mostrar mensajes/logs en consola
//var logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .CreateLogger();

//Logger creado para guardar mensajes/logs en un archivo
//var logger = new LoggerConfiguration()
//    .MinimumLevel.Debug() //Acá se le indica el mínimo nivel de mensaje, en este caso es el de 'debug'
//    .WriteTo.File(Path.Combine("Logs","MyApp-.log"), //se indica el nombre del archivo de logs
//    rollingInterval: RollingInterval.Day,
//    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}]")
//    .CreateLogger();


//Logger creado para guardar mensajes/logs en un archivo
//tomando la configuració del appsettings.json, de esta forma,
//si queremos cambiar algo de la configuración, sólo será en el appsettings.
var logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(builder.Configuration)
                .CreateLogger();


builder.Logging.AddSerilog(logger);

var host = builder.Build();
host.Run();
