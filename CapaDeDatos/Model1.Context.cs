﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDeDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TestSolEntities : DbContext
    {
        public TestSolEntities()
            : base("name=TestSolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
    
        public virtual int EmpleadoDelete(Nullable<int> idEmpleado)
        {
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoDelete", idEmpleadoParameter);
        }
    
        public virtual ObjectResult<EmpleadoGetAll_Result2> EmpleadoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetAll_Result2>("EmpleadoGetAll");
        }
    
        public virtual ObjectResult<AreaGetAll_Result> AreaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AreaGetAll_Result>("AreaGetAll");
        }
    
        public virtual int EmpleadoAdd(string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<byte> idArea, string fechaDeNacimiento, Nullable<decimal> sueldo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("IdArea", idArea) :
                new ObjectParameter("IdArea", typeof(byte));
    
            var fechaDeNacimientoParameter = fechaDeNacimiento != null ?
                new ObjectParameter("FechaDeNacimiento", fechaDeNacimiento) :
                new ObjectParameter("FechaDeNacimiento", typeof(string));
    
            var sueldoParameter = sueldo.HasValue ?
                new ObjectParameter("Sueldo", sueldo) :
                new ObjectParameter("Sueldo", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, idAreaParameter, fechaDeNacimientoParameter, sueldoParameter);
        }
    
        public virtual ObjectResult<EmpleadoGetById_Result1> EmpleadoGetById(Nullable<int> idEmpleado)
        {
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetById_Result1>("EmpleadoGetById", idEmpleadoParameter);
        }
    
        public virtual int EmpleadoUpdate(Nullable<int> idEmpleado, string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<byte> idArea, string fechaDeNacimiento, Nullable<decimal> sueldo)
        {
            var idEmpleadoParameter = idEmpleado.HasValue ?
                new ObjectParameter("IdEmpleado", idEmpleado) :
                new ObjectParameter("IdEmpleado", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("IdArea", idArea) :
                new ObjectParameter("IdArea", typeof(byte));
    
            var fechaDeNacimientoParameter = fechaDeNacimiento != null ?
                new ObjectParameter("FechaDeNacimiento", fechaDeNacimiento) :
                new ObjectParameter("FechaDeNacimiento", typeof(string));
    
            var sueldoParameter = sueldo.HasValue ?
                new ObjectParameter("Sueldo", sueldo) :
                new ObjectParameter("Sueldo", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoUpdate", idEmpleadoParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, idAreaParameter, fechaDeNacimientoParameter, sueldoParameter);
        }
    }
}