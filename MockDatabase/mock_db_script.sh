# RUN DOCKER
docker run -d \
      -e "ACCEPT_EULA=Y" \
      -e "SA_PASSWORD=P@ssw0rd" \
      -p 1433:1433 \
      --name sqlserver \
      --hostname sqlserver \
      --network host \
      mcr.microsoft.com/mssql/server:2017-latest

# COPY SCRIPT FILE TO CONTAINER
docker cp ./ScriptContactList.sql sqlserver:/ScriptContactList.sql

# EXECUTE BASH WITHIN CONTAINER
docker exec -it sqlserver "bash"

# CONNECT TO DATABASE THROUGH sqlcmd WITHIN CONTAINER
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "P@ssw0rd"

# EXECUTE SQL SCRIPT FILE
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "P@ssw0rd" -i ScriptContactList.sql
