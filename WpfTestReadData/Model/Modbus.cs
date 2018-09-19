using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestReadData
{
    class Modbus
    {
        public int DeviceID { get; set; }
        public string RiD { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }      

    }

    //public class Account
    //{
    //    public string Email { get; set; }
    //    public bool Active { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public IList<string> Roles { get; set; }
    //}
}
