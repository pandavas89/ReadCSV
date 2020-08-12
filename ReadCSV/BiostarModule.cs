using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ReadCSV
{
    class BiostarModule
    {

        /*
         *  Biostar2 new local API를 이용하여 제어하는 모듈.
         * 
         *  Biostar2 new local api에 관해서는 https://127.0.0.1/swagger/index.html 참조
         * 
         */

        static string session_id;

        public static HttpClient httpClient = new HttpClient();

        public static HttpClient returnHttp(HttpClient httpClient) 
        {
            return httpClient;
        }

        public async Task BSLogin() // Biostar2 api 로그인
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (requestMessage, certificate, chain, policyErrors) => true;
            httpClient = new HttpClient(handler);
            var request = new HttpRequestMessage(new HttpMethod("POST"), "https://127.0.0.1/api/login");
            request.Headers.TryAddWithoutValidation("accept", "application/json");
            request.Content = new StringContent("{ \"User\": { \"login_id\": \"admin\", \"password\": \"seven7757\" }}"); // 모든 biostar2 시스템 설치 시 동일하게 적용할 것 
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var response = await httpClient.SendAsync(request);
            string strRes = response.ToString();
            var resParse = strRes.Split('\n');
            session_id = resParse[3].Split(':')[1];
        }

        public async Task BSRegisterUser(string userID,  string start_time, string end_time) // 사용자 업데이트 // string userName, string Group,
        {
            /*
             *  Biostar2 new local api 사용자 등록 함수
             *  userID [string] 8자리 숫자
             *  strat_time, end_time [string] yyyy-mm-ddTHH:MM 형식으로 전달 받는다.             *              
             */

            await BSLogin();
            string getRequestURL = "https://127.0.0.1/api/users/" + userID;
            var getRequest = createRequest("GET", getRequestURL);
            var getResponse = await httpClient.SendAsync(getRequest);
            string statusCode = getResponse.Headers.GetValues("status").First();
            var getResult = getResponse.Content.ReadAsStringAsync();
            JObject resObj = (JObject)JsonConvert.DeserializeObject(getResult.Result);
            var responseCode = resObj.SelectToken("Response.code").ToString();
            if (statusCode == "200 OK" && responseCode == "0")   // 기존 ID가 조회 되었을 때
            {
                string putRequestURL = "https://127.0.0.1/api/users/" + userID;
                var putRequest = createRequest("PUT", putRequestURL);

                putRequest.Content = new StringContent("{ \"User\": { \"start_datetime\": \"" + start_time + ":00.00Z\", \"expiry_datetime\": \"" + end_time + ":00.00Z\" }}");
                putRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var putResponse = await httpClient.SendAsync(putRequest);
                JObject putResObj = (JObject)JsonConvert.DeserializeObject(putResponse.Content.ReadAsStringAsync().Result);
                if (putResObj.SelectToken("Response.code").ToString() != "0")
                {
                    MessageBox.Show(putResObj.SelectToken("Response.code").ToString());
                }
            }
            else    // 기존 ID가 조회되지 않았을 때
            {
                string cardRequestURL = "https://127.0.0.1/api/cards";
                var cardGetRequest = createRequest("GET", cardRequestURL + "?limit=1&offset=0");    // 기존 카드 ID를 확인한다.

                var cardGetResponse = await httpClient.SendAsync(cardGetRequest);
                JObject cardGetObj = (JObject)JsonConvert.DeserializeObject(cardGetResponse.Content.ReadAsStringAsync().Result);
                int newCardIdx = int.Parse(cardGetObj.SelectToken("cardCollection.total").ToString() + 1);

                var cardPostRequest = createRequest("POST", cardRequestURL);    // ID와 동일한 카드를 생성한다.
                string cardStr = "{ \"CardCollection\": { \"rows\": [ { \"card_type\": { \"id\": \"0\", \"name\": \"\", \"type\": \"1\" }, \"card_id\": \"";
                cardStr += userID + "\", \"display_card_id\": \"" + userID + "\", \"id\": \"" + newCardIdx + "\", \"$$hashKey\": \"object:565\", \"isDel\": treu } ] }}";
                cardPostRequest.Content = new StringContent(cardStr);
                cardPostRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application.json");

                var cardPostResponse = await httpClient.SendAsync(cardPostRequest);
                JObject cardPostObj = (JObject)JsonConvert.DeserializeObject(cardPostResponse.Content.ReadAsStringAsync().Result);
                if (cardPostObj.SelectToken("Response.code").ToString() == "0")
                {
                    string userRequestURL = "https://127.0.0.1/api/users";
                    var userRequest = createRequest("POST", userRequestURL);

                    string userStr = "{ \"User\": { \"name\": \"" + userID + "\", \"user_id\": \"" + userID + "\", \"user_group_id\": { \"id\": 1 }, \"disabled\": \"false\", ";
                    userStr += "\"start_datetime\": \"" + start_time + ":00.00Z\", \"exepiry_datetime\": \"" + end_time + ":00.00Z\",";
                    userStr += "\"cards\": [ { \"card_type\": { \"id\": \"0\", \"name\": \"\", \"type\": \"1\" }, \"card_id\": \"" + userID + "\", \"display_card_id\": \"" + userID + "\", \"id\": \"" + newCardIdx + "\" } ] }}";
                    userRequest.Content = new StringContent(userStr);
                    userRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var userResponse = await httpClient.SendAsync(userRequest);
                    JObject userObj = (JObject)JsonConvert.DeserializeObject(userResponse.Content.ReadAsStringAsync().Result);

                }


            }


        }

        public HttpRequestMessage createRequest(string method, string requestURL)
        {
            // 지정된 URL과 Method의 request를 생성하고 bs-session-id header를 추가하여 리턴한다.
            var request = new HttpRequestMessage(new HttpMethod(method), requestURL);
            request.Headers.TryAddWithoutValidation("accept", "application/json");
            request.Headers.TryAddWithoutValidation("bs-session-id", session_id);
            return request;
        }
    }
}
