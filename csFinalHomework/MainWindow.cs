//////////////////////////////////////////////
// FrmMain.cs：频繁模式挖掘程序的界面逻辑
// 提示：主窗口中的注释很少，
//       不过也没什么可说的……
// 作者：周昊宇
//////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace csFinalHomework
{
	/// <summary>
	/// 表示无参数无返回值的函数委托。
	/// </summary>
    public delegate void Action();

	/// <summary>
	/// 表示两个参数无返回值的函数委托。
	/// </summary>
	/// <typeparam name="T1">函数参数1的类型</typeparam>
	/// <typeparam name="T2">函数参数2的类型</typeparam>
	/// <param name="arg1">函数参数1</param>
	/// <param name="arg2">函数参数2</param>
    public delegate void Action<T1, T2>(T1 arg1, T2 arg2);

	/// <summary>
	/// 主程序窗口的具体实现。
	/// </summary>
    public partial class MainWindow : Form
    {
        private List<List<int>> allData;
        private List<FPTree<int>.FrequentItemSet> digResult;
        private Action<FPTree<int>.FrequentItemSet> WriteToList;
        private List<List<string>> allData_s;
        private List<FPTree<string>.FrequentItemSet> digResult_s;
        private Action<FPTree<string>.FrequentItemSet> WriteToList_s;
        private Action<string, int> SetStatus;
        private Action EnableAllButtons;
        private int supThreshold;
        private long maxMem;
        private bool showInList, ignoreSingle, readAsString,
            showStatus, getNumOnly, trace;
        private StreamWriter sw;
        private Thread thrWork;
        private Stopwatch watch;
        private bool[] columnSortStatus;
        private string fileName;

        public MainWindow()
        {
            InitializeComponent();
            columnSortStatus = new bool[] { false, false };
            supThreshold = 100;
            showStatus = ignoreSingle = true;
            trace = false;
            showInList = readAsString = getNumOnly = false;

			// 以下委托用于在工作线程中间接调用改变主窗口状态
            SetStatus = new Action<string, int>((x, count) =>
                {
                    lblStatus.Text = x;
                    if (showInList)
                        lstMain.VirtualListSize = count;
                    long mem = GC.GetTotalMemory(false);
                    lblHeapMem.Text = string.Format(" 堆内存占用：{0} MB", mem / 1048576);
                    if (mem > maxMem)
                        maxMem = mem;
                    if (trace && watch != null && watch.IsRunning)
                        sw.WriteLine(string.Format("{0},{1},{2},{3},{4}", fileName,
                            supThreshold, watch.ElapsedMilliseconds, count, GC.GetTotalMemory(false)));
                });
            EnableAllButtons = new Action(() =>
                {
                    btnOpen.Enabled = txtSupportThreshold.Enabled = txtSupportPercentThreshold.Enabled =
						btnSortFrequentItemSet.Enabled = btnProcess.Enabled = btnSaveToFile.Enabled = 
						chkGetNumOnly.Enabled = chkShowInList.Enabled = chkIgnoreSingleItem.Enabled =
						radbtnInt.Enabled = radbtnString.Enabled = chkUpdateStatus.Enabled = true;
					if ((readAsString && digResult_s != null) || (!readAsString && digResult != null))
						btnVisualize.Enabled = true;
                    btnStop.Enabled = false;
                    prgbarProcess.MarqueeAnimationSpeed = 0;
					btnRefreshList_Click(null, null);
                });
            WriteToList = new Action<FPTree<int>.FrequentItemSet>((item) => digResult.Add(item));
            WriteToList_s = new Action<FPTree<string>.FrequentItemSet>((item) => digResult_s.Add(item));
        }

        private void lstMain_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (readAsString)
            {
                var item = digResult_s[e.ItemIndex];
                StringBuilder sb = new StringBuilder();
                foreach (string x in item.Items)
                    sb.Append(x).Append(' ');
                e.Item = new ListViewItem(new string[] { e.ItemIndex.ToString(), sb.ToString(), item.Support.ToString() });
            }
            else
            {
                var item = digResult[e.ItemIndex];
                StringBuilder sb = new StringBuilder();
                foreach (int x in item.Items)
                    sb.Append(x).Append(' ');
                e.Item = new ListViewItem(new string[] { e.ItemIndex.ToString(), sb.ToString(), item.Support.ToString() });
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
			mnuOpen.Show(btnOpen, btnOpen.Width, btnOpen.Height);
        }

		/// <summary>
		/// 从文件中读取数据集。
		/// </summary>
		/// <param name="strPath">文件路径</param>
        private void ReadData(string strPath)
        {
            using (StreamReader sr = new StreamReader(strPath, true))
            {
                string currLine;
                this.Invoke(SetStatus, "正在读取文件……", 0);
                if (readAsString)
                {
                    allData_s = new List<List<string>>();
                    while (!sr.EndOfStream)
                    {
                        currLine = sr.ReadLine();
                        List<string> currTransact = new List<string>();
                        foreach (string x in currLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                            currTransact.Add(x);
                        allData_s.Add(currTransact);
                    }
                }
                else
                {
                    try
                    {
                        allData = new List<List<int>>();
                        while (!sr.EndOfStream)
                        {
                            currLine = sr.ReadLine();
                            List<int> currTransact = new List<int>();
                            foreach (string x in currLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                                currTransact.Add(int.Parse(x));
                            allData.Add(currTransact);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("该文件内容不是整数，请检查后再试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                this.Invoke(SetStatus, "就绪。", 0);
                this.Invoke(EnableAllButtons);
            }        
        }

		/// <summary>
		/// 使用频繁模式树对当前数据集进行挖掘。
		/// </summary>
        private void ProcessData()
        {
            int setCount = 0;
            try
            {
                if (trace)
                {
                    try { sw.Close(); }
                    catch { }
                    sw = new StreamWriter("trace.txt", true);
                    sw.WriteLine(string.Format("{0},{1},{2},{3},{4}", fileName, supThreshold, 0, 0, 0));
                }
                maxMem = 0;
                watch = new Stopwatch();

                watch.Start();
                if (readAsString)
                {
                    FPTree<string> tree;
                    if (showStatus)
                        tree = new FPTree<string>((x, count) => this.Invoke(SetStatus, x, count), allData_s, supThreshold);
                    else
                        tree = new FPTree<string>(null, allData_s, supThreshold);
                    if (getNumOnly)
                        setCount = tree.StartDig(null, ignoreSingle);
                    else
                        setCount = tree.StartDig(WriteToList_s, ignoreSingle);
                    this.Invoke(SetStatus, "就绪。找到满足条件的项集" + setCount + "个。", setCount);
                }
                else
                {
                    FPTree<int> tree;
                    if (showStatus)
                        tree = new FPTree<int>((x, count) => this.Invoke(SetStatus, x, count), allData, supThreshold);
                    else
                        tree = new FPTree<int>(null, allData, supThreshold);
                    if (getNumOnly)
                        setCount = tree.StartDig(null, ignoreSingle);
                    else
                        setCount = tree.StartDig(WriteToList, ignoreSingle);
                    this.Invoke(SetStatus, "就绪。找到满足条件的项集" + setCount + "个。", setCount);
                }
                watch.Stop();

                if (trace)
                {
                    sw.WriteLine(string.Format("{0},{1},{2},{3},{4}", fileName,
                        supThreshold, watch.ElapsedMilliseconds, setCount, maxMem));
                    sw.Close();
                }
                if (showInList)
                    MessageBox.Show("挖掘成功完成！" + Environment.NewLine + "耗时：" + watch.Elapsed.TotalSeconds + " 秒" +
                        Environment.NewLine + "内存峰值：" + maxMem / 1048576 +  " MB" + Environment.NewLine + 
                        "提示：请关闭“在列表中实时显示”以获得最佳性能！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("挖掘成功完成！" + Environment.NewLine + "耗时：" + watch.Elapsed.TotalSeconds + " 秒" +
                        Environment.NewLine + "内存峰值：" + maxMem / 1048576 + " MB",
                        "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke(EnableAllButtons);
            }
            catch (ThreadAbortException)
            {
                MessageBox.Show("T T挖掘过程被中断了……", "sigh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("处理过程中出现了问题……" + Environment.NewLine + Environment.NewLine +
                    ex.Message, "错误> <", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "正在处理……";
            FreezeControls();
            if (readAsString)
                digResult_s = new List<FPTree<string>.FrequentItemSet>(4000000);
            else
                digResult = new List<FPTree<int>.FrequentItemSet>(4000000);
            (thrWork = new Thread(() => ProcessData())).Start();
        }

		/// <summary>
		/// 冻结当前窗体上除“停止”按钮外所有控件。
		/// </summary>
        private void FreezeControls()
        {
            columnSortStatus[0] = columnSortStatus[1] = false;
            lstMain.VirtualListSize = 0;
            lstMain.VirtualMode = showInList;
            btnOpen.Enabled = false;
            btnSaveToFile.Enabled = false;
            btnProcess.Enabled = false;
            txtSupportThreshold.Enabled = txtSupportPercentThreshold.Enabled = false;
            btnVisualize.Enabled = btnSortFrequentItemSet.Enabled = false;
            btnStop.Enabled = true;
            chkUpdateStatus.Enabled = chkGetNumOnly.Enabled = chkShowInList.Enabled = chkIgnoreSingleItem.Enabled = false;
            radbtnInt.Enabled = radbtnString.Enabled = false;
            prgbarProcess.MarqueeAnimationSpeed = 100;
        }

        private void txtSupportThreshold_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                supThreshold = int.Parse(txtSupportThreshold.Text);
                txtSupportPercentThreshold.Text = (supThreshold * 100.0 / GetTransactCount()).ToString();
            }
            catch
            {
                txtSupportThreshold.Text = supThreshold.ToString();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();
            int i = 0;
            for (i = 1; i < args.Length; i++)
                if (args[i] == "-t")
                    trace = true;
                else if (File.Exists(args[i]))
                {
                    btnOpen.Enabled = false;
                    txtFilePath.Text = args[i];
                    prgbarProcess.MarqueeAnimationSpeed = 100;
                    (thrWork = new Thread(() => ReadData(args[i]))).Start();
                }
                else
                    MessageBox.Show("命令行参数：" + Environment.NewLine +
                        "____________________________" + Environment.NewLine + Environment.NewLine +
                        "-t : 将性能记录信息存入trace.txt" + Environment.NewLine +
                        "<filename> : 指定要打开的数据文件");
			cmbConnType.SelectedIndex = 0;
			cmbProvider.SelectedIndex = 0;
        }

        private void chkShowInList_CheckedChanged(object sender, EventArgs e)
        {
            showInList = chkShowInList.Checked;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (thrWork != null && thrWork.IsAlive)
                thrWork.Abort();
            SetStatus("就绪。", GetTransactCount());
            EnableAllButtons();
        }

        private void chkIgnoreSingleItem_CheckedChanged(object sender, EventArgs e)
        {
            ignoreSingle = chkIgnoreSingleItem.Checked;
        }

        private void lstMain_ColumnClick(object sender, ColumnClickEventArgs e)
        {
			// 处理列表视图中的排序请求
            if (e.Column == 1)
            {
                columnSortStatus[0] = !columnSortStatus[0];
                if (readAsString)
                    digResult_s.Sort(new Comparison<FPTree<string>.FrequentItemSet>((x, y) =>
                        {
                            if (y.Items.Length < x.Items.Length)
                                return columnSortStatus[0] ? -1 : 1;
                            else if (x.Items.Length < y.Items.Length)
                                return columnSortStatus[0] ? 1 : -1;
                            int i, compare;
                            for (i = 0; i < x.Items.Length; i++)
                                if ((compare = x.Items[i].CompareTo(y.Items[i])) < 0)
                                    return columnSortStatus[0] ? 1 : -1;
                                else if (compare > 0)
                                    return columnSortStatus[0] ? -1 : 1;
                            return 0;
                        }));
                else
                    digResult.Sort(new Comparison<FPTree<int>.FrequentItemSet>((x, y) =>
                    {
                            if (y.Items.Length < x.Items.Length)
                                return columnSortStatus[0] ? -1 : 1;
                            else if (x.Items.Length < y.Items.Length)
                                return columnSortStatus[0] ? 1 : -1;
                            int i;
                            for (i = 0; i < x.Items.Length; i++)
                                if (x.Items[i] < y.Items[i])
                                    return columnSortStatus[0] ? 1 : -1;
                                else if (x.Items[i] > y.Items[i])
                                    return columnSortStatus[0] ? -1 : 1;
                            return 0;
                        }));
            }
            else if (e.Column == 2)
            {
                if (readAsString)
                    digResult_s.Sort(new Comparison<FPTree<string>.FrequentItemSet>((x, y) => (columnSortStatus[1] ? -1 : 1) *
                        x.Support.CompareTo(y.Support)));
                else
                    digResult.Sort(new Comparison<FPTree<int>.FrequentItemSet>((x, y) => (columnSortStatus[1] ? -1 : 1) *
                        x.Support.CompareTo(y.Support)));
                columnSortStatus[1] = !columnSortStatus[1];
            }
            lstMain.Refresh();
        }

        private void radbtnString_CheckedChanged(object sender, EventArgs e)
        {
            readAsString = radbtnString.Checked;
            btnProcess.Enabled = btnSaveToFile.Enabled = false;
            lstMain.VirtualMode = false;
            ttReload.Show("请重新打开文件！", this, btnOpen.Location, 5000);
        }

        private void btnSortFrequentItemSet_Click(object sender, EventArgs e)
        {
            if (readAsString)
            {
                if (digResult_s != null)
                    foreach (FPTree<string>.FrequentItemSet itemSet in digResult_s)
                        Array.Sort(itemSet.Items);
            }
            else
            {
                if (digResult != null)
                    foreach (FPTree<int>.FrequentItemSet itemSet in digResult)
                        Array.Sort(itemSet.Items);
            }
            lstMain.Refresh();
        }

		/// <summary>
		/// 获得挖掘得到的频繁项集个数。
		/// </summary>
		/// <returns></returns>
        private int GetTransactCount()
        {
            if (readAsString && allData_s != null)
                return allData_s.Count;
            else if (!readAsString && allData != null)
                return allData.Count;
            return 0;
        }

        private void txtSupportPercentThreshold_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                supThreshold = (int)(GetTransactCount() * double.Parse(txtSupportPercentThreshold.Text) / 100);
                txtSupportThreshold.Text = supThreshold.ToString();
            }
            catch
            {
                txtSupportPercentThreshold.Text = (100.0 * supThreshold / GetTransactCount()).ToString();
            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            if ((readAsString && digResult_s == null) ||
                (!readAsString && digResult == null))
                return;
            lstMain.VirtualListSize = readAsString ? digResult_s.Count : digResult.Count;
            lstMain.VirtualMode = true;
        }

        private void chkGetNumOnly_CheckedChanged(object sender, EventArgs e)
        {
            getNumOnly = chkGetNumOnly.Checked;
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (sfdFileSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try { sw.Close(); }
                catch { }
                FreezeControls();
                string prev = lblStatus.Text;
                (thrWork = new Thread(() =>
                    {
                        try
                        {
                            using (sw = new StreamWriter(sfdFileSave.FileName))
                            {
                                if (readAsString)
                                {
                                    this.Invoke(SetStatus, "正在保存……", digResult_s.Count);
                                    foreach (FPTree<string>.FrequentItemSet fis in digResult_s)
                                    {
                                        StringBuilder sb = new StringBuilder();
                                        foreach (string x in fis.Items)
                                            sb.Append(x).Append(' ');
                                        sb.Append(": ").Append(fis.Support);
                                        sw.WriteLine(sb.ToString());
                                    }
                                    this.Invoke(SetStatus, prev, digResult_s.Count);
                                }
                                else
                                {
                                    this.Invoke(SetStatus, "正在保存……", digResult.Count);
                                    foreach (FPTree<int>.FrequentItemSet fis in digResult)
                                    {
                                        StringBuilder sb = new StringBuilder();
                                        foreach (int x in fis.Items)
                                            sb.Append(x).Append(' ');
                                        sb.Append(": ").Append(fis.Support);
                                        sw.WriteLine(sb.ToString());
                                    }
                                    this.Invoke(SetStatus, prev, digResult.Count);
                                }
                            }
                            this.Invoke(EnableAllButtons);
                        }
                        catch (ThreadAbortException)
                        {
                            MessageBox.Show("T T保存过程被中断了……", "sigh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("保存过程中出现了问题……" + Environment.NewLine + Environment.NewLine +
                                ex.Message, "错误> <", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    })).Start();
            }
        }

        private void chkUpdateStatus_CheckedChanged(object sender, EventArgs e)
        {
            showStatus = chkUpdateStatus.Checked;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
@"频繁模式挖掘与可视化工具
v 0.1
________________

作者：周昊宇
学号：1200012823
邮箱：zhy.zbklqx@Gmail.com

", "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		private void btnVisualize_Click(object sender, EventArgs e)
		{
			if (readAsString && digResult_s != null)
				(new Visualizer<string>(digResult_s)).ShowDialog();
			else if (!readAsString && digResult != null)
				(new Visualizer<int>(digResult)).ShowDialog();
		}

		private void mnuOpenFile_Click(object sender, EventArgs e)
		{
			if (ofdFileOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				lstMain.Items.Clear();
				btnOpen.Enabled = false;
				fileName = Path.GetFileName(ofdFileOpen.FileName);
				txtFilePath.Text = ofdFileOpen.FileName;
				prgbarProcess.MarqueeAnimationSpeed = 100;
				(thrWork = new Thread(() => ReadData(ofdFileOpen.FileName))).Start();
			}
		}

		private void conn_TextChanged(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			if (cmbConnType.SelectedItem as string != "SQL" && cmbProvider.Text != "")
				sb.Append("Provider=").Append(cmbProvider.Text).Append(';');
			if (txtDataSource.Text != "")
				sb.Append("Data Source=").Append(txtDataSource.Text).Append(';');
			if (txtUserID.Text != "")
				sb.Append("User ID=").Append(txtUserID.Text).Append(';');
			if (txtPassword.Text != "")
				sb.Append("Password=").Append(txtPassword.Text).Append(';');
			txtConnStr.Text = sb.ToString();
		}
		
		private void mnuDataSrcConfirm_Click(object sender, EventArgs e)
		{
			IDbCommand cmd;
			IDataReader reader;
			string connTyp = cmbConnType.SelectedItem as string;
			lstMain.Items.Clear();
			btnOpen.Enabled = false;
			txtFilePath.Text = txtConnStr.Text;
			FreezeControls();
			(thrWork = new Thread(() =>
			{
				try
				{
					if (connTyp == "SQL")
					{
						SqlConnection conn = new SqlConnection(txtConnStr.Text);
						conn.Open();
						cmd = new SqlCommand("select * from " + txtTableName.Text, conn);
					}
					else
					{
						OdbcConnection conn = new OdbcConnection(txtConnStr.Text);
						conn.Open();
						cmd = new OdbcCommand("select * from " + txtTableName.Text, conn);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("连接指定数据源过程中出现了问题……" + Environment.NewLine + Environment.NewLine +
						ex.Message, "错误> <", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Invoke(SetStatus, "就绪。", 0);
					this.Invoke(EnableAllButtons);
					return;
				}
				try
				{
					using (reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						this.Invoke(SetStatus, "正在读取……", 0);
						if (readAsString)
						{
							allData_s = new List<List<string>>();
							do
							{
								int len = reader.GetSchemaTable().Rows.Count;
								List<string> currTransact = new List<string>();
								for (int i = 0; i < len; i++)
									currTransact.Add(reader.GetString(i));
								allData_s.Add(currTransact);
							} while (reader.Read());
						}
						else
						{
							try
							{
								allData = new List<List<int>>();
								do
								{
									int len = reader.GetSchemaTable().Rows.Count;
									List<int> currTransact = new List<int>();
									for (int i = 0; i < len; i++)
										currTransact.Add(reader.GetInt32(i));
									allData.Add(currTransact);
								} while (reader.Read());
							}
							catch (Exception)
							{
								MessageBox.Show("该数据库内容不是整数，请检查后再试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						this.Invoke(SetStatus, "就绪。", 0);
						this.Invoke(EnableAllButtons);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("访问指定数据源过程中出现了问题……" + Environment.NewLine + Environment.NewLine +
						ex.Message, "错误> <", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Invoke(SetStatus, "就绪。", 0);
					this.Invoke(EnableAllButtons);
				}
			})).Start();
		}
    }
}
