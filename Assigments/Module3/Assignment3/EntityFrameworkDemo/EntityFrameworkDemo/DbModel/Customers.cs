using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EntityFrameworkDemo.DbModel
{
    [Serializable()]
    public partial class Customers : ISerializable
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public string JobTitle { get; set; }
        public string BusinessPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string CountryRegion { get; set; }
        public string WebPage { get; set; }
        public string Notes { get; set; }
        
        [XmlIgnore]
        public byte[] Attachments { get; set; }

        [XmlIgnore]
        public virtual ICollection<Orders> Orders { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", Id);
            info.AddValue("Company", Company);
            info.AddValue("Last Name", LastName);
            info.AddValue("First Name", FirstName);
            info.AddValue("Email", EmailAddress);
            info.AddValue("Job Title", JobTitle);
            info.AddValue("Business Phone", BusinessPhone);
            info.AddValue("Home Phone", HomePhone);
            info.AddValue("Mobile Phone", MobilePhone);
            info.AddValue("Fax", FaxNumber);
            info.AddValue("Address", Address);
            info.AddValue("City", City);
            info.AddValue("State/Province", StateProvince);
            info.AddValue("ZIP/Postal Code", ZipPostalCode);
            info.AddValue("Country/Region", CountryRegion);
            info.AddValue("Webpage", WebPage);
            info.AddValue("Notes", Notes);
        }
    }
}
