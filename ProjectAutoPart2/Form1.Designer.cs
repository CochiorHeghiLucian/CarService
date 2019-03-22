namespace ProjectAutoPart2
{
    partial class CarService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.clientsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.autoDataSet = new ProjectAutoPart2.AutoDataSet();
            this.DisplayAllClients = new System.Windows.Forms.Button();
            this.NewClient = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.dataSet1 = new ProjectAutoPart2.DataSet1();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientsTableAdapter = new ProjectAutoPart2.DataSet1TableAdapters.ClientsTableAdapter();
            this.clientsTableAdapter1 = new ProjectAutoPart2.AutoDataSetTableAdapters.ClientsTableAdapter();
            this.carListbox = new System.Windows.Forms.ListBox();
            this.comandaListbox = new System.Windows.Forms.ListBox();
            this.clientsLabel = new System.Windows.Forms.Label();
            this.carLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.clientsBindingSource1, "Nume", true));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(53, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(489, 433);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // clientsBindingSource1
            // 
            this.clientsBindingSource1.DataMember = "Clients";
            this.clientsBindingSource1.DataSource = this.autoDataSet;
            // 
            // autoDataSet
            // 
            this.autoDataSet.DataSetName = "AutoDataSet";
            this.autoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DisplayAllClients
            // 
            this.DisplayAllClients.Location = new System.Drawing.Point(53, 521);
            this.DisplayAllClients.Name = "DisplayAllClients";
            this.DisplayAllClients.Size = new System.Drawing.Size(120, 34);
            this.DisplayAllClients.TabIndex = 1;
            this.DisplayAllClients.Text = "Display all clients";
            this.DisplayAllClients.UseVisualStyleBackColor = true;
            this.DisplayAllClients.Click += new System.EventHandler(this.DisplayAllClients_Click);
            // 
            // NewClient
            // 
            this.NewClient.Location = new System.Drawing.Point(179, 521);
            this.NewClient.Name = "NewClient";
            this.NewClient.Size = new System.Drawing.Size(120, 34);
            this.NewClient.TabIndex = 2;
            this.NewClient.Text = "New client";
            this.NewClient.UseVisualStyleBackColor = true;
            this.NewClient.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(179, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.search_input_txt);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(339, 29);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(84, 20);
            this.Search.TabIndex = 4;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.dataSet1;
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // clientsTableAdapter1
            // 
            this.clientsTableAdapter1.ClearBeforeFill = true;
            // 
            // carListbox
            // 
            this.carListbox.FormattingEnabled = true;
            this.carListbox.Location = new System.Drawing.Point(568, 67);
            this.carListbox.Name = "carListbox";
            this.carListbox.Size = new System.Drawing.Size(329, 433);
            this.carListbox.TabIndex = 5;
            // 
            // comandaListbox
            // 
            this.comandaListbox.FormattingEnabled = true;
            this.comandaListbox.Location = new System.Drawing.Point(922, 67);
            this.comandaListbox.Name = "comandaListbox";
            this.comandaListbox.Size = new System.Drawing.Size(308, 433);
            this.comandaListbox.TabIndex = 6;
            // 
            // clientsLabel
            // 
            this.clientsLabel.AutoSize = true;
            this.clientsLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientsLabel.Location = new System.Drawing.Point(48, 38);
            this.clientsLabel.Name = "clientsLabel";
            this.clientsLabel.Size = new System.Drawing.Size(82, 26);
            this.clientsLabel.TabIndex = 8;
            this.clientsLabel.Text = "Clients:";
            // 
            // carLabel
            // 
            this.carLabel.AutoSize = true;
            this.carLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carLabel.Location = new System.Drawing.Point(670, 38);
            this.carLabel.Name = "carLabel";
            this.carLabel.Size = new System.Drawing.Size(58, 26);
            this.carLabel.TabIndex = 9;
            this.carLabel.Text = "Cars:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1008, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Comenzi:";
            // 
            // CarService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 572);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.carLabel);
            this.Controls.Add(this.clientsLabel);
            this.Controls.Add(this.comandaListbox);
            this.Controls.Add(this.carListbox);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NewClient);
            this.Controls.Add(this.DisplayAllClients);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CarService";
            this.Text = "CarService";
            this.Load += new System.EventHandler(this.CarService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button DisplayAllClients;
        private System.Windows.Forms.Button NewClient;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Search;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private DataSet1TableAdapters.ClientsTableAdapter clientsTableAdapter;
        private AutoDataSet autoDataSet;
        private System.Windows.Forms.BindingSource clientsBindingSource1;
        private AutoDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter1;
        private System.Windows.Forms.ListBox carListbox;
        private System.Windows.Forms.ListBox comandaListbox;
        private System.Windows.Forms.Label clientsLabel;
        private System.Windows.Forms.Label carLabel;
        private System.Windows.Forms.Label label3;
    }
}

