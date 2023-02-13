using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LeitnerBoxNew
{
    /// <summary>
    /// Interaction logic for CreateCategory.xaml
    /// </summary>
    public partial class CreateCategory : Window
    {
        
        LeitnerBoxDataAccess leitnerBoxDataAccess = new LeitnerBoxDataAccess();
        MainWindow mainWindow = new MainWindow();
        public CreateCategory(LeitnerBoxDataAccess leitnerBoxData,MainWindow main)
        {
            InitializeComponent();
            leitnerBoxDataAccess=leitnerBoxData;
            mainWindow = main;
        }

        private void btnBoxSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbname.Text))
            {
                if (!leitnerBoxDataAccess.Read().Any(x => x.LeitnerBoxName == tbname.Text))
                {
                    LeitnerBox leitnerBox = new LeitnerBox()
                    {
                        LeitnerBoxName = tbname.Text.Trim()
                    };
                    leitnerBoxDataAccess.Create(leitnerBox);

                    mainWindow.FillData();
                    mainWindow.AddCategories();
                   
                    mainWindow.CategoryStartPlane.Visibility = Visibility.Collapsed;
                    mainWindow.CategoryEndPlane.Visibility = Visibility.Visible;

                    
                  
                    this.Close();

              
                      
                    
                }
                else
                {
                    lblErrorMessage.Content = "!نام جعبه تکراری است";
                }
            }
            else
            {
                lblErrorMessage.Content = "!نام جعبه را وارد کنید";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbname_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblErrorMessage.Content = "";
        }

        private void btnCancel_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void btnCancel_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;

        }

        private void btnBoxSave_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;

        }

        private void btnBoxSave_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;

        }
    }
}
