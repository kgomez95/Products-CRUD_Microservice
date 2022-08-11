using Products_CRUD_Microservice.Utils.Extensions;
using System.Text;

namespace Products_CRUD_Microservice.Utils
{
    public class RestClient<RP>
    {
        #region Protected variables.

        protected readonly Encoding _encoding;
        protected readonly HttpClient _httpClient;
        protected readonly HttpRequestMessage _request;

        #endregion

        #region Constructors.

        public RestClient(string url)
            : this(url, HttpMethod.Get)
        { }

        public RestClient(string url, HttpMethod method)
            : this(url, method, Encoding.UTF8)
        { }

        public RestClient(string url, HttpMethod method, Encoding encoding)
        {
            this._encoding = encoding;
            this._httpClient = new HttpClient();
            this._request = new HttpRequestMessage();

            this._request.RequestUri = new Uri(url);
            this._request.Method = method;
            //this._request.Version = HttpVersion.Version10;
        }

        #endregion

        #region Public members.

        #region Manage Headers.

        public RestClient<RP> AddHeader(string name, string? value)
        {
            this._request.Headers.Add(name, value);
            return this;
        }

        public RestClient<RP> AddHeader(string name, IEnumerable<string?> values)
        {
            this._request.Headers.Add(name, values);
            return this;
        }

        #endregion

        #region Execute members.

        public RP Execute()
        {
            return this.Execute(null);
        }

        public RP Execute(object? requestData)
        {
            try
            {
                // NOTE: Se podrían crear varios mediaType y no solo el "application/json".
                this._request.Content = new StringContent((requestData != null) ? requestData.ToJSON() : "", this._encoding, "application/json");

                // Lanzamos la petición y cogemos la respuesta.
                HttpResponseMessage response = this._httpClient.Send(this._request);

                // Obtenemos la respuesta y la devolvemos.
                return this.ObtainResponse(response);
            }
            catch (HttpRequestException ex)
            {
                // TODO: Controlar la excepción HTTP.
                throw ex;
            }
            catch (Exception ex)
            {
                // TODO: Controlar la excepción general.
                throw ex;
            }
        }

        #endregion

        #endregion

        #region Protected members.

        protected RP ObtainResponse(HttpResponseMessage response)
        {
            Stream stream = response.Content.ReadAsStream();

            using (StreamReader streamReader = new StreamReader(stream))
            {
                string responseContent = streamReader.ReadToEnd();
                return responseContent.FromJSON<RP>();
            }
        }

        #endregion
    }
}
