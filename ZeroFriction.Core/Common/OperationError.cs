﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFriction.Core.Common
{
    public record OperationError
    {
        public string Details { get; }

        public OperationError(string details) => (Details) = (details);
    }
}
