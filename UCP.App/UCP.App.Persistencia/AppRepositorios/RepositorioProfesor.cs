using UCP.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace UCP.App.Persistencia

{
    public class RepositorioProfesor : IRepositorioProfesor
    {
        private readonly AppContext _appContext;

        public RepositorioProfesor(AppContext appContext)
        {
            _appContext = appContext;
        }

        Profesor IRepositorioProfesor.AddProfesor(Profesor profesor)
        {
            //var profesorAdicionado = _appContext.Profesores.AddProfesor(profesor);
            var profesorAdicionado = _appContext.Profesores.Add(profesor);
            _appContext.SaveChanges();
            //return profesorAdicionado;
            return profesorAdicionado.Entity;
        }

        Profesor IRepositorioProfesor.UpdateProfesor(Profesor profesor)
        {
            //var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id = profesor.id);
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id == profesor.id);
            if (profesorEncontrado != null)
            {
                profesorEncontrado.nombre = profesor.nombre;
                profesorEncontrado.apellidos = profesor.apellidos;
                profesorEncontrado.identificacion = profesor.identificacion;
                profesorEncontrado.telefono = profesor.telefono;
                profesorEncontrado.correo =profesor.correo;
                profesorEncontrado.vehiculo_1 = profesor.vehiculo_1;
                profesorEncontrado.vehiculo_2 = profesor.vehiculo_2;
                profesorEncontrado.facultad = profesor.facultad;
                profesorEncontrado.cubiculo = profesor.cubiculo;

                _appContext.SaveChanges();
            }
            return profesorEncontrado;
        }

        void IRepositorioProfesor.DeleteProfesor (int idProfesor)
        {
            //var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id = idProfesor);
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id == idProfesor);
            if (profesorEncontrado == null)
                return;
            _appContext.Profesores.Remove(profesorEncontrado);
            _appContext.SaveChanges();
        }

        Profesor IRepositorioProfesor.GetProfesor(int idProfesor)
        {
            //var profesorEncontrado= _appContext.Profesores.FirstOrDefault(p => p.id = idProfesor);
            var profesorEncontrado= _appContext.Profesores.FirstOrDefault(p => p.id == idProfesor);
            return profesorEncontrado;
        }

        IEnumerable<Profesor> IRepositorioProfesor.GetAllProfesores()
        {
            return _appContext.Profesores;
        }
    }
}