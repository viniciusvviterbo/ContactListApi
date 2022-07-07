# RUN DOCKER
docker run -d \
      -e "ACCEPT_EULA=Y" \
      -e "SA_PASSWORD=P@ssw0rd" \
      -p 1433:1433 \
      --name sqlserver \
      --hostname sqlserver \
      --network host \
      mcr.microsoft.com/mssql/server:2017-latest

# EXECUTE BASH WITHIN CONTAINER
docker exec -it sqlserver "bash"

# CONNECT TO DATABASE THROUGH sqlcmd WITHIN CONTAINER
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "P@ssw0rd"

# CREATE AND RUN MIGRATIONS THROUGH ENTITY FRAMEWORK
dotnet ef migrations add InitialCreate
dotnet ef database update
