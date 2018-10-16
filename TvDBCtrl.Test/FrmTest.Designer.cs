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
            this.PgViewCtrl = new System.Windows.Forms.PropertyGrid();
            this.BtAfficher = new System.Windows.Forms.Button();
            this.uC_TvDB1 = new TvDBCtrl.UC_TvDB();
            this.CmbSelect = new System.Windows.Forms.ComboBox();
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
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 372);
            this.Controls.Add(this.CmbSelect);
            this.Controls.Add(this.BtAfficher);
            this.Controls.Add(this.PgViewCtrl);
            this.Controls.Add(this.uC_TvDB1);
            this.Name = "FrmTest";
            this.Text = "FrmTest";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TvDBCtrl.UC_TvDB uC_TvDB1;
        private System.Windows.Forms.PropertyGrid PgViewCtrl;
        private System.Windows.Forms.Button BtAfficher;
        private System.Windows.Forms.ComboBox CmbSelect;
    }
}

