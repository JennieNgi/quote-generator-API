using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace quoteGeneratorAPI.Models {
    
    public class AdminManager {
        // database private variables
        private MySqlConnection dbConnection;
        private MySqlCommand dbCommand;
        private MySqlDataReader dbReader;
        private int _quoteCount = 0;

        public AdminManager() {
            // initialization
            dbConnection = new MySqlConnection(Connection.CONNECTION_STRING);
            dbCommand = new MySqlCommand("", dbConnection);
        }

        // ---------------------------------------------------------------------- get/set methods
        public Quote quote {get; set;} = new Quote();
        public string feedbackAdd {get; set;} = "";
        public string feedbackDel {get; set;} = "";

        public int quoteCount {
            get {
                return _quoteCount;
            }
        }

        // ---------------------------------------------------------------------- public methods
        public bool add(IWebHostEnvironment env, IFormFile selectedFile) {
            // construct ImageUploader object to do all the heavy lifting
            ImageUploader imageUploader = new ImageUploader(env, "images");
            
            // set filename of file to be random
            string filename = "";
            // check if user forgot to select a file with open dialog
            if (selectedFile != null) {
                Random random = new Random();
                // append on a random four digits to the beginning of the image filename to avoid overwrite of images of same name
                filename = random.Next(1, 10).ToString() + random.Next(1, 10).ToString() + random.Next(1, 10).ToString() + random.Next(1, 10).ToString() + selectedFile.FileName;
            }

            // carrying out uploading
            int result = imageUploader.uploadImage(selectedFile, filename);

            // set feedback on upload if error
            if (result == ImageUploader.ERROR_NO_FILE) feedbackAdd = "Error : Please select a file for uploading";
            else if (result == ImageUploader.ERROR_NAME_LENGTH) feedbackAdd = "Error : filename must be less than 100 characters";
            else if (result == ImageUploader.ERROR_SAVE) feedbackAdd = "Error : issue with saving file";
            else if (result == ImageUploader.ERROR_SIZE) feedbackAdd = "Error : file size is too large";
            else if (result == ImageUploader.ERROR_TYPE) feedbackAdd = "Error : Incompatable file type";
            
            if (result != ImageUploader.SUCCESS) return false;

            // quote image successfully uploaded - update source property of quote object
            quote.image = filename;

            // update database
            try {
                dbConnection.Open();

                // no need to HTML encode input since ASP.NET Core automatically does this when displaying any value in the model
                dbCommand.CommandText = "INSERT INTO tblQuotes (author,quote,permalink,image) VALUES (?author,?quote,?permalink,?image)";
                dbCommand.Parameters.Clear();
                dbCommand.Parameters.AddWithValue("?author", quote.author);
                dbCommand.Parameters.AddWithValue("?quote", quote.quote);
                dbCommand.Parameters.AddWithValue("?permalink", quote.permalink);
                dbCommand.Parameters.AddWithValue("?image", quote.image);
                // add record to db
                dbCommand.ExecuteNonQuery();

                // update feedback
                feedbackAdd = "Quote with image " + selectedFile.FileName + " has been added";
            } finally {
                // close connection
                dbConnection.Close();
            }
            return true;
        }

        public void delete(IWebHostEnvironment env) {
            try {
                dbConnection.Open();

                // grab filename of quote to delete before deleting
                dbCommand.CommandText = "SELECT image FROM tblQuotes WHERE id = ?id";
                dbCommand.Parameters.AddWithValue("?id", quote.id);
                string image = dbCommand.ExecuteScalar().ToString();

                // clear out command object or else it complains about ?id being used twice
                dbCommand.Parameters.Clear();

                // SQL string construction
                dbCommand.CommandText = "DELETE FROM tblQuotes WHERE id = ?id";
                dbCommand.Parameters.AddWithValue("?id", quote.id);
                // delete record from db
                dbCommand.ExecuteNonQuery();
                // delete image from folder
                File.Delete(env.WebRootPath + "/images/" + image);
                // update feedback
                feedbackDel = "Quote with image '" + image + "' has been deleted";
            } finally {
                // close connection
                dbConnection.Close();
            }
        }

        public List<SelectListItem> getQuoteList() {
            // construct list of SelectListItems for dropdown population
            List<SelectListItem> list = new List<SelectListItem>();
            try {
                dbConnection = new MySqlConnection(Connection.CONNECTION_STRING);
                dbConnection.Open();
                dbCommand = new MySqlCommand("SELECT id,quote FROM tblQuotes", dbConnection);
                dbReader = dbCommand.ExecuteReader();
                while (dbReader.Read()) {
                    SelectListItem item = new SelectListItem();

                    // display maximum 50 characters of quote in drop down
                    string quote = dbReader["quote"].ToString();
                    if (quote.Length < 50) quote = quote + "...";
                    else quote = quote.Substring(0,50) + "...";
                    
                    item.Text = quote;
                    item.Value = dbReader["id"].ToString();
                    list.Add(item);
                }
            } finally {
                _quoteCount = list.Count;
                dbConnection.Close();
            }

            return list;
        }
        
    }
}