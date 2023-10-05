using System.Xml;

class Note
{
    public string Id { get; private set; }
    public string Date { get; private set; }
    public string Time { get; private set; }
    public string Subject { get; private set; }
    public string Text { get; private set; }
    public string Tel { get; private set; }

    public Note(string id, string date, string time, string subject, string text, string tel)
    {
        Id = id;
        Date = date;
        Time = time;
        Subject = subject;
        Text = text;
        Tel = tel;
    }
    public void PrintToConsole()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Дата: {Date}");
        Console.WriteLine($"Час: {Time}");
        Console.WriteLine($"Тема: {Subject}");
        Console.WriteLine($"Текст: {Text}");
        Console.WriteLine($"Телефон: {Tel}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(@"D:\XMLFile1.xml");

        foreach (XmlNode node in xml.DocumentElement)
        {
            string id = node.Attributes["id"].InnerText;
            string date = node.Attributes["date"].InnerText;
            string time = node.Attributes["time"].InnerText;
            string subject = node["subject"].InnerText;
            string text = node["text"].InnerText;
            string tel = node["text"]["tel"].InnerText;

            Note note = new Note(id, date, time, subject, text, tel);
            note.PrintToConsole();
        }
    }
}
