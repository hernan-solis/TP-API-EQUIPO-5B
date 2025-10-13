using Dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public Cliente buscarClientePorDNI(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {


                string consulta = @"SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE DOCUMENTO = @dni";

                datos.setearConsulta(consulta);
                datos.setearParametro("@dni", dni);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = (int)datos.Lector["Id"];
                    cliente.Documento = (string)datos.Lector["Documento"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Ciudad = (string)datos.Lector["Ciudad"];
                    cliente.Cp = (int)datos.Lector["CP"];
                   

                    return cliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Cliente nuevoCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@dni, @nombre, @apellido, @email, @direccion, @ciudad, @cp)";

                datos.setearConsulta(consulta);

                datos.setearParametro("@dni", nuevoCliente.Documento);
                datos.setearParametro("@nombre", nuevoCliente.Nombre);
                datos.setearParametro("@apellido", nuevoCliente.Apellido);
                datos.setearParametro("@email", nuevoCliente.Email);
                datos.setearParametro("@direccion", nuevoCliente.Direccion);
                datos.setearParametro("@ciudad", nuevoCliente.Ciudad);
                datos.setearParametro("@cp", nuevoCliente.Cp);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int ultimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                int id = 0;
                string consulta = "SELECT MAX(Id) AS Id FROM Clientes";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    id = (int)datos.Lector["Id"];
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
