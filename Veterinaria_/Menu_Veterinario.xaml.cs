using Entity;
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
using System.Windows.Shapes;

namespace Veterinaria_
{
    /// <summary>
    /// Lógica de interacción para Menu_Veterinario.xaml
    /// </summary>
    public partial class Menu_Veterinario : Window
    {
        public Menu_Veterinario()
        {
            InitializeComponent();
            
        }
        public void Datos_Veterinario()
        {
            Veterinario veterinario = Seccion.veterinario;
            txt_nombre.Text = veterinario.nombre;
        }
    }
}
