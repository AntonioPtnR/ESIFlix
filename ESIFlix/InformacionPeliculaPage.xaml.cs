using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ESIFlix
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class InformacionPeliculaPage : Page
    {
        List<Boolean> listaLikes = new List<Boolean>();
        List<Boolean> listaVistas = new List<Boolean>();
        List<Object> lista = new List<Object>();
        Storyboard sbPasarRatonLike;
        Storyboard sbPasarRatonOjo;
        Storyboard sbPulsarOjo;
        Boolean pelVista = false;
        Boolean blanco = true;
        public InformacionPeliculaPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += InformacionPeliculaPage_VisibleBoundsChanged;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            SystemNavigationManager.GetForCurrentView().BackRequested += irAtras;
            rcValoracion.Value = 3;


        }

        private void irAtras(object sender, BackRequestedEventArgs e)
        {
           
            List<Object> list = new List<Object>();
            list.Add("");
            listaLikes[0] = !blanco;
            list.Add(listaLikes);
            list.Add(listaVistas);
            this.Frame.Navigate(typeof(MainPage), list);
        }

        private void InformacionPeliculaPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView
sender, object args)
        {
            var Width =
           Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 720)
            {
                trailerPelicula.Width = 548;
                tbNombrePelicula.FontSize = 36;
            }
            else if (Width >= 360)
            {
                trailerPelicula.Width = 360;
                tbNombrePelicula.FontSize = 30;
            }
            else
            {
                trailerPelicula.Width = 260;
                tbNombrePelicula.FontSize = 24;

            }
        }

       

        private void PasarRatonLike(object sender, PointerRoutedEventArgs e)
        {
            sbPasarRatonLike = (Storyboard)this.Resources["animacionPasarRatonLike"];
            sbPasarRatonLike.Begin();
        }

        

        private void PulsarRatonLike(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            SolidColorBrush whiteBrush = new SolidColorBrush(Windows.UI.Colors.White);
            if (blanco) {
                corazon.Fill = redBrush;
                blanco = false;
                new ToastContentBuilder()
                        .AddArgument("action", "Likes")
                        .AddArgument("conversationId", 9813)
                        .AddText(tbNombrePelicula.Text + " añadida a peliculas que te gustan")
                        .AddText("Información actualizada en ESIFlix")
                        .AddInlineImage(new Uri("ms-appx:///Assets/Images/img" + lista[0] + ".jpg"))
                        .AddAppLogoOverride(new Uri("ms-appx:///Assets/Images/img" + lista[0] + ".jpg"),
                         ToastGenericAppLogoCrop.Circle)
                        .Show();

            }
            else
            {
                corazon.Fill = whiteBrush;
                blanco = true;
                new ToastContentBuilder()
                        .AddArgument("action", "Likes")
                        .AddArgument("conversationId", 9813)
                        .AddText(tbNombrePelicula.Text + " quitada de películas que te gustan")
                        .AddText("Información actualizada en ESIFlix")
                        .AddInlineImage(new Uri("ms-appx:///Assets/Images/img" + lista[0] + ".jpg"))
                        .AddAppLogoOverride(new Uri("ms-appx:///Assets/Images/img" + lista[0] + ".jpg"),
                         ToastGenericAppLogoCrop.Circle)
                        .Show();
            }
            if(lista[0].ToString().Equals("gladiator"))
                listaLikes[0] = !blanco;
            if (lista[0].ToString().Equals("braveheart"))
                listaLikes[1] = !blanco;
            if (lista[0].ToString().Equals("apocalypse now"))
                listaLikes[2] = !blanco;
            if (lista[0].ToString().Equals("avatar"))
                listaLikes[3] = !blanco;
            if (lista[0].ToString().Equals("el mayordomo"))
                listaLikes[4] = !blanco;
            if (lista[0].ToString().Equals("el rey leon"))
                listaLikes[5] = !blanco;
            if (lista[0].ToString().Equals("forrest gump"))
                listaLikes[6] = !blanco;
            if (lista[0].ToString().Equals("la lista de schindler"))
                listaLikes[7] = !blanco;
            if (lista[0].ToString().Equals("pearl harbor"))
                listaLikes[8] = !blanco;
            if (lista[0].ToString().Equals("pulp fiction"))
                listaLikes[9] = !blanco;
            if (lista[0].ToString().Equals("salvar al soldado ryan"))
                listaLikes[10] = !blanco;
            if (lista[0].ToString().Equals("senderos de gloria"))
                listaLikes[11] = !blanco;
            if (lista[0].ToString().Equals("shrek"))
                listaLikes[12] = !blanco;
            if (lista[0].ToString().Equals("titanic"))
                listaLikes[13] = !blanco;
            if (lista[0].ToString().Equals("el senor de los anillos"))
                listaLikes[14] = !blanco;

        }


        private void PasarRatonLikeFin(object sender, PointerRoutedEventArgs e)
        {
            sbPasarRatonLike.Stop();
        }

        private void PasarRatonOjo(object sender, PointerRoutedEventArgs e)
        {
            sbPasarRatonOjo = (Storyboard)this.Resources["animacionPasarRatonOjo"];
            sbPasarRatonOjo.Begin();
        }

        private void PasarRatonOjoFin(object sender, PointerRoutedEventArgs e)
        {
            sbPasarRatonOjo.Stop();
        }

        private void PulsarOjo(object sender, PointerRoutedEventArgs e)
        {
            sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
            if (!pelVista)
            {
                sbPulsarOjo.Begin();
                pelVista = true;
                new ToastContentBuilder()
                        .AddArgument("action", "Vistas")
                        .AddArgument("conversationId", 9813)
                        .AddText(tbNombrePelicula.Text + " añadida a películas vistas")
                        .AddText("Información actualizada en ESIFlix")
                        .AddInlineImage(new Uri("ms-appx:///Assets/Images/img" + lista[0] + ".jpg"))
                        .AddAppLogoOverride(new Uri("ms-appx:///Assets/Images/img" + lista[0] + ".jpg"),
                         ToastGenericAppLogoCrop.Circle)
                        .Show();
            }
            else {
                sbPulsarOjo.Stop();
                pelVista = false;
                new ToastContentBuilder()
                        .AddArgument("action", "Vistas")
                        .AddArgument("conversationId", 9813)
                        .AddText(tbNombrePelicula.Text + " quitada de películas vistas")
                        .AddText("Información actualizada en ESIFlix")
                        .AddInlineImage(new Uri("ms-appx:///Assets/Images/img"+lista[0]+".jpg"))
                        .AddAppLogoOverride(new Uri("ms-appx:///Assets/Images/img"+lista[0]+".jpg"),
                         ToastGenericAppLogoCrop.Circle)
                        .Show();
            }

            if (lista[0].ToString().Equals("gladiator"))
                listaVistas[0] = pelVista;
            if (lista[0].ToString().Equals("braveheart"))
                listaVistas[1] = pelVista;
            if (lista[0].ToString().Equals("apocalypse now"))
                listaVistas[2] = pelVista;
            if (lista[0].ToString().Equals("avatar"))
                listaVistas[3] = pelVista;
            if (lista[0].ToString().Equals("el mayordomo"))
                listaVistas[4] = pelVista;
            if (lista[0].ToString().Equals("el rey leon"))
                listaVistas[5] = pelVista;
            if (lista[0].ToString().Equals("forrest gump"))
                listaVistas[6] = pelVista;
            if (lista[0].ToString().Equals("la lista de schindler"))
                listaVistas[7] = pelVista;
            if (lista[0].ToString().Equals("pearl harbor"))
                listaVistas[8] = pelVista;
            if (lista[0].ToString().Equals("pulp fiction"))
                listaVistas[9] = pelVista;
            if (lista[0].ToString().Equals("salvar al soldado ryan"))
                listaVistas[10] = pelVista;
            if (lista[0].ToString().Equals("senderos de gloria"))
                listaVistas[11] = pelVista;
            if (lista[0].ToString().Equals("shrek"))
                listaVistas[12] = pelVista;
            if (lista[0].ToString().Equals("titanic"))
                listaVistas[13] = pelVista;
            if (lista[0].ToString().Equals("el senor de los anillos"))
                listaVistas[14] = pelVista;
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            lista = (List<Object>)e.Parameter;
            listaLikes = (List<Boolean>)lista[1];
            listaVistas = (List<Boolean>)lista[2];
            SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            SolidColorBrush whiteBrush = new SolidColorBrush(Windows.UI.Colors.White);
            sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
            if (lista[0] is string && !string.IsNullOrWhiteSpace((string)lista[0]))
                if (lista[0].Equals("gladiator"))
                {
                    tbNombrePelicula.Text = "Gladiator";
                    tbDirector.Text = "Ridley Scott";
                    tbReparto.Text = "Russell Crowe, Joaquin Phoenix";
                    tbClasificacion.Text = "Acción/Aventuras/Drama";
                    tbEdad.Text = "+12";

                    rcValoracion.Value = 5;
                    Paragraph p = new Paragraph();
                    Run run = new Run();
                    run.Text = "En el año 180, el Imperio Romano domina todo el mundo conocido. Tras una gran victoria sobre los bárbaros del norte, el anciano emperador Marco Aurelio (Richard Harris) decide transferir el poder a Máximo (Russell Crowe), bravo general de sus ejércitos y hombre de inquebrantable lealtad al imperio. Pero su hijo Cómodo (Joaquin Phoenix), que aspiraba al trono, no lo acepta y trata de asesinar a Máximo.  ";
                    p.Inlines.Clear();
                    p.Inlines.Add(run);
                    descripcionPelicula.Blocks.Add(p);


                    Uri pathUri = new Uri("ms-appx:///Assets/Videos/Gladiator.mp4");
                    trailerPelicula.Source = pathUri;
                    blanco = !listaLikes[0];
                    
                    if (blanco)
                        corazon.Fill = whiteBrush;
                    else
                        corazon.Fill = redBrush;

                    pelVista = listaVistas[0];
                   
                    if (pelVista)
                    {
                        sbPulsarOjo.Begin();
                        
                    }
                    else {
                        sbPulsarOjo.Stop();
                    }
                }


            if (lista[0].Equals("braveheart"))
            {
                tbNombrePelicula.Text = "Braveheart";
                tbDirector.Text = "Mel Gibson";
                tbReparto.Text = "Mel Gibson, Sophie Merceau";
                tbClasificacion.Text = "Aventuras/Drama";
                tbEdad.Text = "+18";

                rcValoracion.Value = 4;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "En el siglo XIV, los escoceses viven oprimidos por los gravosos tributos y las injustas leyes impuestas por los ingleses. William Wallace es un joven escocés que regresa a su tierra despues de muchos años de ausencia. Siendo un niño, toda su familia fue asesinada por los ingleses, razón por la cual se fue a vivir lejos con un tío suyo. ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Braveheart.mp4");
                trailerPelicula.Source = pathUri;
                blanco = !listaLikes[1];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[1];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }

            }

            if (lista[0].Equals("apocalypse now"))
            {
                tbNombrePelicula.Text = "Apocalypse Now";
                tbDirector.Text = "Francis Ford Coppola";
                tbReparto.Text = "Martin Sheen, Marlon Brando...";
                tbClasificacion.Text = "Bélico/Drama";
                tbEdad.Text = "+13";

                rcValoracion.Value = 3;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Durante la guerra de Vietnam, al joven Capitán Willard, un oficial de los servicios de inteligencia del ejército estadounidense, se le ha encomendado entrar en Camboya con la peligrosa misión de eliminar a Kurtz, un coronel renegado que se ha vuelto loco. El capitán deberá ir navegar por el río hasta el corazón de la selva, donde parece ser que Kurtz reina como un buda despótico sobre los miembros de la tribu Montagnard, que le adoran como a un dios.  ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Apocalypsenow.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[2];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[2];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("avatar"))
            {
                tbNombrePelicula.Text = "Avatar";
                tbDirector.Text = "James Cameron";
                tbReparto.Text = "Sam Worthington, Zoe Saldana...";
                tbClasificacion.Text = "Ficción/Aventuras";
                tbEdad.Text = "+7";

                rcValoracion.Value = 3;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Año 2154. Jake Sully (Sam Worthington), un ex-marine condenado a vivir en una silla de ruedas, sigue siendo, a pesar de ello, un auténtico guerrero. Precisamente por ello ha sido designado para ir a Pandora, donde algunas empresas están extrayendo un mineral extraño que podría resolver la crisis energética de la Tierra. Para contrarrestar la toxicidad de la atmósfera de Pandora, se ha creado el programa Avatar, gracias al cual los seres humanos mantienen sus conciencias unidas a un avatar: un cuerpo biológico controlado de forma remota que puede sobrevivir en el aire letal. Esos cuerpos han sido creados con ADN humano, mezclado con ADN de los nativos de Pandora, los Na'vi. Convertido en avatar, Jake puede caminar otra vez. Su misión consiste en infiltrarse entre los Na'vi, que se han convertido en el mayor obstáculo para la extracción del mineral. Pero cuando Neytiri, una bella Na'vi (Zoe Saldana), salva la vida de Jake, todo cambia: Jake, tras superar ciertas pruebas, es admitido en su clan. Mientras tanto, los hombres esperan los resultados de la misión de Jake.  ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Avatar.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[3];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[3];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("el mayordomo"))
            {
                tbNombrePelicula.Text = "El Mayordomo";
                tbDirector.Text = "Lee Daniels";
                tbReparto.Text = "Forest Whitaker, Oprah Winfrey...";
                tbClasificacion.Text = "Drama";
                tbEdad.Text = "+12";

                rcValoracion.Value = 4;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Cecil Gaines (Forest Whitaker) fue mayordomo jefe de la Casa Blanca durante el mandato de ocho presidentes (1952-1986), lo que le permitió ser testigo directo de la historia política y racial de los Estados Unidos.  ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Elmayordomo.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[4];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[4];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("el rey leon"))
            {
                tbNombrePelicula.Text = "El Rey León";
                tbDirector.Text = "Jon Favreau";
                tbReparto.Text = "Animación";
                tbClasificacion.Text = "Animación/Aventuras/Drama";
                tbEdad.Text = "+6";

                rcValoracion.Value = 3;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Tras el asesinato de su padre, un joven león abandona su reino para descubrir el auténtico significado de la responsabilidad y de la valentía. Remake de El Rey León, dirigido y producido por Jon Favreau, responsable de la puesta al día, con el mismo formato, de El libro de la selva (2016). ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/ElreyLeon.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[5];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[5];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("forrest gump"))
            {
                tbNombrePelicula.Text = "Forrest Gump";
                tbDirector.Text = "Robert Zemeckis";
                tbReparto.Text = "Tom Hanks, Robin Wright...";
                tbClasificacion.Text = "Comedia/Drama/Romance";
                tbEdad.Text = "+7";

                rcValoracion.Value = 4;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Forrest Gump (Tom Hanks) sufre desde pequeño un cierto retraso mental. A pesar de todo, gracias a su tenacidad y a su buen corazón será protagonista de acontecimientos cruciales de su país durante varias décadas. Mientras pasan por su vida multitud de cosas en su mente siempre está presente la bella Jenny (Robin Wright), su gran amor desde la infancia, que junto a su madre será la persona más importante en su vida. ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Forrestgump.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[6];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[6];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("la lista de schindler"))
            {
                tbNombrePelicula.Text = "La Lista de Schindler";
                tbDirector.Text = "Steven Spielberg";
                tbReparto.Text = "Liam Neeson, Ben Kingsley...";
                tbClasificacion.Text = "Drama";
                tbEdad.Text = "+12";

                rcValoracion.Value = 4;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Oskar Schindler (Liam Neeson), un empresario alemán de gran talento para las relaciones públicas, busca ganarse la simpatía de los nazis de cara a su beneficio personal. Después de la invasión de Polonia por los alemanes en 1939, Schindler consigue, gracias a sus relaciones con los altos jerarcas nazis, la propiedad de una fábrica de Cracovia. Allí emplea a cientos de operarios judíos, cuya explotación le hace prosperar rápidamente, gracias sobre todo a su gerente Itzhak Stern (Ben Kingsley), también judío. Pero conforme la guerra avanza, Schindler y Stern comienzan ser conscientes de que a los judíos que contratan, los salvan de una muerte casi segura en el temible campo de concentración de Plaszow, que lidera el Comandante nazi Amon Goeth (Ralph Fiennes), un hombre cruel que disfruta ejecutando judíos. ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Lalistadeschindler.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[7];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[7];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("pearl harbor"))
            {
                tbNombrePelicula.Text = "Pearl Harbor";
                tbDirector.Text = "Michael Bay";
                tbReparto.Text = "Ben Affleck, Josh Hartnett, Kate Beckinsale...";
                tbClasificacion.Text = "Bélico/Acción/Drama/Romance";
                tbEdad.Text = "+12";

                rcValoracion.Value = 5;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Año 1941, en plena Segunda Guerra Mundial en Europa. Rafe McCawley (Affleck) y Danny Walker (Hartnett) crecieron juntos en una zona rural estadounidense y su larga amistad se mantiene cuando ambos ingresan como pilotos en las fuerzas aéreas. Rafe encontró en Evelyn Johnson (Beckinsale), una valiente enfermera, al amor de su vida, pero pronto tuvieron que separarse, al ser llamado Rafe para servir en la Fuerza Aérea Británica (RAF) contra los alemanes. Mientras tanto, Danny y Evelyn son enviados a la base aérea de Pearl Harbor en Hawai. ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Pearlharbor.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[8];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[8];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("pulp fiction"))
            {
                tbNombrePelicula.Text = "Pulp Fiction";
                tbDirector.Text = "Quentin Tarantino";
                tbReparto.Text = "Jhon Travolta, Samuel L. Jackson, Uma Thurman...";
                tbClasificacion.Text = "Thriller";
                tbEdad.Text = "+18";

                rcValoracion.Value = 4;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Jules y Vincent, dos asesinos a sueldo con no demasiadas luces, trabajan para el gángster Marsellus Wallace. Vincent le confiesa a Jules que Marsellus le ha pedido que cuide de Mia, su atractiva mujer. Jules le recomienda prudencia porque es muy peligroso sobrepasarse con la novia del jefe. Cuando llega la hora de trabajar, ambos deben ponerse manos a la obra. Su misión: recuperar un misterioso maletín. ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Pulpfiction.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[9];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[9];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("salvar al soldado ryan"))
            {
                tbNombrePelicula.Text = "Salvar al soldado Ryan";
                tbDirector.Text = "Steven Spilberg";
                tbReparto.Text = "Tom Hanks, Tom Sizemore...";
                tbClasificacion.Text = "Bélico";
                tbEdad.Text = "+12";

                rcValoracion.Value = 4;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Segunda Guerra Mundial, 1944. Tras el desembarco de los Aliados en Normandía, a un grupo de soldados americanos se le encomienda una peligrosa misión: poner a salvo al soldado James Ryan. Los hombres de la patrulla del capitán John Miller deben arriesgar sus vidas para encontrar a este soldado, cuyos tres hermanos han muerto en la guerra. Lo único que se sabe del soldado Ryan es que se lanzó con su escuadrón de paracaidistas detrás de las líneas enemigas. ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Salvaralsoldadoryan.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[10];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[10];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("senderos de gloria"))
            {
                tbNombrePelicula.Text = "Senderos de Gloria";
                tbDirector.Text = "Stanley Kubrick";
                tbReparto.Text = "Kirk Douglas, George Macready...";
                tbClasificacion.Text = "Bélico/Drama";
                tbEdad.Text = "+12";

                rcValoracion.Value = 3;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Primera Guerra Mundial (1914-1918). En 1916, en Francia, el general Boulard ordena la conquista de una inexpugnable posición alemana y encarga esa misión al ambicioso general Mireau. El encargado de dirigir el ataque será el coronel Dax. La toma de la colina resulta un infierno, y el regimiento emprende la retirada hacia las trincheras. El alto mando militar, irritado por la derrota, decide imponer al regimiento un terrible castigo que sirva de ejemplo a los demás soldados.  ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Senderosdegloria.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[11];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[11];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("shrek"))
            {
                tbNombrePelicula.Text = "Shrek";
                tbDirector.Text = "Andrew Adamson, Vicky Jenson";
                tbReparto.Text = "Animación";
                tbClasificacion.Text = "Animación/Comedia/Aventuras";
                tbEdad.Text = "+6";

                rcValoracion.Value = 3;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Hace mucho tiempo, en una lejanísima ciénaga, vivía un feroz ogro llamado Shrek. De repente, un día, su soledad se ve interrumpida por una invasión de sorprendentes personajes. Hay ratoncitos ciegos en su comida, un enorme y malísimo lobo en su cama, tres cerditos sin hogar y otros seres que han sido deportados de su tierra por el malvado Lord Farquaad. Para salvar su territorio, Shrek hace un pacto con Farquaad y emprende viaje para conseguir que la bella princesa Fiona acceda a ser la novia del Lord. En tan importante misión le acompaña un divertido burro, dispuesto a hacer cualquier cosa por Shrek: todo, menos guardar silencio. ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Shrek.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[12];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[12];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("titanic"))
            {
                tbNombrePelicula.Text = "Titanic";
                tbDirector.Text = "James Cameron";
                tbReparto.Text = "Leonardo DiCaprio, Kate Winslet...";
                tbClasificacion.Text = "Romance/Drama/Aventuras";
                tbEdad.Text = "+12";

                rcValoracion.Value = 5;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "Jack (DiCaprio), un joven artista, gana en una partida de cartas un pasaje para viajar a América en el Titanic, el transatlántico más grande y seguro jamás construido. A bordo conoce a Rose (Kate Winslet), una joven de una buena familia venida a menos que va a contraer un matrimonio de conveniencia con Cal (Billy Zane), un millonario engreído a quien sólo interesa el prestigioso apellido de su prometida. Jack y Rose se enamoran, pero el prometido y la madre de ella ponen todo tipo de trabas a su relación. Mientras, el gigantesco y lujoso transatlántico se aproxima hacia un inmenso iceberg. ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/Titanic.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[13];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[13];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            if (lista[0].Equals("el senor de los anillos"))
            {
                tbNombrePelicula.Text = "El Señor de los Anillos";
                tbDirector.Text = "Peter Jackson";
                tbReparto.Text = "Elijah Wood, Ian McKellen, Viggo Mortensen...";
                tbClasificacion.Text = "Fantástico/Aventuras/Acción";
                tbEdad.Text = "+12";

                rcValoracion.Value = 5;
                Paragraph p = new Paragraph();
                Run run = new Run();
                run.Text = "En la Tierra Media, el Señor Oscuro Sauron ordenó a los Elfos que forjaran los Grandes Anillos de Poder. Tres para los reyes Elfos, siete para los Señores Enanos, y nueve para los Hombres Mortales. Pero Saurón también forjó, en secreto, el Anillo Único, que tiene el poder de esclavizar toda la Tierra Media. Con la ayuda de sus amigos y de valientes aliados, el joven hobbit Frodo emprende un peligroso viaje con la misión de destruir el Anillo Único. Pero el malvado Sauron ordena la persecución del grupo, compuesto por Frodo y sus leales amigos hobbits, un mago, un hombre, un elfo y un enano. La misión es casi suicida pero necesaria, pues si Sauron con su ejército de orcos lograra recuperar el Anillo, sería el final de la Tierra Media.  ";
                p.Inlines.Clear();
                p.Inlines.Add(run);
                descripcionPelicula.Blocks.Add(p);

                Uri pathUri = new Uri("ms-appx:///Assets/Videos/trailer_senor_anillos.mp4");
                trailerPelicula.Source = pathUri;

                blanco = !listaLikes[14];
                if (blanco)
                    corazon.Fill = whiteBrush;
                else
                    corazon.Fill = redBrush;

                pelVista = listaVistas[14];
                sbPulsarOjo = (Storyboard)this.Resources["animacionPeliculaVista"];
                if (pelVista)
                {
                    sbPulsarOjo.Begin();
                }
                else
                {
                    sbPulsarOjo.Stop();
                }
            }

            base.OnNavigatedTo(e);

        }

        

    }
}