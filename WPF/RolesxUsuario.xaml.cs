﻿using EFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Lógica de interacción para RolesxUsuario.xaml
    /// https://www.c-sharpcorner.com/uploadfile/mahesh/listbox-in-wpf/
    /// </summary>
    public partial class RolesxUsuario : Page
    {
        public List<usuariosBox> ListaUsuarios { get; set; }
        public List<rolesBox> ListaRoles { get; set; }
        //public List<roles_por_usuario> ListaRolesPorUsuario { get; set; }


        public RolesxUsuario()
        {
            InitializeComponent();
            LlenarComboUsuario();
            LlenarListaRoles();

        }

        private void LlenarListaRoles()
        {
            using (DapperEntities DB = new DapperEntities()) 
            {
                ListaRoles = DB.rolesBox.ToList();
                lstRoles.ItemsSource = ListaRoles;
                lstRoles2.ItemsSource = ListaRoles;
            }
        }

        private void LlenarComboUsuario()
        {
            using (DapperEntities DB = new DapperEntities())
            {
                ListaUsuarios = DB.usuariosBox.ToList();
            }
            cbousuarios.DataContext = ListaUsuarios;
        }

        private void cbousuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cbousuarios.SelectedItem as usuariosBox;
            var userId = item.Id;
            LlenarListaRolesxUsuario(userId);
            //var id = item.Id.ToString();
            //Sucursal_id_selected = item.Id.ToString();
            //var item = cbosucursal.SelectedItem as usuario;
            //if (item != null) 
            //{
            //MessageBox.Show(item.id.ToString());

        }

        private void LlenarListaRolesxUsuario(int userId)
        {
            //ListaRolesPorUsuario = DB.RolesPorUsuario.ConsultarPorUsuario(userId);
            //lstRolesAsignados.ItemsSource = ListaRolesPorUsuario;
        }

        //x:5
        //foreach (var item in lstRoles.SelectedItems.OfType<rolesBox>())
        //    {
        //        MessageBox.Show(item.Id.ToString());
        //        MessageBox.Show(item.Nombre);
        //    }


        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //var currentItemText = lstRoles.SelectedValue.ToString();

            
            //var currentItemIndex = lstRoles.SelectedIndex;

            //MessageBox.Show(currentItemText);

            foreach (var item in lstRoles.SelectedItems.OfType<rolesBox>())
            {
                MessageBox.Show(item.Id.ToString());
            }

            //foreach (var item in lstRoles.SelectedValuePath.che)
            //{
            //    MessageBox.Show("ddd");
            //}

            //foreach (var item in lstRoles.Items.OfType<rolesBox>())
            //{

            //    MessageBox.Show(item.Nombre);
            //}

            //var chapters = new rolesBox();

            //foreach (var item in lstRoles.SelectedItems)
            //{
            //    MessageBox.Show("ddd");
            //}
            //for (int i = 0; i < lstRoles.Items.Count; i++)
            //{
            //    if (lstRoles.Items[i].Checked)
            //    {
            //        MessageBox.Show("Listview items " + lstRoles.Items[i] + " is checked");
            //    }
            //}
        }

        private void btnSacar_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}