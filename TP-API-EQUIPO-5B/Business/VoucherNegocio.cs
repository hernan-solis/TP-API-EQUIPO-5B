using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Models;

namespace Business
{
    public class VoucherNegocio
    {
        public bool codigoValido(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Consulta para verificar si existe un voucher con el código y los campos nulos
                string consulta = @"
            SELECT COUNT(*) 
             FROM Vouchers 
             WHERE CodigoVoucher = @codigo
              AND IdCliente IS NULL
              AND FechaCanje IS NULL
              AND IdArticulo IS NULL";

                datos.setearConsulta(consulta);
                datos.setearParametro("@codigo", codigo);

                // Ejecutamos la consulta
                datos.ejecutarLectura();

                int cantidad = 0;
                if (datos.Lector.Read()) // Si hay resultado
                {
                    cantidad = datos.Lector.GetInt32(0); // Obtenemos el COUNT(*)
                }

                return cantidad > 0; // true si encontró al menos uno
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

        public void modificar(Voucher voucher)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"
            UPDATE Vouchers
            SET IdCliente = @idCliente,
                FechaCanje = @fechaCanje,
                IdArticulo = @idArticulo
            WHERE CodigoVoucher = @codigo";

                datos.setearConsulta(consulta);
                datos.setearParametro("@idCliente", voucher.IdCliente);
                datos.setearParametro("@fechaCanje", voucher.FechaCanje);
                datos.setearParametro("@idArticulo", voucher.IdArticulo);
                datos.setearParametro("@codigo", voucher.Codigo);

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


    }


}