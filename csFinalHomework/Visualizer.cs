//////////////////////////////////////////////
// Visualizer.cs：频繁模式可视化工具的界面逻辑
// 作者：周昊宇
//////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csFinalHomework
{
	/// <summary>
	/// 频繁模式可视化工具的具体实现。
	/// </summary>
	/// <typeparam name="T">项的类型</typeparam>
	public partial class Visualizer<T> : Form where T : IComparable<T>
	{
		private ItemDetailContainer frmDetail;
		private List<FPTree<T>.FrequentItemSet> digResult;
		private Hashtable map;

		/// <summary>
		/// 以频繁模式树挖掘结果创建新的可视化窗口。
		/// </summary>
		/// <param name="result">频繁模式树挖掘结果</param>
		public Visualizer(List<FPTree<T>.FrequentItemSet> result)
		{
			if (result == null)
				throw new ArgumentNullException("你在搞毛线啊！！");
			digResult = result;
			map = new Hashtable();
			InitializeComponent();
			numTopX.Maximum = digResult.Count;
			numTopX.Value = digResult.Count > 5 ? 5 : digResult.Count;
		}

		private void numTopX_ValueChanged(object sender, EventArgs e)
		{
			int i, j, scale = 0, cur;
			short globalID = 0;
			map.Clear();
			tagCloud.Items.Clear();
			tagCloud.ClearBond();
			for (i = 0; i < numTopX.Value; i++)
			{
				Array.Sort(digResult[i].Items);

				// 枚举所有指定范围内频繁项集，并将项和项关系加入标签云控件
				for (j = 0; j < digResult[i].Items.Length; j++)
				{
					if (map.Contains(digResult[i].Items[j]))
					{
						TagCloud.TagItem item = map[digResult[i].Items[j]] as TagCloud.TagItem;
						(item.Tag as List<FPTree<T>.FrequentItemSet>).Add(digResult[i]);
						cur = (item.Value += digResult[i].Support);
						if (cur > scale)
							scale = cur;
					}
					else
					{
						TagCloud.TagItem item = new TagCloud.TagItem();
						item.Name = digResult[i].Items[j].ToString();
						item.ID = globalID++;
						item.Value = digResult[i].Support;
						item.Tag = new List<FPTree<T>.FrequentItemSet>();
						(item.Tag as List<FPTree<T>.FrequentItemSet>).Add(digResult[i]);
						tagCloud.Items.Add(item);
						map.Add(digResult[i].Items[j], item);
					}
					if (j > 0)
					{
						tagCloud.AddBond(map[digResult[i].Items[j - 1]] as TagCloud.TagItem,
							map[digResult[i].Items[j]] as TagCloud.TagItem,
							digResult[i].Support);
					}
				}
			}
			tagCloud.Scale = scale;
			tagCloud.NeedUpdate = true;
			tagCloud.Invalidate();
		}

		private void tagCloud_ItemSelected(object sender, MouseEventArgs e)
		{
			if (frmDetail == null)
			{
				frmDetail = new ItemDetailContainer();
				frmDetail.FormClosed += (o, x) => frmDetail = null;
			}

			// 使用详细信息窗口显示选中项的详细信息
			frmDetail.Show();
			frmDetail.SetItem(tagCloud.SelectedItem);
		}

		private void Visualizer_Load(object sender, EventArgs e)
		{
			btnBorderColor.BackColor = tagCloud.HoveredBorder.Color;
			btnHighLightColor.BackColor = (tagCloud.SelectedBackground as SolidBrush).Color;
			btnLineColor.BackColor = tagCloud.ForeColor;
		}

		private void btnBorderColor_Click(object sender, EventArgs e)
		{
			dlgColor.Color = tagCloud.HoveredBorder.Color;
			if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				tagCloud.HoveredBorder.Color = btnBorderColor.BackColor = dlgColor.Color;
			tagCloud.Invalidate();
		}

		private void btnHighLightColor_Click(object sender, EventArgs e)
		{
			dlgColor.Color = (tagCloud.SelectedBackground as SolidBrush).Color;
			if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				(tagCloud.SelectedBackground as SolidBrush).Color = btnHighLightColor.BackColor = dlgColor.Color;
			tagCloud.Invalidate();
		}

		private void btnLineColor_Click(object sender, EventArgs e)
		{
			dlgColor.Color = tagCloud.ForeColor;
			if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				tagCloud.ForeColor = btnLineColor.BackColor = dlgColor.Color;
			tagCloud.Invalidate();
		}
	}
}
