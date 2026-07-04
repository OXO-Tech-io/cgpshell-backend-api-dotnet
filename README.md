CGP Exam Backend API
Overview

CGP Exam Backend is a .NET Web API that manages secure online examination sessions. It receives security events and audit logs from the CGP Exam Shell, stores them in memory, generates a consolidated examination report, and exposes APIs for external systems such as the Bot Assessment platform.

The backend is responsible for:

Managing examination sessions
Recording security events
Recording audit logs
Calculating examination risk
Generating a final examination report
Providing a single endpoint for retrieving all examination logs
Supporting real-time integration with external systems (SignalR)
Architecture
CGP Exam Shell
        │
        ├──────────────► Create Session
        ├──────────────► Security Events API
        ├──────────────► Audit Logs API
        ▼
CGP Exam Backend
        ├── Stores Session
        ├── Stores Security Events
        ├── Stores Audit Logs
        ├── Calculates Risk Score
        └── Generates Final Exam Report
        ▼
Bot Assessment Frontend
Technologies
ASP.NET Core Web API
C#
.NET
SignalR
Swagger / OpenAPI
Features
Create examination sessions
Record security events
Record audit logs
Risk score calculation
Final examination report generation
Query exam logs using:
Exam ID
Student ID
Session Token
Ready for real-time SignalR notifications
Setup & Run
Build Project
dotnet build
Run Project
dotnet run

API will start on:

http://localhost:5222
API Endpoints
1. Create Session

POST

/api/sessions
2. Record Security Event

POST

/api/security-events
3. Record Audit Log

POST

/api/audit-logs
4. Retrieve Final Examination Report

GET

/audit/exam-logs
Query Parameters
examId
studentId
sessionToken

Example:

GET /audit/exam-logs?examId=59&studentId=991a3f43-10d3-4bd7-828b-9a4c779e4bdb&sessionToken=5b9cf587-9669-48ff-9c83-a9e4fb3d5e64
Example Response
{
  "examId": "59",
  "studentId": "991a3f43-10d3-4bd7-828b-9a4c779e4bdb",
  "sessionToken": "5b9cf587-9669-48ff-9c83-a9e4fb3d5e64",
  "securityEvents": [],
  "auditLogs": []
}
Security Events
Tab Switch
Print Screen Attempt
Alt + Tab Attempt
Multiple Monitor Detection
Audit Logs
Exam Started
Exam Cancelled
Exam Submitted
Risk Assessment
0–19: CLEAN
20–49: WARNING
50+: FLAGGED
