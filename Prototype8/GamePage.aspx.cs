using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Prototype8
{
    public partial class GamePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlDuringGame.Visible = false;
            pnlAISettings.Visible = false;
            pnlCustomTime.Visible = false;
            cmbTimeSettings.Visible = false;
            textFEN.Visible = false;
            radAgainstAI_CheckedChanged(sender, e);
        }

        // starts the game
        protected void btnStartGame_Click(object sender, EventArgs e)
        {
            pnlPreGame.Visible = false;
            pnlDuringGame.Visible = true;
            //pnlDuringGame.Visible = true;
            //InitialiseGame();
        }


        #region AI Settings

        protected void radAgainstAI_CheckedChanged(object sender, EventArgs e)
        {
            if (radAgainstAI.Checked) // if checking the ai button,.Visible = true :: else.Visible = false
            {
                pnlAISettings.Visible = true;

                //hide time settings

                radNoTimers.Checked = true;
                radPresetTime.Checked = false;
                radCustomTime.Checked = false;

                radCustomTime.Visible = false;
                radPresetTime.Visible = false;
            }
            else
            {
                pnlAISettings.Visible = false;
                radCustomTime.Visible = true;
                radPresetTime.Visible = true;
            }
            timeRadioButton_CheckChanged(sender, e);
            radDefaultPosition_CheckedChanged(sender, e);
        }

        #endregion

        #region Time Settings

        //hide relevant controls for time settings
        protected void timeRadioButton_CheckChanged(object sender, EventArgs e)
        {
            if (radPresetTime.Checked)
            {
                pnlCustomTime.Visible = false;
                cmbTimeSettings.Visible = true;
            }
            else if (radCustomTime.Checked)
            {
                pnlCustomTime.Visible = true;
                cmbTimeSettings.Visible = false;
            }
            else
            {
                pnlCustomTime.Visible = false;
                cmbTimeSettings.Visible = false;
            }
        }

        // if input not a number, dont accept
        protected void customTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            foreach(char c in ((System.Web.UI.WebControls.TextBox)sender).Text)
            {
                if (!int.TryParse(c.ToString(), out int i))
                {
                    ((System.Web.UI.WebControls.TextBox)sender).Text = string.Empty;
                    pnlCustomTime.Visible = true;
                    return;
                }
            }
            pnlCustomTime.Visible = true;
        }
        #endregion

        #region Position

        protected void radDefaultPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (radDefaultPosition.Checked)
            {
                textFEN.Visible = false;
            }
            else
            {
                textFEN.Visible = true;
            }
        }

        #endregion

        #region Variants

        protected void cmbVariant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVariant.SelectedIndex == 1) // disallow custom positions in ficherrandom
            {
                radDefaultPosition.Checked = true;
                radCustomPosition.Checked = false;
                radAgainstAI_CheckedChanged(sender, e);
            }
        }

        #endregion
    }
}