using EFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
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
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Page
    {
        public List<sucursalesBox> Listasucursales { get; set; }
        public string Sucursal_id_selected { get; set; }

        public Usuarios()
        {
            InitializeComponent();
            LlenarComboSucursal();
            LlenarGrilla();
        }

        private void LlenarComboSucursal()
        {
            using (DapperEntities db2 = new DapperEntities())
            {
                DataContext = db2.sucursalesBox.ToList();
            }
        }

        private void LlenarGrilla()
        {
            using (DapperEntities db2 = new DapperEntities())
            {
                var mylista = db2.usuariosBox.Include(x => x.sucursalesBox).ToList();
                dgUsuarios.ItemsSource = mylista;

            }
        }

        private bool FiltroporNombre(object obj)
        {
            var Filterobj = obj as usuariosBox;
            if (txtFiltroNombre.Text != string.Empty)
            {
                return Filterobj.Nombre.Contains(txtFiltroNombre.Text);
            }
            else
            {
                return false;
            }
        }

        private void txtFiltroNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFiltroNombre.Text == string.Empty)
            {
                dgUsuarios.Items.Filter = null;
            }
            else
            {
                dgUsuarios.Items.Filter = FiltroporNombre;
            }

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            var item = cbosucursal.SelectedItem as sucursalesBox;

            usuariosBox usuario = new usuariosBox();
            var nombre = txtNombre.Text.ToUpper();
            var pass = PasswordBox.Password;
            //var pass = txtPassword.Text;
            var activo = chkActivo.IsChecked;
            var bloqueado = chkBloqueado.IsChecked;
            var suc_id = item.Id;

            usuario.Nombre = nombre;
            usuario.Pass = pass;
            usuario.Activo = (bool)activo;
            usuario.UsuarioBloqueado = (bool)bloqueado;
            usuario.IdSucursal = suc_id;

            using (DapperEntities db = new DapperEntities())
            {
                db.usuariosBox.Add(usuario);
                db.SaveChanges();
            }
            LlenarGrilla();
            dgUsuarios.Focus();
            dgUsuarios.SelectedIndex = 0;
            //PasswordBox.Password = "";

            MessageBox.Show("El registro se creo correctamente", "Alta de Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            int fila = 0;
            fila = dgUsuarios.SelectedIndex;

            usuariosBox usuarioSelect = dgUsuarios.SelectedItem as usuariosBox;
            if (usuarioSelect != null)
            {
                if (MessageBox.Show("¿Esta seguro de Actualizar el registro actual?",
                            "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var item = cbosucursal.SelectedItem as sucursalesBox;

                    usuariosBox usuario = new usuariosBox();

                    usuario.Id = usuarioSelect.Id;
                    usuario.Nombre = txtNombre.Text.ToUpper();
                    //usuario.Pass = txtPassword.Text;
                    usuario.Pass = PasswordBox.Password;
                    usuario.IdSucursal = item.Id;
                    usuario.Activo = (bool)chkActivo.IsChecked;
                    usuario.UsuarioBloqueado = (bool)chkBloqueado.IsChecked;

                    using (DapperEntities db = new DapperEntities())
                    {
                        var encontrado = db.usuariosBox.FirstOrDefault(x => x.Id == usuario.Id);
                        if (encontrado != null)
                        {
                            encontrado.Nombre = usuario.Nombre;
                            encontrado.Pass = usuario.Pass;
                            encontrado.Activo = usuario.Activo;
                            encontrado.UsuarioBloqueado = usuario.UsuarioBloqueado;
                            encontrado.IdSucursal = usuario.IdSucursal;
                            db.SaveChanges();
                        }
                    }
                    LlenarGrilla();
                    dgUsuarios.Focus();
                    dgUsuarios.SelectedIndex = fila;
                    //PasswordBox.Password = "";
                    //txtPassword.Password = "";
                }
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int fila = 0;
            fila = dgUsuarios.SelectedIndex;

            usuariosBox usuarioSelect = dgUsuarios.SelectedItem as usuariosBox;
            if (usuarioSelect != null)
            {
                if (MessageBox.Show("¿Esta seguro de Eliminar el registro actual?",
                    "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    using (DapperEntities db = new DapperEntities())
                    {
                        var encontrado = db.usuariosBox.FirstOrDefault(x => x.Id == usuarioSelect.Id);
                        if (encontrado != null)
                        {
                            db.usuariosBox.Remove(encontrado);
                            db.SaveChanges();
                        }
                    }
                    LlenarGrilla();
                    if (fila != 0)
                    {
                        dgUsuarios.Focus();
                        dgUsuarios.SelectedIndex = fila - 1;
                    }
                }
            }
        }
    }
}

