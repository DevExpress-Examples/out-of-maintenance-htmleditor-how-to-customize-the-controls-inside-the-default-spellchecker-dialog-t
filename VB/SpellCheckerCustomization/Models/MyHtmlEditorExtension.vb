Imports DevExpress.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.Web.ASPxHtmlEditor.Internal
Imports System.Web.UI
Imports DevExpress.Web.ASPxSpellChecker.Forms
Imports DevExpress.Web
Imports DevExpress.Web.Mvc.UI
Imports System.Web.Mvc

Namespace SpellCheckerCustomization.Models
	Public Class MyHtmlEditorExtension
		Inherits HtmlEditorExtension

		Public Sub New(ByVal settings As HtmlEditorSettings, ByVal ctx As ViewContext)
			MyBase.New(settings, ctx)
		End Sub
		Protected Overrides Function CreateControl() As ASPxWebControl
			Return New MVCxHtmlEditor()
		End Function
	End Class
	Public Class MVCxHtmlEditor
		Inherits DevExpress.Web.Mvc.MVCxHtmlEditor

		Protected Overrides Function CreateSpellCheckerInstance() As DevExpress.Web.ASPxHtmlEditor.Internal.HtmlEditorSpellChecker
			Dim check As New MVCxHtmlEditorSpellChecker(Me)
			Return check
		End Function
	End Class

	Friend Class MVCxHtmlEditorSpellChecker
		Inherits DevExpress.Web.Mvc.MVCxHtmlEditorSpellChecker

		Public Sub New(ByVal htmlEditor As DevExpress.Web.Mvc.MVCxHtmlEditor)
			MyBase.New(htmlEditor)
		End Sub
		Protected Overrides Function CreateSpellCheckForm() As Control
			Return New SpellCheckForm()
		End Function
	End Class

	Friend Class SpellCheckForm
		Inherits DevExpress.Web.ASPxSpellChecker.Forms.SpellCheckForm

		Protected Overrides Sub PrepareChildControls()
			MyBase.PrepareChildControls()
			' Customize controls here
			Me.btnIgnore.ControlStyle.CssClass = "btn-custom"
			Me.btnAddToDictionary.Text = "Add"
		End Sub
	End Class
End Namespace