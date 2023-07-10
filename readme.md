# Back-End Challenge 20210221
<table>
<tr>
<td>
  O projeto se refere ao desenvolvimento de uma REST API, com importa��o de dados autom�tica, di�ria e limitada, a partir de outra API (base de aproximadamente 7 mil registros e 11 tabelas), que importa e exibe os dados de forma paginada; e protegida com token de autentica��o Bearer.
</td>
</tr>
</table>


## Getting Started
1. Para criar e inicar os cont�iners necess�rios � aplica��o, rode:
   ```bash
   docker-compose up
   ```
2. Para aplica��o das migra��es, e cria��o do banco de dados atrav�s do Entity Framework, rode:
   ```bash
   dotnet ef database update
   ```
3. Para gera��o do token de autentica��o, necess�rio para utiliza��o do LaunchersController, rode:
   ```bash
   dotnet user-jwts create
   ```
	Posteriormente, na p�gina "https://localhost/swagger/index.html", em "Authorize", cole o token:
	```bash
   Bearer {token}
   ```
4. Finalmente, no arquivo "Back-End_Challenge_20210221\Infra\Cron\CronService", defina no "ImportStart" (linha 14), a hora, minuto e segundo (UTC) para in�cio da execu��o da importa��o.
   ```bash
   public TimeSpan ImportStart = new (00, 00, 00);
   ```