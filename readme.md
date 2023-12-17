# Back-End Challenge 20210221
<table>
<tr>
<td>
  O projeto se refere ao desenvolvimento de uma REST API, com importação de dados automática, diária e limitada, a partir de outra API (base de aproximadamente 7 mil registros e 11 tabelas), que importa e exibe os dados de forma paginada; e protegida com token de autenticação Bearer. Tecnologias utilizadas: C#, .NET 7, ASP.NET API, Authentication Jwt Bearer, Unit Test Controller, Entity Framework, SQL Server, Docker, Clean Architecture, Hexagonal Architecture.
</td>
</tr>
</table>


## Getting Started
1. Para criar e inicar os contêiners necessários à aplicação, no caminho "Back-End_Challenge_20210221", rode:
   ```bash
   docker-compose up
   ```
2. Acesse a página inicial da aplicação em "http://localhost:5211";

3. Para geração do token de autenticação, necessário para utilização do LaunchersController, acesse o Swagger em "http://localhost:5211/swagger/index.html", e acesse o endpoint que gera um token válido ("validToken").
   Posteriormente, em "Authorize", cole o token:
	```bash
   Bearer {token}
   ```


# Aplicação
## Sistema CRON
O sistema de atualização dos dados foi feito utilizando ferramentas nativas do .NET, que cria / atualiza a base existente, seguindo as seguintes regras:
- Os dados são cadastrados com requisições paginadas e limitadas da API externa: 100 registros a cada 5 minutos;
- O limite de requisições são 2000 ao dia;

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Cron.png)

## API

### Modelo de Dados:
Para a definição do modelo, [este arquivo JSON](https://ll.thespacedevs.com/2.0.0/launch/) foi consultado, para definição dos campos e tabelas utilizados no projeto.
Além destes, 2 campos adicionais eram criados para controle interno dos "launchers":
- `imported_t`: campo do tipo Date com a dia e hora que foi importado;
- `status`: campo do tipo Enum com os possíveis valores "Draft" (importado), "Trash" (apagado na base de dados interna) e "Published" (editado na base de dados interna);

### Endpoints REST API
- `GET /`: Retornar uma mensagem "REST Back-end Challenge 20201209 Running"
- `PUT /launchers/:launchId`: Será responsável por receber atualizações realizadas
- `DELETE /launchers/:launchId`: Remover o launch da base
- `GET /launchers/:launchId`: Obter a informação somente de um launch da base de dados
- `GET /launchers`: Listar os launchers da base de dados de maneira paginada

### Segurança
Foi utilizado o JWT (Json Web Token), para realizar as autenticações das requisições à API de Launchers.

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/OpenAPI_2.png)

### Paginação

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/OpenAPI_3.png)

### Resposta da API para visualização ou edição de registro excluído da base de dados:

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/OpenAPI_4.png)

## Docker
Aplicação e banco de dados rodando em Container Docker.

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Docker_1.png)
![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Docker_2.png)

## Testes
Um projeto "Test" foi adicionado com referência ao projeto principal, para adição do arquivo responsável pelo teste unitário do "LaunchersConttroller".

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Tests.png)