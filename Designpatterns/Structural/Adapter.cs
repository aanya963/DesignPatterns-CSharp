namespace DesignPatterns.Structural
{
    //1. Target interface expected by the client
    public interface IReports
    {
        string GetJsonData(string data);
    }
    // 2. Adaptee: provides XML data from raw input
    public class XmlDataProvider
    {
        //expect data in "name:id" format
        public string GetXmlData(string data)
        {
            int sep = data.IndexOf(':');
            string name=data.Substring(0, sep);
            string id=data.Substring(sep+1);

            return "<user>" +
                    "<name>" + name + "</name>" +
                    "<id>" + id + "</id>" + 
                    "</user>";
        }
    }
    // 3. Adapter: converts XML → JSON
    public class XmlDataProviderAdapter : IReports{
        private readonly XmlDataProvider xmlPro;
        public XmlDataProviderAdapter(XmlDataProvider pro)
        {
            xmlPro=pro;
        }
        public string GetJsonData(string data)
        {
            // 1. Get XML from adaptee
            string xml = xmlPro.GetXmlData(data);

            // 2. Extract values from XML
            int startName = xml.IndexOf("<name>") + 6;
            int endName = xml.IndexOf("</name>");
            string name = xml.Substring(startName, endName - startName);

            int startId=xml.IndexOf("<id>") + 4;
            int endId=xml.IndexOf("</id>");
            string id=xml.Substring(startId, endId-startId);

            //3. Return JSON
            return $"{{\"name\":\"{name}\", \"id\":{id}}}";
        }
    }
    // 4. Client
    public class Client
    {
        public void GetReport(IReports report, string rawData)
        {
            Console.WriteLine("Processed JSON: " + report.GetJsonData(rawData));
        }
    }
    //MAIN PROGRAM
    public class AdapterDemo
    {
        public static void Run()
        {
            // 1. Create adaptee
            XmlDataProvider xmlProv = new XmlDataProvider();
            //2. Create adapter
            IReports adapter = new XmlDataProviderAdapter(xmlProv);
            //3. Raw data
            string rawData = "Alice:42";
            //4. Client uses adapter
            Client client = new Client();
            client.GetReport(adapter, rawData);

        }
    }
    
}