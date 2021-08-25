using System;

namespace MinhlndShop.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreateDate { get; set; } 
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; } 
        string UpdatedBy { get; set; }
        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }
        bool Status { get; set; } 
        
    }
}
