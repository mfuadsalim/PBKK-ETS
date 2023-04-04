using Newtonsoft.Json;
using System.Net;
namespace WeatherApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String APIKey = "1bf18b8b977d323d335a0ee27df4e589";
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            getWeather();
        }
        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", textBoxKota.Text, APIKey);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].Icon + ".png";
                labelCondition.Text = Info.weather[0].main;
                labelDetails.Text = Info.weather[0].description;
                labelSunset.Text = Info.sys.sunset.ToString();
                labelSunrise.Text = Info.sys.sunrise.ToString();

                labelWindspeed.Text = Info.wind.speed.ToString();
                labelPressure.Text = Info.main.pressure.ToString();
            }
        }

        private void textBoxKota_TextChanged(object sender, EventArgs e)
        {

        }
    }
}