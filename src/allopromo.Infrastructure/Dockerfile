
FROM ubuntu:20.04

# SHELL ["/bin/bash", "-c"]

RUN apt-get update && apt-get install -y wget software-properties-common

RUN wget -qO- https://packages.microsoft.com/keys/microsoft.asc | tee /etc/apt/trusted.gpg.d/microsoft.asc
RUN add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/20.04/mssql-server-2019.list)"
RUN apt-get update && apt-get install -y mssql-server

run docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=helloPassword123" -p 1433:1433 -d microsoft/mssql-server-linux -v /home/docker/dockervolumes/MSSQL/:/var/opt/mssql --restart=always --name MSSQLSERVER

run docker exec -it -u root my-jentkins /bin/bash
