using System;
using System.ComponentModel.DataAnnotations;


namespace MinhlndShop.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreateDate { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        public string UpdatedBy { get; set; }

        [MaxLength(256)]
        public string MetaKeyword { get; set; }
        [MaxLength(256)]
        public string MetaDescription { get; set; }

        public bool Status { get; set; } 

    }
}
