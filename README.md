# QuesGenie 🧠✨  
An AI-powered question generation system for documents and educational content.

---

## 1. 🔧 Prerequisites

Ensure the following are installed before running the project:

- [.NET 9+ SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
- [Git](https://git-scm.com/downloads)

---

## 2. 🔃 Clone the Repository

```bash
git clone https://github.com/fares7elsadek/QuesGenie.git
cd QuesGenie
````

---

## 3. 📦 Restore Dependencies

```bash
dotnet restore
```

This installs:

* Serilog logging packages
* Application Insights sink
* EF Core and PostgreSQL provider
* Other required project dependencies

---

## 4. 🗄️ PostgreSQL Database Setup

### 🐧 Ubuntu/Debian Installation

```bash
sudo apt update
sudo apt install postgresql postgresql-contrib
```

### 🪟 Windows Installation

Download from: [https://www.postgresql.org/download/windows/](https://www.postgresql.org/download/windows/)

### 🧑‍💻 Create Database and User

```bash
sudo -u postgres psql
```

Inside the prompt:

```sql
CREATE DATABASE quesgenie;
CREATE USER quesgenie_user WITH PASSWORD 'your_password';
GRANT ALL PRIVILEGES ON DATABASE quesgenie TO quesgenie_user;
\q
```

### 🔗 Add Connection String to `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=quesgenie;Username=quesgenie_user;Password=your_password"
}
```

---

## 5. ☁️ Azure Blob Storage Setup

Used for storing uploaded files such as documents or images.

### 🔨 Create Storage Account and Container

```bash
az login
az group create --name quesgenie-rg --location eastus
az storage account create --name quesgeniestorage --resource-group quesgenie-rg --location eastus --sku Standard_LRS
az storage container create --name documents --account-name quesgeniestorage --public-access off
```

### 🔑 Get the Connection String

```bash
az storage account show-connection-string --name quesgeniestorage --resource-group quesgenie-rg
```

### 📝 Add to `appsettings.json`

```json
"BlobStorage": {
  "ConnectionString": "<your-blob-connection-string>",
  "PhotosContainerName": "documents"
}
```

---

## 6. 🔐 JWT Authentication Configuration

In `appsettings.json`:

```json
"JWT": {
  "Issure": "QuesGenieAPI",
  "Audience": "QuesGenieUsers",
  "Key": "ThisIsAStrongJWTSecretKey",
  "DurationInMinutes": 60
}
```

---

## 7. 📧 Email Service Configuration

Used for sending verification and notification emails.

```json
"email": {
  "smptemail": "your-email@gmail.com",
  "smptpassword": "your-smtp-password"
}
```

---

## 8. 📊 Application Insights (Azure) Setup

```bash
az monitor app-insights component create --app quesgenie-logs --location eastus --resource-group quesgenie-rg --application-type web
az monitor app-insights component show --app quesgenie-logs --resource-group quesgenie-rg --query "instrumentationKey"
```

Add to `appsettings.json`:

```json
"APPLICATIONINSIGHTS_CONNECTION_STRING": "Connection string"
```

---

## 9. 📝 Logging Configuration (Serilog)

Add the following to your `appsettings.json`:

```json
"serilog": {
  "Using": [
    "Serilog.Sinks.ApplicationInsights"
  ],
  "MinimumLevel": {
    "Override": {
      "Microsoft": "Warning",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  },
  "WriteTo": [
    {
      "Name": "Console",
      "Args": {
        "outputTemplate": "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine}{Message:lj}{NewLine}{Exception}"
      }
    },
    {
      "Name": "File",
      "Args": {
        "path": "Logs/QuesGenie-API-.json",
        "rollingInterval": "Day",
        "rollOnFileSizeLimit": true,
        "formatter": "Serilog.Formatting.Json.JsonFormatter"
      }
    },
    {
      "Name": "ApplicationInsights",
      "Args": {
        "telemetryConverter": "Serilog.Sinks.ApplicationInsights.TelemetryConverters.TraceTelemetryConverter, Serilog.Sinks.ApplicationInsights"
      }
    }
  ]
}
```

---

## 10. 🚀 Apply Migrations & Run the App

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

---

## ✅ Running the Backend

The application should now be running at:

```
http://localhost:5150
https://localhost:7061
```

---

## 👥 Contributing

Contributions, issues, and feature requests are welcome!
Feel free to open a [discussion](https://github.com/fares7elsadek/QuesGenie/discussions) or [pull request](https://github.com/fares7elsadek/QuesGenie/pulls).

---

## 📄 License

Distributed under the MIT License.
See `LICENSE` for more information.
