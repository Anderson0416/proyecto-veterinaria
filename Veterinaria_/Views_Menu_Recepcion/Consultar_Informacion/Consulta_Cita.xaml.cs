using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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

namespace Veterinaria_.Views_Menu_Recepcion.Consultar_Informacion
{
    /// <summary>
    /// Lógica de interacción para Consulta_Cita.xaml
    /// </summary>
    public partial class Consulta_Cita : UserControl
    {
        private List<Cita_Tipo_Consulta> consultas_Seleccionadas = new List<Cita_Tipo_Consulta>();
        int id_Cita;
        int id_Propietario;
        private List<Citas> listaCitasOriginal;
        public Consulta_Cita()
        {
            InitializeComponent();
            Mostrar_Veterinario_cmb();
            Mostrar_Tipo_Consulta();
            Llenar_Tabla_Citas();
        }
        private void Mostrar_Mascota_cmb(string documento)
        {
            Servicio_Mascota servicio_Mascota = new Servicio_Mascota();
            List<Mascota> mascotas = servicio_Mascota.Mascotas_Propietario(documento);
            cmb_Nombre_Mascota.ItemsSource = null;
            cmb_Nombre_Mascota.ItemsSource = mascotas;
            cmb_Nombre_Mascota.DisplayMemberPath = "nombre";
            cmb_Nombre_Mascota.SelectedValuePath = "id";
        }
        private void Llenar_Tabla_Citas()
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            listaCitasOriginal = servicio_cita.Lista_Todos_Citas();
            dtg_Tabla_Citas.ItemsSource = listaCitasOriginal;
        }
        private void Llenar_Tabla_Tipo_consulta(int id)
        {
            Servicio_Cita_Tipo_Consulta servicio_cita_tipo_consulta = new Servicio_Cita_Tipo_Consulta();
            consultas_Seleccionadas = servicio_cita_tipo_consulta.Citas_Tipo_Consultas_Id(id);
            dtg_Tabla_Tipo_Consulta.ItemsSource = consultas_Seleccionadas;
            Calcular_Total_Precio();
        }
        private void Mostrar_Veterinario_cmb()
        {
            Servicio_Veterinario servicio_Veterinario = new Servicio_Veterinario();
            List<Veterinario> veterinarios = servicio_Veterinario.Lista_Todos_Veterinario();
            cmb_Nombre_Veterinario.ItemsSource = null;
            cmb_Nombre_Veterinario.ItemsSource = veterinarios;
            cmb_Nombre_Veterinario.DisplayMemberPath = "nombre";
            cmb_Nombre_Veterinario.SelectedValuePath = "id";
        }
        private void Mostrar_Tipo_Consulta()
        {
            Servicio_Tipo_Consulta servicio_Tipo_Consulta = new Servicio_Tipo_Consulta();
            List<Tipo_Consulta> tipo_Consultas = servicio_Tipo_Consulta.Lista_Tipo_Consulta();
            cmb_Tipo_Consulta.ItemsSource = null;
            cmb_Tipo_Consulta.ItemsSource = tipo_Consultas;
            cmb_Tipo_Consulta.DisplayMemberPath = "nombre";
            cmb_Tipo_Consulta.SelectedValuePath = "id" + "nombre" + "precio";
        }
        private void Llenar_Tabla()
        {
            if (cmb_Tipo_Consulta.SelectedItem != null)
            {
                Tipo_Consulta tipo_Consulta = (Tipo_Consulta)cmb_Tipo_Consulta.SelectedItem;
                if (!consultas_Seleccionadas.Any(c => c.id == tipo_Consulta.id))
                {
                    Cita_Tipo_Consulta citaTipoConsulta = new Cita_Tipo_Consulta
                    {
                        id = tipo_Consulta.id, 
                        tipo_consulta = tipo_Consulta
                    };

                    consultas_Seleccionadas.Add(citaTipoConsulta);
                    dtg_Tabla_Tipo_Consulta.ItemsSource = null; 
                    dtg_Tabla_Tipo_Consulta.ItemsSource = consultas_Seleccionadas;
                    Calcular_Total_Precio();
                }
            }
        }
        private void Calcular_Total_Precio()
        {
            if (consultas_Seleccionadas != null && consultas_Seleccionadas.Any())
            {
                decimal total = consultas_Seleccionadas.Sum(consulta => consulta.tipo_consulta?.precio ?? 0);
                txt_Total_Pagar.Text = total.ToString("C2");
            }
        }
        private void borrar_Tabla()
        {
            if (dtg_Tabla_Tipo_Consulta.SelectedItem != null)
            {
                Cita_Tipo_Consulta citaTipoConsulta = dtg_Tabla_Tipo_Consulta.SelectedItem as Cita_Tipo_Consulta;

                if (citaTipoConsulta != null)
                {
                    consultas_Seleccionadas.Remove(citaTipoConsulta);
                    dtg_Tabla_Tipo_Consulta.Items.Refresh(); 
                    Calcular_Total_Precio();
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila para eliminar.");
            }
        }
        private void btn_borrar_Tipo_Consulta_Click(object sender, RoutedEventArgs e)
        {
            borrar_Tabla();
        }
        private void cmb_Tipo_Consulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Llenar_Tabla();
        }
        private void Selecionar_Datos()
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            Citas citaSeleccionada = (Citas)dtg_Tabla_Citas.SelectedItem;

