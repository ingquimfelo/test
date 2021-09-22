using System;
namespace UCP.App.Dominio

{
    public class Puesto
    {
        public int id { get; set; }

        public TipoVehiculo tipoVehiculo { get; set; }

        public int numeroParqueadero { get; set; }

        public Estado estado { get; set; }

        public Vehiculo vehiculo { get; set; }
    }
}