using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Entidades;
namespace Datos.Accesos
{
    public class PedidoDA
    {
        readonly string cadena = "server = localhost; Port=3306; Database = examen; Uid = root; Pwd = 12345;";
        MySqlConnection conn;
        MySqlCommand cmd;
        public int InsertarPedidos(Pedidos pedidos)
        {
            int IdPedido = 0;
            try
            {
                string sql = "INSERT INTO pedidos (IdentidadCliente, Cliente, SubTotal, ISV, Total) VALUES (@IdentidadCliente, @Cliente, @SubTotal, @ISV, @Total); select last_insert_id()";
                conn = new MySqlConnection(cadena);
                conn.Open();
                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdentidadCliente", pedidos.IdentidadCliente); 
                cmd.Parameters.AddWithValue("@Cliente", pedidos.Cliente);
                cmd.Parameters.AddWithValue("@SubTotal", pedidos.SubTotal);
                cmd.Parameters.AddWithValue("@ISV", pedidos.ISV);
                cmd.Parameters.AddWithValue("@Total", pedidos.Total);
                IdPedido = Convert.ToInt32(cmd.ExecuteScalar());
               
               
            }
            catch (Exception ex) { }

            return IdPedido;
        }
        public bool InsertarDetalle(DetallePedido detallePedido)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO detallepedido (IdPedido, CodigoProducto, Descripcion, Cantidad, Precio, Total) VALUES (@IdPedido, @CodigoProducto, @Descripcion, @Cantidad, @Precio, @Total);";
                conn = new MySqlConnection(cadena);
                conn.Open();
                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdFactura", detallePedido.IdPedido);
                cmd.Parameters.AddWithValue("@Codigo Producto", detallePedido.CodigoProducto);
                cmd.Parameters.AddWithValue("@Descripcion", detallePedido.Descripcion); 
                cmd.Parameters.AddWithValue("@Cantidad", detallePedido.Cantidad); 
                cmd.Parameters.AddWithValue("@Precio", detallePedido.Precio); 
                cmd.Parameters.AddWithValue("@Total", detallePedido.Total); 
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) { }

            return inserto;
        }
    }
}
