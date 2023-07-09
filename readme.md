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
2. No arquivo "Back-End_Challenge_20210221\Infra\Cron\CronService", defina no "ImportStart" (linha 14), a hora, minuto e segundo (UTC) para in�cio da execu��o da importa��o.
   ```bash
   public TimeSpan ImportStart = new (00, 00, 00);
   ```