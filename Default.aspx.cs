using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using OneLogin.Saml;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AccountSettings accountSettings = new AccountSettings();

        AuthRequest req = new AuthRequest(new AppSettings(), accountSettings);

        UriBuilder uriBuilder = new UriBuilder(accountSettings.idp_sso_target_url);
        NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["SAMLRequest"] = Server.UrlEncode(req.GetRequest(AuthRequest.AuthRequestFormat.Base64));
        uriBuilder.Query = query.ToString();

        Response.Redirect(uriBuilder.ToString());
    }
}
