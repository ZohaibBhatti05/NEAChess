using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype8
{
    public partial class GamePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlAISettings.Visible = false;
        }

        // starts the game
        protected void btnStartGame_Click(object sender, EventArgs e)
        {
            pnlPreGame.Visible = false;
            //pnlDuringGame.Visible = true;
            //InitialiseGame();
        }






        #region AI Settings

        protected void radAgainstAI_CheckedChanged(object sender, EventArgs e)
        {
            if (radAgainstAI.Checked) // if checking the ai button, show :: else hide
            {
                pnlAISettings.Visible = true;

                // hide time settings

                //radNoTimers.Checked = true;
                //timeRadioButton_CheckChanged(sender, e);

                //radCustomTime.Hide();
                //radPresetTime.Hide();
            }
            else
            {
                pnlAISettings.Visible = false;
                //radCustomTime.Show();
                //radPresetTime.Show();
            }
        }

        // show value of ai ply depth in label
        protected void trackPlyDepth_ValueChanged(object sender, EventArgs e)
        {
            //lblPlyDepth.Text = trackPlyDepth.Value.ToString();
        }

        #endregion
    }
}