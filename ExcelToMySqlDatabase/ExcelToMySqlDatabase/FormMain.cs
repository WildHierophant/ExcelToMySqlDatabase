using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelToMySqlDatabase.Properties;
using MySql.Data.MySqlClient;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ExcelToMySqlDatabase
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            textBoxExcelURL.Text = Settings.Default.excelURL;
            textBoxServerURL.Text = Settings.Default.serverURL;
            textBoxPort.Text = Settings.Default.port;
            textBoxDataBase.Text = Settings.Default.dataBase;
            textBoxUser.Text = Settings.Default.user;
            checkBoxRememberUser.Checked = Settings.Default.rememberUser;
            textBoxPassword.Text = Settings.Default.password;
            checkBoxRememberPassword.Checked = Settings.Default.rememberPassword;
            textBoxDistinguish.Text = Settings.Default.distinguish;
        }

        /// <summary>
        /// Excel文件列表，只有xlsx格式与xls格式，且带有识别后缀的表格才会被读取
        /// </summary>
        List<string> pathList = new List<string>();

        /// <summary>
        /// 表格数量统计
        /// </summary>
        int excelNum = 0;

        /// <summary>
        /// 成功导出至MySql数据库的表格数量统计
        /// </summary>
        int excelNumSuccessToMySqkDatabase = 0;

        /// <summary>
        /// 统计时间变量
        /// </summary>
        Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// 总导表耗时统计
        /// </summary>
        double timeCount = 0f;

        /// <summary>
        /// ExcelURL按钮点击事件，即最上面那个...按钮，用于选择Excel文件所在文件夹地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExcelURL_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult.ToString() == "OK")
            {
                textBoxExcelURL.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// StartingExport按钮点击事件，即导出数据按钮，开始导出至指定数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartingExport_Click(object sender, EventArgs e)
        {
            // Excel文件夹地址
            string excelPath = textBoxExcelURL.Text;

            // 文件识别后缀
            string distinguishText = textBoxDistinguish.Text;

            // 服务器地址
            string serverPath = textBoxServerURL.Text;

            // 端口名
            string serverPort = textBoxPort.Text;

            // 数据库名
            string dataBaseName = textBoxDataBase.Text;

            // 用户名
            string userName = textBoxUser.Text;

            // 密码
            string passwordText = textBoxPassword.Text;

            // 调用方法，获取Excel文件列表
            GetPath(excelPath, distinguishText);

            // 判断Excel文件列表中待导出的文件是否大于0，如果是则执行导出
            if (excelNum > 0)
            {
                // 调用方法，判断服务器地址、端口名、数据库名是非为空
                if (IsPathNoNULL(serverPath, serverPort, dataBaseName))
                {
                    for (int i = 1; i <= excelNum; i++)
                    {
                        FileStream fileStream = new FileStream(pathList[i - 1], FileMode.Open, FileAccess.Read);
                        ConnectToSql(serverPath, serverPort, dataBaseName, userName, passwordText, fileStream);
                        //WriteToJson(fileStream);
                    }
                    listBox.Items.Add("表格总计:共读取到" + excelNum + "张表格");
                    listBox.Items.Add("成功导出表格:共有" + excelNumSuccessToMySqkDatabase + "张表格成功导出至MySql数据库");
                    listBox.Items.Add("错误表格:共有" + (excelNum - excelNumSuccessToMySqkDatabase) + "张表格导出失败");
                    listBox.Items.Add("导出结束");
                    listBox.Items.Add("耗时" + timeCount + "秒");
                    listBox.Items.Add("---------------------------------------------------");
                    excelNum = default;
                    excelNumSuccessToMySqkDatabase = default;
                    timeCount = default;
                }
            }
        }

        /// <summary>
        /// ClearListBoxMessage按钮点击事件，清理ListBox中的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearListBoxMessage_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }

        /// <summary>
        /// FormMain窗体关闭事件，关闭时记录所有textBox中的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.excelURL = textBoxExcelURL.Text;
            Settings.Default.serverURL = textBoxServerURL.Text;
            Settings.Default.port = textBoxPort.Text;
            Settings.Default.dataBase = textBoxDataBase.Text;
            if (checkBoxRememberUser.Checked)
            {
                Settings.Default.user = textBoxUser.Text;
            }
            else
            {
                Settings.Default.user = "";
            }
            Settings.Default.rememberUser = checkBoxRememberUser.Checked;
            if (checkBoxRememberPassword.Checked)
            {
                Settings.Default.password = textBoxPassword.Text;
            }
            else
            {
                Settings.Default.password = "";
            }
            Settings.Default.rememberPassword = checkBoxRememberPassword.Checked;
            Settings.Default.distinguish = textBoxDistinguish.Text;
            Settings.Default.Save();
        }

        /// <summary>
        /// 获取目标文件夹内文件列表方法，只读取xlsx格式与xls格式
        /// </summary>
        /// <param name="excelPath">Excel文件夹地址</param>
        /// <param name="distinguishText">文件识别后缀</param>
        /// <returns></returns>
        public List<string> GetPath(string excelPath, string distinguishText)
        {
            // 检查excelURL内地址是否为空
            if (excelPath != "")
            {
                // 检查distinguish文件识别后缀是非为空，以及是否包含非法字符
                if (distinguishText == ""
                && distinguishText.Contains(@"\")
                && distinguishText.Contains("/")
                && distinguishText.Contains(":")
                && distinguishText.Contains("*")
                && distinguishText.Contains("?")
                && distinguishText.Contains('"')
                && distinguishText.Contains("<")
                && distinguishText.Contains(">")
                && distinguishText.Contains("|"))
                {
                    listBox.Items.Add("Error:识别后缀为空或包含非法字符");
                    listBox.Items.Add("---------------------------------------------------");
                    pathList.Clear();
                    return pathList;
                }
                else
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(excelPath);
                    // 检查excelURL内地址是否存在
                    if (directoryInfo.Exists)
                    {
                        FileInfo[] fileInfos = directoryInfo.GetFiles();
                        pathList.Clear();
                        foreach (FileInfo fileInfo in fileInfos)
                        {
                            if (fileInfo.Name.EndsWith(distinguishText + ".xlsx") || fileInfo.Name.EndsWith(distinguishText + ".xls"))
                            {
                                pathList.Add(fileInfo.FullName);
                            }
                        }
                    }
                    else
                    {
                        listBox.Items.Add("Error:表格地址有误，请重新选择文件夹目录");
                        listBox.Items.Add("---------------------------------------------------");
                        pathList.Clear();
                        return pathList;
                    }
                }
                
            }
            else
            {
                listBox.Items.Add("Error:表格地址为空，请重新选择文件夹目录");
                listBox.Items.Add("---------------------------------------------------");
                pathList.Clear();
                return pathList;
            }
            excelNum = pathList.Count;
            if (excelNum == 0)
            {
                listBox.Items.Add("Error:表格文件夹目录下未读取到带后缀表格，请重新选择文件夹");
                listBox.Items.Add("---------------------------------------------------");
            }
            else if (excelNum < 0)
            {
                listBox.Items.Add("Error:读取表格数量异常");
                listBox.Items.Add("---------------------------------------------------");
            }
            return pathList;
        }

        /// <summary>
        /// 判断服务器地址、端口名、数据库名是否为空，如果为空返回false，非空返回true
        /// </summary>
        /// <param name="serverPath">服务器地址</param>
        /// <param name="serverPort">端口名</param>
        /// <param name="dataBaseName">数据库名</param>
        /// <returns></returns>
        public bool IsPathNoNULL(string serverPath, string serverPort, string dataBaseName)
        {
            // 检查serverURL内地址是否为空
            if (serverPath == "")
            {
                listBox.Items.Add("Error:导出数据库地址为空");
                listBox.Items.Add("---------------------------------------------------");
                pathList.Clear();
                return false;
            }

            // 检查port端口是否为空
            if (serverPort == "")
            {
                listBox.Items.Add("Error:导出端口号为空");
                listBox.Items.Add("---------------------------------------------------");
                pathList.Clear();
                return false;
            }

            // 检查dataBase数据库名是否为空
            if (dataBaseName == "")
            {
                listBox.Items.Add("Error:导出数据库名为空");
                listBox.Items.Add("---------------------------------------------------");
                pathList.Clear();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 连接至数据库，需要填入服务器地址，端口名，数据库名，用户名，密码，当前读取文件名
        /// </summary>
        /// <param name="serverPath">服务器地址</param>
        /// <param name="serverPort">端口名</param>
        /// <param name="dataBaseName">数据库名</param>
        /// <param name="userName">用户名</param>
        /// <param name="passwordText">密码</param>
        /// <param name="fileStream">当前正在读取的表格的文件流</param>
        public void ConnectToSql(string serverPath, string serverPort, string dataBaseName, string userName, string passwordText, FileStream fileStream)
        {
            // 连接数据库字符串，包含服务器地址，端口名，数据库名，用户名，密码
            string constructorString =
                "server=" + serverPath + ";" +
                "port=" + serverPort + ";" +
                "database=" + dataBaseName + ";" +
                "user=" + userName + ";" +
                "pwd=" + passwordText + ";";

            // 重置统计时间变量
            stopwatch.Restart();

            // 单次耗时
            double timer;

            // 连接MySql数据库
            MySqlConnection mySqlConnection = new MySqlConnection(constructorString);

            // 读取创建Excel文件
            XSSFWorkbook wookBook = new XSSFWorkbook(fileStream);

            // 服务端表头所在行数，第2行
            var serverTitleRow = 1;

            // 服务端数据开始行数，第4行
            var serverDataRow = 3;

            // 服务端单元格类型行数，第3行
            var serverCellTypeRow = 2;

            // 获取Excel文件第一张sheet表格的表名
            string sheetName = wookBook.GetSheetName(0);

            // 获取Excel文件第一张sheet表格
            ISheet sheet = wookBook.GetSheetAt(0);

            // 判断表头是否存在异常
            bool titleIsError = false;

            // Excel表格文件名
            string fileStreamName = fileStream.Name.Replace(textBoxExcelURL.Text + @"\", "");

            if (sheetName.StartsWith("Sheet") || sheetName.StartsWith("sheet") || sheetName == "")
            {
                stopwatch.Stop();
                timer = stopwatch.ElapsedMilliseconds * 0.001;
                timeCount += timer;
                listBox.Items.Add("Error:文件[" + fileStreamName + "]表格名称不符合规范，该表格无法导出Json，请修改");
                listBox.Items.Add("耗时" + timer + "秒");
                listBox.Items.Add("*********************************************");
            }
            else
            {
                //服务端表头
                IRow titleRow = sheet.GetRow(serverTitleRow);
                //单元格类型表头
                IRow cellTypeRow = sheet.GetRow(serverCellTypeRow);
                //最后一格的编号，即列数
                int columnCount = titleRow.LastCellNum;
                //遍历表头是否有空值，如果有则不导出
                for (int i = titleRow.FirstCellNum; i < columnCount; i++)
                {
                    if (titleRow.GetCell(i) == null || titleRow.GetCell(i).ToString().Length == 0)
                    {
                        stopwatch.Stop();
                        timer = stopwatch.ElapsedMilliseconds * 0.001;
                        timeCount += timer;
                        listBox.Items.Add("Error:文件[" + fileStreamName + "]表格，第" + (i + 1) + "列表头存在数据异常，该表格无法导出Json，请修改");
                        listBox.Items.Add("耗时" + timer + "秒");
                        listBox.Items.Add("*********************************************");
                        titleIsError = true;
                        break;
                    }
                }
                //遍历单元格类型表头是否有空值，如果有则不导出
                for (int i = cellTypeRow.FirstCellNum; i < columnCount; i++)
                {
                    if (cellTypeRow.GetCell(i) == null || cellTypeRow.GetCell(i).ToString().Length == 0)
                    {
                        stopwatch.Stop();
                        timer = stopwatch.ElapsedMilliseconds * 0.001;
                        timeCount += timer;
                        listBox.Items.Add("Error:文件[" + fileStreamName + "]表格，第" + (i + 1) + "列单元格类型存在数据异常，该表格无法导出Json，请修改");
                        listBox.Items.Add("耗时" + timer + "秒");
                        listBox.Items.Add("*********************************************");
                        titleIsError = true;
                        break;
                    }
                }
                try
                {
                    // 判断表头是否存在异常
                    if (titleIsError == false)
                    {
                        // 打开通道，建立连接，可能出现异常,使用try catch语句
                        mySqlConnection.Open();
                        listBox.Items.Add("已经与服务器地址" + serverPath + "建立连接");
                        listBox.Items.Add("服务器用户" + userName);

                        // 最后一行的编号
                        int rowCount = sheet.LastRowNum;

                        string tableName = sheetName.ToLower() + "_table";

                        // 清空对应表格
                        string sql = "TRUNCATE TABLE " + tableName + ";";

                        // 表头名列表
                        List<string> columnsName = new List<string>();

                        // 建立DataTable
                        DataTable dataTable = mySqlConnection.GetSchema("Columns");

                        // 读取当前表对应的MySql表的表头
                        if (dataTable.Columns.Contains("COLUMN_NAME"))
                        {
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                if (dataRow["TABLE_NAME"].ToString() == tableName)
                                {
                                    columnsName.Add((string)dataRow["COLUMN_NAME"]);
                                }
                            }
                        }

                        // 需导出表头统计
                        string columnNameCountData = "";

                        string valueCountData = "";

                        // 遍历行
                        for (int i = serverDataRow; i <= rowCount; i++)
                        {
                            // 获取行
                            IRow row = sheet.GetRow(i);

                            // 判断该行是否为空
                            if (row == null)
                            {
                                listBox.Items.Add("Error:文件[" + fileStreamName + "]表格，第" + (i + 1) + "行存在数据异常");
                                break;
                            }

                            // 需要导出数据库表示
                            bool isToDataBaseDistinguish = false;

                            // 需导出表头统计
                            string columnNameCount = "";

                            // 需导出数据参数值统计
                            string valueCount = "";

                            // 遍历该行的列
                            for (int j = row.FirstCellNum; j < columnCount; j++)
                            {
                                if (titleRow.GetCell(j) != null && titleRow.GetCell(j).ToString().Length != 0)
                                {
                                    // 表头名
                                    string title = titleRow.GetCell(j).ToString().Trim();

                                    // 遍历数据库表头
                                    for (int x = 0; x <= columnsName.Count - 1; x++)
                                    {
                                        // 判断表头是否相同，数据是否需要导出
                                        if (row.GetCell(j) != null && columnsName[x] == sheetName.ToLower() + title.ToLower())
                                        {
                                            // 目标单元格类型
                                            CellType cellType = row.GetCell(j).CellType;

                                            // 单元格类型表头
                                            CellType rowCellType = default;
                                            switch (cellTypeRow.GetCell(j).ToString().Trim())
                                            {
                                                case "int":
                                                    rowCellType = CellType.Numeric;
                                                    break;
                                                case "string":
                                                    rowCellType = CellType.String;
                                                    break;
                                                case "bool":
                                                    rowCellType = CellType.Boolean;
                                                    break;
                                                case "":
                                                    rowCellType = CellType.Blank;
                                                    break;
                                            }

                                            // 判断数据是否异常
                                            if (cellType != rowCellType && cellType != CellType.Formula)
                                            {
                                                stopwatch.Stop();
                                                timer = stopwatch.ElapsedMilliseconds * 0.001;
                                                timeCount += timer;
                                                listBox.Items.Add("Error:文件[" + fileStreamName + "]表格，第" + (i + 1) + "行，第" + (j + 1) + "列单元格类型存在数据异常，该表格无法继续导出Json，请修改");
                                                listBox.Items.Add("耗时" + timer + "秒");
                                                listBox.Items.Add("*********************************************");
                                                return;
                                            }
                                            else
                                            {
                                                // 判断单元格类型
                                                switch (cellType)
                                                {
                                                    case CellType.Numeric:
                                                        valueCount = valueCount + ", '" + row.GetCell(j).NumericCellValue.ToString().Trim() + "'";
                                                        break;
                                                    case CellType.String:
                                                        valueCount = valueCount + ", '" + row.GetCell(j).StringCellValue.ToString().Trim() + "'";
                                                        break;
                                                    case CellType.Formula:
                                                        switch (rowCellType)
                                                        {
                                                            case CellType.Numeric:
                                                                valueCount = valueCount + ", '" + row.GetCell(j).NumericCellValue.ToString().Trim() + "'";
                                                                break;
                                                            case CellType.String:
                                                                valueCount = valueCount + ", '" + row.GetCell(j).StringCellValue.ToString().Trim() + "'";
                                                                break;
                                                            case CellType.Boolean:
                                                                valueCount = valueCount + ", '" + row.GetCell(j).BooleanCellValue.ToString().Trim() + "'";
                                                                break;
                                                        }
                                                        break;
                                                    case CellType.Blank:
                                                        valueCount = valueCount + ", ''";
                                                        break;
                                                    case CellType.Boolean:
                                                        valueCount = valueCount + ", '" + row.GetCell(j).BooleanCellValue.ToString().Trim() + "'";
                                                        break;
                                                    case CellType.Unknown:
                                                        listBox.Items.Add("Error:文件[" + fileStreamName + "]表格，第" + (i + 1) + "行，第" + (j + 1) + "列单元格类型未知");
                                                        break;
                                                    case CellType.Error:
                                                        listBox.Items.Add("Error:文件[" + fileStreamName + "]表格，第" + (i + 1) + "行，第" + (j + 1) + "列单元格类型存在异常");
                                                        break;
                                                }
                                                columnNameCount = columnNameCount + ", " + columnsName[x];
                                                isToDataBaseDistinguish = true;
                                            }
                                        }
                                    }
                                }
                            }

                            //if (isToDataBaseDistinguish)
                            //{
                            //    sql = sql + "INSERT INTO " + tableName + " (id" + columnNameCount + ") VALUES ('" + (i - serverDataRow) + "'" + valueCount + ");";
                            //}

                            if (isToDataBaseDistinguish)
                            {
                                columnNameCountData = "(id" + columnNameCount + ")";
                                valueCountData = valueCountData + "('" + (i - serverDataRow) + "'" + valueCount + "),";
                                //listBox.Items.Add("INSERT INTO " + tableName + " (id" + columnNameCount + ") VALUES ('" + (i - serverDataRow) + "'" + valueCount + ");");
                            }
                        }
                        valueCountData = valueCountData.Substring(0, valueCountData.Length - 1);
                        sql = sql + "INSERT INTO " + tableName + " " + columnNameCountData + " VALUES " + valueCountData + ";";

                        MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                        //MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                        MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                        //DataTable dataTable2 = new DataTable();
                        //mySqlDataAdapter.Fill(dataTable);

                        //计时
                        excelNumSuccessToMySqkDatabase += 1;
                        stopwatch.Stop();
                        timer = stopwatch.ElapsedMilliseconds * 0.001;
                        timeCount += timer;
                        listBox.Items.Add("文件[" + fileStreamName + "]导出至数据库成功");
                        listBox.Items.Add("耗时" + timer + "秒");
                        listBox.Items.Add("*********************************************");
                    }
                }
                catch (MySqlException ex)
                {
                    listBox.Items.Add("Error:" + ex.Message);
                    listBox.Items.Add("*********************************************");
                }
                finally
                {
                    // 关闭通道
                    mySqlConnection.Close();
                }
            }
        }
    }
}
