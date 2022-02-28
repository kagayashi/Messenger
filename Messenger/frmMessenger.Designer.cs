namespace Messenger
{
    partial class Messenger
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
            this.label_username = new System.Windows.Forms.Label();
            this.textbox_search = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Texbox_Chat = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_CreateRoom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_RemoveMember = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSendGroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome:";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_username.Location = new System.Drawing.Point(73, 9);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(11, 16);
            this.label_username.TabIndex = 1;
            this.label_username.Text = " ";
            // 
            // textbox_search
            // 
            this.textbox_search.Location = new System.Drawing.Point(273, 6);
            this.textbox_search.Name = "textbox_search";
            this.textbox_search.Size = new System.Drawing.Size(222, 20);
            this.textbox_search.TabIndex = 2;
            this.textbox_search.Text = "UserName to Find...";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(130, 355);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(163, 39);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(413, 283);
            this.webBrowser1.TabIndex = 4;
            // 
            // Texbox_Chat
            // 
            this.Texbox_Chat.Location = new System.Drawing.Point(163, 344);
            this.Texbox_Chat.Multiline = true;
            this.Texbox_Chat.Name = "Texbox_Chat";
            this.Texbox_Chat.Size = new System.Drawing.Size(413, 61);
            this.Texbox_Chat.TabIndex = 5;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(501, 412);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 6;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(501, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_CreateRoom
            // 
            this.btn_CreateRoom.Location = new System.Drawing.Point(115, 416);
            this.btn_CreateRoom.Name = "btn_CreateRoom";
            this.btn_CreateRoom.Size = new System.Drawing.Size(89, 24);
            this.btn_CreateRoom.TabIndex = 8;
            this.btn_CreateRoom.Text = "Create Room";
            this.btn_CreateRoom.UseVisualStyleBackColor = true;
            this.btn_CreateRoom.Click += new System.EventHandler(this.btn_CreateRoom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Your Chats:";
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(210, 416);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(90, 24);
            this.btn_back.TabIndex = 10;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Visible = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 58);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(130, 334);
            this.checkedListBox1.TabIndex = 11;
            this.checkedListBox1.Visible = false;
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(20, 416);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(89, 24);
            this.btn_Confirm.TabIndex = 12;
            this.btn_Confirm.Text = "Confirm";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Visible = false;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_RemoveMember
            // 
            this.btn_RemoveMember.Location = new System.Drawing.Point(306, 416);
            this.btn_RemoveMember.Name = "btn_RemoveMember";
            this.btn_RemoveMember.Size = new System.Drawing.Size(106, 24);
            this.btn_RemoveMember.TabIndex = 13;
            this.btn_RemoveMember.Text = "Remove Member";
            this.btn_RemoveMember.UseVisualStyleBackColor = true;
            this.btn_RemoveMember.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(163, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(413, 284);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // btnSendGroup
            // 
            this.btnSendGroup.Location = new System.Drawing.Point(501, 411);
            this.btnSendGroup.Name = "btnSendGroup";
            this.btnSendGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSendGroup.TabIndex = 15;
            this.btnSendGroup.Text = "Send";
            this.btnSendGroup.UseVisualStyleBackColor = true;
            this.btnSendGroup.Visible = false;
            // 
            // Messenger
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(592, 447);
            this.Controls.Add(this.btnSendGroup);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_RemoveMember);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_CreateRoom);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.Texbox_Chat);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textbox_search);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Messenger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMessenger";
            this.Deactivate += new System.EventHandler(this.Messenger_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Messenger_FormClosed);
            this.Load += new System.EventHandler(this.Messenger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label_username;
        private System.Windows.Forms.TextBox textbox_search;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox Texbox_Chat;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_CreateRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_RemoveMember;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSendGroup;
    }
}

