//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleanBlog.DATA.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string BlogContent { get; set; }
        public string BlogImage { get; set; }
    }
}
