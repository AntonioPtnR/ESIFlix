
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ESIFlix
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PerfilPage : Page
    {
        List<Object> pasarInfo = new List<object>();
        String nombrepelilike;
        String nombrepelivista;
        List<Boolean> listaLikes;
        List<Boolean> listaVistas;
        List<String> listaPelLike = new List<string>();
        List<String> listaPelVista = new List<string>();
        public PerfilPage()
        {
            this.InitializeComponent();
            
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            //SystemNavigationManager.GetForCurrentView().BackRequested += irAtras;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            //Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += PerfilPage_VisibleBoundsChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Object> lista = (List<Object>)e.Parameter;
            if (lista[0] is string && !string.IsNullOrWhiteSpace((string)lista[0]))
                tbPerfil.Text = lista[0].ToString();
            listaLikes = (List<Boolean>)lista[1];
            listaVistas = (List<Boolean>)lista[2];


            if (listaLikes[0] == true)
                listaPelLike.Add("Gladiator");
            if (listaVistas[0] == true)
                listaPelVista.Add("Gladiator");
            
            if (listaLikes[1] == true)
                listaPelLike.Add("Braveheart");
            if (listaVistas[1] == true)
                listaPelVista.Add("Braveheart");

            if (listaLikes[2] == true)
                listaPelLike.Add("Apocalypse now");
            if (listaVistas[2] == true)
                listaPelVista.Add("Apocalypse now");

            if (listaLikes[3] == true)
                listaPelLike.Add("Avatar");
            if (listaVistas[3] == true)
                listaPelVista.Add("Avatar");

            if (listaLikes[4] == true)
                listaPelLike.Add("El mayordomo");
            if (listaVistas[4] == true)
                listaPelVista.Add("El mayordomo");

            if (listaLikes[5] == true)
                listaPelLike.Add("El rey leon");
            if (listaVistas[5] == true)
                listaPelVista.Add("El rey leon");

            if (listaLikes[6] == true)
                listaPelLike.Add("Forrest gump");
            if (listaVistas[6] == true)
                listaPelVista.Add("Forrest gump");
            
            if (listaLikes[7] == true)
                listaPelLike.Add("La lista de Schindler");
            if (listaVistas[7] == true)
                listaPelVista.Add("La lista de Schindler");

            if (listaLikes[8] == true)
                listaPelLike.Add("Pearl Harbor");
            if (listaVistas[8] == true)
                listaPelVista.Add("Pearl Harbor");

            if (listaLikes[9] == true)
                listaPelLike.Add("Pulp Fiction");
            if (listaVistas[9] == true)
                listaPelVista.Add("Pulp Fiction");

            if (listaLikes[10] == true)
                listaPelLike.Add("Salvar al soldado Ryan");
            if (listaVistas[10] == true)
                listaPelVista.Add("Salvar al soldado Ryan");

            if (listaLikes[11] == true)
                listaPelLike.Add("Senderos de Gloria");
            if (listaVistas[11] == true)
                listaPelVista.Add("Senderos de Gloria");

            if (listaLikes[12] == true)
                listaPelLike.Add("Shrek");
            if (listaVistas[12] == true)
                listaPelVista.Add("Shrek");

            if (listaLikes[13] == true)
                listaPelLike.Add("Titanic");
            if (listaVistas[13] == true)
                listaPelVista.Add("Titanic");

            if (listaLikes[14] == true)
                listaPelLike.Add("el senor de los anillos");
            if (listaVistas[14] == true)
                listaPelVista.Add("el senor de los anillos");

            if (listaPelLike.Count > 0) 
            { 
                nombrepelilike = listaPelLike[0];
                imgFav1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/img" + listaPelLike[0] + ".jpg"));
            }
            if (listaPelVista.Count > 0)
            {
                nombrepelivista = listaPelVista[0];
                imgVista1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/img" + listaPelVista[0] + ".jpg"));
            }

            if (listaPelLike.Count > 1)
            {
                nombrepelilike = listaPelLike[1];
                imgFav2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/img" + listaPelLike[1] + ".jpg"));
            }
            if (listaPelVista.Count > 1)
            {
                nombrepelivista = listaPelVista[1];
                imgVista2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/img" + listaPelVista[1] + ".jpg"));
            }

            if (listaPelLike.Count > 2) {
                nombrepelilike = listaPelLike[2];
                imgFav3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/img" + listaPelLike[2] + ".jpg"));
            }
            if (listaPelVista.Count > 2)
            {
                nombrepelivista = listaPelVista[2];
                imgVista3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/img" + listaPelVista[2] + ".jpg"));
            }


            if (listaPelLike.Count > 3) {
                nombrepelilike = listaPelLike[3];
                imgFav4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/img" + listaPelLike[3] + ".jpg"));
            }

            if (listaPelLike.Count > 4)
            {
                nombrepelilike = listaPelLike[4];
                imgFav5.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/img" + listaPelLike[4] + ".jpg"));
            }

            if (listaPelLike.Count > 5)
            {
                nombrepelilike = listaPelLike[5];
                imgFav6.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/img" + listaPelLike[5] + ".jpg"));
            }


            base.OnNavigatedTo(e);

        }

        
       
        

        private void pasarRatonPopulares(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            tbVistas.Foreground = redBrush;


        }

        private void pasarRatonPopularesFin(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush whiteBrush = new SolidColorBrush(Windows.UI.Colors.White);
            tbVistas.Foreground = whiteBrush;
        }

        private void minimizarPopulares(object sender, PointerRoutedEventArgs e)
        {
            if (gvVistas.Visibility == Visibility.Visible)
                gvVistas.Visibility = Visibility.Collapsed;
            else
                gvVistas.Visibility = Visibility.Visible;
        }







        private void pasarRatonAccion(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            tbFavoritas.Foreground = redBrush;
        }

        private void pasarRatonAccionFin(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush whiteBrush = new SolidColorBrush(Windows.UI.Colors.White);
            tbFavoritas.Foreground = whiteBrush;
        }

        private void minimizarAccion(object sender, PointerRoutedEventArgs e)
        {
            if (gvFavoritas.Visibility == Visibility.Visible)
                gvFavoritas.Visibility = Visibility.Collapsed;
            else
                gvFavoritas.Visibility = Visibility.Visible;
        }




        private void Pulsar_fav1(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelLike[0].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
           
        }

        private void Pulsar_fav2(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelLike[1].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_fav3(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelLike[2].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_fav4(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelLike[3].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_fav5(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelLike[4].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_fav6(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelLike[5].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_vista1(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelVista[0].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_vista2(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelVista[1].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_vista3(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelVista[2].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_vista4(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelVista[3].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_vista5(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelVista[4].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }

        private void Pulsar_vista6(object sender, PointerRoutedEventArgs e)
        {
            String nombre = listaPelVista[5].ToString().ToLower();
            pasarInfo.Clear();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            this.Frame.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }
    }
}