using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using TvDBCtrl.Tools;
using TvDBCtrl.Client;
using TvDBCtrl.Enums;
using TvDBCtrl.Objects.Models;

namespace TvDBCtrl
{
    public partial class UC_TvDB: UserControl
    {
        /// <summary>
        /// TvDB APIKey à utiliser avec le client TvDB
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Le TvDB APIKey utilisé")]
        public string       TvDB_Key            { get { return TvDBAPIKey; } }
        
        /// <summary>
        /// TvDB Langue souhaitée pour les resultats
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Langue préférée pour les recherches (fr pour Français, en pour Anglais, ...)")]
        public string       TvDB_Lng            { get { return TvDBAPILng; } set { TvDBAPILng = value; if (Ctrl_IsReady) { Client.Language = TvDBAPILng; } } }
        
        /// <summary>
        /// Numéro d'épisode si l'on en souhaite qu'un seul en particulier
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Numéro d'épisode si l'on en souhaite qu'un seul en particulier")]
        public Int32        TvDB_Episode        { get { return Ctrl_Episode; } set { Ctrl_Episode = value; TxtEpisode.Text = Ctrl_Episode.ToString(); } }

        /// <summary>
        /// Numéro de saison si l'on souhaite un épisode particulier
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Numéro de saison si l'on souhaite un épisode particulier")]
        public Int32        TvDB_Saison         { get { return Ctrl_Saison;  } set { Ctrl_Saison = value;  TxtSaison.Text = Ctrl_Saison.ToString(); } }

        /// <summary>
        /// Booléan pour choisir ou non tout les épisodes de la saisons
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Choisir ou non tout les épisodes de la, ou des, saison(s)")]
        public bool         TvDB_AllEpisode     { get { return CbToutEpisodes.Checked; } set { CbToutEpisodes.Checked = value; } }

        /// <summary>
        /// Booléan pour choisir ou non toutes les saisons
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Choisir ou non toutes les saisons")]
        public bool         TvDB_AllSaison      { get { return CbTouteSaisons.Checked; } set { CbTouteSaisons.Checked = value; } }

        /// <summary>
        /// Booléan de récupération les posters de serie
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Récuperer les Posters pour la série trouvée")]
        public bool         TvDB_ImgPosters     { get; set; }

        /// <summary>
        /// Booléan de récupération les fanarts de serie
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Récuperer les Fanarts pour la série trouvée")]
        public bool         TvDB_ImgFanart      { get; set; }

        /// <summary>
        /// Booléan de récupération les posters de saisons de serie
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Récuperer les Posters de saisons pour la série trouvée")]
        public bool         TvDB_ImgSeaPoster   { get; set; }

        /// <summary>
        /// Booléan de récupération les banners de saison de serie
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Récuperer les Banners de saisons pour la série trouvée")]
        public bool         TvDB_ImgSeaBanner   { get; set; }

        /// <summary>
        /// Booléan de récupération les images serie de serie
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Récuperer les Images de Série pour la série trouvée")]
        public bool         TvDB_ImgSerie       { get; set; }

        /// <summary>
        /// Le resultat des données recherchées 
        /// </summary>
        [Category("TvDB Client"), Browsable(true), Description("Toutes les données trouvées pour la Série cherchée")]
        public SeriesFull   TvDB_Serie          { get { return Serie; } internal set { } }

        /// <summary>
        /// Booléan pour afficher ou non la zone de banner
        /// </summary>
        [Category("TvDB Control"), Browsable(true), Description("Afficher le banner de la série selectionnée lors d'une recherche par un 'FindSerie'")]

