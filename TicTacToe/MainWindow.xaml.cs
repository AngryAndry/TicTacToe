
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// результаты значений в активной игре
        /// </summary>
        private MarkType[] mResults;
        /// <summary>
        /// True ход первого игрока (X)
        /// </summary>
        private bool mPlayer1Turn;
        /// <summary>
        /// True игра завершена 
        /// </summary>
        private bool mGameEnded;

        /// <summary>
        /// Счетчики игроков 
        /// </summary>
        private int Player1Counter;
        private int Player2Counter;
        #endregion

        #region Contructor
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        #endregion
        /// <summary>
        /// Начало новой игры и очистка всех значений
        /// </summary>
        private void NewGame()
        {
            ///Создаем новый массив с Free 
            mResults = new MarkType[9];
            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }
            //Уточняем что ходит первый играк
            mPlayer1Turn = true;

            //делаем кнопки пустые 
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                //меняем на значения по умолчанию
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });
            mGameEnded = false;
                }


        /// <summary>
        /// Обработка нажатия на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //старт новой игры если она была закончина
            if (mGameEnded)
            {
                NewGame();
                return;
            }
            //преобразует sender в button
            var button = (Button)sender;
            //определяем положение кнопки в массиве 
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);
            //ничего не делаем если ячейка занята
            if (mResults[index]!=MarkType.Free)
            {
                return;
            }
            //определяем значение в зависимости от игрока 
            
            mResults[index] = mPlayer1Turn? MarkType.Cross: MarkType.Nought;
            //устанавливаем значение
            button.Content = mPlayer1Turn ? "X" : "O";
            //меняем цвет символа
            if (!mPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }

            //меняем игроков
            mPlayer1Turn ^= true;
            //проверка на победителя
            CheckForWinner();
        }
        /// <summary>
        /// Счетчик игроков
        /// </summary>
        private void PlayerCounter(MarkType temp)
            
        {            if(temp==MarkType.Cross)
                { Player1Counter++;
                    Player1.Content = $"Player X: {Player1Counter}";
                       }
                else
                {
                    Player2Counter++;
                    Player2.Content = $"Player O: {Player2Counter}";
                }
}
/// <summary>
/// проверяет победителя по линии из трех 
/// </summary>
private void CheckForWinner()
        {
            //Проверка горизонта
            //Строка 0 
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                //конец игры
                mGameEnded = true;
                //Окрашиваем выйграшные в зеленый
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
                //Увеличиваем счетчик игрока
                PlayerCounter(mResults[0]);
                return;
            } 
            //Строка 1 
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                //конец игры
                mGameEnded = true;
                //Окрашиваем выйграшные в зеленый
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
                //Увеличиваем счетчик игрока
                PlayerCounter(mResults[3]);
                return;
            }          
            //Строка 2
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {

                //конец игры
                mGameEnded = true;
                //Окрашиваем выйграшные в зеленый
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
                //Увеличиваем счетчик игрока
                PlayerCounter(mResults[6]);
                return;
            }            
            //Проверка вертикали
            //Столбец 0 
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                //конец игры
                mGameEnded = true;
                //Окрашиваем выйграшные в зеленый
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
                //Увеличиваем счетчик игрока
                PlayerCounter(mResults[0]);
                return;
            }
            //Столбец 1
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                //конец игры
                mGameEnded = true;
                //Окрашиваем выйграшные в зеленый
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
                //Увеличиваем счетчик игрока
                PlayerCounter(mResults[1]);
                return;
            }
            //Столбец 2 
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                //конец игры
                mGameEnded = true;
                //Окрашиваем выйграшные в зеленый
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
                //Увеличиваем счетчик игрока
                PlayerCounter(mResults[2]);
                return;
            }  
            //Проверка диагоналей
            //Диагональ 1
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                //конец игры
                mGameEnded = true;
                //Окрашиваем выйграшные в зеленый
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
                //Увеличиваем счетчик игрока
                PlayerCounter(mResults[0]);
                return;
            }          
            //Диагональ 2
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                //конец игры
                mGameEnded = true;
                //Окрашиваем выйграшные в зеленый
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
                //Увеличиваем счетчик игрока
                PlayerCounter(mResults[2]);
                return;
            }          
           
            //проверка на отсутствие победителя и полную доску
            if (!mResults.Any(result=>result==MarkType.Free))
            {
                mGameEnded = true;
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    //перекрашиваем все в оранджевый 
                    button.Background = Brushes.Orange;
                });
            }
        }
    }
}
