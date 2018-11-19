using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntityFrameworkCore.Procedure.Schema
{
    //
    // Summary:
    //     Represents the database column that a property is mapped to.
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ParamAttribute : Attribute
    {
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.Schema.ParamAttribute
        //     class.
        public ParamAttribute()
        {

        }
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.Schema.ParamAttribute
        //     class.
        //
        // Parameters:
        //   name:
        //     The name of the column the property is mapped to.
        public ParamAttribute(string name)
        {
            Name = name;
        }

        //
        // Summary:
        //     Gets the name of the column the property is mapped to.
        //
        // Returns:
        //     The name of the column the property is mapped to.
        public string Name { get; }
        //
        // Summary:
        //     Gets or sets the zero-based order of the column the property is mapped to.
        //
        // Returns:
        //     The order of the column.
        public int Order { get; set; }
        //
        // Summary:
        //     Gets or sets the database provider specific data type of the column the property
        //     is mapped to.
        //
        // Returns:
        //     The database provider specific data type of the column the property is mapped
        //     to.
        public SqlDbType Type { get; set; }
        //
        // Summary:
        //     Gets or sets the length of the column the property
        //     is mapped to.
        //
        // Returns:
        //     Length of the column the property is mapped
        //     to.
        public int AllowedLength { get; set; }
        //
        // Summary:
        //     Gets the name of the column the property is mapped to.
        //
        // Returns:
        //     The name of the column the property is mapped to.
        public bool Optional { get; set; }

    }
}