        public bool         Ctrl_BannerZone
        {
            get
            {
                return PnlBanner.Visible;
            }
            set
            {
                PnlBanner.Visible = value;
                if (value == true)
                {
                    PnlSerie.Top            = SerieTop;
                    PnlResultView.Height    = ResultFullHeight;
                    this.Height             = CtrlFullHeight;
                }
                else
                {
                    PnlSerie.Top            = 2;
                    PnlResultView.Height    = ResultShortHeight;
                    this.Height             = CtrkShortHeight;
                }
            }
        }
        /// <summary>
        /// Booléan pour signifier que la recherche est disponible ( bon APIKey / Token valide )
        /// </summary>
        [Category("TvDB Control"), Browsable(true), Description("Permet de savoir si le Client est pret à faire une recherche")]
        public bool         Ctrl_IsReady    { get; internal set; }

        /// <summary>
        /// Liste des langues supporté par le client TvDB sous forme de list de structure
        /// </summary>
        [Category("TvDB Control"), Browsable(true), Description("La liste complete des langues supportée par The TvDB")]
        public List<Language> Ctrl_Languages { get; internal set; }

        /// <summary>
        /// Liste des langues supporté par le client TvDB 
        /// </summary>
        [Category("TvDB Control"), Browsable(false), Description("Diffuse la liste des langues supporté par TvDB")]
        public List<string> Languages     { get; internal set; }

        
        private int         SerieTop            = 82;
        private int         CtrlFullHeight      = 348;
        private int         ResultShortHeight   = 263;
        private int         ResultFullHeight    = 343;
        private int         CtrkShortHeight     = 268;
        private bool        IsInDesignMode;

        private TvDBClient  Client;
        private SeriesFull  Serie;
        private string      TvDBAPIKey;
        private string      TvDBAPILng;
        private UInt32      SerieID;
        private Int32       Ctrl_Episode;
        private Int32       Ctrl_Saison;

        Timer InitClient;

        /// <summary>
        /// UC_TvDB () Main initialisation for the custom control
        /// </summary>
        public UC_TvDB()
        {
            InitializeComponent ();

            this.IsInDesignMode     = this.DesignMode;
            Ctrl_IsReady            = false;
            PnlResultView.Visible   = false;
            PnlResultView.SendToBack();
            PnlSaiEpi.Visible       = false;
            BtSearch.Enabled        = false;
            CmbLangue.Enabled       = false;
            PbTvDBReady.Image       = Il_Ctrl.Images[0];
        }

        private void UC_TvDB_Load                           ( object sender, EventArgs e )
        {
            if (!IsInDesignMode)
            {
                Client                      = new TvDBClient();
                InitClient                  = new Timer();
                InitClient.Tick            += new EventHandler(InitClient_Tick);
                InitClient.Interval         = 1000;
                InitClient.Start();

                List<TComboView> ViewType   = new List<TComboView>();
                ViewType.Add(new TComboView() { Name = "Serie"      , Value = 1 });
                ViewType.Add(new TComboView() { Name = "Graphics"   , Value = 2 });
                ViewType.Add(new TComboView() { Name = "Summary"    , Value = 3 });
                this.CmbView.DataSource     = ViewType;
                this.CmbView.DisplayMember  = "Name";
                this.CmbView.ValueMember    = "Value";
                this.CmbView.DropDownStyle  = ComboBoxStyle.DropDownList;
                CmbView.SelectedValue       = 1;

            }
        }

