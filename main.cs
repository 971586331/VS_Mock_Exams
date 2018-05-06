using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace VS_Mock_Exams
{
    public partial class main : Form
    {

        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp;
            MySqlConnection sqlcom = null;

            common.gInput_Info.mysql_ip = "198.13.61.243";
            common.gInput_Info.mysql_port = "3306";
            common.gInput_Info.mysql_ID = "root";
            common.gInput_Info.mysql_password = "sy84436446";
            common.gInput_Info.mysql_databases = "sy_test";
            common.gInput_Info.mysql_table = "table_full";

            //连接接据库
            temp = common_mysql.Connect_Databse(ref sqlcom, common.gInput_Info.mysql_ip, common.gInput_Info.mysql_port, common.gInput_Info.mysql_ID, common.gInput_Info.mysql_password);
            if (temp == 0x00)
            {
                temp = common_mysql.Is_Database_Exists(sqlcom, common.gInput_Info.mysql_databases);
                if (temp == 0x00)
                {
                    Console.WriteLine("数据库存在!");
                    temp = common_mysql.User_Databse(sqlcom, common.gInput_Info.mysql_databases);
                    if (temp == 0x00)
                    {
                        temp = common_mysql.Is_Table_Exists(sqlcom, common.gInput_Info.mysql_databases, common.gInput_Info.mysql_table);
                        if (temp == 0x00)
                        {
                            Console.WriteLine("数据表存在!");
                            common_mysql.Query_One_Record(sqlcom, common.gInput_Info.mysql_table, 4, ref common.gTest_Questions);
                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", common.gTest_Questions.Title_Number, common.gTest_Questions.Subject, common.gTest_Questions.Option_A, common.gTest_Questions.Option_B, common.gTest_Questions.Option_C, common.gTest_Questions.Answer);
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("使用库失败!");
                    }
                }
                else if (temp == 0x01)
                {
                    Console.WriteLine("数据库不存在!");
                    
                }
                else
                {
                    Console.WriteLine("查询库错误!");
                }

                temp = common_mysql.Close_Databse(sqlcom);
                if (temp == 0x00)
                {
                    Console.WriteLine("数据库关闭成功!");
                }
                else
                {
                    Console.WriteLine("数据库关闭失败!");
                }
            }
        }
    }
}
