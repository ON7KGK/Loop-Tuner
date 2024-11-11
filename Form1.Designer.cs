namespace Loop_Tuner
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Button toggleRigButton;
        private System.Windows.Forms.TextBox updateIntervalInput;
        private System.Windows.Forms.Label intervalLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.toggleRigButton = new System.Windows.Forms.Button();
            this.updateIntervalInput = new System.Windows.Forms.TextBox();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(30, 30);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(200, 24);
            this.frequencyLabel.Text = "Frequency: 0.000000 MHz";
            // 
            // toggleRigButton
            // 
            this.toggleRigButton.Location = new System.Drawing.Point(30, 70);
            this.toggleRigButton.Name = "toggleRigButton";
            this.toggleRigButton.Size = new System.Drawing.Size(150, 30);
            this.toggleRigButton.Text = "Switch to RIG2";
            this.toggleRigButton.Click += new System.EventHandler(this.ToggleRigButton_Click);
            // 
            // updateIntervalInput
            // 
            this.updateIntervalInput.Location = new System.Drawing.Point(200, 120);
            this.updateIntervalInput.Name = "updateIntervalInput";
            this.updateIntervalInput.Size = new System.Drawing.Size(60, 20);
            this.updateIntervalInput.TextChanged += new System.EventHandler(this.UpdateIntervalInput_TextChanged);
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(30, 123);
            this.intervalLabel.Text = "Update Interval (ms):";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.intervalLabel);
            this.Controls.Add(this.updateIntervalInput);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.toggleRigButton);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
