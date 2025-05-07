

FROM mcr.microsoft.com/mssql/server:2019-latest
# Create app directory
WORKDIR /usr/src/app

# Copy initialization scripts/entrypoint
COPY . /usr/src/app

# Set env variables 
ENV SA_PASSWORD Kad@1207
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

# Expose port in case accessing from other containers


# Run SQl server and init script at same time
# /usr/src/app/run-init.sh & /opt/mssql/bin/sqlservr

#RUN apt-get update && \
#	apt-get install && \
#-e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Kad@1207" -p 1433:1433 --restart=always --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
#COPY ../src/init-scripts/init-db.sql .
#COPY ../init-scripts/entrypoint.sh .

# CMD /bin/bash ../entrypoint.sh