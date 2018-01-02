using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL;
using BLL.NotificationRepository;
using BLL.SearchRepository;
using BLL.UserRepository;
using Entity.UserModels;
using Entity.Others;
using TutorsHub.Application.Models;


namespace TutorsHub.Application.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult DashBoard()
        {
            return View(new Tutor());
        }
        [HttpGet]
        public RedirectToRouteResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Report()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ExamResult()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View(new EditPass());
        }
        [HttpPost]
        public ActionResult ChangePassword(EditPass editPass)
        {
            var userservice = new UserService<Student>();

            var studentservice = new ServiceProvider().Create<Student>();
            var student = studentservice.GetByEmail(Session["KEY"] as string);

            if (editPass.NewPassword == editPass.RepPassword)
            {
                userservice.UpdatePassword(student.Email, editPass.NewPassword);
            }
            return View(editPass);
        }

        [HttpGet]
        public ActionResult SchedTutor()
        {

            return View(new ProposedSchedule());
        }

        [HttpPost]
        public ActionResult SchedTutor(ProposedSchedule schedule)
        {
            
            schedule.UserName=TempData["SearchedTutor"] as string;
            schedule.UserEmail = TempData["SearchedTutorEmail"] as string;
            

            var notification = new Notification()
            {
                Notificationtype = Notificationtype.ScheduleProposiotion,
                NotificationData = schedule.ScheduleAsString,
                Message = "You have been hired",
                ActionLink = "/Home/Index",
                Key = schedule.UserEmail
            };

            if (new NotificationService().Add(notification))
            {
          
            }

            //send a notification to tutor
            var t = new ServiceProvider().Create<Tutor>().GetByEmail(schedule.UserEmail);
            var student = new ServiceProvider().Create<Student>().GetByEmail(Session["Key"] as string);
            

            if (!t.Students.Contains(student))
            {
                t.Students.Add(student);
            }
            
            t.Schedules.Add(schedule);
            if (new ServiceProvider().Create<Tutor>().Update(t))
            {
                
               
            }

            student = new ServiceProvider().Create<Student>().GetByEmail(Session["Key"] as string);
            student.Schedules.Add(schedule);
            if (!student.Tutors.Contains(t))
            {
                student.Tutors.Add(t);
                
                new ServiceProvider().Create<Student>().Update(student);
            }


            return RedirectToAction("HireTutor", "Student");
        }


        [HttpGet]
        public ActionResult SendMessage()
        {
            IUserService<Student> userService = new ServiceProvider().Create<Student>();
            ChatViewModel chatViewModel = new ChatViewModel();
            chatViewModel.Users = userService.GetByEmail(Session["Key"] as string).Tutors.ToList<User>();
            return View(chatViewModel);
        }


        [HttpPost]
        public ActionResult SendMessage(ChatViewModel chatViewModel)
        {
            var notification = new Notification
            {
                Message = chatViewModel.Message,
                Key = chatViewModel.UserKey,
                Notificationtype = Notificationtype.Message,
                ActionLink = new ServiceProvider().Create<Student>().GetByEmail(Session["Key"] as string).Name
            };

            if (new NotificationService().Add(notification))
            {

            }

            return RedirectToAction("DashBoard","Student");
        }


        [HttpGet]
        public ActionResult StudyMaterial()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OnlineExam()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HireTutor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HireTutor(string action)
        {
            return RedirectToAction("DashBoard", "Student");
        }
        [HttpGet]
        public ActionResult StudentProfile()
        {
            var studentservice = new ServiceProvider().Create<Student>();
            var student = studentservice.GetByEmail(Session["KEY"] as string);
            return View(student);
            
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            var studentprovider = new ServiceProvider().Create<Student>();
            return View(studentprovider.GetByEmail(Session["KEY"] as string));
        }


        [HttpPost]
        public ActionResult EditProfile(Student student)
        {
            var studentprovider = new ServiceProvider().Create<Student>();
            student.Email = Session["Key"] as string;
            if (studentprovider.Update(student))
            {
                return RedirectToAction("ViewProfile", "Student");
            }

            return View(student);
        }


        [HttpGet]
        public ActionResult Notification()
        {
            return View(new NotificationViewModel(Session["Key"] as string));
        }
        [HttpGet]
        public ActionResult TutorSearch()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public ActionResult ViewSearch(SearchViewModel searchViewModel)
        {
            List<Tutor> tutors = new PublicSearch().SearchTutors(searchViewModel.Location, searchViewModel.Gender
                , searchViewModel.Class, (int)searchViewModel.MinSal, (int)searchViewModel.MaxSal, searchViewModel.SelectedSubjects);
            return View(tutors);
        }

        [HttpPost]
        public ActionResult ViewProfile(string key)
        {
            Tutor tutor = new TutorService().GetByEmail(key);
            TempData["SearchedTutor"] = tutor.Name;
            TempData["SearchedTutorEmail"] = tutor.Email;
            return View(tutor);
        }

        public ActionResult ScheduleResult()
        {
            return View();
        }
    }
}