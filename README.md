
Resumen del Proyecto
Título del Proyecto: Elite Dangerous RPG Overlay

Descripción General
El proyecto es una aplicación en C# con Windows Forms diseñada para funcionar como un overlay para el juego Elite Dangerous. Su propósito es ofrecer interacciones adicionales en pantalla basadas en la ubicación del jugador dentro del juego, utilizando datos obtenidos de los archivos del juego (e.g., Status.json) y archivos de configuración (interaction_data.json).

Requerimientos Funcionales
Pantalla de carga (Splash Screen):

Al iniciar la aplicación, debe mostrar un splash screen con un mensaje de carga durante 3 segundos.
Lectura del archivo Status.json:

Monitorear cambios en el archivo Status.json para identificar la ubicación actual del jugador.
Validar coordenadas (Latitud, Longitud, BodyName) con un margen de error.
Lectura de interaction_data.json:

Leer un archivo JSON ubicado en la carpeta Data del proyecto, que contiene las interacciones disponibles para diferentes planetas.
Sistema de Interacciones:

Mostrar en pantalla las interacciones disponibles en el planeta actual si el jugador se encuentra dentro de las coordenadas especificadas.
Para cada interacción:
Mostrar un mensaje inicial con la cantidad de interacciones disponibles.
Permitir avanzar en las interacciones con un botón "Continuar".
Permitir cancelar la interacción con un botón "Cancelar".
Manejo de Diálogos:

Los diálogos deben avanzar línea por línea con el botón "Continuar".
Si el jugador termina una interacción, mostrar el mensaje "Interacción finalizada".
Si el jugador selecciona "Cancelar", cerrar la interacción actual.
Configuración dinámica:

Los archivos Status.json y interaction_data.json deben cargarse dinámicamente.
La aplicación debe adaptarse a nuevos datos sin necesidad de recompilar.
Requerimientos Técnicos
Framework: .NET 8.0 (Windows Forms)
Lenguaje: C#
IDE recomendado: Visual Studio 2022
Dependencias:
System.Text.Json para la lectura y deserialización de archivos JSON.
Clases de .NET (File, Timer, etc.) para manejo de archivos y eventos.
Estructura del Proyecto
1. Carpeta raíz:
plaintext
Copiar código
Elite Dangerous RPG Overlay/
├── bin/                     # Salida del proyecto
├── obj/                     # Archivos de compilación
├── Data/                    # Carpeta para los datos de configuración
│   ├── interaction_data.json
├── Models/                  # Modelos de datos
│   ├── PlanetInteraction.cs
│   ├── StatusData.cs
├── InteractionManager.cs    # Clase para manejar interacciones
├── StatusManager.cs         # Clase para manejar el estado del jugador
├── Form1.cs                 # Clase principal del formulario
├── Form1.Designer.cs        # Código generado automáticamente para el formulario
├── Program.cs               # Punto de entrada de la aplicación
├── Elite Dangerous RPG Overlay.csproj
2. Archivos relevantes
interaction_data.json

Ubicación: Data/interaction_data.json
Contenido de ejemplo:
json
Copiar código
{
  "Planets": [
    {
      "BodyName": "LHS 2459 A 1",
      "Interactions": [
        {
          "NPC": "NPC 1",
          "Latitude": 18.796764,
          "Longitude": 164.046234,
          "Dialogues": [
            "Bienvenido al planeta.",
            "Tenemos una misión para ti.",
            "Dirígete a Prospector's Rest en LHS 130 A1 y habla con Jasen Stephens."
          ]
        }
      ]
    }
  ]
}
Status.json

Ubicación: C:\Users\<Usuario>\Saved Games\Frontier Developments\Elite Dangerous\Status.json
Actualizado automáticamente por el juego.
Ejemplo:
json
Copiar código
{
  "timestamp":"2024-12-07T21:58:02Z",
  "event":"Status",
  "Flags":2097157,
  "Flags2":65553,
  "Oxygen":1.000000,
  "Health":1.000000,
  "Temperature":293.000000,
  "Latitude":18.796764,
  "Longitude":164.046234,
  "BodyName":"LHS 2459 A 1"
}
PlanetInteraction.cs

Modelo que representa interacciones planetarias:
csharp
Copiar código
namespace Elite_Dangerous_RPG_Overlay.Models
{
    public class PlanetInteraction
    {
        public string BodyName { get; set; } = "";
        public List<Interaction> Interactions { get; set; } = new List<Interaction>();
    }

    public class Interaction
    {
        public string NPC { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<string> Dialogues { get; set; } = new List<string>();
    }
}
StatusData.cs

Modelo para deserializar Status.json:
csharp
Copiar código
namespace Elite_Dangerous_RPG_Overlay.Models
{
    public class StatusData
    {
        public string BodyName { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
Guía de Desarrollo
Paso 1: Configurar Visual Studio
Asegúrate de usar Visual Studio 2022 con soporte para .NET 8.0.
Crea un proyecto Windows Forms App.
Configura el framework objetivo a .NET 8.0.
Paso 2: Crear Estructura de Carpetas
Agrega la carpeta Data en el proyecto y coloca el archivo interaction_data.json.
Agrega la carpeta Models y crea los archivos PlanetInteraction.cs y StatusData.cs.
Paso 3: Configurar Form1
Implementa el diseño del formulario principal (Form1.Designer.cs).
Configura los eventos para los botones Continuar y Cancelar.
Implementa la funcionalidad de lectura de archivos y detección de ubicación en Form1.cs.
Paso 4: Prueba del Proyecto
Ejecuta la aplicación en modo Debug.
Verifica que:
El splash screen se muestre correctamente.
Los mensajes de interacción aparezcan según la ubicación del jugador.
