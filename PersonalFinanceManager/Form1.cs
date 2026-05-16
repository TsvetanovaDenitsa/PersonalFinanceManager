using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;


namespace PersonalFinanceManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadTransactions();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.DataSource is not DataTable table || table.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.FileName = "transactions.csv";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);
                // headers
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (i > 0) sw.Write(',');
                    sw.Write(EscapeCsv(table.Columns[i].ColumnName));
                }
                sw.WriteLine();

                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (i > 0) sw.Write(',');
                        var val = row[i]?.ToString() ?? "";
                        sw.Write(EscapeCsv(val));
                    }
                    sw.WriteLine();
                }

                MessageBox.Show("Exported to " + sfd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message);
            }
        }

        private string EscapeCsv(string s)
        {
            if (s.Contains('"') || s.Contains(',') || s.Contains('\n') || s.Contains('\r'))
            {
                return '"' + s.Replace("\"", "\"\"") + '"';
            }
            return s;
        }

        string connectionString = @"Data Source=DENICA\SQLEXPRESS;Initial Catalog=PersonalFinanceDB;Integrated Security=True;Trust Server Certificate=True;";

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using SqlConnection connection =
    new SqlConnection(connectionString);

            string query =
                "INSERT INTO Transactions (Amount, Category) VALUES (@Amount, @Category)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Amount", decimal.Parse(txtAmount.Text));
            command.Parameters.AddWithValue("@Category", cmbCategory.Text);

            connection.Open();

            command.ExecuteNonQuery();

            MessageBox.Show("Saved!");
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                string baseQuery = "SELECT Id, Amount, Category, CreatedAt FROM Transactions";
                string where = "";
                var selectedCategory = cmbCategory.Text;
                if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All")
                {
                    where = " WHERE Category = @Category";
                }

                string order = " ORDER BY CreatedAt DESC";
                string query = baseQuery + where + order;

                using var adapter = new SqlDataAdapter(query, connection);
                if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All")
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Category", selectedCategory);
                }
                var table = new DataTable();
                adapter.Fill(table);

                dgvTransactions.DataSource = table;
                dgvTransactions.AutoResizeColumns();
                // calculate balance
                // calculate balance using same filter
                try
                {
                    string sumQuery = "SELECT SUM(Amount) FROM Transactions" + (where ?? "");
                    using SqlCommand cmd = new SqlCommand(sumQuery, connection);
                    if (!string.IsNullOrWhiteSpace(selectedCategory) && selectedCategory != "All")
                    {
                        cmd.Parameters.AddWithValue("@Category", selectedCategory);
                    }
                    connection.Open();
                    var result = cmd.ExecuteScalar();
                    connection.Close();

                    decimal balance = 0;
                    if (result != DBNull.Value && result != null)
                    {
                        decimal.TryParse(result.ToString(), out balance);
                    }

                    lblBalance.Text = $"Balance: {balance:C}";
                }
                catch
                {
                    decimal balance = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        if (row["Amount"] != DBNull.Value)
                        {
                            decimal.TryParse(row["Amount"].ToString(), out decimal v);
                            balance += v;
                        }
                    }

                    lblBalance.Text = $"Balance: {balance:C}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load transactions: " + ex.Message);
            }
        }

        private int? GetSelectedTransactionId()
        {
            if (dgvTransactions.CurrentRow == null)
                return null;

            var cell = dgvTransactions.CurrentRow.Cells["Id"];
            if (cell == null || cell.Value == null)
                return null;

            if (int.TryParse(cell.Value.ToString(), out int id))
                return id;

            return null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedTransactionId();
            if (id == null)
            {
                MessageBox.Show("Please select a transaction to delete.");
                return;
            }

            var confirm = MessageBox.Show("Delete selected transaction?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                string query = "DELETE FROM Transactions WHERE Id = @Id";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id.Value);
                connection.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    MessageBox.Show("Deleted.");
                    LoadTransactions();
                }
                else
                {
                    MessageBox.Show("No transaction deleted. It may have been removed already.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete: " + ex.Message);
            }
        }
    }
}


    