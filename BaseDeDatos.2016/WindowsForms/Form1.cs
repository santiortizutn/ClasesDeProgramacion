﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AccesoDatos;

namespace WindowsForms
{
    public partial class frmPersonas : Form
    {
        private List<Persona> _personas;
        private DataTable _tabla;
        private AccesoDatos.AccesoDatos _objAcceso;
        public frmPersonas()
        {
            InitializeComponent();

            this._objAcceso = new AccesoDatos.AccesoDatos();
            this._personas = this._objAcceso.ObtenerListaPersonas();
            this._tabla = this._objAcceso.ObtenerTablaPersonas();
        }


        private void frmPersonas_Load(object sender, EventArgs e)
        {
            this.dgvGrilla.DataSource = this._tabla;
            //this.dgvGrilla.DataSource = this._personas;
            this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ABM frm = new ABM();

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataRow fila = this._tabla.NewRow();
                fila["apellido"] = frm.PersonaDelFormulario.Apellido;
                fila["nombre"] = frm.PersonaDelFormulario.Nombre;
                fila["edad"] = frm.PersonaDelFormulario.Edad;
                //this._tabla.Rows.Add(fila);
                this._objAcceso.InsertarPersona(frm.PersonaDelFormulario);
                //this._personas.Add(frm.PersonaDelFormulario);

                this._tabla = this._objAcceso.ObtenerTablaPersonas();
                this.dgvGrilla.DataSource = this._tabla;
                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
                string dato = this.dgvGrilla.SelectedCells[2].Value.ToString();
                Persona per = this._objAcceso.ObtenerPersonaPorApellido(dato);

                ABM frm = new ABM(per);

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this._objAcceso.EliminarPersona(per);

                    this._tabla = this._objAcceso.ObtenerTablaPersonas();
                    this.dgvGrilla.DataSource = this._tabla;
                    
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dato = this.dgvGrilla.SelectedCells[2].Value.ToString();
            Persona per = this._objAcceso.ObtenerPersonaPorApellido(dato);

            ABM frm = new ABM(per);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this._objAcceso.ModificarPersona(per);

                this._tabla = this._objAcceso.ObtenerTablaPersonas();
                this.dgvGrilla.DataSource = this._tabla;
                
            }
        }
    }


}

