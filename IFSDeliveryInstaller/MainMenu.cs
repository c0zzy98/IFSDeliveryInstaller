using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IFSDeliveryInstaller
{
    public partial class IFSDeliveryInstaller : Form
    {
        public IFSDeliveryInstaller()
        {
            InitializeComponent();
            this.Text = "IFS Delivery Installer";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Wczytaj dane z JSON podczas ładowania formularza
            LoadCommandsFromJson();
        }

        private void LoadCommandsFromJson()
        {
            string jsonPath = Path.Combine(Application.StartupPath, "commands.json"); // Ścieżka do pliku JSON

            if (File.Exists(jsonPath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(jsonPath);
                    dynamic json = JsonConvert.DeserializeObject(jsonContent);

                    // Przypisz wartości do pól tekstowych
                    txtCommand1.Text = json.Command1;
                    txtCommand2.Text = json.Command2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas odczytu pliku JSON: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono pliku JSON z konfiguracją.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Obsługa przycisku "Instaluj" dla pierwszej komendy
        private void btnInstall1_Click(object sender, EventArgs e)
        {
            ExecuteCommand(txtCommand1.Text);
        }

        // Obsługa przycisku "Instaluj" dla drugiej komendy
        private void btnInstall2_Click(object sender, EventArgs e)
        {
            ExecuteCommand(txtCommand2.Text);
        }

        private void ExecuteCommand(string command)
        {
            string sourcePath = txtArchivePath.Text; // Ścieżka wybranego pliku .7z lub .zip
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourcePath); // Nazwa pliku bez rozszerzenia
            string installerPath = Path.Combine(@"D:\ifsremote\ifsroot\deliveries", fileNameWithoutExtension, "ifsinstaller");

            if (Directory.Exists(installerPath))
            {
                try
                {
                    // Uruchomienie CMD w widocznym trybie
                    Process process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "cmd.exe",
                            Arguments = $"/k cd /d \"{installerPath}\" && {command}", // Użycie cd /d
                            UseShellExecute = true,
                            CreateNoWindow = false,
                            Verb = "runas" // Uruchom jako administrator

                        }
                    };

                    process.Start();

                    MessageBox.Show("Proces instalacji został uruchomiony w CMD. Monitoruj proces w otwartym oknie.",
                                    "Instalacja uruchomiona",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas uruchamiania instalacji: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono katalogu instalatora.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Obsługa przycisku "Wybierz archiwum"
        private void btnSelectArchive_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archiwa (.7z, .zip)|*.7z;*.zip|Wszystkie pliki|*.*",
                Title = "Wybierz archiwum dostawy"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtArchivePath.Text = openFileDialog.FileName;
            }
        }

        // Obsługa przycisku "Rozpakuj i przygotuj"
        private void btnUnpack_Click(object sender, EventArgs e)
        {
            string sourcePath = txtArchivePath.Text;
            string destinationRoot = @"D:\ifsremote\ifsroot\deliveries";

            if (File.Exists(sourcePath))
            {
                try
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourcePath);
                    string deliveryFolder = Path.Combine(destinationRoot, fileNameWithoutExtension);
                    ExtractUsing7zExe(sourcePath, deliveryFolder);

                    string installationFilesPath = Path.Combine(deliveryFolder, "InstallationFiles");
                    if (Directory.Exists(installationFilesPath))
                    {
                        foreach (string file in Directory.GetFiles(installationFilesPath))
                        {
                            string fileName = Path.GetFileName(file);
                            string destinationFile = Path.Combine(deliveryFolder, fileName);
                            File.Move(file, destinationFile);
                        }

                        foreach (string directory in Directory.GetDirectories(installationFilesPath))
                        {
                            string directoryName = Path.GetFileName(directory);
                            string destinationDirectory = Path.Combine(deliveryFolder, directoryName);
                            Directory.Move(directory, destinationDirectory);
                        }

                        Directory.Delete(installationFilesPath, true);
                    }

                    MessageBox.Show($"Pliki zostały rozpakowane i przygotowane w: {deliveryFolder}", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas rozpakowywania i przygotowywania plików: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono wskazanego pliku.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExtractUsing7zExe(string sourcePath, string destinationPath)
        {
            string sevenZipPath = @"C:\Program Files\7-Zip\7z.exe";

            if (!File.Exists(sevenZipPath))
            {
                throw new FileNotFoundException("Nie znaleziono 7z.exe. Upewnij się, że 7-Zip jest zainstalowany.");
            }

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = sevenZipPath,
                    Arguments = $"x \"{sourcePath}\" -o\"{destinationPath}\" -y",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new Exception($"Błąd podczas rozpakowywania: {error}");
            }
        }
    }
}
