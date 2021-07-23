# Gamers and Fans API

Is a .Net5 API for registering Gamers and their Scores and registering Fans for KIONCM game.
So the user can register credentials and the role then the API will response with a Status Code 201 that user created , in other hand they are three types of users (Gamer , Fan , Admin )


## Installation

Download and install [.Net5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) and 
[ MS SQL Server 2019](https://go.microsoft.com/fwlink/?linkid=866658) to get your environment ready to run the API. 

## Configure Database 
After installing the SDK and SQL Server Express be sure for the SQL Server Authentication the username must be ``SA`` and Password must be ``MSSQL2019@`` and type in package-manager console 
```Bash
update-database
```
That command will build the database automatically on SQL Server ,
if you finished migration without any kind of errors , GamersAndFansAPI and excute command 
```bash
dotnet run --project GamersAndFansAPI
```

## Usage
**Notes:** All coming routes specific Domain name and port is for test purpose only(will changing after build to production).
  
#### API Documentation :

First End Point that in our api is the root route  
```bash 
https:localhost:5001/API/
--------------------------------
http://localhost:5000/swagger/index.html
```
and our route holding the Swagger Documentation to display the end points and parameters.

#### Gamer and Fan Registraion :

>#### Requirements in registration User Object 
>- Username "has validation on using Characters and numbers."  
>- First name and last name are required .
>- Password is required and it must contains Upper-case and lower-case with numbers and digits.
>- Profiole Picture Method is not implemented yet . it will be in next update .
>- Roles is mandatory and it's in a Many to Many relation ships 

```json
{
    "username": "John2021",// Username Validations
    "firstname": "John",
    "lastname": "Doe",
    "email": "JohnDoe@example.com",
    "password": "Password12@", // password Validations
    "pofilePicture": null,
    "roles": "gamer" //Gamer , Fan , Admin
}
```

For the register operation a **``Post``** request contains an object of user send to ``AccountController`` as Request Body to the end point
```Bash
https:localhost:5001/API/Account 
```
 and the Server will response with Http Status Code **``201 Created``** that means the account with roles was registerd on database if not may they are same username in database or may other validation , Check error and try again  .  

---

#### User Login:

>#### Requirements in Login Object 
>- Username. 
>- Password.

```json
{
    "username": "John2021",
    "password": "Password12@",
}
```
Login is simple a **``Post``** request contains an object of user send to ``AccountController`` `Login Method ` as Request Body to the end point
```Bash
https:localhost:5001/API/Account/login 
```
 and the Server will response with Http Status Code **``OK 200``** and returns **``Access Token``** and user profile if it's authenticated or returns Status Code **``401 UnAutherized ``** if the user not found on authentication manager or returns the error with ``Username or password not found ! `` .
#### Response from Login request 
```Json

{
 "token": "eyJhbGciOiJIUzI1NtrtryghfCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiT3NhbWExMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29hfghfMvMjAwOC8wNi9pZGVudGlsdffFpbXMvcm9sZSI6IkdhbWVyIiwigdfgNjI5NTg5MzczLCJpc3MiOiJJbkJveCIsImF1ZCgdfdxob3N0OjUwgdfgdbpL3zGQLXspnQEa-bZG_gdfgc3knCM",
    "userProfile": {
        "id": "664545-e28a-487-b922-cc3d214b9544",
        "firstName": "John",
        "lastName": "Doe",
        "username": "John2021",
        "email": "Johnfoe@example.com",
        "phoneNumber": null,
        "profilePict": null
    }
}
```


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
