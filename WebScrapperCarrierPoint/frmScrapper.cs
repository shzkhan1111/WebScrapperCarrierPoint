using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;


namespace WebScrapperCarrierPoint
{
    public partial class frmScrapper : Form
    {
        public frmScrapper()
        {
            InitializeComponent();
        }

        private void frmScrapper_Load(object sender, EventArgs e)
        {
            LoadConfigurations();
        }

        private void SaveConfigurations()
        {
            var config = new ScraperConfig
            {
                MinWeight = Convert.ToInt32(txtMinWeight.Text),
                MaxWeight = Convert.ToInt32(txtMaxWeight.Text),
                MinLength = Convert.ToInt32(txtMinLength.Text),
                MaxLength = Convert.ToInt32(txtMaxLength.Text),
                DeliveryDateOffset = Convert.ToInt32(txtDeliveryDate.Text),
                MinMileage = Convert.ToInt32(txtMinMileage.Text),
                MaxMileage = Convert.ToInt32(txtMaxMileage.Text),

                OriginCity = txtOriginCity.Text,
                OriginState = txtOriginState.Text,
                DestinationCity = txtDestinationCity. Text,
                DestinationState = txtDestinationState.Text,

                
            };

            var configJson = Newtonsoft.Json.JsonConvert.SerializeObject(config);
            File.WriteAllText("config.json", configJson);
            //MessageBox.Show("Configurations saved successfully!");
        }

        private void LoadConfigurations()
        {
            if (File.Exists("config.json"))
            {
                var configJson = File.ReadAllText("config.json");
                var config = Newtonsoft.Json.JsonConvert.DeserializeObject<ScraperConfig>(configJson);

                txtMinWeight.Text = config.MinWeight.ToString();
                txtMaxWeight.Text = config.MaxWeight.ToString();
                txtMinLength.Text = config.MinLength.ToString();
                txtMaxLength.Text = config.MaxLength.ToString();
                txtDeliveryDate.Text = config.DeliveryDateOffset.ToString();
                txtMinMileage.Text = config.MinMileage.ToString();
                txtMaxMileage.Text = config.MaxMileage.ToString(); 
                txtOriginCity.Text = config.OriginCity;
                txtOriginState. Text = config.OriginState; 
                txtDestinationCity.Text = config.DestinationCity;
                txtDestinationState.Text = config.DestinationState;
                string clientUrl = ConfigurationManager.AppSettings["clientUrl"];
                string clientId = ConfigurationManager.AppSettings["clientId"];
                string clientSecret = ConfigurationManager.AppSettings["clientSecret"];


                string customerId = ConfigurationManager.AppSettings["customerclientId"];
                string customerSecret = ConfigurationManager.AppSettings["customerclientSecret"];

                lblClientURL.Text = clientUrl;
                lblClientId.Text = clientId;
                lblClientSecret.Text = clientSecret;
                lblCustomerId.Text = customerId;
                lblCustomerSecret.Text = customerSecret;
               // MessageBox.Show("Configurations loaded successfully!");
            }
            else
            {
                MessageBox.Show("No configuration file found.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;    
            SaveConfigurations();
            btnSave.Enabled = true;
        }
    }
}
