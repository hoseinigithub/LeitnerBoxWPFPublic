using DataAccess;
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
using System.Xml.Linq;

namespace LeitnerBoxNew
{
    /// <summary>
    /// Interaction logic for CreateCard.xaml
    /// </summary>
    public partial class CreateCard : Window
    {
        CardDataAccess dataAccess = new CardDataAccess();
      
        MainWindow mainWindow = new MainWindow();
        public CreateCard(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;   
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBoxSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbQuestion.Text))
            {
                if (!string.IsNullOrEmpty(tbAnswer.Text))
                {
                    if (!dataAccess.Read().Any(x => x.Question == tbQuestion.Text))
                    {
                        Card card = new Card()
                        {
                            Question = tbQuestion.Text.Trim(),
                            Answer = tbAnswer.Text.Trim(),
                            Position = BoxPosition.Box1.ToString(),
                            PositionPersion = "خانه اول",
                            LeitnerBoxId = mainWindow.categoryId,
                            CreationDate=DateTime.Now,
                            EarlyDate=DateTime.Now
                        };

                        dataAccess.Create(card);

                        mainWindow.FillData();
                       

                        MessageBox.Show("با موفقیت ثبت شد");

                        this.Close();

                    }
                    else
                    {
                        lblErrorMessage.Content = "!سوال تکراری است";
                    }

                }

                else
                {
                    lblErrorMessage.Content = "!جواب را وارد کنید";
                }
                    
               
            }
            else
            {
                lblErrorMessage.Content = "!سوال را وارد کنید";
            }
         
        }

        private void tbQuestion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {

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
