using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App2
{[DataContract]
    class Player_history
    {
        [DataMember]
        public String name  { get; set; }
        [DataMember]
        public int King { get; set; }
        [DataMember]
        public int subking { get; set; }
        [DataMember]
        public int subkooz { get; set; }
        [DataMember]
        public int kooz { get; set; }
        public Player_history(String name , int King, int subking,int subkooz, int kooz)
        {
            this.name = name;
            this.King = King;
            this.subking = subking;
            this.subkooz = subkooz;
            this.kooz = kooz;

        }
        public Player_history()
        { }
    }
}
