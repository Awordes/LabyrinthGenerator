using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LabyrinthGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textboxCellSize.Text = "20";
            textboxHeight.Text = "50";
            textboxWidth.Text = "50";
        }

        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            int height = Convert.ToInt32(textboxHeight.Text);
            int width = Convert.ToInt32(textboxWidth.Text);
            int cellSize = Convert.ToInt32(textboxCellSize.Text);
            
            LabGen labGen = new LabGen(width, height);
            labGen.Generate();
            Cell[][] labyrinth = labGen.getLabyrinth();

            gridLabyrinth.Children.Clear();
            drawLine(0, 0, labyrinth.Length * cellSize, 0);
            drawLine(0, 0, 0, labyrinth[0].Length * cellSize);

            //отрисовка лабиринта
            for (int i = 0; i < labyrinth.Length; i++)
            {
                for (int j = 0; j < labyrinth[i].Length; j++)
                {
                    
                    //if (labyrinth[i][j].leftWall)
                    //    drawLine(i * cellSize, j * cellSize, i * cellSize, (j + 1) * cellSize);//лево

                    //if (labyrinth[i][j].upWall)
                    //    drawLine(i * cellSize, j * cellSize, (i + 1) * cellSize, j * cellSize);//верх
                        
                    if (labyrinth[i][j].rightWall)
                        drawLine((i + 1) * cellSize, j * cellSize, (i + 1) * cellSize, (j + 1) * cellSize);//право

                    if (labyrinth[i][j].downWall)
                        drawLine(i * cellSize, (j + 1) * cellSize, (i + 1) * cellSize, (j + 1) * cellSize);//низ
                }
            }
        }

        private void drawLine(int x1, int y1, int x2, int y2)
        {
            Line line = new Line();
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 1;
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            gridLabyrinth.Children.Add(line);
        }

        private void buttonAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("by Awordes" + Environment.NewLine +
                            "Andrew Tolstov" + Environment.NewLine +
                            "awordes76@gmail.com" + Environment.NewLine +
                            "https://github.com/Awordes/LabyrinthGenerator");
        }

        private void textboxWidth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }        
    }
}
