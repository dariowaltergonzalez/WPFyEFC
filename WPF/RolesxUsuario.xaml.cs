using EFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public List<usuariosBox> ListaUsuarios2 { get; set; }

        public RolesxUsuario()
        {
            InitializeComponent();
            LlenarComboUsuario();
            LlenarListaRoles();
            LlenarListaUsuario();
            LlenarLista2();

        }
        private void LlenarLista2()
        {
            lstListado2.Items.Add("12:00 a 16:00");
            lstListado2.Items.Add("18:00 a 19:00");
            lstListado2.Items.Add("19:30 a 23:30");

        }

        private void LlenarListaUsuario() 
        {
            using (DapperEntities DB = new DapperEntities())
            {
                ListaUsuarios2 = DB.usuariosBox.ToList();
                lstListado.ItemsSource = ListaUsuarios2;
                dgSimple.ItemsSource = ListaUsuarios2;
            }
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

        private void txtNumero_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string cadena = txtNumero.Text;
            e.Handled = !AreAllValidNumericChars(e.Text, cadena);
            base.OnPreviewTextInput(e);
        }

        private bool AreAllValidNumericChars(string str, string cadena)
        {
            char[] delimiterChars = { '.' };
            int largo = 0;
            if (cadena.Contains(".") == true) 
            {
                string[] segmentos = cadena.Split(delimiterChars);
                largo = segmentos[1].Length;
            }

            foreach (char c in str)
            {
                if (c != '.')
                {   

                    if (!Char.IsNumber(c)) return false;

                    if (Char.IsNumber(c) && largo >= 2) return false;

                }
                else
                {
                    if (cadena.Contains(".") == true)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        private void dtpFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string fecha = dtpFecha.SelectedDate.ToString();
            int hh = 0;
        }

        private void btnEjecutarStore_Click(object sender, RoutedEventArgs e)
        {

            //funciona ok   ..retorna la cantidad de registros insertados
            //con el Modelo.edmx abierto, seleccionar  del menu ..Ver..Otras Ventanas.. Explorador de Entity Data Model para poder ver el store sql de la base.
            //si hacemos modificaciones en el store, hay que eliminarlo de 2 carpetas, guardar el modelo y volverlo a agregar.
            // Las 2 carpetas de llaman...Importaciones de funciones....y...funciones/procedimientos almacenados
            using (DapperEntities DB = new DapperEntities())
            {
                // funciona ok.
                //var retorno = DB.sp_usuariosbox_Insert("JHONY","PASS2222",true,false,1,1);
                //var qty = retorno.ToString();

                // funciona ok. SELECT NOMBRE FROM ..el store devuelve una columna de un solo registro
                //var nombre = DB.sp_usuariosbox_SelectByPass("PASS2222");
                //var nombre_user = nombre.Single();  // string nombre_user = nombre.FirstOrDefault(); tambien funciona
                //string nombrecompleto = nombre_user + " " + " CASTRO";

                // funciona ok..el store retorna una columna de nombres (una lista) con el comando "select Nombre From ....." 
                //List<string> miLista = new List<string>();
                //var nombre = DB.sp_usuariosbox_SelectByPass("PASS2222");
                //miLista = nombre.ToList();
                //lstListado3.ItemsSource = miLista;



                // ....probando
                List<Gente> miListaGente = new List<Gente>();
 
                var retorno = DB.sp_usuariosbox_SelectByPass("PASS2222");
                
                string id = "";
                foreach (string item in retorno) 
                {
                    id = item;
                }

                    
                    //string[] authorsList = item.Split(", ");
       

                //miListaGente.Add(new Gente
                //{
                //    GenteID = item,
                //    Nombre = "I'm Gonna Be (500 Miles)"
                //});


                lstListado3.ItemsSource = miListaGente;
                // System.Data.Entity.Core.Objects.ObjectResult<string>
            }
        }
    }

    public class Gente
    {
        public string GenteID { get; set; }
        public string Nombre { get; set; }
    }
}
