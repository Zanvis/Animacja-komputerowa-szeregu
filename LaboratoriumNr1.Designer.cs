namespace ProjektNr1_Piwowarski62024
{
    partial class LaboratoriumNr1
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnimacja = new System.Windows.Forms.Button();
            this.txtH = new System.Windows.Forms.TextBox();
            this.txtXg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXd = new System.Windows.Forms.TextBox();
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.obramowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stylLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKreskowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKreskowoKropkowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grubośćLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKreskowoKropkowaKropkowaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKropkowaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaCiągłaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(330, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Xg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(225, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Xd";
            // 
            // btnAnimacja
            // 
            this.btnAnimacja.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAnimacja.Location = new System.Drawing.Point(739, 119);
            this.btnAnimacja.Name = "btnAnimacja";
            this.btnAnimacja.Size = new System.Drawing.Size(102, 64);
            this.btnAnimacja.TabIndex = 15;
            this.btnAnimacja.Text = "Animacja";
            this.btnAnimacja.UseVisualStyleBackColor = true;
            this.btnAnimacja.Click += new System.EventHandler(this.btnAnimacja_Click);
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(468, 40);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(26, 20);
            this.txtH.TabIndex = 14;
            // 
            // txtXg
            // 
            this.txtXg.Location = new System.Drawing.Point(380, 38);
            this.txtXg.Name = "txtXg";
            this.txtXg.Size = new System.Drawing.Size(26, 20);
            this.txtXg.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(437, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "h";
            // 
            // txtXd
            // 
            this.txtXd.Location = new System.Drawing.Point(274, 36);
            this.txtXd.Name = "txtXd";
            this.txtXd.Size = new System.Drawing.Size(26, 20);
            this.txtXd.TabIndex = 11;
            // 
            // pbRysownica
            // 
            this.pbRysownica.Location = new System.Drawing.Point(117, 68);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(614, 404);
            this.pbRysownica.TabIndex = 10;
            this.pbRysownica.TabStop = false;
            this.pbRysownica.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRysownica_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obramowanieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // obramowanieToolStripMenuItem
            // 
            this.obramowanieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stylLiniiToolStripMenuItem,
            this.grubośćLiniiToolStripMenuItem,
            this.kolorLiniiToolStripMenuItem});
            this.obramowanieToolStripMenuItem.Name = "obramowanieToolStripMenuItem";
            this.obramowanieToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.obramowanieToolStripMenuItem.Text = "Obramowanie";
            // 
            // stylLiniiToolStripMenuItem
            // 
            this.stylLiniiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liniaKreskowaToolStripMenuItem,
            this.liniaKreskowoKropkowaToolStripMenuItem,
            this.liniaKreskowoKropkowaKropkowaToolStripMenuItem1,
            this.liniaKropkowaToolStripMenuItem1,
            this.liniaCiągłaToolStripMenuItem1});
            this.stylLiniiToolStripMenuItem.Name = "stylLiniiToolStripMenuItem";
            this.stylLiniiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stylLiniiToolStripMenuItem.Text = "Styl linii";
            // 
            // liniaKreskowaToolStripMenuItem
            // 
            this.liniaKreskowaToolStripMenuItem.Name = "liniaKreskowaToolStripMenuItem";
            this.liniaKreskowaToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.liniaKreskowaToolStripMenuItem.Text = "Linia Kreskowa";
            this.liniaKreskowaToolStripMenuItem.Click += new System.EventHandler(this.liniaKreskowaToolStripMenuItem_Click);
            // 
            // liniaKreskowoKropkowaToolStripMenuItem
            // 
            this.liniaKreskowoKropkowaToolStripMenuItem.Name = "liniaKreskowoKropkowaToolStripMenuItem";
            this.liniaKreskowoKropkowaToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.liniaKreskowoKropkowaToolStripMenuItem.Text = "Linia KreskowoKropkowa";
            this.liniaKreskowoKropkowaToolStripMenuItem.Click += new System.EventHandler(this.liniaKreskowoKropkowaToolStripMenuItem_Click);
            // 
            // grubośćLiniiToolStripMenuItem
            // 
            this.grubośćLiniiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.grubośćLiniiToolStripMenuItem.Name = "grubośćLiniiToolStripMenuItem";
            this.grubośćLiniiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grubośćLiniiToolStripMenuItem.Text = "Grubość linii";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "3";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "4";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = "5";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // kolorLiniiToolStripMenuItem
            // 
            this.kolorLiniiToolStripMenuItem.Name = "kolorLiniiToolStripMenuItem";
            this.kolorLiniiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kolorLiniiToolStripMenuItem.Text = "Kolor linii";
            this.kolorLiniiToolStripMenuItem.Click += new System.EventHandler(this.kolorLiniiToolStripMenuItem_Click);
            // 
            // liniaKreskowoKropkowaKropkowaToolStripMenuItem1
            // 
            this.liniaKreskowoKropkowaKropkowaToolStripMenuItem1.Name = "liniaKreskowoKropkowaKropkowaToolStripMenuItem1";
            this.liniaKreskowoKropkowaKropkowaToolStripMenuItem1.Size = new System.Drawing.Size(259, 22);
            this.liniaKreskowoKropkowaKropkowaToolStripMenuItem1.Text = "Linia KreskowoKropkowaKropkowa";
            this.liniaKreskowoKropkowaKropkowaToolStripMenuItem1.Click += new System.EventHandler(this.liniaKreskowoKropkowaKropkowaToolStripMenuItem1_Click);
            // 
            // liniaKropkowaToolStripMenuItem1
            // 
            this.liniaKropkowaToolStripMenuItem1.Name = "liniaKropkowaToolStripMenuItem1";
            this.liniaKropkowaToolStripMenuItem1.Size = new System.Drawing.Size(259, 22);
            this.liniaKropkowaToolStripMenuItem1.Text = "Linia Kropkowa";
            this.liniaKropkowaToolStripMenuItem1.Click += new System.EventHandler(this.liniaKropkowaToolStripMenuItem1_Click);
            // 
            // liniaCiągłaToolStripMenuItem1
            // 
            this.liniaCiągłaToolStripMenuItem1.Name = "liniaCiągłaToolStripMenuItem1";
            this.liniaCiągłaToolStripMenuItem1.Size = new System.Drawing.Size(259, 22);
            this.liniaCiągłaToolStripMenuItem1.Text = "Linia Ciągła";
            this.liniaCiągłaToolStripMenuItem1.Click += new System.EventHandler(this.liniaCiągłaToolStripMenuItem1_Click);
            // 
            // LaboratoriumNr1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 510);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAnimacja);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.txtXg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXd);
            this.Controls.Add(this.pbRysownica);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LaboratoriumNr1";
            this.Text = "LaboratoriumNr1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaboratoriumNr1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnimacja;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtXg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXd;
        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem obramowanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stylLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grubośćLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaKreskowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaKreskowoKropkowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem liniaKreskowoKropkowaKropkowaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem liniaKropkowaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem liniaCiągłaToolStripMenuItem1;
    }
}