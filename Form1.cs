namespace WinForms_EntityFramework
{
    public partial class Form1 : Form
    {
        rfaContext accessBdd;
        public Form1()
        {
            InitializeComponent();
            accessBdd = new RfaContext();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //
            accessBdd.Actors.Load();
            //
            this.actorBindingSource.DataSource = accessBdd.Actors.Local.ToBindingList();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            accessBdd.SaveChanges();
        }
    }
}
