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
    [WebService(Namespace = "http://adresat.org/")]
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
        public string kerkoAdrese(string Lloji, string P1, string P2, string P3)
        {
            string dalja = "";
            DataSet ds = new DataSet();


            
            if (Lloji == "Individ")
            {
                string emri ="";
                string mbiemri ="";
                try
                {
                    emri = P1.Substring(0, P1.IndexOf(" "));
                    mbiemri = P1.Substring(P1.IndexOf(" "));
                }
                catch(Exception)
                {
                    emri = P1;
                }
                ds = objRegjistriCivil.lexoRegjistringCivilQuery(emri,mbiemri,P2,P3);
            }
            else if (Lloji == "Biznes")
            {
                ds = objArbk.lexoArbkQuery(P1, P2, P3);

            }
            else if (Lloji == "Institucion")
            {
                ds = objInstitucionet.lexoInstitucionetQuery(P1, P2, P3);
            }

          
            if (ds.Tables[0].Rows.Count == 0)
            {
                dalja = "0";
            }
            else if (ds.Tables[0].Rows.Count == 1)
            {
                dalja = "1"+ds.Tables[0].Rows[0][0];
            }
            else if (ds.Tables[0].Rows.Count > 5)
            {
                dalja = "6";
            }
            
          return dalja;

        }
    

        [WebMethod]
        public string ndryshoPassword(string Username, string Hash, string Salt)
        {
            try
            {
                objKonektimi.Open();
                string query = "Update tblUsers Set Hash='" + Hash + "', Salt='" + Salt + "' Where Username=" + Username;
                SqlCommand cmd = new SqlCommand(query, objKonektimi);
                cmd.ExecuteNonQuery();

                return "U ndryshua me sukses";

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
        public string lexoEmail(string Username)
        {
            try
            {
                objKonektimi.Open();
                string query = "Select Email from tblUsers Where Username=" + Username;
                SqlCommand cmd = new SqlCommand(query, objKonektimi);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    return dr[0].ToString();
                }
                else
                {
                    return "Error";
                }

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
        public string azhuroAdresen(string PerdoruesiID, string Lat, string Lng, string Numri)
        {
            try
            {
                objKonektimi.Open();
                string query = "Update tblAdresat Set Lat='" + Lat + "', Lng='" + Lng + "', Numri='" + Numri + "' Where PerdoruesiID=" + PerdoruesiID;
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
        public string lexoAdresen(string PerdoruesiID)
        {
            try
            {
                objKonektimi.Open();
                string query = "Select Lat,Lng,Numri from tblAdresat Where PerdoruesiID=" + PerdoruesiID;
                SqlCommand cmd = new SqlCommand(query, objKonektimi);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    return dr[0].ToString()+"Lng=>"+dr[1].ToString()+"Numri=>"+dr[2].ToString();
                }
                else
                {
                    return "Error";
                }

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
        public string validoRegjistrimin(string PerdoruesiID)
        {
            try
            {
                objKonektimi.Open();
                string query = "Select * from tblAdresat Where PerdoruesiID="+PerdoruesiID;
                SqlCommand cmd = new SqlCommand(query, objKonektimi);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    return "True";
                }
                else
                {
                    return "False";
                }

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
        public string shtoAdrese(string PerdoruesiID, string Lat, string Lng, string Numri)
        {
            try
            {
                objKonektimi.Open();
                string query = "Insert into tblAdresat (PerdoruesiID,Lat,Lng,Numri) VALUES('" + PerdoruesiID + "','" + Lat + "','" + Lng + "','" + trajtosqlinject(Numri) + "');";
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
            string dalja = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("http://nominatim.openstreetmap.org/reverse?format=xml&lat=" + lat + "&lon=" + lng + "&zoom=18&addressdetails=1");
            try
            {
                XmlNode Rruga = doc.SelectSingleNode("/reversegeocode/addressparts/road");
                dalja = Rruga.InnerText;
            }
            catch (Exception)
            {
                dalja = "";
                
            }
            try
            {
                XmlNode Qyteti = doc.SelectSingleNode("/reversegeocode/addressparts/city");
                dalja += "Qyteti=>" + Qyteti.InnerText;
            }
            catch (Exception)
            {
                try
                {
                    XmlNode Qyteti = doc.SelectSingleNode("/reversegeocode/addressparts/county");
                    dalja += "Qyteti=>" + Qyteti.InnerText;
                }
                catch (Exception)
                {

                    dalja += "Qyteti=>";
                }
                
                
            }
            try
            {
                XmlNode Kodi = doc.SelectSingleNode("/reversegeocode/addressparts/postcode");
                dalja+="Kodi=>"+Kodi.InnerText;
            }
            catch (Exception)
            {
                dalja+="Kodi=>";
            }
                       
            return dalja;
        }

        [WebMethod]
        public string ktheKordinatat(string Query)
        {
            Query= Query.Replace(" ","%20");
            XmlDocument doc = new XmlDocument();
            doc.Load("http://nominatim.openstreetmap.org/search?q=" + Query + "&format=xml&limit=1&addressdetails=1");
            XmlNode nod1 = doc.SelectSingleNode("/searchresults/place");
            try
            {
                XmlAttribute Latitude = nod1.Attributes["lat"];
                XmlAttribute Longitude = nod1.Attributes["lon"];

                return Latitude.InnerText + "Longitude=>" + Longitude.InnerText;
            }
            catch (Exception)
            {

                return "Error";
            }
            

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
