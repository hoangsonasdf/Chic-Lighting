﻿namespace projectchicandlighting.Request
{
    public class ListProductOrderRequest
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
