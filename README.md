FLOW:
1. create configuration for db connection
2. create db context configuration . just empty dbcontext (will be replaced later)
3. install dependencies
4. start auto migration (i.e using PMC)
5. update the generated migration file using sql raw
6. run the migration (Update-Database)
7. update the Entity using Reverse-Engineer tool
8. create migration using PMC (i.e Add-Migration AddNewTable) -> generates new migration file
9. edit migration file using sql raw
10. do the migration again -> repeat
11. there is possibility that migration can lock the migration table, 
	1. you can refresh the database, or
	2. run this :
'SELECT pid, age(clock_timestamp(), query_start), usename, query
FROM pg_stat_activity
WHERE state != 'idle'
ORDER BY query_start;

SELECT pg_terminate_backend(37); // change this according to the query result
'