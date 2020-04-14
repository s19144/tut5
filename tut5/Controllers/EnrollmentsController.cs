using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tut5.DTOs.Requests;
using tut5.DTOs.Responses;
using tut5.Services;

namespace tut5.Controllers
{
    [Route("api/enrollments")]
    [ApiController] 
    public class EnrollmentsController : ControllerBase
    {
        
        private IStudentServiceDb _service;

        public EnrollmentsController(IStudentServiceDb service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            _service.EnrollStudent(request);

            var response = new EnrollStudentResponse();
            return Ok(response);
        }

        [HttpPost("promote")]
        public IActionResult PromoteStudents()
        {
           
            _service.PromoteStudents(1, "IT");

            return Ok();
        }
    }

}