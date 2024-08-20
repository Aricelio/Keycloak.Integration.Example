using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk.Admin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Keycloak authentication
var authOptions = builder
    .Configuration
    .GetSection(KeycloakAuthenticationOptions.Section)
    .Get<KeycloakAuthenticationOptions>();

builder.Services.AddKeycloakAuthentication(authOptions);

// Keycloak authorization
var clientOptions = builder
    .Configuration
    .GetSection(KeycloakProtectionClientOptions.Section)
    .Get<KeycloakProtectionClientOptions>();

builder.Services.AddKeycloakAuthorization(clientOptions);

// Keycloak admin client
var adminOption = builder
    .Configuration
    .GetSection(KeycloakAdminClientOptions.Section)
    .Get<KeycloakAdminClientOptions>();

builder.Services.AddKeycloakAdminHttpClient(adminOption);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();