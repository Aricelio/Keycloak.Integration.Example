### **English**
This is a example of a .NET Api that integrates with a local keycloak service.

Steps to configure:
- Exec the command bellow:
  - ```docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:20.0.2 start-dev```
- Access the keycloak webpage on the brownser by entering the address ```localhost:8080```

### **Portuguese**
Esse é um exemplo de uma api .NET que se integra com um serviço local do keycloak.

Passos para configuração:
- Executar o container do keycloak via docker:
  - ```docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:20.0.2 start-dev```
- Acessar a página web do keycloak usando o endereço ```localhost:8080``` em um navegador web;
  - Criar um novo realm
  - Criar um client do tipo 'OpenID Connect'
  - Criar um client scope
    - Criar uma mapper do tipo audience para o escopo;
    - Associar o mapper ao client criado;
  - Dentro do client, na aba de escopos, adicionar o escopo ao client;
  - Criar um usuário e setar uma senha para ele;

- Testando:
  - Criar projeto .NET
    - Instalar dependencias
	    - KeyCloak.AuthServices.Authentication
	    - KeyCloak.AuthServices.Authorization
	    - IdentityModel.AspNetCore
	    - Refit.HttpClientFactory
   - No appsettings, adicionar uma chave com os dados do client, exemplo:
     - ```
          "Keycloak": {
          {
            "realm": "<my-realm>",
            "auth-server-url": "http://localhost:8080/",
            "ssl-required": "external",
            "resource": "<my-api-api-client>",
            "verify-token-audience": true,
            "credentials": {
              "secret": "<my-secret>"
            },
            "confidential-port": 0
          }
        }
       ````   
