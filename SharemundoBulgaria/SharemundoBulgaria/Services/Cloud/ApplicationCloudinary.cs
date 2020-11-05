﻿namespace SharemundoBulgaria.Services.Cloud
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class ApplicationCloudinary
    {
        public static async Task<string> UploadImage(Cloudinary cloudinary, IFormFile image, string name)
        {
            if (image != null)
            {
                byte[] destinationImage;
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using (var ms = new MemoryStream(destinationImage))
                {
                    // Cloudinary doesn't work with [?, &, #, \, %, <, >]
                    name = name.Replace("&", "And");
                    name = name.Replace("#", "sharp");
                    name = name.Replace("?", "questionMark");
                    name = name.Replace("\\", "right");
                    name = name.Replace("%", "percent");
                    name = name.Replace(">", "greater");
                    name = name.Replace("<", "lower");

                    var uploadParams = new RawUploadParams()
                    {
                        File = new FileDescription(name, ms),
                        PublicId = name,
                    };

                    var uploadResult = cloudinary.Upload(uploadParams);
                    return uploadResult.SecureUri.AbsoluteUri;
                }
            }

            return null;
        }

        public static void DeleteImage(Cloudinary cloudinary, string name)
        {
            var delParams = new DelResParams()
            {
                PublicIds = new List<string>() { name },
                Invalidate = true,
                ResourceType = ResourceType.Raw,
            };

            cloudinary.DeleteResources(delParams);
        }
    }
}