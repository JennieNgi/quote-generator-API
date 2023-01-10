using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace quoteGeneratorAPI.Models {

    public class ImageUploader {

        // class constants for different errors while uploading
        public const int ERROR_NO_FILE = 0;
        public const int ERROR_TYPE = 1;
        public const int ERROR_SIZE = 2;
        public const int ERROR_NAME_LENGTH = 3;
        public const int ERROR_SAVE = 4;
        public const int SUCCESS = 5;

        // this is the file size limit in bytes that IFormFile approach can handle
        // do have the option to stream larger files - but is more complicated
        private const int UPLOADLIMIT = 4194304;

        // needed for getting path to web app's location
        private string targetFolder;
        // path to the upload folder
        private string fullPath;

        public ImageUploader(IWebHostEnvironment env, string myTargetFolder) {
            // initialization
            targetFolder = myTargetFolder;         

            // check to see if web app's root folder has an "uploads" folder - if not create it
            fullPath = env.WebRootPath + "/" + targetFolder + "/";
            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(fullPath);
            }
        }

        // --------------------------------------------------- public methods
        public int uploadImage(IFormFile file, string filename) {
            // If no file is found don't do anything
            if (file != null) {
                // checking to see what type of file has been uploaded
                string contentType = file.ContentType;
                if ((contentType == "image/png") || (contentType == "image/jpeg") || (contentType == "image/gif")) {

                    // getting the size of the file
                    long size = file.Length;
                    if ((size > 0) && (size < UPLOADLIMIT)) {
                        // get filename of selected file if provided - otherwise use original file's name
                        if (filename == "") filename = Path.GetFileName(file.FileName);
                        // check to make sure filename is under 100 characters
                        if (filename.Length <= 100) {
                            FileStream stream = new FileStream((fullPath + filename), FileMode.Create);
                            //Waiting for the file to be written to the server
                            try {
                                file.CopyTo(stream);
                                stream.Close();
                                return ImageUploader.SUCCESS;
                            } catch {
                                // if error occurs while uploading then return false; 
                                stream.Close();
                                return ImageUploader.ERROR_SAVE;
                            }
                        } else {
                            return ImageUploader.ERROR_NAME_LENGTH;
                        }
                    } else {
                        return ImageUploader.ERROR_SIZE;
                    }
                } else {
                    return ImageUploader.ERROR_TYPE;
                }
            } else {
                return ImageUploader.ERROR_NO_FILE;
            }
        }

        public int uploadImage(IFormFile file) {
            return uploadImage(file,"");
        }

    }

}