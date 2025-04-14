

FROM mcr.microsoft.com/mssql/server:2019-latest

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