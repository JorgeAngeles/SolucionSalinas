using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices;
using ML;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.getCadenaConexion()))
                {
                    string Query = "UsuarioAdd";
                    SqlCommand cmd = DL.Conexion.CreateCommand(Query, context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);

                    int RowsAffected = DL.Conexion.ExecuteComand(cmd);

                    if(RowsAffected >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.getCadenaConexion()))
                {
                    string Query = "UsuarioAdd";
                    SqlCommand cmd = DL.Conexion.CreateCommand(Query, context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);

                    int RowsAffected = DL.Conexion.ExecuteComand(cmd);

                    if (RowsAffected >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.getCadenaConexion()))
                {
                    string Query = "UsuarioGetAll";
                    SqlCommand cmd = DL.Conexion.CreateCommand(Query,context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable table = DL.Conexion.ExecuteCommandSelect(cmd);
                    result.Objects = new List<object>();
                    if(table.Rows.Count >= 1)
                    {
                        result.Correct = true;
                        foreach (DataRow row in table.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.NombreUsuario = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Edad = Int16.Parse(row[5].ToString());
                            usuario.Sexo = row[5].ToString();
                            usuario.Email = row[5].ToString();

                            result.Objects.Add(usuario);
                        }
                    }
                }
            }
            catch ( Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.getCadenaConexion()))
                {
                    string Query = "UsuarioGetAll";
                    SqlCommand cmd = DL.Conexion.CreateCommand(Query, context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    DataTable table = DL.Conexion.ExecuteCommandSelect(cmd);
                    
                    if (table.Rows.Count >= 1)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.NombreUsuario = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Edad = Int16.Parse(row[5].ToString());
                            usuario.Sexo = row[5].ToString();
                            usuario.Email = row[5].ToString();

                            result.Object = usuario;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
