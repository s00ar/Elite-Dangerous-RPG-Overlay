using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Elite_Dangerous_RPG_Overlay
{
    public partial class Form1 : Form
    {
        private int currentDialogueIndex = 0;
        private InteractionData loadedScript; // Objeto para almacenar el script JSON cargado.

        public Form1()
        {
            InitializeComponent();

            // Configurar propiedades del formulario
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);

            LoadScript(); // Cargar script inicial
        }
        // Método para el evento Click de texto_inicial
        private void texto_inicial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Texto inicial clickeado.");
        }

        // Método para el evento Click del botón Continuar
        private void continuarButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se presionó el botón Continuar.");
        }

        // Método para el evento Click del botón Cancelar
        private void cancelarButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se presionó el botón Cancelar.");
        }

        /// <summary>
        /// Clase para deserializar los datos del archivo JSON.
        /// </summary>
        private class InteractionData
        {
            public string NPC { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string BodyName { get; set; }
            public string[] Dialogues { get; set; }
        }

        /// <summary>
        /// Carga el archivo JSON con los datos de interacción.
        /// </summary>
        private void LoadScript()
        {
            try
            {
                //string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "interaction_data.json");
                string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "interaction_data.json");

                if (File.Exists(scriptPath))
                {
                    string scriptContent = File.ReadAllText(scriptPath);
                    loadedScript = JsonSerializer.Deserialize<InteractionData>(scriptContent);

                    if (loadedScript != null && loadedScript.Dialogues.Length > 0)
                    {
                        ShowInteraction(loadedScript.Dialogues[currentDialogueIndex]);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron diálogos en el archivo JSON.");
                    }
                }
                else
                {
                    MessageBox.Show($"El archivo {scriptPath} no se encontró. Verifica que exista y tenga permisos de lectura.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el archivo JSON: {ex.Message}\n{ex.StackTrace}");
            }
        }


        /// <summary>
        /// Muestra la interfaz de interacción con el mensaje actual.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        private void ShowInteraction(string message)
        {
            // Limpiar controles existentes para evitar duplicados
            this.Controls.Clear();

            // Crear etiquetas y botones
            Label dialogueLabel = new Label
            {
                Text = message,
                AutoSize = true,
                Font = new Font("Arial", 14),
                ForeColor = Color.White,
                BackColor = Color.Black,
                Location = new Point(100, 100)
            };

            Button continueButton = new Button
            {
                Text = "Continuar",
                Location = new Point(100, 200)
            };
            continueButton.Click += ContinueButton_Click;

            Button cancelButton = new Button
            {
                Text = "Cancelar",
                Location = new Point(200, 200)
            };
            cancelButton.Click += CancelButton_Click;

            // Agregar controles al formulario
            this.Controls.Add(dialogueLabel);
            this.Controls.Add(continueButton);
            this.Controls.Add(cancelButton);
        }

        /// <summary>
        /// Avanza al siguiente diálogo al presionar "Continuar".
        /// </summary>
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (loadedScript != null && currentDialogueIndex < loadedScript.Dialogues.Length - 1)
            {
                currentDialogueIndex++;
                ShowInteraction(loadedScript.Dialogues[currentDialogueIndex]);
            }
            else
            {
                MessageBox.Show("Interacción terminada.");
                Application.Exit(); // Cierra el overlay.
            }
        }

        /// <summary>
        /// Cancela la interacción al presionar "Cancelar".
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear(); // Limpia la interfaz
            MessageBox.Show("Interacción cancelada.");
        }
    }
}
