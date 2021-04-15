using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CCard
{
    class Program
    {
        static void Main(string[] args)
        {
            /* string secretString = Cripto.Cripto.GenerateSecretString();

             Console.WriteLine($"secretString = {secretString}");

             string key = "]q`UbxJU_oZQeGm@faDaXc@3G`=OrJ^`";
             string creditCard = "1234-5678-9012-3456";
             string hiddenCreditCard = Cripto.Cripto.EncryptString(key, creditCard);
             Console.WriteLine($"hiddenCreditCard = {hiddenCreditCard}");

             string decryptedCreditCard = Cripto.Cripto.DecryptString(key, hiddenCreditCard);
             Console.WriteLine($"decryptedCreditCard = {decryptedCreditCard}");
             Console.WriteLine($"one time hidden Credit Card = {Cripto.Cripto.toMD5(hiddenCreditCard)}");

             string password = "pa$$word";
             Console.WriteLine($"SaltHashPassword = {Cripto.Cripto.SaltAndHash(password)}");
            */

            string key = "]q`UbxJU_oZQeGm@faDaXc@3G`=OrJ^`";

            List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Bob Smith", CreditCard = "1234-5678-9012-3456", Password = "Pa$$word"},
                new Customer { Name = "Duane Cruz", CreditCard = "9876-5432-1098-7654", Password = "MyPa$$"}
            };

            foreach (var item in customers)
            {
                item.CreditCard = Cripto.Cripto.EncryptString(key, item.CreditCard);
                item.Password = Cripto.Cripto.SaltAndHash(item.Password);
            }


            ToXml(customers, "customers.xml");

            var customersFromXml = FromXml<List<Customer>>("customers.xml");

            foreach (var item in customersFromXml)
            {
                var ccn = Cripto.Cripto.DecryptString(key, item.CreditCard);
                    Console.WriteLine($"{item.Name} {ccn} {item.Password}");
            }

        }

        public static void ToXml<T>(T obj, string path)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(sw, obj);
                File.WriteAllText(path, sw.ToString());
            }
        }
        public static T FromXml<T>(string path)
        {
            string xmlString = File.ReadAllText(path);
            using (StringReader sr = new StringReader(xmlString))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(sr);
            }
        }

    }
}
