using System;
using System.Collections;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Security.Principal;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace codebar
{
  public class Form1 : Form
  {
        private DialogBox dlg = new DialogBox();
        private string[] barcodes_for_print = new string[500];
        private string[] barcodes_for_db = new string[500];
        private string[] barcodes_repeated = new string[200];
        private int[] barcodes_repeated_indexes = new int[200];
        private MyPrintPreviewDialog newPreview = new MyPrintPreviewDialog();
        //private IContainer components;
        public PrintDocument printDocument1;
        private OleDbConnection oledbConnection;
        private OleDbCommand oleDbCommand;
        private TableLayoutPanel tableLayoutPanel1;
        private int num_copies;
        private int num_repeate_copies;
        private int barcode_type;
        private bool onlyUnique;
        private string barcode_name;
        private string bdpath;
        private string filebdname;
        private float high;
        private float high_default;
        private float fhigh;
        private float horiz_betw_codes;
        private float horiz_betw_codes_default;
        private float vert_betw_codes;
        private float vert_betw_codes_default;
        private float left;
        private float left_default;
        private float top;
        private float top_default;
        private float right;
        private float right_default;
        private float bottom;
        private float bottom_default;
        private int numberPrintedTimes;
        private int counter;
        private bool prnt_uk_repeat;
        private TabControl tabControl;
        private TabPage tabPage_uk;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox tB_bookinfo_uk;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label2;
        private MaskedTextBox mTB_quantity_numbers;
        private Label label3;
        private MaskedTextBox mTB_start_number;
        private Label label4;
        private MaskedTextBox mTB_number_uk;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel3;
        private CheckBox optPreview;
        private Button print_button_uk;
        private TabPage tabPage_ukrepeat;
        private GroupBox groupBox7;
        private TableLayoutPanel tableLayoutPanel14;
        private CheckBox checkBoxPreviewTab_ukp;
        private DataGridView dataGridView_uk;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button button_del_ukp;
        private Button button_delall_ukp;
        private Button print_button_ukp;
        private TabPage tabPage_in;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel6;
        private DataGridView dataGridView_in;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private CheckBox checkBoxPreviewTab1;
        private Button print_button_in;
        private Button button_delall_in;
        private Button button_del_in;
        private TabPage tabPage_inrange;
        private TableLayoutPanel tableLayoutPanel7;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label7;
        private MaskedTextBox maskedTextBox4;
        private Label label6;
        private MaskedTextBox maskedTextBox5;
        private Button print_button_inrange;
        private CheckBox checkBoxPreviewTab2;
        private TabPage tabPage_ti;
        private TableLayoutPanel tableLayoutPanel9;
        private CheckBox checkBoxPrintPriviewJobs;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel12;
        private CheckBox checkBox_print_enumeration;
        private GroupBox groupBox_print_enumeration;
        private TableLayoutPanel tableLayoutPanel10;
        private Button button_del_ti;
        private Button button_delall_ti;
        private DataGridView dataGridView_ti;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private TableLayoutPanel tableLayoutPanel13;
        private CheckBox checkBox_print_range;
        private GroupBox groupBox_print_range;
        private TableLayoutPanel tableLayoutPanel11;
        private MaskedTextBox maskedTextBox6;
        private MaskedTextBox maskedTextBox7;
        private Label label5;
        private Label label8;
        private Button print_button_ti;
        private TabPage tabPage_settings;
        private GroupBox groupBox6;
        private Button btn_default;
        private TextBox tB_high;
        private Label lbl_high;
        private Button btn_save;
        private TextBox tB_vert_betw_rows;
        private TextBox tB_hor_betw_col;
        private TextBox tB_bottom_identure;
        private TextBox tB_right_identure;
        private TextBox tB_left_identure;
        private Label lbl_vert_betw_rows;
        private Label lbl_hor_betw_col;
        private Label lbl_bottom_identure;
        private Label lbl_right_identure;
        private Label lbl_left_identure;
        private TextBox tB_top_identure;
        private Label lbl_top_identure;
        private CheckBox chB_save_db;
        private Label lbl_portret;
        private Label lbl_save_db;
        private CheckBox chB_portret;
        private TabPage tabPage_DIS;
        private TableLayoutPanel tableLayoutPanel_DIS;
        private Button print_button_DIS;
        private CheckBox checkBox_DIS;
        private GroupBox groupBox_DIS;
        private TableLayoutPanel tableLayoutPanel16;
        private Label label9;
        private Label label10;
        private MaskedTextBox maskedTextBox1_DIS;
        private MaskedTextBox maskedTextBox2_DIS;
        private TabPage tabPage_il;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel15;
        private DataGridView dataGridView_il;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private CheckBox checkBoxPreviewTab_il;
        private Button print_button_il;
        private Button button_delall_il;
        private Button button_del_il;
        private Label lbl_debug;
        private CheckBox chB_debug;
        private string id_user;


    public Form1()
    {
            InitializeComponent();
            DialogBox dialogBox = new DialogBox();
            //bdpath = "..\\bd";
            bdpath = "";
            filebdname = "lib_codebars.mdb";
            //oledbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + bdpath + "\\" + filebdname;
            oledbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + bdpath + filebdname;
            check_DB();
            fhigh = Properties.Settingss.Default.high;
            high = fhigh * 11.811f;
            left = Properties.Settingss.Default.left_identure * 11.811f;
            top = Properties.Settingss.Default.top_identure * 11.811f;
            right = Properties.Settingss.Default.right_identure * 11.811f;
            bottom = Properties.Settingss.Default.bottom_identure * 11.811f;
            horiz_betw_codes = Properties.Settingss.Default.hor_betw_col * 11.811f;
            vert_betw_codes = Properties.Settingss.Default.vert_betw_rows * 11.811f;
            chB_portret.Checked = true;
            chB_save_db.Checked = true;
            chB_debug.Checked = false;
            // Значения по умолчанию
            high_default = 15;
            horiz_betw_codes_default = 7;
            vert_betw_codes_default = 10;
            left_default = 2;
            top_default = 25;
            right_default = 8;
            bottom_default = 25;
            tB_top_identure.Text = Properties.Settingss.Default.top_identure.ToString();
            tB_left_identure.Text = Properties.Settingss.Default.left_identure.ToString();
            tB_right_identure.Text = Properties.Settingss.Default.right_identure.ToString();
            tB_bottom_identure.Text = Properties.Settingss.Default.bottom_identure.ToString();
            tB_hor_betw_col.Text = Properties.Settingss.Default.hor_betw_col.ToString();
            tB_vert_betw_rows.Text = Properties.Settingss.Default.vert_betw_rows.ToString();
            tB_high.Text = Properties.Settingss.Default.high.ToString();
        }

    /*protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }*/
    #region InitializeComponent
    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.oledbConnection = new System.Data.OleDb.OleDbConnection();
            this.oleDbCommand = new System.Data.OleDb.OleDbCommand();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_uk = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tB_bookinfo_uk = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.mTB_quantity_numbers = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mTB_start_number = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mTB_number_uk = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.optPreview = new System.Windows.Forms.CheckBox();
            this.print_button_uk = new System.Windows.Forms.Button();
            this.tabPage_ukrepeat = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxPreviewTab_ukp = new System.Windows.Forms.CheckBox();
            this.dataGridView_uk = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_del_ukp = new System.Windows.Forms.Button();
            this.button_delall_ukp = new System.Windows.Forms.Button();
            this.print_button_ukp = new System.Windows.Forms.Button();
            this.tabPage_in = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_in = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxPreviewTab1 = new System.Windows.Forms.CheckBox();
            this.print_button_in = new System.Windows.Forms.Button();
            this.button_delall_in = new System.Windows.Forms.Button();
            this.button_del_in = new System.Windows.Forms.Button();
            this.tabPage_inrange = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
            this.print_button_inrange = new System.Windows.Forms.Button();
            this.checkBoxPreviewTab2 = new System.Windows.Forms.CheckBox();
            this.tabPage_ti = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxPrintPriviewJobs = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_print_enumeration = new System.Windows.Forms.CheckBox();
            this.groupBox_print_enumeration = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.button_del_ti = new System.Windows.Forms.Button();
            this.button_delall_ti = new System.Windows.Forms.Button();
            this.dataGridView_ti = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_print_range = new System.Windows.Forms.CheckBox();
            this.groupBox_print_range = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.maskedTextBox6 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox7 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.print_button_ti = new System.Windows.Forms.Button();
            this.tabPage_DIS = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_DIS = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_DIS = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.maskedTextBox1_DIS = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2_DIS = new System.Windows.Forms.MaskedTextBox();
            this.print_button_DIS = new System.Windows.Forms.Button();
            this.checkBox_DIS = new System.Windows.Forms.CheckBox();
            this.tabPage_il = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_il = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxPreviewTab_il = new System.Windows.Forms.CheckBox();
            this.print_button_il = new System.Windows.Forms.Button();
            this.button_delall_il = new System.Windows.Forms.Button();
            this.button_del_il = new System.Windows.Forms.Button();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.lbl_debug = new System.Windows.Forms.Label();
            this.chB_debug = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_default = new System.Windows.Forms.Button();
            this.tB_high = new System.Windows.Forms.TextBox();
            this.lbl_high = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.tB_vert_betw_rows = new System.Windows.Forms.TextBox();
            this.tB_hor_betw_col = new System.Windows.Forms.TextBox();
            this.tB_bottom_identure = new System.Windows.Forms.TextBox();
            this.tB_right_identure = new System.Windows.Forms.TextBox();
            this.tB_left_identure = new System.Windows.Forms.TextBox();
            this.lbl_vert_betw_rows = new System.Windows.Forms.Label();
            this.lbl_hor_betw_col = new System.Windows.Forms.Label();
            this.lbl_bottom_identure = new System.Windows.Forms.Label();
            this.lbl_right_identure = new System.Windows.Forms.Label();
            this.lbl_left_identure = new System.Windows.Forms.Label();
            this.tB_top_identure = new System.Windows.Forms.TextBox();
            this.lbl_top_identure = new System.Windows.Forms.Label();
            this.chB_save_db = new System.Windows.Forms.CheckBox();
            this.lbl_portret = new System.Windows.Forms.Label();
            this.lbl_save_db = new System.Windows.Forms.Label();
            this.chB_portret = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_uk.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage_ukrepeat.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_uk)).BeginInit();
            this.tabPage_in.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_in)).BeginInit();
            this.tabPage_inrange.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tabPage_ti.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.groupBox_print_enumeration.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ti)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            this.groupBox_print_range.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tabPage_DIS.SuspendLayout();
            this.tableLayoutPanel_DIS.SuspendLayout();
            this.groupBox_DIS.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tabPage_il.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_il)).BeginInit();
            this.tabPage_settings.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // oleDbCommand
            // 
            this.oleDbCommand.Connection = this.oledbConnection;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(956, 350);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_uk);
            this.tabControl.Controls.Add(this.tabPage_ukrepeat);
            this.tabControl.Controls.Add(this.tabPage_in);
            this.tabControl.Controls.Add(this.tabPage_inrange);
            this.tabControl.Controls.Add(this.tabPage_ti);
            this.tabControl.Controls.Add(this.tabPage_DIS);
            this.tabControl.Controls.Add(this.tabPage_il);
            this.tabControl.Controls.Add(this.tabPage_settings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(4, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(948, 342);
            this.tabControl.TabIndex = 3;
            // 
            // tabPage_uk
            // 
            this.tabPage_uk.Controls.Add(this.tableLayoutPanel2);
            this.tabPage_uk.Location = new System.Drawing.Point(4, 25);
            this.tabPage_uk.Name = "tabPage_uk";
            this.tabPage_uk.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_uk.Size = new System.Drawing.Size(940, 313);
            this.tabPage_uk.TabIndex = 0;
            this.tabPage_uk.Text = "Учетная карточка";
            this.tabPage_uk.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(934, 307);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(928, 237);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные о партии книг";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tB_bookinfo_uk, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.63768F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.36232F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(922, 216);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // tB_bookinfo_uk
            // 
            this.tB_bookinfo_uk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tB_bookinfo_uk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_bookinfo_uk.Location = new System.Drawing.Point(3, 26);
            this.tB_bookinfo_uk.Multiline = true;
            this.tB_bookinfo_uk.Name = "tB_bookinfo_uk";
            this.tB_bookinfo_uk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_bookinfo_uk.Size = new System.Drawing.Size(916, 64);
            this.tB_bookinfo_uk.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.21614F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.78386F));
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.mTB_quantity_numbers, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.mTB_start_number, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.mTB_number_uk, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 96);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(916, 117);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(682, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Номер учетной карточки";
            // 
            // mTB_quantity_numbers
            // 
            this.mTB_quantity_numbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTB_quantity_numbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mTB_quantity_numbers.Location = new System.Drawing.Point(691, 83);
            this.mTB_quantity_numbers.Mask = "00000";
            this.mTB_quantity_numbers.Name = "mTB_quantity_numbers";
            this.mTB_quantity_numbers.Size = new System.Drawing.Size(222, 22);
            this.mTB_quantity_numbers.TabIndex = 2;
            this.mTB_quantity_numbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(682, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Начальный порядковый номер";
            // 
            // mTB_start_number
            // 
            this.mTB_start_number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTB_start_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mTB_start_number.Location = new System.Drawing.Point(691, 43);
            this.mTB_start_number.Mask = "00000";
            this.mTB_start_number.Name = "mTB_start_number";
            this.mTB_start_number.Size = new System.Drawing.Size(222, 22);
            this.mTB_start_number.TabIndex = 1;
            this.mTB_start_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(682, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Количество экземпляров ";
            // 
            // mTB_number_uk
            // 
            this.mTB_number_uk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTB_number_uk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mTB_number_uk.Location = new System.Drawing.Point(691, 3);
            this.mTB_number_uk.Mask = "0000";
            this.mTB_number_uk.Name = "mTB_number_uk";
            this.mTB_number_uk.Size = new System.Drawing.Size(222, 22);
            this.mTB_number_uk.TabIndex = 0;
            this.mTB_number_uk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Автор и название книги";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel3.Controls.Add(this.optPreview, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.print_button_uk, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 265);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(928, 39);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // optPreview
            // 
            this.optPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.optPreview.AutoSize = true;
            this.optPreview.Location = new System.Drawing.Point(3, 9);
            this.optPreview.Name = "optPreview";
            this.optPreview.Size = new System.Drawing.Size(817, 20);
            this.optPreview.TabIndex = 1;
            this.optPreview.TabStop = false;
            this.optPreview.Text = "Просмотр перед печатью";
            // 
            // print_button_uk
            // 
            this.print_button_uk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.print_button_uk.Location = new System.Drawing.Point(826, 3);
            this.print_button_uk.Name = "print_button_uk";
            this.print_button_uk.Size = new System.Drawing.Size(99, 27);
            this.print_button_uk.TabIndex = 0;
            this.print_button_uk.Text = "Печать";
            this.print_button_uk.Click += new System.EventHandler(this.print_button_uk_Click);
            // 
            // tabPage_ukrepeat
            // 
            this.tabPage_ukrepeat.Controls.Add(this.groupBox7);
            this.tabPage_ukrepeat.Location = new System.Drawing.Point(4, 25);
            this.tabPage_ukrepeat.Name = "tabPage_ukrepeat";
            this.tabPage_ukrepeat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ukrepeat.Size = new System.Drawing.Size(940, 313);
            this.tabPage_ukrepeat.TabIndex = 5;
            this.tabPage_ukrepeat.Text = "УК повтор";
            this.tabPage_ukrepeat.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tableLayoutPanel14);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(934, 307);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Печать повторных учетных карточек";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 3;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.1405F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.8595F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tableLayoutPanel14.Controls.Add(this.checkBoxPreviewTab_ukp, 0, 4);
            this.tableLayoutPanel14.Controls.Add(this.dataGridView_uk, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.button_del_ukp, 2, 0);
            this.tableLayoutPanel14.Controls.Add(this.button_delall_ukp, 2, 1);
            this.tableLayoutPanel14.Controls.Add(this.print_button_ukp, 2, 3);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 5;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(928, 286);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // checkBoxPreviewTab_ukp
            // 
            this.checkBoxPreviewTab_ukp.AutoSize = true;
            this.tableLayoutPanel14.SetColumnSpan(this.checkBoxPreviewTab_ukp, 2);
            this.checkBoxPreviewTab_ukp.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBoxPreviewTab_ukp.Location = new System.Drawing.Point(731, 256);
            this.checkBoxPreviewTab_ukp.Name = "checkBoxPreviewTab_ukp";
            this.checkBoxPreviewTab_ukp.Size = new System.Drawing.Size(194, 27);
            this.checkBoxPreviewTab_ukp.TabIndex = 8;
            this.checkBoxPreviewTab_ukp.Text = "Просмотр перед печатью";
            // 
            // dataGridView_uk
            // 
            this.dataGridView_uk.AllowUserToResizeColumns = false;
            this.dataGridView_uk.AllowUserToResizeRows = false;
            this.dataGridView_uk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_uk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView_uk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_uk.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_uk.Name = "dataGridView_uk";
            this.dataGridView_uk.RowHeadersVisible = false;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridView_uk.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tableLayoutPanel14.SetRowSpan(this.dataGridView_uk, 5);
            this.dataGridView_uk.RowTemplate.DefaultCellStyle.Format = "N0";
            this.dataGridView_uk.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dataGridView_uk.RowTemplate.Height = 20;
            this.dataGridView_uk.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_uk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_uk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_uk.Size = new System.Drawing.Size(520, 280);
            this.dataGridView_uk.TabIndex = 0;
            this.dataGridView_uk.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_uk_CellClick);
            this.dataGridView_uk.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_uk_CellEndEdit);
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "№";
            this.Column3.MinimumWidth = 15;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 25;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Номер уч. карточки";
            this.Column4.MaxInputLength = 4;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Номер экземпляра";
            this.Column5.MaxInputLength = 4;
            this.Column5.Name = "Column5";
            // 
            // button_del_ukp
            // 
            this.button_del_ukp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_del_ukp.Location = new System.Drawing.Point(722, 10);
            this.button_del_ukp.Name = "button_del_ukp";
            this.button_del_ukp.Size = new System.Drawing.Size(102, 30);
            this.button_del_ukp.TabIndex = 5;
            this.button_del_ukp.Text = "Удалить";
            this.button_del_ukp.Click += new System.EventHandler(this.button_del_ukp_Click);
            // 
            // button_delall_ukp
            // 
            this.button_delall_ukp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_delall_ukp.Location = new System.Drawing.Point(722, 59);
            this.button_delall_ukp.Name = "button_delall_ukp";
            this.button_delall_ukp.Size = new System.Drawing.Size(102, 31);
            this.button_delall_ukp.TabIndex = 6;
            this.button_delall_ukp.Text = "Удалить все";
            this.button_delall_ukp.Click += new System.EventHandler(this.button_delall_ukp_Click);
            // 
            // print_button_ukp
            // 
            this.print_button_ukp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.print_button_ukp.Location = new System.Drawing.Point(722, 220);
            this.print_button_ukp.Name = "print_button_ukp";
            this.print_button_ukp.Size = new System.Drawing.Size(102, 29);
            this.print_button_ukp.TabIndex = 7;
            this.print_button_ukp.Text = "Печать";
            this.print_button_ukp.Click += new System.EventHandler(this.print_button_ukp_Click);
            // 
            // tabPage_in
            // 
            this.tabPage_in.Controls.Add(this.groupBox2);
            this.tabPage_in.Location = new System.Drawing.Point(4, 25);
            this.tabPage_in.Name = "tabPage_in";
            this.tabPage_in.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_in.Size = new System.Drawing.Size(940, 313);
            this.tabPage_in.TabIndex = 1;
            this.tabPage_in.Text = "Инвентарный номер";
            this.tabPage_in.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(934, 307);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Введите инвентарные номера в столбец";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.14F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.86F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tableLayoutPanel6.Controls.Add(this.dataGridView_in, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.checkBoxPreviewTab1, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.print_button_in, 2, 3);
            this.tableLayoutPanel6.Controls.Add(this.button_delall_in, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.button_del_in, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 5;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(928, 286);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // dataGridView_in
            // 
            this.dataGridView_in.AllowUserToResizeColumns = false;
            this.dataGridView_in.AllowUserToResizeRows = false;
            this.dataGridView_in.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_in.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView_in.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_in.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_in.Name = "dataGridView_in";
            this.dataGridView_in.RowHeadersVisible = false;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("ru-RU");
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridView_in.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.tableLayoutPanel6.SetRowSpan(this.dataGridView_in, 5);
            this.dataGridView_in.RowTemplate.DefaultCellStyle.Format = "N0";
            this.dataGridView_in.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("ru-RU");
            this.dataGridView_in.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dataGridView_in.RowTemplate.Height = 20;
            this.dataGridView_in.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_in.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_in.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_in.Size = new System.Drawing.Size(520, 280);
            this.dataGridView_in.TabIndex = 0;
            this.dataGridView_in.Text = "dataGridView1";
            this.dataGridView_in.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_in_CellClick);
            this.dataGridView_in.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_in_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("ru-RU");
            dataGridViewCellStyle5.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.HeaderText = "№";
            this.Column1.MinimumWidth = 15;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 25;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column2.HeaderText = "Инвентарный номер";
            this.Column2.MaxInputLength = 11;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // checkBoxPreviewTab1
            // 
            this.checkBoxPreviewTab1.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.checkBoxPreviewTab1, 2);
            this.checkBoxPreviewTab1.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBoxPreviewTab1.Location = new System.Drawing.Point(731, 256);
            this.checkBoxPreviewTab1.Name = "checkBoxPreviewTab1";
            this.checkBoxPreviewTab1.Size = new System.Drawing.Size(194, 27);
            this.checkBoxPreviewTab1.TabIndex = 2;
            this.checkBoxPreviewTab1.Text = "Просмотр перед печатью";
            // 
            // print_button_in
            // 
            this.print_button_in.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.print_button_in.Location = new System.Drawing.Point(722, 220);
            this.print_button_in.Name = "print_button_in";
            this.print_button_in.Size = new System.Drawing.Size(102, 29);
            this.print_button_in.TabIndex = 1;
            this.print_button_in.Text = "Печать";
            this.print_button_in.Click += new System.EventHandler(this.print_button_in_Click);
            // 
            // button_delall_in
            // 
            this.button_delall_in.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_delall_in.Location = new System.Drawing.Point(722, 59);
            this.button_delall_in.Name = "button_delall_in";
            this.button_delall_in.Size = new System.Drawing.Size(102, 31);
            this.button_delall_in.TabIndex = 5;
            this.button_delall_in.Text = "Удалить все";
            this.button_delall_in.Click += new System.EventHandler(this.button_delall_in_Click);
            // 
            // button_del_in
            // 
            this.button_del_in.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_del_in.Location = new System.Drawing.Point(722, 10);
            this.button_del_in.Name = "button_del_in";
            this.button_del_in.Size = new System.Drawing.Size(102, 30);
            this.button_del_in.TabIndex = 4;
            this.button_del_in.Text = "Удалить";
            this.button_del_in.Click += new System.EventHandler(this.button_del_in_Click);
            // 
            // tabPage_inrange
            // 
            this.tabPage_inrange.Controls.Add(this.tableLayoutPanel7);
            this.tabPage_inrange.Location = new System.Drawing.Point(4, 25);
            this.tabPage_inrange.Name = "tabPage_inrange";
            this.tabPage_inrange.Size = new System.Drawing.Size(940, 313);
            this.tabPage_inrange.TabIndex = 2;
            this.tabPage_inrange.Text = "ИН диапазон";
            this.tabPage_inrange.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.2F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.8F));
            this.tableLayoutPanel7.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.print_button_inrange, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.checkBoxPreviewTab2, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(940, 313);
            this.tableLayoutPanel7.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.groupBox3, 2);
            this.groupBox3.Controls.Add(this.tableLayoutPanel8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(934, 262);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Данные о партии книг";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.26966F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.73034F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel8.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.maskedTextBox4, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.maskedTextBox5, 2, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(928, 241);
            this.tableLayoutPanel8.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Начальный порядковый номер";
            // 
            // maskedTextBox4
            // 
            this.maskedTextBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maskedTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox4.Location = new System.Drawing.Point(748, 86);
            this.maskedTextBox4.Mask = "000";
            this.maskedTextBox4.Name = "maskedTextBox4";
            this.maskedTextBox4.Size = new System.Drawing.Size(81, 22);
            this.maskedTextBox4.TabIndex = 1;
            this.maskedTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Количество экземпляров ";
            // 
            // maskedTextBox5
            // 
            this.maskedTextBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maskedTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox5.Location = new System.Drawing.Point(748, 19);
            this.maskedTextBox5.Mask = "00000000000";
            this.maskedTextBox5.Name = "maskedTextBox5";
            this.maskedTextBox5.Size = new System.Drawing.Size(81, 22);
            this.maskedTextBox5.TabIndex = 0;
            this.maskedTextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // print_button_inrange
            // 
            this.print_button_inrange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_button_inrange.Location = new System.Drawing.Point(834, 276);
            this.print_button_inrange.Name = "print_button_inrange";
            this.print_button_inrange.Size = new System.Drawing.Size(103, 29);
            this.print_button_inrange.TabIndex = 0;
            this.print_button_inrange.Text = "Печать";
            this.print_button_inrange.Click += new System.EventHandler(this.print_button_inrange_Click);
            // 
            // checkBoxPreviewTab2
            // 
            this.checkBoxPreviewTab2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxPreviewTab2.AutoSize = true;
            this.checkBoxPreviewTab2.Location = new System.Drawing.Point(3, 280);
            this.checkBoxPreviewTab2.Name = "checkBoxPreviewTab2";
            this.checkBoxPreviewTab2.Size = new System.Drawing.Size(194, 20);
            this.checkBoxPreviewTab2.TabIndex = 5;
            this.checkBoxPreviewTab2.Text = "Просмотр перед печатью";
            // 
            // tabPage_ti
            // 
            this.tabPage_ti.Controls.Add(this.tableLayoutPanel9);
            this.tabPage_ti.Location = new System.Drawing.Point(4, 25);
            this.tabPage_ti.Name = "tabPage_ti";
            this.tabPage_ti.Size = new System.Drawing.Size(940, 313);
            this.tabPage_ti.TabIndex = 3;
            this.tabPage_ti.Text = "Труды института";
            this.tabPage_ti.UseVisualStyleBackColor = true;
            this.tabPage_ti.Enter += new System.EventHandler(this.tabPage4_Enter);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel9.Controls.Add(this.checkBoxPrintPriviewJobs, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.print_button_ti, 1, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(940, 313);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // checkBoxPrintPriviewJobs
            // 
            this.checkBoxPrintPriviewJobs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxPrintPriviewJobs.AutoSize = true;
            this.checkBoxPrintPriviewJobs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxPrintPriviewJobs.Location = new System.Drawing.Point(3, 280);
            this.checkBoxPrintPriviewJobs.Name = "checkBoxPrintPriviewJobs";
            this.checkBoxPrintPriviewJobs.Size = new System.Drawing.Size(194, 20);
            this.checkBoxPrintPriviewJobs.TabIndex = 6;
            this.checkBoxPrintPriviewJobs.Text = "Просмотр перед печатью";
            // 
            // splitContainer1
            // 
            this.tableLayoutPanel9.SetColumnSpan(this.splitContainer1, 2);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel12);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel13);
            this.splitContainer1.Size = new System.Drawing.Size(934, 262);
            this.splitContainer1.SplitterDistance = 547;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.checkBox_print_enumeration, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.groupBox_print_enumeration, 0, 1);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.71429F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.28571F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(547, 262);
            this.tableLayoutPanel12.TabIndex = 1;
            // 
            // checkBox_print_enumeration
            // 
            this.checkBox_print_enumeration.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_print_enumeration.AutoSize = true;
            this.checkBox_print_enumeration.Checked = true;
            this.checkBox_print_enumeration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_print_enumeration.Location = new System.Drawing.Point(3, 4);
            this.checkBox_print_enumeration.Name = "checkBox_print_enumeration";
            this.checkBox_print_enumeration.Size = new System.Drawing.Size(194, 20);
            this.checkBox_print_enumeration.TabIndex = 8;
            this.checkBox_print_enumeration.Text = "Печать по перечислению";
            this.checkBox_print_enumeration.UseVisualStyleBackColor = true;
            this.checkBox_print_enumeration.CheckedChanged += new System.EventHandler(this.checkBox_print_enumeration_CheckedChanged);
            // 
            // groupBox_print_enumeration
            // 
            this.groupBox_print_enumeration.Controls.Add(this.tableLayoutPanel10);
            this.groupBox_print_enumeration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_print_enumeration.Location = new System.Drawing.Point(3, 31);
            this.groupBox_print_enumeration.Name = "groupBox_print_enumeration";
            this.groupBox_print_enumeration.Size = new System.Drawing.Size(541, 228);
            this.groupBox_print_enumeration.TabIndex = 0;
            this.groupBox_print_enumeration.TabStop = false;
            this.groupBox_print_enumeration.Text = "Перечисление";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel10.Controls.Add(this.button_del_ti, 2, 1);
            this.tableLayoutPanel10.Controls.Add(this.button_delall_ti, 2, 2);
            this.tableLayoutPanel10.Controls.Add(this.dataGridView_ti, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 5;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(535, 207);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // button_del_ti
            // 
            this.button_del_ti.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_del_ti.Location = new System.Drawing.Point(435, 29);
            this.button_del_ti.Name = "button_del_ti";
            this.button_del_ti.Size = new System.Drawing.Size(97, 30);
            this.button_del_ti.TabIndex = 5;
            this.button_del_ti.Text = "Удалить";
            this.button_del_ti.Click += new System.EventHandler(this.button_del_ti_Click);
            // 
            // button_delall_ti
            // 
            this.button_delall_ti.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_delall_ti.Location = new System.Drawing.Point(435, 68);
            this.button_delall_ti.Name = "button_delall_ti";
            this.button_delall_ti.Size = new System.Drawing.Size(97, 31);
            this.button_delall_ti.TabIndex = 6;
            this.button_delall_ti.Text = "Удалить все";
            this.button_delall_ti.Click += new System.EventHandler(this.button_delall_ti_Click);
            // 
            // dataGridView_ti
            // 
            this.dataGridView_ti.AllowUserToResizeColumns = false;
            this.dataGridView_ti.AllowUserToResizeRows = false;
            this.dataGridView_ti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_ti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView_ti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ti.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_ti.Name = "dataGridView_ti";
            this.dataGridView_ti.RowHeadersVisible = false;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("ru-RU");
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridView_ti.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.tableLayoutPanel10.SetRowSpan(this.dataGridView_ti, 5);
            this.dataGridView_ti.RowTemplate.DefaultCellStyle.Format = "N0";
            this.dataGridView_ti.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("ru-RU");
            this.dataGridView_ti.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dataGridView_ti.RowTemplate.Height = 20;
            this.dataGridView_ti.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ti.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_ti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_ti.Size = new System.Drawing.Size(396, 201);
            this.dataGridView_ti.TabIndex = 7;
            this.dataGridView_ti.Text = "dataGridView3";
            this.dataGridView_ti.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ti_CellClick);
            this.dataGridView_ti.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ti_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("ru-RU");
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "№";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 15;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 25;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "Номер";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 110;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.checkBox_print_range, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.groupBox_print_range, 0, 1);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 2;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.71429F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.28571F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(383, 262);
            this.tableLayoutPanel13.TabIndex = 1;
            // 
            // checkBox_print_range
            // 
            this.checkBox_print_range.AutoSize = true;
            this.checkBox_print_range.Location = new System.Drawing.Point(3, 3);
            this.checkBox_print_range.Name = "checkBox_print_range";
            this.checkBox_print_range.Size = new System.Drawing.Size(185, 20);
            this.checkBox_print_range.TabIndex = 6;
            this.checkBox_print_range.Text = "Печать через диапазон";
            this.checkBox_print_range.UseVisualStyleBackColor = true;
            this.checkBox_print_range.CheckedChanged += new System.EventHandler(this.checkBox_print_range_CheckedChanged);
            // 
            // groupBox_print_range
            // 
            this.groupBox_print_range.Controls.Add(this.tableLayoutPanel11);
            this.groupBox_print_range.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_print_range.Location = new System.Drawing.Point(3, 31);
            this.groupBox_print_range.Name = "groupBox_print_range";
            this.groupBox_print_range.Size = new System.Drawing.Size(377, 228);
            this.groupBox_print_range.TabIndex = 0;
            this.groupBox_print_range.TabStop = false;
            this.groupBox_print_range.Text = "Диапазон";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel11.Controls.Add(this.maskedTextBox6, 1, 2);
            this.tableLayoutPanel11.Controls.Add(this.maskedTextBox7, 1, 4);
            this.tableLayoutPanel11.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 6;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(371, 207);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // maskedTextBox6
            // 
            this.maskedTextBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.maskedTextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox6.Location = new System.Drawing.Point(287, 75);
            this.maskedTextBox6.Mask = "00000000000";
            this.maskedTextBox6.Name = "maskedTextBox6";
            this.maskedTextBox6.Size = new System.Drawing.Size(81, 22);
            this.maskedTextBox6.TabIndex = 1;
            this.maskedTextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox7
            // 
            this.maskedTextBox7.Dock = System.Windows.Forms.DockStyle.Right;
            this.maskedTextBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox7.Location = new System.Drawing.Point(287, 155);
            this.maskedTextBox7.Mask = "000";
            this.maskedTextBox7.Name = "maskedTextBox7";
            this.maskedTextBox7.Size = new System.Drawing.Size(81, 22);
            this.maskedTextBox7.TabIndex = 2;
            this.maskedTextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.label5, 2);
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(160, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 50);
            this.label5.TabIndex = 4;
            this.label5.Text = "Начальный порядковый номер";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.label8, 2);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(365, 50);
            this.label8.TabIndex = 5;
            this.label8.Text = "Количество экземпляров ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // print_button_ti
            // 
            this.print_button_ti.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_button_ti.Location = new System.Drawing.Point(834, 276);
            this.print_button_ti.Name = "print_button_ti";
            this.print_button_ti.Size = new System.Drawing.Size(103, 29);
            this.print_button_ti.TabIndex = 7;
            this.print_button_ti.Text = "Печать";
            this.print_button_ti.Click += new System.EventHandler(this.print_button_ti_Click);
            // 
            // tabPage_DIS
            // 
            this.tabPage_DIS.Controls.Add(this.tableLayoutPanel_DIS);
            this.tabPage_DIS.Location = new System.Drawing.Point(4, 25);
            this.tabPage_DIS.Name = "tabPage_DIS";
            this.tabPage_DIS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DIS.Size = new System.Drawing.Size(940, 313);
            this.tabPage_DIS.TabIndex = 7;
            this.tabPage_DIS.Text = "Диссертации";
            this.tabPage_DIS.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_DIS
            // 
            this.tableLayoutPanel_DIS.ColumnCount = 2;
            this.tableLayoutPanel_DIS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.2F));
            this.tableLayoutPanel_DIS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.8F));
            this.tableLayoutPanel_DIS.Controls.Add(this.groupBox_DIS, 0, 0);
            this.tableLayoutPanel_DIS.Controls.Add(this.print_button_DIS, 1, 1);
            this.tableLayoutPanel_DIS.Controls.Add(this.checkBox_DIS, 0, 1);
            this.tableLayoutPanel_DIS.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_DIS.Name = "tableLayoutPanel_DIS";
            this.tableLayoutPanel_DIS.RowCount = 2;
            this.tableLayoutPanel_DIS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_DIS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_DIS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_DIS.Size = new System.Drawing.Size(750, 294);
            this.tableLayoutPanel_DIS.TabIndex = 0;
            // 
            // groupBox_DIS
            // 
            this.tableLayoutPanel_DIS.SetColumnSpan(this.groupBox_DIS, 2);
            this.groupBox_DIS.Controls.Add(this.tableLayoutPanel16);
            this.groupBox_DIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_DIS.Location = new System.Drawing.Point(3, 3);
            this.groupBox_DIS.Name = "groupBox_DIS";
            this.groupBox_DIS.Size = new System.Drawing.Size(744, 243);
            this.groupBox_DIS.TabIndex = 8;
            this.groupBox_DIS.TabStop = false;
            this.groupBox_DIS.Text = "Диссертации";
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 3;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.27F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.73F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel16.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel16.Controls.Add(this.maskedTextBox1_DIS, 2, 0);
            this.tableLayoutPanel16.Controls.Add(this.maskedTextBox2_DIS, 2, 1);
            this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 3;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.56F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(738, 222);
            this.tableLayoutPanel16.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Начальный порядковый номер";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Количество экземпляров ";
            // 
            // maskedTextBox1_DIS
            // 
            this.maskedTextBox1_DIS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maskedTextBox1_DIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox1_DIS.Location = new System.Drawing.Point(558, 14);
            this.maskedTextBox1_DIS.Mask = "00000000000";
            this.maskedTextBox1_DIS.Name = "maskedTextBox1_DIS";
            this.maskedTextBox1_DIS.Size = new System.Drawing.Size(81, 22);
            this.maskedTextBox1_DIS.TabIndex = 6;
            this.maskedTextBox1_DIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox2_DIS
            // 
            this.maskedTextBox2_DIS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maskedTextBox2_DIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox2_DIS.Location = new System.Drawing.Point(558, 72);
            this.maskedTextBox2_DIS.Mask = "000";
            this.maskedTextBox2_DIS.Name = "maskedTextBox2_DIS";
            this.maskedTextBox2_DIS.Size = new System.Drawing.Size(81, 22);
            this.maskedTextBox2_DIS.TabIndex = 7;
            this.maskedTextBox2_DIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // print_button_DIS
            // 
            this.print_button_DIS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_button_DIS.Location = new System.Drawing.Point(644, 257);
            this.print_button_DIS.Name = "print_button_DIS";
            this.print_button_DIS.Size = new System.Drawing.Size(103, 29);
            this.print_button_DIS.TabIndex = 7;
            this.print_button_DIS.Text = "Печать";
            this.print_button_DIS.Click += new System.EventHandler(this.print_button_DIS_Click);
            // 
            // checkBox_DIS
            // 
            this.checkBox_DIS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_DIS.AutoSize = true;
            this.checkBox_DIS.Location = new System.Drawing.Point(3, 261);
            this.checkBox_DIS.Name = "checkBox_DIS";
            this.checkBox_DIS.Size = new System.Drawing.Size(194, 20);
            this.checkBox_DIS.TabIndex = 6;
            this.checkBox_DIS.Text = "Просмотр перед печатью";
            // 
            // tabPage_il
            // 
            this.tabPage_il.Controls.Add(this.groupBox4);
            this.tabPage_il.Location = new System.Drawing.Point(4, 25);
            this.tabPage_il.Name = "tabPage_il";
            this.tabPage_il.Size = new System.Drawing.Size(940, 313);
            this.tabPage_il.TabIndex = 8;
            this.tabPage_il.Text = "Иностранная литература";
            this.tabPage_il.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel15);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(940, 313);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Введите инвентарные номера в столбец";
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.14F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.86F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tableLayoutPanel15.Controls.Add(this.dataGridView_il, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.checkBoxPreviewTab_il, 1, 4);
            this.tableLayoutPanel15.Controls.Add(this.print_button_il, 2, 3);
            this.tableLayoutPanel15.Controls.Add(this.button_delall_il, 2, 1);
            this.tableLayoutPanel15.Controls.Add(this.button_del_il, 2, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 5;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(934, 292);
            this.tableLayoutPanel15.TabIndex = 6;
            // 
            // dataGridView_il
            // 
            this.dataGridView_il.AllowUserToResizeColumns = false;
            this.dataGridView_il.AllowUserToResizeRows = false;
            this.dataGridView_il.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_il.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView_il.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_il.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_il.Name = "dataGridView_il";
            this.dataGridView_il.RowHeadersVisible = false;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.FormatProvider = new System.Globalization.CultureInfo("ru-RU");
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridView_il.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.tableLayoutPanel15.SetRowSpan(this.dataGridView_il, 5);
            this.dataGridView_il.RowTemplate.DefaultCellStyle.Format = "N0";
            this.dataGridView_il.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("ru-RU");
            this.dataGridView_il.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dataGridView_il.RowTemplate.Height = 20;
            this.dataGridView_il.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_il.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_il.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_il.Size = new System.Drawing.Size(524, 286);
            this.dataGridView_il.TabIndex = 0;
            this.dataGridView_il.Text = "dataGridView1";
            this.dataGridView_il.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_il_CellClick);
            this.dataGridView_il.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_il_CellContentClick);
            this.dataGridView_il.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_il_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("ru-RU");
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 15;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn2.HeaderText = "Инвентарные номера Иностранной литературы";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 11;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // checkBoxPreviewTab_il
            // 
            this.checkBoxPreviewTab_il.AutoSize = true;
            this.tableLayoutPanel15.SetColumnSpan(this.checkBoxPreviewTab_il, 2);
            this.checkBoxPreviewTab_il.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBoxPreviewTab_il.Location = new System.Drawing.Point(737, 262);
            this.checkBoxPreviewTab_il.Name = "checkBoxPreviewTab_il";
            this.checkBoxPreviewTab_il.Size = new System.Drawing.Size(194, 27);
            this.checkBoxPreviewTab_il.TabIndex = 2;
            this.checkBoxPreviewTab_il.Text = "Просмотр перед печатью";
            // 
            // print_button_il
            // 
            this.print_button_il.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.print_button_il.Location = new System.Drawing.Point(728, 226);
            this.print_button_il.Name = "print_button_il";
            this.print_button_il.Size = new System.Drawing.Size(102, 29);
            this.print_button_il.TabIndex = 1;
            this.print_button_il.Text = "Печать";
            this.print_button_il.Click += new System.EventHandler(this.print_button_il_Click);
            // 
            // button_delall_il
            // 
            this.button_delall_il.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_delall_il.Location = new System.Drawing.Point(728, 59);
            this.button_delall_il.Name = "button_delall_il";
            this.button_delall_il.Size = new System.Drawing.Size(102, 31);
            this.button_delall_il.TabIndex = 5;
            this.button_delall_il.Text = "Удалить все";
            this.button_delall_il.Click += new System.EventHandler(this.button_delall_il_Click);
            // 
            // button_del_il
            // 
            this.button_del_il.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_del_il.Location = new System.Drawing.Point(728, 10);
            this.button_del_il.Name = "button_del_il";
            this.button_del_il.Size = new System.Drawing.Size(102, 30);
            this.button_del_il.TabIndex = 4;
            this.button_del_il.Text = "Удалить";
            this.button_del_il.Click += new System.EventHandler(this.button_del_il_Click);
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.Controls.Add(this.lbl_debug);
            this.tabPage_settings.Controls.Add(this.chB_debug);
            this.tabPage_settings.Controls.Add(this.groupBox6);
            this.tabPage_settings.Controls.Add(this.chB_save_db);
            this.tabPage_settings.Controls.Add(this.lbl_portret);
            this.tabPage_settings.Controls.Add(this.lbl_save_db);
            this.tabPage_settings.Controls.Add(this.chB_portret);
            this.tabPage_settings.Location = new System.Drawing.Point(4, 25);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(940, 313);
            this.tabPage_settings.TabIndex = 4;
            this.tabPage_settings.Text = "Настройки";
            this.tabPage_settings.UseVisualStyleBackColor = true;
            // 
            // lbl_debug
            // 
            this.lbl_debug.Location = new System.Drawing.Point(67, 282);
            this.lbl_debug.Name = "lbl_debug";
            this.lbl_debug.Size = new System.Drawing.Size(299, 22);
            this.lbl_debug.TabIndex = 20;
            this.lbl_debug.Text = "Debug";
            this.lbl_debug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chB_debug
            // 
            this.chB_debug.AutoSize = true;
            this.chB_debug.Location = new System.Drawing.Point(33, 287);
            this.chB_debug.Name = "chB_debug";
            this.chB_debug.Size = new System.Drawing.Size(15, 14);
            this.chB_debug.TabIndex = 19;
            this.chB_debug.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_default);
            this.groupBox6.Controls.Add(this.tB_high);
            this.groupBox6.Controls.Add(this.lbl_high);
            this.groupBox6.Controls.Add(this.btn_save);
            this.groupBox6.Controls.Add(this.tB_vert_betw_rows);
            this.groupBox6.Controls.Add(this.tB_hor_betw_col);
            this.groupBox6.Controls.Add(this.tB_bottom_identure);
            this.groupBox6.Controls.Add(this.tB_right_identure);
            this.groupBox6.Controls.Add(this.tB_left_identure);
            this.groupBox6.Controls.Add(this.lbl_vert_betw_rows);
            this.groupBox6.Controls.Add(this.lbl_hor_betw_col);
            this.groupBox6.Controls.Add(this.lbl_bottom_identure);
            this.groupBox6.Controls.Add(this.lbl_right_identure);
            this.groupBox6.Controls.Add(this.lbl_left_identure);
            this.groupBox6.Controls.Add(this.tB_top_identure);
            this.groupBox6.Controls.Add(this.lbl_top_identure);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(934, 234);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Настройки отступов штих-кодов на листе";
            // 
            // btn_default
            // 
            this.btn_default.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_default.Location = new System.Drawing.Point(19, 200);
            this.btn_default.Name = "btn_default";
            this.btn_default.Size = new System.Drawing.Size(183, 24);
            this.btn_default.TabIndex = 19;
            this.btn_default.Text = "Значения по умолчанию";
            this.btn_default.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_default.UseVisualStyleBackColor = true;
            this.btn_default.Click += new System.EventHandler(this.btn_default_Click);
            // 
            // tB_high
            // 
            this.tB_high.Location = new System.Drawing.Point(19, 172);
            this.tB_high.Name = "tB_high";
            this.tB_high.Size = new System.Drawing.Size(39, 22);
            this.tB_high.TabIndex = 14;
            this.tB_high.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_high
            // 
            this.lbl_high.Location = new System.Drawing.Point(64, 172);
            this.lbl_high.Name = "lbl_high";
            this.lbl_high.Size = new System.Drawing.Size(411, 22);
            this.lbl_high.TabIndex = 13;
            this.lbl_high.Text = "Высота штрих-кода";
            this.lbl_high.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_save.Location = new System.Drawing.Point(208, 200);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(94, 24);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Сохранить";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tB_vert_betw_rows
            // 
            this.tB_vert_betw_rows.Location = new System.Drawing.Point(19, 150);
            this.tB_vert_betw_rows.Name = "tB_vert_betw_rows";
            this.tB_vert_betw_rows.Size = new System.Drawing.Size(39, 22);
            this.tB_vert_betw_rows.TabIndex = 11;
            this.tB_vert_betw_rows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tB_hor_betw_col
            // 
            this.tB_hor_betw_col.Location = new System.Drawing.Point(19, 128);
            this.tB_hor_betw_col.Name = "tB_hor_betw_col";
            this.tB_hor_betw_col.Size = new System.Drawing.Size(39, 22);
            this.tB_hor_betw_col.TabIndex = 10;
            this.tB_hor_betw_col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tB_bottom_identure
            // 
            this.tB_bottom_identure.Location = new System.Drawing.Point(19, 106);
            this.tB_bottom_identure.Name = "tB_bottom_identure";
            this.tB_bottom_identure.Size = new System.Drawing.Size(39, 22);
            this.tB_bottom_identure.TabIndex = 9;
            this.tB_bottom_identure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tB_right_identure
            // 
            this.tB_right_identure.Location = new System.Drawing.Point(19, 84);
            this.tB_right_identure.Name = "tB_right_identure";
            this.tB_right_identure.Size = new System.Drawing.Size(39, 22);
            this.tB_right_identure.TabIndex = 8;
            this.tB_right_identure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tB_left_identure
            // 
            this.tB_left_identure.Location = new System.Drawing.Point(19, 62);
            this.tB_left_identure.Name = "tB_left_identure";
            this.tB_left_identure.Size = new System.Drawing.Size(39, 22);
            this.tB_left_identure.TabIndex = 7;
            this.tB_left_identure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_vert_betw_rows
            // 
            this.lbl_vert_betw_rows.Location = new System.Drawing.Point(64, 150);
            this.lbl_vert_betw_rows.Name = "lbl_vert_betw_rows";
            this.lbl_vert_betw_rows.Size = new System.Drawing.Size(411, 22);
            this.lbl_vert_betw_rows.TabIndex = 6;
            this.lbl_vert_betw_rows.Text = "Расстояние между штрих- кодами в столбце, по вертикали";
            this.lbl_vert_betw_rows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_hor_betw_col
            // 
            this.lbl_hor_betw_col.Location = new System.Drawing.Point(64, 128);
            this.lbl_hor_betw_col.Name = "lbl_hor_betw_col";
            this.lbl_hor_betw_col.Size = new System.Drawing.Size(411, 22);
            this.lbl_hor_betw_col.TabIndex = 5;
            this.lbl_hor_betw_col.Text = "Расстояния между штрих- кодами  в строке, по горизонтали";
            this.lbl_hor_betw_col.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_bottom_identure
            // 
            this.lbl_bottom_identure.Location = new System.Drawing.Point(64, 106);
            this.lbl_bottom_identure.Name = "lbl_bottom_identure";
            this.lbl_bottom_identure.Size = new System.Drawing.Size(411, 22);
            this.lbl_bottom_identure.TabIndex = 4;
            this.lbl_bottom_identure.Text = "Отступ снизу от границ печати принтера";
            this.lbl_bottom_identure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_right_identure
            // 
            this.lbl_right_identure.Location = new System.Drawing.Point(64, 84);
            this.lbl_right_identure.Name = "lbl_right_identure";
            this.lbl_right_identure.Size = new System.Drawing.Size(411, 22);
            this.lbl_right_identure.TabIndex = 3;
            this.lbl_right_identure.Text = "Отступ справа от границ печати принтера";
            this.lbl_right_identure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_left_identure
            // 
            this.lbl_left_identure.Location = new System.Drawing.Point(64, 62);
            this.lbl_left_identure.Name = "lbl_left_identure";
            this.lbl_left_identure.Size = new System.Drawing.Size(411, 22);
            this.lbl_left_identure.TabIndex = 2;
            this.lbl_left_identure.Text = "Отступ слева от границ печати принтера";
            this.lbl_left_identure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tB_top_identure
            // 
            this.tB_top_identure.Location = new System.Drawing.Point(19, 40);
            this.tB_top_identure.Name = "tB_top_identure";
            this.tB_top_identure.Size = new System.Drawing.Size(39, 22);
            this.tB_top_identure.TabIndex = 1;
            this.tB_top_identure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_top_identure
            // 
            this.lbl_top_identure.Location = new System.Drawing.Point(64, 40);
            this.lbl_top_identure.Name = "lbl_top_identure";
            this.lbl_top_identure.Size = new System.Drawing.Size(411, 22);
            this.lbl_top_identure.TabIndex = 0;
            this.lbl_top_identure.Text = "Отступ сверху от границ печати принтера";
            this.lbl_top_identure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chB_save_db
            // 
            this.chB_save_db.AutoSize = true;
            this.chB_save_db.Location = new System.Drawing.Point(33, 267);
            this.chB_save_db.Name = "chB_save_db";
            this.chB_save_db.Size = new System.Drawing.Size(15, 14);
            this.chB_save_db.TabIndex = 18;
            this.chB_save_db.UseVisualStyleBackColor = true;
            // 
            // lbl_portret
            // 
            this.lbl_portret.Location = new System.Drawing.Point(67, 240);
            this.lbl_portret.Name = "lbl_portret";
            this.lbl_portret.Size = new System.Drawing.Size(299, 22);
            this.lbl_portret.TabIndex = 15;
            this.lbl_portret.Text = "Ориентация страницы -портретная";
            this.lbl_portret.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_save_db
            // 
            this.lbl_save_db.Location = new System.Drawing.Point(67, 262);
            this.lbl_save_db.Name = "lbl_save_db";
            this.lbl_save_db.Size = new System.Drawing.Size(299, 22);
            this.lbl_save_db.TabIndex = 17;
            this.lbl_save_db.Text = "Сохранять в БД";
            this.lbl_save_db.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chB_portret
            // 
            this.chB_portret.AutoSize = true;
            this.chB_portret.Location = new System.Drawing.Point(33, 245);
            this.chB_portret.Name = "chB_portret";
            this.chB_portret.Size = new System.Drawing.Size(15, 14);
            this.chB_portret.TabIndex = 16;
            this.chB_portret.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 350);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Штрих-коды 5.6   © Буталов Андрей, 2021";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage_uk.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage_ukrepeat.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_uk)).EndInit();
            this.tabPage_in.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_in)).EndInit();
            this.tabPage_inrange.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tabPage_ti.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.groupBox_print_enumeration.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ti)).EndInit();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.groupBox_print_range.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tabPage_DIS.ResumeLayout(false);
            this.tableLayoutPanel_DIS.ResumeLayout(false);
            this.tableLayoutPanel_DIS.PerformLayout();
            this.groupBox_DIS.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tabPage_il.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_il)).EndInit();
            this.tabPage_settings.ResumeLayout(false);
            this.tabPage_settings.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion InitializeComponent
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // ФУНКЦИИ
        #region DB МЕТОДЫ
        // Проверка существования файла БД
        private void check_DB()
        {
            if (File.Exists("lib_codebars.mdb"))
            {
                autoriz();
            }
            else
            {
                MessageBox.Show("Файл БД lib_codebars.mdb отсутствует в папке с программой!");
                Environment.Exit(0);
            }
        }
        // Открыть соединение с БД Access
        private void OpenConnection()
        {
            try
            {
                oledbConnection.Open();
            }
            catch
            {
            }
        }
        // Закрыть соединение с БД Access
        private void CloseConnection()
        {
            try
            {
                oledbConnection.Close();
            }
            catch
            {
            }
        }
        // Авторизация в access
        private void autoriz()
        {
            OpenConnection();
            oleDbCommand.CommandText = "select id from users where user_name = '" + WindowsIdentity.GetCurrent().Name + "'";
            oleDbCommand.CommandTimeout = 20;
            OleDbDataReader oleDbDataReader1 = oleDbCommand.ExecuteReader();

            if (oleDbDataReader1.Read())
            {
                id_user = Convert.ToString(oleDbDataReader1.GetInt32(0));
                oleDbDataReader1.Close();
            }
            else
            {
                oleDbDataReader1.Close();
                oleDbCommand.CommandText = "insert into users (user_name) values ('" + WindowsIdentity.GetCurrent().Name + "')";
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select id from users where id = (select max(id) from user)";
                OleDbDataReader oleDbDataReader2 = oleDbCommand.ExecuteReader();
                oleDbDataReader2.Read();
                id_user = Convert.ToString(oleDbDataReader2.GetInt32(0));
                oleDbDataReader2.Close();
            }
            CloseConnection();
        }
        // Вставить данные в базу, Учетная карточка
        private void insertIntoDatabaseUchCard()
        {
            try
            {
                OpenConnection();
                oleDbCommand.CommandText = "insert into index_cards (author_title, index_card_number, starting_number, quantity_of_copies) values ('" + tB_bookinfo_uk.Text + "'," + stringCorrecting(mTB_number_uk.Text) + "," + stringCorrecting(mTB_start_number.Text) + "," + stringCorrecting(mTB_quantity_numbers.Text) + ")";
                oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "select id from index_cards where id= (select max(id) from index_cards)";
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                oleDbDataReader.Read();
                string @string = Convert.ToString(oleDbDataReader.GetInt32(0));
                oleDbDataReader.Close();
                for (int index = 0; index < num_copies; ++index)
                {
                    oleDbCommand.CommandText = "insert into barcode (codebar, printing_time_date, book_id, user_id) values ('" + barcodes_for_db[index] + "','" + getDateTime() + "'," + @string + "," + id_user + ")";
                    oleDbCommand.ExecuteNonQuery();
                }
                CloseConnection();
            }
            catch
            {
            }
            clear_barcodes_for_db();
            clear_barcodes_repeated();
            num_copies = 0;
        }
        // Сохраняем баркоды в базу
        private void insertIntoDatabase(string[] barcodes_for_db_save)
        {
            //MessageBox.Show("ДО Except - barcodes_for_db.Length: " + barcodes_for_db.Length.ToString());
            //barcodes_for_db = barcodes_for_db.Except(barcodes_repeated).ToArray();
            //MessageBox.Show("ПОСЛЕ Except - barcodes_for_db.Length: " + barcodes_for_db.Length.ToString());
            //removeElementsFromArrayToDBByBarcodesRepeated();
            //MessageBox.Show("insertIntoDatabase - barcodes_for_db_save.Length: " + barcodes_for_db_save.Length.ToString());
            arrayEnumeration("insertIntoDatabase Баркоды на сохранение в базу: ", barcodes_for_db_save);
            if (barcodes_for_db_save.Length != 0)
            {
                OpenConnection();
                for (int index = 0; index < num_copies; ++index)
                {
                    oleDbCommand.CommandText = "insert into barcode (codebar, printing_time_date, book_id, user_id) values (" + barcodes_for_db_save[index] + ",'" + getDateTime() + "',-1," + id_user + ")";
                    try
                    {
                        oleDbCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        int num = (int)MessageBox.Show(ex.ToString());
                    }
                }
                CloseConnection();
            }
            clear_barcodes_for_db();
            clear_barcodes_repeated();
            num_copies = 0;
        }
        #endregion DB МЕТОДЫ
        // Общие методы       
        private void clear_barcodes_for_print()
        {
            Array.Clear(barcodes_for_print, 0, barcodes_for_print.Length);
        }
        private void clear_barcodes_for_db()
        {
            //MessageBox.Show("Array.Clear - barcodes_for_db.Length: " + barcodes_for_db.Length.ToString());
            Array.Clear(barcodes_for_db, 0, barcodes_for_db.Length);
        }
        private void clear_barcodes_repeated()
        {
            Array.Clear(barcodes_repeated, 0, barcodes_repeated.Length);
        }
        private void clear_barcodes_repeated_indexes()
        {
            Array.Clear(barcodes_repeated_indexes, 0, barcodes_repeated_indexes.Length);
        }
        // Удаление элементов из массива для печати, по списку индексов
        private void removeElementsFromArrayToPrintByIndex()
        {
            if (onlyUnique)
            {
                MessageBox.Show("Удаление элементов из массива для печати, по списку индексов");
                //MessageBox.Show("removeElementsFromArrayToPrintByIndex - barcodes_repeated_indexes.Length: " + barcodes_repeated_indexes.Length.ToString());
                //MessageBox.Show("removeElementsFromArrayToPrintByIndex - num_copies: " + num_copies.ToString());
                //arrayEnumeration("Баркоды на печать до удаления: ", barcodes_for_print);
                for (int i = barcodes_repeated_indexes.Length - 1; i >= 0; i--)
                {
                    //MessageBox.Show("removeArrayElementsByIndexs" + i.ToString());
                    if (barcodes_repeated_indexes[i] != 0 || (barcodes_repeated_indexes[i] == 0 && i == 0))
                    {
                        //MessageBox.Show("barcodes_repeated_indexes[" + i.ToString() + "]" + barcodes_repeated_indexes[i].ToString());
                        //MessageBox.Show(" - num_copies: " + num_copies.ToString());
                        barcodes_for_print = barcodes_for_print.Where((source, index) => index != barcodes_repeated_indexes[i]).ToArray();
                        num_copies = num_copies - 1;
                    }
                }
                arrayEnumeration("Баркоды на печать после удаления: ", barcodes_for_print);
                //MessageBox.Show("removeElementsFromArrayToPrintByIndex - barcodes_repeated_indexes.Length: " + barcodes_repeated_indexes.Length.ToString());
                //MessageBox.Show("removeElementsFromArrayToPrintByIndex - num_copies: " + num_copies.ToString());
            }
            clear_barcodes_repeated_indexes();
        }
        // Удаление элементов из массива для BD, с помощью массива содержащего повторные баркоды
        private string[] removeElementsFromArrayToDBByBarcodesRepeated()
        {
            //barcodes_for_db = barcodes_for_db.Except(barcodes_repeated).ToArray();
            //MessageBox.Show("removeElementsFromArrayToDBByBarcodesRepeated - barcodes_repeated.Length: " + barcodes_repeated.Length.ToString());
            //MessageBox.Show("removeElementsFromArrayToDBByBarcodesRepeated - barcodes_for_db.Length: " + barcodes_for_db.Length.ToString());
            arrayEnumeration("Удаление элементов из массива для BD, с помощью массива содержащего повторные баркоды: ", barcodes_repeated);
            string[] barcodes_for_db_save = new string[500];
            //MessageBox.Show("removeElementsFromArrayToDBByBarcodesRepeated - barcodes_for_db_save.Length: " + barcodes_for_db_save.Length.ToString());
            if (onlyUnique)
            {
                barcodes_for_db_save = barcodes_for_db.Except(barcodes_repeated).ToArray();
                if (chB_debug.Checked)
                {
                    MessageBox.Show("removeElementsFromArrayToDBByBarcodesRepeated" + onlyUnique);
                }
            }
            else
            {
                barcodes_for_db_save = barcodes_for_db;
                if (chB_debug.Checked)
                {
                    MessageBox.Show("removeElementsFromArrayToDBByBarcodesRepeated" + onlyUnique);
                }
            }
            arrayEnumeration("Удаление баркодов из массива на сохранение в DB barcodes_for_db_save: ", barcodes_for_db_save);
            return barcodes_for_db_save;
        }
        // перебор значений массива
        private void arrayEnumeration(string title, string[] arr)
        {
            string stroka = title;
            foreach (string n in arr)
            {
                if (n != null)
                {
                    stroka = stroka + n.ToString() + "\n";
                }
            }
            if (chB_debug.Checked)
            {
                MessageBox.Show(stroka);
            }
        }
        // Получение индексов повторяющихся баркодов из массива для DB
        private void checkIndexRemoveDataNumbers()
        {
            for (int i = 0; i < barcodes_repeated.Length && barcodes_repeated[i] != null; i++)
            {
                barcodes_repeated_indexes[i] = Array.IndexOf(barcodes_for_db, barcodes_repeated[i]);
            }
            //removeElementsFromArrayToPrintByIndex();
        }
        // Текущая дата
        private DateTime getDateTime()
        {
            return DateTime.Now;
        }
        // Показать превью
        private void showPreview()
        {
            newPreview = new MyPrintPreviewDialog();
            newPreview.Document = printDocument1;
            int num = (int)newPreview.ShowDialog();
        }
        // Начало печати - проверка повторной печати, сверка с DB
        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            if (numberPrintedTimes == -1)
                return;
            //DialogResult dialogResult = DialogResult.Yes;
            DialogResult dialogResult = DialogResult.None;
            bool flag = false;
            switch (barcode_type)
            {
                case 1:
                    flag = checkRepeatePrintingUchCard();
                    break;
                default:
                    flag = checkRepeatePrinting(barcode_name);
                    break;
            }
            if (flag)
                dialogResult = dlg.ShowDialog();
            //if (dialogResult != DialogResult.Yes)
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
                newPreview.Close();
            }
            if (dialogResult == DialogResult.OK)
            {
                onlyUnique = false;
                if (chB_debug.Checked)
                {
                    MessageBox.Show("Повторные баркоды - печатать все");
                }
            }
            if (dialogResult == DialogResult.Yes)
            {
                onlyUnique = true;
                if (chB_debug.Checked)
                {
                    MessageBox.Show("Повторные баркоды - печатать только уникальные");
                }  
                removeElementsFromArrayToPrintByIndex();

            }
            //dlg.label1.Text = "Некоторые штрих-кОды уже распечатывались.";
        }
        // Конец печати - добавление записи в DB о данном штрих-коде
        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            if (numberPrintedTimes <= 0)
            {
                return;
            }
            switch (barcode_type)
            {
                case 1:
                    if (chB_save_db.Checked && !prnt_uk_repeat)
                    {
                        insertIntoDatabaseUchCard();                     
                    }
                    break;
                default:
                    if (chB_save_db.Checked)
                    {
                        insertIntoDatabase(removeElementsFromArrayToDBByBarcodesRepeated());
                    }
                    break;
            }
        }
        // Печать страницы
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //MessageBox.Show("printDocument1_PrintPage1 - barcodes_for_print.Length: " + barcodes_for_print.Length.ToString());
            if (chB_debug.Checked)
            {
                MessageBox.Show("printDocument1_PrintPage1 - num_copies: " + num_copies.ToString());
            }
            arrayEnumeration("Баркоды на печать: ", barcodes_for_print);
            Font font = new Font("EanBwrP36Tt", fhigh, FontStyle.Regular, GraphicsUnit.Millimeter);
            float num1 = high * 2.75f;
            float x = left;
            float y = top;
            int num2 = 0;
            int num3 = 1;
            float num4 = e.MarginBounds.Height / (float)(high / 3.0 + vert_betw_codes / 3.0);
            float num5 = e.MarginBounds.Width / (float)(num1 / 3.0 + horiz_betw_codes / 3.0);
            e.Graphics.PageUnit = GraphicsUnit.Document;
            while (num2 < (double)num4 && counter < num_copies)
            {
                for (; num3 < num5 && counter < num_copies; ++num3)
                {
                    e.Graphics.DrawString(barcodes_for_print[counter], font, Brushes.Black, x, y);
                    x += num1 + horiz_betw_codes;
                    ++counter;
                }
                y += high + vert_betw_codes;
                x = left;
                ++num2;
                num3 = 1;
            }
            if (counter < num_copies)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                counter = 0;
                ++numberPrintedTimes;
            }
            //clear_barcodes_for_print();
            clear_barcodes_repeated_indexes();
            num_repeate_copies = 0;

            //onlyUnique = false;
            //MessageBox.Show("printDocument1_PrintPage2 - barcodes_for_print.Length: " + barcodes_for_print.Length.ToString());
            //arrayEnumeration("Баркоды на печать: ", barcodes_for_print);
        }
        // Функция убирает пробелы и нижнее подчеркивание из строки
        private string stringCorrecting(string origin)
        {
            char[] chArray = new char[2] { '_', ' ' };
            string str1 = origin.Trim(chArray);
            foreach (char ch in chArray)
            {
                if (str1.IndexOf(ch) != -1)
                {
                    string[] strArray = str1.Split(ch);
                    str1 = string.Empty;
                    foreach (string str2 in strArray)
                    {
                        if (str2 != Convert.ToString(ch))
                            str1 += str2;
                    }
                }
            }
            return str1;
        }
        // Конвертация в символы баркода
        private string convertToSymb(int type, string left, string right, int index)
        {
            string str = null;
            string str_left = left;
            if (type == 1)
            {
                barcodes_for_db[index] = "1" + str_left;
                str = "$!" + str_left[0] + str_left[1] + codeB(str_left[2]) + str_left[3] + codeB(str_left[4]) + codeB(str_left[5]) + '-';
            }
            if (type == 2)
            {
                barcodes_for_db[index] = "2"+ str_left;
                str = "%!" + str_left[0] + str_left[1] + codeB(str_left[2]) + codeB(str_left[3]) + str_left[4] + codeB(str_left[5]) + '-';
            }
            if (type == 3)
            {
                barcodes_for_db[index] = "3" + str_left;
                str = "&!" + str_left[0] + str_left[1] + codeB(str_left[2]) + codeB(str_left[3]) + codeB(str_left[4]) + str_left[5] + '-';
            }
            if (type == 4)
            {
                barcodes_for_db[index] = "4" + str_left;
                str = "'!" + str_left[0] + codeB(str_left[1]) + str_left[2] + str_left[3] + codeB(str_left[4]) + codeB(str_left[5]) + '-';
            }
            if (type == 5)
            {
                barcodes_for_db[index] = "5" + str_left;
                str = "(!" + str_left[0] + codeB(str_left[1]) + codeB(str_left[2]) + str_left[3] + str_left[4] + codeB(str_left[5]) + '-';
            }
            if (chB_debug.Checked)
            {
                MessageBox.Show("type:" + type.ToString() + Environment.NewLine + "left:" + left + Environment.NewLine + "right:" + right + Environment.NewLine + "str:" + str + Environment.NewLine + "index:" + index.ToString());
            }
            string str_right = right;
            string[] strArray1;
            IntPtr index1;
            (strArray1 = barcodes_for_db)[(int)(index1 = (IntPtr)index)] = strArray1[(int)index1] + str_right;
            //(strArray1 = this.printed_barcodes)[(int)(index1 = (IntPtr)index)] = strArray1[Convert.ToInt32(index1)] + str_right;
            //(strArray1 = this.printed_barcodes)[(int)(index1 = (IntPtr)index)] = strArray1[index1] + str_right;
            string @string = Convert.ToString(CalculateChecksum(barcodes_for_db[index]));
            //MessageBox.Show("printed_barcodes:  (" + printed_barcodes[index] + ")");
            string[] strArray2;
            IntPtr index2;
            (strArray2 = barcodes_for_db)[(int)(index2 = (IntPtr)index)] = strArray2[(int)index2] + @string;
            //(strArray2 = this.printed_barcodes)[(int) (index2 = (IntPtr) index)] = strArray2[index2] + @string;
            string c = str_right + @string;

            //MessageBox.Show("index:  (" + index + ") \n str_right: (" + str_right + ") \n barcodes_for_db:  (" + barcodes_for_db[index] + ") \n index1:  (" + index1.ToString() + ") \n @string:  (" + @string + ") \n ");
            return str + codeC(c) + '!';
        }
        // Checksum
        private int CalculateChecksum(string sTemp)
        {
            int num = 0;
            for (int length = sTemp.Length; length >= 1; --length)
            {
                int int32 = Convert.ToInt32(sTemp.Substring(length - 1, 1));
                if (length % 2 == 0)
                    num += int32 * 3;
                else
                    num += int32;
            }
            return (10 - num % 10) % 10;
        }
        // Параметры печати
        private void BarcodePrintingParametres(int numberOfBarcodes, int barcodeType)
        {
            num_copies = numberOfBarcodes;
            barcode_type = barcodeType;
            printDocument1.DefaultPageSettings.Margins = new Margins(Convert.ToInt32(Properties.Settingss.Default.left_identure * 3.9f), Convert.ToInt32(Properties.Settingss.Default.right_identure * 3.9f), Convert.ToInt32(Properties.Settingss.Default.top_identure * 3.9f), Convert.ToInt32(Properties.Settingss.Default.bottom_identure * 3.9f));
            if (chB_portret.Checked)
            {
                printDocument1.DefaultPageSettings.Landscape = false;
                //allX = 2480.31f;
            }
            else
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                //allX = 3507.867f;
            }
        }
        // Печать штрих кодов
        private void printCurrentTab(bool usePreview)
        {
            if (usePreview)
            {
                numberPrintedTimes = -1;
                showPreview();
            }
            else
            {
                try
                {
                    numberPrintedTimes = 0;
                    printDocument1.Print();
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show("При печати возникли неполадки. Информация не будет внесена в базу данных! \n Описание ошибки: \n" + ex.ToString());
                }
            }
        }
        //
        private char codeB(char c)
        {
            switch (c)
            {
                case '0':
                    return 'A';
                case '1':
                    return 'B';
                case '2':
                    return 'C';
                case '3':
                    return 'D';
                case '4':
                    return 'E';
                case '5':
                    return 'F';
                case '6':
                    return 'G';
                case '7':
                    return 'H';
                case '8':
                    return 'I';
                case '9':
                    return 'J';
                default:
                    return '0';
            }
        }
        //
        private string codeC(string c)
        {
            string str = (string)null;
            for (int index = 0; index < c.Length; ++index)
            {
                switch (c[index])
                {
                    case '0':
                        str += /*(string)*/ (object)'a';
                        break;
                    case '1':
                        str += /*(string)*/ (object)'b';
                        break;
                    case '2':
                        str += /*(string)*/ (object)'c';
                        break;
                    case '3':
                        str += /*(string)*/ (object)'d';
                        break;
                    case '4':
                        str += /*(string)*/ (object)'e';
                        break;
                    case '5':
                        str += /*(string)*/ (object)'f';
                        break;
                    case '6':
                        str += /*(string)*/ (object)'g';
                        break;
                    case '7':
                        str += /*(string)*/ (object)'h';
                        break;
                    case '8':
                        str += /*(string)*/ (object)'i';
                        break;
                    case '9':
                        str += /*(string)*/ (object)'j';
                        break;
                }
            }

            return str;
        }
        // Проверка типа штрих-кода
        /*private int checkBarcodeType(string barcode)
        {
            return Convert.ToInt32(barcode.Substring(0, 1));
        }*/
        //  Проверка повторной печати Учетных карточек
        private bool checkRepeatePrintingUchCard()
        {
            bool flag = false;
            if (!prnt_uk_repeat)
            {
                dlg.textBox1.Text = "Уже распечатанные штрих-коды\r\n";
                ///*      
                //string number_uk;
                OpenConnection();
                oleDbCommand.CommandText = "select distinct starting_number, quantity_of_copies,index_card_number from index_cards where index_card_number=" + stringCorrecting(mTB_number_uk.Text);
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                int index1 = 0;
                int[] numArray1 = new int[100];
                int[] numArray2 = new int[100];
                int[] numArray3 = new int[100];

                while (oleDbDataReader.Read() & index1 < 100)
                {
                    numArray1[index1] = oleDbDataReader.GetInt32(0);
                    numArray2[index1] = oleDbDataReader.GetInt32(1);
                    numArray3[index1] = oleDbDataReader.GetInt32(2);
                    ++index1;
                    flag = true;
                }
                oleDbDataReader.Close();
                CloseConnection();
                //*/
                for (int index2 = 0; index2 <= index1 && flag; ++index2)
                {
                    if (Convert.ToInt32(stringCorrecting(mTB_start_number.Text)) + num_copies >= numArray1[index2] && Convert.ToInt32(stringCorrecting(mTB_start_number.Text)) <= numArray1[index2] + numArray2[index2])
                    {
                        TextBox textBox = dlg.textBox1;
                        string str = textBox.Text + "Для учетной карточки " + numArray3[index2] + " диапазон от " + Convert.ToString(numArray1[index2]) + " до " + Convert.ToString(numArray2[index2] + numArray1[index2] - 1) + "\r\n";
                        textBox.Text = str;
                    }
                }
            }
            else { flag = false; }
            return flag;
        }
        //  Проверка повторной печати штрих-кодов
        private bool checkRepeatePrinting(string what)
        {
            num_repeate_copies = 0;
            //dlg.textBox1.Text = "Уже распечатанные номера штрих-кодов " + what + " (повторяющиеся номера будут удалены из печати и не сохранятся)\r\n";
            dlg.textBox1.Text = "Повторяющиеся штрих-коды " + what + ": \r\n";
            this.oleDbCommand.CommandText = "select distinct codebar from barcode where codebar='" + barcodes_for_db[0] + "' ";
            for (int index = 1; index < num_copies; ++index)
            {
                OleDbCommand oleDbCommand = this.oleDbCommand;
                string str = oleDbCommand.CommandText + "or codebar='" + barcodes_for_db[index] + "' ";
                oleDbCommand.CommandText = str;
            }
            bool flag = false;
            OpenConnection();
            try
            {
                OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                int i = 0;
                while (oleDbDataReader.Read())
                {
                    TextBox textBox = dlg.textBox1;
                    string str = textBox.Text + oleDbDataReader.GetString(0) + "\r\n";
                    barcodes_repeated[i] = oleDbDataReader.GetString(0);
                    i++;
                    num_repeate_copies++;
                    //MessageBox.Show("oleDbDataReader.GetString:  -" + oleDbDataReader.GetString(0));
                    textBox.Text = str;
                    flag = true;
                }
                oleDbDataReader.Close();
                checkIndexRemoveDataNumbers();
            }
            catch (Exception ex)
            {
                flag = true;
                dlg.label1.Text = "Возникла ошибка при выполнении запроса!";
                dlg.textBox1.Text = ex.ToString();
            }
            arrayEnumeration("Баркоды повторные barcodes_repeated: ", barcodes_repeated);
            CloseConnection();
            return flag;
        }
        // Сохранение настроек
        private void SaveSettings(float _top_identure, float _left_identure, float _right_identure, float _bottom_identure, float _hor_betw_col, float _vert_betw_rows, float _high)
        {
            Properties.Settingss.Default.top_identure = _top_identure;
            Properties.Settingss.Default.left_identure = _left_identure;
            Properties.Settingss.Default.right_identure = _right_identure;
            Properties.Settingss.Default.bottom_identure = _bottom_identure;
            Properties.Settingss.Default.hor_betw_col = _hor_betw_col;
            Properties.Settingss.Default.vert_betw_rows = _vert_betw_rows;
            Properties.Settingss.Default.high = _high;
            Properties.Settingss.Default.Save();
            fhigh = _high;
            high = fhigh * 11.811f;
            left = _left_identure * 11.811f;
            top = _top_identure * 11.811f;
            right = _right_identure * 11.811f;
            bottom = _bottom_identure * 11.811f;
            horiz_betw_codes = _hor_betw_col * 11.811f;
            vert_betw_codes = _vert_betw_rows * 11.811f;
        }
        // Закрытие формы
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings(float.Parse(tB_top_identure.Text), float.Parse(tB_left_identure.Text), float.Parse(tB_right_identure.Text), float.Parse(tB_bottom_identure.Text), float.Parse(tB_hor_betw_col.Text), float.Parse(tB_vert_betw_rows.Text), float.Parse(tB_high.Text));
            CloseConnection();
        }
        // Завершение заполнения ячейки в таблице ввода Инвентарных номеров
        private void dataGridView_in_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt64(((DataGridView)sender).SelectedCells[0].Value);
            }
            catch
            {
                ((DataGridView)sender).Rows.Remove(((DataGridView)sender).CurrentRow);
            }
            if ((long)Convert.ToString(((DataGridView)sender).SelectedCells[0].Value).Length > 11L)
            {
                ((DataGridView)sender).Rows.Remove(((DataGridView)sender).CurrentRow);
                int num = (int)MessageBox.Show("Количество символов в строке не должно превышать одиннадцати!");
            }
            else if (e.RowIndex == 0)
            {
                ((DataGridView)sender).CurrentRow.Cells[0].Value = (object)1;
            }
            else
            {
                for (int rowIndex = e.RowIndex; rowIndex < ((DataGridView)sender).RowCount - 1; ++rowIndex)
                    ((DataGridView)sender).Rows[rowIndex].Cells[0].Value = (object)(rowIndex + 1);
            }
        }
        // таблица ввода Инвентарные номера - клик по ячейке
        private void dataGridView_in_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            ((DataGridView)sender).CurrentCell = ((DataGridView)sender).CurrentRow.Cells[1];
        }
        // Завершение заполнения ячейки в таблице ввода Труды института
        private void dataGridView_ti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt64(((DataGridView)sender).SelectedCells[0].Value);
            }
            catch
            {
                ((DataGridView)sender).Rows.Remove(((DataGridView)sender).CurrentRow);
            }
            if ((long)Convert.ToString(((DataGridView)sender).SelectedCells[0].Value).Length > 11L)
            {
                ((DataGridView)sender).Rows.Remove(((DataGridView)sender).CurrentRow);
                int num = (int)MessageBox.Show("Количество символов в строке не должно превышать одиннадцати!");
            }
            else if (e.RowIndex == 0)
            {
                ((DataGridView)sender).CurrentRow.Cells[0].Value = (object)1;
            }
            else
            {
                for (int rowIndex = e.RowIndex; rowIndex < ((DataGridView)sender).RowCount - 1; ++rowIndex)
                    ((DataGridView)sender).Rows[rowIndex].Cells[0].Value = (object)(rowIndex + 1);
            }
        }
        //  таблица ввода Труды института - клик по ячейке
        private void dataGridView_ti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            ((DataGridView)sender).CurrentCell = ((DataGridView)sender).CurrentRow.Cells[1];
        }
        // Завершение заполнения ячейки в таблице ввода Иностранная литература
        private void dataGridView_il_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt64(((DataGridView)sender).SelectedCells[0].Value);
            }
            catch
            {
                ((DataGridView)sender).Rows.Remove(((DataGridView)sender).CurrentRow);
            }
            if ((long)Convert.ToString(((DataGridView)sender).SelectedCells[0].Value).Length > 11L)
            {
                ((DataGridView)sender).Rows.Remove(((DataGridView)sender).CurrentRow);
                int num = (int)MessageBox.Show("Количество символов в строке не должно превышать одиннадцати!");
            }
            else if (e.RowIndex == 0)
            {
                ((DataGridView)sender).CurrentRow.Cells[0].Value = (object)1;
            }
            else
            {
                for (int rowIndex = e.RowIndex; rowIndex < ((DataGridView)sender).RowCount - 1; ++rowIndex)
                    ((DataGridView)sender).Rows[rowIndex].Cells[0].Value = (object)(rowIndex + 1);
            }
        }
        //  таблица ввода Иностранная литература - клик по ячейке
        private void dataGridView_il_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            ((DataGridView)sender).CurrentCell = ((DataGridView)sender).CurrentRow.Cells[1];
        }
        // Завершение заполнения ячейки в таблице ввода Учетная карточка (повтор)
        private void dataGridView_uk_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt64(((DataGridView)sender).SelectedCells[0].Value);
            }
            catch
            {
                ((DataGridView)sender).Rows.Remove(((DataGridView)sender).CurrentRow);
            }
            if ((long)Convert.ToString(((DataGridView)sender).SelectedCells[0].Value).Length > 11L)
            {
                ((DataGridView)sender).Rows.Remove(((DataGridView)sender).CurrentRow);
                int num = (int)MessageBox.Show("Количество символов в строке не должно превышать четырёх!");
            }
            else if (e.RowIndex == 0)
            {
                ((DataGridView)sender).CurrentRow.Cells[0].Value = (object)1;
            }
            else
            {
                for (int rowIndex = e.RowIndex; rowIndex < ((DataGridView)sender).RowCount - 1; ++rowIndex)
                    ((DataGridView)sender).Rows[rowIndex].Cells[0].Value = (object)(rowIndex + 1);
            }
        }
        // таблица ввода Учетная карточка (повтор) - клик по ячейке
        private void dataGridView_uk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            ((DataGridView)sender).CurrentCell = ((DataGridView)sender).CurrentRow.Cells[1];
            //MessageBox.Show("###" + ((DataGridView)sender).CurrentRow.Cells[1] + "###");
        }
        // КНОПКИ
        // кнопка Сохранить, вкладка Настройки
        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveSettings(float.Parse(tB_top_identure.Text), float.Parse(tB_left_identure.Text), float.Parse(tB_right_identure.Text), float.Parse(tB_bottom_identure.Text), float.Parse(tB_hor_betw_col.Text), float.Parse(tB_vert_betw_rows.Text), float.Parse(tB_high.Text));
        }
        // кнопка Значения по умолчанию, вкладка Настройки
        private void btn_default_Click(object sender, EventArgs e)
        {
            SaveSettings(top_default, left_default, right_default, bottom_default, horiz_betw_codes_default, vert_betw_codes_default, high_default);
            tB_top_identure.Text = top_default.ToString();
            tB_left_identure.Text = left_default.ToString();
            tB_right_identure.Text = right_default.ToString();
            tB_bottom_identure.Text = bottom_default.ToString();
            tB_hor_betw_col.Text = horiz_betw_codes_default.ToString();
            tB_vert_betw_rows.Text = vert_betw_codes_default.ToString();
            tB_high.Text = high_default.ToString();
        }
        // кнопка Печать, вкладка Учетная карточка
        private void print_button_uk_Click(object sender, EventArgs e)
        {
            clear_barcodes_for_print();
            barcode_name = "Учетная карточка";
            prnt_uk_repeat = false;
            if (chB_save_db.Checked == false)
            {
                MessageBox.Show("Баркоды не будут сохранены в БД");
            }
            if (tB_bookinfo_uk.Text != "" && mTB_number_uk.Text != "" && mTB_start_number.Text != "" && mTB_quantity_numbers.Text != "")
            {
                if (MessageBox.Show((IWin32Window)this, "Подтвердите печать заданного диапазона", "Печать", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
                if (tB_bookinfo_uk.Text.Length <= (int)byte.MaxValue)
                {
                    num_copies = Convert.ToInt32(stringCorrecting(mTB_quantity_numbers.Text)); // количество экземпляров
                    int int32_1 = Convert.ToInt32(stringCorrecting(mTB_number_uk.Text)); // номер учетной карточки
                    int int32_2 = Convert.ToInt32(stringCorrecting(mTB_start_number.Text)); // начальный порядковый номер
                    if (num_copies != 0)
                    {
                        if (int32_2 + num_copies > 99999)
                        {
                            int num1 = (int)MessageBox.Show("Сумма начального порядкового номера и количества экземпляров не должна превышать 99999");
                        }
                        else if (num_copies > 254)
                        {
                            int num2 = (int)MessageBox.Show("За один раз может быть напечано не более 254 штрих-кодов");
                        }
                        else
                        {
                            for (int index = 0; index < num_copies; ++index)
                            {
                                string right = Convert.ToString(int32_2 + index).PadLeft(5, '0');
                                string left = Convert.ToString(int32_1).PadLeft(6, '0');
                                barcodes_for_print[index] = convertToSymb(1, left, right, index);
                            }
                            BarcodePrintingParametres(num_copies, 1);
                            printCurrentTab(optPreview.Checked);
                        }
                    }
                    else
                    {
                        int num3 = (int)MessageBox.Show("Количество экземпляров не должно быть равно нулю!");
                    }
                }
                else
                {
                    int num = (int)MessageBox.Show("Поле автора и названия книги не должно превышать 255 символов!");
                }
            }
            else
            {
                int num4 = (int)MessageBox.Show("Все поля должны быть заполнены");
            }
        }
        // кнопка Печать, вкладка Учетная карточка (повтор)
        private void print_button_ukp_Click(object sender, EventArgs e)
        {
            clear_barcodes_for_print();
            barcode_name = "Учетная карточка (повтор)";
            prnt_uk_repeat = true;
            int num1 = 0;
            if (this.dataGridView_uk.RowCount == 1)
                return;
            int index1 = 0;
            bool flag = true;
            string text = "Подтвердите печать  " + Convert.ToString(this.dataGridView_uk.RowCount - 1) + "  штрих-кодов(а)";
            //MessageBox.Show("");
            string caption = "Печать";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            if (MessageBox.Show(this, text, caption, buttons, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;
            foreach (DataGridViewRow row in (IEnumerable)this.dataGridView_uk.Rows)
            {
                // проверка заполненности полей числами
                try
                {
                    Convert.ToInt64(row.Cells[1].Value);
                    Convert.ToInt64(row.Cells[2].Value);
                }
                catch
                {
                    int num2 = (int)MessageBox.Show("Должны быть введены только цифры !");
                    flag = false;
                    break;
                }
                //string @string = Convert.ToString(row.Cells[1].Value);
                string str_row_left = Convert.ToString(row.Cells[1].Value);
                string str_row_right = Convert.ToString(row.Cells[2].Value);
                //MessageBox.Show(row.Cells[1].Value.ToString());
                //long num3 = (long)@string.Length;
                long num_row_left = (long)str_row_left.Length;
                long num_row_right = (long)str_row_right.Length;
                //MessageBox.Show(num_row_left.ToString() + "--" + num_row_right.ToString());
                if (dataGridView_uk.Rows.Count > 254)
                {
                    int num2 = (int)MessageBox.Show("Количество распечатываемых за раз штрих-кодов не может быть больше 254");
                    flag = false;
                }
                //else if (num3 <= 4L)
                else if (num_row_left <= 4L && num_row_right <= 4L)
                {
                    //if (@string != "")
                    if (str_row_left != "" && str_row_right != "")
                    {
                        //string str = @string.PadLeft(11, '0');
                        //MessageBox.Show(str);
                        string str_l = str_row_left.PadLeft(6, '0');
                        string str_r = str_row_right.PadLeft(5, '0');
                        //MessageBox.Show(str_l + "--" + str_r);
                        //string right = str.Substring(6);
                        //MessageBox.Show(right);
                        //string left = str.Substring(0, 6);
                        //MessageBox.Show(left);
                        barcodes_for_print[index1] = convertToSymb(1, str_l, str_r, index1);
                        for (int index2 = 0; index2 < index1; ++index2)
                        {
                            if (barcodes_for_print[index2] == barcodes_for_print[index1])
                            {
                                --index1;
                                ++num1;
                                row.Tag = (object)'0';
                            }
                        }
                        ++index1;
                    }
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Количество символов в строке не должно превышать одиннадцати!");
                    flag = false;
                    break;
                }

            }
            if (flag)
            {
                if (num1 != 0)
                {
                    for (int index2 = 0; index2 < dataGridView_uk.Rows.Count; ++index2)
                    {
                        if ((int)Convert.ToChar(dataGridView_uk.Rows[index2].Tag) == 48)
                        {
                            dataGridView_uk.Rows.Remove(dataGridView_uk.Rows[index2]);
                            --index2;
                        }
                    }
                    for (int index2 = 0; index2 < dataGridView_uk.Rows.Count - 1; ++index2)
                        dataGridView_uk.Rows[index2].Cells[0].Value = (object)(index2 + 1);
                    int num2 = (int)MessageBox.Show("Повторящиеся номера в списке были удалены.  (" + num1.ToString() + ")");
                }
                BarcodePrintingParametres(index1, 1);
                printCurrentTab(checkBoxPreviewTab_ukp.Checked);
            }
            if (MessageBox.Show((IWin32Window)this, "Очистить список инвентарных номеров?", "Очистка списка", buttons, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.dataGridView_uk.Rows.Clear();
            prnt_uk_repeat = false;
        }
        // кнопка Печать, вкладка Инвентарный номер
        private void print_button_in_Click(object sender, EventArgs e)
        {
            clear_barcodes_for_print();
            barcode_name = "Инвентарных номеров";
            int num1 = 0;
            if (this.dataGridView_in.RowCount == 1)
                return;
            int index1 = 0;
            bool flag = true;
            string text = "Подтвердите печать  " + Convert.ToString(this.dataGridView_in.RowCount - 1) + "  штрих-кодов(а)";
            string caption = "Печать";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            if (MessageBox.Show((IWin32Window)this, text, caption, buttons, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;
            foreach (DataGridViewRow row in (IEnumerable)this.dataGridView_in.Rows)
            {
                try
                {
                    Convert.ToInt64(row.Cells[1].Value);
                }
                catch
                {
                    int num2 = (int)MessageBox.Show("Должны быть введены только цифры (не больше 11)!");
                    flag = false;
                    break;
                }
                string @string = Convert.ToString(row.Cells[1].Value);
                long num3 = (long)@string.Length;
                if (this.dataGridView_in.Rows.Count > 254)
                {
                    int num2 = (int)MessageBox.Show("Количество распечатываемых за раз штрих-кодов не может быть больше 254");
                    flag = false;
                }
                else if (num3 <= 11L)
                {
                    if (@string != "")
                    {
                        //MessageBox.Show(@string);
                        string str = @string.PadLeft(11, '0'); // заполнение строки слева нулями до 11ти символов
                        //MessageBox.Show(str);
                        string right = str.Substring(6);
                        //MessageBox.Show(right);
                        string left = str.Substring(0, 6);
                        //MessageBox.Show(left);
                        //MessageBox.Show(index1.ToString());
                        barcodes_for_print[index1] = convertToSymb(2, left, right, index1);
                        
                        for (int index2 = 0; index2 < index1; ++index2)
                        {
                            if (barcodes_for_print[index2] == barcodes_for_print[index1])
                            {
                                --index1;
                                ++num1;
                                row.Tag = (object)'0';
                            }
                        }
                        ++index1;
                    }
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Количество символов в строке не должно превышать одиннадцати!");
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                if (num1 != 0)
                {
                    for (int index2 = 0; index2 < this.dataGridView_in.Rows.Count; ++index2)
                    {
                        if ((int)Convert.ToChar(this.dataGridView_in.Rows[index2].Tag) == 48)
                        {
                            this.dataGridView_in.Rows.Remove(this.dataGridView_in.Rows[index2]);
                            --index2;
                        }
                    }
                    for (int index2 = 0; index2 < this.dataGridView_in.Rows.Count - 1; ++index2)
                        this.dataGridView_in.Rows[index2].Cells[0].Value = (object)(index2 + 1);
                    int num2 = (int)MessageBox.Show("Повторящиеся номера в списке были удалены.  (" + num1.ToString() + ")");
                }
                this.BarcodePrintingParametres(index1, 2);
                this.printCurrentTab(this.checkBoxPreviewTab1.Checked);
            }
            if (MessageBox.Show((IWin32Window)this, "Очистить список инвентарных номеров?", "Очистка списка", buttons, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.dataGridView_in.Rows.Clear();
        }
        // кнопка Печать, вкладка ИН диапазон
        private void print_button_inrange_Click(object sender, EventArgs e)
        {
            clear_barcodes_for_print();
            barcode_name = "Инвентарных номеров";
            dlg.textBox1.Text = "Уже распечатанные номера штрих-кодов по инвентарным номерам\r\n";
            string str1 = this.stringCorrecting(this.maskedTextBox4.Text);
            string str2 = this.stringCorrecting(this.maskedTextBox5.Text);
            if (str1 != string.Empty && str2 != string.Empty)
            {
                int int32 = Convert.ToInt32(str1);
                long int64 = Convert.ToInt64(str2);
                if (int32 == 0)
                {
                    int num1 = (int)MessageBox.Show("Введено нулевое количество штрих-кодов!");
                }
                else
                {
                    string text;
                    MessageBoxIcon icon;
                    if (int32 > 80)
                    {
                        text = "Вы действительно хотите напечатать " + str1 + " штрих-кодов(а)?";
                        icon = MessageBoxIcon.Hand;
                    }
                    else
                    {
                        text = "Подтвердите печать заданного диапазона";
                        icon = MessageBoxIcon.Exclamation;
                    }
                    string caption = "Печать";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    if (MessageBox.Show((IWin32Window)this, text, caption, buttons, icon) != DialogResult.Yes)
                        return;
                    if ((long)int32 + int64 - 1L > 99999999999L)
                    {
                        int num2 = (int)MessageBox.Show("Сумма начального порядкового номера и количества экземпляров не должна превышать 1000 000 000 000");
                    }
                    else if (int32 > 254)
                    {
                        int num3 = (int)MessageBox.Show("Количество распечатываемых штрих-кодов за один раз не может быть больше 254!");
                    }
                    else
                    {
                        for (int index = 0; index < int32; ++index)
                        {
                            string str3 = Convert.ToString(int64 + (long)index).PadLeft(11, '0');
                            string right = str3.Substring(6);
                            string left = str3.Substring(0, 6);
                            barcodes_for_print[index] = convertToSymb(2, left, right, index);
                            if (chB_debug.Checked)
                            {
                                MessageBox.Show("str3.  (" + str3 + ") \n right.  (" + right + ") \n left.  (" + left + ") \n barcodes_for_print[index].  (" + this.barcodes_for_print[index].ToString() + ")");
                            }
                        }
                        BarcodePrintingParametres(int32, 2);
                        printCurrentTab(checkBoxPreviewTab2.Checked);
                    }
                }
            }
            else
            {
                int num = (int)MessageBox.Show("Все поля должны быть заполнены");
            }
        }
        // кнопка Печать, вкладка Труды института
        private void print_button_ti_Click(object sender, EventArgs e)
        {
            clear_barcodes_for_print();
            barcode_name = "Трудов института";
            if (this.checkBox_print_enumeration.Checked)
            {
                int num1 = 0;
                if (this.dataGridView_ti.RowCount != 1)
                {
                    int index1 = 0;
                    bool flag = true;
                    string text = "Подтвердите печать  " + Convert.ToString(this.dataGridView_ti.RowCount - 1) + "  штрих-кодов(а)";
                    string caption = "Печать";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    if (MessageBox.Show((IWin32Window)this, text, caption, buttons, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in (IEnumerable)this.dataGridView_ti.Rows)
                        {
                            try
                            {
                                Convert.ToInt64(row.Cells[1].Value);
                            }
                            catch
                            {
                                int num2 = (int)MessageBox.Show("Должны быть введены только цифры!");
                                flag = false;
                                break;
                            }
                            string @string = Convert.ToString(row.Cells[1].Value);
                            long num3 = (long)@string.Length;
                            if (this.dataGridView_ti.Rows.Count > 254)
                            {
                                int num2 = (int)MessageBox.Show("Количество распечатываемых за раз штрих-кодов не может быть больше 254");
                                flag = false;
                            }
                            else if (num3 <= 11L)
                            {
                                if (@string != "")
                                {
                                    string str = @string.PadLeft(11, '0');
                                    string right = str.Substring(6);
                                    string left = str.Substring(0, 6);
                                    this.barcodes_for_print[index1] = this.convertToSymb(3, left, right, index1);
                                    for (int index2 = 0; index2 < index1; ++index2)
                                    {
                                        if (this.barcodes_for_print[index2] == this.barcodes_for_print[index1])
                                        {
                                            --index1;
                                            ++num1;
                                            row.Tag = (object)'0';
                                        }
                                    }
                                    ++index1;
                                }
                            }
                            else
                            {
                                int num2 = (int)MessageBox.Show("Количество символов в строке не должно превышать одиннадцати!");
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            if (num1 != 0)
                            {
                                for (int index2 = 0; index2 < this.dataGridView_ti.Rows.Count; ++index2)
                                {
                                    if ((int)Convert.ToChar(this.dataGridView_ti.Rows[index2].Tag) == 48)
                                    {
                                        this.dataGridView_in.Rows.Remove(this.dataGridView_ti.Rows[index2]);
                                        --index2;
                                    }
                                }
                                for (int index2 = 0; index2 < this.dataGridView_ti.Rows.Count - 1; ++index2)
                                    this.dataGridView_ti.Rows[index2].Cells[0].Value = (object)(index2 + 1);
                                int num2 = (int)MessageBox.Show("Повторящиеся номера в списке были удалены.  (" + num1.ToString() + ")");
                            }
                            this.BarcodePrintingParametres(index1, 3);
                            this.printCurrentTab(this.checkBoxPrintPriviewJobs.Checked);
                        }
                        if (MessageBox.Show((IWin32Window)this, "Очистить список инвентарных номеров?", "Очистка списка", buttons, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.dataGridView_in.Rows.Clear();
                    }
                }
            }
            if (!checkBox_print_range.Checked)
                return;
            dlg.textBox1.Text = "Уже распечатанные номера штрих-кодов для трудов института\r\n";
            string str1 = stringCorrecting(maskedTextBox6.Text);
            string str2 = stringCorrecting(maskedTextBox7.Text);
            if (str2 != string.Empty && str1 != string.Empty)
            {
                int int32 = Convert.ToInt32(str2);
                long int64 = Convert.ToInt64(str1);
                if (int32 == 0)
                {
                    int num1 = (int)MessageBox.Show("Введено нулевое количество штрих-кодов!");
                }
                else
                {
                    string text;
                    MessageBoxIcon icon;
                    if (int32 > 80)
                    {
                        text = "Вы действительно хотите напечатать " + str2 + " штрих-кодов(а)?";
                        icon = MessageBoxIcon.Hand;
                    }
                    else
                    {
                        text = "Подтвердите печать заданного диапазона";
                        icon = MessageBoxIcon.Exclamation;
                    }
                    string caption = "Печать";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    if (MessageBox.Show(this, text, caption, buttons, icon) != DialogResult.Yes)
                        return;
                    if (int32 + int64 - 1L > 99999999999L)
                    {
                        int num2 = (int)MessageBox.Show("Сумма начального порядкового номера и количества экземпляров не должна превышать 1000 000 000 000");
                    }
                    else if (int32 > 254)
                    {
                        int num3 = (int)MessageBox.Show("Количество распечатываемых штрих-кодов за один раз не может быть больше 254!");
                    }
                    else
                    {
                        for (int index = 0; index < int32; ++index)
                        {
                            string str3 = Convert.ToString(int64 + index).PadLeft(11, '0');
                            string right = str3.Substring(6);
                            string left = str3.Substring(0, 6);
                            barcodes_for_print[index] = convertToSymb(3, left, right, index);
                        }
                        BarcodePrintingParametres(int32, 3);
                        printCurrentTab(checkBoxPrintPriviewJobs.Checked);
                    }
                }
            }
            else
            {
                int num = (int)MessageBox.Show("Все поля должны быть заполнены");
            }
        }
        // Вкладка Труды института - Печать по перечислению
        private void checkBox_print_enumeration_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_print_enumeration.Checked)
                return;
            disableElementsCB2();
        }
        // Вкладка Труды института - Печать через диапазон
        private void checkBox_print_range_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_print_range.Checked)
                return;
            disableElementsCB3();
        }
        // Отключение элементов Печати через диапазон
        private void disableElementsCB2()
        {
            if (!checkBox_print_enumeration.Checked)
                return;
            groupBox_print_enumeration.Enabled = true;
            groupBox_print_range.Enabled = false;
            checkBox_print_range.Checked = false;
        }
        // Отключение элементов Печать по перечислению
        private void disableElementsCB3()
        {
            if (!checkBox_print_range.Checked)
                return;
            groupBox_print_range.Enabled = true;
            groupBox_print_enumeration.Enabled = false;
            checkBox_print_enumeration.Checked = false;
        }
        // кнопка Печать, вкладка Диссертации
        private void print_button_DIS_Click(object sender, EventArgs e)
        {
            clear_barcodes_for_print();
            barcode_name = "Диссертаций";
            dlg.textBox1.Text = "Уже распечатанные номера штрих-кодов по 7777инвентарным номерам\r\n";
            string start_number = stringCorrecting(maskedTextBox1_DIS.Text);
            string sum = stringCorrecting(maskedTextBox2_DIS.Text);
            if (sum != string.Empty && start_number != string.Empty)
            {
                int int32 = Convert.ToInt32(sum);
                long int64 = Convert.ToInt64(start_number);
                if (int32 == 0)
                {
                    int num1 = (int)MessageBox.Show("Введено нулевое количество штрих-кодов!");
                }
                else
                {
                    string text;
                    MessageBoxIcon icon;
                    if (int32 > 80)
                    {
                        text = "Вы действительно хотите напечатать " + sum + " штрих-кодов(а)?";
                        icon = MessageBoxIcon.Hand;
                    }
                    else
                    {
                        text = "Подтвердите печать заданного диапазона";
                        icon = MessageBoxIcon.Exclamation;
                    }
                    string caption = "Печать";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    if (MessageBox.Show(this, text, caption, buttons, icon) != DialogResult.Yes)
                        return;
                    if ((long)int32 + int64 - 1L > 99999999999L)
                    {
                        int num2 = (int)MessageBox.Show("Сумма начального порядкового номера и количества экземпляров не должна превышать 1000 000 000 000");
                    }
                    else if (int32 > 254)
                    {
                        int num3 = (int)MessageBox.Show("Количество распечатываемых штрих-кодов за один раз не может быть больше 254!");
                    }
                    else
                    {
                        for (int index = 0; index < int32; ++index)
                        {
                            string str3 = Convert.ToString(int64 + index).PadLeft(11, '0');
                            string right = str3.Substring(6);
                            string left = str3.Substring(0, 6);
                            barcodes_for_print[index] = convertToSymb(4, left, right, index);
                        }
                        BarcodePrintingParametres(int32, 4);
                        printCurrentTab(checkBox_DIS.Checked);
                    }
                }
            }
            else
            {
                int num = (int)MessageBox.Show("Все поля должны быть заполнены");
            }
        }
        // Удаление строки DataGrid из Инвентарного номера
        private void button_del_in_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell selectedCell in (BaseCollection)this.dataGridView_in.SelectedCells)
            {
                if (selectedCell.RowIndex != this.dataGridView_in.Rows.Count - 1)
                    this.dataGridView_in.Rows.Remove(this.dataGridView_in.Rows[selectedCell.RowIndex]);
            }
            for (int index = 0; index < this.dataGridView_in.RowCount - 1; ++index)
                this.dataGridView_in.Rows[index].Cells[0].Value = (object)(index + 1);
        }
        // Удаление всех строк DataGrid из Инвентарного номера
        private void button_delall_in_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "Очистить список инвентарных номеров?", "Очистка списка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.dataGridView_in.Rows.Clear();
        }
        // Удаление строки DataGrid из Учетной карточки (повтор)
        private void button_del_ukp_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell selectedCell in (BaseCollection)this.dataGridView_uk.SelectedCells)
            {
                if (selectedCell.RowIndex != this.dataGridView_uk.Rows.Count - 1)
                    this.dataGridView_uk.Rows.Remove(this.dataGridView_uk.Rows[selectedCell.RowIndex]);
            }
            for (int index = 0; index < this.dataGridView_uk.RowCount - 1; ++index)
                this.dataGridView_uk.Rows[index].Cells[0].Value = (object)(index + 1);
        }
        // Удаление всех строк DataGrid из Учетной карточки (повтор)
        private void button_delall_ukp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "Очистить список инвентарных номеров?", "Очистка списка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.dataGridView_uk.Rows.Clear();
        }
        // Удаление строки DataGrid из Трудов института
        private void button_del_ti_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell selectedCell in (BaseCollection)this.dataGridView_ti.SelectedCells)
            {
                if (selectedCell.RowIndex != this.dataGridView_ti.Rows.Count - 1)
                    this.dataGridView_ti.Rows.Remove(this.dataGridView_ti.Rows[selectedCell.RowIndex]);
            }
            for (int index = 0; index < this.dataGridView_ti.RowCount - 1; ++index)
                this.dataGridView_ti.Rows[index].Cells[0].Value = (object)(index + 1);
        }
        // Удаление всех строк DataGrid из Трудов института
        private void button_delall_ti_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "Очистить список инвентарных номеров?", "Очистка списка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.dataGridView_ti.Rows.Clear();
        }
        
        // Удаление строки DataGrid из Иностранная литература
        private void button_del_il_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell selectedCell in (BaseCollection)this.dataGridView_il.SelectedCells)
            {
                if (selectedCell.RowIndex != this.dataGridView_il.Rows.Count - 1)
                    this.dataGridView_il.Rows.Remove(this.dataGridView_il.Rows[selectedCell.RowIndex]);
            }
            for (int index = 0; index < this.dataGridView_il.RowCount - 1; ++index)
                this.dataGridView_il.Rows[index].Cells[0].Value = (object)(index + 1);
        }

        // Удаление всех строк DataGrid из Иностранной литературы
        private void button_delall_il_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "Очистить список инвентарных номеров?", "Очистка списка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.dataGridView_il.Rows.Clear();
        }
        //=====================================================================================================================================================================================

        /*private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }*/
        // Enter на вкладке Труды института

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            if (this.checkBox_print_enumeration.Checked)
                this.disableElementsCB2();
            if (!this.checkBox_print_range.Checked)
                return;
            this.disableElementsCB3();
        }
        // кнопка Печать, вкладка Иностранная литература
        private void print_button_il_Click(object sender, EventArgs e)
        {
            clear_barcodes_for_print();
            barcode_name = "Иностранной литературы";
            int num1 = 0;
            if (this.dataGridView_il.RowCount == 1)
                return;
            int index1 = 0;
            bool flag = true;
            string text = "Подтвердите печать  " + Convert.ToString(this.dataGridView_il.RowCount - 1) + "  штрих-кодов(а)";
            string caption = "Печать";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            if (MessageBox.Show((IWin32Window)this, text, caption, buttons, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;
            foreach (DataGridViewRow row in (IEnumerable)this.dataGridView_il.Rows)
            {
                try
                {
                    Convert.ToInt64(row.Cells[1].Value);
                }
                catch
                {
                    int num2 = (int)MessageBox.Show("Должны быть введены только цифры (не больше 11)!");
                    flag = false;
                    break;
                }
                string @string = Convert.ToString(row.Cells[1].Value);
                long num3 = (long)@string.Length;
                if (this.dataGridView_il.Rows.Count > 254)
                {
                    int num2 = (int)MessageBox.Show("Количество распечатываемых за раз штрих-кодов не может быть больше 254");
                    flag = false;
                }
                else if (num3 <= 11L)
                {
                    if (@string != "")
                    {
                        //MessageBox.Show(@string);
                        string str = @string.PadLeft(11, '0'); // заполнение строки слева нулями до 11ти символов
                        //MessageBox.Show(str);
                        string right = str.Substring(6);
                        //MessageBox.Show(right);
                        string left = str.Substring(0, 6);
                        //MessageBox.Show(left);
                        //MessageBox.Show(index1.ToString());
                        barcodes_for_print[index1] = convertToSymb(5, left, right, index1);

                        for (int index2 = 0; index2 < index1; ++index2)
                        {
                            if (barcodes_for_print[index2] == barcodes_for_print[index1])
                            {
                                --index1;
                                ++num1;
                                row.Tag = (object)'0';
                            }
                        }
                        ++index1;
                    }
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Количество символов в строке не должно превышать одиннадцати!");
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                if (num1 != 0)
                {
                    for (int index2 = 0; index2 < this.dataGridView_il.Rows.Count; ++index2)
                    {
                        if ((int)Convert.ToChar(this.dataGridView_il.Rows[index2].Tag) == 48)
                        {
                            this.dataGridView_il.Rows.Remove(this.dataGridView_il.Rows[index2]);
                            --index2;
                        }
                    }
                    for (int index2 = 0; index2 < this.dataGridView_il.Rows.Count - 1; ++index2)
                        this.dataGridView_il.Rows[index2].Cells[0].Value = (object)(index2 + 1);
                    int num2 = (int)MessageBox.Show("Повторящиеся номера в списке были удалены.  (" + num1.ToString() + ")");
                }
                this.BarcodePrintingParametres(index1, 2);
                this.printCurrentTab(this.checkBoxPreviewTab_il.Checked);
            }
            if (MessageBox.Show((IWin32Window)this, "Очистить список инвентарных номеров?", "Очистка списка", buttons, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.dataGridView_il.Rows.Clear();
        }
        // таблица ввода Иностранная литература - клик по ячейке
        private void dataGridView_il_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            ((DataGridView)sender).CurrentCell = ((DataGridView)sender).CurrentRow.Cells[1];
        }
    }
}


