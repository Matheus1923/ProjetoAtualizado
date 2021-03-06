//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoTreinamentoG160.ModelData.Logic.Northwind.MetaData
{
    
    using System; 
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// Customers class MetaData
    /// </summary>
    public partial class CustomersMetaData
    {
        [DisplayName("Customer ID")]
        [Required(ErrorMessage = "Customer ID is required")]
        [MaxLength(5, ErrorMessage = "Customer ID cannot be longer than 5 characters")]
        public string CustomerID { get; set; }
       
        [DisplayName("Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        [MaxLength(40, ErrorMessage = "Company Name cannot be longer than 40 characters")]
        public string CompanyName { get; set; }
       
        [DisplayName("Contact Name")]
        [MaxLength(30, ErrorMessage = "Contact Name cannot be longer than 30 characters")]
        public string ContactName { get; set; }
       
        [DisplayName("Contact Title")]
        [MaxLength(30, ErrorMessage = "Contact Title cannot be longer than 30 characters")]
        public string ContactTitle { get; set; }
       
        [DisplayName("Address")]
        [MaxLength(60, ErrorMessage = "Address cannot be longer than 60 characters")]
        public string Address { get; set; }
       
        [DisplayName("City")]
        [MaxLength(15, ErrorMessage = "City cannot be longer than 15 characters")]
        public string City { get; set; }
       
        [DisplayName("Region")]
        [MaxLength(15, ErrorMessage = "Region cannot be longer than 15 characters")]
        public string Region { get; set; }
       
        [DisplayName("Postal Code")]
        [MaxLength(10, ErrorMessage = "Postal Code cannot be longer than 10 characters")]
        public string PostalCode { get; set; }
       
        [DisplayName("Country")]
        [MaxLength(15, ErrorMessage = "Country cannot be longer than 15 characters")]
        public string Country { get; set; }
       
        [DisplayName("Phone")]
        [MaxLength(24, ErrorMessage = "Phone cannot be longer than 24 characters")]
        public string Phone { get; set; }
       
        [DisplayName("Fax")]
        [MaxLength(24, ErrorMessage = "Fax cannot be longer than 24 characters")]
        public string Fax { get; set; }
       
    }
}
