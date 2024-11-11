using System;
using System.IO.Ports;
using System.Timers;

namespace Loop_Tuner
{
    public class TeensyManager
    {
        private SerialPort teensyPort;
        private Timer updateTimer;
        public event Action<string> DataUpdated; // Événement pour notifier le formulaire avec les données
        public event Action<string> ConnectionStatusUpdated; // Événement pour notifier le statut de connexion

        public TeensyManager()
        {
            // Configure le port série pour le Teensy (ajuster le port COM si nécessaire)
            teensyPort = new SerialPort("COM3", 115200); // Remplace "COM3" par le port exact de ton Teensy
            teensyPort.DataReceived += OnDataReceived;

            // Configuration du timer pour vérifier la connexion du Teensy
            updateTimer = new Timer(1000); // Intervalle de vérification de 1 seconde
            updateTimer.Elapsed += CheckConnection;
            updateTimer.Start();
        }

        // Vérifie la connexion au Teensy
        private void CheckConnection(object sender, ElapsedEventArgs e)
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
