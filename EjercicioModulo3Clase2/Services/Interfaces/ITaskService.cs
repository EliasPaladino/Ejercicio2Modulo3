using EjercicioModulo3Clase2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioModulo3Clase2.Services.Interfaces
{
    public interface ITaskService
    {
        public List<Tasks> Get();
        public Tasks GetTaskById(int id);
        public Tasks CreateTask(Tasks task);
        public Tasks UpdateTask(int id, Tasks task);
        public Tasks DeleteTaskById(int id);
    }
}
