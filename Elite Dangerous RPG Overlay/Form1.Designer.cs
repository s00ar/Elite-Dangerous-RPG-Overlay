namespace Elite_Dangerous_RPG_Overlay
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            texto_inicial = new Label();
            continuarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // texto_inicial
            // 
            texto_inicial.AccessibleDescription = "initialText";
            texto_inicial.AutoSize = true;
            texto_inicial.BackColor = SystemColors.Desktop;
            texto_inicial.CausesValidation = false;
            texto_inicial.Font = new Font("Poppins SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            texto_inicial.ForeColor = SystemColors.ButtonFace;
            texto_inicial.Location = new Point(78, 58);
            texto_inicial.Name = "texto_inicial";
            texto_inicial.Size = new Size(469, 28);
            texto_inicial.TabIndex = 0;
            texto_inicial.Text = "Haz llegado a un planeta con interacciones disponibles.";
            texto_inicial.Click += texto_inicial_Click;
            // 
            // continuarButton
            // 
            continuarButton.BackColor = Color.Silver;
            continuarButton.ForeColor = Color.Black;
            continuarButton.Location = new Point(78, 99);
            continuarButton.Name = "continuarButton";
            continuarButton.Size = new Size(75, 23);
            continuarButton.TabIndex = 1;
            continuarButton.Text = "Continuar";
            continuarButton.UseVisualStyleBackColor = false;
            continuarButton.Click += continuarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.BackColor = Color.Silver;
            cancelarButton.ForeColor = Color.Black;
            cancelarButton.Location = new Point(472, 99);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 2;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = false;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(650, 234);
            Controls.Add(cancelarButton);
            Controls.Add(continuarButton);
            Controls.Add(texto_inicial);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label texto_inicial;
        private System.Windows.Forms.Button continuarButton;
        private System.Windows.Forms.Button cancelarButton;
    }
}
