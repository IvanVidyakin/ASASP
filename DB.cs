using System;
using System.Collections.Generic;
using System.ComponentModel;
using SD = System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    class DB
    {
        public string sqlselectcomm;
        public string sqltempcomm;
        public int idnum;
        public string name = "";
        public int firstcleanrow;
        public List<string> sqllist = new List<string>();
        public DataGridView dataGridView1;
        public Label label1;
        public CheckBox CheckBox1;
        public RichTextBox rtbxquerry;
        public RichTextBox rtbxelem;
        public RichTextBox rtbxoldquerry;
        public TextBox tbxFind;
        public TextBox tbxmove;
        public Panel pnltabs;
        public Form1 workform;
        Globalum constant = new Globalum("Server=localhost;Database=mydb;Uid=root;pwd=root;charset=utf8;", 366, new MySqlConnection("Server=localhost;Database=mydb;Uid=root;pwd=root;charset=utf8;"));

        public DB(Form1 mainform)
        {
            workform = mainform;
            dataGridView1 = workform.getdgv();
            label1 = workform.getlbl();
            CheckBox1 = workform.getcbx();
            rtbxquerry = workform.getrbx1();
            rtbxelem = workform.getrbx2();
            rtbxoldquerry = workform.getrbx3();
            tbxFind = workform.gettbx1();
            tbxmove = workform.gettbx2();
            pnltabs = workform.getpnl();
        }
        public void DBConnection()
        {
            try
            {
                if (constant.conn.State == SD.ConnectionState.Closed)
                {
                    constant.conn.Open();
                    MessageBox.Show("Successfully connected");
                }
                expired();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        public void SORTDB()
        {
            try
            {
                SD.DataTable table = new SD.DataTable();
                if (sqlselectcomm.IndexOf("ORDER") != -1)
                {
                    sqlselectcomm = sqltempcomm;
                }
                string sqlsortcomm = sqlselectcomm;
                sqlsortcomm += $" ORDER BY `{dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText}`";
                if (CheckBox1.Checked == true)
                {
                    sqlsortcomm += " DESC";
                }
                SelectQuerry(name, sqlsortcomm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public static string[][] addinglist = 
        {
            new string[]{"Студенты.Студенты_id","Студенты.ФИО","Студенты.Пол", "Студенты.Номер_телефона", "Студенты.Адрес", "Студенты.Дата_рождения", "Группы.Номер", "Формы_оплаты_обучения.Цена", "Неизменяемо.Неизменяемо"}, 
            new string[]{"Институты.Название", "Институты.Декан"},
            new string[]{"Кафедры.Шифр","Кафедры.Название","Кафедры.Заведующий","Институты.Название"},
            new string[]{"Специальности.Шифр", "Специальности.Название", "Кафедры.Название", "Специальности.Количество_курсов"},
            new string[]{"Группы.Курс", "Группы.Поток", "Группы.Номер", "Специальности.Название", "Кураторы.ФИО", "Формы_обучения.Тип"},
            new string[]{"Учебные_планы.Пары_лекций", "Учебные_планы.Пары_семинаров", "Учебные_планы.Семестр", "Учебные_планы.Курсовая", "Дисциплины.Название", "Специальности.Название", "Кафедры.Название", "Формы_контроля.Тип"},
            new string[]{"Дисциплины.Название", "Кафедры.Название"},
            new string[]{"Посещаемость.Студенты_id", "Студенты.ФИО", "Дисциплины.Название", "Посещаемость.Семестр", "Посещаемость.Пары_лекций", "Посещаемость.Пары_семинаров"},
            new string[]{"Формы_оплаты_обучения.Цена"},
            new string[]{"Формы_обучения.Тип"},
            new string[]{"Кураторы.ФИО"},
            new string[]{"Формы_контроля.Тип"},
            new string[]{"Кандидаты_на_исключение.Студенты_id", "Студенты.ФИО", "Кандидаты_на_исключение.Причина"},
            new string[]{"Курсовые.Тема", "Курсовые.Курс", "Курсовые.Студенты_id", "Студенты.ФИО", "Оценки.Результат", "Дисциплины.Название", "Неизменяемо.Неизменяемо"},
            new string[]{"Успеваемость.Студенты_id", "Студенты.ФИО", "Дисциплины.Название", "Неизменяемо.Неизменяемо", "Неизменяемо.Неизменяемо", "Неизменяемо.Неизменяемо", "Неизменяемо.Неизменяемо", "Неизменяемо.Неизменяемо", "Неизменяемо.Неизменяемо", "Оценки.Результат", "Формы_контроля.Тип", "Неизменяемо.Неизменяемо"},
            new string[]{"Академические_задолженности.Студенты_id", "Студенты.ФИО", "Дисциплины.Название", "Академические_задолженности.Дата_появления", "Академические_задолженности.Тип_задолженности"}
        };
        public static Item[] items =
        {
            new Item(@"SELECT Студенты.Студенты_id as Шифр, Студенты.ФИО, Студенты.Пол, Студенты.Номер_телефона, Студенты.Адрес, Студенты.Дата_рождения, Группы.Номер as Номер_группы, Формы_оплаты_обучения.Цена as Цена_обучения, COUNT(Академические_задолженности.Академические_задолженности_id) as Долги, Студенты.Студенты_id as `Служебный id`
                            FROM Студенты
                            LEFT JOIN Группы USING(Группы_id)
                            LEFT JOIN Формы_оплаты_обучения USING(Формы_оплаты_обучения_id)
                            LEFT JOIN Академические_задолженности USING(Студенты_id)
                            GROUP BY Студенты_id, ФИО, Пол, Номер_телефона, Адрес, Дата_рождения, Группы.Номер",10,addinglist[0]),
            new Item(@"SELECT Институты.Название, Институты.Декан, Институты.Институты_id as `Служебный id`
                                FROM Институты",3,addinglist[1]),
            new Item(@"SELECT Кафедры.Шифр, Кафедры.Название, Кафедры.Заведующий, Институты.Название as Институт, Кафедры.Кафедры_id as `Служебный id`
                                FROM Кафедры
                                LEFT JOIN Институты USING(Институты_id)",5,addinglist[2]),
            new Item(@"SELECT Специальности.Шифр, Специальности.Название, Кафедры.Название as Кафедра, Специальности.Количество_курсов, Специальности.Специальности_id  as `Служебный id`
                                FROM Специальности
                                LEFT JOIN Кафедры USING(Кафедры_id)",5,addinglist[3]),
            new Item(@"SELECT Группы.Курс, Группы.Поток, Группы.Номер, Специальности.Название as Специальность, Кураторы.ФИО as Куратор, Формы_обучения.Тип as `Форма обучения`, Группы.Группы_id  as `Служебный id`
                                FROM Группы
                                INNER JOIN Специальности USING(Специальности_id)
                                LEFT JOIN Кураторы USING(Кураторы_id)
                                INNER JOIN Формы_обучения USING(Формы_обучения_id)",7,addinglist[4]),
            new Item(@"SELECT Учебные_планы.Пары_лекций as `Лекций по плану`, Учебные_планы.Пары_семинаров as `Семинаров по плану`, Учебные_планы.Семестр, Учебные_планы.Курсовая, Дисциплины.Название as Дисциплина, Специальности.Название as Специальность, Кафедры.Название as Кафедра, Формы_контроля.Тип as `Форма контроля`, Учебные_планы.Учебные_планы_id as `Служебный id`
                                FROM Учебные_планы
                                INNER JOIN Дисциплины USING(Дисциплины_id)
                                INNER JOIN Специальности USING(Специальности_id)
                                LEFT JOIN Кафедры ON Специальности.Кафедры_id=Кафедры.Кафедры_id
                                INNER JOIN Формы_контроля USING(Формы_контроля_id)",9,addinglist[5]),
            new Item(@"SELECT Дисциплины.Название as Дисциплина, Кафедры.Название as Кафедра, Дисциплины.Дисциплины_id as `Служебный id`
                                FROM Дисциплины
                                LEFT JOIN Кафедры USING(Кафедры_id)",3,addinglist[6]),
            new Item(@"SELECT Посещаемость.Студенты_id as Шифр, Студенты.ФИО, Дисциплины.Название as Дисциплина, Посещаемость.Семестр, Посещаемость.Пары_лекций as `Посещено лекций`, Посещаемость.Пары_семинаров as `Посещено семинаров`, Посещаемость.Посещаемость_id as `Служебный id`
                                FROM Посещаемость
                                INNER JOIN Студенты USING(Студенты_id)
                                INNER JOIN Дисциплины USING(Дисциплины_id)",7,addinglist[7]),
            new Item(@"SELECT Формы_оплаты_обучения.Цена, Формы_оплаты_обучения.Формы_оплаты_обучения_id as `Служебный id`
                                FROM Формы_оплаты_обучения",2,addinglist[8]),
            new Item(@"SELECT Формы_обучения.Тип, Формы_обучения.Формы_обучения_id as `Служебный id`
                                FROM Формы_обучения",2,addinglist[9]),
            new Item(@"SELECT Кураторы.ФИО, Кураторы.Кураторы_id as `Служебный id`
                                FROM Кураторы",2,addinglist[10]),
            new Item(@"SELECT Формы_контроля.Тип as Форма, Формы_контроля.Формы_контроля_id as `Служебный id`
                                FROM Формы_контроля",2,addinglist[11]),
            new Item(@"SELECT Кандидаты_на_исключение.Студенты_id as Шифр, Студенты.ФИО, Кандидаты_на_исключение.Причина, Кандидаты_на_исключение.Кандидаты_на_исключение_id as `Служебный id`
                                FROM Кандидаты_на_исключение
                                INNER JOIN Студенты USING(Студенты_id)",4,addinglist[12]),
            new Item(@"SELECT Курсовые.Тема, Курсовые.Курс, Курсовые.Студенты_id as Шифр, Студенты.ФИО, Оценки.Результат, Дисциплины.Название as Дисциплина, Кафедры.Название as Кафедра, Курсовые.Курсовые_id as `Служебный id`
                                FROM Курсовые
                                INNER JOIN Студенты USING(Студенты_id)
                                LEFT JOIN Оценки USING(Оценки_id)
                                INNER JOIN Дисциплины USING(Дисциплины_id)
                                INNER JOIN Кафедры USING(Кафедры_id)",8,addinglist[13]),
            new Item(@"SELECT Успеваемость.Студенты_id as Шифр, Студенты.ФИО, Дисциплины.Название as Дисциплина, Посещаемость.Пары_лекций as `Посещено лекций`, Посещаемость.Пары_семинаров as `Посещено семинаров`, Учебные_планы.Пары_лекций as `Лекций по плану`, Учебные_планы.Пары_семинаров as `Семинаров по плану`, Посещаемость.Пары_лекций/Учебные_планы.Пары_лекций*100 as `Процент посещения лекций`, Посещаемость.Пары_семинаров/Учебные_планы.Пары_семинаров*100 as `Процент посещения семинаров`,  Оценки.Результат, Формы_контроля.Тип as `Форма контроля`, Посещаемость.Семестр, Успеваемость.Успеваемость_id  as `Служебный id`
                                FROM Успеваемость
                                INNER JOIN Студенты USING(Студенты_id)
                                INNER JOIN Посещаемость USING(Посещаемость_id)
                                INNER JOIN Дисциплины USING(Дисциплины_id)
                                INNER JOIN Учебные_планы USING(Учебные_планы_id)
                                LEFT JOIN Оценки USING(Оценки_id)
                                INNER JOIN Формы_контроля ON Успеваемость.Формы_контроля_id=Формы_контроля.Формы_контроля_id",13,addinglist[14]),
            new Item(@"SELECT Академические_задолженности.Студенты_id as Шифр, Студенты.ФИО, Дисциплины.Название as Дисциплина, Академические_задолженности.Дата_появления, Академические_задолженности.Тип_задолженности, Академические_задолженности.Академические_задолженности_id as `Служебный id`
                                FROM Академические_задолженности
                                INNER JOIN Студенты USING(Студенты_id)
                                LEFT JOIN Дисциплины USING(Дисциплины_id)",6,addinglist[15])
        };
        public class Item
        {
            public string Sqlcomm;
            public int Num;
            public string[] Addlist;
            public Item(string sqlcomm, int num, string[] addlists)
            {
                Sqlcomm = sqlcomm;
                Num = num;
                Addlist = addlists;
            }
        }
        public void Addtolist(string[] addings)
        {
            foreach (string str in addings)
            {
                sqllist.Add(str);
            }
        }
        public void SelectQuerry(string n, string command = "", int flag = 0)
        {
            try
            {
                if (n == "")
                {
                    throw new Exception("Таблица не выбрана");
                }
                if (name != n)
                {
                    sqllist.Clear();
                }
                SD.DataTable table = new SD.DataTable();
                dataGridView1.DataSource = null;
                name = n;
                name = name.Replace('_', ' ');
                label1.Visible = true;
                label1.Text = name;
                name = name.Replace(' ', '_');
                pnltabs.Visible = false;
                if (command == "" || flag != 0)
                {
                    sqlselectcomm = $"SELECT * FROM {name}";
                    switch (name)
                    {
                        case "Студенты":
                            sqlselectcomm = @"SELECT Студенты.Студенты_id as Шифр, Студенты.ФИО, Студенты.Пол, Студенты.Номер_телефона, Студенты.Адрес, Студенты.Дата_рождения, Группы.Номер as Номер_группы, Формы_оплаты_обучения.Цена as Цена_обучения, COUNT(Академические_задолженности.Академические_задолженности_id) as Долги, Студенты.Студенты_id as `Служебный id`
                            FROM Студенты
                            LEFT JOIN Группы USING(Группы_id)
                            LEFT JOIN Формы_оплаты_обучения USING(Формы_оплаты_обучения_id)
                            LEFT JOIN Академические_задолженности USING(Студенты_id)
                            GROUP BY Студенты_id, ФИО, Пол, Номер_телефона, Адрес, Дата_рождения, Группы.Номер";
                            idnum = 10;
                            sqllist.Add("Студенты.Студенты_id");
                            sqllist.Add("Студенты.ФИО");
                            sqllist.Add("Студенты.Пол");
                            sqllist.Add("Студенты.Номер_телефона");
                            sqllist.Add("Студенты.Адрес");
                            sqllist.Add("Студенты.Дата_рождения");
                            sqllist.Add("Группы.Номер");
                            sqllist.Add("Формы_оплаты_обучения.Цена");
                            sqllist.Add("Неизменяемо.Неизменяемо");
                            break;
                        case "Институты":
                            sqlselectcomm = @"SELECT Институты.Название, Институты.Декан, Институты.Институты_id as `Служебный id`
                                FROM Институты";
                            idnum = 3;
                            sqllist.Add("Институты.Название");
                            sqllist.Add("Институты.Декан");
                            break;
                        case "Кафедры":
                            sqlselectcomm = @"SELECT Кафедры.Шифр, Кафедры.Название, Кафедры.Заведующий, Институты.Название as Институт, Кафедры.Кафедры_id as `Служебный id`
                                FROM Кафедры
                                LEFT JOIN Институты USING(Институты_id)";
                            idnum = 5;
                            sqllist.Add("Кафедры.Шифр");
                            sqllist.Add("Кафедры.Название");
                            sqllist.Add("Кафедры.Заведующий");
                            sqllist.Add("Институты.Название");
                            break;
                        case "Специальности":
                            sqlselectcomm = @"SELECT Специальности.Шифр, Специальности.Название, Кафедры.Название as Кафедра, Специальности.Количество_курсов, Специальности.Специальности_id  as `Служебный id`
                                FROM Специальности
                                LEFT JOIN Кафедры USING(Кафедры_id)";
                            idnum = 5;
                            sqllist.Add("Специальности.Шифр");
                            sqllist.Add("Специальности.Название");
                            sqllist.Add("Кафедры.Название");
                            sqllist.Add("Специальности.Количество_курсов");
                            break;
                        case "Группы":
                            sqlselectcomm = @"SELECT Группы.Курс, Группы.Поток, Группы.Номер, Специальности.Название as Специальность, Кураторы.ФИО as Куратор, Формы_обучения.Тип as `Форма обучения`, Группы.Группы_id  as `Служебный id`
                                FROM Группы
                                INNER JOIN Специальности USING(Специальности_id)
                                LEFT JOIN Кураторы USING(Кураторы_id)
                                INNER JOIN Формы_обучения USING(Формы_обучения_id)";
                            idnum = 7;
                            sqllist.Add("Группы.Курс");
                            sqllist.Add("Группы.Поток");
                            sqllist.Add("Группы.Номер");
                            sqllist.Add("Специальности.Название");
                            sqllist.Add("Кураторы.ФИО");
                            sqllist.Add("Формы_обучения.Тип");
                            break;
                        case "Учебные_планы":
                            sqlselectcomm = @"SELECT Учебные_планы.Пары_лекций as `Лекций по плану`, Учебные_планы.Пары_семинаров as `Семинаров по плану`, Учебные_планы.Семестр, Учебные_планы.Курсовая, Дисциплины.Название as Дисциплина, Специальности.Название as Специальность, Кафедры.Название as Кафедра, Формы_контроля.Тип as `Форма контроля`, Учебные_планы.Учебные_планы_id as `Служебный id`
                                FROM Учебные_планы
                                INNER JOIN Дисциплины USING(Дисциплины_id)
                                INNER JOIN Специальности USING(Специальности_id)
                                LEFT JOIN Кафедры ON Специальности.Кафедры_id=Кафедры.Кафедры_id
                                INNER JOIN Формы_контроля USING(Формы_контроля_id)";
                            idnum = 9;
                            sqllist.Add("Учебные_планы.Пары_лекций");
                            sqllist.Add("Учебные_планы.Пары_семинаров");
                            sqllist.Add("Учебные_планы.Семестр");
                            sqllist.Add("Учебные_планы.Курсовая");
                            sqllist.Add("Дисциплины.Название");
                            sqllist.Add("Специальности.Название");
                            sqllist.Add("Кафедры.Название");
                            sqllist.Add("Формы_контроля.Тип");
                            break;
                        case "Дисциплины":
                            sqlselectcomm = @"SELECT Дисциплины.Название as Дисциплина, Кафедры.Название as Кафедра, Дисциплины.Дисциплины_id as `Служебный id`
                                FROM Дисциплины
                                LEFT JOIN Кафедры USING(Кафедры_id)";
                            idnum = 3;
                            sqllist.Add("Дисциплины.Название");
                            sqllist.Add("Кафедры.Название");
                            break;
                        case "Посещаемость":
                            sqlselectcomm = @"SELECT Посещаемость.Студенты_id as Шифр, Студенты.ФИО, Дисциплины.Название as Дисциплина, Посещаемость.Семестр, Посещаемость.Пары_лекций as `Посещено лекций`, Посещаемость.Пары_семинаров as `Посещено семинаров`, Посещаемость.Посещаемость_id as `Служебный id`
                                FROM Посещаемость
                                INNER JOIN Студенты USING(Студенты_id)
                                INNER JOIN Дисциплины USING(Дисциплины_id)";
                            idnum = 7;
                            sqllist.Add("Посещаемость.Студенты_id");
                            sqllist.Add("Студенты.ФИО");
                            sqllist.Add("Дисциплины.Название");
                            sqllist.Add("Посещаемость.Семестр");
                            sqllist.Add("Посещаемость.Пары_лекций");
                            sqllist.Add("Посещаемость.Пары_семинаров");
                            break;
                        case "Формы_оплаты_обучения":
                            sqlselectcomm = @"SELECT Формы_оплаты_обучения.Цена, Формы_оплаты_обучения.Формы_оплаты_обучения_id as `Служебный id`
                                FROM Формы_оплаты_обучения";
                            idnum = 2;
                            sqllist.Add("Формы_оплаты_обучения.Цена");
                            break;
                        case "Формы_обучения":
                            sqlselectcomm = @"SELECT Формы_обучения.Тип, Формы_обучения.Формы_обучения_id as `Служебный id`
                                FROM Формы_обучения";
                            idnum = 2;
                            sqllist.Add("Формы_обучения.Тип");
                            break;
                        case "Кураторы":
                            sqlselectcomm = @"SELECT Кураторы.ФИО, Кураторы.Кураторы_id as `Служебный id`
                                FROM Кураторы";
                            idnum = 2;
                            sqllist.Add("Кураторы.ФИО");
                            break;
                        case "Формы_контроля":
                            sqlselectcomm = @"SELECT Формы_контроля.Тип as Форма, Формы_контроля.Формы_контроля_id as `Служебный id`
                                FROM Формы_контроля";
                            idnum = 2;
                            sqllist.Add("Формы_контроля.Тип");
                            break;
                        case "Кандидаты_на_исключение":
                            sqlselectcomm = @"SELECT Кандидаты_на_исключение.Студенты_id as Шифр, Студенты.ФИО, Кандидаты_на_исключение.Причина, Кандидаты_на_исключение.Кандидаты_на_исключение_id as `Служебный id`
                                FROM Кандидаты_на_исключение
                                INNER JOIN Студенты USING(Студенты_id)";
                            idnum = 4;
                            sqllist.Add("Кандидаты_на_исключение.Студенты_id");
                            sqllist.Add("Студенты.ФИО");
                            sqllist.Add("Кандидаты_на_исключение.Причина");
                            break;
                        case "Курсовые":
                            sqlselectcomm = @"SELECT Курсовые.Тема, Курсовые.Курс, Курсовые.Студенты_id as Шифр, Студенты.ФИО, Оценки.Результат, Дисциплины.Название as Дисциплина, Кафедры.Название as Кафедра, Курсовые.Курсовые_id as `Служебный id`
                                FROM Курсовые
                                INNER JOIN Студенты USING(Студенты_id)
                                LEFT JOIN Оценки USING(Оценки_id)
                                INNER JOIN Дисциплины USING(Дисциплины_id)
                                INNER JOIN Кафедры USING(Кафедры_id)";
                            idnum = 8;
                            sqllist.Add("Курсовые.Тема");
                            sqllist.Add("Курсовые.Курс");
                            sqllist.Add("Курсовые.Студенты_id");
                            sqllist.Add("Студенты.ФИО");
                            sqllist.Add("Оценки.Результат");
                            sqllist.Add("Дисциплины.Название");
                            sqllist.Add("Неизменяемо.Неизменяемо");
                            break;
                        case "Успеваемость":
                            sqlselectcomm = @"SELECT Успеваемость.Студенты_id as Шифр, Студенты.ФИО, Дисциплины.Название as Дисциплина, Посещаемость.Пары_лекций as `Посещено лекций`, Посещаемость.Пары_семинаров as `Посещено семинаров`, Учебные_планы.Пары_лекций as `Лекций по плану`, Учебные_планы.Пары_семинаров as `Семинаров по плану`, Посещаемость.Пары_лекций/Учебные_планы.Пары_лекций*100 as `Процент посещения лекций`, Посещаемость.Пары_семинаров/Учебные_планы.Пары_семинаров*100 as `Процент посещения семинаров`,  Оценки.Результат, Формы_контроля.Тип as `Форма контроля`, Посещаемость.Семестр, Успеваемость.Успеваемость_id  as `Служебный id`
                                FROM Успеваемость
                                INNER JOIN Студенты USING(Студенты_id)
                                INNER JOIN Посещаемость USING(Посещаемость_id)
                                INNER JOIN Дисциплины USING(Дисциплины_id)
                                INNER JOIN Учебные_планы USING(Учебные_планы_id)
                                LEFT JOIN Оценки USING(Оценки_id)
                                INNER JOIN Формы_контроля ON Успеваемость.Формы_контроля_id=Формы_контроля.Формы_контроля_id";
                            idnum = 13;
                            sqllist.Add("Успеваемость.Студенты_id");
                            sqllist.Add("Студенты.ФИО");
                            sqllist.Add("Дисциплины.Название");
                            sqllist.Add("Неизменяемо.Неизменяемо");
                            sqllist.Add("Неизменяемо.Неизменяемо");
                            sqllist.Add("Неизменяемо.Неизменяемо");
                            sqllist.Add("Неизменяемо.Неизменяемо");
                            sqllist.Add("Неизменяемо.Неизменяемо");
                            sqllist.Add("Неизменяемо.Неизменяемо");
                            sqllist.Add("Оценки.Результат");
                            sqllist.Add("Формы_контроля.Тип");
                            sqllist.Add("Неизменяемо.Неизменяемо");
                            break;
                        case "Академические_задолженности":
                            sqlselectcomm = @"SELECT Академические_задолженности.Студенты_id as Шифр, Студенты.ФИО, Дисциплины.Название as Дисциплина, Академические_задолженности.Дата_появления, Академические_задолженности.Тип_задолженности, Академические_задолженности.Академические_задолженности_id as `Служебный id`
                                FROM Академические_задолженности
                                INNER JOIN Студенты USING(Студенты_id)
                                LEFT JOIN Дисциплины USING(Дисциплины_id)";
                            idnum = 6;
                            sqllist.Add("Академические_задолженности.Студенты_id");
                            sqllist.Add("Студенты.ФИО");
                            sqllist.Add("Дисциплины.Название");
                            sqllist.Add("Академические_задолженности.Дата_появления");
                            sqllist.Add("Академические_задолженности.Тип_задолженности");
                            break;
                        default:
                            break;
                    }
                    sqltempcomm = sqlselectcomm;
                }
                else
                {
                    sqlselectcomm = command;
                }
                rtbxoldquerry.Text = rtbxquerry.Text;
                rtbxquerry.Text = sqlselectcomm;
                MySqlDataAdapter sql_data = new MySqlDataAdapter(sqlselectcomm, constant.getjoin());
                sql_data.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.Columns[idnum - 1].Visible = false;
                firstcleanrow = 0;
                while (dataGridView1[0, firstcleanrow].Value != null)
                {
                    firstcleanrow++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public void EXPORTDB()
        {
            try
            {
                Excel.Application export = new Excel.Application();
                export.Workbooks.Add();
                Excel.Worksheet expsh = (Excel.Worksheet)export.ActiveSheet;
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                {
                    expsh.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText;
                }
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                    {
                        expsh.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                    }
                }
                export.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public void FIND()
        {
            try
            {
                if (sqlselectcomm.IndexOf("LIKE") != -1)
                {
                    sqlselectcomm = sqltempcomm;
                }
                string sqlfindcomm = $"SELECT * FROM ({sqlselectcomm}) subquerry WHERE {dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText} LIKE '%{tbxFind.Text}%'";
                SelectQuerry(name, sqlfindcomm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public void UPDATEDB(string newinf)
        {
            try
            {
                if (name == "")
                {
                    throw new Exception("Таблица, не выбрана, пожалуйста сначала нажмите 'Выбрать таблицу'");
                }
                string s = sqllist[dataGridView1.CurrentCell.ColumnIndex];
                string colname = s.Substring(s.IndexOf('.') + 1);
                if (colname.IndexOf("Дата") != -1)
                {
                    string tempday = newinf.Substring(0, 2);
                    string tempmonth = newinf.Substring(3, 2);
                    string tempyear = newinf.Substring(6, 4);
                    newinf = tempyear + '-' + tempmonth + '-' + tempday;
                }
                string sqlupdatecomm = "";
                string tabname = s.Substring(0, s.IndexOf('.'));
                rtbxelem.Text += name + ' ' + tabname;
                if (s == "Дисциплины.Название" && name == "Успеваемость")
                {
                    throw new Exception("Дисциплину, по которой ведётся учёт успеваемости, невозможно изменить. Удалите и начните новый учёт, либо измените данные в других таблицах (например-название дисциплины в таблице 'дисциплины').");
                }
                if ((s == "Студенты.ФИО") && (name != "Студенты"))
                {
                    throw new Exception("Невозможно изменить ФИО студента не в соответствующей таблице, попробуйте изменить шифр");
                }
                if (s == "Неизменяемо.Неизменяемо")
                {
                    throw new Exception("Данный столбец невозможно изменить в указанной таблице. Возможно он калькулируется из данных других таблиц, либо в них же задаётся. Также, возможно, данные об этом столбце получает программа на основании данных из другого. Не вводите сюда ничего самостоятельно.");
                }
                else
                {
                    if (name == tabname)
                    {
                        sqlupdatecomm = $"UPDATE {name} SET {colname}='{newinf}' WHERE {name}.{name}_id={int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[idnum - 1].Value.ToString())}";
                    }
                    else
                    {
                        sqlupdatecomm = $"UPDATE {name} SET {name}.{tabname}_id=(SELECT DISTINCT {tabname}.{tabname}_id FROM {tabname} WHERE {tabname}.{colname}='{newinf}') WHERE {name}.{name}_id={int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[idnum - 1].Value.ToString())}";
                        sqltempcomm = $"SELECT COUNT(*) FROM (SELECT DISTINCT {tabname}.{tabname}_id FROM {tabname} WHERE {tabname}.{colname}='{newinf}') subquerry";
                        MySqlCommand commtemp = new MySqlCommand(sqltempcomm, constant.conn);
                        if (commtemp.ExecuteScalar().ToString() == "0")
                        {
                            throw new Exception($"Введённое значение не было найдено в таблице {tabname}, перепишете изменяемое значение, либо добавьте новое в вышеописанную таблицу");
                        }
                    }
                }
                rtbxoldquerry.Text = rtbxquerry.Text;
                rtbxquerry.Text = sqlupdatecomm;
                MySqlCommand comm = new MySqlCommand(sqlupdatecomm, constant.conn);
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Close();
                SelectQuerry(name, sqlselectcomm, 1);
            }
            catch (Exception ex)
            {
                SelectQuerry(name, sqlselectcomm, 1);
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public void DELETEDB()
        {
            try
            {
                if (name == "Кандидаты_на_исключение")
                {
                    throw new Exception("В данной таблице нельзя удалять строки, удалите соответствующую академическую задолженность, после чего перезапустите программу или нажмите 'Обновить список на исключение'");
                }
                string sqldeletecomm = $"DELETE FROM {name} WHERE {name}.{name}_id={int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[idnum - 1].Value.ToString())}";
                rtbxoldquerry.Text = rtbxquerry.Text;
                rtbxquerry.Text = sqldeletecomm;
                MySqlCommand comm = new MySqlCommand(sqldeletecomm, constant.conn);
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Close();
                SelectQuerry(name, sqlselectcomm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public void INSERTDB()
        {
            try
            {
                rtbxelem.Text = "";
                List<string> insertlist = new List<string>();
                for (int i = 0; i < idnum - 1; i++)
                {
                    insertlist.Add(dataGridView1[i, firstcleanrow].Value.ToString());
                }
                for (int i = 0; i < idnum - 1; i++)
                {
                    rtbxelem.Text += ',' + insertlist[i];
                }
                string sqlinsertcomm = "";
                string temp1 = "";
                string temp2 = "";
                string stemp = "";
                MySqlCommand commtemp;
                switch (name)
                {
                    case "Студенты":
                        if ((insertlist[1] == "") || (insertlist[2] == "") || (insertlist[3] == "") || (insertlist[4] == "") || (insertlist[5] == "") || (insertlist[6] == "") || (insertlist[7] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены (2,3,4,5,6,7,8). Введите все необходимые данные и попробуйте снова. Если номер группы еще неизвестен, введите 0.");
                        }
                        if (DateTime.Parse(insertlist[5]).Month.ToString().Length == 1)
                        {
                            temp1 = "0";
                        }
                        if (DateTime.Parse(insertlist[5]).Day.ToString().Length == 1)
                        {
                            temp2 = "0";
                        }
                        stemp = DateTime.Parse(insertlist[5]).Year.ToString() + '-' + temp1 + DateTime.Parse(insertlist[5]).Month.ToString() + '-' + temp2 + DateTime.Parse(insertlist[5]).Day.ToString();
                        sqlinsertcomm = $@"INSERT INTO Студенты (ФИО, Пол, Номер_телефона, Адрес, Дата_рождения, Группы_id, Формы_оплаты_обучения_id)
                                VALUES ('{insertlist[1]}','{insertlist[2]}','{insertlist[3]}','{insertlist[4]}','{stemp}', 
                                (SELECT Группы_id FROM Группы WHERE Группы.Номер={insertlist[6]}),(SELECT Формы_оплаты_обучения_id FROM Формы_оплаты_обучения WHERE Цена={insertlist[7]}))";
                        break;
                    case "Институты":
                        if (insertlist[0] == "")
                        {
                            throw new Exception("Не все обязательные поля заполнены (1). Введите все необходимые данные и попробуйте снова");
                        }
                        sqlinsertcomm = $@"INSERT INTO Институты (Название, Декан) 
                                VALUES('{insertlist[0]}','{insertlist[1]}')";
                        break;
                    case "Кафедры":
                        if ((insertlist[0] == "") || (insertlist[1] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены (1,2). Введите все необходимые данные и попробуйте снова");
                        }
                        sqlinsertcomm = $@"INSERT INTO Кафедры (Шифр, Название, Заведующий, Институты_id)
                                VALUES('{insertlist[0]}','{insertlist[1]}','{insertlist[2]}',(SELECT Институты_id FROM Институты WHERE Название='{insertlist[3]}'))";
                        break;
                    case "Специальности":
                        if ((insertlist[0] == "") || (insertlist[1] == "") || (insertlist[3] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены (1,2,4). Введите все необходимые данные и попробуйте снова");
                        }
                        sqlinsertcomm = $@"INSERT INTO Специальности (Шифр, Название, Кафедры_id)
                                VALUES('{insertlist[0]}','{insertlist[1]}',(SELECT Кафедры_id FROM Кафедры WHERE Название='{insertlist[2]}'),'{insertlist[3]}')";
                        break;
                    case "Группы":
                        if ((insertlist[0] == "") || (insertlist[1] == "") || (insertlist[2] == "") || (insertlist[3] == "") || (insertlist[5] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены (1,2,3,4,6). Введите все необходимые данные и попробуйте снова");
                        }
                        sqlinsertcomm = $@"INSERT INTO Группы (Курс, Поток, Номер, Специальности_id, Кураторы_id, Формы_обучения_id)
                                VALUES('{int.Parse(insertlist[0])}','{insertlist[1]}','{insertlist[2]}',(SELECT Специальности_id FROM Специальности WHERE Название='{insertlist[3]}'),
                                (SELECT Кураторы_id FROM Кураторы WHERE ФИО='{insertlist[4]}'), (SELECT Формы_обучения_id FROM Формы_обучения WHERE Тип='{insertlist[5]}'))";
                        break;
                    case "Учебные_планы":
                        if ((insertlist[0] == "") || (insertlist[1] == "") || (insertlist[2] == "") || (insertlist[3] == "") || (insertlist[4] == "") || (insertlist[5] == "") || (insertlist[6] == "") || (insertlist[7] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены (1,2,3,4,5,6,7,8). Введите все необходимые данные и попробуйте снова. Если количество часов еще неизвестно введите 0.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Учебные_планы (Пары_лекций, Пары_семинаров, Семестр, Курсовая, Дисциплины_id, Специальности_id, Формы_контроля_id)
                                VALUES('{int.Parse(insertlist[0])}','{int.Parse(insertlist[1])}','{int.Parse(insertlist[2])}','{insertlist[3]}',(SELECT Дисциплины_id FROM Дисциплины WHERE Название='{insertlist[4]}'),
                                (SELECT Специальности_id FROM Специальности WHERE Название='{insertlist[5]}' AND Кафедры_id=(SELECT Кафедры_id FROM Кафедры WHERE Название='{insertlist[6]}')),(SELECT Формы_контроля_id FROM Формы_контроля WHERE Тип='{insertlist[7]}'))";
                        break;
                    case "Дисциплины":
                        if (insertlist[0] == "")
                        {
                            throw new Exception("Не все обязательные поля заполнены(1). Введите все необходимые данные и попробуйте снова.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Дисциплины (Название, Кафедры_id)
                                VALUES('{insertlist[0]}',(SELECT Кафедры_id FROM Кафедры WHERE Название='{insertlist[1]}'))";
                        break;
                    case "Посещаемость":
                        if ((insertlist[0] == "") || (insertlist[2] == "") || (insertlist[3] == "") || (insertlist[4] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены(1,3,4,5,6). Введите все необходимые данные и попробуйте снова. Если количество посещённых пар ещё неизвестно или равно нулю введите 0.");
                        }
                        sqltempcomm = $"SELECT COUNT(*) FROM Студенты WHERE Студенты_id={insertlist[0]}";
                        commtemp = new MySqlCommand(sqltempcomm, constant.conn);
                        if (commtemp.ExecuteScalar().ToString() == "0")
                        {
                            throw new Exception($"Данный шифр студента недействителен, перепишете изменяемое значение, либо добавьте новое в в таблицу студентов.");
                        }
                        if (insertlist[1] != "")
                        {
                            throw new Exception("Вводить ФИО студента не нужно. Введите шифр и программа сама вставит необходимое ФИО.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Посещаемость (Студенты_id, Дисциплины_id, Семестр, Пары_лекций, Пары_семинаров)
                                VALUES({int.Parse(insertlist[0])},(SELECT Дисциплины_id FROM Дисциплины WHERE Название='{insertlist[2]}'), {int.Parse(insertlist[3])},{int.Parse(insertlist[4])},{int.Parse(insertlist[5])})";
                        break;
                    case "Формы_оплаты_обучения":
                        if (insertlist[0] == "")
                        {
                            throw new Exception("Не все обязательные поля заполнены(1). Введите все необходимые данные и попробуйте снова.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Формы_оплаты_обучения (Цена)
                                VALUES('{insertlist[0]}')";
                        break;
                    case "Формы_обучения":
                        if (insertlist[0] == "")
                        {
                            throw new Exception("Не все обязательные поля заполнены(1). Введите все необходимые данные и попробуйте снова.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Формы (Тип)
                                VALUES('{insertlist[0]}')";
                        break;
                    case "Кураторы":
                        if (insertlist[0] == "")
                        {
                            throw new Exception("Не все обязательные поля заполнены(1). Введите все необходимые данные и попробуйте снова.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Кураторы (ФИО)
                                VALUES('{insertlist[0]}')";
                        break;
                    case "Формы_контроля":
                        if (insertlist[0] == "")
                        {
                            throw new Exception("Не все обязательные поля заполнены(1). Введите все необходимые данные и попробуйте снова.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Формы_контроля (Тип)
                                VALUES('{insertlist[0]}')";
                        break;
                    case "Кандидаты_на_исключение":
                        if ((insertlist[0] == "") || (insertlist[2] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены(1,3). Введите все необходимые данные и попробуйте снова.");
                        }
                        if (insertlist[1] != "")
                        {
                            throw new Exception("Вводить ФИО студента не нужно. Введите шифр и программа сама вставит необходимое ФИО.");
                        }
                        sqltempcomm = $"SELECT COUNT(*) FROM Студенты WHERE Студенты_id={int.Parse(insertlist[0])}";
                        commtemp = new MySqlCommand(sqltempcomm, constant.conn);
                        if (commtemp.ExecuteScalar().ToString() == "0")
                        {
                            throw new Exception($"Данный шифр студента недействителен, перепишете изменяемое значение, либо добавьте новое в в таблицу студентов.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Кандидаты_на_исключение (Студенты_id, Причина)
                            VALUES('{int.Parse(insertlist[0])}','{insertlist[2]}')";
                        break;
                    case "Курсовые":
                        if ((insertlist[0] == "") || (insertlist[1] == "") || (insertlist[2] == "") || (insertlist[5] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены(1,2,3,6). Введите все необходимые данные и попробуйте снова.");
                        }
                        sqltempcomm = $"SELECT COUNT(*) FROM Студенты WHERE Студенты_id={int.Parse(insertlist[2])}";
                        commtemp = new MySqlCommand(sqltempcomm, constant.conn);
                        if (commtemp.ExecuteScalar().ToString() == "0")
                        {
                            throw new Exception($"Данный шифр студента недействителен, перепишете изменяемое значение, либо добавьте новое в в таблицу студентов.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Курсовые (Тема, Курс, Студенты_id, Оценки_id, Дисциплины_id)
                                VALUES('{insertlist[0]}','{int.Parse(insertlist[1])}','{int.Parse(insertlist[2])}',(SELECT Оценки_id FROM Оценки WHERE Результат='{insertlist[4]}'),(SELECT Дисциплины_id FROM Дисциплины WHERE Название='{insertlist[5]}'))";
                        break;
                    case "Успеваемость":
                        if ((insertlist[0] == "") || (insertlist[2] == "") || (insertlist[11] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены(1,3,12). Введите все необходимые данные и попробуйте снова.");
                        }
                        sqltempcomm = $"SELECT COUNT(*) FROM Студенты WHERE Студенты_id={int.Parse(insertlist[0])}";
                        commtemp = new MySqlCommand(sqltempcomm, constant.conn);
                        if (commtemp.ExecuteScalar().ToString() == "0")
                        {
                            throw new Exception($"Данный шифр студента недействителен, перепишете изменяемое значение, либо добавьте новое в в таблицу студентов.");
                        }
                        sqltempcomm = $"SELECT COUNT(*) FROM (SELECT Посещаемость_id FROM Посещаемость WHERE Дисциплины_id=(SELECT Дисциплины_id FROM Дисциплины WHERE Название='{insertlist[2]}') AND Студенты_id={int.Parse(insertlist[0])} AND Семестр={int.Parse(insertlist[11])}) subquerry";
                        commtemp = new MySqlCommand(sqltempcomm, constant.conn);
                        if (commtemp.ExecuteScalar().ToString() == "0")
                        {
                            throw new Exception($"Данные этого студента по заданной дисциплине в указанном семестре не найдены. Проверьте введённую информацию.");
                        }
                        sqltempcomm = $"SELECT COUNT(*) FROM (SELECT Учебные_планы_id FROM Учебные_планы WHERE Дисциплины_id=(SELECT Дисциплины_id FROM Дисциплины WHERE Название='{insertlist[2]}') AND Специальности_id=(SELECT Специальности_id FROM Специальности WHERE Специальности_id=(SELECT Специальности_id FROM Группы WHERE Группы_id=(SELECT Группы_id FROM Студенты WHERE Студенты_id={int.Parse(insertlist[0])}))) AND Семестр={int.Parse(insertlist[11])}) subquerry";
                        commtemp = new MySqlCommand(sqltempcomm, constant.conn);
                        if (commtemp.ExecuteScalar().ToString() == "0")
                        {
                            throw new Exception($"Учебный план заданной дисциплине и специальности в указанный семестр не найден. Проверьте введённую информацию.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Успеваемость (Студенты_id, Посещаемость_id, Учебные_планы_id, Оценки_id, Формы_контроля_id)
                                VALUES({int.Parse(insertlist[0])},(SELECT Посещаемость_id FROM Посещаемость WHERE Дисциплины_id=(SELECT Дисциплины_id FROM Дисциплины WHERE Название='{insertlist[2]}') AND Студенты_id={int.Parse(insertlist[0])} AND Семестр={int.Parse(insertlist[11])}),
                                (SELECT Учебные_планы_id FROM Учебные_планы WHERE Дисциплины_id=(SELECT Дисциплины_id FROM Дисциплины WHERE Название='{insertlist[2]}') AND Специальности_id=(SELECT Специальности_id FROM Специальности WHERE Специальности_id=(SELECT Специальности_id FROM Группы WHERE Группы_id=(SELECT Группы_id FROM Студенты WHERE Студенты_id={int.Parse(insertlist[0])}))) AND Семестр={int.Parse(insertlist[11])}),
                                (SELECT Оценки_id FROM Оценки WHERE Результат='{insertlist[9]}'),(SELECT Формы_контроля_id FROM Формы_контроля WHERE Тип='{insertlist[10]}'))";
                        break;
                    case "Академические_задолженности":
                        if (insertlist[1] != "")
                        {
                            throw new Exception("Вводить ФИО студента не нужно. Введите шифр и программа сама вставит необходимое ФИО.");
                        }
                        if ((insertlist[0] == "") || (insertlist[2] == "") || (insertlist[3] == ""))
                        {
                            throw new Exception("Не все обязательные поля заполнены(1,3,4). Введите все необходимые данные и попробуйте снова.");
                        }
                        if (DateTime.Parse(insertlist[3]).Month.ToString().Length == 1)
                        {
                            temp1 = "0";
                        }
                        if (DateTime.Parse(insertlist[3]).Day.ToString().Length == 1)
                        {
                            temp2 = "0";
                        }
                        stemp = DateTime.Parse(insertlist[3]).Year.ToString() + '-' + temp1 + DateTime.Parse(insertlist[3]).Month.ToString() + '-' + temp2 + DateTime.Parse(insertlist[3]).Day.ToString();
                        sqltempcomm = $"SELECT COUNT(*) FROM Студенты WHERE Студенты_id={int.Parse(insertlist[0])}";
                        commtemp = new MySqlCommand(sqltempcomm, constant.conn);
                        if (commtemp.ExecuteScalar().ToString() == "0")
                        {
                            throw new Exception($"Данный шифр студента недействителен, перепишете изменяемое значение, либо добавьте новое в в таблицу студентов.");
                        }
                        sqlinsertcomm = $@"INSERT INTO Академические_задолженности (Студенты_id, Дисциплины_id, Дата_появления, Тип_задолженности, Отправка_на_комиссию)
                                VALUES('{int.Parse(insertlist[0])}',(SELECT Дисциплины_id FROM Дисциплины WHERE Название='{insertlist[2]}'),'{stemp}','{insertlist[4]}','Нет')";
                        break;
                    default:
                        throw new Exception("Таблица для вставки не выбрана, пожалуйста сначала нажмите 'Выбрать таблицу'");
                }
                rtbxoldquerry.Text = rtbxquerry.Text;
                rtbxquerry.Text = sqlinsertcomm;
                MySqlCommand comm = new MySqlCommand(sqlinsertcomm, constant.conn);
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Close();
                SelectQuerry(name, sqlselectcomm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public void expired()
        {
            try
            {
                string sqlexpcomm = $"INSERT INTO Кандидаты_на_исключение (Студенты_id, Причина) SELECT Студенты_id, Тип_задолженности FROM Академические_задолженности WHERE DATEDIFF(CURDATE(),Дата_появления)>{constant.getper()} AND Академические_задолженности.Отправка_на_комиссию='Нет'";
                MySqlCommand comm = new MySqlCommand(sqlexpcomm, constant.conn);
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Close();
                sqlexpcomm = "UPDATE Академические_задолженности SET Отправка_на_комиссию='Да' WHERE DATEDIFF(CURDATE(),Дата_появления)>366 AND Академические_задолженности.Отправка_на_комиссию='Нет'";
                comm = new MySqlCommand(sqlexpcomm, constant.conn);
                reader = comm.ExecuteReader();
                reader.Close();
                sqlexpcomm = "DELETE FROM Кандидаты_на_исключение WHERE Студенты_id NOT IN(SELECT Студенты_id FROM Академические_задолженности) AND Причина IN ('Не сдан экзамен','Не сдан зачёт','Не сдана практика','Не сдана курсовая')";
                comm = new MySqlCommand(sqlexpcomm, constant.conn);
                reader = comm.ExecuteReader();
                reader.Close();
                if ((name == "Кандидаты_на_исключение") || (name == "Академические_задолженности"))
                {
                    SelectQuerry(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        public void Moving(string team)
        {
            try
            {
                string sqlmovecomm = $@"INSERT INTO Академические_задолженности (Студенты_id, Дисциплины_id, Дата_появления, Тип_задолженности, Отправка_на_комиссию) 
                    SELECT Студенты.Студенты_id, Дисциплины.Дисциплины_id, CURDATE(), CONCAT('Не сдан ',Формы_контроля.Тип), 'Нет' FROM Студенты
                    INNER JOIN Посещаемость USING(Студенты_id)
                    INNER JOIN Дисциплины USING(Дисциплины_id)
                    INNER JOIN Успеваемость USING(Посещаемость_id)
                    INNER JOIN Группы USING(Группы_id)
                    INNER JOIN Оценки USING(Оценки_id)
                    INNER JOIN Формы_контроля USING(Формы_контроля_id)
                    WHERE Группы.Номер='{team}' AND Оценки.Результат='2'";
                MySqlCommand comm = new MySqlCommand(sqlmovecomm, constant.conn);
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Close();
                sqlmovecomm = $@"INSERT INTO Академические_задолженности(Студенты_id, Дисциплины_id, Дата_появления, Тип_задолженности, Отправка_на_комиссию)
                    SELECT Студенты.Студенты_id, Курсовые.Дисциплины_id, CURDATE(), 'Не сдана курсовая', 'Нет' FROM Студенты
                    INNER JOIN Группы USING(Группы_id)
                    INNER JOIN Курсовые USING(Студенты_id)
                    INNER JOIN Оценки USING(Оценки_id)
                    WHERE Группы.Номер='{team}' AND Оценки.Результат='2'";
                comm = new MySqlCommand(sqlmovecomm, constant.conn);
                reader = comm.ExecuteReader();
                reader.Close();
                sqlmovecomm = $@"UPDATE Группы
		            SET Курс=Курс+1
		            WHERE Номер='{team}' 
                    AND Курс NOT IN (SELECT Количество_курсов FROM Специальности WHERE Специальности.Специальности_id=Группы.Специальности_id)";
                comm = new MySqlCommand(sqlmovecomm, constant.conn);
                reader = comm.ExecuteReader();
                reader.Close();
                if (name == "Академические_задолженности" || name == "Группы")
                {
                    SelectQuerry(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
