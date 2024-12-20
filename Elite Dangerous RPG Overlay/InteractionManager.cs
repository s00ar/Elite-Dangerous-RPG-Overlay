using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Elite_Dangerous_RPG_Overlay.Models;


namespace Elite_Dangerous_RPG_Overlay
{
    public class InteractionManager
    {
        public List<PlanetInteraction> LoadInteractions(string interactionFilePath)
        {
            if (!File.Exists(interactionFilePath))
            {
                throw new FileNotFoundException($"El archivo {interactionFilePath} no se encontró.");
            }

            string json = File.ReadAllText(interactionFilePath);
            return JsonSerializer.Deserialize<List<PlanetInteraction>>(json);
        }

        public List<Interaction> GetAvailableInteractions(string bodyName, double latitude, double longitude, List<PlanetInteraction> planetInteractions, double marginOfError = 0.1)
        {
            var planet = planetInteractions.FirstOrDefault(p => p.BodyName == bodyName);

            return planet?.Interactions.Where(interaction =>
                Math.Abs(interaction.Latitude - latitude) <= marginOfError &&
                Math.Abs(interaction.Longitude - longitude) <= marginOfError).ToList();
        }
    }
}
