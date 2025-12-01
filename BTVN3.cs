namespace btvn3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewStudents.View = View.Details;
            listViewStudents.GridLines = true;
            listViewStudents.FullRowSelect = true;

            listViewStudents.Columns.Add("Last Name", 100);
            listViewStudents.Columns.Add("First Name", 100);
            listViewStudents.Columns.Add("Phone", 80);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string hotext = ho.Text.Trim();
            string tentext = ten.Text.Trim();
            string sdttext = sdt.Text.Trim();

            if (string.IsNullOrEmpty(hotext) || string.IsNullOrEmpty(tentext))
            {
                return;
            }
            ListViewItem item = new ListViewItem(hotext);
            item.SubItems.Add(tentext);
            item.SubItems.Add(sdttext);
            listViewStudents.Items.Add(item);

            ho.Clear();
            ten.Clear();
            sdt.Clear();
            ho.Focus();
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewStudents.SelectedItems[0];

                ho.Text = selectedItem.Text;

                if (selectedItem.SubItems.Count > 1)
                {
                    ten.Text = selectedItem.SubItems[1].Text;
                }

                if (selectedItem.SubItems.Count > 2)
                {
                    sdt.Text = selectedItem.SubItems[2].Text;
                }
            }
            else
            {
                ho.Clear();
                ten.Clear();
                sdt.Clear();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a student to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ListViewItem selectedItem = listViewStudents.SelectedItems[0];
                selectedItem.Text = ho.Text.Trim();
                selectedItem.SubItems[1].Text = ten.Text.Trim();
                selectedItem.SubItems[2].Text = sdt.Text.Trim();
                ho.Clear();
                ten.Clear();
                sdt.Clear();
                ho.Focus();
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                ListViewItem selectedItem = listViewStudents.SelectedItems[0];
                listViewStudents.Items.Remove(selectedItem);
                ho.Clear();
                ten.Clear();
                sdt.Clear();
                ho.Focus();
            }
        }
    }
}