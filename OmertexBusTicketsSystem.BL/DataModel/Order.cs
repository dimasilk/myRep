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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Ticket = new HashSet<Ticket>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Id_SpecifiedVoyage { get; set; }
        public Nullable<int> Id_Status { get; set; }
        public string Id_User { get; set; }
    
        public virtual SpecifiedVoyage SpecifiedVoyage { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
