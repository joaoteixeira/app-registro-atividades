
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
using RegistroAtividadesApp.Database;

namespace RegistroAtividadesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<string> listRecurso = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            FillForm();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FillFormCheck())
                SaveInfo();

        }

        private void SaveInfo()
        {
            try
            {
                Conexao conn = new Conexao();

                var query = conn.Query();
                query.CommandText = "INSERT INTO atividades (servidor, atividade, sistema) " +
                    "VALUES (@servidor, @atividade, @sistema)";
                //query.Parameters.AddWithValue("@data", "2021-04-12");
                query.Parameters.AddWithValue("@servidor", "João Eujácio Teixeira Junior");
                query.Parameters.AddWithValue("@atividade", txtAtividade.Text);
                query.Parameters.AddWithValue("@sistema", String.Join(", ", listRecurso));
                query.ExecuteNonQuery();
                conn.Close();

                ClearForm();

                MessageBox.Show("Atividade inserida com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool FillFormCheck()
        {
            //if (listRecurso.Count > 0 && !txtAtividade.Text.Equals("") && !txtAtividade.Text.Equals(null))
            //    return true;
            //else
            //    textBlockInfo.Text = "Preencher os campos antes de salvar...";

            return false;
        }

        private void FillForm()
        {
            string[] recursos = { "Google Meet", "E-mail", "SUAP", "AVA", "SEI" };
            //cbRecurso.ItemsSource = recursos;

            foreach (var item in recursos)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Content = item;
                //checkbox.Width = 100;
                checkbox.HorizontalAlignment = HorizontalAlignment.Left;
                checkbox.FontSize = 16;
                checkbox.Margin = new Thickness(10);
                //checkbox.Style = this.FindResource("CircleCheckbox") as Style;
                checkbox.Checked += new RoutedEventHandler(HandleCheck);
                checkbox.Unchecked += new RoutedEventHandler(HandleUnCheck);

                stackPanelRecurso.Children.Add(checkbox);
            }
        }

        private void HandleUnCheck(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;

            listRecurso.Remove(check.Content.ToString());
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;

            listRecurso.Add(check.Content.ToString());
        }

        private void ClearForm()
        {
            txtAtividade.Text = null;
        }

        private void GotFocuus(object sender, RoutedEventArgs e)
        {
            //textBlockInfo.Text = "";
        }
    }
}
