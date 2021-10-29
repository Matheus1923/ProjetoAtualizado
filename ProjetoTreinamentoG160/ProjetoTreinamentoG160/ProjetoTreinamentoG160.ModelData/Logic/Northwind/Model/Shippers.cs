//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoTreinamentoG160.ModelData.Logic.Northwind.Model
{
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ProjetoTreinamentoG160.ModelData.Logic.Northwind.MetaData;
    
    [Serializable]
    [MetadataType(typeof(ShippersMetaData))]
    
    public partial class Shippers
    {
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    	public Shippers()
    	{
    		this.Orders = new HashSet<Orders>();
    	}
    
    	public int ShipperID { get; set; }
    	public string CompanyName { get; set; }
    	public string Phone { get; set; }
    
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	public virtual ICollection<Orders> Orders { get; set; }
    }
}