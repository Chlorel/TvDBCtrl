namespace TestApp
{
    partial class FrmTest
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTest));
            this.PgViewCtrl = new System.Windows.Forms.PropertyGrid();
            this.BtAfficher = new System.Windows.Forms.Button();
            this.uC_TvDB1 = new TvDBCtrl.UC_TvDB();
            this.CmbSelect = new System.Windows.Forms.ComboBox();
            this.PnlGetAPIKey = new System.Windows.Forms.Panel();
            this.PnlTvDBLng = new System.Windows.Forms.Panel();
            this.BtOK = new System.Windows.Forms.Button();
            this.CmbAPILng = new System.Windows.Forms.ComboBox();
            this.LblAPILng = new System.Windows.Forms.Label();
            this.BtAPIKey = new System.Windows.Forms.Button();
            this.TxtAPIKey = new System.Windows.Forms.TextBox();
            this.LblAPIKey = new System.Windows.Forms.Label();
            this.IlMain = new System.Windows.Forms.ImageList(this.components);
            this.PbKey = new System.Windows.Forms.PictureBox();
            this.PnlGetAPIKey.SuspendLayout();
            this.PnlTvDBLng.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbKey)).BeginInit();
            this.SuspendLayout();
            // 
            // PgViewCtrl
            // 
            this.PgViewCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PgViewCtrl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PgViewCtrl.Location = new System.Drawing.Point(405, 12);
            this.PgViewCtrl.Name = "PgViewCtrl";
            this.PgViewCtrl.Size = new System.Drawing.Size(440, 317);
            this.PgViewCtrl.TabIndex = 1;
            this.PgViewCtrl.ToolbarVisible = false;
            // 
            // BtAfficher
            // 
            this.BtAfficher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtAfficher.Location = new System.Drawing.Point(632, 337);
            this.BtAfficher.Name = "BtAfficher";
            this.BtAfficher.Size = new System.Drawing.Size(213, 23);
            this.BtAfficher.TabIndex = 2;
            this.BtAfficher.Text = "Voir les données du controle";
            this.BtAfficher.UseVisualStyleBackColor = true;
            this.BtAfficher.Click += new System.EventHandler(this.BtAfficher_Click);
            // 
            // uC_TvDB1
            // 
            this.uC_TvDB1.Ctrl_BannerZone = true;
            this.uC_TvDB1.Location = new System.Drawing.Point(11, 12);
            this.uC_TvDB1.Name = "uC_TvDB1";
            this.uC_TvDB1.Size = new System.Drawing.Size(388, 348);
            this.uC_TvDB1.TabIndex = 0;
            this.uC_TvDB1.TvDB_AllEpisode = false;
            this.uC_TvDB1.TvDB_AllSaison = false;
            this.uC_TvDB1.TvDB_Episode = 0;
            this.uC_TvDB1.TvDB_ImgFanart = true;
            this.uC_TvDB1.TvDB_ImgPosters = true;
            this.uC_TvDB1.TvDB_ImgSeaBanner = true;
            this.uC_TvDB1.TvDB_ImgSeaPoster = true;
            this.uC_TvDB1.TvDB_ImgSerie = true;
            this.uC_TvDB1.TvDB_Lng = null;
            this.uC_TvDB1.TvDB_Saison = 0;
            // 
            // CmbSelect
            // 
            this.CmbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSelect.FormattingEnabled = true;
            this.CmbSelect.Location = new System.Drawing.Point(405, 337);
            this.CmbSelect.Name = "CmbSelect";
            this.CmbSelect.Size = new System.Drawing.Size(121, 21);
            this.CmbSelect.TabIndex = 3;
            this.CmbSelect.SelectedIndexChanged += new System.EventHandler(this.CmbSelect_SelectedIndexChanged);
            // 
            // PnlGetAPIKey
            // 
            this.PnlGetAPIKey.Controls.Add(this.PbKey);
            this.PnlGetAPIKey.Controls.Add(this.PnlTvDBLng);
            this.PnlGetAPIKey.Controls.Add(this.BtAPIKey);
            this.PnlGetAPIKey.Controls.Add(this.TxtAPIKey);
            this.PnlGetAPIKey.Controls.Add(this.LblAPIKey);
            this.PnlGetAPIKey.Location = new System.Drawing.Point(11, 12);
            this.PnlGetAPIKey.Name = "PnlGetAPIKey";
            this.PnlGetAPIKey.Size = new System.Drawing.Size(834, 348);
            this.PnlGetAPIKey.TabIndex = 4;
            // 
            // PnlTvDBLng
            // 
            this.PnlTvDBLng.Controls.Add(this.BtOK);
            this.PnlTvDBLng.Controls.Add(this.CmbAPILng);
            this.PnlTvDBLng.Controls.Add(this.LblAPILng);
            this.PnlTvDBLng.Location = new System.Drawing.Point(250, 124);
            this.PnlTvDBLng.Name = "PnlTvDBLng";
            this.PnlTvDBLng.Size = new System.Drawing.Size(334, 62);
            this.PnlTvDBLng.TabIndex = 7;
            // 
            // BtOK
            // 
            this.BtOK.Location = new System.Drawing.Point(241, 19);
            this.BtOK.Name = "BtOK";
            this.BtOK.Size = new System.Drawing.Size(75, 23);
            this.BtOK.TabIndex = 2;
            this.BtOK.Text = "Save";
            this.BtOK.UseVisualStyleBackColor = true;
            this.BtOK.Click += new System.EventHandler(this.BtOK_Click);
            // 
            // CmbAPILng
            // 
            this.CmbAPILng.FormattingEnabled = true;
            this.CmbAPILng.Location = new System.Drawing.Point(105, 19);
            this.CmbAPILng.Name = "CmbAPILng";
            this.CmbAPILng.Size = new System.Drawing.Size(121, 21);
            this.CmbAPILng.TabIndex = 1;
            this.CmbAPILng.SelectedIndexChanged += new System.EventHandler(this.CmbAPILng_SelectedIndexChanged);
            // 
            // LblAPILng
            // 
            this.LblAPILng.AutoSize = true;
            this.LblAPILng.Location = new System.Drawing.Point(16, 22);
            this.LblAPILng.Name = "LblAPILng";
            this.LblAPILng.Size = new System.Drawing.Size(80, 13);
            this.LblAPILng.TabIndex = 0;
            this.LblAPILng.Text = "User Language";
            // 
            // BtAPIKey
            // 
            this.BtAPIKey.Location = new System.Drawing.Point(509, 73);
            this.BtAPIKey.Name = "BtAPIKey";
            this.BtAPIKey.Size = new System.Drawing.Size(75, 23);
            this.BtAPIKey.TabIndex = 5;
            this.BtAPIKey.Text = "Checkout";
            this.BtAPIKey.UseVisualStyleBackColor = true;
            this.BtAPIKey.Click += new System.EventHandler(this.BtAPIKey_Click);
            // 
            // TxtAPIKey
            // 
            this.TxtAPIKey.Location = new System.Drawing.Point(355, 75);
            this.TxtAPIKey.Name = "TxtAPIKey";
            this.TxtAPIKey.Size = new System.Drawing.Size(121, 20);
            this.TxtAPIKey.TabIndex = 6;
            // 
            // LblAPIKey
            // 
            this.LblAPIKey.AutoSize = true;
            this.LblAPIKey.Location = new System.Drawing.Point(245, 78);
            this.LblAPIKey.Name = "LblAPIKey";
            this.LblAPIKey.Size = new System.Drawing.Size(101, 13);
            this.LblAPIKey.TabIndex = 0;
            this.LblAPIKey.Text = "Enter TvDB APIKey";
            // 
            // IlMain
            // 
            this.IlMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IlMain.ImageStream")));
            this.IlMain.TransparentColor = System.Drawing.Color.Transparent;
            this.IlMain.Images.SetKeyName(0, "coche19.png");
            this.IlMain.Images.SetKeyName(1, "croix19.png");
            // 
            // PbKey
            // 
            this.PbKey.Location = new System.Drawing.Point(483, 75);
            this.PbKey.Name = "PbKey";
            this.PbKey.Size = new System.Drawing.Size(19, 19);
            this.PbKey.TabIndex = 8;
            this.PbKey.TabStop = false;
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 372);
            this.Controls.Add(this.PnlGetAPIKey);
            this.Controls.Add(this.CmbSelect);
            this.Controls.Add(this.BtAfficher);
            this.Controls.Add(this.PgViewCtrl);
            this.Controls.Add(this.uC_TvDB1);
            this.Name = "FrmTest";
            this.Text = "FrmTest";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            this.PnlGetAPIKey.ResumeLayout(false);
            this.PnlGetAPIKey.PerformLayout();
            this.PnlTvDBLng.ResumeLayout(false);
            this.PnlTvDBLng.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbKey)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TvDBCtrl.UC_TvDB uC_TvDB1;
        private System.Windows.Forms.PropertyGrid PgViewCtrl;
        private System.Windows.Forms.Button BtAfficher;
        private System.Windows.Forms.ComboBox CmbSelect;
        private System.Windows.Forms.Panel PnlGetAPIKey;
        private System.Windows.Forms.Panel PnlTvDBLng;
        private System.Windows.Forms.Button BtOK;
        private System.Windows.Forms.ComboBox CmbAPILng;
        private System.Windows.Forms.Label LblAPILng;
        private System.Windows.Forms.Button BtAPIKey;
        private System.Windows.Forms.TextBox TxtAPIKey;
        private System.Windows.Forms.Label LblAPIKey;
        private System.Windows.Forms.ImageList IlMain;
        private System.Windows.Forms.PictureBox PbKey;
    }
}

