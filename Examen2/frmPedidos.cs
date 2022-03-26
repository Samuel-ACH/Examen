using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2
{
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }
        ProductoDA productoDA = new ProductoDA();
        Pedidos pedidos = new Pedidos();
        Producto producto;
        PedidoDA pedidoDA = new PedidoDA();

        List<DetallePedido> detallePedidoLista = new List<DetallePedido>();

        decimal subTotal = decimal.Zero;
        decimal isv = decimal.Zero;
        decimal totalAPagar = decimal.Zero;

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            DetalleDataGridView.DataSource = detallePedidoLista;
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = new Producto();
                producto = productoDA.GetProductoPorCodigo(txtCodigoProducto.Text);
                txtDescripcion.Text = producto.Descripcion;
                txtCantidad.Focus();
            }
            else
            {
                producto = null;
                txtDescripcion.Clear();
                txtCantidad.Clear();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtCantidad.Text))
            {
                DetallePedido detallePedido = new DetallePedido();
                detallePedido.CodigoProducto = producto.Codigo;
                detallePedido.Descripcion = producto.Descripcion;
                detallePedido.Cantidad = Convert.ToInt32(txtCantidad.Text);
                detallePedido.Precio = producto.Precio;
                detallePedido.Total = producto.Precio * Convert.ToInt32(txtCantidad.Text);
                
                subTotal += detallePedido.Total;
                isv = subTotal * 0.15M;
                totalAPagar = subTotal + isv;

                txtSubtotal.Text = subTotal.ToString();
                txtISV.Text = isv.ToString();
                txtTotal.Text = totalAPagar.ToString();
                

                detallePedidoLista.Add(detallePedido);
                DetalleDataGridView.DataSource = null;
                DetalleDataGridView.DataSource = detallePedidoLista;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            pedidos.IdentidadCliente = txtId.Text;
            pedidos.Cliente = txtNombre.Text;
            pedidos.SubTotal = Convert.ToDecimal(txtSubtotal.Text);
            pedidos.ISV = Convert.ToDecimal(txtISV.Text);
            pedidos.Total = Convert.ToDecimal(txtTotal.Text);
            int idPedidos = 0;

            idPedidos = pedidoDA.InsertarPedidos(pedidos);

            if (idPedidos != 0)
            {
                foreach (var item in detallePedidoLista)
                {
                    item.IdPedido = idPedidos;
                    pedidoDA.InsertarDetalle(item);
                }
            }
        }
    }
}
