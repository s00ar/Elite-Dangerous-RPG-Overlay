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
            this.texto_inicial = new System.Windows.Forms.Label();
            this.continuarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // texto_inicial
            // 
            this.texto_inicial.AccessibleDescription = "initialText";
            this.texto_inicial.AutoSize = true;
            this.texto_inicial.BackColor = System.Drawing.SystemColors.Desktop;
            this.texto_inicial.CausesValidation = false;
            this.texto_inicial.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texto_inicial.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.texto_inicial.Location = new System.Drawing.Point(112, 219);
            this.texto_inicial.Name = "texto_inicial";
            this.texto_inicial.Size = new System.Drawing.Size(469, 28);
            this.texto_inicial.TabIndex = 0;
            this.texto_inicial.Text = "Haz llegado a un planeta con interacciones disponibles.";
            // 
            // continuarButton
            // 
            this.continuarButton.BackColor = System.Drawing.Color.Transparent;
            this.continuarButton.ForeColor = System.Drawing.Color.Black;
            this.continuarButton.Location = new System.Drawing.Point(413, 263);
            this.continuarButton.Name = "continuarButton";
            this.continuarButton.Size = new System.Drawing.Size(75, 23);
            this.continuarButton.TabIndex = 1;
            this.continuarButton.Text = "Continuar";
            this.continuarButton.UseVisualStyleBackColor = false;
            this.continuarButton.Click += new System.EventHandler(this.ContinuarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelarButton.ForeColor = System.Drawing.Color.Black;
            this.cancelarButton.Location = new System.Drawing.Point(506, 263);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 2;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = false;
            this.cancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.continuarButton);
            this.Controls.Add(this.texto_inicial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.5D;
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label texto_inicial;
        private System.Windows.Forms.Button continuarButton;
        private System.Windows.Forms.Button cancelarButton;
    }
}
