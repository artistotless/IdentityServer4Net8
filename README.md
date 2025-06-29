# IdentityServer4Net8

## Description

This is a port of the well-known **IdentityServer4** library to **.NET 8.0**. This library provides an implementation of OpenID Connect and OAuth 2.0 server for ASP.NET Core.

Previously, the library worked on **.NET Core 3.1** and did not support newer versions of .NET. This project ensures compatibility with the modern .NET 8.0 ecosystem.

## Features

- ✅ Full compatibility with **.NET 8.0**
- ✅ **OpenID Connect** and **OAuth 2.0** support
- ✅ **ASP.NET Core Identity** integration
- ✅ **Entity Framework Core** support for data storage
- ✅ Built-in caching support
- ✅ Ready-to-use In-Memory storage providers
- ✅ Mutual TLS (mTLS) support
- ✅ Local API Authentication integration

## Components

The project includes the following main components:

### Core Libraries
- **IdentityServer4** - Main identity server library
- **IdentityServer4.Storage** - Data storage abstractions
- **IdentityServer4.AspNetIdentity** - ASP.NET Core Identity integration
- **IdentityServer4.EntityFramework** - Entity Framework provider
- **IdentityServer4.EntityFramework.Storage** - EF Core data models

### Key Capabilities
- Client and resource management
- User authentication and authorization
- Token issuance and validation
- Support for various grant types
- Token introspection
- Token revocation
- Device Flow for devices with limited interface

## Requirements

- **.NET 8.0** or higher
- **ASP.NET Core 8.0**
- Compatible database (when using Entity Framework)

## Quick Start

### 1. Installation

```bash
# Clone repository
git clone https://github.com/artistotless/IdentityServer4Net8.git
cd IdentityServer4Net8
```

### 2. Build Project

```bash
dotnet build
```

### 3. Configuration

Add IdentityServer to your ASP.NET Core project:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddIdentityServer()
        .AddInMemoryClients(Config.Clients)
        .AddInMemoryApiScopes(Config.ApiScopes)
        .AddInMemoryIdentityResources(Config.IdentityResources)
        .AddDeveloperSigningCredential();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseIdentityServer();
}
```

## Migration from .NET Core 3.1

When migrating from the original IdentityServer4 version on .NET Core 3.1:

1. Update target framework to .NET 8.0
2. Update ASP.NET Core dependencies to version 8.0
3. Check configuration - most settings remain unchanged
4. Test all endpoints and functionality

## Documentation

For detailed documentation on using IdentityServer4, refer to:
- [Official IdentityServer4 Documentation](https://identityserver4.readthedocs.io/)
- [Samples and Code Examples](https://github.com/IdentityServer/IdentityServer4.Samples)

## Support

If you have questions or issues:
1. Create an Issue in this repository
2. Refer to the original project documentation
3. Check compatibility with .NET 8.0

## License

This project inherits the license from the original IdentityServer4. See the LICENSE file for details.

## Contributing

We welcome contributions to the project:
1. Fork the repository
2. Create a branch for your feature
3. Commit your changes
4. Submit a Pull Request

---

**Important**: This project is an unofficial port of IdentityServer4 to .NET 8.0. Use it at your own risk in production environments.
