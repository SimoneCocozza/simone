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
            //throw new Exception("Scoppiato alla riga 23");
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
                    ID = newId,
                    State = CreateState.Created
                };
            }
            catch(Exception exc)
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
            catch (Exception exc)
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
                throw new Exception("Scoppiato alla riga 90");

                if (_repositoryStudent.Exists(id))
                {
                    return new DeleteResult
                    {
                        State = DeleteResult.DeleteState.NotExisting
                    };
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
            catch (Exception exc)
            {
                return new DeleteResult
                {
                    Message = exc.Message,
                    State = DeleteResult.DeleteState.Error
                };
            }
        
        }
        // ho bisogno di avere una lista di studenti che hanno effettuato almeno un esame
        public IEnumerable<Student> GetStudentWithExam()
        {
            // deve ritornare lista studenti
            // devo utilizzare il repository degli esami per prendere gli esami
            // chiamare examrepository
            IEnumerable<Exam> Esami = _repositoryExam.GetElements(); // abbiamo preso tutti gli esami
                                                                     // devo estrarre la lista degli studenti che hanno fatto quell'esame

            List<int> StudentsID = new List<int>();

            foreach (Exam Esame in Esami)
            {
                StudentsID.AddRange(Esame.Students);  // abbiamo aggiunto gli id degli studenti
            }
            // andare sul repository degli studenti ed estrarre tutti gli studenti che hanno l'id nella lista
            // StudentID
            IEnumerable<Student> Studenti = _repositoryStudent.GetElements(); // repositorystudent ci da tutti
                                                                              // i dati degli studenti
            return Studenti.Where(x => StudentsID.Contains(x.ID)).ToList();
            // va bene se ho la certezza su come verrà utilizzata questa collezzione di dati

        }
    }
}
