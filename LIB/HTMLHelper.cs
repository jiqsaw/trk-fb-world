using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace LIB {
    public sealed class HTMLHelper {

        //��inde Literal Olan Cell D�nd�r�r
        public static TableCell GetTdLiteral(string Text, string Align) {
            return GetTdLiteral(Text, Align, "");
        }

        //��inde Literal Olan Cell D�nd�r�r
        public static TableCell GetTdLiteral(string Text) {
            return GetTdLiteral(Text, "", "");
        }

        //��inde Literal Olan Cell D�nd�r�r
        public static TableCell GetTdLiteral(string Text, string Align, string Width) {
            TableCell gCell = new TableCell();
            Literal ltl = new Literal();
            ltl.Text = Text;

            if (Align != "") {
                gCell.Style.Add("text-align", Align);
            }

            if (Width != "") {
                gCell.Style.Add("width", Width);
            }

            gCell.Controls.Add(ltl);
            return gCell;
        }

    }
}
