
using System;
using System.Web.UI.WebControls;
using System.Text;
using System.Web;

namespace TinyMceEditor
{
    /// <summary>
    /// User control to edit online ditable content using tiny-mce. Extends TextBox class.
    /// </summary>
    public class OnlineEditor : TextBox
    {
        #region TextEditorMode enum

        public enum TextEditorMode
        {
            Simple,
            Full
        }

        #endregion

        private string _BlockFormats = "h1,h2,h3,p,div";
        private string _ContentCSS = "~/App_Themes/redmond/style.css";
        private string _ContentFileName;
        private string _ImagePath = "";
        private string _TinyMCEPath = "~/tiny_mce/tiny_mce.js";

        public override TextBoxMode TextMode
        {
            get { return TextBoxMode.MultiLine; }
        }

        public TextEditorMode Mode
        {
            get
            {
                Object obj = ViewState["Mode"];
                if (obj == null)
                {
                    return TextEditorMode.Simple;
                }
                return (TextEditorMode) obj;
            }
            set { ViewState["Mode"] = value; }
        }


        public static string ResolveUrl(string relativeUrl)
        {
            if (relativeUrl == null) throw new ArgumentNullException("relativeUrl");

            if (relativeUrl.Length == 0 || relativeUrl[0] == '/' || relativeUrl[0] == '\\')
                return relativeUrl;

            int idxOfScheme = relativeUrl.IndexOf(@"://", StringComparison.Ordinal);
            if (idxOfScheme != -1)
            {
                int idxOfQM = relativeUrl.IndexOf('?');
                if (idxOfQM == -1 || idxOfQM > idxOfScheme) return relativeUrl;
            }

            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append(HttpRuntime.AppDomainAppVirtualPath);
            if (sbUrl.Length == 0 || sbUrl[sbUrl.Length - 1] != '/') sbUrl.Append('/');

            // found question mark already? query string, do not touch!
            bool foundQM = false;
            bool foundSlash; // the latest char was a slash?
            if (relativeUrl.Length > 1
                && relativeUrl[0] == '~'
                && (relativeUrl[1] == '/' || relativeUrl[1] == '\\'))
            {
                relativeUrl = relativeUrl.Substring(2);
                foundSlash = true;
            }
            else foundSlash = false;
            foreach (char c in relativeUrl)
            {
                if (!foundQM)
                {
                    if (c == '?') foundQM = true;
                    else
                    {
                        if (c == '/' || c == '\\')
                        {
                            if (foundSlash) continue;
                            else
                            {
                                sbUrl.Append('/');
                                foundSlash = true;
                                continue;
                            }
                        }
                        else if (foundSlash) foundSlash = false;
                    }
                }
                sbUrl.Append(c);
            }

            return sbUrl.ToString();
        }

        protected override void OnPreRender(EventArgs e)
        {
            string tinyMceIncludeKey = "TinyMCEInclude";
            string tinyMceIncludeScript = "<script type=\"text/javascript\" src=\"" +
                                          ResolveUrl(_TinyMCEPath) + "\"></script>";


            if (!Page.ClientScript.IsStartupScriptRegistered(tinyMceIncludeKey))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), tinyMceIncludeKey, tinyMceIncludeScript);
            }

            if (!Page.ClientScript.IsStartupScriptRegistered(GetInitKey()))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), GetInitKey(), GetInitScript());
            }

            if (!CssClass.Contains(GetEditorClass()))
            {
                if (CssClass.Length > 0)
                {
                    CssClass += " ";
                }
                CssClass += GetEditorClass();
            }
            base.OnPreRender(e);
        }

        private string GetInitKey()
        {
            string simpleKey = "TinyMCESimple";
            string fullKey = "TinyMCEFull";

            switch (Mode)
            {
                case TextEditorMode.Simple:
                    return simpleKey;
                case TextEditorMode.Full:
                    return fullKey;
                default:
                    goto case TextEditorMode.Simple;
            }
        }

        private string GetEditorClass()
        {
            return GetEditorClass(Mode);
        }

        private string GetEditorClass(TextEditorMode mode)
        {
            string simpleClass = "SimpleTextEditor";
            string fullClass = "FullTextEditor";

            switch (mode)
            {
                case TextEditorMode.Simple:
                    return simpleClass;
                case TextEditorMode.Full:
                    return fullClass;
                default:
                    goto case TextEditorMode.Simple;
            }
        }

        private string GetInitScript()
        {
            _ImagePath = "~/UploadedImage/";

            string simpleScript =
                "<script type='text/javascript'>tinyMCE.init({mode : 'textareas', theme : 'advanced',skin : 'o2k7',skin_variant : 'silver', relative_urls: 'true', plugins : 'advimageNet,table,advhr,advlink,autosave,cleanup,contextmenu,directionality,emotions,flash,fullpage,fullscreen,inlinepopups,insertdatetime,layer,media,nonbreaking,noneditable,paste,preview,print,save,searchreplace,style,visualchars,xhtmlxtras,zoom', remove_linebreaks : 'false', theme_advanced_buttons1 : 'bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,formatselect,fontselect,fontsizeselect,|,code', theme_advanced_buttons2 : 'cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,|,insertdate,inserttime,preview,|,forecolor,backcolor ', theme_advanced_buttons3 : 'tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,advhr,|,print,|,ltr,rtl,|,fullscreen', theme_advanced_blockformats : '" +
                _BlockFormats +
                "', theme_advanced_toolbar_location : 'top', theme_advanced_toolbar_align : 'left', content_css : '" +
                ResolveUrl(_ContentCSS) + "', image_path : '" + ResolveUrl(_ImagePath) +
                "', external_image_list_url : '" + ResolveUrl(_TinyMCEPath) +
                "plugins/advImageNet/ImageList.ashx'});</script>";
            string fullScript =
                "<script language=\"javascript\" type=\"text/javascript\">tinyMCE.init({{mode : \"textareas\",theme : \"advanced\",editor_selector : \"{0}\"}});</script>";

            switch (Mode)
            {
                case TextEditorMode.Simple:
                    return simpleScript;
                case TextEditorMode.Full:
                    return string.Format(fullScript, GetEditorClass(TextEditorMode.Full));
                default:
                    goto case TextEditorMode.Simple;
            }
        }
    }
}