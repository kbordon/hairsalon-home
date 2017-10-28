# Hair Salon
### A Hair Salon Management Application for Epicodus C# Database Basics Code Review _10.27.2017_

#### By Kimberly Bordon

## Description
_This is an application that exercises the basics of accessing databases and one-to-many relationships using C# and MySql. The application allows the user to manage the stylists, and the stylists' clients of a specific hair salon._

# Specs
|Behavior|Input|Output|
|-|-|-|
|The app will start user at the hair salon homepage to either add or view the current stylists.| The user goes to homepage.| The user is presented with homepage with title, and two links to either add or view current stylists.|
| Will allow user to see all the hair salon's current stylist. | The user clicks "View Stylists" link on the homepage. | The user is taken to new page that lists all stylists |
| Will allow user to go to form to enter a new stylist's information. | The user clicks "Add a Stylist" link on homepage. | The user is taken to a new page with a form to enter the new stylist. |
| Will allow user to fill form and add a stylist to list of stylist. | User enters: <br><br>Dylan Brook<br>503-444-6745<br><br> User clicks Submit | The user is taken to list of stylists, with newly added stylist. |
| Will allow user to select a stylist from the list, and see their information and clients. | User clicks a stylist name. | The user is taken to stylist's detail page, including list of client if they have any. |
| Will allow user to select a client from the stylist's list of current clients, and see their information. | User clicks a client's name. | The user is shown client's information. |
| Will allow user to add new clients to a stylist's client list. | User clicks "Add a Client" on stylist's detail page. | The user is taken to page with a client form. |
| Will allow user to fill out client information, and add client. | User enters:<br><br>Dahlia Miyazaki<br>503-859-3324<br><br> User clicks Submit | The user is taken to stylist's page of that client with client newly added to client list. |
| Will allow user to update a client's information details. | User clicks on edit link on the client's information, and enters new information.<br><br>User clicks Submit. | The client's information is updated, and the user is taken back to stylist page with new client information shown.|
| Will allow user to delete a client that no longer visits the salon. | User clicks on client's name on stylist's page. User clicks on "Delete" button on client's information page. | User is taken back to stylist page with list of clients without just removed client. |

## Setup/Installation Requirements
* Enter the URL: https://github.com/kbordon/csharp-week3-code-review-hairsalon in your browser.
* Using your terminal or powershell, clone this repository by typing ```>git clone https://github.com/kbordon/csharp-week3-code-review-hairsalon.git```
    * Alternatively, you can use a browser to download the .zip file from the Github web interface at the URL: https://github.com/kbordon/csharp-week3-code-review-hairsalon.git
* To look at project code, navigate to the project folder csharp-week3-code-review-hairsalon, and use a text editor like Atom to open the README.md.
* To run application:
  * Make sure you have [.NET Core 1.1 SDK (Software Development Kit)](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe) and [.NET runtime](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe) both installed.
  * Before you can use the app, you must have the proper database setup by following these commands:
  ```SQL
  >CREATE DATABASE kimberly_bordon;
  >USE kimberly_bordon;
  >CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), phone VARCHAR(255));
  >CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), phone VARCHAR(255), INT stylist_id);
  ```
  * Using powershell or terminal, navigate t ocsharp-week3-code-review-hairsalonfolder. Then enter the following commands:
  ```
  >cd HairSalon.Solution
  >cd HairSalon
  >dotnet restore
  >dotnet run```
  * Then, on your browser, go to the URL address: localhost:5000 or, whichever server your app might be running on.
  * Use the buttons, and forms to navigate the app.
  * Once you're finished, close the browser and turn off the server by entering <kbd>Ctrl</kbd> + <kbd>C</kbd> on your powershell or terminal.

## Known Bugs
* When listing phone numbers, should a zip code be entered starting with a zero, the number may be listed without the zero as it is converted into a number, and will lose the beginning zero.

## Support and contact details

_If you have any questions, comments, or concerns, please contact Kimberly at [kbordon@gmail.com](mailto:kbordon@gmail.com)._

## Technologies Used

* Atom
* GitHub
* Gitbash
* C#
* CSS
* .NET framework
* MySql

### License

*This software is licensed under the MIT license.*

Copyright © 2017 **_Kimberly Bordon_**
