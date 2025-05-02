

namespace OrderManagement.RazorWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Size { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public string? Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
