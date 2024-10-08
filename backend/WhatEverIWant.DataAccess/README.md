# Data Access Layer

### Connection strings 

Example: 

```json 
{
  "ConnectionStrings": 
  {
    "PostgreSQL": "Host=localhost;Database=UnifiedApp;Username=user;Password=pass",
    "MSSQL": "Server=localhost;Database=UnifiedApp;User Id=user;Password=pass;",
    "MariaDB": "Server=localhost;Database=UnifiedApp;User=user;Password=pass;",
    "SQLite": "Data Source=unifiedapp.db"
  }
}
```

### TODOS

- How to automate creation of DAL with best practices, code, structure, types (like a plugin, or app, etc.)?