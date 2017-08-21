﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection
{
    public class AList2 : IList
    {
        int[] arr = new int[30];
        int start = 15;
        int end = 15;

        public void AddEnd(int val)
        {
            arr[end++] = val;
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > end - start)
                throw new IndexOutOfRangeException();

            for (int i = ++end - 1; i >= pos + start; i--)
            {
                arr[i + 1] = arr[i];
            }
            arr[start + pos] = val;
        }

        public void AddStart(int val)
        {
            arr[--start] = val;
        }

        public void Clear()
        {
            start = 15;
            end = 15;
        }

        public int DelEnd()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            return arr[--end];
        }

        public int DelPos(int pos)
        {
            if (end - start == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > (end - start) - 1)
                throw new IndexOutOfRangeException();

            int ret = arr[start + pos];
            end--;
            for (int i = start + pos; i < end; i++)
            {
                arr[i] = arr[i + 1];
            }

            return ret;
        }

        public int DelStart()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            return arr[start++];
        }

        public int Get(int pos)
        {
            if (end - start == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > (end - start) - 1)
                throw new IndexOutOfRangeException();

            return arr[pos + start];
        }

        public void HalfReverse()
        {
            for (int j = start; j < start + (end - start) / 2; j++)
            {
                int temp = arr[start];
                for (int i = start; i < end - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[end - 1] = temp;
            }
        }

        public void Init(int[] ini)
        {
            if(ini == null)
            {
                start = 15;
                end = 15;
                return;
            }
           
            start -= ini.Length / 2;
            end += ini.Length - (ini.Length / 2);
            for (int i = start; i < end; i++)
            {
                arr[i] = ini[i - start];
            }
        }

        public int Max()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            int max = arr[start];
            for (int i = start + 1; i < end; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        public int MaxPos()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            int res = start;
            for (int i = start; i < end; i++)
            {
                if (arr[i] > arr[res])
                {
                    res = i;
                }
            }
            return res - start;
        }

        public int Min()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            int min = arr[start];
            for (int i = start + 1; i < end; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }

        public int MinPos()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            int res = start;
            for (int i = start; i < end; i++)
            {
                if (arr[i] < arr[res])
                {
                    res = i;
                }
            }
            return res - start;
        }

        public void Reverse()
        {
            for (int i = start, j = end - 1; i < start + (end - start) / 2; i++, j--)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        public void Set(int pos, int val)
        {
            if (end - start == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > (end - start) - 1)
                throw new IndexOutOfRangeException();

            arr[pos + start] = val;
        }

        public int Size()
        {
            return end - start;
        }

        public void Sort()
        {
            for (int i = start; i < end - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < end; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }

        public int[] ToArray()
        {
            int[] temp = new int[end - start];
            for (int i = start; i < end; i++)
            {
                temp[i-start] = arr[i];
            }
            return temp;
        }

        public override String ToString()
        {
            string ret = "";
            for (int i = start; i < end; i++)
            {
                ret += arr[i] + ((i != end - 1) ? ", " : "");
            }
            return ret;
        }
    }
}