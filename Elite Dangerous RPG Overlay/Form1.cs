using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Elite_Dangerous_RPG_Overlay.Models;

namespace Elite_Dangerous_RPG_Overlay
{
    public partial class Form1 : Form
    {
        private List<PlanetInteraction>? planetInteractions;
        private Label? interactionMessage;
        private Interaction? currentInteraction;
        private int dialogueIndex = 0;

        public Form1()
        {
            InitializeComponent();
            LoadInteractions();
            CreateCheckLocationButton(); // Crear botón para verificar ubicación
        }

        private void LoadInteractions()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "interaction_data.json");
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"El archivo {filePath} no se encontró.");
                    return;
                }

                string json = File.ReadAllText(filePath);
                planetInteractions = JsonSerializer.Deserialize<List<PlanetInteraction>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar interacciones: {ex.Message}");
            }
        }

        private void CreateCheckLocationButton()
        {
            Button checkLocationButton = new Button
            {
                Text = "Verificar ubicación",
                Location = new Point(20, 20),
                AutoSize = true
            };
            checkLocationButton.Click += CheckPlayerLocation;
            Controls.Add(checkLocationButton);
        }

        private void CheckPlayerLocation(object? sender, EventArgs e)
        {
            try
            {
                string statusFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Saved Games", "Frontier Developments", "Elite Dangerous", "Status.json");

                if (!File.Exists(statusFilePath))
                {
                    MessageBox.Show("Archivo de estado no encontrado.");
                    return;
                }

                string statusJson = File.ReadAllText(statusFilePath);
                var statusData = JsonSerializer.Deserialize<StatusData>(statusJson);

                if (statusData == null)
                {
                    MessageBox.Show("Error al leer datos del estado.");
                    return;
                }

                var planet = planetInteractions?.FirstOrDefault(p => p.BodyName == statusData.BodyName);

                if (planet != null)
                {
                    var availableInteractions = planet.Interactions.Where(i =>
                        Math.Abs(i.Latitude - statusData.Latitude) <= 0.1 &&
                        Math.Abs(i.Longitude - statusData.Longitude) <= 0.1).ToList();

                    if (availableInteractions.Any())
                    {
                        DisplayInteractions(availableInteractions);
                    }
                    else
                    {
                        MessageBox.Show("No hay interacciones disponibles en esta ubicación.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar la ubicación del jugador: {ex.Message}");
            }
        }

        private void DisplayInteractions(List<Interaction> interactions)
        {
            if (interactionMessage == null)
            {
                interactionMessage = new Label
                {
                    AutoSize = true,
                    ForeColor = Color.White,
                    BackColor = Color.Black,
                    Location = new Point(50, 100),
                };
                Controls.Add(interactionMessage);
            }

            interactionMessage.Text = $"Interacciones disponibles: {interactions.Count}";
            interactionMessage.Show();

            currentInteraction = interactions.FirstOrDefault();
            dialogueIndex = 0;

            CreateInteractionButtons();
        }

        private void CreateInteractionButtons()
        {
            Button continueButton = new Button
            {
                Text = "Continuar",
                Location = new Point(50, 200),
                AutoSize = true
            };
            continueButton.Click += ContinuarButton_Click;

            Button cancelButton = new Button
            {
                Text = "Cancelar",
                Location = new Point(150, 200),
                AutoSize = true
            };
            cancelButton.Click += CancelarButton_Click;

            Controls.Add(continueButton);
            Controls.Add(cancelButton);
        }

        private void ContinuarButton_Click(object? sender, EventArgs e)
        {
            if (currentInteraction != null && dialogueIndex < currentInteraction.Dialogues.Count)
            {
                interactionMessage.Text = currentInteraction.Dialogues[dialogueIndex];
                dialogueIndex++;
            }
            else
            {
                interactionMessage.Text = "Interacción finalizada.";
                ClearInteractionUI();
            }
        }

        private void CancelarButton_Click(object? sender, EventArgs e)
        {
            ClearInteractionUI();
        }

        private void ClearInteractionUI()
        {
            Controls.Clear();
            interactionMessage = null;
            currentInteraction = null;

            // Reagregar el botón de verificar ubicación
            CreateCheckLocationButton();
        }
    }
}
