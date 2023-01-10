using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace quoteGeneratorAPI.Models {

    public class APIManager {
        // database connectivity variables
        private MySqlConnection dbConnection; 
        private MySqlCommand dbCommand;
        private MySqlDataReader dbReader; 

        public APIManager() {
        }

        public List<Quote> getQuotes(int count) {
            try {
                // connect to database
                dbConnection = new MySqlConnection(Connection.CONNECTION_STRING);
                dbConnection.Open();
            
                // construct data adapter and setup with SQL to use with the database
                // SQL randomly selects records based on ordering by rand() function
                dbCommand = new MySqlCommand("SELECT * FROM tblQuotes ORDER BY RAND() LIMIT ?count;", dbConnection);
                dbCommand.Parameters.AddWithValue("?count", count);
                dbReader = dbCommand.ExecuteReader();

                // construct temporary List 
                List<Quote> quotes = new List<Quote>();    
                
                // scroll through all records
                while (dbReader.Read()) {                
                    Quote newQuote = new Quote();
                    newQuote.id = Convert.ToInt32(dbReader["id"]);
                    newQuote.author = dbReader["author"].ToString();
                    newQuote.quote = dbReader["quote"].ToString();
                    newQuote.permalink = dbReader["permalink"].ToString();
                    newQuote.image = dbReader["image"].ToString();

                    quotes.Add(newQuote);
                }
                
                return quotes;

            } catch (Exception e) {
                Console.WriteLine(">>> An error has occured with quote data");
                Console.WriteLine(">>> " + e.Message);
            } finally {
                // close db connection
                dbConnection.Close();
            }

            return null;
        }
    }
}