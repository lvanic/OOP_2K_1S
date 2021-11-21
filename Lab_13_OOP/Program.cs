using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace Lab_13_OOP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Car mazda = new Car { id = "0ex45", Manufacturer = "maz", MaxSpeed = 124 };
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("C:/Users/polza/source/repos/Lab_13_OOP/car.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, mazda);

                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("C:/Users/polza/source/repos/Lab_13_OOP/car.dat", FileMode.OpenOrCreate))
            {
                Car newMazda = (Car)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Speed: {newMazda.MaxSpeed} --- Id: {newMazda.id}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var jsonSerializer = new DataContractJsonSerializer(typeof(Car));
            using(FileStream fs = new FileStream("C:/Users/polza/source/repos/Lab_13_OOP/car.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, mazda);
            }
            using (FileStream fs = new FileStream("C:/Users/polza/source/repos/Lab_13_OOP/car.json", FileMode.OpenOrCreate))
            {
                Car mazda1 = (Car)jsonSerializer.ReadObject(fs);
                Console.WriteLine(mazda1.MaxSpeed);
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            XmlSerializer formatter1 = new XmlSerializer(typeof(Car));
            using (FileStream fs = new FileStream("C:/Users/polza/source/repos/Lab_13_OOP/car.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, mazda);

                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("C:/Users/polza/source/repos/Lab_13_OOP/car.xml", FileMode.OpenOrCreate))
            {
                Car Mazda3 = (Car)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Speed: {Mazda3.MaxSpeed} --- Id: {Mazda3.id}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //SoapFormatter formatter = new SoapFormatter();
            //Stream objfilestream = new FileStream("c:\\Myserialzed.xml", FileMode.Create, FileAccess.Write, FileShare.None);

            //formatter.Serialize(objfilestream, objSecrete);
            //objfilestream.Close();
            ////deserialization  
            //Stream objreadstream = new FileStream("c:\\Myserialzed.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            //secreteClass objSecrete2 = (secreteClass)formatter.Deserialize(objreadstream);


            Car[] cars = new Car[5];
            cars[0] = new Car() { id = "ebx", MaxSpeed = 125 };
            cars[1] = new Car() { id = "eax", MaxSpeed = 115};
            cars[2] = new Car() { id = "cce", MaxSpeed = 145 };

            XmlSerializer xmlFormatter2 = new XmlSerializer(typeof(Car[]));
            using (FileStream file = new FileStream("C:/Users/polza/source/repos/Lab_13_OOP/cars.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter2.Serialize(file, cars);
            }
            using (FileStream file = new FileStream("C:/Users/polza/source/repos/Lab_13_OOP/cars.xml", FileMode.Open))
            {
                Car[] newCars = (Car[])xmlFormatter2.Deserialize(file);
                for(int i = 0; cars[i]!=null;i++)
                {
                    Console.WriteLine(newCars[i].MaxSpeed);
                }
            }

            //-------------------------------------------------------------------------------------
            XmlDocument xml = new XmlDocument();
            xml.Load("C:/Users/polza/source/repos/Lab_13_OOP/cars.xml");
            XmlElement element = xml.DocumentElement;
            XmlNodeList xmlList = element.SelectNodes("//ArrayOfCar/Car[MaxSpeed = 115]");
            XmlNodeList xmlList1 = element.SelectNodes("//ArrayOfCar/Car[id = 'ebx']");
            
            foreach (XmlNode x in xmlList)
                Console.WriteLine(x.InnerText);

            XmlNode node = element.SelectSingleNode("Car");
            Console.WriteLine(node.InnerText);
            Console.WriteLine("=====================================================\n");


            XDocument xdoc = new XDocument(new XElement("cars",
                                            new XElement("car",
                                                new XAttribute("id", "ert"),
                                                new XElement("company", "mercedes")),
                                            new XElement("car",
                                                new XAttribute("id", "123"),
                                                new XElement("company", "bmw")),
                                            new XElement("car",
                                                new XAttribute("id", "1234"),
                                                new XElement("company", "Audi")),
                                            new XElement("car",
                                                new XAttribute("id", "324"),
                                                new XElement("company", "Geely"))));
            xdoc.Save("phones.xml");
            var phones = from xe in xdoc.Element("cars").Elements("car") where xe.Element("company").Value == "Audi" select xe;
            foreach (XElement el in phones)
                Console.WriteLine($"id: {el.Attribute("id").Value}, company: {el.Element("company").Value}");
            Console.WriteLine("=====================================================\n");

        }
    }
    [Serializable]
    public class Vehicle
    {
        public int MaxSpeed;
    }
    [Serializable]
    public class Car:Vehicle
    {
        [NonSerialized]
        public string Manufacturer;
        public string id;
    }
}
