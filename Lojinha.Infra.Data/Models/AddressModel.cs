﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postal_code { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string County { get; set; }

    }
}
