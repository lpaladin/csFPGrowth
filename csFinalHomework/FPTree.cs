//////////////////////////////////////////////
// FPTree.cs：FP树的具体实现
// 作者：周昊宇
//////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace csFinalHomework
{
    /// <summary>
    /// FP树的具体实现。
    /// </summary>
    /// <typeparam name="T">项的类型</typeparam>
    public class FPTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// 当FP树的处理状态发生改变的时候触发。
        /// </summary>
        public event Action<string, int> StatusChanged;

        /// <summary>
        /// FP树的频繁项表头项目。
        /// </summary>
        public class FPTreeHeaderTableItem : IComparable<FPTreeHeaderTableItem>
        {
            /// <summary>
            /// 该项目的值。
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// 指向FP树中第一个为该值的结点。
            /// </summary>
            public FPTreeNode FirstNode { get; set; }

            /// <summary>
            /// 包含该值的交易数，即支持度。
            /// </summary>
            public int Occurrence { get; set; }

            /// <summary>
            /// 构造新的频繁项表头项。
            /// </summary>
            /// <param name="value">表头项目的值</param>
            /// <param name="initialOccurrence">该项初始出现次数</param>
            public FPTreeHeaderTableItem(T value, int initialOccurrence = 1)
            {
                Value = value;
                Occurrence = initialOccurrence;
                FirstNode = null;
            }

            /// <summary>
            /// 实现IComparable接口，用于按支持度排序。
            /// </summary>
            /// <param name="other">另一个对象</param>
            /// <returns>表示两个对象相对大小的值</returns>
            public int CompareTo(FPTreeHeaderTableItem other)
            {
                int result = Occurrence.CompareTo(other.Occurrence);
                if (result != 0)
                    return result;

                // 为防止相同支持度的项乱序，采取项值作为次级比较标准
                return Value.CompareTo(other.Value);
            }
        }

        /// <summary>
        /// 使用“左子右兄”表示的FP树的结点。
        /// </summary>
        public class FPTreeNode
        {
            /// <summary>
            /// 结点的值。
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// 到达该结点的交易数。
            /// </summary>
            public int TransactCount { get; set; }

            /// <summary>
            /// 指向FP树中下一个该值的结点。
            /// </summary>
            public FPTreeNode NextSameValNode { get; set; }

            /// <summary>
            /// 指向该结点的子结点。
            /// </summary>
            public FPTreeNode LChild { get; set; }

            /// <summary>
            /// 指向该结点的兄弟结点。
            /// </summary>
            public FPTreeNode RSibling { get; set; }

            /// <summary>
            /// 指向该结点的父结点。
            /// </summary>
            public FPTreeNode Parent { get; set; }

            /// <summary>
            /// 记录该结点是否已被连到上一个该值结点，防止结点连成环。
            /// </summary>
            public bool AlreadyBeenConnected { get; set; }

            /// <summary>
            /// 构造新的FP树结点。
            /// </summary>
            /// <param name="initialCount">结点初始的事务计数</param>
            public FPTreeNode(int initialCount = 1)
            {
                NextSameValNode = LChild = RSibling = Parent = null;
                TransactCount = initialCount;
                AlreadyBeenConnected = false;
            }

            /// <summary>
            /// 在子结点中找到对应值的结点，
            /// 并增加其事务计数。
            /// 若找不到则连接一个新结点。
            /// </summary>
            /// <param name="value">要查找的值</param>
            /// <param name="by">事务计数增加量</param>
            /// <returns>找到的结点</returns>
            public FPTreeNode IncreaseChild(T value, int by = 1)
            {
                // 无子结点，新增结点
                if (LChild == null)
                {
                    LChild = new FPTreeNode(by);
                    LChild.Value = value;
                    LChild.Parent = this;
                    return LChild;
                }

                // 遍历子结点
                FPTreeNode curr = LChild, last = null;
                while (curr != null)
                    if (curr.Value.CompareTo(value) == 0)
                    {
                        curr.TransactCount += by;
                        return curr;
                    }
                    else
                    {
                        last = curr;
                        curr = curr.RSibling;
                    }

                // 找不到该值，在最右子结点后新增结点
                last.RSibling = new FPTreeNode(by);
                last.RSibling.Value = value;
                last.RSibling.Parent = this;
                return last.RSibling;
            }
        }

        /// <summary>
        /// 频繁项目集。
        /// </summary>
        public class FrequentItemSet
        {
            /// <summary>
            /// 该频繁项集的项目内容。
            /// </summary>
            public T[] Items { get; set; }

            /// <summary>
            /// 该频繁项集的支持度。
            /// </summary>
            public int Support { get; set; }

            /// <summary>
            /// 通过一个值和父频繁项集构建新的频繁项集。
            /// </summary>
            /// <param name="onlyItem">该项</param>
            /// <param name="support">项集的支持度</param>
            /// <param name="parentItemSet">父频繁项集</param>
            public FrequentItemSet(T onlyItem, int support, List<T> parentItemSet)
            {
                Items = new T[parentItemSet.Count + 1];
                parentItemSet.CopyTo(Items, 0);
                Items[parentItemSet.Count] = onlyItem;
                Support = support;
            }

            /// <summary>
            /// 通过条件模式基和父频繁项集构建新的频繁项集。
            /// </summary>
            /// <param name="items">条件模式基</param>
            /// <param name="support">项集的支持度</param>
            /// <param name="parentItemSet">父频繁项集</param>
            public FrequentItemSet(List<T> items, int support, List<T> parentItemSet)
            {
                Items = new T[parentItemSet.Count + items.Count];
                parentItemSet.CopyTo(Items, 0);
                items.CopyTo(Items, parentItemSet.Count);
                Support = support;
            }

            /// <summary>
            /// （内部使用）通过已经建好的数组，不复制，直接构建新的频繁项集
            /// </summary>
            /// <param name="items">已经建好的数组</param>
            /// <param name="support">项集的支持度</param>
            internal FrequentItemSet(T[] items, int support)
            {
                Items = items;
                Support = support;
            }
        }

        /// <summary>
        /// FP树的根结点。
        /// </summary>
        private FPTreeNode root;

        /// <summary>
        /// FP树按照支持度排序后的频繁项表头项目表。
        /// </summary>
        private List<FPTreeHeaderTableItem> sortedHeaderTable;

        /// <summary>
        /// 该FP树设定的支持度阈值。
        /// </summary>
        private readonly int supportThreshold;

        /// <summary>
        /// 通过带有支持度的条件模式基构建新的FP树。
        /// </summary>
        /// <param name="allDataWithSupport">带有支持度的条件模式基集合</param>
        /// <param name="supportThreshold">支持度阈值</param>
        private FPTree(List<KeyValuePair<List<T>, int>> allDataWithSupport, int supportThreshold = 0)
        {
            root = new FPTreeNode();
            this.supportThreshold = supportThreshold;

            // 第一次扫描：统计所有项的支持度并记入频繁项表头项目表
            Hashtable headerTable = new Hashtable();
            foreach (KeyValuePair<List<T>, int> transaction in allDataWithSupport)
                foreach (T item in transaction.Key)
                    if (headerTable.ContainsKey(item))
                        (headerTable[item] as FPTreeHeaderTableItem).Occurrence += transaction.Value;
                    else
                        headerTable[item] = new FPTreeHeaderTableItem(item, transaction.Value);

            // 第二次扫描：对各个交易按照支持度排序并构建FP树
            int validHeaderCount = 0;
            Hashtable lastNodeWithValue = new Hashtable();
            foreach (KeyValuePair<List<T>, int> transaction in allDataWithSupport)
            {
                FPTreeNode lastNode = root;
                transaction.Key.Sort(new Comparison<T>((a, b) =>
                    -(headerTable[a] as FPTreeHeaderTableItem).CompareTo((headerTable[b] as FPTreeHeaderTableItem))));
                foreach (T item in transaction.Key)
                {
                    FPTreeHeaderTableItem header = headerTable[item] as FPTreeHeaderTableItem;
                    if (header.Occurrence < supportThreshold)
                        break;
                    validHeaderCount++;
                    lastNode = lastNode.IncreaseChild(item, transaction.Value);
                    if (!lastNode.AlreadyBeenConnected)
                    {
                        if (lastNodeWithValue.Contains(item))
                            (lastNodeWithValue[item] as FPTreeNode).NextSameValNode = lastNode;
                        else
                            header.FirstNode = lastNode;
                        lastNodeWithValue[item] = lastNode;
                        lastNode.AlreadyBeenConnected = true;
                    }
                }
            }

            // 对频繁项表头项目表按照支持度排序
            sortedHeaderTable = new List<FPTreeHeaderTableItem>(validHeaderCount);
            foreach (FPTreeHeaderTableItem item in headerTable.Values)
                if (item.Occurrence >= supportThreshold)
                    sortedHeaderTable.Add(item);
            sortedHeaderTable.Sort();

        }

        /// <summary>
        /// 通过所有项集构建新的FP树。
        /// </summary>
        /// <param name="statChangedCallback">当FP树处理状态发生改变时要调用的回调函数</param>
        /// <param name="allData">所有项集的集合</param>
        /// <param name="supportThreshold">支持度阈值</param>
        public FPTree(Action<string, int> statChangedCallback, List<List<T>> allData, int supportThreshold = 0)
        {
            root = new FPTreeNode();
            StatusChanged += statChangedCallback;
            this.supportThreshold = supportThreshold;

            if (StatusChanged != null)
                StatusChanged("正在构建FP树 - 第一次扫描", 0);

            // 第一次扫描：统计所有项的支持度并记入频繁项表头项目表
            Hashtable headerTable = new Hashtable();
            foreach (List<T> transaction in allData)
                foreach (T item in transaction)
                    if (headerTable.ContainsKey(item))
                        (headerTable[item] as FPTreeHeaderTableItem).Occurrence++;
                    else
                        headerTable[item] = new FPTreeHeaderTableItem(item);

            if (StatusChanged != null)
                StatusChanged("正在构建FP树 - 第二次扫描", 0);

            // 第二次扫描：对各个交易按照支持度排序并构建FP树
            int validHeaderCount = 0;
            Hashtable lastNodeWithValue = new Hashtable();
            foreach (List<T> transaction in allData)
            {
                FPTreeNode lastNode = root;
                transaction.Sort(new Comparison<T>((a, b) => 
                    -(headerTable[a] as FPTreeHeaderTableItem).CompareTo((headerTable[b] as FPTreeHeaderTableItem))));
                foreach (T item in transaction)
                {
                    FPTreeHeaderTableItem header = headerTable[item] as FPTreeHeaderTableItem;
                    if (header.Occurrence < supportThreshold)
                        break;
                    validHeaderCount++;
                    lastNode = lastNode.IncreaseChild(item);
                    if (!lastNode.AlreadyBeenConnected)
                    {
                        if (lastNodeWithValue.Contains(item))
                            (lastNodeWithValue[item] as FPTreeNode).NextSameValNode = lastNode;
                        else
                            header.FirstNode = lastNode;
                        lastNodeWithValue[item] = lastNode;
                        lastNode.AlreadyBeenConnected = true;
                    }
                }
            }

            // 对频繁项表头项目表按照支持度排序
            sortedHeaderTable = new List<FPTreeHeaderTableItem>(validHeaderCount);
            foreach (FPTreeHeaderTableItem item in headerTable.Values)
                if (item.Occurrence >= supportThreshold)
                    sortedHeaderTable.Add(item);
            sortedHeaderTable.Sort();

            if (StatusChanged != null)
                StatusChanged("FP树构建完成 - 准备查询频繁项集", 0);
        }

        /// <summary>
        /// 向上遍历创建条件模式基。
        /// </summary>
        /// <param name="currPatternBase">当前构造中的频繁模式基</param>
        /// <param name="begin">FP树中的起始结点</param>
        private static void GeneratePatternBase(List<T> currPatternBase, FPTreeNode begin)
        {
            if (begin.Parent != null) // 跳过root
            {
                GeneratePatternBase(currPatternBase, begin.Parent);
                currPatternBase.Add(begin.Value);
            }
        }

        /// <summary>
        /// 挖掘当前FP树的频繁项集。
        /// </summary>
        /// <param name="allFrequentItemSet">找到新的频繁项集时的回调函数</param>
        /// <param name="ignoreSingleItem">是否忽略单项集</param>
        /// <returns>找到的频繁项集个数</returns>
        public int StartDig(Action<FrequentItemSet> allFrequentItemSet, bool ignoreSingleItem)
        {
            int setCount = 0;
            Dig(allFrequentItemSet, new List<T>(), ref setCount, ignoreSingleItem);
            return setCount;
        }

        /// <summary>
        /// 尝试该单路FP树所有结点的组合。
        /// </summary>
        /// <param name="allCombinations">找到新的组合（即频繁项集）时的回调函数</param>
        /// <param name="parentItemSet">父频繁项集</param>
        /// <param name="startNode">组合的起始结点</param>
        /// <param name="result">当前构造中的组合</param>
        /// <param name="minTransactCount">尝试过程中所选取结点的最小支持度</param>
        /// <param name="setCount">传递频繁项集的累计数目</param>
        private static void Combine(Action<FrequentItemSet> allCombinations, List<T> parentItemSet,
            FPTreeNode startNode, List<T> result, int minTransactCount, ref int setCount)
        {
            if (startNode != null)
            {
                result.Add(startNode.Value);
                Combine(allCombinations, parentItemSet, startNode.LChild, result,
                    minTransactCount < startNode.TransactCount ? minTransactCount : startNode.TransactCount, ref setCount);
                result.RemoveAt(result.Count - 1);
                Combine(allCombinations, parentItemSet, startNode.LChild, result, minTransactCount, ref setCount);
            }
            else if (result.Count > 0)
            {
                if (allCombinations != null)
                    allCombinations(new FrequentItemSet(result, minTransactCount, parentItemSet));
                setCount++;
            }
        }

        /// <summary>
        /// 挖掘当前FP树或条件FP树的频繁项集。
        /// </summary>
        /// <param name="targetList">找到新的频繁项集时的回调函数</param>
        /// <param name="parentItemSet">父频繁项集</param>
        /// <param name="setCount">传递频繁项集的累计数目</param>
        /// <param name="ignoreSingleItem">是否忽略单项集</param>
        private void Dig(Action<FrequentItemSet> targetList, List<T> parentItemSet, ref int setCount, bool ignoreSingleItem)
        {
            // 检查是否为单路径树
            FPTreeNode curr = root;
            while (curr != null && curr.RSibling == null)
                curr = curr.LChild;
            if (curr == null)
            {
                Combine(targetList, parentItemSet, root.LChild, new List<T>(), int.MaxValue, ref setCount);
                return;
            }

            // 从支持度从低到高遍历结点
            int i;
            for (i = 0; i < sortedHeaderTable.Count; i++)
            {

                if (StatusChanged != null)
                    StatusChanged(string.Format("查询频繁项集 - 构建条件模式子树 {0}/{1}",
                        i + 1, sortedHeaderTable.Count), setCount);

                // 创建单项集
                if (parentItemSet.Count > 0 || !ignoreSingleItem)
                {
                    if (targetList != null)
                        targetList(new FrequentItemSet(sortedHeaderTable[i].Value, sortedHeaderTable[i].Occurrence, parentItemSet));
                    setCount++;
                }

                // 构建条件模式基
                List<KeyValuePair<List<T>, int>> subPatternBases = new List<KeyValuePair<List<T>, int>>();
                FPTreeNode p = sortedHeaderTable[i].FirstNode;

                // 遍历所有同值结点
                while (p != null)
                {
                    List<T> currPatternBase = new List<T>();

                    // 从该结点向上遍历路径，构建带有最小支持度的条件模式基
                    GeneratePatternBase(currPatternBase, p.Parent);
                    subPatternBases.Add(new KeyValuePair<List<T>, int>(currPatternBase, 
                        p.TransactCount));
                    p = p.NextSameValNode;
                }
                if (subPatternBases.Count > 0)
                {
                    if (StatusChanged != null)
                        StatusChanged(string.Format(
                            "查询频繁项集 - 递归条件模式子树 {0}/{1} 该子树开始递归时已找到项集数：{2}",
                            i + 1, sortedHeaderTable.Count, setCount), setCount);
                    parentItemSet.Add(sortedHeaderTable[i].FirstNode.Value);

                    // 使用构建出的带有最小支持度的条件模式基构建新的FP树，并递归进行频繁项集挖掘
                    new FPTree<T>(subPatternBases, supportThreshold).Dig(targetList, parentItemSet, ref setCount, ignoreSingleItem);
                    parentItemSet.RemoveAt(parentItemSet.Count - 1);
                }
            }
        }
    }
}
