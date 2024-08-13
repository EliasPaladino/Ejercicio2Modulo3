using EjercicioModulo3Clase2.Domain.Entities;
using EjercicioModulo3Clase2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioModulo3Clase2.Controllers
{
    [Route( "tasks" )]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Pasos previos
        /*
         * 1 - Instalar EF Core y EF Core SQL Server
         * 2 - Crear contexto de base de datos y los modelos. Se puede usar Ingenieria Inversa de EF Core Power Tools
         * 3 - Configurar la inyección de dependencia del contexto tanto en Program.cs como en el controlador. No olvidar el string de conexión.
         * 4 - Las rutas de los endpoints queda a criterio de cada uno.
         * 5 - En este controlador, realizar los siguientes ejercicios:
         */
        #endregion

        private readonly ToDoListDBContext _context;

        public TaskController( ToDoListDBContext context )
        {
            _context = context;
        }

        #region Ejercicio 1
        // Crear un endpoint para obtener un listado de todas las tareas usando HTTP GET

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Tasks.ToList());
        }
        #endregion

        #region Ejercicio 2
        // Crear un endpoint para obtener una tarea por ID usando HTTP GET
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            return Ok(_context.Tasks.Where(w => w.Id == id).FirstOrDefault());
        }
        #endregion

        #region Ejercicio 3
        // Crear un endpoint para crear una nueva tarea usando HTTP POST
        [HttpPost]
        public IActionResult CreateTask([FromBody] Tasks task)
        {
            _context.Add(task);
            _context.SaveChanges();
            return Ok();
        }
        #endregion

        #region Ejercicio 4
        // Crear un endpoint para marcar una tarea como completada usando HTTP PUT
        [HttpPut("{id}")]
        public IActionResult UpdateTask([FromRoute] int id, [FromBody] Tasks task)
        {
            var t = _context.Tasks.FirstOrDefault(w => w.Id == id);
            t.IsCompleted = task.IsCompleted;
            _context.SaveChanges();
            return Ok(t);
        }
        #endregion
        #region Ejercicio 5
        // Crear un endpoint para dar de baja una tarea usando HTTP PUT (baja lógica)
        [HttpPut("eliminar/{id}")]
        public IActionResult DeleteTaskById([FromRoute] int id)
        {
            var t = _context.Tasks.FirstOrDefault(x => x.Id == id);
            t.IsActive = false;
            _context.SaveChanges();
            return Ok(t);
        }
        #endregion
    }
}
