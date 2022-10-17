using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using Serilog;
using allopromo.Core.Aggregates;

namespace allopromo.Core.Model
{
    public class StoreLocator
    {
        HttpClient _httpClient { get; set; }
        private ILogger _logger { get; set; }
        public StoreLocator(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public string GetLocation()
        {
            var location = getAddress(23.5270797, 77.2548046);
            return location.ToString();
        }
        private string ReturnGPSCoordinates()
        {
            var rootObjc= getAddress(23.5270797, 77.2548046);
            return ""; //rootObj.display_Name;
        }
        private static RootObject getAddress (double Longitude, double Latitude)
            
            //getAddress(23.5270797, 77.2548046);
        {
            //onst double longitude = Longitude;
            //const double latitude = Latitude;

            //const string pathUrl = " https://nominatim.openstreetmap.org/reverse?format=json&lat=30.4573699&lon=-97.8247654";

            //const string  mapBox= " https://api.mapbox.com/geocoding/v5/{endpoint}/";

            const string reverseGeoCodingApiEndPoint = " http://nominatim.openstreetmap.org/reverse?format=json&lat= "; // + Latitude + "&lon=" + Longitude;

            HttpResponseMessage msg = new HttpResponseMessage();
            RootObject obj = null;
            using (var httpClient = new HttpClient())
            {
                //msg = await httpClient.GetFromJsonAsync(pathUrl);
            }
            using (var webClient = new WebClient())
            {
                var jsonData = webClient.DownloadData(reverseGeoCodingApiEndPoint);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
                obj = (RootObject)ser.ReadObject(new MemoryStream(jsonData));
            }
                return obj;
        }
    }




















    //public class OrderPlacedEventArgs : EventArgs
    //{
    //}

    ////return new StoreRepository().GetAllStores().AsEnumerable();//GetStoresCategories()
    //return _storeRepo.GetAllStores().AsEnumerable();//(page, size).AsEnnumerable();
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

/*
 * Latitude: 46.861114 / N 46° 51' 40.012''
Longitude: -71.268900 / W 71° 16' 8.04''
*/
/*
 * https://www.gps-coordinates.net/api
 * 
 */


