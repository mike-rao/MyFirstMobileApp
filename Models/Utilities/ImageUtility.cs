namespace MyFirstMobileApp.Models.Utilities
{
    public static class ImageUtility
    {
        public static ImageSource GetImage(string url)
        {
            var imgsrc = new UriImageSource { Uri = new Uri(url) };
            imgsrc.CachingEnabled = false;
            imgsrc.CacheValidity = TimeSpan.FromHours(1);

            return imgsrc;
        }

        public static async Task<ImageSource> GetImageAsync(string url)
        {
            ImageSource setImageSource = null;

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        setImageSource = ImageSource.FromStream(() => stream);
                    }
                    else
                    {
                        // Handle error or show a placeholder image
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the image loading
                Console.WriteLine($"Error loading image: {ex}");
            }

            return setImageSource;
        }
    }
}
