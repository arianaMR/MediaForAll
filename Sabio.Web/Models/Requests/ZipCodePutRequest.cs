namespace Sabio.Web.Models.Requests
{
    public class ZipCodePutRequest
    {
        public int ZipCode { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Polygon { get; set; }

    }
}