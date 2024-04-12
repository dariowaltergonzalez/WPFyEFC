using EFC;
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

          
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lstRoles.SelectedItems)
            {
                var rol = (rolesBox)item;
                MessageBox.Show($"Id:{rol.Id} Nombre: {rol.Nombre}");
            }

            List<rolesBox> selectedCoasters = lstRoles.SelectedItems.Cast<rolesBox>().ToList();
        }

        private void btnSacar_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lstRoles2.SelectedItems)
            {
                var rol = (rolesBox)item;
                MessageBox.Show(rol.Nombre);
            }
        }

    }
}
