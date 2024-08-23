## **English**
This is a example of a .NET Api that integrates with a local keycloak service.

#### Steps to configure:
- Exec the command bellow:
  - ```docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:20.0.2 start-dev```
- Access the keycloak webpage on the brownser by entering the address ```localhost:8080```
  - Create a new realm;
  - Create a new client with the type 'OpenID Connect';
  - Create a new scope, inside of the scope:
    - Create a new mapper with the type 'Audience';
    - Associate the mapper to the client created previously;
  - Come back to the client, in the scopes tab, add the scope to the client;
  - Create a new user and set for him a new password;
 
#### Configure the application:
- Create a simple .NET Api project;
  - Install the dependencies below:
    - KeyCloak.AuthServices.Authentication
    - KeyCloak.AuthServices.Authorization
    - IdentityModel.AspNetCore
    - Refit.HttpClientFactory
- In the AppSettings file, add a new key with the client data, example:
  ```
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
  ```
- In Program Class, set the dependency injection for the keycloak;
- In Controller class, add the 'Authorize' tag;

#### Testing:
- On some http request app (e.g., Postman, Insomnia, Thunderclient, etc ):
  - Make the request to the keycloak, requesting a authentication token like in the example bellow:
	```
	curl --location 'http://localhost:8080/realms/<your-realm>/protocol/openid-connect/token' \
	--header 'Content-Type: application/x-www-form-urlencoded' \
	--data-urlencode 'grant_type=password' \
	--data-urlencode 'client_id=<your-client-api>' \
	--data-urlencode 'username=<your-username>' \
	--data-urlencode 'password=<your-password>' \
	--data-urlencode 'client_secret=<your-secret>'
	```
  - Save the generated token and use it how a bearer token to authenticate in the example project created;
      
## **Portuguese**
Esse é um exemplo de uma api .NET que se integra com um serviço local do keycloak.

#### Passos para configuração:
- Executar o container do keycloak via docker:
  - ```docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:20.0.2 start-dev```
- Acessar a página web do keycloak usando o endereço ```localhost:8080``` em um navegador web;
  - Criar um novo realm;
  - Criar um client do tipo 'OpenID Connect';
  - Criar um client scope;
    - Criar uma mapper do tipo 'Audience' para o escopo;
    - Associar o mapper ao client criado;
  - Dentro do client, na aba de escopos, adicionar o escopo ao client;
  - Criar um usuário e setar uma senha para ele;

#### Configurando a aplicação:
- Criar projeto .NET
    - Instalar dependencias:
	    - KeyCloak.AuthServices.Authentication
	    - KeyCloak.AuthServices.Authorization
	    - IdentityModel.AspNetCore
	    - Refit.HttpClientFactory
- No arquivo appsettings, adicionar uma chave com os dados do client, exemplo:
     ```
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
     ```
- Na classe Program, configure a injeção de dependencia para o KeyCloak;
- Na classe controller, adicione a tag 'Authorize';

#### Testando
- Em um aplicativo para requisições http (Postman, Insomnia, Thunderclient, etc):
  - Faça uma requisição para o keycloak, solicitando um token de autenticação como no exemplo abaixo:
	```
	curl --location 'http://localhost:8080/realms/<your-realm>/protocol/openid-connect/token' \
	--header 'Content-Type: application/x-www-form-urlencoded' \
	--data-urlencode 'grant_type=password' \
	--data-urlencode 'client_id=<your-client-api>' \
	--data-urlencode 'username=<your-username>' \
	--data-urlencode 'password=<your-password>' \
	--data-urlencode 'client_secret=<your-secret>'
	```
  - Salve o token gerado e o use para como um token bearer para se autenticar na api criada no projeto.
  

