using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ReturnData
    {
        public int numberRecords {  get; set; }
        public int currentPage { get; set; }
        public int maxPage { get; set; }
        public object? Data { get; set; }
    }
}
