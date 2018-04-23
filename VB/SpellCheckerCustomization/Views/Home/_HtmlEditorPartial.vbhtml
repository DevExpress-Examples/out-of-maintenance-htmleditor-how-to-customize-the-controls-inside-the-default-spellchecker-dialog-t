@Imports SpellCheckerCustomization.Controllers

@Code
    Dim settings = New HtmlEditorSettings()
	settings.Name = "HtmlEditor"
	settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "HtmlEditorPartial"}
	settings.Width = 500
	settings.ToolbarMode = HtmlEditorToolbarMode.Menu

	settings.SettingsDialogs.InsertImageDialog.SettingsImageUpload.UploadCallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "HtmlEditorPartialImageUpload"}
	settings.SettingsDialogs.InsertImageDialog.SettingsImageUpload.UploadFolder = HomeControllerHtmlEditorSettings.ImageUploadDirectory
	settings.SettingsDialogs.InsertImageDialog.SettingsImageUpload.ValidationSettings.Assign(HomeControllerHtmlEditorSettings.ImageUploadValidationSettings)
	settings.Toolbars.CreateDefaultToolbars()
	settings.Toolbars(0).Items.Add(New ToolbarCheckSpellingButton(True))
	settings.SettingsSpellChecker.Culture = New System.Globalization.CultureInfo("en-us")
    Dim dictionary As New DevExpress.Web.ASPxSpellChecker.ASPxSpellCheckerISpellDictionary()
	dictionary.AlphabetPath = "~/Dictionaries/EnglishAlphabet.txt"
	dictionary.GrammarPath = "~/Dictionaries/english.aff"
	dictionary.DictionaryPath = "~/Dictionaries/american.xlg"
	dictionary.CacheKey = "ispellDic"
	dictionary.Culture = New System.Globalization.CultureInfo("en-us")
	dictionary.EncodingName = "Western European (Windows)"
	settings.SettingsSpellChecker.Dictionaries.Add(dictionary)

	settings.SettingsDialogs.InsertImageDialog.SettingsImageSelector.Assign(HomeControllerHtmlEditorSettings.ImageSelectorSettings)

    Dim extension = New SpellCheckerCustomization.Models.MyHtmlEditorExtension(settings, ViewContext)
End Code
@extension.GetHtml()