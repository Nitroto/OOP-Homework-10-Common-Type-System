using System;
using System.Collections;

namespace StringDisperser
{
    public class StringDisperser: ICloneable,IComparable<StringDisperser>, IEnumerable
    {
        private string[] strings;

        public StringDisperser(params string[] strings)
        {
            this.Strings = strings;
        }

        public string[] Strings
        {
            get
            {
                //Return cloned array because there is a possibility 
                //if return the original to be modified by enumeratora
                string[] cloneArray = new string[this.strings.Length];
                Array.Copy(this.strings, cloneArray, this.strings.Length);
                return cloneArray;
            }
            private set
            {
                this.strings = value;
            }
        }
        public override bool Equals(object obj)
        {
            StringDisperser other = (StringDisperser)obj;
            return this.ToString()==other.ToString();
        }
        public static bool operator ==(StringDisperser thisStrings, StringDisperser otherStrings)
        {
            return thisStrings.Equals(thisStrings);
        }
        public static bool operator !=(StringDisperser thisStrings, StringDisperser otherStrings)
        {
            return thisStrings.Equals(otherStrings);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override string ToString()
        {
            string output = string.Join("", this.Strings);
            return output;
        }

        public object Clone()
        {
            string[] cloneArray = new string[this.strings.Length];
            Array.Copy(this.strings, cloneArray, this.strings.Length);
            return new StringDisperser(cloneArray);
        }

        public int CompareTo(StringDisperser other)
        {
            return this.ToString().CompareTo(other.ToString());
        }

        public IEnumerator GetEnumerator()
        {
            string disperser = this.ToString();

            for (var i = 0; i < disperser.Length; i++)
            {
                yield return disperser[i];
            }
        }
    }
}
