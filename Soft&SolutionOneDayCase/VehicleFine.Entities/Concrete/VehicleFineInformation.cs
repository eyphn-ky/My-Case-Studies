using System;
using System.Collections.Generic;
using VehicleFine.Entities.Abstract;

#nullable disable

namespace VehicleFine.Entities.Concrete
{
    public partial class VehicleFineInformation: IEntity
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public int? VehicleFineReasonId { get; set; }
        public int? VehicleFineStatusId { get; set; }
        public DateTime? VehicleFineRealizationDate { get; set; }
        public decimal? Cost { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual VehicleFineReason VehicleFineReason { get; set; }
        public virtual VehicleFineStatus VehicleFineStatus { get; set; }
    }
}
