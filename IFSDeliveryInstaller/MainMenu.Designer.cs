namespace IFSDeliveryInstaller
{
    partial class IFSDeliveryInstaller
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IFSDeliveryInstaller));
            this.btnSelectArchive = new System.Windows.Forms.Button();
            this.txtArchivePath = new System.Windows.Forms.TextBox();
            this.btnUnpack = new System.Windows.Forms.Button();
            this.btnInstall1 = new System.Windows.Forms.Button();
            this.txtCommand1 = new System.Windows.Forms.TextBox();
            this.txtCommand2 = new System.Windows.Forms.TextBox();
            this.btnInstall2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectArchive
            // 
            this.btnSelectArchive.Location = new System.Drawing.Point(340, 53);
            this.btnSelectArchive.Name = "btnSelectArchive";
            this.btnSelectArchive.Size = new System.Drawing.Size(123, 23);
            this.btnSelectArchive.TabIndex = 0;
            this.btnSelectArchive.Text = "Wybierz archiwum";
            this.btnSelectArchive.UseVisualStyleBackColor = true;
            this.btnSelectArchive.Click += new System.EventHandler(this.btnSelectArchive_Click);
            // 
            // txtArchivePath
            // 
            this.txtArchivePath.Location = new System.Drawing.Point(246, 27);
            this.txtArchivePath.Name = "txtArchivePath";
            this.txtArchivePath.ReadOnly = true;
            this.txtArchivePath.Size = new System.Drawing.Size(296, 20);
            this.txtArchivePath.TabIndex = 1;
            // 
            // btnUnpack
            // 
            this.btnUnpack.Location = new System.Drawing.Point(340, 82);
            this.btnUnpack.Name = "btnUnpack";
            this.btnUnpack.Size = new System.Drawing.Size(123, 23);
            this.btnUnpack.TabIndex = 2;
            this.btnUnpack.Text = "Rozpakuj i przygotuj";
            this.btnUnpack.UseVisualStyleBackColor = true;
            this.btnUnpack.Click += new System.EventHandler(this.btnUnpack_Click);
            // 
            // btnInstall1
            // 
            this.btnInstall1.Location = new System.Drawing.Point(445, 160);
            this.btnInstall1.Name = "btnInstall1";
            this.btnInstall1.Size = new System.Drawing.Size(215, 23);
            this.btnInstall1.TabIndex = 3;
            this.btnInstall1.Text = "Uruchom instalację SZKOL & TEST";
            this.btnInstall1.UseVisualStyleBackColor = true;
            this.btnInstall1.Click += new System.EventHandler(this.btnInstall1_Click);
            // 
            // txtCommand1
            // 
            this.txtCommand1.Location = new System.Drawing.Point(196, 162);
            this.txtCommand1.Name = "txtCommand1";
            this.txtCommand1.ReadOnly = true;
            this.txtCommand1.Size = new System.Drawing.Size(243, 20);
            this.txtCommand1.TabIndex = 4;
            // 
            // txtCommand2
            // 
            this.txtCommand2.Location = new System.Drawing.Point(196, 190);
            this.txtCommand2.Name = "txtCommand2";
            this.txtCommand2.ReadOnly = true;
            this.txtCommand2.Size = new System.Drawing.Size(243, 20);
            this.txtCommand2.TabIndex = 5;
            // 
            // btnInstall2
            // 
            this.btnInstall2.Location = new System.Drawing.Point(445, 188);
            this.btnInstall2.Name = "btnInstall2";
            this.btnInstall2.Size = new System.Drawing.Size(215, 23);
            this.btnInstall2.TabIndex = 6;
            this.btnInstall2.Text = "Uruchom instalację PROD";
            this.btnInstall2.UseVisualStyleBackColor = true;
            this.btnInstall2.Click += new System.EventHandler(this.btnInstall2_Click);
            // 
            // IFSDeliveryInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInstall2);
            this.Controls.Add(this.txtCommand2);
            this.Controls.Add(this.txtCommand1);
            this.Controls.Add(this.btnInstall1);
            this.Controls.Add(this.btnUnpack);
            this.Controls.Add(this.txtArchivePath);
            this.Controls.Add(this.btnSelectArchive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IFSDeliveryInstaller";
            this.Text = "IFSDeliveryInstaller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectArchive;
        private System.Windows.Forms.TextBox txtArchivePath;
        private System.Windows.Forms.Button btnUnpack;
        private System.Windows.Forms.Button btnInstall1;
        private System.Windows.Forms.TextBox txtCommand1;
        private System.Windows.Forms.TextBox txtCommand2;
        private System.Windows.Forms.Button btnInstall2;
    }
}

