using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskMan.Filters;
using TaskMan.Models;

namespace TaskMan.Controllers
{
    [Authorize]
    public class TaskController : ApiController
    {
        Entities db = new Entities();

        //POST
        public string Post(TaskTable task)
        {
            int id = task.QuoteId;

            TaskTable t = db.TaskTables.Find(id);

            if (t != null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("The Task Already Exists.")
                };
                throw new HttpResponseException(message);
            }

            db.TaskTables.Add(task);
            db.SaveChanges();

            return "Task Added";

        }

        //GET (single task)
        public TaskTable Get(int id)
        {
            TaskTable task = db.TaskTables.Find(id);

            if (task == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("The Task doesn't exist.")
                };
                throw new HttpResponseException(message);
            }
            return task;
        }


        //GET (all tasks)
        public IEnumerable<TaskTable> Get()
        {
            IEnumerable < TaskTable > ret = db.TaskTables.ToList();

            if (ret.Count() == 0)
            {
                var message = new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent("No Tasks currently Available.")
                };
                throw new HttpResponseException(message);
            }
            return ret;
        }



        //PUT
        public string Put(int id, TaskTable task)
        {
            var task_upd = db.TaskTables.Find(id);


            if (task_upd == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("The Task doesn't exist.")
                };
                throw new HttpResponseException(message);
            }

            task_upd.Quote_Type = task.Quote_Type;
            task_upd.Contact = task.Contact;
            task_upd.Task_Desc = task.Task_Desc;
            task_upd.Due_Date = task.Due_Date;
            task_upd.Task_Type = task.Task_Type;

            db.Entry(task_upd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            return "task Updated";
        }

        //DELETE
        public string Delete(int id)
        {

            TaskTable task = db.TaskTables.Find(id);

            if (task == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("The Task doesn't exist.")
                };
                throw new HttpResponseException(message);
            }

            db.TaskTables.Remove(task);
            db.SaveChanges();
            return "Deleted";
        }
    }
}
