using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Food_Control
{
    public partial class FormFoodControl : Form
    {
        public struct Profil
        {
            public string Name;
            public string Years;
            public string Ves;
            public string Rost;
            public int Pol;
            public int Target;
            public int Activ;
        }

        public FormFoodControl()
        {
            InitializeComponent();
            timerTime.Start();
            panelHead.Visible = true;
            panelProfil.Visible = false;
            panelReference.Visible = false;
            panelBook.Visible = false;
            panelStatistics.Visible = false;
        }


        private void buttonMenuExit_Click(object sender, EventArgs e)
        {
            Hide();
            formAuthorization Authorization = new formAuthorization();
            Authorization.ShowDialog();
            Close();
        }

        private void buttonMenuHead_Click(object sender, EventArgs e)
        {
            panelRightButton.Height = buttonMenuHead.Height;
            panelRightButton.Top = buttonMenuProfil.Top-3;
            panelHead.Visible = true;
            panelProfil.Visible = false;
            panelReference.Visible = false;
            panelBook.Visible = false;
            panelStatistics.Visible = false;
        }

        private void buttonMenuProfil_Click(object sender, EventArgs e)
        {
            panelRightButton.Height = buttonMenuProfil.Height;
            panelRightButton.Top = buttonMenuBook.Top-3;
            panelHead.Visible = false;
            panelProfil.Visible = true;
            panelReference.Visible = false;
            panelBook.Visible = false;
            panelStatistics.Visible = false;

            //загрузка личных данных пользователя
            string Name = labelProfil_Name.Text;
            string temp;
            FileStream fileUserData = new FileStream("USER/USER_" + Name + ".txt", FileMode.Open);
                StreamReader readerUserData = new StreamReader(fileUserData);
                labelProfil_Name.Text = readerUserData.ReadLine();
                textBoxProfil_Years.Text = readerUserData.ReadLine();
                textBoxProfil_Ves.Text = readerUserData.ReadLine();
                textBoxProfil_Rost.Text = readerUserData.ReadLine();
                //Pol
                temp = readerUserData.ReadLine();
                if (temp == "2")
                {
                    radioButtonPol_2.Checked = true;
                }
                else
                    radioButtonPol_1.Checked = true;
                //Target
                temp = readerUserData.ReadLine();
                if (temp == "3")
                {
                    radioButton3.Checked = true;
                }
                else
                {
                    if (temp == "2")
                    {
                        radioButton2.Checked = true;
                    }
                    else
                        radioButton1.Checked = true;
                }
                //Activ
                temp = readerUserData.ReadLine();
                if (temp == "5")
                {
                    radioButton_Activ5.Checked = true;
                }
                else
                {
                    if (temp == "4")
                    {
                        radioButton_Activ4.Checked = true;
                    }
                    else
                    {
                        if (temp == "3")
                        {
                            radioButton_Activ3.Checked = true;
                        }
                        else
                        {
                            if (temp == "2")
                            {
                                radioButton_Activ2.Checked = true;
                            }
                            else
                                radioButton_Activ1.Checked = true;
                        }
                    }
                }
                readerUserData.Close();
            //рассчет идеального веса
            if (textBoxProfil_Rost.Text != "0")
                NormMassa();
            //рассчет суточной нормы калорий, белков, жиров, углеводов
            NormaCalorii();
            NormaBelki();
            NormaZhiry();
            NormaUglevody();
        }
        
        private void buttonMenuBook_Click(object sender, EventArgs e)
        {
            panelRightButton.Height = buttonMenuBook.Height;
            panelRightButton.Top = buttonMenuStatistics.Top - 3;
            panelHead.Visible = false;
            panelProfil.Visible = false;
            panelReference.Visible = false;
            panelBook.Visible = true;
            panelStatistics.Visible = false;
        }

        public bool checkDiagramma = true;

        public int x = 0;

        private void buttonMenuStatistic_Click(object sender, EventArgs e)
        {
            panelRightButton.Height = buttonMenuStatistics.Height;
            panelRightButton.Top = buttonMenuReference.Top-3;
            panelHead.Visible = false;
            panelProfil.Visible = false;
            panelReference.Visible = false;
            panelBook.Visible = false;
            panelStatistics.Visible = true;
            //загрузка употребленных продуктов
            string Name = labelProfil_Name.Text;
            listBoxStatistics.Items.Clear();
            //проверка даты сохранения
            string date = File.ReadLines("STATISTICS/STATISTICS_" + Name + ".txt").Skip(0).First();
            DateTime dt = DateTime.Now;
            string CheckDate = dt.ToString("dd:MM:yy");
            if (CheckDate == date)
            {
                FileStream fileStatictics = new FileStream("STATISTICS/STATISTICS_" + Name + ".txt", FileMode.Open);
                StreamReader readerStatistics = new StreamReader(fileStatictics);
                //listBoxStatistics.Text = readerStatistics.ReadToEnd();
                while (!readerStatistics.EndOfStream)
                    listBoxStatistics.Items.Add(readerStatistics.ReadLine());
                readerStatistics.Close();
            }
            else
            {
                listBoxStatistics.Items.Add("Список продуктов пуст...");
                listBoxStatistics.Items.Add("Перейдите на вкладку - Дневник");
                listBoxStatistics.Items.Add("и добавьте продукт");
            }
            if (labelNorma_Calorii.Text != "0")
            {
                //загрузка и рассчет значений калорий
                labelStatistics_Calorii3.Text = labelNorma_Calorii.Text;  //калорий необходимо
                string calorii1 = "0";
                //проверка даты сохранения
                string date2 = File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(0).First();
                if (CheckDate == date2)
                {
                    calorii1 = File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(1).First();
                }
                labelStatistics_Calorii1.Text = calorii1;                  //калорий употреблено
                string calorii3 = labelStatistics_Calorii3.Text;
                labelStatistics_Calorii2.Text = Convert.ToString(Convert.ToDouble(calorii3) - Convert.ToDouble(calorii1)); //калорий осталось
            }
            //отображение количество выпитой воды
            string dateWater = File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(0).First();
            double water = Convert.ToDouble(File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(2).First());
            panelWater.Height = panelWater2.Height;
            if (CheckDate == dateWater) //проверка даты
            {
                panelWater.Top = panelWater2.Height - Convert.ToInt32((water * 100));
            }
            else
            {
                panelWater.Top = panelWater2.Height;
            }

            //рисование диаграммы
            if (checkDiagramma)
            {
                StreamReader readerDiagramma = new StreamReader("DIAGRAMMA/DIAGRAMMA_" + Name + ".txt");
                string s = readerDiagramma.ReadLine();  //вытянул строку с датой!
                while (!readerDiagramma.EndOfStream)
                {
                    double y = Convert.ToDouble(readerDiagramma.ReadLine());
                    chartDiagramma.Series[0].Points.AddXY(x, y);
                    x++;
                }
                readerDiagramma.Close();
                checkDiagramma = false;
            }
        }

        private void buttonMenuReference_Click(object sender, EventArgs e)
        {
            panelRightButton.Top = buttonMenuExit.Top-3;
            panelRightButton.Height = buttonMenuReference.Height;
            panelHead.Visible = false;
            panelProfil.Visible = false;
            panelReference.Visible = true;
            panelBook.Visible = false;
            panelStatistics.Visible = false;
        }

        private void pictureBoxMinimum_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("Время: "+"HH:mm:ss");
            labelDate.Text = dt.ToString("Дата: " + "dd:MM:yy");
        }

        //СОХРАНЕНИЕ ИЗМЕНЕНИЙ
        private void buttonProfil_SaveUsersDate_Click(object sender, EventArgs e)
        {
            //личные данные пользователя
            Profil UserData = new Profil();
            UserData.Name = labelProfil_Name.Text;
            UserData.Years = textBoxProfil_Years.Text;
            UserData.Ves = textBoxProfil_Ves.Text;
            UserData.Rost = textBoxProfil_Rost.Text;
            //Pol
            if (radioButtonPol_2.Checked)
            {
                UserData.Pol = 2;
            }
            else
                UserData.Pol = 1;
            //Targer
            if (radioButton3.Checked)
            {
                UserData.Target = 3;
            }
            else
            {
                if (radioButton2.Checked)
                {
                    UserData.Target = 2;
                }
                else
                    UserData.Target = 1;
            }
            //Activ
            if (radioButton_Activ5.Checked)
            {
                UserData.Activ = 5;
            }
            else
            {
                if (radioButton_Activ4.Checked)
                {
                    UserData.Activ = 4;
                }
                else
                {
                    if (radioButton_Activ3.Checked)
                    {
                        UserData.Activ = 3;
                    }
                    else
                    {
                        if (radioButton_Activ2.Checked)
                        {
                            UserData.Activ = 2;
                        }
                        else
                            UserData.Activ = 1;
                    }
                }
            }
            string Name = labelProfil_Name.Text;
            System.IO.StreamWriter writerUserData = new System.IO.StreamWriter("USER_"+Name+".txt", false);
            writerUserData.WriteLine(UserData.Name);
            writerUserData.WriteLine(UserData.Years);
            writerUserData.WriteLine(UserData.Ves);
            writerUserData.WriteLine(UserData.Rost);
            writerUserData.WriteLine(UserData.Pol);
            writerUserData.WriteLine(UserData.Target);
            writerUserData.WriteLine(UserData.Activ);
            writerUserData.Close();

            //рассчет идеального веса
            NormMassa();
            NormaCalorii();         //норма калорий
            NormaBelki();           //норма белков
            NormaZhiry();           //норма жиров
            NormaUglevody();        //норма углеводов
        }

        public void NormMassa()   //рассчет идеального веса
        {
            double massa1 = 0, massa2 = 0;
            int rost = Convert.ToInt32(textBoxProfil_Rost.Text);
            int years = Convert.ToInt32(textBoxProfil_Years.Text);
            //первая формула
            if (years < 40)
            {
                if (rost > 175)
                    massa1 = rost - 110;
                else
                {
                    if ((rost <= 175) && (rost >= 166))
                        massa1 = rost - 105;
                    else
                        massa1 = rost - 100;
                }
            }
            else
            {
                if (rost > 175)
                    massa1 = rost - 100;
                else
                {
                    if ((rost <= 175) && (rost >= 166))
                        massa1 = rost - 100;
                    else
                        massa1 = rost - 100;
                }
            }
            //вторая формула
            if (radioButtonPol_1.Checked) //для мужчин
                massa2 = (rost - 100) * 0.9;
            if (radioButtonPol_2.Checked) //для женщин
                massa2 = (rost - 100) * 0.85;

            labelProfil_Massa.Text = Convert.ToString((massa1+massa2)/2);
        }

        public void NormaCalorii()   //рассчет суточной нормы калорий
        {
            //рассчет нормы
            if ((textBoxProfil_Rost.Text != "0") && (textBoxProfil_Ves.Text != "0") && (textBoxProfil_Years.Text != "0"))
            {
                double calorii = 1;
                double BMR = 1;   //Базовый Уровень Метаболизма
                int ves = Convert.ToInt32(textBoxProfil_Ves.Text);
                int rost = Convert.ToInt32(textBoxProfil_Rost.Text);
                int years = Convert.ToInt32(textBoxProfil_Years.Text);

                if (radioButtonPol_1.Checked) //для мужчин
                    BMR = 88.36 + (13.4 * ves) + (4.8 * rost) - (5.7 * years);
                if (radioButtonPol_2.Checked) //для женщин
                    BMR = 447.6 + (9.2 * ves) + (3.1 * rost) - (4.3 * years);
                if (radioButton_Activ1.Checked)
                    calorii = BMR * 1.2;
                if (radioButton_Activ2.Checked)
                    calorii = BMR * 1.28;
                if (radioButton_Activ3.Checked)
                    calorii = BMR * 1.35;
                if (radioButton_Activ4.Checked)
                    calorii = BMR * 1.42;
                if (radioButton_Activ5.Checked)
                    calorii = BMR * 1.5;

                //проверка цели
                double ves1 = Convert.ToDouble(textBoxProfil_Ves.Text);
                double massa1 = Convert.ToDouble(labelProfil_Massa.Text);
                //для похудения
                if (radioButton2.Checked)
                {
                    if (ves1 > massa1)
                    {
                        double temp = calorii / 10;
                        calorii = calorii - temp;
                        labelNorma_Calorii.Text = Convert.ToString(Convert.ToInt32(calorii));
                    }
                    else
                    {
                        radioButton2.Checked = false;
                        radioButton1.Checked = true;   //переключение на "поддержка веса"
                    }
                }
                //для набора веса
                if (radioButton3.Checked)
                {
                    if (ves1 < massa1)
                    {
                        double temp = calorii / 10;
                        calorii = calorii + temp;
                        labelNorma_Calorii.Text = Convert.ToString(Convert.ToInt32(calorii));
                    }
                    else
                    {
                        radioButton3.Checked = false;
                        radioButton1.Checked = true;   //переключение на "поддержка веса"
                    }
                }
                //поддержка веса
                if (radioButton1.Checked)
                {
                    labelNorma_Calorii.Text = Convert.ToString(Convert.ToInt32(calorii));
                }
            }
            else
                labelNorma_Calorii.Text = "0000";
        }

        public void NormaBelki()   //рассчет суточной нормы белков
        {
            if (textBoxProfil_Ves.Text != "0")
            {
                double belki = 1;
                int ves = Convert.ToInt32(textBoxProfil_Ves.Text);
                if (radioButton_Activ1.Checked)
                    belki = ves * 1.2;
                if (radioButton_Activ2.Checked)
                    belki = ves * 1.4;
                if (radioButton_Activ3.Checked)
                    belki = ves * 1.6;
                if (radioButton_Activ4.Checked)
                    belki = ves * 1.8;
                if (radioButton_Activ5.Checked)
                    belki = ves * 2;
                labelNorma_Belki.Text = Convert.ToString(Convert.ToInt32(belki));

                //проверка цели
                double ves2 = Convert.ToDouble(textBoxProfil_Ves.Text);
                double massa2 = Convert.ToDouble(labelProfil_Massa.Text);
                //для похудения
                if (radioButton2.Checked)
                {
                    if (ves2 > massa2)
                    {
                        double temp = belki / 10;
                        belki = belki - temp;
                        labelNorma_Belki.Text = Convert.ToString(Convert.ToInt32(belki));
                    }
                    else
                    {
                        radioButton2.Checked = false;
                        radioButton1.Checked = true;   //переключение на "поддержка веса"
                    }
                }
                //для набора веса
                if (radioButton3.Checked)
                {
                    if (ves2 < massa2)
                    {
                        double temp = belki / 10;
                        belki = belki + temp;
                        labelNorma_Belki.Text = Convert.ToString(Convert.ToInt32(belki));
                    }
                    else
                    {
                        radioButton3.Checked = false;
                        radioButton1.Checked = true;   //переключение на "поддержка веса"
                    }
                }
                //поддержка веса
                if (radioButton1.Checked)
                {
                    labelNorma_Belki.Text = Convert.ToString(Convert.ToInt32(belki));
                }
            }
            else
                labelNorma_Belki.Text = "000";
        }

        public void NormaZhiry()   //рассчет суточной нормы жиров
        {
            double zhiry = 1;
            double belki = Convert.ToDouble(labelNorma_Belki.Text);
            if (labelNorma_Belki.Text != "000")
            {
                zhiry = belki * 22.5 / 30;  //белки-30%, жиры-22.5%
                labelNorma_Zhiry.Text = Convert.ToString(Convert.ToInt32(zhiry));
            }
            else
                labelNorma_Zhiry.Text = "000";
        }

        public void NormaUglevody()   //рассчет суточной нормы углеводов
        {
            double uglevody = 1;
            double calorii = Convert.ToDouble(labelNorma_Calorii.Text);
            if (labelNorma_Calorii.Text != "0000")
            {
                uglevody = calorii / 6; 
                labelNorma_Uglevody.Text = Convert.ToString(Convert.ToInt32(uglevody));
            }
            else
                labelNorma_Uglevody.Text = "000";
        }

        //добавление воды
        private void buttonBook_AddWater_Click(object sender, EventArgs e)
        {
            double V = Convert.ToDouble(textBoxBook_Water.Text);
            string Name = labelProfil_Name.Text;
            double water = Convert.ToDouble(File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(2).First()); //3-1 т.к. нумерация с 0, а строка в файле 3
            string calorii = File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(1).First();
            string date = File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(0).First();
            bool check = false;

            //проверка на "сегодняшний" файл
            DateTime dt = DateTime.Now;
            string CheckDate = dt.ToString("dd:MM:yy");
            if (CheckDate != date)  //если не "сегодняшний", то обновляем данные
            {
                date = CheckDate;
                calorii = "0";
                water = 0;
            }
            //если измеряется в кружках => в штуках
            if (radioButtonBook_Water1.Checked)
            {
                if ((V >= 1) && (V < 16)) //ограничение от 0.25л до 4л
                {
                    water = water + (V * 0.25);
                    check = true;
                }
                else
                {
                    DialogResult res = MessageBox.Show("Введено неправильное значение (слишком большое/слишком маленькое)!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxBook_Water.Text = "";
                    V = 0;
                }
            }
            //если измеряется в миллилитрах
            if (radioButtonBook_Water2.Checked)
            {
                if ((V >= 0) && (V < 4000)) //ограничение от 0л до 4л
                {
                    water = water + (V * 0.001);
                    check = true;
                }
                else
                {
                    DialogResult res = MessageBox.Show("Введено неправильное значение (слишком большое/слишком маленькое)!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxBook_Water.Text = "";
                    V = 0;
                }
            }
            if (check)
            {
                System.IO.StreamWriter writerCalorii = new System.IO.StreamWriter("CALORII/CALORII_" + Name + ".txt", false);
                writerCalorii.WriteLine(date);
                writerCalorii.WriteLine(calorii);
                writerCalorii.WriteLine(Convert.ToString(water));
                writerCalorii.Close();
                DialogResult res = MessageBox.Show("Значение добавлено!", "ГОТОВО", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxBook_Water.Text = "";
            }
        }


        public double ProduktCaloriiAdd = 0;    //калорийность продукта, которую нужно добавить к общему числу (следующ. процедура)
        //добавление продукта, рассчет калорийности
        private void buttonBook_Add_Click(object sender, EventArgs e)
        {
            string Name = labelProfil_Name.Text;
            double water = Convert.ToDouble(File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(2).First());
            double calorii = Convert.ToDouble(File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(1).First());
            string date = File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(0).First();
            double ProduktNumber = Convert.ToDouble(textBox_AddNum.Text);  //количество в граммах
            string ProduktName = textBoxBook_AddName.Text;                 //название продукта
           // double ProduktCaloriiAdd = 0;                                  //калорийность продукта, которую нужно добавить к общему числу
            bool checkProdukt = false;  
          
            //проверка на "сегодняшний" файл
            DateTime dt = DateTime.Now;
            string CheckDate = dt.ToString("dd:MM:yy");
            if (CheckDate != date)  //если не "сегодняшний", то обновляем данные
            {
                //сначала запишем в файл для диаграммы, т.к. эти калории "вчерашние"
                System.IO.StreamWriter writer = new System.IO.StreamWriter("DIAGRAMMA/DIAGRAMMA_" + Name + ".txt", true);
                    writer.WriteLine(calorii);
                    writer.Close();
                    x++;
                    chartDiagramma.Series[0].Points.AddXY(x, calorii);
                   // checkDiagramma = true;
                //обновление данных
                date = CheckDate;
                calorii = 0;
                water = 0;
            }     
     
            //поиск продукта
            string str = "";
            string strName = "";
            double strNumber = 0;
            int NumCalorii = 0;
            using (StreamReader ReaderProdukt = new StreamReader("SYSTEM/PRODUKT.txt", System.Text.Encoding.Default))
            {
                while (!ReaderProdukt.EndOfStream)
                {
                    strName = ReaderProdukt.ReadLine();
                    //разделение строки на слова
                    //string[] words = str.Split(' ');
                    //strName = words[0];                      //первое прочитанное слово - название продукта
                    //strNumber = Convert.ToDouble(words[1]);  //второе прочитанное слово - калорийность продукта
                    if (strName == ProduktName)
                    {
                        checkProdukt = true;
                        break;
                    }
                    else
                        NumCalorii++;
                }
            }
            if (checkProdukt)   //если нашел продукт
            {
                strNumber = Convert.ToDouble(File.ReadLines("SYSTEM/PRODUKT_CALORII.txt").Skip(NumCalorii).First());
                ProduktCaloriiAdd = strNumber * ProduktNumber / 100;  //т.к. в файле калорийность рассчитанная на 100 грамм
                calorii = calorii + ProduktCaloriiAdd;
                textBoxBook_Calorii.Text = Convert.ToString(ProduktCaloriiAdd);
                System.IO.StreamWriter writerCalorii2 = new System.IO.StreamWriter("CALORII/CALORII_" + Name + ".txt", false);
                writerCalorii2.WriteLine(date);
                writerCalorii2.WriteLine(Convert.ToString(calorii));
                writerCalorii2.WriteLine(Convert.ToString(water));
                writerCalorii2.Close();

                //добавляем в файл с употребленными продуктами за день
                string dateStatistics = File.ReadLines("STATISTICS/STATISTICS_" + Name + ".txt").Skip(0).First();
                DateTime dt2 = DateTime.Now;
                string CheckDate2 = dt.ToString("dd:MM:yy");
                if (CheckDate2 == dateStatistics)
                {   //дата совпала
                    System.IO.StreamWriter writerStatictics = new System.IO.StreamWriter("STATISTICS/STATISTICS_" + Name + ".txt", true); //здесь true
                    writerStatictics.WriteLine(strName + " " + ProduktCaloriiAdd);
                    writerStatictics.Close();
                }
                else
                {   //дата не совпала, значит перезаписываем
                    System.IO.StreamWriter writerStatictics = new System.IO.StreamWriter("STATISTICS/STATISTICS_" + Name + ".txt", false); //здесь false
                    writerStatictics.WriteLine(CheckDate2);
                    writerStatictics.WriteLine(strName + " " + ProduktCaloriiAdd);
                    writerStatictics.Close();
                }

                DialogResult Res = MessageBox.Show("Продукт успешно добавлен!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProduktName = "";
                ProduktNumber = 0;
                textBox_AddNum.Text = "";
                textBoxBook_AddName.Text = "";
            }
            else
            {
                DialogResult Res = MessageBox.Show("Продукт не найден, проверьте правильность введенных данных!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProduktName = "";
                ProduktNumber = 0;
                ProduktCaloriiAdd = 0;
            };
        }

        private void buttonBook_AddNo_Click(object sender, EventArgs e)
        {
            if (ProduktCaloriiAdd != 0)
            {
                string Name = labelProfil_Name.Text;
                string water = File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(2).First();
                double calorii = Convert.ToDouble(File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(1).First());
                string date = File.ReadLines("CALORII/CALORII_" + Name + ".txt").Skip(0).First();

                //проверка на "сегодняшний" файл
                DateTime dt = DateTime.Now;
                string CheckDate = dt.ToString("dd:MM:yy");
                if (CheckDate == date)
                {
                    System.IO.StreamWriter writerCalorii2 = new System.IO.StreamWriter("CALORII/CALORII_" + Name + ".txt", false);
                    writerCalorii2.WriteLine(date);
                    writerCalorii2.WriteLine(Convert.ToString(calorii - ProduktCaloriiAdd));
                    writerCalorii2.WriteLine(water);
                    writerCalorii2.Close();
                    DialogResult Res = MessageBox.Show("Последний продукт отменён!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProduktCaloriiAdd = 0;
                    textBoxBook_Calorii.Text = "";
                    //в файле со всеми употребленными продуктами указываем отмененный продукт
                    System.IO.StreamWriter writerStatictics = new System.IO.StreamWriter("STATISTICS/STATISTICS_" + Name + ".txt", true); //здесь true, в конец файла
                    writerStatictics.WriteLine("^(последний продукт отменен)");
                    writerStatictics.Close();
                }
                else
                {
                    DialogResult Res = MessageBox.Show("Продукт отменить невозможно!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult Res = MessageBox.Show("Продукт отменить невозможно!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
