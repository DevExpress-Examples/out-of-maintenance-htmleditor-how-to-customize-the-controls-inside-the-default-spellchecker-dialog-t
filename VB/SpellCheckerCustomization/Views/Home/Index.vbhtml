@Code
    ViewBag.Title = "Index"
End Code

<h2>How to customize the hover style of of buttons in the SpellChecker dialog</h2>
<blockquote cite="https://documentation.devexpress.com/#InterfaceElementsWeb/CustomDocument5360">
    <p>
        Invoke the spell checker dialog by clicking the "Check Spelling" toolbar item (<img src="~/Content/Images/SpellCheck.png" alt="Check Spelling" />). 
        <br />
        There we've customized the "Ignore Once" button's styles and changed the "Add to Dictionary" button text to "Add".
    </p>
     
</blockquote>

@Using Html.BeginForm()
	@Html.Action("HtmlEditorPartial")
End Using
