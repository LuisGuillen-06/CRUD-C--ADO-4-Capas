﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Attributes;
using Domain.CRUD;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Variables

        CPersona personas = new CPersona();
        AttributesPeople attributes = new AttributesPeople();
        bool edit = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void getData()
        {
            CPersona cPersona = new CPersona();
            DgvDatos.DataSource = cPersona.Mostrar();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSexo.SelectedIndex = 0;
            btnGuardar.Enabled = false;
            getData();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre") txtNombre.Text = "";
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") txtNombre.Text = "Nombre";
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Apellido") txtApellido.Text = "";
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text == "") txtApellido.Text = "Apellido";
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            if(txtID.Text == "ID") txtID.Text = "";
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "") txtID.Text = "ID";
        }

        private void LimpiarTextBox()
        {
            txtNombre.Text = "Nombre";
            txtApellido.Text = "Apellido";
            txtID.Text = "ID";
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(edit == false)
            {
                //Insertar
                try
                {
                    attributes.ID = Convert.ToInt32(txtID.Text);
                    attributes.Nombre = txtNombre.Text;
                    attributes.Apellido = txtApellido.Text;
                    attributes.Sexo = cmbSexo.Text;
                    personas.Insertar(attributes);
                    LimpiarTextBox();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    MessageBox.Show("Se Guardo de forma exitosa", "INSERTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            else if(edit == true)
            {
                //Actualizar
                try
                {
                    attributes.ID = Convert.ToInt32(txtID.Text);
                    attributes.Nombre = txtNombre.Text;
                    attributes.Apellido = txtApellido.Text;
                    attributes.Sexo = cmbSexo.Text;
                    personas.Modificar(attributes);
                    LimpiarTextBox();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    txtID.Enabled = true;
                    edit = false;
                    MessageBox.Show("Se Actualizo un Registro de forma exitosa", "MODIFICADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(DgvDatos.SelectedRows.Count > 0)
            {
                txtID.Enabled = false;
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                edit = true;
                //Cargar Datos
                txtID.Text = DgvDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = DgvDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = DgvDatos.CurrentRow.Cells[2].Value.ToString();
                cmbSexo.Text = DgvDatos.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar...") txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar...";
                getData();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(DgvDatos.SelectedRows.Count > 0)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("DESEAS ELMINAR ESTE REGISTRO?","ELIMINADO",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        attributes.ID = Convert.ToInt32(DgvDatos.CurrentRow.Cells[0].Value.ToString());
                        personas.Eliminar(attributes);
                        getData();
                        MessageBox.Show("Registro Elimado Correctamente","ELIMINADO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"SE PRODUJO EL SIGUIENTE ERROR: {ex.ToString()}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CPersona cPersona = new CPersona();
            DgvDatos.DataSource = cPersona.Buscar(txtBuscar.Text);
        }
    }
}
