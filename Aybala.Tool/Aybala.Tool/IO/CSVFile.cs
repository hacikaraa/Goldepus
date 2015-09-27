using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Aybala.Tool.IO
{
    enum EmptyLineBehavior
    {
        NoColumns,
        EmptyColumn,
        Ignore,
        EndOfFile,
    }

    abstract class CsvFileCommon
    {
        protected char[] SpecialChars = new char[] { ',', '"', '\r', '\n' };

        private const int DelimiterIndex = 0;
        private const int QuoteIndex = 1;

        public char Delimiter
        {
            get { return SpecialChars[DelimiterIndex]; }
            set { SpecialChars[DelimiterIndex] = value; }
        }

        public char Quote
        {
            get { return SpecialChars[QuoteIndex]; }
            set { SpecialChars[QuoteIndex] = value; }
        }
    }

    class CsvFileReader : CsvFileCommon, IDisposable
    {
        private StreamReader Reader;
        private string CurrLine;
        private int CurrPos;
        private EmptyLineBehavior EmptyLineBehavior;

        public CsvFileReader(System.IO.Stream stream,EmptyLineBehavior emptyLineBehavior = EmptyLineBehavior.NoColumns)
        {
            Reader = new StreamReader(stream);
            EmptyLineBehavior = emptyLineBehavior;
        }

        public CsvFileReader(string path,EmptyLineBehavior emptyLineBehavior = EmptyLineBehavior.NoColumns)
        {
            Reader = new StreamReader(path);
            EmptyLineBehavior = emptyLineBehavior;
        }

        public bool ReadRow(List<string> columns)
        {
            if (columns == null)
                throw new ArgumentNullException("columns");

        ReadNextLine:
            CurrLine = Reader.ReadLine();
            CurrPos = 0;
            if (CurrLine == null)
                return false;
            if (CurrLine.Length == 0)
            {
                switch (EmptyLineBehavior)
                {
                    case EmptyLineBehavior.NoColumns:
                        columns.Clear();
                        return true;
                    case EmptyLineBehavior.Ignore:
                        goto ReadNextLine;
                    case EmptyLineBehavior.EndOfFile:
                        return false;
                }
            }
            string column;
            int numColumns = 0;
            while (true)
            {
                if (CurrPos < CurrLine.Length && CurrLine[CurrPos] == Quote)
                    column = ReadQuotedColumn();
                else
                    column = ReadUnquotedColumn();
                if (numColumns < columns.Count)
                    columns[numColumns] = column;
                else
                    columns.Add(column);
                numColumns++;
                if (CurrLine == null || CurrPos == CurrLine.Length)
                    break;
                Debug.Assert(CurrLine[CurrPos] == Delimiter);
                CurrPos++;
            }
            if (numColumns < columns.Count)
                columns.RemoveRange(numColumns, columns.Count - numColumns);
            return true;
        }

        private string ReadQuotedColumn()
        {
            Debug.Assert(CurrPos < CurrLine.Length && CurrLine[CurrPos] == Quote);
            CurrPos++;
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                while (CurrPos == CurrLine.Length)
                {
                    CurrLine = Reader.ReadLine();
                    CurrPos = 0;
                    if (CurrLine == null)
                        return builder.ToString();
                    builder.Append(Environment.NewLine);
                }

                if (CurrLine[CurrPos] == Quote)
                {
                    int nextPos = (CurrPos + 1);
                    if (nextPos < CurrLine.Length && CurrLine[nextPos] == Quote)
                        CurrPos++;
                    else
                        break; 
                }
                builder.Append(CurrLine[CurrPos++]);
            }

            if (CurrPos < CurrLine.Length)
            {
                Debug.Assert(CurrLine[CurrPos] == Quote);
                CurrPos++;
                builder.Append(ReadUnquotedColumn());
            }
            return builder.ToString();
        }

        private string ReadUnquotedColumn()
        {
            int startPos = CurrPos;
            CurrPos = CurrLine.IndexOf(Delimiter, CurrPos);
            if (CurrPos == -1)
                CurrPos = CurrLine.Length;
            if (CurrPos > startPos)
                return CurrLine.Substring(startPos, CurrPos - startPos);
            return String.Empty;
        }

        public void Dispose()
        {
            Reader.Dispose();
        }
    }

}
