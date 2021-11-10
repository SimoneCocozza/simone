using AcademyWebAPI.Exention;
using AcademyWebAPI.Model;
using AcademyWebAPI.Repository;
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
    public class ExamsController : ControllerBase
    {
        IRepository<Exam> _repository;
        public ExamsController(IRepository<Exam> repository)
        {
            _repository = repository;
        }
        // Exams
        [HttpGet]
        public IEnumerable<Exam> Get()
        {
            return _repository.GetElements();
        }

        // Exams/id
        [HttpGet("{id}")] // stiamo standardizzando il comportamento
        [ApiConventionMethod(typeof(APIConventions), nameof(APIConventions.Get))]

        public ActionResult<Exam> GetById(int id)
        {
            Exam exam = _repository.GetElementById(id);

            if(exam == null)
            {
                return NotFound();
            }
            return exam;
        }

        // Exams 
        [HttpPost]
        public ActionResult CreateExam(Exam exam)
        {
            if(exam == null)
            {
                return BadRequest();
            }

            var id = exam.ID;

            if(_repository.Exists(id))
            {
                return Ok("Oggetto già esistente");
            }

            int newId = _repository.AddObject(exam);
            
            return Created(new Uri($"https://localhost:5001/exams/{newId}"), exam);


        }

        //PUT Exams/id
        [HttpPut("{id}")]
        public ActionResult UpdateExam(int id, Exam exam)
        {
            if(exam == null)
            {
                return BadRequest();
            }

            Exam ExamOld = _repository.GetElementById(id);

            if(ExamOld == null)
            {
                return NotFound();
            }

            bool updateResult = _repository.Update(id, exam);

            if (updateResult)
                return Ok(exam);

            return new EmptyResult();
        }

        //DELETE Exams/id
        [HttpDelete("{id}")]
        public ActionResult DeleteExam(int id)
        {
            Exam ExamOld = _repository.GetElementById(id);

            if (ExamOld == null)
            {
                return NotFound();
            }

            bool deleteResult = _repository.Delete(id);

            if (deleteResult)
                return Ok(new DeleteResult
                {
                    Message = "Utente correttamente rimosso",
                    RemovedObject = ExamOld
                });

            return new EmptyResult();

        }
    }
}
