using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net.Http;
using System.Xml;

namespace Adresat
{
    /// <summary>
    /// Summary description for Sherbimi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Sherbimi : System.Web.Services.WebService
    {

        [WebMethod]
        public string ktheAdresen(string lat, string lng)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://nominatim.openstreetmap.org/reverse?format=xml&lat=" + lat + "&lon=" + lng + "&addressdetails=1");
            XmlNode nod1 = doc.SelectSingleNode("/reversegeocode/result");
            return nod1.InnerText;
        }
    }
}
