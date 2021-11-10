using AcademyWebAPI.Exention;
using AcademyWebAPI.Model;
using AcademyWebAPI.Repository;
using AcademyWebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AcademyWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        StudentService _service;
        public StudentsController(StudentService service)
        {
            _service = service;
        }
        // students
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Student>> Get([FromQuery(Name = "WithExam")] bool WithExam)
        {
            // bisogna aggiungere query string
            if (WithExam)
            {
                return Ok(_service.GetStudentWithExam());
            }
            return Ok(_service.Get());
            
        }

        // students/id
        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(APIConventions), nameof(APIConventions.Get))]
        public ActionResult<Student> GetById(int id)
        {
            Student student = _service.GetById(id);

            if(student == null)
            {
                return NotFound();
            }
            return student;
        }

        // students 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult CreateStudent(Student student)
        {
            if(student == null)
            {
                return BadRequest();
            }

            CreateResult result = _service.CreateStudent(student);

            switch (result.State)
            {
                case CreateState.AlreadyExisting:
                    return new EmptyResult();                
                case CreateState.Created:
                    return Created(new Uri($"https://localhost:5001/students/{result.ID}"), student);
                case CreateState.Error:
                default:
                    return Problem();
            }
        }

        //PUT students/id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateStudent(int id, Student student)
        {
            if(student == null)
            {
                return BadRequest();
            }
            UpdateResult result = _service.UpdateStudent(id, student);

            switch (result.State)
            {
                case UpdateState.NotExisting:
                    return NotFound();
                case UpdateState.Updated:
                    return Ok(student);
                case UpdateState.Error:
                default:
                    return Problem();
            }
        }



        //DELETE students/id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteStudent(int id)
        {
            DeleteResult result = _service.DeleteStudent(id);

            switch (result.State)
            {
                case DeleteResult.DeleteState.NotExisting: return NotFound();
                case DeleteResult.DeleteState.Deleted: return Ok(result.RemovedObject);
                case DeleteResult.DeleteState.Error:
                default:
                    return Problem();
            }
        }
    }
}
