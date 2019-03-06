using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Desktop_client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtUsername, "");
            errorProvider1.SetError(txtPassword, "");
            if (txtUsername.Text.ToString().Trim() != "" && txtPassword.Text.ToString().Trim() != "")
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:49632/");
                    DataModel lgn = new DataModel { UserName = txtUsername.Text.ToString(), Password = txtPassword.Text.ToString() };
                    HttpResponseMessage response = client.PostAsJsonAsync("api/Login/Login", lgn).Result;
                    HttpResponseMessage response2 = client.PostAsJsonAsync("api/Login/Notification", lgn).Result;
                    var a = response.Content.ReadAsStringAsync();
                    var b = response2.Content.ReadAsStringAsync();

                    if (a.Result.ToString().Trim() == "0")
                    {
                        lblErrorMessage.Text = "Invalid login credentials.";
                        lblErrorMessage.ForeColor = Color.Red;
                       
                    }
                    else
                    {
                        
                        lblErrorMessage.Text = "Loggedin successfully.";
                        lblErrorMessage.ForeColor = Color.Green;
                       //string result2 = b.Result.ToString().TrimStart('[').TrimEnd(']');
                        List <DataModel> ntf = JsonConvert.DeserializeObject<List<DataModel>>(b.Result.ToString());
                        lblnotMessage.Text = ntf.Select(x=>x.title).FirstOrDefault().ToString();
                        label3.Text = ntf.Select(x => x.Message).FirstOrDefault().ToString();
                        lblnotMessage.ForeColor = Color.Red;
                        this.groupBox1.Hide();
                        groupBox2.Show();
                        
                    }
                }
            }
            else if (txtUsername.Text.ToString().Trim() == "" && txtPassword.Text.ToString().Trim() == "")
            {
                errorProvider1.SetError(txtUsername, "Please enter the email");
                errorProvider1.SetError(txtPassword, "Please enter the password");
            }
            else if (txtUsername.Text.ToString().Trim() == "")
            {
                errorProvider1.SetError(txtUsername, "Please enter the email");
            }
            else if (txtPassword.Text.ToString().Trim() == "")
            {
                errorProvider1.SetError(txtPassword, "Please enter the password");
            }
        }
      
       
        
        private void ValidateEmail()
        {
            Regex regEmail = new Regex(@"^(([^<>()[\]\\.,;:\s@\""]+"
                                    + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                    + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                    + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                    + @"[a-zA-Z]{2,}))$",
                                    RegexOptions.Compiled);

            if (!regEmail.IsMatch(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Please enter a Valid Email Address.");
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox1.Show();
        }
    }
}
