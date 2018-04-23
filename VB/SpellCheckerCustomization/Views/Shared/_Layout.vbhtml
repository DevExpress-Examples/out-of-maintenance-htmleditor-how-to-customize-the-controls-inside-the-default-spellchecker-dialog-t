<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <title>@ViewBag.Title</title>

    @Html.DevExpress().GetStyleSheets(New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.HtmlEditor}) 
    @Html.DevExpress().GetScripts(New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, New Script With {.ExtensionSuite = ExtensionSuite.Editors}, New Script With {.ExtensionSuite = ExtensionSuite.GridView}, New Script With {.ExtensionSuite = ExtensionSuite.HtmlEditor})
    <style type="text/css">
        .btn-custom {
            width: 100% !important;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            background-image: none !important;
            background-color: dimgray;
            color: white;
            font-size: larger;
        }

        .dxwscDlgContentSCFormContainer .dxbButtonHover_DevEx {
            background-color: red !important;
            background-image: none !important;
        }

       
    </style>

</head>

<body>
    @RenderBody()
</body>
</html>