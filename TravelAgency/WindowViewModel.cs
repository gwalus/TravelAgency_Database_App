using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class WindowViewModel
    {
        public Table TableName { get; set; }
        public ICollection TableContent { get; set; }
    }
}
