using System;
using System.IO.Ports;
using System.Timers;

namespace Loop_Tuner
{
    public class TeensyManager
    {
        private readonly SerialPort teensyPort;
        private readonly System.Timers.Timer updateTimer;

#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur autre que Null lors de la fermeture du constructeur. Envisagez d’ajouter le modificateur « required » ou de déclarer le champ comme pouvant accepter la valeur Null.
        public TeensyManager(System.Timers.Timer updateTimer)
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur autre que Null lors de la fermeture du constructeur. Envisagez d’ajouter le modificateur « required » ou de déclarer le champ comme pouvant accepter la valeur Null.
        {
            this.updateTimer = updateTimer;
        }

        public event Action<string>? DataUpdated; // Événement pour notifier le formulaire avec les données
        public event Action<string>? ConnectionStatusUpdated; // Événement pour notifier le statut de connexion

        public TeensyManager()
        {
            // Configure le port série pour le Teensy (ajuster le port COM si nécessaire)
            teensyPort = new SerialPort("COM3", 115200); // Remplace "COM3" par le port exact de ton Teensy
            teensyPort.DataReceived += OnDataReceived;

            // Configuration du timer pour vérifier la connexion du Teensy
            updateTimer = new System.Timers.Timer(1000); // Spécifie explicitement System.Timers.Timer
            updateTimer.Elapsed += CheckConnection;
            updateTimer.Start();
        }

        // Vérifie la connexion au Teensy
        private void CheckConnection(object? sender, ElapsedEventArgs e)
        {
            if (!teensyPort.IsOpen)
            {
                try
                {
                    teensyPort.Open();
                    ConnectionStatusUpdated?.Invoke("Teensy connecté");
                }
                catch
                {
                    ConnectionStatusUpdated?.Invoke("Teensy non connecté");
                }
            }
        }

        // Gestion des données reçues du Teensy
        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = teensyPort.ReadLine();
            DataUpdated?.Invoke(data);
        }

        // Ferme le port série à la fermeture de l'application
        public void Close()
        {
            if (teensyPort.IsOpen)
                teensyPort.Close();
        }
    }
}
