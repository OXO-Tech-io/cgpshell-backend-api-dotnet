# CGP Exam Backend API

## Overview

CGP Exam Backend is an ASP.NET Core Web API for secure online examinations. It manages examination sessions, records security events and audit logs, calculates risk scores, generates consolidated exam reports, and supports real-time communication with external systems using SignalR.

---

## Features

- Create examination sessions
- Record security events
- Record audit logs
- Generate consolidated exam reports
- Calculate examination risk scores
- Retrieve reports using:
  - Exam ID
  - Student ID
  - Session Token
- SignalR support for real-time notifications

---

## Technologies

- ASP.NET Core Web API
- .NET
- C#
- SignalR
- Swagger / OpenAPI

---

# Prerequisites

Install:

- .NET SDK (9/10 or the version used by the project)
- Visual Studio 2022 or VS Code

Verify installation:

```bash
dotnet --version
```

---

# Clone the Repository

```bash
git clone https://github.com/your-username/CGPExamBackend.git
cd CGPExamBackend
```

---

# Install Packages

Restore all NuGet packages:

```bash
dotnet restore
```

If you are creating the project from scratch, install the required packages:

```bash
dotnet add package Swashbuckle.AspNetCore
dotnet add package Microsoft.AspNetCore.SignalR
dotnet add package Microsoft.AspNetCore.OpenApi
```

---

# Build the Project

```bash
dotnet build
```

---

# Run the API

```bash
dotnet run
```

The API will typically be available at:

```
http://localhost:5222
```

Swagger UI:

```
http://localhost:5222/swagger
```

---

# API Endpoints

## Create Session

**POST**

```
POST /api/sessions
```

---

## Record Security Event

**POST**

```
POST /api/security-events
```

---

## Record Audit Log

**POST**

```
POST /api/audit-logs
```

---

## Retrieve Final Exam Report

**GET**

```
GET /audit/exam-logs
```

### Query Parameters

| Parameter | Description |
|----------|-------------|
| examId | Examination ID |
| studentId | Student ID |
| sessionToken | Session Token |

Example:

```
GET /audit/exam-logs?examId=59&studentId=991a3f43-10d3-4bd7-828b-9a4c779e4bdb&sessionToken=5b9cf587-9669-48ff-9c83-a9e4fb3d5e64
```

---

# Architecture

```
CGP Exam Shell
        │
        ├── Create Session
        ├── Security Events
        ├── Audit Logs
        ▼
CGP Exam Backend
        ├── Session Management
        ├── Risk Calculation
        ├── Report Generation
        ▼
Bot Assessment Frontend
```

---

# License

This API is for the CGPShell and its development, which will be integrated with the Bot Assessment 
