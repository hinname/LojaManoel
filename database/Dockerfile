FROM mcr.microsoft.com/mssql/server:2022-latest

# Switch to root for chown
USER root 

# set permissions on directories
RUN chown -R mssql:mssql /var/opt/mssql
 
# switching to the mssql user
USER mssql