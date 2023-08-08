using System;
using System.Collections.Generic;
using VehicleFine.Entities.Abstract;

#nullable disable

namespace VehicleFine.Entities.Concrete
{
    public partial class Vehicle: IEntity
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public int? OwnerId { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
