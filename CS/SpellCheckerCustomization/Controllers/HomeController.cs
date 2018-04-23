using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace SpellCheckerCustomization.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HtmlEditorPartial()
        {
            return PartialView("_HtmlEditorPartial");
        }
        public ActionResult HtmlEditorPartialImageSelectorUpload()
        {
            HtmlEditorExtension.SaveUploadedImage("HtmlEditor", HomeControllerHtmlEditorSettings.ImageSelectorSettings);
            return null;
        }
        public ActionResult HtmlEditorPartialImageUpload()
        {
            HtmlEditorExtension.SaveUploadedFile("HtmlEditor", HomeControllerHtmlEditorSettings.ImageUploadValidationSettings, HomeControllerHtmlEditorSettings.ImageUploadDirectory);
            return null;
        }
    }
    public class HomeControllerHtmlEditorSettings
    {
        public const string ImageUploadDirectory = "~/Content/UploadImages/";
        public const string ImageSelectorThumbnailDirectory = "~/Content/Thumb/";

        public static DevExpress.Web.UploadControlValidationSettings ImageUploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".png" },
            MaxFileSize = 4000000
        };

        static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings imageSelectorSettings;
        public static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings ImageSelectorSettings
        {
            get
            {
                if (imageSelectorSettings == null)
                {
                    imageSelectorSettings = new DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings(null);
                    imageSelectorSettings.Enabled = true;
                    imageSelectorSettings.UploadCallbackRouteValues = new { Controller = "Home", Action = "HtmlEditorPartialImageSelectorUpload" };
                    imageSelectorSettings.CommonSettings.RootFolder = ImageUploadDirectory;
                    imageSelectorSettings.CommonSettings.ThumbnailFolder = ImageSelectorThumbnailDirectory;
                    imageSelectorSettings.CommonSettings.AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif" };
                    imageSelectorSettings.UploadSettings.Enabled = true;
                }
                return imageSelectorSettings;
            }
        }
    }

}