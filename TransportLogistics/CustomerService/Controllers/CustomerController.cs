using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerService.BusinessLogic;

namespace CustomerService.Controllers
{
    public class CustomerController : ControllerBase
    {


        //public StudentController(IStudentsService studentsService)
        //{
        //    this.studentsService = studentsService;
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Student> GetStudent(int id)
        //{
        //    return studentsService.Get(id) switch
        //    {
        //        null => NotFound(),
        //        var student => student
        //    };
        //}

        //[HttpGet]
        //public ActionResult<IReadOnlyCollection<Student>> GetStudents()
        //{
        //    return studentsService.GetAll().ToArray();
        //}

        //[HttpPost]
        //public IActionResult AddStudent(Student student)
        //{
        //    var newStudentId = studentsService.New(student);
        //    return Ok($"api/student/{newStudentId}");
        //}

        //[HttpPut("{id}")]
        //public ActionResult<string> UpdateStudent(int id, Student student)
        //{
        //    var studentId = studentsService.Edit(id, student);
        //    return Ok($"api/student/{studentId}");
        //}

        //[HttpDelete("{id}")]
        //public ActionResult DeleteStudent(int id)
        //{
        //    studentsService.Delete(id);
        //    return Ok();
        //}
        //private ICustomerService _service;
        private IMapper _mapper;
        // GET: CustomerController
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
