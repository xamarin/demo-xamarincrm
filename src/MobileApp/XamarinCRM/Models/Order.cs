﻿using System;
using Newtonsoft.Json;

namespace XamarinCRM.Models
{
    public class Order : BaseModel
    {
        public Order() : base()
        {
            AccountId = string.Empty;

            //New orders default to open status. 
            IsOpen = true;
            Item = string.Empty;
            OrderDate = DateTime.UtcNow;
            ClosedDate = null; // Is never shown unless order is closed, in which case this should have a sane value.
            DueDate = DateTime.UtcNow.AddDays(7);
            Price = 0;
        }

        [JsonProperty(PropertyName = "is_open")]
        public bool IsOpen { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public string AccountId { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "item")]
        public string Item { get; set; }

        [JsonProperty(PropertyName = "order_date")]
        public DateTime OrderDate { get; set; }

        [JsonProperty(PropertyName = "due_date")]
        public DateTime DueDate { get; set; }

        [JsonProperty(PropertyName = "closed_date")]
        public DateTime? ClosedDate { get; set; }

        [JsonIgnore]
        public string Status
        {
            get { return (IsOpen) ? TextResources.Customers_OrderOpen : TextResources.Customers_OrderClosed; }

        }
    }
}
