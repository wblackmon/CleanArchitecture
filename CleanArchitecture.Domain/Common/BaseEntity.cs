﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
