using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Web_Client.Areas.Admin.Controllers
{
    public class UploadImage : Controller
    {
        public static IWebHostEnvironment _hostingEnvironment;

        public UploadImage(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile image)
        {
            try
            {
                string path = "Upload/";

                //get abs path of wwwroot
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, path);

                string relPath = null;

                //if not exists path, create it
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }


                if (image != null && image.Length > 0)
                {


                    //rename file b_Cover by b_ID
                    string namefile = image.FileName;

                    // absPath/fileName

                    string absPathCover = Path.Combine(uploads, namefile);


                    using (var stream = System.IO.File.Create(absPathCover))
                    {
                        //Copy file to path
                        await image.CopyToAsync(stream);
                    }

                    // relPath to store database
                    relPath = "/" + path + "/" + namefile;
                }

                return Json(new { status = "success", path = relPath });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });

            }
        }


    }
}
