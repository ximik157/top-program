//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace top_project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Messages
    {
        public long id { get; set; }
        public string text { get; set; }
        public long owner_id { get; set; }
        public long receiver_id { get; set; }
        public string attachment { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
