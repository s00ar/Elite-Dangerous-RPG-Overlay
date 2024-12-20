using System;
using System.IO;
using System.Text.Json;

namespace Elite_Dangerous_RPG_Overlay
{
    public class StatusManager
    {
        public StatusData LoadStatus(string statusFilePath)
        {
            if (!File.Exists(statusFilePath))
            {
                throw new FileNotFoundException($"El archivo {statusFilePath} no se encontró.");
            }

            string json = File.ReadAllText(statusFilePath);
            return JsonSerializer.Deserialize<StatusData>(json);
        }
    }

    public class StatusData
    {
        public string BodyName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
