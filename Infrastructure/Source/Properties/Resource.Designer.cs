﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyExpenses.Infrastructure.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyExpenses.Infrastructure.Properties.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data.
        /// </summary>
        internal static string ColumnDate {
            get {
                return ResourceManager.GetString("ColumnDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incoming.
        /// </summary>
        internal static string ColumnIncoming {
            get {
                return ResourceManager.GetString("ColumnIncoming", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name.
        /// </summary>
        internal static string ColumnName {
            get {
                return ResourceManager.GetString("ColumnName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value.
        /// </summary>
        internal static string ColumnValue {
            get {
                return ResourceManager.GetString("ColumnValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expense.
        /// </summary>
        internal static string ExpenseTable {
            get {
                return ResourceManager.GetString("ExpenseTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Label.
        /// </summary>
        internal static string LabelTable {
            get {
                return ResourceManager.GetString("LabelTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Payment.
        /// </summary>
        internal static string PaymentTable {
            get {
                return ResourceManager.GetString("PaymentTable", resourceCulture);
            }
        }
    }
}
