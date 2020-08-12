using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCSV
{
    public partial class BiostarGets : Form
    {
        public BiostarGets()
        {
            InitializeComponent();
        }

        public static bool entrance = false;
        static HttpListener _httpListener = new HttpListener(); // 웹 제어용 httpListener 선언
        Thread _responseThread = new Thread(ResponseThread); // 웹 제어용 responseThread 선언 
        static bool threadControl = true;

        BiostarModule BM = new BiostarModule();

        static string session_id;

        public static HttpClient httpClient = new HttpClient();

        
        public void Request(object sender, EventArgs e)
        {
            ResponseThread();
        }






        static async void ResponseThread() // 웹 제어용 Response Thread
        {
            while (threadControl)
            {
                try
                {
                    HttpListenerContext context = _httpListener.GetContext();
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET");
                    byte[] _responseArray = Encoding.UTF8.GetBytes("");

                    if (context.Request.HttpMethod == "POST")   // POST 신호를 받았을 때 (POST)
                    {
                        var body = new StreamReader(context.Request.InputStream).ReadToEnd();
                        JObject jsonBody = (JObject)JsonConvert.DeserializeObject(body);

                        if (jsonBody.SelectToken("pw").ToString() == "seven7757")   // pw가 일치할 때
                        {
                            var command = context.Request.RawUrl.ToString().Split('/');
                            if (command[1] == "api")    // api request 일 때
                            {
                                BiostarModule bs = new BiostarModule();
                                if (command[2] == "users") // users request 일 때
                                {
                                    string userID = jsonBody.SelectToken("user_id").ToString();
                                    string startTime = jsonBody.SelectToken("s_time").ToString();
                                    string endTime = jsonBody.SelectToken("e_time").ToString();
                                    await bs.BSRegisterUser(userID, startTime, endTime);
                                    _responseArray = Encoding.UTF8.GetBytes("ok");
                                    context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length);
                                    context.Response.KeepAlive = false;
                                    context.Response.Close();
                                }

                            }
                        }
                        _responseArray = Encoding.UTF8.GetBytes("ok");
                        context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length);
                        context.Response.KeepAlive = false;
                        context.Response.Close();
                    }
                    else if (context.Request.HttpMethod == "GET")   // GET 요청을 받았을 때
                    {
                        JObject jsonBody = (JObject)JsonConvert.DeserializeObject(new StreamReader(context.Request.InputStream).ReadToEnd());
                        var command = context.Request.RawUrl.ToString().Split('/');
                        if (command[1] == "api")    // api request 일 때
                        {
                            if (command[2] == "doors")  // doors request 일 때
                            {
                                if (entrance)
                                {
                                    _responseArray = Encoding.UTF8.GetBytes("T");
                                }
                                else
                                {
                                    _responseArray = Encoding.UTF8.GetBytes("F");
                                }
                                context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length);
                                context.Response.KeepAlive = false;
                                context.Response.Close();
                            }

                        }

                    }
                }
                catch { }
            }
        }
    }
}
