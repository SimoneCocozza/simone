using AcademyWebAPI.Model;
using AcademyWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI.Service
{
    public class StudentService
    {

        IRepository<Student> _repositoryStudent;
        IRepository<Exam> _repositoryExam;
        public StudentService(IRepository<Student> repositoryS, IRepository<Exam> repositoryE)
        {
            _repositoryStudent = repositoryS;
            _repositoryExam = repositoryE;
        }
        public IEnumerable<Student> Get()
        {
            //throw new Exception("Errore riga 23");

            return _repositoryStudent.GetElements();
        }

        public Student GetById(int id)
        {
           return _repositoryStudent.GetElementById(id);
        }

        public CreateResult CreateStudent(Student student)
        {
            try
            {
                var id = student.ID;

                if (_repositoryStudent.Exists(id))
                {
                    return new CreateResult
                    {
                        ID = id,
                        State = CreateState.AlreadyExisting
                    };

                }

                int newId = _repositoryStudent.AddObject(student);
                return new CreateResult
                {
                    ID = student.ID,
                    State = CreateState.Error
                };

            } catch
            {
                return new CreateResult
                {
                    ID = student.ID,
                    State = CreateState.Error
                };
            }
        }

        public UpdateResult UpdateStudent(int id, Student student)
        {
            try
            {

                if (!_repositoryStudent.Exists(id))
                {
                    return new UpdateResult { State = UpdateState.NotExisting };
                }
                if (_repositoryStudent.Update(id, student))
                    return new UpdateResult { State = UpdateState.Updated };

                return new UpdateResult { State = UpdateState.Error };
            }
            catch
            {
                return new UpdateResult
                {
                    State = UpdateState.Error
                };
            }
        }

        public DeleteResult DeleteStudent(int id)
        {
            try
            {
                throw new Exception("Errore riga 91");
                if(!_repositoryStudent.Exists(id))
                {
                    return new DeleteResult { State = DeleteResult.DeleteState.NotExisting };
                }
                Student studentOld = _repositoryStudent.GetElementById(id);

                bool deleteResult = _repositoryStudent.Delete(id);

                if (deleteResult)
                    return new DeleteResult
                    {
                        Message = "Utente correttamente rimosso",
                        RemovedObject = studentOld,
                        State = DeleteResult.DeleteState.Deleted
                    };

                return new DeleteResult
                {
                    State = DeleteResult.DeleteState.Error
                };
            }
            catch(Exception exc)
            {
                return new DeleteResult
                {
                    Message = exc.Message,
                    State = DeleteResult.DeleteState.Error
                };
            }
           
        }
        public IEnumerable<Student> GetStudentWithExam()
            //utilizzo repository degli esami
        {
            IEnumerable<Exam> Esami = _repositoryExam.GetElements();//abbiamo preso gli esami
            //creo la lista e la popolo
            List<int> StudentsID = new List<int>();
            
            foreach(Exam Esame in Esami)
            {
                StudentsID.AddRange(Esame.Students);     
            }
            IEnumerable<Student> Studenti = _repositoryStudent.GetElements();
            
            return Studenti.Where(x => StudentsID.Contains(x.ID)).ToList();//utilizzo LINQ se ho la certezza di ritornare i dati(nel foreach verrà eseguita ogni volta)

        }
    }
}
