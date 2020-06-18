using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace smiqs.Model
{
    public class Subscription
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime SubscribedDate { get; set; }
        public bool isActive { get; set; }

        public Subscription()
        {

        }
    }
}
