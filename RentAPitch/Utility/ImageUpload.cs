namespace RentAPitch.Utility
{
    public class ImageUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string SaveImageFile(IFormFile ImageUrl)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string uploadPath = Path.Combine(webRootPath, "upload");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }


            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName); // Error
            var filePath = Path.Combine(uploadPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                ImageUrl.CopyTo(fileStream);
            }
            return Path.Combine("upload", fileName);
        }



    }
}
