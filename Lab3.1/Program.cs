using System.Xml;

class Logs
{
    public static List<Event> EventList = new List<Event>();
    public static void Add(Event e)
    {
        EventList.Add(e);
    }
    public static void Show()
    {
        foreach (Event i in EventList)
        {
            i.PrintToConsole();
        }
    }
}

class Event
{
    public string Date { get; private set; }
    public string Result { get; private set; }
    public string IpFrom { get; private set; }
    public string Method { get; private set; }
    public string UrlTo { get; private set; }
    public string Response { get; private set; }

    public Event(string date, string result, string ipFrom, string method, string urlTo, string response)
    {
        Date = date;
        Result = result;
        IpFrom = ipFrom;
        Method = method;
        UrlTo = urlTo;
        Response = response;
    }

    public void PrintToConsole()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Дата: {Date}");
        Console.WriteLine($"Результат: {Result}");
        Console.WriteLine($"IP-адреса: {IpFrom}");
        Console.WriteLine($"Метод: {Method}");
        Console.WriteLine($"URL: {UrlTo}");
        Console.WriteLine($"Відповідь: {Response}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(@"D:\XMLFile2.xml");
        foreach (XmlNode node in xml.DocumentElement)
        {
            string date = node.Attributes[0].InnerText;
            string result = node.Attributes[1].InnerText;
            string ipFrom = node["ip-from"].InnerText;
            string method = node["method"].InnerText;
            string urlTo = node["url-to"].InnerText;
            string response = node["response"].InnerText;
            Logs.Add(new Event(date, result, ipFrom, method, urlTo, response));
        }
        Logs.Show();
    }
}

