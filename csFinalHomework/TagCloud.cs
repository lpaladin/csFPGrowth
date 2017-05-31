//////////////////////////////////////////////
// TagCloud.cs：标签云控件的实现。
// 作者：周昊宇
//////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace csFinalHomework
{
	/// <summary>
	/// 自定义的标签云控件。
	/// </summary>
	public partial class TagCloud : Control
	{
		/// <summary>
		/// 表示三维给定半径的球坐标空间中的一个点。
		/// 单位：弧度
		/// </summary>
		public struct SphericalCoordinate
		{
			public double θ { get; set; }
			public double φ { get; set; }

			public override string ToString()
			{
				return string.Format("极坐标：θ = {0}，φ = {1}", θ, φ);
			}
		}

		/// <summary>
		/// 表示一个带权重的标签云条目。
		/// </summary>
		[DebuggerDisplay("标签：名为{Name}，值为{Value}，坐标为{pos}")]
		public class TagItem : IComparable
		{
			/// <summary>
			/// 标签名字。
			/// </summary>
			public string Name { get; set; }

			/// <summary>
			/// 标签权重。
			/// </summary>
			public int Value { get; set; }

			/// <summary>
			/// 标签唯一编号。
			/// </summary>
			public short ID { get; set; }

			/// <summary>
			/// 标签自定义的附加信息。
			/// </summary>
			public object Tag { get; set; }

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			internal SphericalCoordinate pos;
			internal int rank;
			internal PointF lastRenderPos;

			public int CompareTo(object obj)
			{
				return Value.CompareTo((obj as TagItem).Value);
			}
		}

		/// <summary>
		/// 控件内部存储标签间关系的类。
		/// </summary>
		private class Bond
		{
			internal TagItem a, b;
			internal int strength;
		}
	
		/// <summary>
		/// 获取或设置标签云的条目集。
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<TagItem> Items { get; set; }

		/// <summary>
		/// 获取或设置条目集是否需要更新。
		/// </summary>
		public bool NeedUpdate { get; set; }

		/// <summary>
		/// 获取当前选中的条目。
		/// </summary>
		public TagItem SelectedItem
		{
			get
			{
				return selectedItem;
			}
		}

		/// <summary>
		/// 获取或设置鼠标悬停条目的边框笔刷。
		/// </summary>
		public Pen HoveredBorder { get; set; }

		/// <summary>
		/// 获取或设置选中条目的背景笔刷。
		/// </summary>
		public Brush SelectedBackground { get; set; }

		/// <summary>
		/// 获取或设置显示线条的缩放程度。
		/// 该属性的值设为最粗线条的粗细为佳。
		/// </summary>
		public new int Scale { get; set; }

		/// <summary>
		/// 当有条目被选中时触发。
		/// </summary>
		public event MouseEventHandler ItemSelected;

		private SphericalCoordinate view;
		private Point lastMousePos;
		private int radius;
		private double rotationAcceleration;
		private bool processing;
		private TagItem hoveredItem, selectedItem;
		private Hashtable bonds;

		/// <summary>
		/// 创建新的标签云控件。
		/// </summary>
		public TagCloud()
		{
			HoveredBorder = new Pen(Color.Yellow, 2);
			SelectedBackground = new SolidBrush(Color.LightBlue);
			selectedItem = null;
			rotationAcceleration = 0;
			NeedUpdate = true;
			processing = false;
			Items = new List<TagItem>();
			bonds = new Hashtable();
			InitializeComponent();
			this.DoubleBuffered = true;
		}

		/// <summary>
		/// 在标签云中给两个标签间的连线增加权重。
		/// </summary>
		/// <param name="a">两个标签之一</param>
		/// <param name="b">另一个标签</param>
		/// <param name="strength">增加的权重</param>
		public void AddBond(TagItem a, TagItem b, int strength)
		{
			if (a.ID > b.ID)
			{
				TagItem tmp = a;
				a = b;
				b = tmp;
			}

			// 拼接两个标签的唯一识别码作为该关系的Hash码
			int uniqueID = a.ID * (1 << 16) + b.ID;
			if (bonds.Contains(uniqueID))
				(bonds[uniqueID] as Bond).strength += strength;
			else
			{
				Bond bond = new Bond();
				bond.a = a;
				bond.b = b;
				bond.strength = strength;
				bonds.Add(uniqueID, bond);
			}
		}

		/// <summary>
		/// 清空所有标签间的连线。
		/// </summary>
		public void ClearBond()
		{
			bonds.Clear();
		}

		/// <summary>
		/// 通过Items的内容重新计算各个点的坐标。
		/// </summary>
		private void UpdateData()
		{
			processing = true;

			// 排序
			Items.Sort();

			// 将点平均分布在球面上
			int n = Items.Count, i;
			double goldenAngle = Math.PI * (3 - Math.Sqrt(5)),
				zFactor = 1 - 1.0 / n;
			for (i = 0; i < n; i++)
			{
				Items[i].rank = i;
				Items[i].pos.θ = goldenAngle * i;
				Items[i].pos.φ = Math.Asin(zFactor * (1 - 2.0 * i / (n - 1)));
				// Debug.WriteLine("Abs coord: " + Items[i].pos.θ + ", " + Items[i].pos.φ);
			}
			processing = NeedUpdate = false;
		}

		/// <summary>
		/// 计算平方。
		/// </summary>
		/// <param name="x">要计算的数字</param>
		/// <returns>该数字的平方</returns>
		private static double Pow2(double x)
		{
			return x * x;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);

			// 判断是否需要更新条目列表
			if (NeedUpdate)
			{
				if (!processing)
					UpdateData();
				else
					return;
			}
			hoveredItem = null;

			// 绘制所有条目
			foreach (TagItem item in Items)
			{
				SphericalCoordinate coord = item.pos;
				coord.θ -= view.θ;
				double x = Width * 0.4, y = Height * 0.4, r = (1 - Math.Sin(coord.θ)) * Math.Cos(coord.φ);
				Color color = Color.FromArgb((byte)(r / 4 * 255 + 127), (byte)(r / 2 * 255), 0, 0);
				x += radius * Math.Cos(coord.θ) * Math.Abs(Math.Cos(coord.φ));
				y += radius * Math.Sin(coord.φ);
				// Debug.WriteLine("Draw point at " + coord.θ + ", " + coord.φ);
				Font currFont = new Font(Font.FontFamily, Font.Size * (float) 
					((r + 1) * (1.3 - 0.6 * item.rank / Items.Count)));
				PointF startPos = new PointF((float) x, (float) y);
				RectangleF rectStr = new RectangleF(startPos, pe.Graphics.MeasureString(item.Name, currFont));
				
				// 判断鼠标是否在条目文字上方
				if (rectStr.Contains(lastMousePos.X, lastMousePos.Y))
				{
					pe.Graphics.DrawRectangle(HoveredBorder, Rectangle.Round(rectStr));
					hoveredItem = item;
				}

				// 给选中条目绘制背景
				if (item == SelectedItem)
					pe.Graphics.FillRectangle(SelectedBackground, Rectangle.Round(rectStr));
				pe.Graphics.DrawString(item.Name, currFont, new SolidBrush(color), startPos);
				item.lastRenderPos.X = startPos.X + rectStr.Width / 2;
				item.lastRenderPos.Y = startPos.Y + rectStr.Height / 2;
			}

			foreach (Bond bond in bonds.Values)
				pe.Graphics.DrawLine(new Pen(ForeColor, 4f * bond.strength / Scale),
					bond.a.lastRenderPos, bond.b.lastRenderPos);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			rotationAcceleration = 1.0 * e.X / Width - 0.5;
			lastMousePos = e.Location;
			timAnim.Enabled = true;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			radius = (Width < Height ? Width : Height) / 3;
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if ((selectedItem = hoveredItem) != null && ItemSelected != null)
				ItemSelected(this, e);
			Invalidate();
		}

		private void timAnim_Tick(object sender, EventArgs e)
		{
			view.θ += rotationAcceleration / 5;
			Invalidate();

			// 阻尼运动
			if (Math.Abs(rotationAcceleration *= 0.99) <= 0.05)
				timAnim.Enabled = false;
		}
	}
}
