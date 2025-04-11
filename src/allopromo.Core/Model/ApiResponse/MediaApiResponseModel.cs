namespace allopromo.Core.Model
{
    public class MediaApiResponseModel
    {
        public string id { get; set; }
        public string url { get; set; }
        public string media { get; set; }
        public string thumb { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ThumbyModel
    {
        public MediaApiResponseModel data { get; set; }
        public int status { get; set; }
        public bool success { get; set; }
    }
    //public class OrderPlacedEventArgs : EventArgs
    //{
    //}
}
/* 1. table jointure
 * 2. re architecture
 * 3. I QUery Patterns
 */

// ? Builder !

//public delegate bool StoreCreatedEventHandler(object source, EventArgs e);
//What are Service Layers in Practice anyway ?
//public UnitOfWork _unitOfWork { get; set; }
// IOC by DIP
//IGenericsRepository _repo = GenericRepositoryFactory.GetRepository();
/*
* MapBox token: pk.eyJ1IjoiYWxpd2l5YW8iLCJhIjoiY2twaXo5bnVvMHYzNTJucGUzbTE3NXRodSJ9.qGOJOXU4ys9x_LU9Arj_MA
*/
//https://api.mapbox.com/geocoding/v5/{endpoint}/{

//IQuery Pattern ?
/* particulier a particulier : entreprises*/
/*
 * Latitude: 46.861114 / N 46° 51' 40.012''
Longitude: -71.268900 / W 71° 16' 8.04''
*/
/*
 * https://www.gps-coordinates.net/api
 * 
 */


