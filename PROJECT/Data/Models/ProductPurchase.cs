﻿namespace PROJECT.Data.Models
{
    public class ProductPurchase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
    }
}
