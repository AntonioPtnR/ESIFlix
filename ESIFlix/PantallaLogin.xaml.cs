using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ESIFlix
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PantallaLogin : Page
    {
        List<Object> listMain = new List<Object>();
        List<Boolean> listaLikes = new List<Boolean>();
        List<Boolean> listaVistas = new List<Boolean>();
        string nombreuser = "\n";

        public PantallaLogin()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Bienvenido a ESIFlix",
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },

                    new AdaptiveText()
                    {
                        Text = "App para ver películas",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = "Ingresa dentro de la app para ver películas",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
                        }
                    },


                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Bienvenido a ESIFlix",
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },

                    new AdaptiveText()
                    {
                        Text = "App para ver películas",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = "Prueba la app para ver películas de nuestro catálogo",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
                        }
                    },

                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Bienvenido a ESIFlix ",
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },

                    new AdaptiveText()
                    {
                        Text = "App para ver películas online",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = "Prueba la app si quieres ver películas online",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
                        }
                    },
                }
            };


        }

        private void entrar(object sender, RoutedEventArgs e)
        {

            if (!nombreuser.Equals(tbNombreUsuario.Text))
            {
                listaVistas.Clear();
                listaLikes.Clear();
                for (int i = 0; i < 17; i++)
                {
                    listaVistas.Add(false);
                    listaLikes.Add(false);
                }
            }
            listMain.Clear();
            listMain.Add(tbNombreUsuario.Text.ToString());
            listMain.Add(listaLikes);
            listMain.Add(listaVistas);

            this.Frame.Navigate(typeof(MainPage), listMain);


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Object> lista = new List<object>();
            if (e.Parameter != null && !e.Parameter.Equals(""))
            {
                lista = (List<object>)e.Parameter;
                if (lista[0] is string)
                    nombreuser = lista[0].ToString();
                listaLikes = (List<Boolean>)lista[1];
                listaVistas = (List<Boolean>)lista[2];
                base.OnNavigatedTo(e);
            }
            
        }
        

        //Mandar a tributos peliculas un boolean que se modifique en atributos pelicula y luego mandar ese boolean modificado a perfil.


    }
}
