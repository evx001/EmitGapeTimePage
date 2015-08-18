using System;

using Xamarin.Forms;

namespace EmitGape
{

	public class App : Application
	{


		public App ()
		{

			// The root page of your application


			MainPage = new NavigationPage (new ContentPage {
				Content = new Button {
					Text = "What time is it?",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					Command = new Command (() => MainPage.Navigation.PushAsync (new TimePage ())),
				},
			});
		}


		//		public TimePage ()
		//		{
		//			ContentPage.Content = timeLabel;
		//
		//		}

		readonly Label timeLabel = new Label {
			Text = "Loading...",
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			VerticalOptions = LayoutOptions.CenterAndExpand,

		};


		


		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}



	}



}

