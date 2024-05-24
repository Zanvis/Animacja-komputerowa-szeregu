namespace ProjektNr1_Piwowarski62024
{
    partial class KokpitProjektuNr1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProjektNr1 = new System.Windows.Forms.Button();
            this.btnLaboratoriumNr1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnProjektNr1
            // 
            this.btnProjektNr1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProjektNr1.Location = new System.Drawing.Point(460, 233);
            this.btnProjektNr1.Name = "btnProjektNr1";
            this.btnProjektNr1.Size = new System.Drawing.Size(204, 82);
            this.btnProjektNr1.TabIndex = 9;
            this.btnProjektNr1.Text = "Projekt Nr1\r\nSzereg indywidualny";
            this.btnProjektNr1.UseVisualStyleBackColor = true;
            this.btnProjektNr1.Click += new System.EventHandler(this.btnProjektNr1_Click);
            // 
            // btnLaboratoriumNr1
            // 
            this.btnLaboratoriumNr1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLaboratoriumNr1.Location = new System.Drawing.Point(146, 233);
            this.btnLaboratoriumNr1.Name = "btnLaboratoriumNr1";
            this.btnLaboratoriumNr1.Size = new System.Drawing.Size(204, 82);
            this.btnLaboratoriumNr1.TabIndex = 8;
            this.btnLaboratoriumNr1.Text = "Laboratorium Nr1\r\nSzereg laboratoryjny";
            this.btnLaboratoriumNr1.UseVisualStyleBackColor = true;
            this.btnLaboratoriumNr1.Click += new System.EventHandler(this.btnLaboratoriumNr1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(116, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(569, 62);
            this.label2.TabIndex = 7;
            this.label2.Text = "Animacja komputerowa po linii toru\r\nwyznaczonego przez wykres szeregu potęgowego";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // KokpitProjektuNr1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProjektNr1);
            this.Controls.Add(this.btnLaboratoriumNr1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KokpitProjektuNr1";
            this.Text = "Animacja komputerowa po linii toru";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KokpitProjektuNr1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProjektNr1;
        private System.Windows.Forms.Button btnLaboratoriumNr1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

