using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class Bill
    {
        private DateTime billingtime;
        private float amountpaid;

        public Bill(DateTime billingtime, float amountpaid)
        {
            this.billingtime = billingtime;
            this.amountpaid = amountpaid;
        }

        public DateTime Billingtime { get => billingtime; set => billingtime = value; }
        public float Amountpaid { get => amountpaid; set => amountpaid = value; }
    }
}
