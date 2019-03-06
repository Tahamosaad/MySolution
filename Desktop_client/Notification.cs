using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_client
{
    public partial class Notification : Form
    {
      


        public Notification()
        {
            InitializeComponent();
             
            using (var client = new HttpClient())
            {
                DataModel lgn = new DataModel();
                
                
               //
                client.BaseAddress = new Uri("http://localhost:49632/");
                
                var response2 = client.GetAsync("api/login/getNotificationInfo").Result;
               
                string res = "";
                using (HttpContent content = response2.Content)
                {
                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                }
                if (res.ToString().Trim() == "0")
                {
                    lblnotMessage.Text = "No Notifications";
                    
                }
                else
                {
                    res = res.TrimStart('[').TrimEnd(']');
                    DataModel ntf = JsonConvert.DeserializeObject<DataModel>(res);//parsing json response

                    lblnotMessage.Text = ntf.title;
                    label1.Text = ntf.Message;
                    lblnotMessage.ForeColor = Color.Red;
              
                    
                }
                //
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
            Login obj = new Login();
            obj.Show();
        }
    }
}
