# Back-End Challenge 20210221
<table>
<tr>
<td>
  O projeto se refere ao desenvolvimento de uma REST API, com importação de dados automática, diária e limitada, a partir de outra API (base de aproximadamente 7 mil registros e 11 tabelas), que importa e exibe os dados de forma paginada; e protegida com token de autenticação Bearer.
</td>
</tr>
</table>


## Getting Started
1. Para criar e inicar os contêiners necessários à aplicação, rode:
   ```bash
   docker-compose up
   ```
2. Para aplicação das migrações, e criação do banco de dados através do Entity Framework, rode:
   ```bash
   dotnet ef database update
   ```
3. Para geração do token de autenticação, necessário para utilização do LaunchersController, rode:
   ```bash
   dotnet user-jwts create
   ```
	Posteriormente, na página "https://localhost/swagger/index.html", em "Authorize", cole o token:
	```bash
   Bearer {token}
   ```
4. Finalmente, no arquivo "Back-End_Challenge_20210221\Infra\Cron\CronService", defina no "ImportStart" (linha 14), a hora, minuto e segundo (UTC) para início da execução da importação.
   ```bash
   public TimeSpan ImportStart = new (00, 00, 00);
   ```