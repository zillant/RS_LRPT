//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Collections;
//using System.Threading.Tasks;

//namespace ReceivingStation.Demodulator
//{

//    public class FifoStream : Stream
//    {
//        private const int BlockSize = 65536;
//        private const int MaxBlocksInCache = (3 * 1024 * 1024) / BlockSize;

//        private int m_Size;
//        private int m_RPos;
//        private int m_WPos;
//        private Stack m_UsedBlocks = new Stack();
//        private ArrayList m_Blocks = new ArrayList();

//        private byte[] AllocBlock()
//        {
//            byte[] Result = null;
//            Result = m_UsedBlocks.Count > 0 ? (byte[])m_UsedBlocks.Pop() : new byte[BlockSize];
//            return Result;
//        }
//        private void FreeBlock(byte[] block)
//        {
//            if (m_UsedBlocks.Count < MaxBlocksInCache)
//                m_UsedBlocks.Push(block);
//        }
//        private byte[] GetWBlock()
//        {
//            byte[] Result = null;
//            if (m_WPos < BlockSize && m_Blocks.Count > 0)
//                Result = (byte[])m_Blocks[m_Blocks.Count - 1];
//            else
//            {
//                Result = AllocBlock();
//                m_Blocks.Add(Result);
//                m_WPos = 0;
//            }
//            return Result;
//        }

//        // Stream members
//        public override bool CanRead
//        {
//            get { return true; }
//        }
//        public override bool CanSeek
//        {
//            get { return false; }
//        }
//        public override bool CanWrite
//        {
//            get { return true; }
//        }
//        public override long Length
//        {
//            get
//            {
//                lock (this)
//                    return m_Size;
//            }
//        }
//        public override long Position
//        {
//          get { throw new InvalidOperationException(); }
//          set {throw new InvalidOperationException(); }
//        }
//        public override void Close()
//        {
//            Flush();
//        }
//        public override void Flush()
//        {
//            lock (this)
//            {
//                foreach (byte[] block in m_Blocks)
//                    FreeBlock(block);
//                m_Blocks.Clear();
//                m_RPos = 0;
//                m_WPos = 0;
//                m_Size = 0;
//            }
//        }
//        public override void SetLength(long len)
//        {
//            throw new InvalidOperationException();
//        }
//        public override long Seek(long pos, SeekOrigin o)
//        {
//            throw new InvalidOperationException();
//        }
//        public override int Read(byte[] buf, int ofs, int count)
//        {
//            lock (this)
//            {
//                int Result = Peek(buf, ofs, count);
//                Advance(Result);
//                return Result;
//            }
//        }
//        public override void Write(byte[] buf, int ofs, int count)
//        {
//            lock (this)
//            {
//                int Left = count;
//                while (Left > 0)
//                {
//                    int ToWrite = Math.Min(BlockSize - m_WPos, Left);
//                    Array.Copy(buf, ofs + count - Left, GetWBlock(), m_WPos, ToWrite);
//                    m_WPos += ToWrite;
//                    Left -= ToWrite;
//                }
//                m_Size += count;
//            }
//        }

//        // extra stuff
//        public int Advance(int count)
//        {
//            lock (this)
//            {
//                int SizeLeft = count;
//                while (SizeLeft > 0 && m_Size > 0)
//                {
//                    if (m_RPos == BlockSize)
//                    {
//                        m_RPos = 0;
//                        FreeBlock((byte[])m_Blocks[0]);
//                        m_Blocks.RemoveAt(0);
//                    }
//                    int ToFeed = m_Blocks.Count == 1 ? Math.Min(m_WPos - m_RPos, SizeLeft) : Math.Min(BlockSize - m_RPos, SizeLeft);
//                    m_RPos += ToFeed;
//                    SizeLeft -= ToFeed;
//                    m_Size -= ToFeed;
//                }
//                return count - SizeLeft;
//            }
//        }
//        public int Peek(byte[] buf, int ofs, int count)
//        {
//            lock (this)
//            {
//                int SizeLeft = count;
//                int TempBlockPos = m_RPos;
//                int TempSize = m_Size;

//                int CurrentBlock = 0;
//                while (SizeLeft > 0 && TempSize > 0)
//                {
//                    if (TempBlockPos == BlockSize)
//                    {
//                        TempBlockPos = 0;
//                        CurrentBlock++;
//                    }
//                    int Upper = CurrentBlock < m_Blocks.Count - 1 ? BlockSize : m_WPos;
//                    int ToFeed = Math.Min(Upper - TempBlockPos, SizeLeft);
//                    Array.Copy((byte[])m_Blocks[CurrentBlock], TempBlockPos, buf, ofs + count - SizeLeft, ToFeed);
//                    SizeLeft -= ToFeed;
//                    TempBlockPos += ToFeed;
//                    TempSize -= ToFeed;
//                }
//                return count - SizeLeft;
//            }
//        }
//    }

//}

//namespace ReceivingStation.Demodulator
//{
//    using System;
//    using System.IO;
//    using System.Threading;

//    public class FifoStream : Stream
//    {
//        #region Fields

//        public override bool CanRead = > true;
//        public override bool CanSeek = > false;
//        public override bool CanWrite = > true;

//        private byte[] buffer;
//        private int end;
//        private int length;
//        private int start;

//        #endregion Fields

