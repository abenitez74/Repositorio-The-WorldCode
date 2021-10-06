# Create Migrations
dotnet ef migrations add Original --startup-project ../UCP.App.Consola 

# Apply migrations
dotnet ef database update --startup-project ../UCR.App.Consola 