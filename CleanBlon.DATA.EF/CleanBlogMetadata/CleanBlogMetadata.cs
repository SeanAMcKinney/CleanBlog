using System;
using System.ComponentModel.DataAnnotations;

namespace CleanBlog.DATA.EF/*.CleanBlogMetadata*/
{
    class BlogMetadata
    {
        //public int BlogId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Title")]
        [StringLength(200, ErrorMessage = "* Field must be 200 characters or less")]
        public string BlogTitle { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Content")]
        public string BlogContent { get; set; }

        [Display(Name = "Image")]
        [StringLength(50, ErrorMessage = "* Field must be 50 characters or less")]
        [DisplayFormat(NullDisplayText = "-N/A-")]
        public string BlogImage { get; set; }

        [MetadataType(typeof(BlogMetadata))]
        public partial class Blog { }
        
    }//end class

}//end namespace
