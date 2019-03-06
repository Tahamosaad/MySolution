using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Notification_API.Controllers
{
    public class LoginController : ApiController
    {
        Notification_DBEntities db = new Notification_DBEntities();
        SqlConnection con = new SqlConnection(GetConnectionStr());
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = null;

        [HttpGet]
        [ActionName("getCustomerInfo")]
        public DataTable Get()
        {//Get All CustomerInfo 
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tbl_Cust";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                adp = new SqlDataAdapter(cmd);
                dt.TableName = "tbl_Cust";
                adp.Fill(dt);
                con.Close();
               
            }
            catch
            {

            }
            //string JSONString = string.Empty;
            //JSONString = JsonConvert.SerializeObject(dt);
            //return JSONString;
            return dt;

        }
        [HttpPost]       
        public DataTable Notification([FromBody] Login lgn)
        {//Get All NotificationInfo 
            DataTable dt = new DataTable();
            string user = lgn.UserName ;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Message, Title, UserName FROM Notification N INNER JOIN Table2 T ON N.Id = T.not_id INNER JOIN dbo.tbl_cust ON T.userid = dbo.tbl_cust.id where UserName = '"+user+"'";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                adp = new SqlDataAdapter(cmd);
                dt.TableName = "Notifications";
                adp.Fill(dt);
                con.Close();

            }
            catch
            {

            }
            //string JSONString = string.Empty;
            //JSONString = JsonConvert.SerializeObject(dt);
            return dt;
        }
        [HttpPost]
        public int Login([FromBody] Login lgn)
        {
            int ret = 0;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT count(*) FROM tbl_Cust WHERE UserName ='" + lgn.UserName.Trim() + "' and Password=" + lgn.Password.Trim();
                cmd.Connection = con;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                ret = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch
            {
            }
            return ret;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Notification _member)
        {
            try
            {
                //To add an new notification record  
                db.Notification.Add(_member);

                //Save the submitted record  
                db.SaveChanges();

                //return response status as successfully created with member entity  
                var msg = Request.CreateResponse(HttpStatusCode.Created, _member);

                //Response message with requesturi for check purpose  
                msg.Headers.Location = new Uri(Request.RequestUri + _member.Id.ToString());

                return msg;
            }
            catch (Exception ex)
            {

                //return response as bad request  with exception message.  
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public static string GetConnectionStr()
        {
            string cs = ConfigurationManager.ConnectionStrings["Notification_DBEntities"].ConnectionString;
            EntityConnectionStringBuilder conn = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["Notification_DBEntities"].ConnectionString);
            
            return conn.ProviderConnectionString;
        }
    }
}
