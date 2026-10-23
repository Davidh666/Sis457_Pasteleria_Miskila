namespace CpPastelería_Miskila
{
    partial class FrmPedidos
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
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.txtIngrese = new System.Windows.Forms.Label();
            this.txtClientes = new System.Windows.Forms.Label();
            this.pedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labPastelería_MiskilaDataSet = new CpPastelería_Miskila.LabPastelería_MiskilaDataSet();
            this.pedidosTableAdapter = new CpPastelería_Miskila.LabPastelería_MiskilaDataSetTableAdapters.PedidosTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlBusqyeda = new System.Windows.Forms.GroupBox();
            this.cont2 = new System.Windows.Forms.GroupBox();
            this.dtgLista = new System.Windows.Forms.DataGridView();
            this.idpedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idusuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipopedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechapedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaentregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoregDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAcciones = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gbxDatos = new System.Windows.Forms.GroupBox();
            this.lblBs = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblFechaR = new System.Windows.Forms.Label();
            this.erpCliente = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpTipo = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpTotal = new System.Windows.Forms.ErrorProvider(this.components);
            this.fkDetallePedidoPedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detallePedidoTableAdapter = new CpPastelería_Miskila.LabPastelería_MiskilaDataSetTableAdapters.DetallePedidoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labPastelería_MiskilaDataSet)).BeginInit();
            this.pnlBusqyeda.SuspendLayout();
            this.cont2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).BeginInit();
            this.pnlAcciones.SuspendLayout();
            this.gbxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fkDetallePedidoPedidosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(270, 25);
            this.txtParametro.Margin = new System.Windows.Forms.Padding(4);
            this.txtParametro.Multiline = true;
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(646, 31);
            this.txtParametro.TabIndex = 15;
            // 
            // txtIngrese
            // 
            this.txtIngrese.AutoSize = true;
            this.txtIngrese.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngrese.Location = new System.Drawing.Point(69, 31);
            this.txtIngrese.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtIngrese.Name = "txtIngrese";
            this.txtIngrese.Size = new System.Drawing.Size(166, 20);
            this.txtIngrese.TabIndex = 12;
            this.txtIngrese.Text = "Buscar por nombre/Tipo";
            // 
            // txtClientes
            // 
            this.txtClientes.AutoSize = true;
            this.txtClientes.Font = new System.Drawing.Font("Montserrat", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientes.ForeColor = System.Drawing.Color.Teal;
            this.txtClientes.Location = new System.Drawing.Point(565, 52);
            this.txtClientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtClientes.Name = "txtClientes";
            this.txtClientes.Size = new System.Drawing.Size(173, 55);
            this.txtClientes.TabIndex = 11;
            this.txtClientes.Text = "Pedidos";
            // 
            // pedidosBindingSource
            // 
            this.pedidosBindingSource.DataMember = "Pedidos";
            this.pedidosBindingSource.DataSource = this.labPastelería_MiskilaDataSet;
            // 
            // labPastelería_MiskilaDataSet
            // 
            this.labPastelería_MiskilaDataSet.DataSetName = "LabPastelería_MiskilaDataSet";
            this.labPastelería_MiskilaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pedidosTableAdapter
            // 
            this.pedidosTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(940, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 30);
            this.button1.TabIndex = 20;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlBusqyeda
            // 
            this.pnlBusqyeda.BackColor = System.Drawing.Color.White;
            this.pnlBusqyeda.Controls.Add(this.txtParametro);
            this.pnlBusqyeda.Controls.Add(this.button1);
            this.pnlBusqyeda.Controls.Add(this.txtIngrese);
            this.pnlBusqyeda.Location = new System.Drawing.Point(130, 127);
            this.pnlBusqyeda.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBusqyeda.Name = "pnlBusqyeda";
            this.pnlBusqyeda.Padding = new System.Windows.Forms.Padding(4);
            this.pnlBusqyeda.Size = new System.Drawing.Size(1048, 85);
            this.pnlBusqyeda.TabIndex = 21;
            this.pnlBusqyeda.TabStop = false;
            this.pnlBusqyeda.Text = "Criterio de Búsqueda";
            // 
            // cont2
            // 
            this.cont2.Controls.Add(this.dtgLista);
            this.cont2.Location = new System.Drawing.Point(130, 231);
            this.cont2.Margin = new System.Windows.Forms.Padding(4);
            this.cont2.Name = "cont2";
            this.cont2.Padding = new System.Windows.Forms.Padding(4);
            this.cont2.Size = new System.Drawing.Size(1048, 327);
            this.cont2.TabIndex = 22;
            this.cont2.TabStop = false;
            this.cont2.Text = "Lista de pedidos";
            // 
            // dtgLista
            // 
            this.dtgLista.AllowUserToAddRows = false;
            this.dtgLista.AllowUserToDeleteRows = false;
            this.dtgLista.AutoGenerateColumns = false;
            this.dtgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpedidoDataGridViewTextBoxColumn,
            this.idusuarioDataGridViewTextBoxColumn,
            this.tipopedidoDataGridViewTextBoxColumn,
            this.observacionesDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.fechapedidoDataGridViewTextBoxColumn,
            this.fechaentregaDataGridViewTextBoxColumn,
            this.estadoregDataGridViewTextBoxColumn});
            this.dtgLista.DataSource = this.pedidosBindingSource;
            this.dtgLista.Location = new System.Drawing.Point(73, 44);
            this.dtgLista.Name = "dtgLista";
            this.dtgLista.ReadOnly = true;
            this.dtgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLista.Size = new System.Drawing.Size(843, 240);
            this.dtgLista.TabIndex = 0;
            // 
            // idpedidoDataGridViewTextBoxColumn
            // 
            this.idpedidoDataGridViewTextBoxColumn.DataPropertyName = "id_pedido";
            this.idpedidoDataGridViewTextBoxColumn.HeaderText = "id_pedido";
            this.idpedidoDataGridViewTextBoxColumn.Name = "idpedidoDataGridViewTextBoxColumn";
            this.idpedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idusuarioDataGridViewTextBoxColumn
            // 
            this.idusuarioDataGridViewTextBoxColumn.DataPropertyName = "id_usuario";
            this.idusuarioDataGridViewTextBoxColumn.HeaderText = "id_usuario";
            this.idusuarioDataGridViewTextBoxColumn.Name = "idusuarioDataGridViewTextBoxColumn";
            this.idusuarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idusuarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // tipopedidoDataGridViewTextBoxColumn
            // 
            this.tipopedidoDataGridViewTextBoxColumn.DataPropertyName = "tipo_pedido";
            this.tipopedidoDataGridViewTextBoxColumn.HeaderText = "tipo_pedido";
            this.tipopedidoDataGridViewTextBoxColumn.Name = "tipopedidoDataGridViewTextBoxColumn";
            this.tipopedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacionesDataGridViewTextBoxColumn
            // 
            this.observacionesDataGridViewTextBoxColumn.DataPropertyName = "observaciones";
            this.observacionesDataGridViewTextBoxColumn.HeaderText = "observaciones";
            this.observacionesDataGridViewTextBoxColumn.Name = "observacionesDataGridViewTextBoxColumn";
            this.observacionesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechapedidoDataGridViewTextBoxColumn
            // 
            this.fechapedidoDataGridViewTextBoxColumn.DataPropertyName = "fecha_pedido";
            this.fechapedidoDataGridViewTextBoxColumn.HeaderText = "fecha_pedido";
            this.fechapedidoDataGridViewTextBoxColumn.Name = "fechapedidoDataGridViewTextBoxColumn";
            this.fechapedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaentregaDataGridViewTextBoxColumn
            // 
            this.fechaentregaDataGridViewTextBoxColumn.DataPropertyName = "fecha_entrega";
            this.fechaentregaDataGridViewTextBoxColumn.HeaderText = "fecha_entrega";
            this.fechaentregaDataGridViewTextBoxColumn.Name = "fechaentregaDataGridViewTextBoxColumn";
            this.fechaentregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoregDataGridViewTextBoxColumn
            // 
            this.estadoregDataGridViewTextBoxColumn.DataPropertyName = "estado_reg";
            this.estadoregDataGridViewTextBoxColumn.HeaderText = "estado_reg";
            this.estadoregDataGridViewTextBoxColumn.Name = "estadoregDataGridViewTextBoxColumn";
            this.estadoregDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.btnCerrar);
            this.pnlAcciones.Controls.Add(this.btnAgregar);
            this.pnlAcciones.Controls.Add(this.btnEditar);
            this.pnlAcciones.Controls.Add(this.btnEliminar);
            this.pnlAcciones.Location = new System.Drawing.Point(222, 578);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(842, 77);
            this.pnlAcciones.TabIndex = 28;
            this.pnlAcciones.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCerrar.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(678, 19);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(146, 37);
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregar.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(18, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(146, 37);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(170, 19);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(146, 37);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminar.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(322, 19);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(146, 37);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // gbxDatos
            // 
            this.gbxDatos.Controls.Add(this.lblBs);
            this.gbxDatos.Controls.Add(this.dateTimePicker1);
            this.gbxDatos.Controls.Add(this.btnCancelar);
            this.gbxDatos.Controls.Add(this.btnGuardar);
            this.gbxDatos.Controls.Add(this.txtCliente);
            this.gbxDatos.Controls.Add(this.cbxTipo);
            this.gbxDatos.Controls.Add(this.lblNombre);
            this.gbxDatos.Controls.Add(this.txtTotal);
            this.gbxDatos.Controls.Add(this.lblObservacion);
            this.gbxDatos.Controls.Add(this.lblTotal);
            this.gbxDatos.Controls.Add(this.txtObservaciones);
            this.gbxDatos.Controls.Add(this.lblTipo);
            this.gbxDatos.Controls.Add(this.lblFechaR);
            this.gbxDatos.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatos.Location = new System.Drawing.Point(130, 691);
            this.gbxDatos.Name = "gbxDatos";
            this.gbxDatos.Size = new System.Drawing.Size(1048, 225);
            this.gbxDatos.TabIndex = 29;
            this.gbxDatos.TabStop = false;
            this.gbxDatos.Text = "Datos del Pedido";
            // 
            // lblBs
            // 
            this.lblBs.AutoSize = true;
            this.lblBs.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBs.Location = new System.Drawing.Point(199, 168);
            this.lblBs.Name = "lblBs";
            this.lblBs.Size = new System.Drawing.Size(36, 30);
            this.lblBs.TabIndex = 30;
            this.lblBs.Text = "Bs";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(753, 116);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(863, 168);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 37);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(747, 168);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 37);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(81, 38);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(872, 21);
            this.txtCliente.TabIndex = 21;
            // 
            // cbxTipo
            // 
            this.cbxTipo.AllowDrop = true;
            this.cbxTipo.AutoCompleteCustomSource.AddRange(new string[] {
            "Delivery",
            "Recojo del local"});
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxTipo.Items.AddRange(new object[] {
            "Delivery",
            "Entrga"});
            this.cbxTipo.Location = new System.Drawing.Point(832, 77);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 25);
            this.cbxTipo.TabIndex = 25;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 41);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 17);
            this.lblNombre.TabIndex = 16;
            this.lblNombre.Text = "Cliente :";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(92, 168);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(110, 30);
            this.txtTotal.TabIndex = 24;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Location = new System.Drawing.Point(20, 85);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(95, 17);
            this.lblObservacion.TabIndex = 17;
            this.lblObservacion.Text = " Observaciones :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(29, 168);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(68, 30);
            this.lblTotal.TabIndex = 18;
            this.lblTotal.Text = "Total :";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(121, 82);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(585, 21);
            this.txtObservaciones.TabIndex = 22;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(724, 81);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(94, 17);
            this.lblTipo.TabIndex = 19;
            this.lblTipo.Text = "Tipo de pedido :";
            // 
            // lblFechaR
            // 
            this.lblFechaR.AutoSize = true;
            this.lblFechaR.Location = new System.Drawing.Point(638, 117);
            this.lblFechaR.Name = "lblFechaR";
            this.lblFechaR.Size = new System.Drawing.Size(109, 17);
            this.lblFechaR.TabIndex = 20;
            this.lblFechaR.Text = "Fecha de Entrega :";
            // 
            // erpCliente
            // 
            this.erpCliente.ContainerControl = this;
            // 
            // erpTipo
            // 
            this.erpTipo.ContainerControl = this;
            // 
            // erpTotal
            // 
            this.erpTotal.ContainerControl = this;
            // 
            // fkDetallePedidoPedidosBindingSource
            // 
            this.fkDetallePedidoPedidosBindingSource.DataMember = "fk_DetallePedido_Pedidos";
            this.fkDetallePedidoPedidosBindingSource.DataSource = this.pedidosBindingSource;
            // 
            // detallePedidoTableAdapter
            // 
            this.detallePedidoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1348, 1008);
            this.Controls.Add(this.gbxDatos);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.cont2);
            this.Controls.Add(this.pnlBusqyeda);
            this.Controls.Add(this.txtClientes);
            this.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPedidos";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmHistorialPedidos";
            this.Load += new System.EventHandler(this.FrmPedidos_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labPastelería_MiskilaDataSet)).EndInit();
            this.pnlBusqyeda.ResumeLayout(false);
            this.pnlBusqyeda.PerformLayout();
            this.cont2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).EndInit();
            this.pnlAcciones.ResumeLayout(false);
            this.gbxDatos.ResumeLayout(false);
            this.gbxDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fkDetallePedidoPedidosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Label txtIngrese;
        private System.Windows.Forms.Label txtClientes;
        private LabPastelería_MiskilaDataSet labPastelería_MiskilaDataSet;
        private System.Windows.Forms.BindingSource pedidosBindingSource;
        private LabPastelería_MiskilaDataSetTableAdapters.PedidosTableAdapter pedidosTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox pnlBusqyeda;
        private System.Windows.Forms.GroupBox cont2;
        private System.Windows.Forms.GroupBox pnlAcciones;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox gbxDatos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblFechaR;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ErrorProvider erpCliente;
        private System.Windows.Forms.ErrorProvider erpTipo;
        private System.Windows.Forms.ErrorProvider erpTotal;
        private System.Windows.Forms.Label lblBs;
        private System.Windows.Forms.BindingSource fkDetallePedidoPedidosBindingSource;
        private LabPastelería_MiskilaDataSetTableAdapters.DetallePedidoTableAdapter detallePedidoTableAdapter;
        private System.Windows.Forms.DataGridView dtgLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipopedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechapedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaentregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoregDataGridViewTextBoxColumn;
    }
}