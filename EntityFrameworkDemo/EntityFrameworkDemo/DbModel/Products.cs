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
    public partial class Products : ISerializable
    {
        public Products()
        {
            InventoryTransactions = new HashSet<InventoryTransactions>();
            OrderDetails = new HashSet<OrderDetails>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }

        public string SupplierIds { get; set; }
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int? ReorderLevel { get; set; }
        public int? TargetLevel { get; set; }
        public string QuantityPerUnit { get; set; }
        public bool Discontinued { get; set; }
        public int? MinimumReorderQuantity { get; set; }
        public string Category { get; set; }

        [XmlIgnore]
        public byte[] Attachments { get; set; }

        [XmlIgnore]
        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }

        [XmlIgnore] 
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        [XmlIgnore] 
        public virtual ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", SupplierIds);
            info.AddValue("Company", Id);
            info.AddValue("Last Name", ProductCode);
            info.AddValue("First Name", ProductName);
            info.AddValue("Email", Description);
            info.AddValue("Job Title", StandardCost);
            info.AddValue("Business Phone", ListPrice);
            info.AddValue("Home Phone", ReorderLevel);
            info.AddValue("Mobile Phone", TargetLevel);
            info.AddValue("Fax", QuantityPerUnit);
            info.AddValue("Address", Discontinued);
            info.AddValue("City", MinimumReorderQuantity);
            info.AddValue("State/Province", Category);
            
        }
    }
}
