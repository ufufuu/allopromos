
FROM ubuntu:20.04
RUN apt-get update && apt-get install -y wget software-properties-common
RUN wget -qO- https://packages.microsoft.com/keys/microsoft.asc | tee /etc/apt/trusted.gpg.d/microsoft.asc
RUN add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/20.04/mssql-server-2019.list)"
RUN apt-get update && apt-get install -y mssql-server

run docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d "microsoft/mssql-server-linux:2019-latest"
