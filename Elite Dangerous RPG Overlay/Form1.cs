using System.IO;       // Para leer archivos
using System.Text.Json; // Para procesar JSON

namespace Elite_Dangerous_RPG_Overlay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string savedGamesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Saved Games", "Frontier Developments", "Elite Dangerous", "status.json");

            InitializeComponent();

            // Configurar propiedades del formulario
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600); // Ajusta según tus necesidades

            ReadStatusFile(); // Llama a la función al iniciar el formulario

            SetupFileWatcher(); // Watcher para revisar cambios en el archivo
        }
        private void ReadStatusFile()
        {
            string savedGamesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Saved Games", "Frontier Developments", "Elite Dangerous", "status.json");

            if (File.Exists(savedGamesPath))
            {
                string jsonContent = File.ReadAllText(savedGamesPath);

                // Ejemplo de procesamiento del JSON (imprimir en consola por ahora)
                dynamic statusData = JsonSerializer.Deserialize<dynamic>(jsonContent);
                MessageBox.Show("Archivo leído correctamente. Ejemplo de contenido: " + statusData.ToString());
            }
            else
            {
                MessageBox.Show("El archivo status.json no existe en la ruta esperada.");
            }
        }
        private FileSystemWatcher watcher;

        private void SetupFileWatcher()
        {
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Saved Games", "Frontier Developments", "Elite Dangerous");

            watcher = new FileSystemWatcher(directoryPath)
            {
                Filter = "status.json",
                NotifyFilter = NotifyFilters.LastWrite
            };

            watcher.Changed += (sender, args) => {
                Invoke((MethodInvoker)(() => {
                    ReadStatusFile();
                }));
            };

            watcher.EnableRaisingEvents = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mensaje de aceptación");
            // Cambiar texto o mostrar más opciones aquí
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Interacción rechazada");
            this.Close(); // Cierra el overlay
        }
    }
}
