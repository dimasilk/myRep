//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OmertexBusTicketsSystem.BL.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpecifiedVoyage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SpecifiedVoyage()
        {
            this.Order = new HashSet<Order>();
            this.Ticket = new HashSet<Ticket>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Id_BusStopDeparture { get; set; }
        public Nullable<int> Id_BusStopArrival { get; set; }
        public Nullable<System.DateTime> DatetimeDeparture { get; set; }
        public Nullable<System.DateTime> DatetimeArrival { get; set; }
        public Nullable<long> TravelTime { get; set; }
        public string VoyageName { get; set; }
        public Nullable<int> VoyageNumber { get; set; }
        public Nullable<int> NumberOfSeats { get; set; }
        public Nullable<int> TicketCost { get; set; }
    
        public virtual Busstop BusstopArrival { get; set; }
        public virtual Busstop BusstopDeparture { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
