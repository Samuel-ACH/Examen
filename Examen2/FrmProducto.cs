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
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }
        string operacion = string.Empty;

        ProductoDA productoDA = new ProductoDA();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }
        private void HabilitarControles()
        {
            txtcodigo.Enabled = true;
            txtdescripcion.Enabled = true;
            txtprecio.Enabled = true;
            txtexistencia.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;


        }
        private void DesabilitarControles()
        {
            txtcodigo.Enabled = false;
            txtdescripcion.Enabled = false;
            txtprecio.Enabled = false;
            txtexistencia.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;

        }
        private void LimpiarControles()
        {
            txtcodigo.Clear();
            txtdescripcion.Clear();
            txtprecio.Clear();
            txtexistencia.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtcodigo.Text))
                {
                    errorProvider1.SetError(txtcodigo, "Ingrese el código");
                    txtcodigo.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtdescripcion.Text))
                {
                    errorProvider1.SetError(txtdescripcion, "Ingrese una descripción");
                    txtdescripcion.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtprecio.Text))
                {
                    errorProvider1.SetError(txtprecio, "Ingrese un precio");
                    txtprecio.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtexistencia.Text))
                {
                    errorProvider1.SetError(txtexistencia, "Ingrese una existencia");
                    txtexistencia.Focus();
                    return;
                }

                Producto producto = new Producto();
                producto.Codigo = txtcodigo.Text;
                producto.Descripcion = txtdescripcion.Text;
                producto.Precio = Convert.ToDecimal(txtprecio.Text);
                producto.Existencia = Convert.ToInt32(txtexistencia.Text);

                if (operacion == "Nuevo")
                {
                    bool inserto = productoDA.InsertarProducto(producto);

                    if (inserto)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        ListarProductos();
                        MessageBox.Show("Producto insertado");
                    }
                }
                if (operacion == "Nuevo")
                {
                    bool inserto = productoDA.InsertarProducto(producto);

                    if (inserto)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        ListarProductos();
                        MessageBox.Show("Producto insertado");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void ListarProductos()
        {
            ProductosdataGridView.DataSource = productoDA.ListarProductos();
        }
    }
}
