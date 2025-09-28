using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace trial
{
    public partial class opportunity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ShowDivsWithClass("pic pic2");
            ShowDivsWithClass("pic");
            
        }
        protected void com_Click(object sender, EventArgs e)
        {
            ShowDivsWithClass("pic pic2");
            HideDivsWithClass("pic");
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            ShowDivsWithClass("pic");
            HideDivsWithClass("pic pic2");
        }
        private void HideDivsWithClass(string className)
        {
            foreach (Control control in Page.Controls)
            {
                HideDivsWithClassRecursive(control, className);
            }
        }

        private void HideDivsWithClassRecursive(Control control, string className)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is HtmlGenericControl div && div.Attributes["class"] == className)
                {
                    div.Visible = false;
                }

                if (childControl.Controls.Count > 0)
                {
                    HideDivsWithClassRecursive(childControl, className);
                }
            }
        }

        private void ShowDivsWithClass(string className)
        {
            foreach (Control control in Page.Controls)
            {
                ShowDivsWithClassRecursive(control, className);
            }
        }

        private void ShowDivsWithClassRecursive(Control control, string className)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is HtmlGenericControl div && div.Attributes["class"] == className)
                {
                    div.Visible = true;
                }

                if (childControl.Controls.Count > 0)
                {
                    ShowDivsWithClassRecursive(childControl, className);
                }
            }
        }
    }
}