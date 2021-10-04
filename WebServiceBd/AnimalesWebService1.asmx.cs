using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceBd
{
    /// <summary>
    /// Descripción breve de AnimalesWebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class AnimalesWebService1 : System.Web.Services.WebService
    {


        [WebMethod(Description = "Lista de animales")]
        public List<animales> GetAnimales()
        {
            webserviceanimalesEntities conexion = new webserviceanimalesEntities();
            var consulta = (from l in conexion.animales select l).ToList();
            return consulta;
        }
        [WebMethod(Description = "Insertar animal")]
        public bool CreateAnimales(string nombre,string alimentacion,string especie, string sexo, string nombre_cientifico)
        {
            try
            {
                using(webserviceanimalesEntities conexion = new webserviceanimalesEntities())
                {
                    animales nuevoAnimal = new animales();
                    
                    nuevoAnimal.nombre = nombre;
                    nuevoAnimal.alimentacion = alimentacion;
                    nuevoAnimal.especie = especie;
                    nuevoAnimal.sexo = sexo;
                    nuevoAnimal.nombre_cientifico = nombre_cientifico;
                    conexion.animales.Add(nuevoAnimal);
                    conexion.SaveChanges();
                    return true;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }
        [WebMethod(Description = "Modificar animal")]
        public bool UpdateAnimales(int id,string nombre, string alimentacion, string especie, string sexo, string nombre_cientifico)
        {
            try
            {
                using (webserviceanimalesEntities conexion = new webserviceanimalesEntities())
                {
                    var consulta = (from l in conexion.animales where l.id == id select l).FirstOrDefault();
                    if(consulta!= null)
                    {
                        consulta.id = id;
                        consulta.nombre = nombre;
                        consulta.alimentacion = alimentacion;
                        consulta.especie = especie;
                        consulta.sexo = sexo;
                        consulta.nombre_cientifico = nombre_cientifico;
                        conexion.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }
        [WebMethod(Description = "Eliminar animal")]
        public bool DeleteAnimales(int id)
        {
            try
            {
                using (webserviceanimalesEntities conexion = new webserviceanimalesEntities())
                {
                    var consulta = (from l in conexion.animales where l.id == id select l).FirstOrDefault();
                    if(consulta!= null)
                    {
                        conexion.animales.Remove(consulta);
                        conexion.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
