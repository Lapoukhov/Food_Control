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
    public partial class formAuthorization : Form
    {
        public formAuthorization()
        {
            InitializeComponent();
        }
        //авторизация
        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            //вход в систему
            string login = textboxLogin.Text, password = textboxPassword.Text;
            int NumLogin = 0;
            bool checkLogin = false;
            //поиск логина
            FileStream fileLogin = new FileStream("SYSTEM/LOGIN.txt", FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileLogin);
            while (!reader.EndOfStream)
                if (reader.ReadLine() == login)
                {
                    checkLogin = true;
                    break;
                }
                else NumLogin++;
            reader.Close();
            if (checkLogin)   //если нашел логин, проверяем пароль
            {
                //begin передача через файл имени для другой формы
        //        System.IO.StreamWriter writer = new System.IO.StreamWriter("ONLINE.txt", false);
        //        writer.WriteLine(textboxLogin.Text);
        //        writer.Close();
                //end
                string secondLine = File.ReadLines("SYSTEM/PASSWORD.txt").Skip(NumLogin).First();
                if (secondLine == password)
                {
                    DialogResult = MessageBox.Show("Вы вошли в систему!", "Приветствуем", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    FormFoodControl FoodControl = new FormFoodControl();
                    FoodControl.labelProfil_Name.Text = this.textboxLogin.Text;
                    FoodControl.ShowDialog();
                    Close();
                }
                else
                {
                    DialogResult res = MessageBox.Show("Неправильный логин или пароль!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textboxLogin.Text = "";
                    textboxPassword.Text = "";
                };
            }
            else
                {
                    DialogResult = MessageBox.Show("Пользователь с таким логином не зарегистрирован!","ВНИМАНИЕ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textboxLogin.Text = "";
                    textboxPassword.Text = "";
                };
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            //переход на панель регистрации
            panelRegistration.Visible = true;
            textboxLoginReg.Text = "";
            textboxPasswordReg.Text = "";
            textboxPassword2.Text = "";
        }

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

        public struct Calorii
        {
            public string Date;    //дата
            public string NumCal;  //количество калорий
            public string Water;   //количество воды
        }

        private void buttonRegistrationOK_Click(object sender, EventArgs e)
        {
            //зарегстрировать пользователя
            string loginReg = textboxLoginReg.Text, passwordReg = textboxPasswordReg.Text, password2 = textboxPassword2.Text;
            bool checkLoginReg = false;
            //проверка логина
            FileStream file3 = new FileStream("SYSTEM/LOGIN.txt", FileMode.OpenOrCreate);
            StreamReader reader3 = new StreamReader(file3);
            while (!reader3.EndOfStream)
                if (reader3.ReadLine() == loginReg)
                {
                    checkLoginReg = true;
                    break;
                }
            reader3.Close();
            //проверка повторного пароля
            if (passwordReg == password2)
            {
                if (checkLoginReg)  //если такой логин уже есть в файле
                {
                    DialogResult = MessageBox.Show("Такой логин уже зарегистрирован!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textboxLoginReg.Text = "";
                    textboxPasswordReg.Text = "";
                    textboxPassword2.Text = "";
                }
                else  //запись нового логина и пароля
                {
                    System.IO.StreamWriter writer1 = new System.IO.StreamWriter("SYSTEM/LOGIN.txt", true);
                    writer1.WriteLine(loginReg);
                    writer1.Close();

                    System.IO.StreamWriter writer2 = new System.IO.StreamWriter("SYSTEM/PASSWORD.txt", true);
                    writer2.WriteLine(passwordReg);
                    writer2.Close();
                    DialogResult = MessageBox.Show("Пользователь успешно зарегистрирован!", "Приветствуем", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    FormFoodControl FoodControl = new FormFoodControl();
                    FoodControl.labelProfil_Name.Text = this.textboxLoginReg.Text;
                    CreateFileUser();        //создание файла с личными данными
                    CreateFileCalorii();     //создание файла со статистикой употребленных калорий и воды
                    CreateFileStatistics();  //создание файла со статистикой съеденных продуктов
                    CreateFileDiagramma();   //создание файла для диаграммы
                    FoodControl.ShowDialog();
                    Close();
                }
            }
            else
            {
                DialogResult = MessageBox.Show("Пароли не совпадают!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textboxLoginReg.Text = "";
                textboxPasswordReg.Text = "";
                textboxPassword2.Text = "";
            }
        }

        private void buttonToAutorization_Click(object sender, EventArgs e)
        {
            //вернуться на поле входа в систему
            panelRegistration.Visible = false;
            panelAutarization.Visible = true;
            textboxLogin.Text = "";
            textboxPassword.Text = "";
        }

        //создание файла с личными данными зарегистрированного пользователя (изначально данные по умолчанию)
        public void CreateFileUser()
        {
            string loginReg = textboxLoginReg.Text;
            Profil UserData = new Profil();
            UserData.Name = loginReg;
            UserData.Years = "0";
            UserData.Ves = "0";
            UserData.Rost = "0";
            UserData.Pol = 1;
            UserData.Target = 1;
            UserData.Activ = 3;
            string Name = loginReg;
            System.IO.StreamWriter writerUserData = new System.IO.StreamWriter("USER/USER_" + Name + ".txt", false);
            writerUserData.WriteLine(UserData.Name);
            writerUserData.WriteLine(UserData.Years);
            writerUserData.WriteLine(UserData.Ves);
            writerUserData.WriteLine(UserData.Rost);
            writerUserData.WriteLine(UserData.Pol);
            writerUserData.WriteLine(UserData.Target);
            writerUserData.WriteLine(UserData.Activ);
            writerUserData.Close();
        }

        //создание файла со статистикой употребленных калорий (изначально данные по умолчанию)
        public void CreateFileCalorii()
        {
            DateTime dt = DateTime.Now;
            Calorii UserCalorii = new Calorii();
            UserCalorii.Date = dt.ToString("dd:MM:yy");
            UserCalorii.NumCal = "0";
            UserCalorii.Water = "0";
            string Name = textboxLoginReg.Text;
            System.IO.StreamWriter writerUserCalorii = new System.IO.StreamWriter("CALORII/CALORII_" + Name + ".txt", false);
            writerUserCalorii.WriteLine(UserCalorii.Date);
            writerUserCalorii.WriteLine(UserCalorii.NumCal);
            writerUserCalorii.WriteLine(UserCalorii.Water);
            writerUserCalorii.Close();
        }

        //создание файла с употребленными продуктами за день (изначально данные по умолчанию)
        public void CreateFileStatistics()
        {
            DateTime dt = DateTime.Now;
            string Date = dt.ToString("dd:MM:yy");
            string Name = textboxLoginReg.Text;
            System.IO.StreamWriter writerProdukt = new System.IO.StreamWriter("STATISTICS/STATISTICS_" + Name + ".txt", false);
            writerProdukt.WriteLine(Date);
            writerProdukt.Close();
        }

        //создание файла для диаграммы (изначально данные по умолчанию)
        public void CreateFileDiagramma()
        {
            DateTime dt = DateTime.Now;
            string Date = dt.ToString("dd:MM:yy");
            string Name = textboxLoginReg.Text;
            System.IO.StreamWriter writerProdukt = new System.IO.StreamWriter("DIAGRAMMA/DIAGRAMMA_" + Name + ".txt", false);
            writerProdukt.WriteLine(Date);
            writerProdukt.Close();
        }
    }
}