            if (citaSeleccionada != null)
            {
                id_Cita = citaSeleccionada.id;
                id_Propietario = citaSeleccionada.propietario.id;
                Citas cita = servicio_cita.Cita_Id(id_Cita);

                if (cita != null)
                {
                    txt_Nombre_Propietario.Text = cita.propietario.nombre;
                    txt_Estado.Text = cita.estado;
                    txt_Nota.Text = cita.nota;
                    string valor = cita.total_pagar.ToString("F2");
                    txt_Total_Pagar.Text = valor;
                    Mostrar_Mascota_cmb(cita.propietario.documento);
                    foreach (var item in cmb_Nombre_Mascota.Items)
                    {
                        if (item is Mascota mascota && mascota.nombre == cita.mascota.nombre)
                        {
                            cmb_Nombre_Mascota.SelectedItem = item;
                            break;
                        }
                    }
                    foreach (var item in cmb_Nombre_Veterinario.Items)
                    {
                        if (item is Veterinario veterinario && veterinario.nombre == cita.veterinario.nombre)
                        {
                            cmb_Nombre_Veterinario.SelectedItem = item;
                            break;
                        }
                    }
                    if (cita.fecha_cita != null)
                    {
                        dtp_Fecha_Consulta.SelectedDate = cita.fecha_cita;
                    }
                    Llenar_Tabla_Tipo_consulta(id_Cita);
                }

            }
        }
        private void dtg_Tabla_Mascota_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dtg_Tabla_Citas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selecionar_Datos();
        }
        private void txt_Buscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txt_Buscar.Text.ToLower();
            var listaFiltrada = listaCitasOriginal.Where(cita =>
                (cita.propietario.nombre != null && cita.propietario.nombre.ToLower().Contains(filtro)) ||
                (cita.mascota.nombre != null && cita.mascota.nombre.ToLower().Contains(filtro)) ||
                (cita.veterinario.nombre != null && cita.veterinario.nombre.ToLower().Contains(filtro)) ||
                (cita.estado != null && cita.estado.ToLower().Contains(filtro)) ||
                FiltrarPorFecha(cita.fecha_cita, filtro) ||
                cita.total_pagar.ToString().Contains(filtro) ||
                (cita.nota != null && cita.nota.ToLower().Contains(filtro))
            ).ToList();
            dtg_Tabla_Citas.ItemsSource = listaFiltrada;
        }
        private bool FiltrarPorFecha(DateTime fechaCita, string filtro)
        {
            if (int.TryParse(filtro, out int numero))
            {
                bool esDia = (numero >= 1 && numero <= 31 && fechaCita.Day == numero);
                bool esMes = (numero >= 1 && numero <= 12 && fechaCita.Month == numero);

                return esDia || esMes;
            }
            return false;
        }
        private Citas Tomar_Datos_Cita()
        {
            Citas citas = new Citas();
            citas.id = id_Cita;
            citas.propietario = new Propietario();
            citas.mascota = new Mascota();
            citas.veterinario = new Veterinario();

            citas.propietario.id = id_Propietario;
            citas.mascota.id = (int)cmb_Nombre_Mascota.SelectedValue;
            citas.veterinario.id = (int)cmb_Nombre_Veterinario.SelectedValue;
            citas.fecha_cita = dtp_Fecha_Consulta.SelectedDate.Value;
            citas.estado = txt_Estado.Text;
            citas.nota = txt_Nota.Text;
            string total = txt_Total_Pagar.Text;
            string total_numero = total.Replace("$", "").Trim();
            citas.total_pagar = decimal.Parse(total_numero, System.Globalization.NumberStyles.Any);
            return citas;
        }
        private void Limpiar()
        {            
            txt_Nombre_Propietario.Clear();
            cmb_Nombre_Mascota.SelectedIndex = -1;
            dtp_Fecha_Consulta.SelectedDate = null;
            txt_Estado.Clear();
            txt_Total_Pagar.Clear();
            cmb_Nombre_Veterinario.SelectedIndex = -1;
            txt_Nota.Clear();
            dtg_Tabla_Tipo_Consulta.ItemsSource = null;

        }
        public void Eliminar()
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            Citas citas = new Citas();
            citas = Tomar_Datos_Cita();
            var respuesta = servicio_cita.Eliminar_Citas(citas);
            MessageBox.Show(respuesta);
        }
        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            Limpiar();
            Llenar_Tabla_Citas();

        }
        public void Actualizar()
        {
            Servicio_Cita servicio_cita = new Servicio_Cita();
            Citas citas = new Citas();
            citas = Tomar_Datos_Cita();
            var respuesta = servicio_cita.Actualizar_Citas(citas);
            MessageBox.Show(respuesta);

        }
        private void Eliminar_Cita_Tipo_Consulta()
        {
            Servicio_Cita_Tipo_Consulta servicio_cita_tipo_consulta = new Servicio_Cita_Tipo_Consulta();
            servicio_cita_tipo_consulta.Eliminar_Citas(id_Cita);
        }
        private List<Tipo_Consulta> ObtenerTiposDeConsulta()
        {
            return consultas_Seleccionadas.Where(c => c.tipo_consulta != null).Select(c => c.tipo_consulta).ToList();
        }
        private void Tomar_Datos_Tipo_Consulta()
        {
            Servicio_Cita_Tipo_Consulta servicio_Cita_Tipo_Consulta = new Servicio_Cita_Tipo_Consulta();
            List<Tipo_Consulta> lista_consultas = ObtenerTiposDeConsulta();
            servicio_Cita_Tipo_Consulta.Guardar_Cita_Consultas(lista_consultas);
        }
        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
            Limpiar();
            Llenar_Tabla_Citas();
            Eliminar_Cita_Tipo_Consulta();
            Tomar_Datos_Tipo_Consulta();

        }

        private void btn_Pagar_Click(object sender, RoutedEventArgs e)
        {
            Pagar_Consulta pagar_Consulta = new Pagar_Consulta(this);
            pagar_Consulta.Show();
        }
        public int Id_cita()
        {
            return id_Cita;
        }
    }
}
