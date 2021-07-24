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
https://kiongamersapi.azurewebsites.net/
```
and our route holding the Swagger Documentation to display the end points and parameters.

### Account Controller:
#### Gamer and Fan Registraion :
**Post**
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
https://kiongamersapi.azurewebsites.net/api/Account 
```
 and the Server will response with Http Status Code **``201 Created``** that means the account with roles was registerd on database if not may they are same username in database or may other validation , Check error and try again  .  

---

#### User Login:
**Post**
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
https://kiongamersapi.azurewebsites.net/api/Account/login 
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
---
### Score Controller:
**Get**
#### ListAsync:
Is an Action to return all Scores in database if that scores belong to current user or  not is for analasis purose and to calculate the rank on game.
Hit the endpoint 
```Bash
https://kiongamersapi.azurewebsites.net/api/Score
```

```json
[
    {
        "id": "16bd9779-20ce-499c-2c63-08d94d5c4c3a",
        "scores": 900, //total scores for user
        "user": {
              "id": "664545-e28a-487-b922-cc3d214b9544",
              "firstName": "John",
              "lastName": "Doe",
              "username": "John2021",
              "email": "Johnfoe@example.com",
              "phoneNumber": null,
              "profilePict": null
        }
    }
]
```
--- 

**Get by Id**
It's same to ListAsync but rather than return a list of scors it's returns a single record for specified Id it's for details 
hit the endpoint below and send an id of score  
```Bash
https://kiongamersapi.azurewebsites.net/api/Score 
```
```json
{
    "id":"5c16daed-b43f-4032-f2c7-08d94d3449f0"
}
```
--- 
**Post**
Create new score linked to user the id is auto generated 
{
    "scores":600,
    "userid":"669154ec-e28a-4fe1-b922-cc3d271b9544"
}
the server will reponse with Status **``200 OK``**  and the new Created score
```json
{
    "id": "16bd9779-20ce-499c-2c63-08d94d5c4c3a",
    "scores": 600,
    "user": null
}
```
that means the score created successfully and returns an object of created score if not it will response with Error **``500 ``** ``Internal Server Error`` and will send the error messages to the `Log Files` that is the beuty of Logger Manager .

--- 

**Put**
Update an score , send the score object as a Put request to ``Score Controller`` 
{
    "id":"5c16daed-b43f-4032-f2c7-08d94d3449f0",
    "scores":300,
    "userid":"669154ec-e28a-4fe1-b922-cc3d271b9544"
}
the server will reponse with Status **``200 OK``** and the object of updated score with user profile .
```json 
{
    "id": "16bd9779-20ce-499c-2c63-08d94d5c4c3a",
    "scores": 900,
    "user": {
       
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
that means the score Updated successfully , if the request it fails the server will response with Error **``500 ``** ``Internal Server Error`` and will send the error messages to the `Log Files`.

**Delete**
Send the Same score object with **``Delete``** request and the server sadlly will responce with Status Code **``400``** ``Bad Request`` and message 
``Score has been deleted successfully.
``
it's work fine just the server response with error 400and we will fix that . 
## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.


