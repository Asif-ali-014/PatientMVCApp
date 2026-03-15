using Microsoft.AspNetCore.Mvc;
using PatientMVCApp.Models;

namespace PatientMVCApp.Controllers
{
    public class PatientController : Controller
    {
        static List<Patient> patients = new List<Patient>();
        public static List<UserLog> logs = new List<UserLog>();

        public IActionResult Index(string search)
        {
            List<Patient> result = new List<Patient>();

            for (int i = 0; i < patients.Count; i++)
            {
                Patient p = patients[i];

                if (string.IsNullOrEmpty(search))
                {
                    result.Add(p);
                }
                else
                {
                    string text = (p.Name + " " + p.Email).ToLower();

                    if (text.Contains(search.ToLower()))
                    {
                        result.Add(p);
                    }
                }
            }

            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            patient.Id = patients.Count + 1;

            patients.Add(patient);

            logs.Add(new UserLog
            {
                Id = logs.Count + 1,
                Action = "Add",
                Description = "Added patient " + patient.Name,
                Time = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        // showing edit form
        public IActionResult Edit(int id)
        {
            Patient patient = null;

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == id)
                {
                    patient = patients[i];
                }
            }

            return View(patient);
        }


        // patient updation
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == patient.Id)
                {
                    patients[i].Name = patient.Name;
                    patients[i].Age = patient.Age;
                    patients[i].Gender = patient.Gender;
                    patients[i].Email = patient.Email;
                }
            }

            logs.Add(new UserLog
            {
                Id = logs.Count + 1,
                Action = "Update",
                Description = "Updated patient " + patient.Name,
                Time = DateTime.Now
            });

            return RedirectToAction("Index");
        }
        //delte patient 
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == id)
                {
                    string name = patients[i].Name;

                    patients.RemoveAt(i);

                    logs.Add(new UserLog
                    {
                        Id = logs.Count + 1,
                        Action = "Delete",
                        Description = "Deleted patient " + name,
                        Time = DateTime.Now
                    });

                    break;
                }
            }

            return RedirectToAction("Index");
        }

    }
}