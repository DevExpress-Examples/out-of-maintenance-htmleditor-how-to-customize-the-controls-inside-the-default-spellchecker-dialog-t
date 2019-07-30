<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/SpellCheckerCustomization/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/SpellCheckerCustomization/Controllers/HomeController.vb))
* [MyHtmlEditorExtension.cs](./CS/SpellCheckerCustomization/Models/MyHtmlEditorExtension.cs) (VB: [MyHtmlEditorExtension.vb](./VB/SpellCheckerCustomization/Models/MyHtmlEditorExtension.vb))
* [_HtmlEditorPartial.cshtml](./CS/SpellCheckerCustomization/Views/Home/_HtmlEditorPartial.cshtml)
* [Index.cshtml](./CS/SpellCheckerCustomization/Views/Home/Index.cshtml)
* [_Layout.cshtml](./CS/SpellCheckerCustomization/Views/Shared/_Layout.cshtml)
<!-- default file list end -->
# HtmlEditor - How to customize the controls inside the default SpellChecker dialog
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t493023/)**
<!-- run online end -->


<p>In the HtmlEditor extension, you can customize spell checking, add new dictionaries, change the spell checker form caption, but further customizations are not possible. This example demonstrates how to create a SpellCheckerForm class descendant to access and customize controls on the form.<br><br>Note that in this scenario, you'll need to create MVXcHtmlEditor and HtmlEditorExtension descendants. An MVXcHtmlEditor class descendant should have the same class name as the MVXcHtmlEditor class due to the specifics of the theming mechanism. </p>


```cs
public class MyHtmlEditorExtension : HtmlEditorExtension {
    public MyHtmlEditorExtension(HtmlEditorSettings settings, ViewContext ctx)
        : base(settings, ctx) {
    }
    protected override ASPxWebControl CreateControl() {
        return new MVCxHtmlEditor();
    }
}

```


<p> </p>
<p>A custom spell checker can be specified in the CreateSpellCheckerInstance method of the MVCxHtmlEditor class:</p>


```cs
public class MVCxHtmlEditor : DevExpress.Web.Mvc.MVCxHtmlEditor {
    protected override DevExpress.Web.ASPxHtmlEditor.Internal.HtmlEditorSpellChecker CreateSpellCheckerInstance() {
        MVCxHtmlEditorSpellChecker check = new MVCxHtmlEditorSpellChecker(this);
        return check;
    }
}

```


<p> </p>
<p>A custom spell checker class should inherit MVCxHtmlEditorSpellChecker for MVC controls (in WebForms, the HtmlEditorSpellChecker class is used):</p>


```cs
class MVCxHtmlEditorSpellChecker : DevExpress.Web.Mvc.MVCxHtmlEditorSpellChecker {
    public MVCxHtmlEditorSpellChecker(DevExpress.Web.Mvc.MVCxHtmlEditor htmlEditor) : base(htmlEditor) { }
    ...
}
 

```


<p> </p>
<p>The MVCxHtmlEditorSpellChecker class provides several methods for creating its dialog forms. You can override any of these methods and provide your custom dialog instance:</p>


```cs
protected override Control CreateSpellCheckForm() {
    return new SpellCheckForm();
}

```


<p> </p>
<p>Each dialog class has the PrepareChildControls method that you can override to customize the controls that reside within the dialog. Make sure you invoke the PrepareChildControls method of the base class in order to create default controls:</p>


```cs
class SpellCheckForm : DevExpress.Web.ASPxSpellChecker.Forms.SpellCheckForm {
    protected override void PrepareChildControls() {
        base.PrepareChildControls();
        // Customize controls here
        this.btnIgnore.ControlStyle.CssClass = "btn-custom";
        this.btnAddToDictionary.Text = "Add";
    }
}

```


<p> </p>
<p>In the code snippet above, I assigned a class to the "Ignore One" button, so you can apply styles to it without using the button's id in custom CSS rules. The this.btnAddToDictionary.Text code changes the text of the "Add to Dictionary" button.<br><br>The extension descendant constructor accepts the HtmlEditorSettings instance and the ViewContext property of a View.</p>

<br/>


