using EjercicioModulo3Clase2.Domain.Entities;
using EjercicioModulo3Clase2.Repository;
using EjercicioModulo3Clase2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioModulo3Clase2.Services
{
    public class TaskService : ITaskService
    {
        private ToDoListDBContext _context;

        public TaskService(ToDoListDBContext context)
        {
            _context = context;
        }

        public List<Tasks> Get()
        {
            return _context.Tasks.ToList();
        }

        public Tasks GetTaskById(int id)
        {
            return _context.Tasks.Where(w => w.Id == id).FirstOrDefault();
        }

        public Tasks CreateTask(Tasks task)
        {
            _context.Add(task);
            _context.SaveChanges();
            return task;
        }

        public Tasks UpdateTask(int id, Tasks task)
        {
            var t = _context.Tasks.FirstOrDefault(w => w.Id == id);
            t.IsCompleted = task.IsCompleted;
            _context.SaveChanges();
            return t;
        }

        public Tasks DeleteTaskById(int id)
        {
            var t = _context.Tasks.FirstOrDefault(x => x.Id == id);
            t.IsActive = false;
            _context.SaveChanges();
            return t;
        }
    }
}
