using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ThiUWP_23102018.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class View_Gallery : Page
    {
        public View_Gallery()
        {
            this.InitializeComponent();
        }

        private async void btn_capture(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {

                BitmapImage source = await LoadImage(file);
                img.Source = source;
                // Application now has read/write access to the picked file

                txtName1.Text = file.Name;
                txtName2.Text = file.Name;
                path.Text = file.Path;
                createdAt.Text = file.DateCreated.ToString();

            }
            else
            {
                
                //lỗi
            }
        }
        public static async Task<BitmapImage> LoadImage(StorageFile file)
        {
            BitmapImage source = new BitmapImage();
            FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);

            source.SetSource(stream);
            return source;
        }

        private void comeBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DemoAppbar));
        }
    }
}
