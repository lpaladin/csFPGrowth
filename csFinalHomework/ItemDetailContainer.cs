//////////////////////////////////////////////////////
// ItemDetailContainer.cs：显示标签详细信息的界面逻辑。
// 作者：周昊宇
//////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csFinalHomework
{
	public partial class ItemDetailContainer : Form
	{
		public ItemDetailContainer()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 设定当前显示的标签项。
		/// </summary>
		/// <param name="item">要显示的项</param>
		public void SetItem(TagCloud.TagItem item)
		{
			lstMain.Items.Clear();
			txtName.Text = item.Name;
			txtSupport.Text = item.Value.ToString();
			if (item.Tag is List<FPTree<string>.FrequentItemSet>)
				foreach (FPTree<string>.FrequentItemSet set in (item.Tag as List<FPTree<string>.FrequentItemSet>))
				{
					ListViewItem lstitem = new ListViewItem();
					lstitem.Text = lstMain.Items.Count.ToString();
					StringBuilder sb = new StringBuilder();
					foreach (string obj in set.Items)
						sb.Append(obj).Append(' ');
					lstitem.SubItems.Add(sb.ToString());
					lstitem.SubItems.Add(set.Support.ToString());
					lstMain.Items.Add(lstitem);
				}
			else
				foreach (FPTree<int>.FrequentItemSet set in (item.Tag as List<FPTree<int>.FrequentItemSet>))
				{
					ListViewItem lstitem = new ListViewItem();
					lstitem.Text = lstMain.Items.Count.ToString();
					StringBuilder sb = new StringBuilder();
					foreach (int obj in set.Items)
						sb.Append(obj).Append(' ');
					lstitem.SubItems.Add(sb.ToString());
					lstitem.SubItems.Add(set.Support.ToString());
					lstMain.Items.Add(lstitem);
				}
		}
	}
}
