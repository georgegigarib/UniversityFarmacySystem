﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _1ParcialJP
{
    public partial class FrmAMedico : Form
    {
        public FrmAMedico()
        {
            InitializeComponent();
        }
        private void FrmAMedico_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMedico fmmedico = new FrmMedico();
            FrmMenu fmmenu = new FrmMenu();
            fmmenu.abrirForm(fmmedico);

        }
        private void FrmAMedico_Load(object sender, EventArgs e)
        {
            eSTADOComboBox.SelectedIndex = 0;
            this.ControlBox = false;
        }
       
        private void btnGguardar_Click_1(object sender, EventArgs e)
        {
           
            string cedula = cEDULATextBox.Text;

            if (ValidacionCedula.validaCedula(cedula))
            {
                try
                {
                    string sql = $"INSERT INTO MEDICO VALUES ( @nombre , @cedula, @tanda , @especialidad, @estado)";
                    SqlCommand command = new SqlCommand(sql);
                    command.Parameters.AddWithValue("@nombre", nOMBRETextBox.Text);
                    command.Parameters.AddWithValue("@cedula", cEDULATextBox.Text);
                    command.Parameters.AddWithValue("@tanda", tANDA_LABORTextBox.Text);
                    command.Parameters.AddWithValue("@especialidad", eSPECIALIDADTextBox.Text);
                    command.Parameters.AddWithValue("@estado", eSTADOComboBox.Text);
                    Helper.DoQueryExecuterLimpio(command);
                    MessageBox.Show("Registro guardado con exito");
                    this.Close();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error al guardar registro: " + er);
                }
            }
            else
            {
                MessageBox.Show("Cedula Incorrecta");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
