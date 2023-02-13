using DataAccess;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LeitnerBoxNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LeitnerBoxDataAccess leitnerBoxData = new LeitnerBoxDataAccess();
        CardDataAccess cardData = new CardDataAccess();

        ObservableCollection<LeitnerBox> leitnerBoxes = new ObservableCollection<LeitnerBox>();
        List<Card> cards = new List<Card>();
       public int categoryId;
        bool isClickbtnBox1 = false;
        bool isClickbtnBox2 = false;
        bool isClickbtnBox3 = false;
        bool isClickbtnBox4 = false;
        bool isClickbtnBox5 = false;
        public MainWindow()
        {
            InitializeComponent();
            FillData();
            AddCategories();
           
    


            if (leitnerBoxes.Any())
            {
                CategoryStartPlane.Visibility = Visibility.Collapsed;
                CategoryEndPlane.Visibility = Visibility.Visible;
            }
                
            
        }

        public void AddCategories()
        {
            stkCategoryEndPlane.Children.Clear();
            foreach (var item in leitnerBoxes)
            {
                Button btn = new Button()
                {
                    Width = 110,
                    Height = 50,
                    BorderThickness = new Thickness(3),
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    Name = "btn" + item.Id,
                    Content = item.LeitnerBoxName,
                    Background=new  SolidColorBrush(Color.FromRgb(09,66,125)),
                    Foreground=Brushes.White,
                    Margin = new Thickness(5)

                };

              
                Image imgDelete = new Image()
                {
                    Width=50,
                    Height=50,
                    Name = "imgDelete" + item.Id,
                    Source= new BitmapImage(new Uri(@"Resource/Img/trash.png",UriKind.Relative)),
                    Margin=new Thickness(0,5,0,0),

                };
                

                StackPanel stack = new StackPanel()
                {
                    Name = "stk" + item.Id,
                };
                Border brd = new Border()
                {
                    Name = "brd" + item.Id,
                    Margin = new Thickness(20),
                    Width = 300,
                    Height = 150,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(20),
                    Child = stack,

                };

                stack.Children.Add(btn);
                stack.Children.Add(imgDelete);

                stkCategoryEndPlane.Children.Add(brd);

                btn.Click += (e, s) =>
                {
                    lblCategoryName.Content = item.LeitnerBoxName;
                    CategoryPlane.Visibility = Visibility.Visible;
                    categoryId = item.Id;

                    DisplayCards(BoxPosition.Box1.ToString(), categoryId);
                    btnBox1.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
                    btnBox2.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
                    btnBox3.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
                    btnBox4.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
                    btnBox5.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));

                    btnBox2.Foreground = new SolidColorBrush(Colors.White);
                    btnBox3.Foreground = new SolidColorBrush(Colors.White);
                    btnBox4.Foreground = new SolidColorBrush(Colors.White);
                    btnBox5.Foreground = new SolidColorBrush(Colors.White);

                    isClickbtnBox1 = true;
                    isClickbtnBox2 = false;
                    isClickbtnBox3 = false;
                    isClickbtnBox4 = false;
                    isClickbtnBox5 = false;

                    lblCardDisplayTime.Content = "کارت ها بعد از گذشت 1 روز از زمان انتقال به این خانه نمایش داده میشوند";


                };
                btn.MouseMove += (e, s) =>
                {
                    Cursor = Cursors.Hand;
                   btn.Foreground = Brushes.Black;
                };
                btn.MouseLeave += (e, s) =>
                {
                    Cursor = Cursors.Arrow;
                    btn.Foreground = Brushes.White;
                };
                imgDelete.MouseDown += (e, s) =>
                {
                    leitnerBoxData.Delete(item.Id);
                    foreach (var value in cards.Where(u=>u.LeitnerBoxId==item.Id))
                    {
                        cardData.Delete(value.Id);
                    }
                    FillData();
                    brd.Visibility = Visibility.Collapsed;

                    if (!leitnerBoxes.Any())
                    {
                        CategoryEndPlane.Visibility = Visibility.Collapsed;
                        CategoryStartPlane.Visibility = Visibility.Visible;
                      
                    }
                    if(categoryId==item.Id)
                    {
                        HomePlane.Visibility = Visibility.Visible;
                        CategoryPlane.Visibility = Visibility.Collapsed;
                    }
                };
                imgDelete.MouseMove += (e, s) =>
                {
                    Cursor = Cursors.Hand;
                };
                imgDelete.MouseLeave += (e, s) =>
                {
                    Cursor = Cursors.Arrow;
                };
            }
           

        }

      
        public void DisplayCards(string Position,int categoryID)
        {
            CardPlane.Children.Clear();
            Card card = new Card();

            if (Position == BoxPosition.Box1.ToString())
            {
                 card = cards.FirstOrDefault(x => x.Position == Position && x.LeitnerBoxId == categoryID && x.CreationDate.AddDays(1) <= DateTime.Now);
            }
            else if (Position == BoxPosition.Box2.ToString())
            {
                 card = cards.FirstOrDefault(x => x.Position == Position && x.LeitnerBoxId == categoryID && x.CreationDate.AddDays(2) <= DateTime.Now);
            }
            else if (Position == BoxPosition.Box3.ToString())
            {
                 card = cards.FirstOrDefault(x => x.Position == Position && x.LeitnerBoxId == categoryID && x.CreationDate.AddDays(4) <= DateTime.Now);
            }
            else if (Position == BoxPosition.Box4.ToString())
            {
                 card = cards.FirstOrDefault(x => x.Position == Position && x.LeitnerBoxId == categoryID && x.CreationDate.AddDays(8) <= DateTime.Now);
            }
            else if (Position == BoxPosition.Box5.ToString())
            {
                 card = cards.FirstOrDefault(x => x.Position == Position && x.LeitnerBoxId == categoryID && x.CreationDate.AddDays(15) <= DateTime.Now);
            }

            if (card != null)
            {

                //Label lblPosition = new Label()
                //{
                //    Name = "lblPosition",
                //    FontSize = 24,
                //    Content = card.PositionPersion,
                //    HorizontalAlignment = HorizontalAlignment.Center
                //};

                Label lblQuestion = new Label()
                {
                    Name = "lblQuestion" + card.Id,
                    FontSize = 18,
                    Content = card.Question,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Foreground = new SolidColorBrush(Color.FromRgb(252, 196, 0))
                   
                    };

                    Label lblAnswer = new Label()
                    {
                        Name = "lblAnswer" + card.Id,
                        FontSize = 18,
                        Content = card.Answer,
                        Visibility = Visibility.Hidden,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Foreground = new SolidColorBrush(Color.FromRgb(252, 196, 0))
                    };

                    Button btnAnswer = new Button()
                    {
                        Width = 80,
                        Height = 35,
                        Name = "btnAswer" + card.Id,
                        Content = "جواب",
                        Background = new SolidColorBrush(Color.FromRgb(09, 66, 125)),
                        Foreground = Brushes.White,
                        Margin = new Thickness(5)

                    };

                    Button btnCurrect = new Button()
                    {
                        Width = 80,
                        Height = 35,
                        Name = "btnCurrect" + card.Id,
                        Content = "درست",
                        Background = Brushes.Green,
                        Foreground = Brushes.White,
                        Margin = new Thickness(5)

                    };

                    Button btnUnCurrect = new Button()
                    {
                        Width = 80,
                        Height = 35,
                        Name = "btnUnCurrect" + card.Id,
                        Content = "نادرست",
                        Background = Brushes.Red,
                        Foreground = Brushes.White,
                        Margin = new Thickness(5)

                    };

                    DockPanel dock = new DockPanel()
                    {
                        Name = "dk" + card.Id,
                        Margin = new Thickness(10),
                        HorizontalAlignment=HorizontalAlignment.Center
                    };

                    dock.Children.Add(btnUnCurrect);
                    dock.Children.Add(btnCurrect);

           
                    StackPanel stack = new StackPanel()
                    {
                        Name = "stk" + card.Id,
                    };
                
                    stack.Children.Add(lblQuestion);
                    stack.Children.Add(btnAnswer);
                    stack.Children.Add(lblAnswer);
                    stack.Children.Add(dock);
              

                    Border brd = new Border()
                    {
                        Name = "brd" + card.Id,
                        Margin = new Thickness(20),
                        Width = 300,
                        Height = 250,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(2),
                        CornerRadius = new CornerRadius(20),
                        Child = stack
                    };
          
                    btnAnswer.Click += (e, s) =>
                    {
                        lblAnswer.Visibility = Visibility.Visible;
                    };

                btnAnswer.MouseMove += (e, s) =>
                {
                    Cursor = Cursors.Hand;
                };

                btnAnswer.MouseLeave += (e, s) =>
                {
                    Cursor = Cursors.Arrow;
                };

                btnCurrect.Click += (e, s) =>
                    {
                        var c = cards.FirstOrDefault(c => c.Id == card.Id);
                        c.CreationDate=DateTime.Now;

                        switch(c.Position)
                        {
                            case "Box1":
                                c.Position = BoxPosition.Box2.ToString();
                                c.PositionPersion = "خانه دوم";
                                break;
                            case "Box2":
                                c.Position = BoxPosition.Box3.ToString();
                                c.PositionPersion = "خانه سوم";
                                break;
                            case "Box3":
                                c.Position = BoxPosition.Box4.ToString();
                                c.PositionPersion = "خانه چهارم";
                                break;
                            case "Box4":
                                c.Position = BoxPosition.Box5.ToString();
                                c.PositionPersion = "خانه پنجم";
                                break;
                            case "Box5":
                                c.Position = BoxPosition.BoxFinish.ToString();
                                c.PositionPersion = "خانه تمام شده ها";
                                break;
                        }

                        cardData.Update(c);
                        DisplayCards(Position,categoryID);
                        brd.Visibility = Visibility.Collapsed;
                    };

                btnUnCurrect.Click += (e, s) =>
                {
                    var c = cards.FirstOrDefault(c => c.Id == card.Id);
                    c.CreationDate = DateTime.Now;

                    switch (c.Position)
                    {
                        case "Box2":
                            c.Position = BoxPosition.Box1.ToString();
                            c.PositionPersion = "خانه اول";
                            break;
                        case "Box3":
                            c.Position = BoxPosition.Box2.ToString();
                            c.PositionPersion = "خانه دوم";
                            break;
                        case "Box4":
                            c.Position = BoxPosition.Box3.ToString();
                            c.PositionPersion = "خانه سوم";
                            break;
                        case "Box5":
                            c.Position = BoxPosition.Box4.ToString();
                            c.PositionPersion = "خانه چهارم";
                            break;
                    }

                    cardData.Update(c);
                    DisplayCards(Position, categoryID);
                    brd.Visibility = Visibility.Collapsed;
                };

                btnCurrect.MouseMove += (e, s) =>
                {
                    Cursor = Cursors.Hand;
                };
                btnUnCurrect.MouseMove += (e, s) =>
                {
                    Cursor = Cursors.Hand;
                };

                btnCurrect.MouseMove += (e, s) =>
                {
                    Cursor = Cursors.Hand;
                };
                btnUnCurrect.MouseMove += (e, s) =>
                {
                    Cursor = Cursors.Hand;
                };

                /////////////////////////////////////////////
                btnCurrect.MouseLeave += (e, s) =>
                {
                    Cursor = Cursors.Arrow;
                };
                btnUnCurrect.MouseLeave += (e, s) =>
                {
                    Cursor = Cursors.Arrow;
                };

                btnCurrect.MouseLeave += (e, s) =>
                {
                    Cursor = Cursors.Arrow;
                };
                btnUnCurrect.MouseLeave += (e, s) =>
                {
                    Cursor = Cursors.Arrow;
                };




                CardPlane.Children.Add(brd);

                }
                else
            {
      

                Label lblNothing = new Label()
                {
                    Name = "lblNothing",
                    FontSize = 24,
                    Margin = new Thickness(0, 90, 0, 0),
                    Content = "این خانه خالی است",
                    Foreground = Brushes.Yellow,
                    Visibility = Visibility.Visible,
                    HorizontalAlignment = HorizontalAlignment.Center

                };

                Border brdNothing = new Border()
                {
                    Name = "brdNothing",
                    Margin = new Thickness(20),
                    Width = 300,
                    Height = 250,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(20),
                    Child = lblNothing
                };

                CardPlane.Children.Add(brdNothing);
            }
            
    
        }
        private void btCreateCategory_Click(object sender, RoutedEventArgs e)
        {
            CreateCategory createCategory = new CreateCategory(leitnerBoxData,this);
            createCategory.ShowDialog();
        }
        
        public void FillData()
        {
            leitnerBoxes = leitnerBoxData.Read();
            cards = cardData.Read();
        }

     

        private void AddCategory_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateCategory createCategory = new CreateCategory(leitnerBoxData,this);
            createCategory.ShowDialog();
        }

        private void AddCategory_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void AddCategory_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            CreateCard createCard = new CreateCard(this);
            createCard.ShowDialog();
        }

        private void btnBox1_Click(object sender, RoutedEventArgs e)
        {
            DisplayCards(BoxPosition.Box1.ToString(), categoryId);
            btnBox1.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox2.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox3.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox4.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox5.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));

            btnBox2.Foreground = new SolidColorBrush(Colors.White);
            btnBox3.Foreground = new SolidColorBrush(Colors.White);
            btnBox4.Foreground = new SolidColorBrush(Colors.White);
            btnBox5.Foreground = new SolidColorBrush(Colors.White);

            isClickbtnBox1 = true;
            isClickbtnBox2 = false;
            isClickbtnBox3 = false;
            isClickbtnBox4 = false;
            isClickbtnBox5 = false;

            lblCardDisplayTime.Content = "کارت ها بعد از گذشت 1 روز از زمان انتقال به این خانه نمایش داده میشوند";
        }

        private void btnBox2_Click(object sender, RoutedEventArgs e)
        {
            DisplayCards(BoxPosition.Box2.ToString(), categoryId);
            btnBox2.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox1.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox3.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox4.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox5.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));

            btnBox1.Foreground = new SolidColorBrush(Colors.White);
            btnBox3.Foreground = new SolidColorBrush(Colors.White);
            btnBox4.Foreground = new SolidColorBrush(Colors.White);
            btnBox5.Foreground = new SolidColorBrush(Colors.White);

            isClickbtnBox2 = true;
            isClickbtnBox1 = false;
            isClickbtnBox3 = false;
            isClickbtnBox4 = false;
            isClickbtnBox5 = false;

            lblCardDisplayTime.Content = "کارت ها بعد از گذشت 2 روز از زمان انتقال به این خانه نمایش داده میشوند";
        }

        private void btnBox3_Click(object sender, RoutedEventArgs e)
        {
            DisplayCards(BoxPosition.Box3.ToString(), categoryId);
            btnBox3.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox2.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox1.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox4.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox5.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));

            btnBox1.Foreground = new SolidColorBrush(Colors.White);
            btnBox2.Foreground = new SolidColorBrush(Colors.White);
            btnBox4.Foreground = new SolidColorBrush(Colors.White);
            btnBox5.Foreground = new SolidColorBrush(Colors.White);

            isClickbtnBox3 = true;
            isClickbtnBox1 = false;
            isClickbtnBox2 = false;
            isClickbtnBox4 = false;
            isClickbtnBox5 = false;

            lblCardDisplayTime.Content = "کارت ها بعد از گذشت 4 روز از زمان انتقال به این خانه نمایش داده میشوند";
        }

        private void btnBox4_Click(object sender, RoutedEventArgs e)
        {
            DisplayCards(BoxPosition.Box4.ToString(), categoryId);
            btnBox4.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox2.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox3.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox1.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox5.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));

            btnBox1.Foreground = new SolidColorBrush(Colors.White);
            btnBox2.Foreground = new SolidColorBrush(Colors.White);
            btnBox3.Foreground = new SolidColorBrush(Colors.White);
            btnBox5.Foreground = new SolidColorBrush(Colors.White);

            isClickbtnBox4 = true;
            isClickbtnBox1 = false;
            isClickbtnBox2 = false;
            isClickbtnBox3 = false;
            isClickbtnBox5 = false;

            lblCardDisplayTime.Content = "کارت ها بعد از گذشت 8 روز از زمان انتقال به این خانه نمایش داده میشوند";
        }

        private void btnBox5_Click(object sender, RoutedEventArgs e)
        {
            DisplayCards(BoxPosition.Box5.ToString(), categoryId);
            btnBox5.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox2.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox3.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox4.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
            btnBox1.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));

            btnBox1.Foreground = new SolidColorBrush(Colors.White);
            btnBox2.Foreground = new SolidColorBrush(Colors.White);
            btnBox3.Foreground = new SolidColorBrush(Colors.White);
            btnBox4.Foreground = new SolidColorBrush(Colors.White);

            isClickbtnBox5 = true;
            isClickbtnBox1 = false;
            isClickbtnBox2 = false;
            isClickbtnBox3 = false;
            isClickbtnBox4 = false;

            lblCardDisplayTime.Content = "کارت ها بعد از گذشت 15 روز از زمان انتقال به این خانه نمایش داده میشوند";
        }

        private void btnBox1_MouseMove(object sender, MouseEventArgs e)
        {
            btnBox1.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox1.Foreground = new SolidColorBrush(Colors.Black);
            

        }
        private void btnBox2_MouseMove(object sender, MouseEventArgs e)
        {
           btnBox2.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox2.Foreground = new SolidColorBrush(Colors.Black);

        }
        private void btnBox3_MouseMove(object sender, MouseEventArgs e)
        {
            btnBox3.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox3.Foreground = new SolidColorBrush(Colors.Black);


        }
        private void btnBox4_MouseMove(object sender, MouseEventArgs e)
        {
            btnBox4.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox4.Foreground = new SolidColorBrush(Colors.Black);


        }
        private void btnBox5_MouseMove(object sender, MouseEventArgs e)
        {
            btnBox5.Background = new SolidColorBrush(Color.FromRgb(252, 196, 0));
            btnBox5.Foreground = new SolidColorBrush(Colors.Black);


        }


        private void btnBox1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isClickbtnBox1 == false)
            {
                btnBox1.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
                btnBox1.Foreground = new SolidColorBrush(Colors.White);
            }
        }
        private void btnBox2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isClickbtnBox2 == false)
            {
                btnBox2.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
                btnBox2.Foreground = new SolidColorBrush(Colors.White);

            }
        }
            private void btnBox3_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isClickbtnBox3 == false)
            {
                btnBox3.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
                btnBox3.Foreground = new SolidColorBrush(Colors.White);
            }
        }
        private void btnBox4_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isClickbtnBox4 == false)
            {
                btnBox4.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
                btnBox4.Foreground = new SolidColorBrush(Colors.White);
            }
        }
        private void btnBox5_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isClickbtnBox5 == false)
            {
                btnBox5.Background = new SolidColorBrush(Color.FromRgb(09, 66, 125));
                btnBox5.Foreground = new SolidColorBrush(Colors.White);
            }

        }

        private void btnAddCard_MouseMove(object sender, MouseEventArgs e)
        {
            btnAddCard.Cursor = Cursors.Hand;
        }

        private void btnAddCard_MouseLeave(object sender, MouseEventArgs e)
        {
            btnAddCard.Cursor = Cursors.Arrow;
        }
    }
}
