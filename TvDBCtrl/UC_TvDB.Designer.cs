namespace TvDBCtrl
{
    partial class UC_TvDB
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

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TvDB));
            this.PnlSerie = new System.Windows.Forms.Panel();
            this.PbTvDBReady = new System.Windows.Forms.PictureBox();
            this.LblStatus = new System.Windows.Forms.Label();
            this.PnlSaiEpi = new System.Windows.Forms.Panel();
            this.BtSearchSaisEpi = new System.Windows.Forms.Button();
            this.BtView = new System.Windows.Forms.Button();
            this.CbToutEpisodes = new System.Windows.Forms.CheckBox();
            this.CbTouteSaisons = new System.Windows.Forms.CheckBox();
            this.TxtEpisode = new System.Windows.Forms.TextBox();
            this.TxtSaison = new System.Windows.Forms.TextBox();
            this.LblEpisode = new System.Windows.Forms.Label();
            this.LblSaison = new System.Windows.Forms.Label();
            this.LvResult = new System.Windows.Forms.ListView();
            this.Lv_HID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Lv_HTitre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Lv_HStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Lv_HYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblLangue = new System.Windows.Forms.Label();
            this.CmbLangue = new System.Windows.Forms.ComboBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.BtSearch = new System.Windows.Forms.Button();
            this.PnlBanner = new System.Windows.Forms.Panel();
            this.PbBanner = new System.Windows.Forms.PictureBox();
            this.Il_Ctrl = new System.Windows.Forms.ImageList(this.components);
            this.PnlResultView = new System.Windows.Forms.Panel();
            this.CmbView = new System.Windows.Forms.ComboBox();
            this.PgResult = new System.Windows.Forms.PropertyGrid();
            this.BtClose = new System.Windows.Forms.Button();
            this.PnlSerie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbTvDBReady)).BeginInit();
            this.PnlSaiEpi.SuspendLayout();
            this.PnlBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbBanner)).BeginInit();
            this.PnlResultView.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlSerie
            // 
            this.PnlSerie.Controls.Add(this.PbTvDBReady);
            this.PnlSerie.Controls.Add(this.LblStatus);
            this.PnlSerie.Controls.Add(this.PnlSaiEpi);
            this.PnlSerie.Controls.Add(this.LvResult);
            this.PnlSerie.Controls.Add(this.lblLangue);
            this.PnlSerie.Controls.Add(this.CmbLangue);
            this.PnlSerie.Controls.Add(this.TxtSearch);
            this.PnlSerie.Controls.Add(this.BtSearch);
            this.PnlSerie.Location = new System.Drawing.Point(2, 82);
            this.PnlSerie.Name = "PnlSerie";
            this.PnlSerie.Size = new System.Drawing.Size(383, 263);
            this.PnlSerie.TabIndex = 8;
            // 
            // PbTvDBReady
            // 
            this.PbTvDBReady.Location = new System.Drawing.Point(359, 43);
            this.PbTvDBReady.Name = "PbTvDBReady";
            this.PbTvDBReady.Size = new System.Drawing.Size(20, 20);
            this.PbTvDBReady.TabIndex = 14;
            this.PbTvDBReady.TabStop = false;
            // 
            // LblStatus
            // 
            this.LblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblStatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus.Location = new System.Drawing.Point(3, 241);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(376, 18);
            this.LblStatus.TabIndex = 13;
            // 
            // PnlSaiEpi
            // 
            this.PnlSaiEpi.Controls.Add(this.BtSearchSaisEpi);
            this.PnlSaiEpi.Controls.Add(this.BtView);
            this.PnlSaiEpi.Controls.Add(this.CbToutEpisodes);
            this.PnlSaiEpi.Controls.Add(this.CbTouteSaisons);
            this.PnlSaiEpi.Controls.Add(this.TxtEpisode);
            this.PnlSaiEpi.Controls.Add(this.TxtSaison);
            this.PnlSaiEpi.Controls.Add(this.LblEpisode);
            this.PnlSaiEpi.Controls.Add(this.LblSaison);
            this.PnlSaiEpi.Location = new System.Drawing.Point(3, 203);
            this.PnlSaiEpi.Name = "PnlSaiEpi";
            this.PnlSaiEpi.Size = new System.Drawing.Size(376, 35);
            this.PnlSaiEpi.TabIndex = 12;
            // 
            // BtSearchSaisEpi
            // 
            this.BtSearchSaisEpi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtSearchSaisEpi.Image = global::TvDBCtrl.Properties.Resources.loupe;
            this.BtSearchSaisEpi.Location = new System.Drawing.Point(306, 1);
            this.BtSearchSaisEpi.Name = "BtSearchSaisEpi";
            this.BtSearchSaisEpi.Size = new System.Drawing.Size(33, 33);
            this.BtSearchSaisEpi.TabIndex = 8;
            this.BtSearchSaisEpi.UseVisualStyleBackColor = true;
            this.BtSearchSaisEpi.Click += new System.EventHandler(this.BtSearchSaisEpi_Click);
            // 
            // BtView
            // 
            this.BtView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtView.Image = global::TvDBCtrl.Properties.Resources.viewresult;
            this.BtView.Location = new System.Drawing.Point(343, 1);
            this.BtView.Name = "BtView";
            this.BtView.Size = new System.Drawing.Size(33, 33);
            this.BtView.TabIndex = 8;
            this.BtView.UseVisualStyleBackColor = true;
            this.BtView.Visible = false;
            this.BtView.Click += new System.EventHandler(this.BtView_Click);
            // 
            // CbToutEpisodes
            // 
            this.CbToutEpisodes.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbToutEpisodes.Location = new System.Drawing.Point(254, 6);
            this.CbToutEpisodes.Name = "CbToutEpisodes";
            this.CbToutEpisodes.Size = new System.Drawing.Size(58, 22);
            this.CbToutEpisodes.TabIndex = 7;
            this.CbToutEpisodes.Text = "Tout";
            this.CbToutEpisodes.UseVisualStyleBackColor = true;
            // 
            // CbTouteSaisons
            // 
            this.CbTouteSaisons.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbTouteSaisons.Location = new System.Drawing.Point(90, 6);
            this.CbTouteSaisons.Name = "CbTouteSaisons";
            this.CbTouteSaisons.Size = new System.Drawing.Size(65, 22);
            this.CbTouteSaisons.TabIndex = 7;
            this.CbTouteSaisons.Text = "Toutes";
            this.CbTouteSaisons.UseVisualStyleBackColor = true;
            // 
            // TxtEpisode
            // 
            this.TxtEpisode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEpisode.Location = new System.Drawing.Point(218, 6);
            this.TxtEpisode.Name = "TxtEpisode";
            this.TxtEpisode.Size = new System.Drawing.Size(30, 22);
            this.TxtEpisode.TabIndex = 6;
            this.TxtEpisode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtSaison
            // 
            this.TxtSaison.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSaison.Location = new System.Drawing.Point(54, 6);
            this.TxtSaison.Name = "TxtSaison";
            this.TxtSaison.Size = new System.Drawing.Size(30, 22);
            this.TxtSaison.TabIndex = 5;
            this.TxtSaison.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblEpisode
            // 
            this.LblEpisode.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEpisode.Location = new System.Drawing.Point(161, 6);
            this.LblEpisode.Name = "LblEpisode";
            this.LblEpisode.Size = new System.Drawing.Size(60, 21);
            this.LblEpisode.TabIndex = 4;
            this.LblEpisode.Text = "Episode";
            this.LblEpisode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblSaison
            // 
            this.LblSaison.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaison.Location = new System.Drawing.Point(3, 6);
            this.LblSaison.Name = "LblSaison";
            this.LblSaison.Size = new System.Drawing.Size(55, 21);
            this.LblSaison.TabIndex = 4;
            this.LblSaison.Text = "Saison";
            this.LblSaison.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LvResult
            // 
            this.LvResult.BackColor = System.Drawing.SystemColors.Control;
            this.LvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Lv_HID,
            this.Lv_HTitre,
            this.Lv_HStatus,
            this.Lv_HYear});
            this.LvResult.FullRowSelect = true;
            this.LvResult.GridLines = true;
            this.LvResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvResult.Location = new System.Drawing.Point(3, 69);
            this.LvResult.Name = "LvResult";
            this.LvResult.Size = new System.Drawing.Size(376, 128);
            this.LvResult.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LvResult.TabIndex = 11;
            this.LvResult.UseCompatibleStateImageBehavior = false;
            this.LvResult.View = System.Windows.Forms.View.Details;
            this.LvResult.SelectedIndexChanged += new System.EventHandler(this.LvResult_SelectedIndexChanged);
            // 
            // Lv_HID
            // 
            this.Lv_HID.Text = "TvDB ID";
            // 
            // Lv_HTitre
            // 
            this.Lv_HTitre.Text = "Titre";
            this.Lv_HTitre.Width = 190;
            // 
            // Lv_HStatus
            // 
            this.Lv_HStatus.Text = "Status";
            // 
            // Lv_HYear
            // 
            this.Lv_HYear.Text = "Année";
            this.Lv_HYear.Width = 50;
            // 
            // lblLangue
            // 
            this.lblLangue.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLangue.Location = new System.Drawing.Point(3, 42);
            this.lblLangue.Name = "lblLangue";
            this.lblLangue.Size = new System.Drawing.Size(55, 21);
            this.lblLangue.TabIndex = 10;
            this.lblLangue.Text = "Langue";
            this.lblLangue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbLangue
            // 
            this.CmbLangue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLangue.FormattingEnabled = true;
            this.CmbLangue.Location = new System.Drawing.Point(61, 42);
            this.CmbLangue.Name = "CmbLangue";
            this.CmbLangue.Size = new System.Drawing.Size(83, 21);
            this.CmbLangue.TabIndex = 9;
            this.CmbLangue.SelectedIndexChanged += new System.EventHandler(this.CmbLangue_SelectedIndexChanged);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.Location = new System.Drawing.Point(3, 3);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(337, 33);
            this.TxtSearch.TabIndex = 8;
            // 
            // BtSearch
            // 
            this.BtSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtSearch.Image = global::TvDBCtrl.Properties.Resources.loupe;
            this.BtSearch.Location = new System.Drawing.Point(346, 3);
            this.BtSearch.Name = "BtSearch";
            this.BtSearch.Size = new System.Drawing.Size(33, 33);
            this.BtSearch.TabIndex = 7;
            this.BtSearch.UseVisualStyleBackColor = true;
            this.BtSearch.Click += new System.EventHandler(this.BtSearch_Click);
            // 
            // PnlBanner
            // 
            this.PnlBanner.Controls.Add(this.PbBanner);
            this.PnlBanner.Location = new System.Drawing.Point(2, 2);
            this.PnlBanner.Name = "PnlBanner";
            this.PnlBanner.Size = new System.Drawing.Size(383, 74);
            this.PnlBanner.TabIndex = 9;
            // 
            // PbBanner
            // 
            this.PbBanner.Location = new System.Drawing.Point(2, 2);
            this.PbBanner.Name = "PbBanner";
            this.PbBanner.Size = new System.Drawing.Size(379, 70);
            this.PbBanner.TabIndex = 1;
            this.PbBanner.TabStop = false;
            // 
            // Il_Ctrl
            // 
            this.Il_Ctrl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Il_Ctrl.ImageStream")));
            this.Il_Ctrl.TransparentColor = System.Drawing.Color.Transparent;
            this.Il_Ctrl.Images.SetKeyName(0, "TopRouge.png");
            this.Il_Ctrl.Images.SetKeyName(1, "TopVert.png");
            // 
            // PnlResultView
            // 
            this.PnlResultView.Controls.Add(this.CmbView);
            this.PnlResultView.Controls.Add(this.PgResult);
            this.PnlResultView.Controls.Add(this.BtClose);
            this.PnlResultView.Location = new System.Drawing.Point(2, 2);
            this.PnlResultView.Name = "PnlResultView";
            this.PnlResultView.Size = new System.Drawing.Size(383, 343);
            this.PnlResultView.TabIndex = 10;
            // 
            // CmbView
            // 
            this.CmbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbView.FormattingEnabled = true;
            this.CmbView.Location = new System.Drawing.Point(3, 316);
            this.CmbView.Name = "CmbView";
            this.CmbView.Size = new System.Drawing.Size(121, 21);
            this.CmbView.TabIndex = 2;
            this.CmbView.SelectedIndexChanged += new System.EventHandler(this.CmbView_SelectedIndexChanged);
            // 
            // PgResult
            // 
            this.PgResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PgResult.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PgResult.Location = new System.Drawing.Point(3, 3);
            this.PgResult.Name = "PgResult";
            this.PgResult.Size = new System.Drawing.Size(377, 307);
            this.PgResult.TabIndex = 0;
            this.PgResult.ToolbarVisible = false;
            // 
            // BtClose
            // 
            this.BtClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtClose.Location = new System.Drawing.Point(305, 316);
            this.BtClose.Name = "BtClose";
            this.BtClose.Size = new System.Drawing.Size(75, 23);
            this.BtClose.TabIndex = 1;
            this.BtClose.Text = "Fermer";
            this.BtClose.UseVisualStyleBackColor = true;
            this.BtClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // UC_TvDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlBanner);
            this.Controls.Add(this.PnlSerie);
            this.Controls.Add(this.PnlResultView);
            this.Name = "UC_TvDB";
            this.Size = new System.Drawing.Size(388, 348);
            this.Load += new System.EventHandler(this.UC_TvDB_Load);
            this.PnlSerie.ResumeLayout(false);
            this.PnlSerie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbTvDBReady)).EndInit();
            this.PnlSaiEpi.ResumeLayout(false);
            this.PnlSaiEpi.PerformLayout();
            this.PnlBanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbBanner)).EndInit();
            this.PnlResultView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlSerie;
        private System.Windows.Forms.ListView LvResult;
        private System.Windows.Forms.ColumnHeader Lv_HID;
        private System.Windows.Forms.ColumnHeader Lv_HTitre;
        private System.Windows.Forms.ColumnHeader Lv_HStatus;
        private System.Windows.Forms.ColumnHeader Lv_HYear;
        private System.Windows.Forms.Label lblLangue;
        private System.Windows.Forms.ComboBox CmbLangue;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button BtSearch;
        private System.Windows.Forms.Panel PnlBanner;
        private System.Windows.Forms.PictureBox PbBanner;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Panel PnlSaiEpi;
        private System.Windows.Forms.Button BtSearchSaisEpi;
        private System.Windows.Forms.Button BtView;
        private System.Windows.Forms.CheckBox CbToutEpisodes;
        private System.Windows.Forms.CheckBox CbTouteSaisons;
        private System.Windows.Forms.TextBox TxtEpisode;
        private System.Windows.Forms.TextBox TxtSaison;
        private System.Windows.Forms.Label LblEpisode;
        private System.Windows.Forms.Label LblSaison;
        private System.Windows.Forms.PictureBox PbTvDBReady;
        private System.Windows.Forms.ImageList Il_Ctrl;
        private System.Windows.Forms.Panel PnlResultView;
        private System.Windows.Forms.Button BtClose;
        private System.Windows.Forms.PropertyGrid PgResult;
        private System.Windows.Forms.ComboBox CmbView;
    }
}
