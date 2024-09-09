using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.Models.FlunaSeptiembreContext context = new DL.Models.FlunaSeptiembreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}','{usuario.ApellidoMaterno}','{usuario.ApellidoPaterno}','{usuario.CURP}','{usuario.FechaNacimiento}','{usuario.Sexo}','{usuario.Telefono}'");
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el usuario";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.Models.FlunaSeptiembreContext context = new DL.Models.FlunaSeptiembreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioUpdate {usuario.IdUsuario},'{usuario.Nombre}','{usuario.ApellidoMaterno}','{usuario.ApellidoPaterno}','{usuario.CURP}','{usuario.FechaNacimiento}','{usuario.Sexo}','{usuario.Telefono}'");
                    if(query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo el usuario";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.Models.FlunaSeptiembreContext context = new DL.Models.FlunaSeptiembreContext())
                {
                    // var query = context.Usuarios.FromSqlRaw($"UsuarioGetAll'{usuario.Nombre}','{usuario.ApellidoMaterno}','{usuario.ApellidoPaterno}','{usuario.CURP}','{usuario.FechaNacimiento}','{usuario.Sexo}','{usuario.Telefono}'").ToList();
                    var query = context.Usuarios.FromSqlRaw("UsuarioGetAll").ToList();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.CURP = obj.Curp;
                            usuario.FechaNacimiento = obj.FechaNacimiento.Value;
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.Models.FlunaSeptiembreContext context = new DL.Models.FlunaSeptiembreContext())
                {
                    var objquery = context.Usuarios.FromSqlRaw($"UsuarioGetById {IdUsuario}").AsEnumerable().FirstOrDefault();
                    if(objquery != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = objquery.IdUsuario;
                        usuario.Nombre = objquery.Nombre;
                        usuario.ApellidoMaterno = objquery.ApellidoMaterno;
                        usuario.ApellidoPaterno = objquery.ApellidoPaterno;
                        usuario.CURP = objquery.Curp;
                        usuario.FechaNacimiento = objquery.FechaNacimiento.Value;
                        usuario.Sexo = objquery.Sexo;
                        usuario.Telefono = objquery.Telefono;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.Models.FlunaSeptiembreContext context = new DL.Models.FlunaSeptiembreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioDelete {IdUsuario}");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al Eliminar Registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
