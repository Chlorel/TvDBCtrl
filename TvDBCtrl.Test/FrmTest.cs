using System;
using System.Collections.Generic;
using System.Windows.Forms;

using TvDBCtrl;

namespace TestApp
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private async void FrmTest_Load(object sender, EventArgs e)
        {
            string  TvDBAPI_KEY     = "GXL7IKVKOHZ3DM8R";
            UC_TvDB Tc              = new UC_TvDB();
            

            // Check if the give APIKey is valid
            bool IsGood = await Tc.CheckTvDB_APIKey(TvDBAPI_KEY);

            if (IsGood)
            {
                Tc.Dispose();

                uC_TvDB1.TvDB_Lng               = "fr";
                uC_TvDB1.SetTvDB_APIKey(TvDBAPI_KEY);

                List<TComboSel> ViewType = new List<TComboSel>();
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
    }

    public class TComboSel
    {
        public string   Name    { get; set; }
        public Int32    Value   { get; set; }
    }
}
