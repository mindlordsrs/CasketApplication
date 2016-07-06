using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape)
            {
                if ((i++ % 10) == 0)
                    Console.WriteLine("Escape - выход, Anykey - получение данных");

                try
                {
                    Console.WriteLine(GetStateString());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                key = Console.ReadKey();
            }
        }

        static string GetStateString()
        {
            var url = ConfigurationManager.AppSettings["Url"];
            var request = HttpWebRequest.CreateHttp(url);


            Response responseObject;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var serializer = new DataContractJsonSerializer(typeof(Response));
                responseObject = (Response)serializer.ReadObject(response.GetResponseStream());
                if (responseObject == null)
                    throw new InvalidOperationException();

                response.Close();


            }

            if (!responseObject.working)
                return "не работает";

            var workStartTime = responseObject.workStartTime != null ? DateTime.Parse(responseObject.workStartTime) : (DateTime?)null;

            if (workStartTime.HasValue)
                return string.Format("работает штатно, работы запланированы на {0}", workStartTime.Value);

            return "работает штатно";


        }
        [DataContract]
        class Response
        {
            [DataMember]
            public bool working { get; set; }
            [DataMember]
            public string workStartTime { get; set; }
        }
    }
}
