using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Others;
using Newtonsoft.Json;

namespace Entity.UserModels
{
    public class Student:User
    {
        [NotMapped]
        public List<Tutor> Tutors { get; set; }
        [NotMapped]
        public List<Tutor> ActiveTutors { get; set; }

        public string TutorsList
        {
            get => JsonConvert.SerializeObject(Tutors);
            set => Tutors = string.IsNullOrEmpty(value) ? new List<Tutor>() : JsonConvert.DeserializeObject<List<Tutor>>(value);
        }

        public string ActiveTutorsList
        {
            get => JsonConvert.SerializeObject(ActiveTutors);
            set => ActiveTutors = string.IsNullOrEmpty(value) ? new List<Tutor>() : JsonConvert.DeserializeObject<List<Tutor>>(value);
        }
        [NotMapped]
        public List<ProposedSchedule> Schedules { get; set; }
        public string Schedule
        {
            get => JsonConvert.SerializeObject(Schedules);
            set => Schedules = value == null
                ? new List<ProposedSchedule>()
                : JsonConvert.DeserializeObject<List<ProposedSchedule>>(value);
        }

        public string Location { set; get; }
        public Student()
        {
            Role=Role.Student;
            Tutors=new List<Tutor>();
            ActiveTutors= new List<Tutor>();
            Schedules = new List<ProposedSchedule>();
        }

        public override User Copy(User user)
        {
            Student student = (Student) user;
            Name = student.Name;
            Location = student.Location;
            ProfilePictureUrl = student.ProfilePictureUrl;
            Mobilenumber = student.Mobilenumber;
            Schedule = student.Schedule;
            TutorsList = student.TutorsList;
            ActiveTutorsList = student.ActiveTutorsList;
            return student;
        }
    }
}
