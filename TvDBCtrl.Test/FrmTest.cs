using System;
using System.Collections.Generic;
using System.Windows.Forms;

using TvDBCtrl;
using TvDBCtrl.Objects.Models;

namespace TestApp
{
    public partial class FrmTest : Form
    {
        UC_TvDB Tc;
        string  TvDBAPI_KEY = "";
        string  TvDBAPI_LNG = "";
        bool    bInitCombo  = false;

        public FrmTest()
        {
            InitializeComponent();

            CParams.Load();

            TvDBAPI_KEY = CParams.TV_ApiKey;
            TvDBAPI_LNG = CParams.TV_Langue;

            if (!string.IsNullOrEmpty(TvDBAPI_KEY))
            {
                PnlGetAPIKey.Visible    = false;
                PbKey.Image             = IlMain.Images[0];
            }
            else
            {
                PnlGetAPIKey.Visible    = true;
                PnlTvDBLng.Visible      = false;
                PbKey.Image             = IlMain.Images[1];
            }
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            List<TComboSel> ViewType        = new List<TComboSel>();
            ViewType.Add(new TComboSel() { Name = "Control"     , Value = 1 });
            ViewType.Add(new TComboSel() { Name = "Serie"       , Value = 2 });
            ViewType.Add(new TComboSel() { Name = "Graphics"    , Value = 3 });
            ViewType.Add(new TComboSel() { Name = "Summary"     , Value = 4 });
            ViewType.Add(new TComboSel() { Name = "Language"    , Value = 5 });
            this.CmbSelect.DataSource       = ViewType;
            this.CmbSelect.DisplayMember    = "Name";
            this.CmbSelect.ValueMember      = "Value";
            this.CmbSelect.DropDownStyle    = ComboBoxStyle.DropDownList;

            CmbSelect.SelectedValue         = 1;

            if (!string.IsNullOrEmpty(TvDBAPI_KEY))
            {
                uC_TvDB1.TvDB_Lng               = TvDBAPI_LNG;
                uC_TvDB1.SetTvDB_APIKey(TvDBAPI_KEY);

                PgViewCtrl.SelectedObject       = uC_TvDB1;
            }

        }

        private void BtAfficher_Click(object sender, EventArgs e)
        {
        }

        private void CmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelIndex = CmbSelect.SelectedIndex;
            if (uC_TvDB1.Ctrl_IsReady == true)
            {
                Int32 SelValue = (Int32)CmbSelect.SelectedValue;
                switch (SelValue)
                {
                    case 1:
                        PgViewCtrl.SelectedObject = uC_TvDB1;
                        break;
                    case 2:
                        PgViewCtrl.SelectedObject = uC_TvDB1.TvDB_Serie;
                        break;
                    case 3:
                        PgViewCtrl.SelectedObject = uC_TvDB1.TvDB_Serie.Graphics;
                        break;
                    case 4:
                        PgViewCtrl.SelectedObject = uC_TvDB1.TvDB_Serie.Summary;
                        break;
                    case 5:
                        PgViewCtrl.SelectedObject = uC_TvDB1.Languages;
                        break;
                }
            }

        }

        private async void BtAPIKey_Click(object sender, EventArgs e)
        {
            Tc = new UC_TvDB();

            TvDBAPI_KEY = TxtAPIKey.Text;
            // Check if the give APIKey is valid
            bool IsGood = await Tc.CheckTvDB_APIKey(TvDBAPI_KEY);
            if (IsGood == true)
            {
                List<TComboLng> ViewType = new List<TComboLng>();
                PbKey.Image = IlMain.Images[0];
                if (Tc.Ctrl_Languages.Count > 0)
                {
                    foreach (var Lng in Tc.Ctrl_Languages)
                    {
                        ViewType.Add(new TComboLng() { Name = Lng.name, Value = Lng });
                    }
                    this.CmbAPILng.DataSource       = ViewType;
                    this.CmbAPILng.DisplayMember    = "Name";
                    this.CmbAPILng.ValueMember      = "Value";
                    this.CmbAPILng.DropDownStyle    = ComboBoxStyle.DropDownList;

                    bInitCombo = true;
                }

                PnlTvDBLng.Visible = true;
            }

        }

        private void BtOK_Click(object sender, EventArgs e)
        {
            CParams.TV_ApiKey = TvDBAPI_KEY;
            CParams.TV_Langue = TvDBAPI_LNG;
            CParams.Save();

            Tc.Dispose();

            uC_TvDB1.TvDB_Lng = TvDBAPI_LNG;
            uC_TvDB1.SetTvDB_APIKey(TvDBAPI_KEY);

            PgViewCtrl.SelectedObject = uC_TvDB1;

            PnlGetAPIKey.Visible = false;
        }

        private void CmbAPILng_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bInitCombo)
            {
                Language SelValue = (Language)CmbAPILng.SelectedValue;
                if (SelValue != null)
                {
                    TvDBAPI_LNG = SelValue.abbreviation;
                }
            }
        }

        private bool GetTvDB_ApiKey ()
        {
            bool bResult = false;
            List<Language> Lngs = new List<Language>();

            return bResult;
        }
    }

    public class TComboLng
    {
        public string   Name    { get; set; }
        public Language Value   { get; set; }
    }

    public class TComboSel
    {
        public string   Name    { get; set; }
        public Int32    Value   { get; set; }
    }
}
