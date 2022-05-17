using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CleanBlog.DATA.EF;
using CleanBlog.UI.MVC.Utilities;

namespace CleanBlog.UI.MVC.Controllers
{
    public class BlogsController : Controller
    {
        private CleanBlogEntities db = new CleanBlogEntities();

        // GET: Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,BlogTitle,CreatedDate,BlogContent,BlogImage")] Blog blog, HttpPostedFileBase blogImage)
        {
            if (ModelState.IsValid)
            {

                #region File Upload

                string file = "NoImage.png";

                if (blogImage != null)
                {
                    file = blogImage.FileName;

                    string ext = file.Substring(file.LastIndexOf('.'));

                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".jif" };

                    if (goodExts.Contains(ext.ToLower()) && blogImage.ContentLength <= 4194304)
                    {
                        file = Guid.NewGuid() + ext;

                        #region Resize Image

                        string savePath = Server.MapPath("~/Content/img/");

                        Image convertedImage = Image.FromStream(blogImage.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                        #endregion
                    }

                    blog.BlogImage = file;
                }

                #endregion


                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Possible issue here

            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,BlogTitle,CreatedDate,BlogContent,BlogImage")] Blog blog, HttpPostedFileBase blogImage)
        {
            #region File Upload

            string file = "NoImage.png";

            if (blogImage != null)
            {
                file = blogImage.FileName;

                string ext = file.Substring(file.LastIndexOf('.'));

                string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                if (goodExts.Contains(ext.ToLower()) && blogImage.ContentLength <= 4194304)
                {
                    file = Guid.NewGuid() + ext;

                    #region Resize Image

                    string savePath = Server.MapPath("~/Content/img/");

                    Image convertedImage = Image.FromStream(blogImage.InputStream);

                    int maxImageSize = 500;

                    int maxThumbSize = 100;

                    ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                    #endregion

                    if (blog.BlogImage != null && blog.BlogImage != "NoImage.png")
                    {
                        string path = Server.MapPath("/Content/store_images/");
                        ImageUtility.Delete(path, blog.BlogImage);
                    }

                    blog.BlogImage = file;
                }
            }

            #endregion

            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);

            string path = Server.MapPath("~/Content/img/");
            ImageUtility.Delete(path, blog.BlogImage);

            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
