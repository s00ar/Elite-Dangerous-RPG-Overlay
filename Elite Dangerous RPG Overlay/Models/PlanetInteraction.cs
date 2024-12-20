namespace Elite_Dangerous_RPG_Overlay.Models
{
    public class PlanetInteraction
    {
        public string BodyName { get; set; }
        public List<Interaction> Interactions { get; set; }
    }

    public class Interaction
    {
        public string NPC { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<string> Dialogues { get; set; }
    }
}
