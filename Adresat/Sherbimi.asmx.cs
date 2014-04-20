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
        RegjistriCivil.SherbimiSoapClient objRegjistriCivil = new RegjistriCivil.SherbimiSoapClient();
        Arbk.Sherbimi_ArbkSoapClient objArbk = new Arbk.Sherbimi_ArbkSoapClient();
        Institucionet.Sherbimi_InstitucionetSoapClient objInstitucionet = new Institucionet.Sherbimi_InstitucionetSoapClient();

        [WebMethod]
        public string lexoInstitucionet(string NrInstitucionit)
        {
            return objInstitucionet.lexoInstitucionet(NrInstitucionit);
        }
        
        [WebMethod]
        public string lexoArbk(string NrBiznesit)
        {
            string dalja = "";
            string Arbk = objArbk.lexoArbk(NrBiznesit);
            if (Arbk != "")
            {
                int emriLength = Arbk.IndexOf("NrPersonal=>");
                string Emri = Arbk.Substring(0, emriLength);
                int nrLength = Arbk.IndexOf("Veprimtaria=>") - Arbk.IndexOf("NrPersonal=>") - 12;
                string NrPersonali = Arbk.Substring(Arbk.IndexOf("NrPersonal=>") + 12, nrLength);
                string Veprimtaria = Arbk.Substring(Arbk.IndexOf("Veprimtaria=>") + 13);
                string RegjistriCivil = objRegjistriCivil.lexoRegjistrinCivil(NrPersonali);
                if (RegjistriCivil != "")
                {
                    string Pronari = RegjistriCivil.Substring(0, RegjistriCivil.IndexOf("DataLindjes=>"));
                    dalja = Emri + "Pronari=>" + Pronari + "Veprimtaria=>" + Veprimtaria;
                }
            }
            return dalja;
        }
        
        [WebMethod]
        public string validoUsername(string Username, string Lloji)
        {
            string query = "Select Username From tblUsers Where Username='" + trajtosqlinject(Username) + "'";
             SqlCommand cmd = new SqlCommand(query, objKonektimi);
             string dalja="";
                try
                {
                    objKonektimi.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dalja = "True";
                    }
                    else
                    {
                        dalja = "False";
                    }
                }
           catch(Exception e)
                {
                dalja=e.Message;
                }
            finally
                {
                    objKonektimi.Close();
                }
            if (Lloji == "Individ")
            {
                dalja += objRegjistriCivil.validoNrPersonal(Username);
            }
            else if (Lloji == "Biznes")
            {
                dalja += objArbk.validoNrBiznesit(Username);
            }
            else if (Lloji == "Institucion")
            {
                dalja += objInstitucionet.validoNrInstitucionit(Username);
            }
            return dalja;
        }

        [WebMethod]
        public string lexoRegjistrinCivil(string NrPersonal)
        {

            return objRegjistriCivil.lexoRegjistrinCivil(NrPersonal);

        }

        [WebMethod]
        public string merrCred(string Username)
        {
            string dalja = "";
            string query = "Select Hash,Salt from tblUsers Where Username='" + trajtosqlinject(Username) + "'";
            SqlCommand cmd = new SqlCommand(query, objKonektimi);

            try
            {
                objKonektimi.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    dr.Read();
                    dalja = dr[0].ToString() + dr[1].ToString() + "OK"; ;
                }
                
            }
            catch (Exception ex)
            {

                dalja= ex.Message;
            }
            finally
            {
                objKonektimi.Close();
            }
            return dalja;

        }
        
        [WebMethod]
        public string shtoUser(string Username,string Hash,string Salt,string Email)
        {
            try
            {
                objKonektimi.Open();
                string query = "Insert into tblUsers (Username,Hash,Salt,Email) VALUES('"+trajtosqlinject(Username)+"','" + Hash + "','" + Salt + "','"+trajtosqlinject(Email)+"');";
                SqlCommand cmd = new SqlCommand(query, objKonektimi);
                cmd.ExecuteNonQuery();

                return "U insertua me sukses";

            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                objKonektimi.Close();
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

        private string trajtosqlinject(string s)
        {
            char[] vargu = s.ToCharArray();
            string stringu = "";
            for (int i = 0; i < vargu.Length; i++)
            {
                if (vargu[i].ToString() != "'" && vargu[i].ToString() != ";")
                {
                    stringu += vargu[i].ToString();
                }
            }
            return stringu;
        }

    
    }
}
