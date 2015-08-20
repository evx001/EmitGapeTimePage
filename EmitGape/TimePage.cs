using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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
		public TimePage ()
		{
			Content = timeLabel;
		}
		//> TimePage

		//< OnAppearing
		protected override async void OnAppearing ()
		{
			base.OnAppearing ();
			timeLabel.Text = await RequestTimeAsync ();
		}
		//> OnAppearing

		//< RequestTimeAsync
		static async Task<string> RequestTimeAsync ()
		{
			using (var client = new HttpClient ()) {
				// http://openweathermap.org/

				var jsonString = await client.GetStringAsync ("http://openweathermap.org/");
				var jsonObject = JObject.Parse (jsonString);
				return (string)jsonObject; // ["time"].Value<string> ();
				var webView = new WebView ();
				var htmlWebViewSource = new HtmlWebViewSource ();
				htmlWebViewSource.Html = (string)jsonObject;
				webView.Source = htmlWebViewSource;
				WebView webview = webView;
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


