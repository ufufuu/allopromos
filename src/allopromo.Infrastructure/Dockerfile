# The official Microsoft Sql Server
FROM mcr.microsoft.com/mssql/server:2019-latest

RUN docker run -e “ACCEPT_EULA=Y” -e “SA_PASSWORD=myPassword”
-p 1433:1433  --restart=always --name MSSQLSERVER
-v /home/docker/dockervolumes/MSSQL/:/var/opt/mssql
-d [mcr.microsoft.com/mssql/server:2019-latest](http://mcr.microsoft.com/mssql/server:2019-latest)

#Directory to store the data, which can be referenced as the starting point.
# RUN mkdir -p /var/opt/mysql

# Copy files to User Directory
# COPY . /usr/local/bin

# CMD ["/usr/local/bin/start.sh"]
# ENTRYPOINT ["sh"]

# CMD /bin/bash ./entrypoint.sh
ENV SA_PASSWORD password123!
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

# EXPOSE 14336

# CMD /bin/bash ./entrypoint.sh


# RUN useradd -M -s /bin/bash -u 10001 -g 0 mssql
# RUN mkdir -p -m 770 /var/opt/mssql && chgrp -R 0 /var/opt/mssql
# RUN setcap 'cap_net_bind_service+ep' /opt/mssql/bin/sqlservr
# RUN setcap 'cap_sys_ptrace+ep' /opt/mssql/bin/paldumper
# RUN setcap 'cap_sys_ptrace+ep' /usr/bin/gdb
# RUN mkdir -p /etc/ld.so.conf.d && touch /etc/ld.so.conf.d/mssql.conf
# RUN echo -e "# mssql libs\n/opt/mssql/lib" >> /etc/ld.so.conf.d/mssql.conf
# RUN ldconfig
# USER mssql
# CMD ["/opt/mssql/bin/sqlservr"]