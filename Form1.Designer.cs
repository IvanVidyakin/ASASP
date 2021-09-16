
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автоматизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьСписокНаИсключениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закончитьКурсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимОтладкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставляемыеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnsort = new System.Windows.Forms.Button();
            this.btnex = new System.Windows.Forms.Button();
            this.pnltabs = new System.Windows.Forms.Panel();
            this.btntabs = new System.Windows.Forms.Button();
            this.cbxtabs = new System.Windows.Forms.ComboBox();
            this.lbltabs = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rtbxquerry = new System.Windows.Forms.RichTextBox();
            this.rtbxelem = new System.Windows.Forms.RichTextBox();
            this.btnfind = new System.Windows.Forms.Button();
            this.tbxFind = new System.Windows.Forms.TextBox();
            this.pnlmove = new System.Windows.Forms.Panel();
            this.btnmove = new System.Windows.Forms.Button();
            this.lblmove = new System.Windows.Forms.Label();
            this.tbxmove = new System.Windows.Forms.TextBox();
            this.rtbxoldquerry = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnltabs.SuspendLayout();
            this.pnlmove.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(611, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem,
            this.сменитьТаблицуToolStripMenuItem,
            this.автоматизацияToolStripMenuItem,
            this.режимОтладкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1285, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьЗаписьToolStripMenuItem,
            this.изменитьЗаписьToolStripMenuItem,
            this.удалитьЗаписьToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // добавитьЗаписьToolStripMenuItem
            // 
            this.добавитьЗаписьToolStripMenuItem.Name = "добавитьЗаписьToolStripMenuItem";
            this.добавитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.добавитьЗаписьToolStripMenuItem.Text = "Добавить запись";
            this.добавитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.добавитьЗаписьToolStripMenuItem_Click);
            // 
            // изменитьЗаписьToolStripMenuItem
            // 
            this.изменитьЗаписьToolStripMenuItem.Name = "изменитьЗаписьToolStripMenuItem";
            this.изменитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.изменитьЗаписьToolStripMenuItem.Text = "Изменить запись";
            this.изменитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.изменитьЗаписьToolStripMenuItem_Click);
            // 
            // удалитьЗаписьToolStripMenuItem
            // 
            this.удалитьЗаписьToolStripMenuItem.Name = "удалитьЗаписьToolStripMenuItem";
            this.удалитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.удалитьЗаписьToolStripMenuItem.Text = "Удалить запись";
            this.удалитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.удалитьЗаписьToolStripMenuItem_Click);
            // 
            // сменитьТаблицуToolStripMenuItem
            // 
            this.сменитьТаблицуToolStripMenuItem.Name = "сменитьТаблицуToolStripMenuItem";
            this.сменитьТаблицуToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.сменитьТаблицуToolStripMenuItem.Text = "Выбрать таблицу";
            this.сменитьТаблицуToolStripMenuItem.Click += new System.EventHandler(this.ВыбратьтаблицуToolStripMenuItem_Click);
            // 
            // автоматизацияToolStripMenuItem
            // 
            this.автоматизацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьСписокНаИсключениеToolStripMenuItem,
            this.закончитьКурсToolStripMenuItem});
            this.автоматизацияToolStripMenuItem.Name = "автоматизацияToolStripMenuItem";
            this.автоматизацияToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.автоматизацияToolStripMenuItem.Text = "Автоматизация";
            // 
            // обновитьСписокНаИсключениеToolStripMenuItem
            // 
            this.обновитьСписокНаИсключениеToolStripMenuItem.Name = "обновитьСписокНаИсключениеToolStripMenuItem";
            this.обновитьСписокНаИсключениеToolStripMenuItem.Size = new System.Drawing.Size(323, 26);
            this.обновитьСписокНаИсключениеToolStripMenuItem.Text = "Обновить список на исключение";
            this.обновитьСписокНаИсключениеToolStripMenuItem.Click += new System.EventHandler(this.обновитьСписокНаИсключениеToolStripMenuItem_Click);
            // 
            // закончитьКурсToolStripMenuItem
            // 
            this.закончитьКурсToolStripMenuItem.Name = "закончитьКурсToolStripMenuItem";
            this.закончитьКурсToolStripMenuItem.Size = new System.Drawing.Size(323, 26);
            this.закончитьКурсToolStripMenuItem.Text = "Закончить курс";
            this.закончитьКурсToolStripMenuItem.Click += new System.EventHandler(this.закончитьКурсToolStripMenuItem_Click);
            // 
            // режимОтладкиToolStripMenuItem
            // 
            this.режимОтладкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запросыToolStripMenuItem,
            this.вставляемыеДанныеToolStripMenuItem});
            this.режимОтладкиToolStripMenuItem.Name = "режимОтладкиToolStripMenuItem";
            this.режимОтладкиToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.режимОтладкиToolStripMenuItem.Text = "Режим отладки";
            // 
            // запросыToolStripMenuItem
            // 
            this.запросыToolStripMenuItem.Name = "запросыToolStripMenuItem";
            this.запросыToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.запросыToolStripMenuItem.Text = "Запросы";
            this.запросыToolStripMenuItem.Click += new System.EventHandler(this.запросыToolStripMenuItem_Click);
            // 
            // вставляемыеДанныеToolStripMenuItem
            // 
            this.вставляемыеДанныеToolStripMenuItem.Name = "вставляемыеДанныеToolStripMenuItem";
            this.вставляемыеДанныеToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.вставляемыеДанныеToolStripMenuItem.Text = "Вставляемые данные";
            this.вставляемыеДанныеToolStripMenuItem.Click += new System.EventHandler(this.вставляемыеДанныеToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 129);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1245, 367);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnsort
            // 
            this.btnsort.Location = new System.Drawing.Point(15, 521);
            this.btnsort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsort.Name = "btnsort";
            this.btnsort.Size = new System.Drawing.Size(187, 82);
            this.btnsort.TabIndex = 4;
            this.btnsort.Text = "Отсортировать";
            this.btnsort.UseVisualStyleBackColor = true;
            this.btnsort.Click += new System.EventHandler(this.btnsort_Click);
            // 
            // btnex
            // 
            this.btnex.Location = new System.Drawing.Point(845, 521);
            this.btnex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnex.Name = "btnex";
            this.btnex.Size = new System.Drawing.Size(187, 82);
            this.btnex.TabIndex = 5;
            this.btnex.Text = "Экспорт в excel";
            this.btnex.UseVisualStyleBackColor = true;
            this.btnex.Click += new System.EventHandler(this.btnex_Click);
            // 
            // pnltabs
            // 
            this.pnltabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnltabs.Controls.Add(this.btntabs);
            this.pnltabs.Controls.Add(this.cbxtabs);
            this.pnltabs.Controls.Add(this.lbltabs);
            this.pnltabs.Location = new System.Drawing.Point(453, 39);
            this.pnltabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnltabs.Name = "pnltabs";
            this.pnltabs.Size = new System.Drawing.Size(414, 456);
            this.pnltabs.TabIndex = 6;
            this.pnltabs.Visible = false;
            // 
            // btntabs
            // 
            this.btntabs.Location = new System.Drawing.Point(145, 246);
            this.btntabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntabs.Name = "btntabs";
            this.btntabs.Size = new System.Drawing.Size(95, 23);
            this.btntabs.TabIndex = 2;
            this.btntabs.Text = "Выбрать";
            this.btntabs.UseVisualStyleBackColor = true;
            this.btntabs.Click += new System.EventHandler(this.btntabs_Click);
            // 
            // cbxtabs
            // 
            this.cbxtabs.FormattingEnabled = true;
            this.cbxtabs.Items.AddRange(new object[] {
            "Студенты",
            "Институты",
            "Кафедры",
            "Специальности",
            "Группы",
            "Учебные планы",
            "Дисциплины",
            "Посещаемость",
            "Формы оплаты обучения",
            "Формы обучения",
            "Кураторы",
            "Формы контроля",
            "Кандидаты на исключение",
            "Курсовые",
            "Успеваемость",
            "Академические задолженности"});
            this.cbxtabs.Location = new System.Drawing.Point(101, 178);
            this.cbxtabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxtabs.Name = "cbxtabs";
            this.cbxtabs.Size = new System.Drawing.Size(207, 24);
            this.cbxtabs.TabIndex = 1;
            // 
            // lbltabs
            // 
            this.lbltabs.AutoSize = true;
            this.lbltabs.Location = new System.Drawing.Point(141, 116);
            this.lbltabs.Name = "lbltabs";
            this.lbltabs.Size = new System.Drawing.Size(132, 17);
            this.lbltabs.TabIndex = 0;
            this.lbltabs.Text = "Выберите таблицу";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 608);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(205, 21);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Сортировать по убыванию";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // rtbxquerry
            // 
            this.rtbxquerry.Location = new System.Drawing.Point(528, 500);
            this.rtbxquerry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbxquerry.Name = "rtbxquerry";
            this.rtbxquerry.Size = new System.Drawing.Size(281, 139);
            this.rtbxquerry.TabIndex = 9;
            this.rtbxquerry.Text = "";
            this.rtbxquerry.Visible = false;
            // 
            // rtbxelem
            // 
            this.rtbxelem.Location = new System.Drawing.Point(569, 500);
            this.rtbxelem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbxelem.Name = "rtbxelem";
            this.rtbxelem.Size = new System.Drawing.Size(193, 142);
            this.rtbxelem.TabIndex = 12;
            this.rtbxelem.Text = "";
            this.rtbxelem.Visible = false;
            // 
            // btnfind
            // 
            this.btnfind.Location = new System.Drawing.Point(1037, 521);
            this.btnfind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(205, 82);
            this.btnfind.TabIndex = 13;
            this.btnfind.Text = "Поиск по столбцу";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
            // 
            // tbxFind
            // 
            this.tbxFind.Location = new System.Drawing.Point(1037, 608);
            this.tbxFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxFind.Name = "tbxFind";
            this.tbxFind.Size = new System.Drawing.Size(207, 22);
            this.tbxFind.TabIndex = 14;
            // 
            // pnlmove
            // 
            this.pnlmove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmove.Controls.Add(this.btnmove);
            this.pnlmove.Controls.Add(this.lblmove);
            this.pnlmove.Controls.Add(this.tbxmove);
            this.pnlmove.Location = new System.Drawing.Point(298, 191);
            this.pnlmove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlmove.Name = "pnlmove";
            this.pnlmove.Size = new System.Drawing.Size(714, 118);
            this.pnlmove.TabIndex = 15;
            this.pnlmove.Visible = false;
            // 
            // btnmove
            // 
            this.btnmove.Location = new System.Drawing.Point(307, 78);
            this.btnmove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnmove.Name = "btnmove";
            this.btnmove.Size = new System.Drawing.Size(95, 23);
            this.btnmove.TabIndex = 1;
            this.btnmove.Text = "Перевести";
            this.btnmove.UseVisualStyleBackColor = true;
            this.btnmove.Click += new System.EventHandler(this.btnmove_Click);
            // 
            // lblmove
            // 
            this.lblmove.AutoSize = true;
            this.lblmove.Location = new System.Drawing.Point(137, 17);
            this.lblmove.Name = "lblmove";
            this.lblmove.Size = new System.Drawing.Size(509, 17);
            this.lblmove.TabIndex = 2;
            this.lblmove.Text = "Введите номер группы, которую необходимо перевести на следующий курс";
            // 
            // tbxmove
            // 
            this.tbxmove.Location = new System.Drawing.Point(299, 37);
            this.tbxmove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxmove.Name = "tbxmove";
            this.tbxmove.Size = new System.Drawing.Size(115, 22);
            this.tbxmove.TabIndex = 0;
            // 
            // rtbxoldquerry
            // 
            this.rtbxoldquerry.Location = new System.Drawing.Point(246, 500);
            this.rtbxoldquerry.Name = "rtbxoldquerry";
            this.rtbxoldquerry.Size = new System.Drawing.Size(276, 139);
            this.rtbxoldquerry.TabIndex = 16;
            this.rtbxoldquerry.Text = "";
            this.rtbxoldquerry.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 645);
            this.Controls.Add(this.rtbxoldquerry);
            this.Controls.Add(this.pnlmove);
            this.Controls.Add(this.tbxFind);
            this.Controls.Add(this.btnfind);
            this.Controls.Add(this.rtbxquerry);
            this.Controls.Add(this.rtbxelem);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pnltabs);
            this.Controls.Add(this.btnex);
            this.Controls.Add(this.btnsort);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "ASUUS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnltabs.ResumeLayout(false);
            this.pnltabs.PerformLayout();
            this.pnlmove.ResumeLayout(false);
            this.pnlmove.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьТаблицуToolStripMenuItem;
        private System.Windows.Forms.Button btnsort;
        private System.Windows.Forms.Button btnex;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.ToolStripMenuItem автоматизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьСписокНаИсключениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закончитьКурсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимОтладкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запросыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставляемыеДанныеToolStripMenuItem;
        public System.Windows.Forms.Panel pnltabs;
        public System.Windows.Forms.ComboBox cbxtabs;
        public System.Windows.Forms.Label lbltabs;
        public System.Windows.Forms.Button btntabs;
        public System.Windows.Forms.RichTextBox rtbxquerry;
        public System.Windows.Forms.RichTextBox rtbxelem;
        public System.Windows.Forms.TextBox tbxFind;
        public System.Windows.Forms.Panel pnlmove;
        public System.Windows.Forms.Button btnmove;
        public System.Windows.Forms.Label lblmove;
        public System.Windows.Forms.TextBox tbxmove;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox rtbxoldquerry;
    }
}

