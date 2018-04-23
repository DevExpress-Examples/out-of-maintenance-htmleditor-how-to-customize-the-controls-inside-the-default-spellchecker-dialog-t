Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc

Namespace SpellCheckerCustomization.Controllers
	Public Class HomeController
		Inherits Controller

		' GET: Home
		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function HtmlEditorPartial() As ActionResult
			Return PartialView("_HtmlEditorPartial")
		End Function
		Public Function HtmlEditorPartialImageSelectorUpload() As ActionResult
			HtmlEditorExtension.SaveUploadedImage("HtmlEditor", HomeControllerHtmlEditorSettings.ImageSelectorSettings)
			Return Nothing
		End Function
		Public Function HtmlEditorPartialImageUpload() As ActionResult
			HtmlEditorExtension.SaveUploadedFile("HtmlEditor", HomeControllerHtmlEditorSettings.ImageUploadValidationSettings, HomeControllerHtmlEditorSettings.ImageUploadDirectory)
			Return Nothing
		End Function
	End Class
	Public Class HomeControllerHtmlEditorSettings
		Public Const ImageUploadDirectory As String = "~/Content/UploadImages/"
		Public Const ImageSelectorThumbnailDirectory As String = "~/Content/Thumb/"

		Public Shared ImageUploadValidationSettings As New DevExpress.Web.UploadControlValidationSettings() With {.AllowedFileExtensions = New String() { ".jpg", ".jpeg", ".jpe", ".gif", ".png" }, .MaxFileSize = 4000000}

'INSTANT VB NOTE: The variable imageSelectorSettings was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private Shared imageSelectorSettings_Renamed As DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings
		Public Shared ReadOnly Property ImageSelectorSettings() As DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings
			Get
				If imageSelectorSettings_Renamed Is Nothing Then
					imageSelectorSettings_Renamed = New DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings(Nothing)
					imageSelectorSettings_Renamed.Enabled = True
					imageSelectorSettings_Renamed.UploadCallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "HtmlEditorPartialImageSelectorUpload"}
					imageSelectorSettings_Renamed.CommonSettings.RootFolder = ImageUploadDirectory
					imageSelectorSettings_Renamed.CommonSettings.ThumbnailFolder = ImageSelectorThumbnailDirectory
					imageSelectorSettings_Renamed.CommonSettings.AllowedFileExtensions = New String() { ".jpg", ".jpeg", ".jpe", ".gif" }
					imageSelectorSettings_Renamed.UploadSettings.Enabled = True
				End If
				Return imageSelectorSettings_Renamed
			End Get
		End Property
	End Class

End Namespace