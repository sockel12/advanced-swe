FROM mcr.microsoft.com/dotnet/sdk:8.0

# Setzen Sie das Arbeitsverzeichnis im Container auf /app
WORKDIR /app

# Kopieren Sie das Projekt in das Arbeitsverzeichnis im Container
COPY . ./
RUN su
RUN ln -s ./lib/* /usr/lib/

RUN apt-get upgrade && \
    apt-get update && \
    apt-get install -y odbcinst1debian2 libodbc1 odbcinst unixodbc

# Installieren Sie den Microsoft SQL ODBC-Treiber
#RUN apt-get upgrade  \
#    && apt-get update \
#    && apt-get install -y --no-install-recommends gnupg \
#    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
#    && curl https://packages.microsoft.com/config/debian/11/prod.list > /etc/apt/sources.list.d/mssql-release.list \
#    && apt-get update \
#    && ACCEPT_EULA=Y apt-get install -y msodbcsql18 \
#    && ACCEPT_EULA=Y apt-get install -y mssql-tools18 \
#    && echo 'export PATH="$PATH:/opt/mssql-tools18/bin"' >> ~/.bashrc \
#    && apt-get install -y unixodbc-dev

RUN odbcinst -d -i -l -f ./lib/driver.ini
RUN odbcinst -s -i -l -f ./lib/data_source.ini

# RUN dotnet build # -c Release

# Führen Sie die Anwendung aus
# CMD ["dotnet", "Administration/bin/Release/net8.0/Administration.dll"]
# CMD ["dotnet", "test"]