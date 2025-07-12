using ChatApp.Services;
using System.Drawing;
using System.Windows.Forms;

namespace ChatApp.Forms
{
    public partial class ChatForm : Form
    {
        private readonly IKafkaService _kafkaService;
        private readonly string _username;
        private bool _disposed = false;

        public ChatForm(IKafkaService kafkaService)
        {
            InitializeComponent();
            _kafkaService = kafkaService;
            _username = $"User_{new Random().Next(1000, 9999)}";
            
            // UI Enhancements
            InitializeEnhancedUI();
            
            _kafkaService.StartConsuming(DisplayMessage);
            this.Load += (s, e) => txtMessage.Focus();
        }

        private void InitializeEnhancedUI()
        {
            // Form styling
            this.Text = $"Chat App - {_username}";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            // Chat display
            txtChat.BackColor = Color.White;
            txtChat.BorderStyle = BorderStyle.FixedSingle;
            txtChat.Font = new Font("Consolas", 9F);

            // Message input
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
        }

        private void DisplayMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(DisplayMessage), message);
                return;
            }

            txtChat.AppendText($"{message}{Environment.NewLine}");
            txtChat.SelectionStart = txtChat.Text.Length;
            txtChat.ScrollToCaret();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                btnSend.Enabled = false;
                btnSend.Text = "Sending...";
                Cursor = Cursors.WaitCursor;

                try
                {
                    var timestamp = DateTime.Now.ToString("HH:mm:ss");
                    var message = $"[{timestamp}] {_username}: {txtMessage.Text}";
                    await Task.Run(() => _kafkaService.Produce(message));
                    txtMessage.Clear();
                }
                finally
                {
                    btnSend.Enabled = true;
                    btnSend.Text = "🚀 Send";
                    Cursor = Cursors.Default;
                    txtMessage.Focus();
                }
            }
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSend.PerformClick();
                e.Handled = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _kafkaService?.StopConsuming();
                    components?.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }
    }
}