# Authress Starter Kit: C# + .NET (ASP MVC)
The C# Starter Kit for Authress includes Authentication, Authorization, user identity and role management

This is an example built specifically for using Authress with Typescript & Express.

## How to use this repository

### Install Dotnet
This repository is set up to use Dotnet 6.0 for its LTS support. It's easy to also switch this repo to using 7.0 instead, just making some quick adjustments to the following installs:

For dotnet 6.0:
```sh
sudo apt install dotnet-sdk-6.0 dotnet-hostfxr-6.0 dotnet-runtime-6.0 dotnet-runtime-deps-6.0 aspnetcore-runtime-6.0
```

For dotnet 7.0:
```sh
sudo apt install dotnet-sdk-7.0 dotnet-hostfxr-7.0 dotnet-runtime-7.0 dotnet-runtime-deps-7.0 aspnetcore-runtime-7.0
```
Also make sure to switch the version specified in the `launch.json` and in the `AuthressStarterKit.csproj` to 7.0 before running `dotnet restore`.

### Running the example:

```sh
cd src
dotnet restore
dotnet build
dotnet run
```

The service will then be running on `http://localhost:5000` by default
* And then use `curl` or `postman` to hit any of the endpoints.

```sh
curl -XGET http://localhost:5000/example-resource
```

## See the code
If you just want to see the code, it's available right here.

* [Program.cs](./src/Program.cs) - Boilerplate to run your service
* [AuthressConfiguration](./src/AuthressConfiguration.cs) - Configuration for Authress

There are three controllers, they all use Authress in some way to authorize the request and check the users permissions:
<!-- * [Accounts](./src/accounts/accountController.ts) - General creating an account and setting up SSO -->
* [ExampleResourceController](./src/ExampleResourceController.cs) - How to secure a reason creating access and updating it
<!-- * [Users](./src/users/usersController.ts) - Managing users for the whole account. -->

## Details

### The middleware
The important part of the integration is to get the userId and Authress client to authorize the user. This is done by adding a middleware to parse out the caller, and one line in the service to validate this.

* [Authentication Middleware](.src/Program.cs)
