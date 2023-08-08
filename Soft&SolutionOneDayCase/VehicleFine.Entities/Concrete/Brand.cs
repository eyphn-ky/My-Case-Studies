using System;
using System.Collections.Generic;
using VehicleFine.Entities.Abstract;
using VehicleFine.Entities.Concrete;
#nullable disable

namespace VehicleFine.Entities.Concrete
{
    public partial class Brand:IEntity
    {
        public Brand()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Brand1 { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
