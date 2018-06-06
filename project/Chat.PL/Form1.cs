using Chat.BL;
using Chat.BL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.PL
{
    public partial class Form1 : Form
    {
        IUserService service;
        public Form1(IUserService s)
        {
            service = s;
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//add
        {
            int index;
            using (var form = new AddForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    dataGridView1.Rows.Add();
                    index = dataGridView1.Rows.Count - 1;
                    dataGridView1[0, index].Value = form.ReturnValue1;
                    dataGridView1[1, index].Value = form.ReturnValue2;
                    dataGridView1[2, index].Value = form.ReturnValue3;
                    dataGridView1[3, index].Value = form.ReturnValue4;
                    dataGridView1[4, index].Value = form.ReturnValue5;
                    dataGridView1[5, index].Value = form.ReturnValue6;
                }
                else
                {
                    return;
                }
            }
            index = dataGridView1.Rows.Count - 1;
            UserDTO user = new UserDTO(
                    Convert.ToInt32(dataGridView1[0, index].Value),
                    dataGridView1[1, index].Value.ToString(),
                    dataGridView1[2, index].Value.ToString(),
                    Convert.ToInt32(dataGridView1[5, index].Value),
                    dataGridView1[3, index].Value.ToString(),
                    Convert.ToInt32(dataGridView1[4, index].Value));
            service.CreateUser(user);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//delete
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                service.DeleteUser(Convert.ToInt32(r.Cells[0].Value));
                dataGridView1.Rows.RemoveAt(r.Index);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//edit
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                UserDTO user = new UserDTO(
                    Convert.ToInt32(dataGridView1[0, r.Index].Value.ToString()),
                    dataGridView1[1, r.Index].Value.ToString(),
                    dataGridView1[2, r.Index].Value.ToString(),
                    Convert.ToInt32(dataGridView1[5, r.Index].Value.ToString()),
                    dataGridView1[3, r.Index].Value.ToString(),
                    Convert.ToInt32(dataGridView1[4, r.Index].Value.ToString()));
                service.ChangeUser(user);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IEnumerable<UserDTO> users = service.GetAllUsers();
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Surname";
            dataGridView1.Columns[3].Name = "Email";
            dataGridView1.Columns[4].Name = "Company id";
            dataGridView1.Columns[5].Name = "Pos id";
            dataGridView1.RowCount = users.Count();
            int i = 0;
            foreach (UserDTO user in users)
            {
                dataGridView1[0, i].Value = user.id;
                dataGridView1[1, i].Value = user.name;
                dataGridView1[2, i].Value = user.surname;
                dataGridView1[3, i].Value = user.email;
                dataGridView1[4, i].Value = user.companyId;
                dataGridView1[5, i].Value = user.positionId;
                i++;
            }
        }
    }
}
