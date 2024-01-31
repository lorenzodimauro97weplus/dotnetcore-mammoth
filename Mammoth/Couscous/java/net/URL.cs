using System.Net;
using Mammoth.Couscous.java.io;

namespace Mammoth.Couscous.java.net {
    using System.Net.Http;

    internal class URL {
        private readonly string _url;
        
        internal URL(string url) {
            _url = url;
        }
        
        internal InputStream openStream() {
            try
            {
                using var client = new HttpClient();
                var response = client.GetStreamAsync(_url).Result;
                try {
                    return ToJava.StreamToInputStream(response);
                } catch {
                    response.Close();
                    throw;
                }
            } catch (System.UriFormatException) {
                return ToJava.StreamToInputStream(System.IO.File.OpenRead(_url));
            } catch (WebException exception) {
                throw new IOException(exception.Message);
            }
        }
    }
}
