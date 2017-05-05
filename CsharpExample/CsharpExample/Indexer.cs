
// 定义“索引器”使您可以创建作为“虚拟数组”的类。该类的实例可以使用 [] 数组访问运算符进行访问


// 由于索引器是使用 [] 运算符进行访问的，因此没有名称
// 索引器必须至少有一个参数。
// 尽管索引器功能强大，但有一点很重要，仅当类似数组的抽象化有意义时才使用索引器

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{

    public class FileByteArray
    {
        Stream stream;      // Holds the underlying stream
                            
        // used to access the file.
        // Create a new FileByteArray encapsulating a particular file.
        public FileByteArray(string fileName)
        {
            stream = new FileStream(fileName, FileMode.OpenOrCreate);
        }

        // Close the stream. This should be the last thing done
        // when you are finished.
        public void Close()
        {
            stream.Close();
            stream = null;
        }

        // Indexer to provide read/write access to the file.
        public byte this[long index]   // long is a 64-bit integer
        {
            // Read one byte at offset index and return it.
            get
            {
                byte[] buffer = new byte[1];
                stream.Seek(index, SeekOrigin.Begin);
                stream.Read(buffer, 0, 1);
                return buffer[0];
            }
            // Write one byte at offset index and return it.
            set
            {
                byte[] buffer = new byte[1] { value };
                stream.Seek(index, SeekOrigin.Begin);
                stream.Write(buffer, 0, 1);
            }
        }

        // Get the total length of the file.
        public long Length
        {
            get
            {
                return stream.Seek(0, SeekOrigin.End);
            }
        }
    }
    class Indexer: Instance<Indexer>
    {
        override public void Show() {

            FileByteArray fb = new FileByteArray("config.txt");

            fb[10] = 128;
            fb[12] = 1;

            fb.Close();
        }
    }
}
