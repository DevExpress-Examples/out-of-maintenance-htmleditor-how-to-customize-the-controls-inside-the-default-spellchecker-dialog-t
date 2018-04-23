using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxHtmlEditor.Internal;
using System.Web.UI;
using DevExpress.Web.ASPxSpellChecker.Forms;
using DevExpress.Web;
using DevExpress.Web.Mvc.UI;
using System.Web.Mvc;

namespace SpellCheckerCustomization.Models {
    public class MyHtmlEditorExtension : HtmlEditorExtension {
        public MyHtmlEditorExtension(HtmlEditorSettings settings, ViewContext ctx)
            : base(settings, ctx) {
        }
        protected override ASPxWebControl CreateControl() {
            return new MVCxHtmlEditor();
        }
    }
    public class MVCxHtmlEditor : DevExpress.Web.Mvc.MVCxHtmlEditor {
        protected override DevExpress.Web.ASPxHtmlEditor.Internal.HtmlEditorSpellChecker CreateSpellCheckerInstance() {
            MVCxHtmlEditorSpellChecker check = new MVCxHtmlEditorSpellChecker(this);
            return check;
        }
    }

    class MVCxHtmlEditorSpellChecker : DevExpress.Web.Mvc.MVCxHtmlEditorSpellChecker {
        public MVCxHtmlEditorSpellChecker(DevExpress.Web.Mvc.MVCxHtmlEditor htmlEditor) : base(htmlEditor) { }
        protected override Control CreateSpellCheckForm() {
            return new SpellCheckForm();
        }
    }

    class SpellCheckForm : DevExpress.Web.ASPxSpellChecker.Forms.SpellCheckForm {
        protected override void PrepareChildControls() {
            base.PrepareChildControls();
            // Customize controls here
            this.btnIgnore.ControlStyle.CssClass = "btn-custom";
            this.btnAddToDictionary.Text = "Add";
        }
    }
}