        /// <summary>
        /// InitClient_Tick : timer handled function only activated at runtime so long no valid APIKey is entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void InitClient_Tick                  ( object sender, EventArgs e )
        {
            if (!string.IsNullOrEmpty(TvDB_Key))
            {
                LblStatus.Text          = "Initialisation APIKey";
                InitClient.Stop();
                bool bResult            = await Client.SetAPIKey(TvDB_Key);
                if (bResult)
                {
                    LblStatus.Text      = "Initialisation Langues";
                    if (Client.Languages.Count > 0)
                    {
                        List<TComboLangue>  LngType = new List<TComboLangue>();
                        Languages                   = new List<string>();
                        foreach (string Lng in Client.Languages)
                        {
                            LngType.Add(new TComboLangue() { Name = Lng.ToUpper(), Value = Lng });
                            Languages.Add(Lng);
                        }

                        this.CmbLangue.DataSource       = LngType;
                        this.CmbLangue.DisplayMember    = "Name";
                        this.CmbLangue.ValueMember      = "Value";
                        this.CmbLangue.DropDownStyle    = ComboBoxStyle.DropDownList;

                        if ( !string.IsNullOrEmpty(this.TvDBAPILng) )
                        {
                            CmbLangue.Text = this.TvDBAPILng.ToUpper();
                            Client.Language = TvDBAPILng.ToUpper();
                        }
                        

                        CmbLangue.Enabled = true;
                    }
                    LblStatus.Text      = "";
                    PbTvDBReady.Image   = Il_Ctrl.Images[1];
                    Ctrl_IsReady        = true;
                    BtSearch.Enabled    = true;
                }
                else
                {
                    LblStatus.Text = "Initialisation APIKey loupée";
                    InitClient.Start();
                }
            }
        }

        public event EventHandler SerieSearchDone;

        private async void BtSearch_Click                   ( object sender, EventArgs e )
        {
            string  Target      = TextTools.RemoveDiacritics(TxtSearch.Text);

            bool    IsTvDB      = Regex.Match(Target, "^[0-9]+$").Success;
            bool    IsImDB      = Regex.Match(Target.ToLower(), "(tt\\d{6})").Success;
            bool    IsZap2It    = Regex.Match(Target.ToUpper(), "(EP\\d{8})").Success;

            LvResult.Items.Clear();
            Client.Language     = TvDBAPILng;
            PnlSaiEpi.Visible   = false;
            BtView.Visible      = false;
            LblStatus.Text      = "Recherche ...";

            List<SeriesSummary> FoundSeries;
            if (IsTvDB)
            {
                FoundSeries = await Client.Series.FindSeries(Target, QueryType.TvDB);
            }
            else if (IsImDB)
            {
                FoundSeries = await Client.Series.FindSeries(Target, QueryType.ImDB);
            }
            else if (IsZap2It)
            {
                FoundSeries = await Client.Series.FindSeries(Target, QueryType.Zap2it);
            }
            else
            {
                FoundSeries = await Client.Series.FindSeries(Target, QueryType.Name);
            }

            if (FoundSeries?.Count > 0)
            {
                foreach (SeriesSummary FoundSerie in FoundSeries)
                {
                    ListViewItem    Lvi     = new ListViewItem(FoundSerie.TvDBID.ToString());
                    string          Year    = "";
                    Lvi.SubItems.Add(FoundSerie.SeriesName);
                    Lvi.SubItems.Add((FoundSerie.Status == Status.Continuing) ? "En Cours" : "Terminée");
                    if (FoundSerie.FirstAired != null)
                    {
                        Year                = FoundSerie.FirstAired.Value.Year.ToString();
                    }

                    Lvi.SubItems.Add(Year);
                    Lvi.Tag                 = !string.IsNullOrEmpty(FoundSerie.Banner) ? FoundSerie.Banner : "";
                    LvResult.Items.Add(Lvi);
                    LblStatus.Text = ""
;                }
                SerieSearchDone?.Invoke(sender, e);
            }
            else
            {
                LblStatus.Text = "Non trouvé !";
            }
        }

        public event EventHandler EpisodesSearchDone;

        private async void BtSearchSaisEpi_Click            ( object sender, EventArgs e )
        {
            LblStatus.Text      = "Lecture des episodes ...";

            Application.DoEvents();

            if (CbTouteSaisons.Checked && CbToutEpisodes.Checked)
            {
                Serie.Episodes  = await Client.Episodes.GetAllEpisodes(this.SerieID);
            }
            else if (CbToutEpisodes.Checked)
            {
                UInt32 Saison   = UInt32.Parse(TxtSaison.Text);
                Serie.Episodes  = await Client.Episodes.GetEpisodesForSeason(this.SerieID, Saison);
            }
            else
            {
                UInt32 Saison   = UInt32.Parse(TxtSaison.Text);
                UInt32 Episode  = UInt32.Parse(TxtEpisode.Text);
                Serie.Episodes  = await Client.Episodes.GetEpisode(this.SerieID, Saison, Episode);
            }

            Application.DoEvents();

            BtView.Visible      = true;
            LblStatus.Text      = "";
            EpisodesSearchDone?.Invoke(sender, e);

        }