//        #region Constructors

//        public FifoStream(int bufferSize)
//        {
//            end = 0;
//            start = 0;

//            length = 0;
//            buffer = new byte[bufferSize];
//        }

//        #endregion Constructors

//        #region Properties

//        public virtual int Available
//        {
//            get
//            {
//                lock (this)
//                {
//                    return length;
//                }
//            }
//        }

//        public virtual int Capacity
//        {
//            get
//            {
//                lock (this)
//                {
//                    return buffer.Length;
//                }
//            }
//        }

//        public override long Length
//        {
//            get { throw new NotSupportedException(); }
//        }

//        public override long Position
//        {
//            get
//            {
//                throw new NotSupportedException();
//            }
//            set
//            {
//                throw new NotSupportedException();
//            }
//        }

//        public override bool CanRead => throw new NotImplementedException();

//        public override bool CanSeek => throw new NotImplementedException();

//        public override bool CanWrite => throw new NotImplementedException();

//        private int BytesFree
//        {
//            get
//            {
//                lock (this)
//                {
//                    return Capacity - length;
//                }
//            }
//        }

//        #endregion Properties

//        #region Methods

//        public override void Flush()
//        {
//        }

//        public override int Read(byte[] buffer, int offset, int count)
//        {
//            lock (this)
//            {
//                while (true)
//                {
//                    if (length == 0)
//                    {
//                        Monitor.Wait(this);

//                        continue;
//                    }

//                    int bytesAfterStart;

//                    if (end > start)
//                    {
//                        bytesAfterStart = end - start;
//                    }
//                    else
//                    {
//                        bytesAfterStart = Capacity - start;
//                    }

//                    var x = Math.Min(bytesAfterStart, count);

//                    Array.Copy(this.buffer, start, buffer, offset, x);

//                    start += x;
//                    start %= Capacity;
//                    length -= x;

//                    return x;
//                }
//            }
//        }

//        public override int ReadByte()
//        {
//            lock (this)
//            {
//                while (true)
//                {
//                    if (length == 0)
//                    {
//                        Monitor.Wait(this);

//                        continue;
//                    }

//                    var retval = buffer[start];

//                    start++;
//                    start %= Capacity;
//                    length--;

//                    return retval;
//                }
//            }
//        }

//        public virtual int ReadToStream(Stream dest, int count)
//        {
//            lock (this)
//            {
//                for (; ; )
//                {
//                    if (length == 0)
//                    {
//                        Monitor.Wait(this);

//                        continue;
//                    }

//                    if (count > length)
//                    {
//                        count = length;
//                    }

//                    int bytesAfterStart;
//                    if (end > start)
//                    {
//                        bytesAfterStart = end - start;
//                    }
//                    else
//                    {
//                        bytesAfterStart = Capacity - start;
//                    }

//                    var x = Math.Min(bytesAfterStart, count);

//                    dest.Write(buffer, start, x);

//                    start += x;
//                    start %= Capacity;
//                    length -= x;

//                    return x;
//                }
//            }
//        }

//        public override long Seek(long offset, SeekOrigin origin)
//        {
//            throw new NotSupportedException();
//        }

//        public override void SetLength(long value)
//        {
//            throw new NotSupportedException();
//        }

//        public override void Write(byte[] buffer, int offset, int count)
//        {
//            lock (this)
//            {
//                if (BytesFree < count)
//                {
//                    Rebuild(Capacity + count - BytesFree);
//                }

//                int freeSpaceAfterEnd;

//                if (end >= start)
//                {
//                    freeSpaceAfterEnd = Capacity - end;
//                }
//                else
//                {
//                    freeSpaceAfterEnd = start - end;
//                }

//                var x = Math.Min(count, freeSpaceAfterEnd);

//                Array.Copy(buffer, offset, this.buffer, end, x);

//                if (count - x > 0)
//                {
//                    Array.Copy(buffer, offset + freeSpaceAfterEnd, this.buffer, 0, count - x);
//                }

//                end += count;
//                end %= Capacity;
//                length += count;

//                Monitor.PulseAll(this);
//            }
//        }

//        public virtual int WriteFromStream(Stream source, int maxCount)
//        {
//            lock (this)
//            {
//                if (BytesFree < maxCount)
//                {
//                    Rebuild(Capacity + maxCount - BytesFree);
//                }

//                int freeSpaceAfterEnd;

//                if (end >= start)
//                {
//                    freeSpaceAfterEnd = Capacity - end;
//                }
//                else
//                {
//                    freeSpaceAfterEnd = start - end;
//                }

//                var x = Math.Min(maxCount, freeSpaceAfterEnd);

//                x = source.Read(buffer, end, x);

//                end += x;
//                end %= Capacity;
//                length += x;

//                Monitor.PulseAll(this);

//                return x;
//            }
//        }

//        protected virtual void Rebuild(int minimumSize)
//        {
//            var newCapacity = this.buffer.Length * 2;

//            while (newCapacity < minimumSize)
//            {
//                newCapacity *= 2;
//            }

//            var newBuffer = new byte[newCapacity];

//            var x = 0;

//            while (length > 0)
//            {
//                x += Read(newBuffer, x, length);
//            }

//            buffer = newBuffer;
//            start = 0;
//            end = x;
//            length = x;
//        }

//        #endregion Methods
//    }
//}
