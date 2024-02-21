<p id="main" align="center">
  <img src="https://authress.io/static/images/linkedin-banner.png" alt="Authress media banner">
</p>

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

### Configure the example

Update `src/AuthressConfiguration.cs`:
* `AuthenticationProviderOAuthIssuerUrl` - to point to your JWT Authentication OAuth 2 provider's Issuer URL. If you are using Authress for development this is: `login.authress.io`, and for production it will be your [custom domain url](https://authress.io/app/#/settings?focus=domain).
* `AuthressApiHostUrl` - to point to your Authress account [Host API URL](https://authress.io/app/#/api).
* `ServiceClientAccessKey` - Create and configure an Authress Service Client Access Token. Generate one at [Authress service clients](https://authress.io/app/#/settings?focus=clients), or see the [service client access key documentation](https://authress.io/knowledge-base/docs/authorization/service-clients).

### Running the example:

```sh
cd src
dotnet restore
dotnet build
dotnet run
```

The service will then be running on `http://localhost:5000` by default
* And then use `curl` or `postman` to hit any of the endpoints.
* Grab your AUTHORIZATION_TOKEN from https://authress.io/app/#/api

```sh
curl -XGET http://localhost:5000/example-resource -H"Authorization: Bearer AUTHORIZATION_TOKEN"
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

## Troubleshooting issues

`Microsoft.IdentityModel.Tokens.SecurityTokenSignatureKeyNotFoundException: IDX10501: Signature validation failed. Unable to match key:`

There is a current bug with the implementation in ASP.NET MVC JWT Bearer token verification not accepting our more secure EdDSA tokens. The full extent of the issue is available in this [GitHub Issue](https://github.com/Authress/authress-sdk.cs/issues/20). For now, please just reach out to us at [Authress Support](https://authress.io/app/#/support), and we'll make a quick fix for you.
