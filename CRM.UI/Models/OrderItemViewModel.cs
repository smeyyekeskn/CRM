﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.UI.ViewModel
{
    public class OrderItemViewModel
    {
        public string SerialNumber { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime RegisterRequiredDate { get { return DateTime.Now; } }
    }
}