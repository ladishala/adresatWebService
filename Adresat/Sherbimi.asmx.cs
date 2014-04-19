using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net.Http;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Numerics;

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

        SqlConnection objKonektimi = new SqlConnection("server=localhost;user=Perdoruesi;database=dbAdresat;password=Ladi1234@;");


        [WebMethod]
        public string merrCred(string Username)
        {
            string dalja = "";
            string query = "Select Hash,Salt from tblUsers Where Username='" + Username+"'";
            SqlCommand cmd = new SqlCommand(query, objKonektimi);

            try
            {
                objKonektimi.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    dr.Read();
                    dalja = dr[0].ToString() + dr[1].ToString();
                }
                
            }
            catch (Exception ex)
            {

                dalja= ex.Message;
            }

            return dalja;

        }
        
        [WebMethod]
        public string shtoUser(string Username,string Hash,string Salt,string Email)
        {
            try
            {
                objKonektimi.Open();
                string salt = gjenerosalt();
                string query = "Insert into tblUsers (Username,Hash,Salt,Email) VALUES('"+Username+",'" + Hash + "','" + salt + "','"+Email+"');";
                SqlCommand cmd = new SqlCommand(query, objKonektimi);
                cmd.ExecuteNonQuery();

                return "U insertua me sukses";

            }
            catch (SqlException ex)
            {
                return ex.Message;
            }

        }
      
        
        [WebMethod]
        public string ktheAdresen(string lat, string lng)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://nominatim.openstreetmap.org/reverse?format=xml&lat=" + lat + "&lon=" + lng + "&addressdetails=1");
            XmlNode nod1 = doc.SelectSingleNode("/reversegeocode/result");
            return nod1.InnerText;
        }


        private string gjenerosalt()
        {
            Random objrandom = new Random();
            string rez = "";
            for (int i = 0; i < 4; i++)
            {
                int a = objrandom.Next(33, 125);
                rez += Convert.ToChar(a).ToString();
            }
            return rez;
        }

        private string gjejhash(string s)
        {
            HashAlgorithm Hasher = new SHA1CryptoServiceProvider();
            byte[] strBytes = Encoding.UTF8.GetBytes(s);
            byte[] strHash = Hasher.ComputeHash(strBytes);
            return BitConverter.ToString(strHash).Replace("-", "").ToLowerInvariant().Trim();
        }

    
    }
}
