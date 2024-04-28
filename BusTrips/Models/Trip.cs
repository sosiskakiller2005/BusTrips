//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusTrips.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trip()
        {
            this.Ticket = new HashSet<Ticket>();
        }
    
        public int Id { get; set; }
        public int RouteId { get; set; }
        public System.DateTime DateTimeOfDeparture { get; set; }
        public System.DateTime DateTimeOfArrival { get; set; }
        public int BusId { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public int EmptySeats { get; set; }
    
        public virtual Bus Bus { get; set; }
        public virtual Route Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
