using Adapter_Administration;
using Adapter_Repositories;
using Adapter_Store_CSV;
using Application_Code.Interfaces;
using Domain_Code;


WebServer server = new WebServer(args);
server.Start();
