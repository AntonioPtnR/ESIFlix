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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ESIFlix
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        String nombrepeli;
        List<Boolean> listaLikes = new List<Boolean>();
        List<Boolean> listaVistas = new List<Boolean>();
        List<Object> pasarInfo = new List<Object>();
        List<Object> lista = new List<object>();

        public MainPage()
        {
            
            this.InitializeComponent();
            svMenu.IsPaneOpen = false;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += irAtras;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
            tbAccion.Visibility = Visibility.Visible;
            tbBelicas.Visibility = Visibility.Visible;
            tbPopulares.Visibility = Visibility.Visible;
            gvAccion.Visibility = Visibility.Visible;
            gvBelicas.Visibility = Visibility.Visible;
            gvPopulares.Visibility = Visibility.Visible;
            rAccion.Visibility = Visibility.Visible;
            rPopulares.Visibility = Visibility.Visible;
            rBelicas.Visibility = Visibility.Visible;
            tbBuscada.Visibility = Visibility.Collapsed;
            rBuscada.Visibility = Visibility.Collapsed;
            gvBuscada.Visibility = Visibility.Collapsed;
            

        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;

            if (Width >= 720)
            {
                //svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactInline;
                tbBuscador.Visibility = Visibility.Visible;
                imagenLogo.Visibility = Visibility.Visible;
            }
            else if (Width >= 360)
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                tbBuscador.Visibility = Visibility.Collapsed;
                imagenLogo.Visibility = Visibility.Collapsed;
            }
            else
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.Overlay;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            svMenu.IsPaneOpen = !svMenu.IsPaneOpen;
        }


        private void pulsarInicio(object sender, RoutedEventArgs e)
        {
            tbOpcion.Text = "Inicio";
            List<Object> list = new List<Object>();
            list.Add(tbPerfil.Text);
            list.Add(listaLikes);
            list.Add(listaVistas);
            this.Frame.Navigate(typeof(MainPage), list);

        }

        private void pulsarPerfil(object sender, RoutedEventArgs e)
        {
            tbOpcion.Text = "Perfil";
            pasarInfo.Clear();
            pasarInfo.Add(tbPerfil.Text);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(PerfilPage), pasarInfo);
            

        }

        private void pulsarLogin(object sender, RoutedEventArgs e)
        {
            List<Object> list = new List<Object>();
            list.Add(lista[0]);
            list.Add(listaLikes);
            list.Add(listaVistas);
            this.Frame.Navigate(typeof(PantallaLogin), list);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             lista = (List<Object>)e.Parameter;
            if (lista[0] is string && !string.IsNullOrWhiteSpace((string)lista[0]))
                tbPerfil.Text = lista[0].ToString();
            listaLikes = (List<Boolean>)lista[1];
            listaVistas = (List<Boolean>)lista[2];
            base.OnNavigatedTo(e);
        }
        

        private void irAtras(object sender, BackRequestedEventArgs e)
        {
            tbOpcion.Text = "Inicio";
            List<Object> list = new List<Object>();
            list.Add(tbPerfil.Text);
            list.Add(listaLikes);
            list.Add(listaVistas);
            this.Frame.Navigate(typeof(MainPage), list);
        }
        private void irAtrasLogin(object sender, BackRequestedEventArgs e)
        {
            this.Frame.Navigate(typeof(PantallaLogin));
        }

        private void pasarRatonPopulares(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            tbPopulares.Foreground = redBrush;


        }

        private void pasarRatonPopularesFin(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush whiteBrush = new SolidColorBrush(Windows.UI.Colors.White);
            tbPopulares.Foreground = whiteBrush;
        }

        private void minimizarPopulares(object sender, PointerRoutedEventArgs e)
        {
            if (gvPopulares.Visibility == Visibility.Visible)
                gvPopulares.Visibility = Visibility.Collapsed;
            else
                gvPopulares.Visibility = Visibility.Visible;
        }

        private void pasarRatonBelicas(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            tbBelicas.Foreground = redBrush;
        }

        private void pasarRatonBelicasFin(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush whiteBrush = new SolidColorBrush(Windows.UI.Colors.White);
            tbBelicas.Foreground = whiteBrush;
        }

        private void minimizarBelicas(object sender, PointerRoutedEventArgs e)
        {
            if (gvBelicas.Visibility == Visibility.Visible)
                gvBelicas.Visibility = Visibility.Collapsed;
            else
                gvBelicas.Visibility = Visibility.Visible;
        }

        private void pasarRatonAccion(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            tbAccion.Foreground = redBrush;
        }

        private void pasarRatonAccionFin(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush whiteBrush = new SolidColorBrush(Windows.UI.Colors.White);
            tbAccion.Foreground = whiteBrush;
        }

        private void minimizarAccion(object sender, PointerRoutedEventArgs e)
        {
            if (gvAccion.Visibility == Visibility.Visible)
                gvAccion.Visibility = Visibility.Collapsed;
            else
                gvAccion.Visibility = Visibility.Visible;
        }

        

        private void clickBotonBusqueda(object sender, RoutedEventArgs e)
        {
            if (tbBuscador.Visibility == Visibility.Collapsed)
                tbBuscador.Visibility = Visibility.Visible;
           String peli = tbBuscador.Text.ToLower();
            nombrepeli = tbBuscador.Text;
            if (peli.Length != 0)
            {
                tbAccion.Visibility = Visibility.Collapsed;
                tbBelicas.Visibility = Visibility.Collapsed;
                tbPopulares.Visibility = Visibility.Collapsed;
                gvAccion.Visibility = Visibility.Collapsed;
                gvBelicas.Visibility = Visibility.Collapsed;
                gvPopulares.Visibility = Visibility.Collapsed;
                rAccion.Visibility = Visibility.Collapsed;
                rPopulares.Visibility = Visibility.Collapsed;
                rBelicas.Visibility = Visibility.Collapsed;
                rBuscada.Visibility = Visibility.Visible;
                tbBuscada.Visibility = Visibility.Visible;
                gvBuscada.Visibility = Visibility.Visible;

                if (peli == "gladiator")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imggladiator.jpg"));
                    nombrepeli = "Gladiator";
                }
                if (peli == "braveheart")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgbraVeheart.jpg"));
                    nombrepeli = "Braveheart";
                }
                if (peli == "apocalypse now")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgapocalypse.jpg"));
                    nombrepeli = "Apocalypse Now";
                }
                if (peli == "avatar")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgavatar.jpg"));
                    nombrepeli = "Avatar";
                }
                if (peli == "el mayordomo")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgel mayordomo.jpg"));
                    nombrepeli = "El Mayordomo";
                }
                if (peli == "forrest gump")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgforrest gump.jpg"));
                    nombrepeli = "Forrest Gump";
                }
                if (peli == "lista de schindler"|| peli=="la lista de schindler")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgla lista de schindler.jpg"));
                    nombrepeli = "La Lista de Schindler";
                }
                if (peli == "pearl harbor")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgpearl harbor.jpg"));
                    nombrepeli = "Pearl Harbor";
                }
                if (peli == "pulp fiction")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgpulp fiction.jpg"));
                    nombrepeli = "Pulp Fiction";
                }
                if (peli == "el rey león" || peli=="el rey leon")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgel rey leon.jpg"));
                    nombrepeli = "El rey Leon";
                }
                if (peli == "salvar al soldado ryan")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgsalvar al soldado ryan.jpg"));
                    nombrepeli = "Salvar al soldado Ryan";
                }
                if (peli == "senderos de gloria")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgsenderos de gloria.jpg"));
                    nombrepeli = "Senderos de Gloria";
                }
                if (peli == "el señor de los anillos" || peli == "el senor de los anillos")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgel senor de los anillos.jpg"));
                    nombrepeli = "El Senor de los Anillos";
                }
                if (peli == "shrek")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgshrek.jpg"));
                    nombrepeli = "Shrek";
                }
                if (peli == "titanic")
                {
                    imgBuscada.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/imgtitanic.jpg"));
                    nombrepeli = "Titanic";
                }

                
            }

            else {
                tbAccion.Visibility = Visibility.Visible;
                tbBelicas.Visibility = Visibility.Visible;
                tbPopulares.Visibility = Visibility.Visible;
                gvAccion.Visibility = Visibility.Visible;
                gvBelicas.Visibility = Visibility.Visible;
                gvPopulares.Visibility = Visibility.Visible;
                rAccion.Visibility = Visibility.Visible;
                rPopulares.Visibility = Visibility.Visible;
                rBelicas.Visibility = Visibility.Visible;
                tbBuscada.Visibility = Visibility.Collapsed;
                rBuscada.Visibility = Visibility.Collapsed;
                gvBuscada.Visibility = Visibility.Collapsed;
            }

            tbBuscada.Text = "Resultados de " + nombrepeli;
        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

            //tbPerfil.Text = inicializarLista.ToString();
            pasarInfo.Clear();
            pasarInfo.Add("gladiator");
            pasarInfo.Add(listaLikes); 
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage),pasarInfo);
            

        }

        private void tbBuscada_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }

        private void minimizarBuscada(object sender, PointerRoutedEventArgs e)
        {
            if (gvBuscada.Visibility == Visibility.Visible)
                gvBuscada.Visibility = Visibility.Collapsed;
            else
                gvBuscada.Visibility = Visibility.Visible;
        }

        private void pasarRatonBuscada(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            tbBuscada.Foreground = redBrush;
        }

        private void pasarRatonBuscadaFin(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush whiteBrush = new SolidColorBrush(Windows.UI.Colors.White);
            tbBuscada.Foreground = whiteBrush;
        }

        private void Pulsar_braveheart(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("braveheart");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);


        }

        private void Pulsar_salvarsoldado(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("salvar al soldado ryan");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_pulpfiction(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("pulp fiction");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_pearlharbor(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("pearl harbor");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_reyleon(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("el rey leon");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_avatar(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("avatar");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_shrek(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("shrek");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_mayordomo(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("el mayordomo");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_forrestgump(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("forrest gump");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_titanic(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("titanic");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_senoranillos(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("el senor de los anillos");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_apocalypse(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("apocalypse now");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_senderos(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("senderos de gloria");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_listaschindler(object sender, PointerRoutedEventArgs e)
        {
            pasarInfo.Clear();
            pasarInfo.Add("la lista de schindler");
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);

        }

        private void Pulsar_pelibuscada(object sender, PointerRoutedEventArgs e)
        {

            pasarInfo.Clear();
            string nombre = nombrepeli.ToLower();
            pasarInfo.Add(nombre);
            pasarInfo.Add(listaLikes);
            pasarInfo.Add(listaVistas);
            fmInicio.Navigate(typeof(InformacionPeliculaPage), pasarInfo);
        }
    }
}
