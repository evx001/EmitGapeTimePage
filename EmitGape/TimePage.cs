using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace EmitGape
{
    public class TimePage: ContentPage
    {
        //< timeLabel
        readonly Label timeLabel = new Label {
            Text = "Loading...",
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand,
        };
        //> timeLabel

        //< TimePage
        public TimePage()
        {
            Content = timeLabel;
        }
        //> TimePage

        //< OnAppearing
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            timeLabel.Text = await RequestTimeAsync();
        }
        //> OnAppearing

        //< RequestTimeAsync
        static async Task<string> RequestTimeAsync()
        {
            using (var client = new HttpClient()) {
                var jsonString = await client.GetStringAsync("http://date.jsontest.com/");
                var jsonObject = JObject.Parse(jsonString);
                return jsonObject["time"].Value<string>();
            }
        }
        //> RequestTimeAsync
    }
}


//	protected override async void OnAppearing()
//	{
//		base.OnAppearing();
//		timeLabel.Text = await RequestTimeAsync();
//	}

//	static async Task<string> RequestTimeAsync()
//	{
//		using (var client = new HttpClient()) {
//			var jsonString = await client.GetStringAsync("http://date.jsontest.com/");
//			var jsonObject = JObject.Parse(jsonString);
//			return jsonObject["time"].Value<string>();
//		}
//	}


