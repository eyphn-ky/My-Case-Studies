using System;
using System.Collections.Generic;
using VehicleFine.Entities.Abstract;

#nullable disable

namespace VehicleFine.Entities.Concrete
{
    public partial class Owner: IEntity
    {
        public Owner()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
