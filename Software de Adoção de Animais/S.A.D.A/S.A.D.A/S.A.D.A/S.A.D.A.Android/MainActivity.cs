using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace S.A.D.A.Droid
{
	[Activity (Label = "S.A.D.A", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{

        private EditText numero1, numero2;
        private Button btn01;
        private TextView resultado;


		protected override void OnCreate (Bundle bundle)
		{ 

			base.OnCreate (bundle);

            SetContentView(Resource.Layout.layout01);

            numero1 = FindViewById<EditText>(Resource.Id.Numero1);
            numero2 = FindViewById<EditText>(Resource.Id.Numero2);
            btn01 = FindViewById<Button>(Resource.Id.btn01);
            resultado = FindViewById<TextView>(Resource.Id.Resultado);


            btn01.Click += delegate
            {
                int num1 = int.Parse(numero1.Text);
                int num2 = int.Parse(numero2.Text);

                int resultNumerico = MyClass.Soma(num1, num2);
                
                    resultado.Text = "A soma dos valores é " + resultNumerico;

                
            };




        }
	}
}

