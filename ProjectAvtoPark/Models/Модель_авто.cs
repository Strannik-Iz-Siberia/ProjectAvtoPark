//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectAvtoPark.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Модель_авто
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Модель_авто()
        {
            this.Автомобиль = new HashSet<Автомобиль>();
        }
    
        public int id_Модель { get; set; }
        public string Название { get; set; }
        public Nullable<int> id_марка { get; set; }
        public Nullable<int> id_тип_кузова { get; set; }
        public Nullable<int> id_год_выпуска { get; set; }
        public Nullable<int> id_КПП { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Автомобиль> Автомобиль { get; set; }
        public virtual Год_выпуска Год_выпуска { get; set; }
        public virtual КПП КПП { get; set; }
        public virtual Марка_авто Марка_авто { get; set; }
        public virtual Тип_кузова Тип_кузова { get; set; }
    }
}
