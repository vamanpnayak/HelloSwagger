using HelloSwagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace HelloSwagger.Controllers.v2
{
        [RoutePrefix("api/{apiVersion:regex(v2)}/Students")]      
        public class StudentV2sController : ApiController
        {

            private static List<Student> StudentsList;

            public StudentV2sController()
            {
                if (StudentsList == null)
                {
                    StudentsList = StudentsData.CreateStudents();
                }

            }

            /// <summary>
            /// Get all students
            /// </summary>
            /// <remarks>Get an array of all students</remarks>
            /// <response code="500">Internal Server Error</response>
            [Route("")]
            [ResponseType(typeof(List<Student>))]
            public IHttpActionResult Get()
            {
                return Ok(StudentsList);
            }

           

            /// <summary>
            /// Get student
            /// </summary>
            /// <param name="userName">Unique username</param>
            /// <remarks>Get signle student by providing username</remarks>
            /// <response code="404">Not found</response>
            /// <response code="500">Internal Server Error</response>
            [Route("{userName:alpha}", Name = "GetStudentByUserNameV2")]
            [ResponseType(typeof(Student))]
            public IHttpActionResult Get(string userName)
            {

                var student = StudentsList.Where(s => s.UserName == userName).FirstOrDefault();

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }

            /// <summary>
            /// Add new student
            /// </summary>
            /// <param name="student">Student Model</param>
            /// <remarks>Insert new student</remarks>
            /// <response code="400">Bad request</response>
            /// <response code="500">Internal Server Error</response>
            [Route("")]
            [ResponseType(typeof(Student))]
            public IHttpActionResult Post(Student student)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (StudentsList.Any(s => s.UserName == student.UserName))
                {
                    return BadRequest("Username already exists");
                }

                StudentsList.Add(student);

                string uri = Url.Link("GetStudentByUserName", new { userName = student.UserName });

                return Created(uri, student);
            }

            /// <summary>
            /// Delete student
            /// </summary>
            /// <param name="userName">Unique username</param>
            /// <remarks>Delete existing student</remarks>
            /// <response code="404">Not found</response>
            /// <response code="500">Internal Server Error</response>
            [Route("{userName:alpha}")]
            public HttpResponseMessage Delete(string userName)
            {

                var student = StudentsList.Where(s => s.UserName == userName).FirstOrDefault();

                if (student == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                StudentsList.Remove(student);

                return Request.CreateResponse(HttpStatusCode.NoContent);

            }

        }

        public class StudentsData
        {
            public static List<Student> CreateStudents()
            {

                List<Student> studentsList = new List<Student>();

                for (int i = 0; i < studentNames.Length; i++)
                {
                    var nameGenderMail = SplitValue(studentNames[i]);
                    var student = new Student()
                    {
                        Email = String.Format("{0}.{1}@{2}", nameGenderMail[0], nameGenderMail[1], nameGenderMail[3]),
                        UserName = String.Format("{0}{1}", nameGenderMail[0], nameGenderMail[1]),
                        FirstName = nameGenderMail[0],
                        LastName = nameGenderMail[1],
                        DateOfBirth = DateTime.UtcNow.AddDays(-new Random().Next(7000, 8000)),
                    };

                    studentsList.Add(student);
                }

                return studentsList;
            }

            static string[] studentNames = 
        { 
            "Vaman,Nayak,Male,hotmail.com", 
            "Atul,Nayak,Male,mymail.com", 
            "Manvi,Nayak,Female,outlook.com", 
            
        };

            private static string[] SplitValue(string val)
            {
                return val.Split(',');
            }
        }
    
}
