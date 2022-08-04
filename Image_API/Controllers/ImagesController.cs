using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Image_API.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private static List<ImagesList> Images = new List<ImagesList>();

        [HttpPost]
        public async Task<ActionResult<List<ImagesList>>> AddImage(ImagesRequest imagesList)
        {
            try
            {
                byte[] imgBytes = Convert.FromBase64String(imagesList.strImageBase64.Replace("data:image/png;base64,", ""));

                using(var ms = new MemoryStream(imgBytes, 0, imgBytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                }

                return Ok(Images);
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}

