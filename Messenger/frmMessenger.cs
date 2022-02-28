using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;



namespace Messenger
{
    public partial class Messenger : Form
    {
        CancellationTokenSource _tokenSource = null;

        //private EventingBasicConsumer _consumer;

        private IModel _channel;
        private IConnection _connection;
        private ConnectionFactory _connectionFactory;


        public Messenger(string name)
        {

            InitializeComponent();


            _tokenSource = new CancellationTokenSource();
            StartLoadLogs(name);
            Createconnection();
            CreateTask("emptyuse_$$_rtemplate");




        }//Form Entry
        public void Createconnection()
        {
            _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }//Creating RabbitMq Connection

        public void StartLoadLogs(string name)
        {


            label_username.Text = name;
            string path = GetBaseDirectory() + label_username.Text;
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(file.Name.Remove(file.Name.Length - 4, 4));
                checkedListBox1.Items.Add(file.Name.Remove(file.Name.Length - 4, 4));
            }
        }//Loading logs from UserData Folder
        public void LoadLogs(string name)
        {
            Invoke(new ClearDelegate(ClearListbox));

            label_username.Text = name;
            string path = GetBaseDirectory() + label_username.Text;
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                Invoke(new AddFriendDelegate(FriendAdd), file.Name.Remove(file.Name.Length - 4, 4));
                Invoke(new AddFriendDelegateCheckBox(FriendAddCheckBox), file.Name.Remove(file.Name.Length - 4, 4));
            }
        }

        public void Work(string item, CancellationToken token)
        {
            int recount = 0;
            string itembuf = "";
            if (token.IsCancellationRequested)
            {
                return;
            }
            string name = label_username.Text;


            {
                string direction = item + "_" + name;

                _channel.QueueDeclare(queue: direction,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (sender, e) =>
                {
                    var body = e.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    UpdateRecieved(item, name, message);
                    writeWeb(item);
                };

                _channel.BasicConsume(queue: direction,
                                         autoAck: true,
                                         consumer: consumer);


            }

        }//Recievie
        public void CheckIfAdded(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }
            string name = label_username.Text;
            {
                string direction = "FriendList_" + name;

                _channel.QueueDeclare(queue: direction,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (sender, e) =>
                {
                    var body = e.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    if (message.Contains("_Addtofriends_"))
                        handleAdd(message.Substring(0, message.Length - 14));
                };

                _channel.BasicConsume(queue: direction,
                                         autoAck: true,
                                         consumer: consumer);


            }

        }//Recieve Messages format _Addtofriends_

        public string GetBaseDirectory()
        {
            string path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).FullName).FullName + "\\UserData\\";
            return path;
        }//return project directory

        public void handleAdd(string way)
        {
            string str = way;
            string path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).FullName).FullName + "\\UserData\\" + label_username.Text + "\\" + way + ".txt";
            if (!File.Exists(path))
            {
                if (!way.Contains(" "))
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {

                        sw.WriteLine(str + " Added You" + "\n");
                        sw.Close();
                        Invoke(new AddFriendDelegate(FriendAdd), (str));
                        Invoke(new AddFriendDelegateCheckBox(FriendAddCheckBox), str);


                    }
                }
                else
                    using (StreamWriter sw = new StreamWriter(path))
                    {

                        sw.WriteLine(str + " And You GroupChat" + "\n");
                        sw.Close();
                        Invoke(new AddFriendDelegate(FriendAdd), (str));
                        Invoke(new AddFriendDelegateCheckBox(FriendAddCheckBox), str);


                    }


            }

        }//If user gets added

        public async void CreateTask(string He)
        {
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            try
            {
                await Task.Run(() => Work(He, token));
                await Task.Run(() => CheckIfAdded(token));
            }
            catch (OperationCanceledException ex)
            {

            }


        }//Greating recieve task

        //DELEGATES
        public delegate void AddMessageDelegate(string message);

        public void LogAdd(string message)
        {
            richTextBox1.Text = message;
        }
        public delegate void AddFriendDelegate(string message);

        public void FriendAdd(string message)
        {
            listBox1.Items.Add(message);
        }

        public delegate void AddFriendDelegateCheckBox(string message);

        public void FriendAddCheckBox(string message)
        {
            checkedListBox1.Items.Add(message);
        }

        public string[] GetGroupMembers(string group)
        {
            string[] array = group.Split(' ').ToArray();
            Array.Sort(array, StringComparer.InvariantCulture);
            return array;
        }//Returns Members of A group

        public delegate void ClearDelegate();

        public void ClearListbox()
        {
            listBox1.Items.Clear();
        }
        public delegate string SelectedItemDelegate();

        public string Selectedit()
        {
            return listBox1.SelectedItem.ToString();
        }

        public string GetName()
        {
            return label_username.Text;
        }//returns username

        public string GetCurrent()
        {
            return (string)Invoke(new SelectedItemDelegate(Selectedit));


        }//returns current opened chat
        public void writeWeb(string he)
        {
            string Text = "";

            string path = GetBaseDirectory() + GetName() + "\\" + GetCurrent() + ".txt";
            string[] text = System.IO.File.ReadAllLines(path);
            foreach (string line in text)
                Text = Text + "\n" + line;
            Invoke(new AddMessageDelegate(LogAdd), Text);

        }//Updates ChatScreen

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Messenger_Load(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SqlConnection connection = SqlClass.CreateConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Table] WHERE Name = @tname", connection);
            cmd.Parameters.Add(new SqlParameter("tname", textbox_search.Text));
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
                MessageBox.Show("User Not Found");
            else if (textbox_search.Text != GetName())
            {
                string path = GetBaseDirectory() + GetName() + "\\" + textbox_search.Text + ".txt";
                if (!File.Exists(path))
                {
                    RabbitMQclass.ProduceMessage(label_username.Text + "_Addtofriends_", "FriendList_" + textbox_search.Text);
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("Your Conversation With " + textbox_search.Text + "\n");

                    }
                    listBox1.Items.Add(textbox_search.Text);
                    checkedListBox1.Items.Add(textbox_search.Text);
                }
                else
                    MessageBox.Show("User Already in your friend list.");
            }
            else
                MessageBox.Show("Cannot Add YourSelf.");

        }//Add friend class

        private void btn_CreateRoom_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible = true;
            btn_Confirm.Visible = true;
            btn_back.Visible = true;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            bool group = false;
            if (checkedListBox1.CheckedItems.Count < 2)
                MessageBox.Show("Choose at least 2 persons");
             if (checkedListBox1.CheckedItems.ToString().Contains(" "))
            {
               
                    MessageBox.Show("Cannot Add Group to a Group");
                    group = true;
                
            }
            if (!group)
            {
                //CREATE GROUP CHAT!
                checkedListBox1.Visible = false;
                btn_Confirm.Visible = false;
                string str = GetName() + " ";

                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    str = str + checkedListBox1.CheckedItems[i].ToString() + " ";
                }
                for (int j = 0; j < checkedListBox1.CheckedItems.Count; j++)
                {
                    RabbitMQclass.ProduceMessage(str + "_Addtofriends_", "FriendList_" + checkedListBox1.CheckedItems[j].ToString());
                }

                string path = GetBaseDirectory() + GetName() + "\\" + str + ".txt";

                bool isnieje = false;
                foreach (string items in listBox1.Items)
                {
                    string[] check;
                    check = items.Split(' ').ToArray();
                    Array.Sort(check, StringComparer.InvariantCulture);
                    isnieje = GetGroupMembers(str) == check;
                }
                if (!System.IO.File.Exists(path) && !isnieje)
                    using (StreamWriter sw = new StreamWriter(path))
                    {

                        sw.WriteLine("GroupChat Greated Users: " + str);
                        listBox1.Items.Add(str);
                        checkedListBox1.Items.Add(str);

                    }
                else
                    MessageBox.Show("Such group already Exists");

            }
        }//Creating Gropuchat

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // MessageBox.Show(listBox1.SelectedItem.ToString());
        }

        public static void UpdateRecieved(string he, string we, string message)
        {
            {
                string path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).FullName).FullName +
                    "\\UserData\\" + we + "\\" + he + ".txt";

                if (!File.Exists(path))
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("Your Conversation With " + he);
                        sw.WriteLine(he + " :\n" + message);

                    }
                else
                {
                    System.IO.File.AppendAllText(path, "\n" + message + "\n");
                }
            }


        }//Handle Recieved Message

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                string path = GetBaseDirectory() + label_username.Text + "\\" + GetCurrent() + ".txt";
                string message = label_username.Text + "  :" + Texbox_Chat.Text;
                if (!listBox1.SelectedItem.ToString().Contains(" "))
                {
                    string direction = label_username.Text + "_" + listBox1.SelectedItem.ToString();
                    RabbitMQclass.ProduceMessage(message, direction);
                    System.IO.File.AppendAllText(path, "\n" + message + "\n");
                    writeWeb(GetCurrent());
                }
                if (listBox1.SelectedItem.ToString().Contains(" "))
                {
                    string[] members = GetGroupMembers(listBox1.SelectedItem.ToString());
                    foreach (string member in members)
                    {
                        string direction = listBox1.SelectedItem.ToString() + "_" + member;
                        RabbitMQclass.ProduceMessage(message, direction);
                    }

                }
            }
        }//SendingMessage

        private void Messenger_Deactivate(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
        }//End Tasks

        private void Messenger_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }//End Tasks

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            //if (!listBox1.SelectedItem.ToString().Contains(" "))
            //{   
            btnSendGroup.Enabled = false;
            btnSendGroup.Visible = false;
            btn_send.Enabled = true;
            btn_send.Visible = true;
            _tokenSource.Cancel();
            writeWeb(GetCurrent());
            CreateTask(GetCurrent());
            // }
            /* if(listBox1.SelectedItem.ToString().Contains(" "))
             {
                 btnSendGroup.Enabled = true;
                 btnSendGroup.Visible = true;
                 btn_send.Enabled = false;
                 btn_send.Visible = false;
                 _tokenSource.Cancel();
                 writeWeb(GetCurrent());
                 CreateTask(GetCurrent());
             }*/

        }//On current chat changed

        private void btn_back_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible = false;
            btn_Confirm.Visible = false;
            btn_back.Visible = false;
        }//Cancel Group Creation


    }
}
