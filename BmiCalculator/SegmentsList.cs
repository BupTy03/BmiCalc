using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace SegmentsList
{
    /// <summary>
    /// Список интервалов.
    /// Класс, представляющий последовательно расположенные интервалы
    /// значений c ключом типа TKey.
    /// С каждым интервалом ассоциировано значение типа TValue.
    /// Следующее добавленное значение ключа TKey является началом нового интервала 
    /// и, одновременно, концом старого (предыдущего).
    /// Нижняя граница включена в интервал, а верхняя - нет.
    /// Например, чтобы получить такой список интервалов: [2;5)[5;9)[9;бесконечность)
    /// нужно добавить три значения:
    /// <code>
    /// SegmentsList<int, string> lst;
    /// lst.Add(2, "First interval");
    /// lst.Add(5, "Second interval");
    /// lst.Add(9, "Third interval");
    /// </code>
    /// Как видно из примера, можно добавить текстовое описание каждого интервала,
    /// используя в качестве типа TValue тип string.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    /// <typeparam name="TValue">Тип значения.</typeparam>
    class SegmentsList<TKey, TValue> where TKey : IComparable
    {
        public SegmentsList()
        {
        }

        /// <summary>
        /// Добавление нового интервала.
        /// </summary>
        /// <param name="lowerBound">
        /// Ключ, который станет нижней границей нового интревала и 
        /// верхней границей предыдущего.
        /// </param>
        /// <param name="value">Значение, которое будет ассоциировано с интервалом.</param>
        /// <returns>Возвращает true при успешном добавлении интервала.</returns>
        public bool Add(TKey lowerBound, TValue value)
        {
            Debug.Assert(lowerBound != null);

            var segment = new Segment(lowerBound, value);
            int index = m_data.BinarySearch(segment, new SegmentComp());
            if (index >= 0)
                return false;

            index = ~index;
            m_data.Insert(index, segment);
            return true;
        }

        /// <summary>
        /// Оператор индексации как для обычного массива.
        /// Возвращает значение, ассоциированное с интервалом,
        /// при передаче любого index, который входит в этот интервал [.., index, ...).
        /// </summary>
        /// <param name="index">Индекс - ключ по которому определяется интервал.</param>
        /// <returns>Значение, ассоциированное с этим интервалом.</returns>
        /// <exception cref="System.IndexOutOfRangeException">Бросается если интервал не найден.</exception>
        public TValue this[TKey index]
        {
            get
            {
                Debug.Assert(index != null);

                if (m_data.Count == 0)
                    throw new IndexOutOfRangeException();

                var segment = new Segment(index, default(TValue));
                int foundIndex = m_data.BinarySearch(segment, new SegmentComp());
                if (foundIndex >= 0)
                    return m_data[foundIndex].Value;

                foundIndex = ~foundIndex;
                return m_data[foundIndex - 1].Value;
            }
        }

        /// <summary>
        /// Класс, представляющий интервал.
        /// </summary>
        private struct Segment
        {
            public Segment(TKey lowerBound, TValue value)
            {
                Debug.Assert(lowerBound != null);

                LowerBound = lowerBound;
                Value = value;
            }

            /// <summary>
            /// Нижняя граница интервала.
            /// </summary>
            public TKey LowerBound { get; }
            /// <summary>
            /// Значение, ассоциированное с интервалом.
            /// </summary>
            public TValue Value { get; }
        }

        private class SegmentComp : IComparer<Segment>
        {
            public int Compare(Segment x, Segment y)
            {
                return x.LowerBound.CompareTo(y.LowerBound);
            }
        }

        /// <summary>
        /// Сегменты хрянятся последовательно в обычном сортированном списке.
        /// Инварианты класса:
        /// 1. Список хранит уникальные значения.
        /// 2. Список всегда отсортирован по ключу(по нижним границам сегмента).
        /// </summary>
        private List<Segment> m_data = new List<Segment>();
    }
}