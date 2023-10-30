FROM ubuntu

RUN su -
RUN export DEBIAN_FRONTEND=noninteractive
RUN apt-get update
RUN apt-get -y install curl

RUN curl https://packages.microsoft.com/keys/microsoft.asc | tee /etc/apt/trusted.gpg.d/microsoft.asc

RUN curl "https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/prod.list" | tee /etc/apt/sources.list.d/mssql-release.list
RUN apt-get update
RUN apt-get install -y msodbcsql18
# optional: for bcp and sqlcmd
RUN apt-get install -y mssql-tools18
RUN echo 'export PATH="$PATH:/opt/mssql-tools18/bin"' >> ~/.bashrc
RUN source ~/.bashrc
# optional: for unixODBC development headers
RUN apt-get install -y unixodbc-dev