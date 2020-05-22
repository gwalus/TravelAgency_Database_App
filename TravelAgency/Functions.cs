using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Functions
    {
        public void SetDataContextComboBoxSelected(MainWindow mainWindow)
        {
            int choose = mainWindow.comboBox.SelectedIndex;

            using (var context = new BiuroPodrozyEntities())
            {
                switch (choose)
                {
                    case 0:
                        mainWindow.viewModel.TableName = ColumnNames.klienci;
                        mainWindow.viewModel.TableContent = context.Klienci.ToList();
                        mainWindow.TextBox1.Text = mainWindow.TextBox2.Text = mainWindow.TextBox3.Text
                            = mainWindow.TextBox4.Text = mainWindow.TextBox5.Text = mainWindow.TextBox6.Text
                            = mainWindow.TextBox7.Text = mainWindow.TextBox8.Text = mainWindow.TextBox9.Text
                            = mainWindow.TextBox10.Text = mainWindow.TextBox11.Text = "";
                        mainWindow.DataContext = mainWindow.viewModel;
                        break;
                    case 1:
                        mainWindow.viewModel.TableName = ColumnNames.uczestnicy;
                        mainWindow.viewModel.TableContent = context.Uczestnicy.ToList();
                        mainWindow.TextBox1.Text = mainWindow.TextBox2.Text = mainWindow.TextBox3.Text
                            = mainWindow.TextBox4.Text = mainWindow.TextBox5.Text = mainWindow.TextBox6.Text
                            = mainWindow.TextBox7.Text = mainWindow.TextBox8.Text = mainWindow.TextBox9.Text
                            = mainWindow.TextBox10.Text = mainWindow.TextBox11.Text = "";
                        mainWindow.DataContext = mainWindow.viewModel;
                        break;
                    case 2:
                        mainWindow.viewModel.TableName = ColumnNames.zamowienia;
                        mainWindow.viewModel.TableContent = context.Zamówienia.ToList();
                        mainWindow.TextBox1.Text = mainWindow.TextBox2.Text = mainWindow.TextBox3.Text
                            = mainWindow.TextBox4.Text = mainWindow.TextBox5.Text = mainWindow.TextBox6.Text
                            = mainWindow.TextBox7.Text = mainWindow.TextBox8.Text = mainWindow.TextBox9.Text
                            = mainWindow.TextBox10.Text = mainWindow.TextBox11.Text = "";
                        mainWindow.DataContext = mainWindow.viewModel;
                        break;
                    case 3:
                        mainWindow.viewModel.TableName = ColumnNames.wycieczki;
                        mainWindow.viewModel.TableContent = context.Wycieczki.ToList();
                        mainWindow.TextBox1.Text = mainWindow.TextBox2.Text = mainWindow.TextBox3.Text
                            = mainWindow.TextBox4.Text = mainWindow.TextBox5.Text = mainWindow.TextBox6.Text
                            = mainWindow.TextBox7.Text = mainWindow.TextBox8.Text = mainWindow.TextBox9.Text
                            = mainWindow.TextBox10.Text = mainWindow.TextBox11.Text = "";
                        mainWindow.DataContext = mainWindow.viewModel;
                        break;
                    case 4:
                        mainWindow.viewModel.TableName = ColumnNames.hotele;
                        mainWindow.viewModel.TableContent = context.Hotele.ToList();
                        mainWindow.TextBox1.Text = mainWindow.TextBox2.Text = mainWindow.TextBox3.Text
                            = mainWindow.TextBox4.Text = mainWindow.TextBox5.Text = mainWindow.TextBox6.Text
                            = mainWindow.TextBox7.Text = mainWindow.TextBox8.Text = mainWindow.TextBox9.Text
                            = mainWindow.TextBox10.Text = mainWindow.TextBox11.Text = "";
                        mainWindow.DataContext = mainWindow.viewModel;
                        break;
                    case 5:
                        mainWindow.viewModel.TableName = ColumnNames.rezydenci;
                        mainWindow.viewModel.TableContent = context.Rezydenci.ToList();
                        mainWindow.TextBox1.Text = mainWindow.TextBox2.Text = mainWindow.TextBox3.Text
                            = mainWindow.TextBox4.Text = mainWindow.TextBox5.Text = mainWindow.TextBox6.Text
                            = mainWindow.TextBox7.Text = mainWindow.TextBox8.Text = mainWindow.TextBox9.Text
                            = mainWindow.TextBox10.Text = mainWindow.TextBox11.Text = "";
                        mainWindow.DataContext = mainWindow.viewModel;
                        break;
                    case 6:
                        mainWindow.viewModel.TableName = ColumnNames.uslugi;
                        mainWindow.viewModel.TableContent = context.Usługi.ToList();
                        mainWindow.TextBox1.Text = mainWindow.TextBox2.Text = mainWindow.TextBox3.Text
                            = mainWindow.TextBox4.Text = mainWindow.TextBox5.Text = mainWindow.TextBox6.Text
                            = mainWindow.TextBox7.Text = mainWindow.TextBox8.Text = mainWindow.TextBox9.Text
                            = mainWindow.TextBox10.Text = mainWindow.TextBox11.Text = "";
                        mainWindow.DataContext = mainWindow.viewModel;
                        break;
                    case 7:
                        mainWindow.viewModel.TableName = ColumnNames.atrakcje;
                        mainWindow.viewModel.TableContent = context.Atrakcje.ToList();
                        mainWindow.TextBox1.Text = mainWindow.TextBox2.Text = mainWindow.TextBox3.Text
                            = mainWindow.TextBox4.Text = mainWindow.TextBox5.Text = mainWindow.TextBox6.Text
                            = mainWindow.TextBox7.Text = mainWindow.TextBox8.Text = mainWindow.TextBox9.Text
                            = mainWindow.TextBox10.Text = mainWindow.TextBox11.Text = "";
                        mainWindow.DataContext = mainWindow.viewModel;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
