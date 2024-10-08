# Back-End Challenge 20210221
<table>
<tr>
<td>
  O projeto se refere ao desenvolvimento de uma REST API, com importa��o de dados autom�tica, di�ria e limitada, a partir de outra API (base de aproximadamente 7 mil registros e 11 tabelas), que importa e exibe os dados de forma paginada; e protegida com token de autentica��o Bearer. Tecnologias utilizadas: C#, .NET 7, ASP.NET API, Authentication Jwt Bearer, Unit Test Controller, Entity Framework, SQL Server, Docker, Clean Architecture, Hexagonal Architecture.
</td>
</tr>
</table>


## Getting Started
1. Para criar e inicar os cont�iners necess�rios � aplica��o, no caminho "Back-End_Challenge_20210221", rode:
   ```bash
   docker-compose up
   ```
2. Acesse a p�gina inicial da aplica��o em "http://localhost:5211";

3. Para gera��o do token de autentica��o, necess�rio para utiliza��o do LaunchersController, acesse o Swagger em "http://localhost:5211/swagger/index.html", e acesse o endpoint que gera um token v�lido ("validToken").
   Posteriormente, em "Authorize", cole o token:
	```bash
   Bearer {token}
   ```
   ![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/OpenAPI_2.png)


# Aplica��o
![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/OpenAPI_1.png)
## Sistema CRON
O sistema de atualiza��o dos dados foi feito utilizando ferramentas nativas do .NET, que cria / atualiza a base existente, seguindo as seguintes regras:
- Os dados s�o cadastrados com requisi��es paginadas e limitadas da API externa: 100 registros a cada 5 minutos;
- O limite de requisi��es s�o 2000 ao dia;

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Cron.png)

## API

### Modelo de Dados:
Para a defini��o do modelo, [este arquivo JSON](https://ll.thespacedevs.com/2.0.0/launch/) foi consultado, para defini��o dos campos e tabelas utilizados no projeto.
Al�m destes, 2 campos adicionais eram criados para controle interno dos "launchers":
- `imported_t`: campo do tipo Date com a dia e hora que foi importado;
- `status`: campo do tipo Enum com os poss�veis valores "Draft" (importado), "Trash" (apagado na base de dados interna) e "Published" (editado na base de dados interna);

### Endpoints REST API
- `GET /`: Retornar uma mensagem "REST Back-end Challenge 20201209 Running"
- `PUT /launchers/:launchId`: Ser� respons�vel por receber atualiza��es realizadas
- `DELETE /launchers/:launchId`: Remover o launch da base
- `GET /launchers/:launchId`: Obter a informa��o somente de um launch da base de dados
- `GET /launchers`: Listar os launchers da base de dados de maneira paginada

### Seguran�a
Foi utilizado o JWT (Json Web Token), para realizar as autentica��es das requisi��es � API de Launchers.

### Pagina��o

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/OpenAPI_3.png)

### Resposta da API para visualiza��o ou edi��o de registro exclu�do da base de dados:

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/OpenAPI_4.png)


## Testes
Um projeto "Test" foi adicionado com refer�ncia ao projeto principal, para adi��o do arquivo respons�vel pelo teste unit�rio do "LaunchersConttroller".

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Tests.png)


## Docker
Aplica��o, banco de dados e ferramentas de observabilidade rodando em Container Docker.

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Docker_1.png)
![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Docker_2.png)


## Observabilidade
A observabilidade foi adicionada � aplica��o atrav�s da integra��o com **Prometheus** e **Grafana**. Com isso, � poss�vel monitorar m�tricas da aplica��o e visualizar gr�ficos em dashboards.

### Configura��o Prometheus
O **Prometheus** foi adicionado � aplica��o para coletar e expor m�tricas atrav�s do endpoint padr�o `/metrics`.

No arquivo `docker-compose.yml`, foi configurado um servi�o do Prometheus que coleta as m�tricas da aplica��o e as exp�e para o Grafana.

#### Arquivo de configura��o (`prometheus/prometheus.yml`):
O Prometheus coleta m�tricas da aplica��o no endpoint `/metrics`.

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Prometheus.png)

### Configura��o Grafana
O **Grafana** foi configurado para visualiza��o das m�tricas coletadas pelo Prometheus. Dashboards pr�-configurados foram adicionados para facilitar a visualiza��o das principais m�tricas.

#### Dashboards e Datasources
- Os arquivos de provisionamento foram inclu�dos para configurar automaticamente as fontes de dados e dashboards no Grafana.
- **Fonte de dados**: Prometheus.
- **Porta do Grafana**: `3000`.

Acesse o Grafana atrav�s de `http://localhost:3000` e utilize as seguintes credenciais padr�o:

- **Usu�rio**: `admin`
- **Senha**: `admin`

![](https://github.com/Git-Lucas/Back-End_Challenge_20210221/blob/master/imgs/Grafana.png)