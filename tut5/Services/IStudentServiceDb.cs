using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut5.DTOs.Requests;

namespace tut5.Services
{
    interface IStudentServiceDb
    {
        void EnrollStudent(EnrollStudentRequest req);
        void PromoteStudents(int semester, string studies);
    }
}

