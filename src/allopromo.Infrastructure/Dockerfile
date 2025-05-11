# You can change this to a newer version of MySQL available at
# https://hub.docker.com/r/mysql/mysql-server/tags/
# mysql/mysql-server:8.0.24
# mcr.microsoft.com/mssql/server:2017-latest
# https://stackoverflow.com/questions/33001750/connect-to-mysql-in-a-docker-container-from-the-host
# https://stackoverflow.com/questions/69941444/how-to-have-docker-compose-init-a-sql-server-database
# FROM postgrest/postgrest
# https://stackoverflow.com/questions/69941444/how-to-have-docker-compose-init-a-sql-server-database

FROM mcr.microsoft.com/mssql/server:2019-CU13-ubuntu-20.04 

# COPY config/user.cnf /etc/mysql/my.cnf
# Create app directory
#WORKDIR /usr/src/app

# Copy initialization scripts
# COPY . /usr/src/app

# Set environment variables, not have to write them with the docker run command
# Note: make sure that your password matches what is in the run-initialization script 

ENV SA_PASSWORD Pa$$w0rd
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

EXPOSE 1433

# Run Microsoft SQL Server and initialization script (at the same time)
# CMD /bin/bash ./entrypoint.sh

#########
### LINUX
##########
# https://stackoverflow.com/questions/62941856/unable-to-start-sql-server-2019-docker
# sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=******" 
    -v /Data/mssql:/var/opt/mssql/data 
    -p 1433:1433 
    --name sql1 
    -h sql1 
    -d mcr.microsoft.com/mssql/server:2019-latest 
	

#######
### INIT DB
########

# https://stackoverflow.com/questions/69941444/how-to-have-docker-compose-init-a-sql-server-database