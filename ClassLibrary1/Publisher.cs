﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ClassLibrary1
{
    [DataContract]
    public class Publisher
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
