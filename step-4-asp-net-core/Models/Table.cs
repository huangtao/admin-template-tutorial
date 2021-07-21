using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapAdmin.Models
{
    public class Table
    {
        public String Id { get; set; }
        public String CreateUserId { get; set; }
        public String JsonData { get; set; }
        public DateTime CreateDate { get; set; }
        public int ClubId { get; set; }
    }

    public class EndTable
    {
        public String Id { get; set; }
        public String CreateUserId { get; set; }
        public String JsonData { get; set; }
        public DateTime EndDate { get; set; }
        public String Player1 { get; set; }
        public String Player2 { get; set; }
        public String Player3 { get; set; }
        public String Player4 { get; set; }
        public int ClubId { get; set; }
    }
}
