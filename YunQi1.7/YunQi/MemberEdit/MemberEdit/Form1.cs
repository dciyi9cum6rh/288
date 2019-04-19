using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemberEdit
{
    public partial class Form1 : Form
    {
        public SqlConnection con;
        ACCPlatformEntities CCE = new ACCPlatformEntities();
        public t_MemberRepository _A_MemberRepository;
        public t_AdminBackendRepository _t_AdminBackendRepository;
        public Form1()
        {
            InitializeComponent();
            _A_MemberRepository = new t_MemberRepository(CCE);
            _t_AdminBackendRepository = new t_AdminBackendRepository(CCE);
            string constr = @"data source = 10.10.0.160; initial catalog = CartCRMERP; persist security info = True; user id = sa; password = dreammaker@1107; MultipleActiveResultSets = True;";
            con = new SqlConnection(constr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("密碼與確認密碼需相符!");
                }
                else
                {
                    if (MessageBox.Show("確定新增?", "象棋自摸", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _A_MemberRepository.Create(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox5.Text,1, null);
                        _A_MemberRepository.save();
                        MessageBox.Show("新增成功!");
                    }
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("密碼與確認密碼需相符!");
            }
            else
            {
                if (MessageBox.Show("確定更新?", "象棋自摸", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _A_MemberRepository.UpdatePassword(textBox2.Text, textBox3.Text);
                    _A_MemberRepository.save();
                    MessageBox.Show("修改成功!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("密碼與確認密碼需相符!");
                }
                else
                {
                    if (MessageBox.Show("確定新增?", "ERP系統", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var p = new DynamicParameters();
                        p.Add("@EmployeeMobile", textBox2.Text, dbType: DbType.String);
                        p.Add("@Password", HashPassword(textBox3.Text), dbType: DbType.String);
                        p.Add("@PositionId", 1, dbType: DbType.Int32);
                        p.Add("@Name", textBox6.Text, dbType: DbType.String);
                        p.Add("@Birthday", new DateTime(1967,11,6), dbType: DbType.Date);
                        p.Add("@Duedate", new DateTime(2018,8,1), dbType: DbType.Date);
                        p.Add("@sex", (byte)1, dbType: DbType.Byte);
                        p.Add("@BaseSalary", 100000, dbType: DbType.Int32);
                        p.Add("@ID", "M111222333", dbType: DbType.String);
                        p.Add("@EmergencyContact", "蘇先生", dbType: DbType.String);
                        p.Add("@EmergencyContactPhone", "0123456789", dbType: DbType.String);
                        p.Add("@ContactPhone", "0422134567", dbType: DbType.String);
                        p.Add("@ContactAddress", "台中市台灣大道1號", dbType: DbType.String);
                        p.Add("@eMail", "1111@@gmail.com", dbType: DbType.String);
                        p.Add("@UpdateTime", DateTime.Now , dbType: DbType.DateTime);
                        p.Add("@UpdateEmployeeMobile", "1111111111", dbType: DbType.String);
                        p.Add("@c", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                        con.Open();
                        con.Execute("sp_InsertEmployee", p, commandType: CommandType.StoredProcedure);
                        int c = p.Get<int>("@c");
                        //_t_AdminRepository.Create(10001, textBox2.Text, textBox3.Text, "SimonDJ", "SimonDj@gmail.com", null);
                        //_t_AdminRepository.save();
                        MessageBox.Show("新增成功!");
                    }
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                if (ex.Message.ToLower().Contains("memberacount"))
                    msg="2";
                else if (ex.Message.ToLower().Contains("nickname"))
                    msg="3";
            }
            finally
            {
                con.Close();
            }
        }
        // 將密碼編碼的方法
        private string HashPassword(string str)
        {
            string rethash = "";

            System.Security.Cryptography.SHA256 hash = System.Security.Cryptography.SHA256.Create();
            System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
            byte[] combined = encoder.GetBytes(str);
            hash.ComputeHash(combined);
            rethash = Convert.ToBase64String(hash.Hash);

            return rethash;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("密碼與確認密碼需相符!");
                }
                else
                {
                    if (MessageBox.Show("確定新增?", "後台管理員", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _t_AdminBackendRepository.Create(textBox2.Text, textBox3.Text, textBox6.Text);
                        _t_AdminBackendRepository.save();
                        MessageBox.Show("新增成功!");
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("密碼與確認密碼需相符!");
            }
            else
            {
                if (MessageBox.Show("確定更新?", "象棋自摸", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _t_AdminBackendRepository.UpdatePassword(textBox2.Text, textBox3.Text);
                    _t_AdminBackendRepository.save();
                    MessageBox.Show("修改成功!");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showEnum();
        }

        private void showEnum(int lt=0)
        {
            if ((LinkType)lt == LinkType.none)
                MessageBox.Show(LinkType.none.ToString());
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public enum LinkType : int
    {
        none = 0,          // 未按連結(即剛進入時)
        PreOnePage = 1,    // 前一頁
        NextOnePage,       // 後一頁
        PreTenPage,        // 前10頁
        NextTenPage,       // 後10頁
        CettainPage        // 特定頁
    }
}
