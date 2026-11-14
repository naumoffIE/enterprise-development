using Aspire.Hosting;
using Aspire.Hosting.MySql;

var builder = DistributedApplication.CreateBuilder(args);

// builder.AddProject<Projects.FitnessClub_Api>("fitnessclub-api")
//     .WithHttpHealthCheck("/health");

var mysql = builder.AddMySql("mysql");
var db = mysql.AddDatabase("appdb");

builder.AddProject<Projects.FitnessClub_Api>("fitnessclub-api")
    .WithUrl("/scalar/v1", "Scalar")
    .WithHttpHealthCheck("/health")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();