        private void BtView_Click                           ( object sender, EventArgs e )
        {
            PnlResultView.Visible = true;
            PnlResultView.BringToFront();
            PgResult.SelectedObject = Serie;
        }

        private void CmbLangue_SelectedIndexChanged         ( object sender, EventArgs e )
        {
            int SelIndex    = CmbLangue.SelectedIndex;
            if (Ctrl_IsReady == true)
            {
                TvDBAPILng = CmbLangue.Text;           // ((Language)CmbLangue.Items[SelIndex]).abbreviation;
                Client.Language = TvDBAPILng;
            }
        }

        private void CmbView_SelectedIndexChanged           ( object sender, EventArgs e )
        {
            int SelIndex    = CmbView.SelectedIndex;
            if (Ctrl_IsReady == true)
            {
                Int32 SelValue = (Int32)CmbView.SelectedValue;
                switch (SelValue)
                {
                    case 1:
                        PgResult.SelectedObject = Serie;
                        break;
                    case 2:
                        PgResult.SelectedObject = Serie.Graphics;
                        break;
                    case 3:
                        PgResult.SelectedObject = Serie.Summary;
                        break;
                }
            }
        }

        public event EventHandler SeriesRetrieveDone;

        private async void LvResult_SelectedIndexChanged    ( object sender, EventArgs e )
        {
            if (LvResult.SelectedItems.Count == 1)
            {
                ListViewItem    SelItem     = LvResult.SelectedItems[0];
                this.SerieID                = Convert.ToUInt32(SelItem.Text);
                string          BannerUrl   = (string)SelItem.Tag;
                if (!string.IsNullOrEmpty(BannerUrl))
                {
                    if (Ctrl_BannerZone == true)
                    {
                        string Url          = Client.BannersUrl + BannerUrl;
                        PbBanner.Image      = GraphicsTools.ResizeInternetImage(Url, 0, 379, 70);
                    }
                }

                Range ToGet                 = Range.Serie | Range.Acteurs;

                if (TvDB_ImgPosters)    ToGet |= Range.ImgPosters;
                if (TvDB_ImgFanart)     ToGet |= Range.ImgFanart;
                if (TvDB_ImgSeaPoster)  ToGet |= Range.ImgSeason;
                if (TvDB_ImgSeaBanner)  ToGet |= Range.ImgSeasonWide;
                if (TvDB_ImgSerie)      ToGet |= Range.ImgSeries;

                Serie                       = await Client.Series.GetSeries(SerieID, ToGet);
                PnlSaiEpi.Visible = true;

                SeriesRetrieveDone?.Invoke(sender, e);
            }
        }

        private void BtClose_Click                          ( object sender, EventArgs e )
        {
            PnlResultView.Visible = false;
            PnlResultView.SendToBack();
        }

        public void SetTvDB_APIKey                          ( string APIKey )
        {
            TvDBAPIKey = APIKey;
        }

        public async Task<bool> CheckTvDB_APIKey ( string APIKey )
        {
            TvDBClient _client  = new TvDBClient();
            bool        bResult = false;

            bResult         = await _client.Authentication.CheckCredentials(APIKey);
            if (bResult)
            {
                bResult         = await _client.SetAPIKey(APIKey);
                Ctrl_Languages  = await _client.Langues.GetLanguage();
            }

            return bResult;
        }
    }

    public class TComboLangue
    {
        public string       Name    { get; set; }
        public string       Value   { get; set; }
    }

    public class TComboView
    {
        public string       Name    { get; set; }
        public int          Value   { get; set; } 
    }
}
