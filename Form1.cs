// Version qui semble fonctionner (omnirig ok mais com teensy à tester)
using System;
using System.Windows.Forms;

namespace Loop_Tuner
{
    public partial class Form1 : Form
    {
        private readonly TransceiverControl transceiverControl;

        public Form1()
        {
            InitializeComponent();
            transceiverControl = new TransceiverControl();
            transceiverControl.FrequencyUpdated += UpdateFrequencyDisplay;
        }

        // Méthode Form1_Load pour l'initialisation
        private void Form1_Load(object sender, EventArgs e)
        {
            // Par défaut, sélectionne RIG1 et un intervalle de 1 seconde
            transceiverControl.SelectRig(true);
            transceiverControl.SetUpdateInterval(1000);
        }

        // Met à jour l'affichage de la fréquence
        private void UpdateFrequencyDisplay(string frequencyText)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => frequencyLabel.Text = frequencyText));
            }
            else
            {
                frequencyLabel.Text = frequencyText;
            }
        }

        // Changer l'intervalle de mise à jour
        private void UpdateIntervalInput_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(updateIntervalInput.Text, out int interval) && interval > 0)
            {
                transceiverControl.SetUpdateInterval(interval);
            }
        }

        // Bouton pour basculer entre RIG1 et RIG2
        private void ToggleRigButton_Click(object sender, EventArgs e)
        {
            bool useRig1 = !transceiverControl.GetCurrentRig().Equals("RIG1");
            transceiverControl.SelectRig(useRig1);
            toggleRigButton.Text = $"Switch to {(useRig1 ? "RIG2" : "RIG1")}";
        }
    }
}
