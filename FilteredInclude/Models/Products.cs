﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FilteredInclude.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        /// <summary>
        /// This is the primary key for a single product
        /// </summary>
        [Key]
        public int ProductID { get; set; }
        /// <summary>
        /// This is the product name of the product
        /// </summary>
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public override string ToString() => ProductName;
    }
}