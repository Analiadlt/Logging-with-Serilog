namespace LoggingWorkerServiceSerilog
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    //invoca este procedimiento para forzar un mensaje de error para guardar en el archivo de logs.
                    Tarea(); 
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        //se define esta tarea, sólo para crear un mensaje de error y mostrar cómo se guarda en el archivo .log
        private void Tarea() 
        {
            _logger.LogError("Ocurrió un error al ejecutar");
        }
    }
}
