namespace ChatApp.Forms
{
    partial class ChatForm
    {
        private System.ComponentModel.IContainer components = null;

        

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // txtChat
            this.txtChat.Location = new System.Drawing.Point(12, 12);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(460, 300);
            this.txtChat.TabIndex = 0;
            
            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(12, 318);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(379, 23);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            
            // btnSend
            this.btnSend.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(397, 318);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "🚀 Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            
            // Hover effects
            this.btnSend.MouseEnter += (sender, e) => 
            {
                btnSend.BackColor = System.Drawing.Color.RoyalBlue;
                btnSend.Cursor = Cursors.Hand;
            };
            this.btnSend.MouseLeave += (sender, e) => 
            {
                btnSend.BackColor = System.Drawing.Color.DodgerBlue;
                btnSend.Cursor = Cursors.Default;
            };
            
            // ChatForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 351);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChat);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
    }
}