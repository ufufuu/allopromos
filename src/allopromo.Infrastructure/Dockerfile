

FROM mcr.microsoft.com/mssql/server:2019-latest
ENV ACCEPT_EULA y
ENV SA_PASSWORD Kad@1207

RUN apt-get update && \
	apt-get install && \
-e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Kad@1207" -p 1433:1433 --restart=always --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
COPY ../script/init-db.SQL .
COPY ../script/entrypoint.sh .

# EXPOSE 1433

# CMD /bin/bash ../entrypoint.sh

#ENV MSSQL_PID=Developer
#ENV MSSQL_TCP_PORT=1433WORKDIR /srcCOPY filldata.sql ./filldata.sqlRUN 
#(/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" 
#&&  /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -Usa -PabcDEF123# -i filldata.sql

#FROM mcr.microsoft.com/mssql/server:2019-latest
#docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Kad@1207" \
#-p 1433:1433 --name sqlsv \
#-d mcr.microsoft.com/mssql/server:2019-latest

#docker exec -it sqlsv bash
#/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Kad@1207"

# localhost, 1400, 1431, 1433*, 
# sa - mssql* 
# password Kad@1207

# provider: TCP Provider, error: 0 - 
# No connection could be made because
# the target machine actively refused it.)
# Kad@1207