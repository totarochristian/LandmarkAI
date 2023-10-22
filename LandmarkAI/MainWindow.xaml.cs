using LandmarkAI.Classes;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LandmarkAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            //Initialize a dialog to choose a file from the pc and then open it
            OpenFileDialog dialog = new OpenFileDialog();
            //Set dialog filters of which type of file the user could select
            dialog.Filter = "Image files (*.png; *.jpg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
            //Set the initial directory of the file dialog as the "My Pictures" folder
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            //If user succesfully select a file
            if (dialog.ShowDialog() == true)
            {
                //Save the full path of the image selected by the user
                string fileName = dialog.FileName;
                //Set the selected image source using the file selected by the user
                selectedImage.Source = new BitmapImage(new Uri(fileName));

                MakePredictionAsync(fileName);
            }
        }

        private async void MakePredictionAsync(string fileName)
        {
            //Set default strings to make the request
            string url = "https://northeurope.api.cognitive.microsoft.com/customvision/v3.0/Prediction/bb98deea-c9e0-45a7-bc96-ed3ddb9c0593/classify/iterations/LandmarkAI/image";
            string predictionKey = "cc120e31d3a344fa9cde535f0739fd39";
            string contentType = "application/octet-stream";
            //Read the file as array of bytes
            var file = File.ReadAllBytes(fileName);
            //Define client http connection
            using (HttpClient client = new HttpClient())
            {
                //Add prediction key to the headers of the http request
                client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);
                
                //Use the file readed to define the content of the http request
                using(var content = new ByteArrayContent(file))
                {
                    //Set the content-type of the header of the file content (to sent in the http request)
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    //Post the content information in the url defined and await the response
                    var response = await client.PostAsync(url, content);
                    //Read the response as string
                    var responseString = await response.Content.ReadAsStringAsync();
                    //Deserialize the response string obtaining the custom vision object and then retrieve the predictions list from it
                    List<Prediction> predictions = (JsonConvert.DeserializeObject<CustomVision>(responseString)).Predictions;
                }
            }
        }
    }
}
