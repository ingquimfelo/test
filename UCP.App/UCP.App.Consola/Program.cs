using System;
using UCP.App.Dominio;
using UCP.App.Persistencia;
using System.Collections.Generic;
using System.Linq;
namespace UCP.App.Consola
{
    class Program
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            Console.WriteLine("Esto es un mensaje por consola");
            //AddProfesor();
            //BuscarProfesor(1);
            BuscarProfesor(2);
            //EliminarProfesor(1);
            //ActualizarProfesor();
            BuscarProfesor(2);
            BuscarProfesores();
        }

        //AddProfesor

        private static void AddProfesor()
        {
            var profesor = new Profesor 
            {
               nombre = "Angelica",
               apellidos = "Muñoz",
               identificacion = 100000003,
               correo =  "AngelicaMunoz.tic@ucaldas.edu.co",
               telefono ="30000000059",
               vehiculo_1 = null,
               vehiculo_2 = null,
               facultad ="Derecho",
               departamento = "Ciencias Politicas",
               cubiculo ="tres" 
            };

            Console.WriteLine(profesor.nombre+"\nCubiculo= "+profesor.cubiculo);
            Profesor profesor_retornado = _repoProfesor.AddProfesor(profesor);
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
        }
        //GetProfesor

        private static void BuscarProfesor(int idProfesor)
        {
            var profesor = _repoProfesor.GetProfesor(idProfesor);
            Console.WriteLine(profesor.nombre+" "+profesor.apellidos+"\n Facultad: "+profesor.facultad+" "+profesor.departamento+"\n Identificación:"+profesor.identificacion+"\n Télefono: "+profesor.telefono);

        }
        //DeleteProfesor

        private static void EliminarProfesor(int idProfesor)
        {
            _repoProfesor.DeleteProfesor(idProfesor);
        }

        //UpdateProfesor

        private static void ActualizarProfesor()
        {
            var profesor = new Profesor 
            {
               id= 2,
               nombre = "Felipe",
               apellidos = "Patiño",
               identificacion = 100000022,
               correo =  "felipepatino.tic@ucaldas.edu.co",
               telefono ="30000000051",
               vehiculo_1 = null,
               vehiculo_2 = null,
               facultad ="Ingeniería",
               departamento = "Ciencias Computacionales",
               cubiculo ="Uno" 

            };
            Profesor profesor_retornado =_repoProfesor.UpdateProfesor(profesor);                         
            if (profesor_retornado!=null)
                Console.WriteLine("Se registró un profesor en la base de datos");
        
        }
        //GetAllProfesores

        private static void BuscarProfesores()
        {
            IEnumerable<Profesor> profesores = _repoProfesor.GetAllProfesores();
            
            // este foreach sería para la lista completa de profesores
            foreach (var profesor in profesores)
            {
                Console.WriteLine(profesor.nombre);
            }
            //Console.WriteLine(profesores.First().nombre);
        }
    }
}

