using CGPExamBackend.Models;
using CGPExamBackend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CGPExamBackend.Services
{
    public class SessionService
    {
        private static readonly List<ExamSession> Sessions = new();

        public static ExamSession Create(CreateSessionRequest req)
        {
            var session = new ExamSession
            {
                ExamId = req.ExamId,
                StudentId = req.StudentId,
                SessionToken = req.SessionToken
            };

            Sessions.Add(session);
            return session;
        }

        public static ExamSession? Find(string examId, string studentId, string sessionToken)
        {
            return Sessions.FirstOrDefault(s =>
                s.ExamId == examId &&
                s.StudentId == studentId &&
                s.SessionToken == sessionToken);
        }
    }
}