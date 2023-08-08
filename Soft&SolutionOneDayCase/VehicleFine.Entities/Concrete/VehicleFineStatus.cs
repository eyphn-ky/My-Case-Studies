﻿using System;
using System.Collections.Generic;
using VehicleFine.Entities.Abstract;

#nullable disable

namespace VehicleFine.Entities.Concrete
{
    public partial class VehicleFineStatus: IEntity
    {
        public int Id { get; set; }
        public string Detail { get; set; }
    }
}
