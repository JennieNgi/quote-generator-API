![quoteGenerator](https://user-images.githubusercontent.com/75710628/223285741-99c6915c-927c-4bc0-ada4-60e401426050.png)
# Quote Generator
This is a web application that generates random quotes using a custom Web API. It includes two web apps, one for the Quote Generator itself, and one for an administration interface that allows you to add and remove quotes.

## Getting Started
To get started with the Quote Generator, you'll need to do the following:
- Clone the repository
- cd to the project folder
- run 
```sh
docker-compose run
```
- open another termimal and run
```sh
dotnet run start
```
This will start both the Quote Generator and Administration web apps in your browser.

## Usage
The Quote Generator allows you to generate random quotes using the custom Web API. It includes the following features:

- Generates a set number of distinct random quotes based on a route parameter
- Returns the quotes in JSON data format
- Includes the following fields: id, author, quote, permalink, and image
- The Quote Generator uses a MySQL database to store the quote data.

Administration Web App
The Administration Web App allows you to add and remove quotes from the MySQL database. It includes the following features:
- User-friendly interface for adding and deleting quotes
- Validates form inputs to ensure that author, quote, and image fields are required
- Allows for optional links to be validated as proper URLs
- Allows for image files to be validated based on file type, size, and name length
- Prevents duplicate images from overwriting each other
- Informs the user when a quote has been successfully added or deleted

## Built With
- ASP.NET Core
- MySQL
- Bootstrap
- Docker

## Author
Jenny Ngi
