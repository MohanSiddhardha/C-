// Print temperature using API

using System;
using System.Net;
using System.IO;

class Weather
{
    public static void Main(string[] args)
    {
        Console.Write("Enter city name two get temperature: ");
        string CityName = Console.ReadLine();
        string URL = "https://api.openweathermap.org/data/2.5/weather?q=" + CityName + "&appid=f9608e11b8d7a417d53920fa76f959a5&units=metric";
        WebRequest Request = HttpWebRequest.Create(URL);
        WebResponse Responce = Request.GetResponse();
        StreamReader Reader = new StreamReader(Responce.GetResponseStream());
        string JsonResponse = Reader.ReadLine().ToString();
        int Start = JsonResponse.IndexOf("\"temp\":") + 7;
        int End = JsonResponse.IndexOf(",", Start);
        float Temperature = float.Parse(JsonResponse.Substring(Start, End - Start));
        Console.WriteLine("Temperature in " + CityName + " is " + Temperature + "\u00B0C");
    }
}