var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql");
var db = mysql.AddDatabase("appdb");

builder.AddProject<Projects.FitnessClub_Api>("fitnessclub-api")
    .WithHttpEndpoint(name: "http")
    .WithUrl("/scalar/v1", "Scalar")
    .WithHttpHealthCheck("/health")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();
