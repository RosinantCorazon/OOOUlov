//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OOOUlov
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int IDOrder { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Nullable<int> IDStatus { get; set; }
        public Nullable<int> IDSklad { get; set; }
        public Nullable<int> IDProd { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Sklad Sklad { get; set; }
        public virtual Status Status { get; set; }
    }
}
