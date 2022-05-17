using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Content")]
        public string BlogContent { get; set; }

        [Display(Name = "Image")]
        [StringLength(50, ErrorMessage = "* Field must be 50 characters or less")]
        [DisplayFormat(NullDisplayText = "-N/A-")]
        public string BlogImage { get; set; }

        
    }//end class

}//end namespace
