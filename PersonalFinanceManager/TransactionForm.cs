using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceManager
{
    public partial class TransactionForm : Form
    {
        private readonly DatabaseManager _db;

        private readonly TransactionRepository _txRepo;

        private readonly CategoryRepository _catRepo;

        public bool TransactionSaved { get; private set; }

        public TransactionForm()
        {
            InitializeComponent();

            _db = new DatabaseManager();

            _txRepo = new TransactionRepository(_db);

            _catRepo = new CategoryRepository(_db);

            LoadCategories();

            LoadTransactionTypes();
        }

        private void LoadCategories()
        {
            List<Category> categories =
                _catRepo.GetAllCategories();

            cmbCategory.DataSource =
                categories;

            cmbCategory.DisplayMember =
                "Name";

            cmbCategory.ValueMember =
                "Id";
        }

        private void LoadTransactionTypes()
        {
            cmbTransactionType.Items.Add(
                "Income");

            cmbTransactionType.Items.Add(
                "Expense");

            cmbTransactionType.SelectedIndex = 0;
        }

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(
                        txtAmount.Text,
                        out decimal amount))
                {
                    MessageBox.Show(
                        "Invalid amount.");

                    return;
                }

                if (cmbCategory.SelectedItem
                    is not Category category)
                {
                    MessageBox.Show(
                        "Select category.");

                    return;
                }

                Transaction transaction =
                    new Transaction
                    {
                        UserId =
                            CurrentUser.Id,

                        CategoryId =
                            category.Id,

                        Amount =
                            amount,

                        Description =
                            txtDescription.Text,

                        TransactionType =
                            cmbTransactionType
                                .Text,

                        TransactionDate =
                            dtpTransactionDate
                                .Value,

                        CreatedAt =
                            DateTime.Now
                    };

                bool result =
                    _txRepo.AddTransaction(
                        transaction);

                if (result)
                {
                    TransactionSaved =
                        true;

                    MessageBox.Show(
                        "Transaction added.");

                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to add transaction.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}